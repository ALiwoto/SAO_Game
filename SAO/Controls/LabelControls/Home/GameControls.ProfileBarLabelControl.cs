// Copyright (C) ALiwoto 2019 - 2020
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of the source code.

using SAO.Constants;
using SAO.Client;
using SAO.Controls.Assets.Icons;

namespace SAO.Controls
{
    partial class GameControls
    {
        /// <summary>
        /// use it only in the <see cref="HomeBarLabelControl"/>.
        /// </summary>
        private sealed partial class ProfileBarLabelControl : LabelControl
        {
            //---------------------------------------------
            #region Constants Region
            public const string GameTimeTriggerName  = "GameTimeTrigger";
            public const string GameTimerBGNameInRes = "GameStaticTimerBackGround";
            public const float ResBackWidthRate      = 1.5f;
            public const float ResBackHeightRate     = 1.2f;
            #endregion
            //---------------------------------------------
            public new GameClient Father { get; }
            public GameIcon Profile_NavIcon { get; private set; }
            public Trigger GameTimeTrigger { get; private set; }
            public LabelControl PlayerNameLabelControl { get; private set; }
            public LabelControl PlayerLvlLabelControl { get; private set; }
            public IconLabelControl Profile_NavIconLabel { get; private set; }
            public IconLabelControl AvatarIconLabel { get; private set; }
            public IconLabelControl ExpTrackIconLabel { get; private set; }
            public IconLabelControl ExpThumbIconLabel { get; private set; }
            public IconLabelControl TimeIconLabel { get; private set; }
            public PlayerResourcesLabelControl DiamondResIconLabel { get; private set; }
            public PlayerResourcesLabelControl CouponResIconLabel { get; private set; }
            public PlayerResourcesLabelControl CoinResIconLabel { get; private set; }
            public PlayerResourcesLabelControl ManaResIconLabel { get; private set; }
            //---------------------------------------------

            #region Constructors Region
            internal ProfileBarLabelControl(IRes myRes, 
                GameClient theClient = null) : base(myRes)
            {
                if (theClient == null)
                {
                    Father = ThereIsConstants.Forming.GameClient;
                }
                else
                {
                    Father = theClient;
                }
                InitializeComponent();
            }
            #endregion



        }
    }
}
