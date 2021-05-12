using SAO.Client;
using SAO.GameObjects.Chatting;

namespace SAO.Controls
{
    partial class GameControls
    {
        public sealed partial class ChatLabelControl : LabelControl
        {
            //---------------------------------------------
            #region Constants Region
            public const int MINIMUM_LENGTH = 3;
            public const string INSIDER = " ";
            #endregion
            //---------------------------------------------
            #region Properties Region
            public new GameClient Father { get; private set; }
            public IconLabelControl FlashIconLabel { get; private set; }
            public IconLabelControl ChatIconLabel { get; private set; }
            public ChatBackgroundLabel ChatBackgroundLabel { get; private set; }
            public LabelControl BackLabel { get; private set; }
            public ChatInputControl InputControl { get; private set; }
            public ChatManager[] ChatManagers { get; private set; }
            public ChatBarLabel SystemChatBar { get; private set; }
            public ChatBarLabel CrossChatBar { get; private set; }
            public ChatBarLabel GeneralChatBar { get; private set; }
            public ChatBarLabel KingdomChatBar { get; private set; }
            public ChatBarLabel GuildChatBar { get; private set; }
            public ChatBarLabel CurrentChatBar { get; private set; }
            //---------------------------------------------
            public bool IsChatFrameApplied { get; private set; }
            #endregion
            //---------------------------------------------
            #region Constructors Region
            private ChatLabelControl(IRes myRes, GameClient father, LabelControl backLabel) :
                base(myRes, LabelControlSpecies.ChatLabel)
            {
                Father      = father;
                BackLabel   = backLabel;
                InitializeComponent();
            }


            #endregion
            //---------------------------------------------
            #region static Methods Region
            /// <summary>
            /// Generate a new instance of the chatLabel.
            /// </summary>
            /// <param name="myRes">
            /// the <see cref="LabelControl.MyRes"/>.
            /// </param>
            /// <param name="father">
            /// the <see cref="LabelControl.Father"/>,
            /// this object should be the GameClient.
            /// </param>
            /// <returns></returns>
            public static  ChatLabelControl GenerateChatLabel(IRes myRes, GameClient father, 
                LabelControl backLabel)
            {
                ChatLabelControl chatLabel =
                    new ChatLabelControl(myRes, father, backLabel);

                return chatLabel;
            }
            #endregion
            //---------------------------------------------





        }
    }
}
