using System.Drawing;
using SAO.Client;
using SAO.GameObjects.Chatting;
using SAO.Controls.Elements.ChatElements;

namespace SAO.Controls
{
    partial class GameControls
    {
        public sealed partial class ChatBackgroundLabel : LabelControl
        {
            //---------------------------------------------
            #region Constants Region
            public const int MoveLimitationRate = 5; // px
            public const float BetweenElements = 30;
            public const float From_the_edge = 6;
            #endregion
            //---------------------------------------------
            #region Properties Region
            /// <summary>
            /// The Game Client.
            /// </summary>
            public GameClient GameClient { get; private set; }
            public ChatLabelControl BackLabel { get; }
            /// <summary>
            /// for now, just load the zero index of this array, and 
            /// it should be the cross chat, load it in the
            /// <see cref="GameClient.DesignForHome(bool)"/>,
            /// in the <see cref="ChatLabelControl.LoadAllChannels()"/>.
            /// </summary>
            public ChatManager CrossChatManager { get; private set; }
            public ChatManager KingdomChatManager { get; private set; }
            public ChatManager GuildChatManager { get; private set; }
            public ChatManager CurrentChatManager { get; private set; }
            public ChatElement[] ChatElements { get; private set; }
            public ChatElement[] AppliedChatElements { get; private set; }
            public ChatBarLabel ActiveChatBar { get; private set; }
            public bool IsLoadingChannels { get; private set; }
            public bool IsKingdomChannelLoaded { get; private set; }
            public bool IsCrossChannelLoaded { get; private set; }
            public bool IsChannelsLoaded
            {
                get
                {
                    return IsKingdomChannelLoaded && IsCrossChannelLoaded;
                }
                private set
                {
                    IsKingdomChannelLoaded = IsCrossChannelLoaded = value;
                }
            }
            public bool IsShowingGeneral { get; private set; }
            public PointF LastPoint { get; private set; }
            public ChatChannels CurrentShowingChannel { get; private set; }
            public ElementMovements Movements { get; }
            #endregion
            //---------------------------------------------
            #region Constructors Region
            /// <summary>
            /// create a new instance of the <see cref="ChatBackgroundLabel"/>,
            /// which will provide you the chat frame, chat icon
            /// and chat flash.
            /// </summary>
            /// <param name="myRes"></param>
            /// <param name="client"></param>
            public ChatBackgroundLabel(IRes myRes, GameClient client, ChatLabelControl backLabel) :
                base(myRes, LabelControlSpecies.ChatBackGroundLabel)
            {
                GameClient = client;
                BackLabel  = backLabel;
                // set the default showing channel to the cross,
                // so when the user opens his chat channel, he should see the
                // cross channel's chats.
                CurrentShowingChannel   = ChatChannels.Cross_Chat;
                Movements               = ElementMovements.VerticalMovements;
                InitializeComponent();
            }
            #endregion
            //---------------------------------------------
        }
    }
}
