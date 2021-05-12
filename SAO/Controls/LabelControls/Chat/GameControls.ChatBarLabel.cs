// Copyright (C) ALiwoto 2019 - 2020
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of the source code.

using SAO.GameObjects.Chatting;
using SAO.Controls.Assets.Icons;

namespace SAO.Controls
{
    partial class GameControls
    {
        public sealed partial class ChatBarLabel : LabelControl
        {
            //---------------------------------------------
            #region Constant's Region
            public const string GeneralLabelNameInRes = "General_Chat";
            #endregion
            //---------------------------------------------
            #region Properties Region
            public ChatLabelControl ChatLabel { get; }
            public ChatBackgroundLabel ChatBackground { get; }
            public ChatBarLabel KingdomChatBar { get; private set; }
            public ChatBarLabel GuildChatBar { get; private set; }
            public ChatManager MyChatManager { get; private set; }
            private GameIcon GoldenIcon { get; set; }
            public bool IsSelected { get; private set; }
            public bool IsGeneral { get; }
            public ChatChannels Channel { get; }
            #endregion
            //---------------------------------------------
            #region Constructors' Region
            /// <summary>
            /// use this constructor when you want to create a 
            /// chat bar in the chat label. (General, Cross, System)
            /// </summary>
            /// <param name="myRes"></param>
            /// <param name="chatLabel"></param>
            public ChatBarLabel(IRes myRes, ChatLabelControl chatLabel,
                ChatChannels channel, bool isSelected = false) :
                base(myRes, LabelControlSpecies.ChatBarLabelControl)
            {
                Channel = channel;
                ChatLabel = chatLabel;
                IsSelected = isSelected;
                InitializeBarComponent();
            }
            public ChatBarLabel(IRes myRes, ChatLabelControl chatLabel,
                bool isSelected = false) :
                base(myRes, LabelControlSpecies.ChatBarLabelControl)
            {
                ChatLabel = chatLabel;
                IsSelected = isSelected;
                IsGeneral = true;
                InitializeBarComponent();
            }
            /// <summary>
            /// use this constructor when you want to create a 
            /// chat bar in the chat background label. 
            /// (Kingdom, Guild)
            /// </summary>
            /// <param name="myRes"></param>
            /// <param name="chatLabel"></param>
            public ChatBarLabel(IRes myRes, ChatBackgroundLabel chatLabel,
                ChatChannels channel, bool isSelected = false) :
                base(myRes, LabelControlSpecies.ChatBarLabelControl)
            {
                Channel = channel;
                ChatBackground = chatLabel;
                IsSelected = isSelected;
                InitializeGeneralComponent();
            }
            #endregion
            //---------------------------------------------
        }
    }
}
