// Copyright (C) ALiwoto 2019 - 2020
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of the source code.

using System.Threading.Tasks;
using WotoProvider.EventHandlers;
using SAO.SandBox;
using SAO.Security;
using SAO.Controls;
using SAO.GameObjects.ServerObjects;

namespace SAO.GameObjects.Chatting
{
    /// <summary>
    /// you can get <see cref="ChatConfiguration"/> with this
    /// class, but this class originally will manage the messages,
    /// it means it will get and send the messages from and to the database.
    /// it will also create the database space needed for chatting and needed for
    /// chat configuration.
    /// but the chat configuration working is not here,
    /// please check <see cref="ChatConfiguration.CreateNewConfiguration(ChatChannels)"/>,
    /// for example.
    /// </summary>
    public class ChatManager
    {
        //-------------------------------------------------
        #region Constants Region
        public const string ChatDataBaseLocation    = "チャット";
        /// <summary>
        /// The Value is Gaijin (means foreigner)
        /// </summary>
        public const string CharSeparator           = "／）外人’＋";
        public const string ManagerWorkerName       = "Chat Manager Worker";
        public const string CLEAR_COMMAND           = "/clear";
        public const string CHANGE_AVATAR_COMMAND   = "/change_avatar";
        public const string ADD_AVATAR_COMMAND      = "/add_avatar";
        public const string CHANGE_FRAME_COMMAND    = "/change_frame";
        public const string ADD_FRAME_COMMAND       = "/add_frame";
        public const string CHANGE_POS_COMMAND1     = "/change_pos";
        public const string CHANGE_POS_COMMAND2     = "/change_position";
        public const int WorkerInterval             = 2700;
        public const int MAXIMUM_MESSAGES           = 40;
        #endregion
        //-------------------------------------------------
        #region Properties Region
        public GameControls.ChatBackgroundLabel Father { get; }
        public ChatConfiguration Configuration { get; private set; }
        public MessageList ChatMessages { get; private set; }
        public ChatMessage WaitingMessage { get; private set; }
        public Trigger ManagerWorker { get; private set; }
        public bool IsKeepingAlive { get; private set; }
        public bool IsSendingMessage { get; private set; }
        public bool IsReloading { get; private set; }
        public ChatChannels Channel { get; }
        #endregion
        //-------------------------------------------------
        #region Events Region
        public event ChatUpdateEventHandler Updated;
        public event ChatReloadedEventHandler ReloadEnded;
        public event ChatSentEventHandler ChatSent;
        #endregion
        //-------------------------------------------------
        #region Constructors Region
        private ChatManager(ChatChannels channel, GameControls.ChatBackgroundLabel father)
        {
            Channel = channel;
            Father = father;
        }
        private ChatManager(ChatChannels channel)
        {
            Channel = channel;
        }
        public ChatMessage this[int id]
        {
            get
            {
                return ChatMessages[id];
            }
        }
        #endregion
        //-------------------------------------------------
        #region Ordinary Methods Region
        public StrongString GetForServer()
        {
            // for now, please just return the message list's 
            // GetForServer method.
            return ChatMessages.GetForServer();
        }
        public async Task<bool> ClearMessages()
        {
            ChatMessages = MessageList.GetEmptyList();
            await UpdateChatMessages();
            return false;
        }
        public async Task<bool> GetMessages()
        {
            IsReloading = true;
            var existingFile =
                    await ThereIsServer.Actions.GetAllContentsByRef(
                        ThereIsServer.ServersInfo.MyServers[ChatConfiguration.BasicDataBaseNum + (int)Channel],
                        ChatDataBaseLocation);
            if (existingFile.IsDeadCallBack || ThereIsServer.ServerSettings.HasConnectionClosed)
            {
                NoInternetConnectionSandBox.PrepareConnectionClosedSandBox();
                return false; // don't set ServerSettings.IsWaitingForServerChecking = false;
            }
            ChatMessages = ParseToMessages(existingFile.Decode());
            IsReloading = false; // do NOT set this value in the upper hand.
            Updated?.Invoke(this, Father);
            return true;
        }
        /// <summary>
        /// Send a Message to the current Chat channel.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task<bool> SendMessage(ChatMessage message)
        {
            if (IsSendingMessage)
            {
                return false;
            }
            if (IsReloading)
            {
                WaitingMessage = message;
                ReloadEnded -= SendMessage;
                ReloadEnded += SendMessage;
                return false;
            }
            IsSendingMessage = true;
            if (message.IsCommand)
            {
                CommandWorks(message);
            }
            else
            {
                ChatMessages.Add(message);
            }
            
            CheckLength();
            await UpdateChatMessages();
            IsSendingMessage = false;
            if (!(WaitingMessage is null))
            {
                WaitingMessage = null;
            }
            var sent = await GetMessages();
            ChatSent?.Invoke(this);
            return sent;
        }
        public void KeepAlive()
        {
            if (IsKeepingAlive)
            {
                return;
            }
            IsKeepingAlive = true;
            if (ManagerWorker is null)
            {
                ManagerWorker = new Trigger()
                {
                    Enabled = false,
                    Name = ManagerWorkerName,
                    SingleLineWorker = true,
                    Interval = WorkerInterval,
                    Index = 0,
                    Tag = this,
                };
            }
            ManagerWorker.Tick -= ManagerWorker_Tick;
            ManagerWorker.Tick += ManagerWorker_Tick;
            ManagerWorker.Start();
        }
        public void KillAlive()
        {
            if (!IsKeepingAlive)
            {
                return;
            }
            if (!(ManagerWorker is null))
            {
                ManagerWorker.Stop();
                ManagerWorker.Dispose();
                ManagerWorker = null;
            }
        }
        private async void ManagerWorker_Tick(Trigger sender, TickHandlerEventArgs<Trigger> handler)
        {
            if (IsSendingMessage || IsReloading)
            {
                return;
            }
            // the IsReloading value is setted in this method.
            await GetMessages();
            if (WaitingMessage != null)
            {
                ReloadEnded?.Invoke(WaitingMessage);
            }
            
        }
        private async Task<DataBaseDataChangedInfo> UpdateChatMessages()
        {
            var Existing = await ThereIsServer.Actions.GetAllContentsByRef(
                ThereIsServer.ServersInfo.MyServers[ChatConfiguration.BasicDataBaseNum + (int)Channel],
                ChatDataBaseLocation);
            if (Existing.IsDeadCallBack || ThereIsServer.ServerSettings.HasConnectionClosed)
            {
                NoInternetConnectionSandBox.PrepareConnectionClosedSandBox();
                return null; // don't set ServerSettings.IsWaitingForServerChecking = false;
            }
            return await ThereIsServer.Actions.UpdateFile(
                ThereIsServer.ServersInfo.MyServers[ChatConfiguration.BasicDataBaseNum + (int)Channel],
                ChatDataBaseLocation,
                new DataBaseUpdateRequest("BY SAO_Game", 
                QString.Parse(GetForServer(), false), Existing[0].Sha));
        }
        private MessageList ParseToMessages(StrongString serverValue)
        {
            StrongString[] myStrings = serverValue.Split(CharSeparator);
            ChatMessage[] messages = new ChatMessage[myStrings.Length];
            for (int i = 0; i < messages.Length; i++)
            {
                messages[i] = ChatMessage.ParseExact(myStrings[i]);
            }
            return new MessageList(messages);
        }
        private void CheckLength()
        {
            if (ChatMessages.Length >= MAXIMUM_MESSAGES)
            {
                ChatMessages.RemoveRange(0,
                    ChatMessages.Length - MAXIMUM_MESSAGES + 1);
            }
        }
        private void CommandWorks(in ChatMessage message)
        {
            var context = message.MessageContext.ToLower();
            StrongString[] contexts = context.Split(" ", "%", "!", "-");
            // check for simple commands with switch statement
            switch (contexts[0].GetValue())
            {
                case CLEAR_COMMAND:
                    ChatMessages.Clear();
                    return;
                case CHANGE_AVATAR_COMMAND:
                    Change_Avatar_Command(message);
                    ChatMessages.Add(message);
                    return;
                case ADD_AVATAR_COMMAND:
                    Add_Avatar_Command(message);
                    ChatMessages.Add(message);
                    return;
                case CHANGE_FRAME_COMMAND:
                    Change_Frame_Command(message);
                    ChatMessages.Add(message);
                    return;
                case ADD_FRAME_COMMAND:
                    Add_Frame_Command(message);
                    ChatMessages.Add(message);
                    return;
                case CHANGE_POS_COMMAND1:
                case CHANGE_POS_COMMAND2:
                    Change_Pos_Command(message);
                    ChatMessages.Add(message);
                    return;
                default:
                    // after this, we should check for non-simple commands
                    break;
            }
        }
        private async void Change_Avatar_Command(ChatMessage message)
        {
            StrongString myString = message.MessageContext.Split(" ", ";")[1];
            if (ThereIsServer.GameObjects.MyProfile.SetPlayerAvatar(myString))
            {
                ChatMessages.ReviewMessagesAvatar();
                message.ReloadPlayerAvatar();
                await ThereIsServer.GameObjects.MyProfile.UpdatePlayerInfo();
            }
        }
        private async void Add_Avatar_Command(ChatMessage message)
        {
            StrongString myString = message.MessageContext.Split(" ", ";")[1];
            if (ThereIsServer.GameObjects.MyProfile.AddPlayerAvatar(myString))
            {
                await ThereIsServer.GameObjects.MyProfile.UpdateMe();
            }
        }
        private async void Change_Frame_Command(ChatMessage message)
        {
            StrongString myString = message.MessageContext.Split(" ", ";")[1];
            if (ThereIsServer.GameObjects.MyProfile.SetPlayerAvatarFrame(myString))
            {
                ChatMessages.ReviewMessagesAvatarFrame();
                message.ReloadPlayerAvatarFrame();
                await ThereIsServer.GameObjects.MyProfile.UpdatePlayerInfo();
            }
        }
        private async void Add_Frame_Command(ChatMessage message)
        {
            StrongString myString = message.MessageContext.Split(" ", ";")[1];
            if (ThereIsServer.GameObjects.MyProfile.AddAvatarFrame(myString))
            {
                await ThereIsServer.GameObjects.MyProfile.UpdateMe();
            }
        }
        private async void Change_Pos_Command(ChatMessage message)
        {
            StrongString myString = message.MessageContext.Split(" ", ";")[1];
            if (ThereIsServer.GameObjects.MyProfile.SetSocialPosition(myString))
            {
                ChatMessages.ReviewMessagesPos();
                message.ReloadPlayerPos();
                await ThereIsServer.GameObjects.MyProfile.UpdatePlayerInfo();
            }
            
        }
        #endregion
        //-------------------------------------------------
        #region static Methods Region
        public static async Task<ChatManager> GetChatManager(ChatChannels channel, GameControls.ChatBackgroundLabel father)
        {
            ChatManager manager = new ChatManager(channel, father)
            {
                Configuration = await ChatConfiguration.GetChatConfiguration(channel),
            };
            await manager.GetMessages();
            return manager;
        }
        /// <summary>
        /// Generate a new database for ChatManager in the Server.
        /// It will also create a new chat configuration.
        /// </summary>
        public static async Task<DataBaseDataChangedInfo> GenerateChatManager(ChatChannels channel)
        {
            ChatManager manager = new ChatManager(channel)
            {
                ChatMessages = MessageList.GetEmptyList(),
            };
            await ChatConfiguration.CreateNewConfiguration(channel);
            return await ThereIsServer.Actions.
                CreateFile(ThereIsServer.ServersInfo.MyServers[ChatConfiguration.BasicDataBaseNum + (int)channel],
                ChatDataBaseLocation, new DataBaseCreation("Created By SAO_Game",
                QString.Parse(manager.GetForServer(), false)));
        }
        #endregion
        //-------------------------------------------------
    }
}
