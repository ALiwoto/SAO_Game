// Copyright (C) ALiwoto 2019 - 2020
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of the source code.

namespace SAO.Controls
{
    partial class GameControls
    {
        public sealed partial class ChatInputControl : LabelControl
        {
            //---------------------------------------------
            #region Constants Region

            #endregion
            //---------------------------------------------
            #region Properties Region
            public LabelControl BackLabel { get; }
            public IconLabelControl EmojiIconLabel { get; private set; }
            public IconLabelControl SendLabelControl { get; private set; }
            public TextBoxControl ChatBoxControl { get; private set; }
            #endregion
            //---------------------------------------------
            #region Constructors Region
            public ChatInputControl(IRes myRes, LabelControl backLabel) :
                base(myRes, LabelControlSpecies.ChatInputLabel)
            {
                BackLabel = backLabel;
                InitializeComponent();
            }
            #endregion
            //---------------------------------------------
        }
    }
}
