using System;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using WotoProvider.Interfaces;
using SAO.SandBox;
using SAO.Security;
using SAO.Controls;
using SAO.GameObjects.ServerObjects;

namespace SAO.GameObjects.Chatting
{
    public class ChatConfiguration
    {
        //-------------------------------------------------
        #region Constants Region
        public const string InCharSeparator = "＾";
        public const string OutCharSeparator = "＠｜";
        public const string DataBaseLocation = "チャット工のフィ五里シェノ";
        public const int BasicDataBaseNum = 5;
        public const int ConfigurationPosition = 0;
        public const int BanListPosition = 1;
        public const int BanTimePosition = 2;
        public const int MINIMUM_LENGTH = 3;
        #endregion
        //-------------------------------------------------
        #region local Properties Region
        public ChatChannels TheChannel { get; }
        #endregion
        //-------------------------------------------------
        #region Server Properties Region
        /// <summary>
        /// The status of this channel.
        /// The Code is: 1.
        /// </summary>
        public ChatChannelStatus Status { get; private set; }
        /// <summary>
        /// this property should not remain string.
        /// it should be Item, but the Item is not
        /// completed in the game, so you should use an empty string for that
        /// untill I complete it.
        /// The Code is: 2.
        /// </summary>
        public string ItemPrice { get; private set; }
        /// <summary>
        /// the minimum level which players should have to be able to chat.
        /// The Code is: 3.
        /// </summary>
        public ushort MinimumLvl { get; private set; }
        /// <summary>
        /// The Banned list.
        /// list of the users who are banned from chatting.
        /// The Code is: 4.
        /// </summary>
        public ChatBlockList BanList { get; private set; }
        /// <summary>
        /// Ban Limitation times.
        /// The Code is: 2.
        /// </summary>
        public List<IDateProvider<DateTime, Trigger, StrongString>> BanLimitationTime { get; private set; }
        #endregion
        //-------------------------------------------------
        #region Constructors Region
        private ChatConfiguration(ChatChannels channel)
        {
            TheChannel = channel;
        }
        #endregion
        //-------------------------------------------------
        #region Ordinary Methods Region
        public StrongString GetForServer()
        {
            StrongString myString = OutCharSeparator;
            myString += 
                ((int)Status).ToString() + InCharSeparator +    // 1
                ((ItemPrice == "") ? "notSet" : "notSet")
                + InCharSeparator +                           // 2
                MinimumLvl + InCharSeparator +                          // 3
                OutCharSeparator;
            myString += BanList.GetForServer() + OutCharSeparator;      // 4
            // for Banlimitaion time.
            myString += InCharSeparator;
            for (int i = 0; i < BanList.Length; i++)
            {
                myString += BanLimitationTime[i].GetForServer().GetValue() + InCharSeparator; // 5                           // 5
            }
            return myString;
        }
        public void SetLimitationTime(QString[] timeValues)
        {
            BanLimitationTime = new List<IDateProvider<DateTime, Trigger, StrongString>>(BanList.Length);
            for (int i = 0; i < BanLimitationTime.Count; i++)
            {
                BanLimitationTime[i] = DateProvider.Parse(timeValues[i].GetStrong());
            }
        }
        public void SetLimitationTime(StrongString[] timeValues)
        {
            BanLimitationTime = new List<IDateProvider<DateTime, Trigger, StrongString>>(BanList.Length);
            for (int i = 0; i < BanLimitationTime.Count; i++)
            {
                BanLimitationTime[i] = DateProvider.Parse(timeValues[i]);
            }
        }
        public void SetLimitationTime()
        {
            BanLimitationTime = new List<IDateProvider<DateTime, Trigger, StrongString>>(BanList.Length);
            for (int i = 0; i < BanLimitationTime.Count; i++)
            {
                BanLimitationTime[i] = DateProvider.GetUnlimited();
            }
        }
        #endregion
        //-------------------------------------------------
        #region static Methods Region
        private static ChatConfiguration Parse(StrongString serverValue, ChatChannels channels)
        {
            ChatConfiguration configuration;
            StrongString[] myTStrings =
                serverValue.Split(OutCharSeparator);
            StrongString[] myStrings =
                myTStrings[ConfigurationPosition].Split(InCharSeparator);
            configuration = new ChatConfiguration(channels)
            {
                Status = (ChatChannelStatus)myStrings[0].ToUInt16(),
                ItemPrice = myStrings[1].GetValue(),
                MinimumLvl = myStrings[2].ToUInt16(),
                BanList = ChatBlockList.Parse(myTStrings[BanListPosition]),
            };
            StrongString[] banTime = myTStrings[BanTimePosition].Split(InCharSeparator);
            configuration.SetLimitationTime(banTime);
            return configuration;
        }
        public static async Task<DataBaseDataChangedInfo> CreateNewConfiguration(ChatChannels channel)
        {
            ChatConfiguration configuration = new ChatConfiguration(channel)
            {
                Status = ChatChannelStatus.FreeForAll,
                ItemPrice = "notSet",
                MinimumLvl = 0,
                BanList = ChatBlockList.GenerateBlankChatBlockList(),
            };
            configuration.SetLimitationTime();
            return await ThereIsServer.Actions.CreateFile(ThereIsServer.ServersInfo.MyServers[BasicDataBaseNum + (int)channel],
                DataBaseLocation, new DataBaseCreation("Created By SAO_Game",
                QString.Parse(configuration.GetForServer(), false)));
        }
        public static async Task<ChatConfiguration> GetChatConfiguration(ChatChannels channel)
        {
            var existingFile =
                    await ThereIsServer.Actions.GetAllContentsByRef(
                        ThereIsServer.ServersInfo.MyServers[BasicDataBaseNum + (int)channel],
                DataBaseLocation);
            if (existingFile.IsDeadCallBack || ThereIsServer.ServerSettings.HasConnectionClosed)
            {
                NoInternetConnectionSandBox.PrepareConnectionClosedSandBox();
                return null; // don't set ServerSettings.IsWaitingForServerChecking = false;
            }
            return Parse(existingFile.Decode(), channel);
        }
        public async Task<bool> ReloadChatConfiguration()
        {
            var existingFile =
                    await ThereIsServer.Actions.GetAllContentsByRef(
                        ThereIsServer.ServersInfo.MyServers[BasicDataBaseNum + (int)TheChannel],
                DataBaseLocation);
            if (existingFile.IsDeadCallBack || ThereIsServer.ServerSettings.HasConnectionClosed)
            {
                NoInternetConnectionSandBox.PrepareConnectionClosedSandBox();
                return false; // don't set ServerSettings.IsWaitingForServerChecking = false;
            }
            StrongString[] myTStrings = existingFile.Decode().Split(OutCharSeparator);
            StrongString[] myStrings = myTStrings[ConfigurationPosition].Split(InCharSeparator);
            StrongString[] banTime = myTStrings[BanTimePosition].Split(InCharSeparator);
            Status = (ChatChannelStatus)myStrings[0].ToInt32();
            ItemPrice = myStrings[1].GetValue();
            MinimumLvl = myStrings[2].ToUInt16();
            BanList = ChatBlockList.Parse(myTStrings[BanListPosition]);
            SetLimitationTime(banTime);
            return true;
        }
        public async Task<DataBaseDataChangedInfo> UpdateChatConfiguration()
        {
            var Existing = await ThereIsServer.Actions.GetAllContentsByRef(
                ThereIsServer.ServersInfo.MyServers[BasicDataBaseNum + (int)TheChannel], 
                DataBaseLocation);
            if (Existing.IsDeadCallBack || ThereIsServer.ServerSettings.HasConnectionClosed)
            {
                NoInternetConnectionSandBox.PrepareConnectionClosedSandBox();
                return null; // don't set ServerSettings.IsWaitingForServerChecking = false;
            }
            return await ThereIsServer.Actions.UpdateFile(
                ThereIsServer.ServersInfo.MyServers[BasicDataBaseNum + (int)TheChannel], 
                DataBaseLocation,
                new DataBaseUpdateRequest("BY SAO_Game",
                QString.Parse(GetForServer(), false), Existing.Sha));
        }
        #endregion
        //-------------------------------------------------
    }
}
