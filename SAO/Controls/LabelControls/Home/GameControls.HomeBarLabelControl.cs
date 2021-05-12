// Copyright (C) ALiwoto 2019 - 2020
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of the source code.

using System;
using SAO.Controls.Assets.Icons;

namespace SAO.Controls
{
    partial class GameControls
    {
        public partial class HomeBarLabelControl : LabelControl
        {
            //---------------------------------------------
            #region Constants Region
            public const string Map_Go_IconNameInRes    = "MapGoIcon";
            public const string Heroes_IconNameInRes    = "HeroesIcon";
            public const string Recruit_IconNameInRes   = "RecruitIcon";
            public const string Arena_IconNameInRes     = "ArenaIcon";
            public const string Dungeons_IconNameInRes  = "DungeonsIcon";
            public const string Bag_IconNameInRes       = "BagIcon";
            public const string Guild_IconNameInRes     = "GuildIcon";
            #endregion
            //---------------------------------------------
            #region Properties Region
            public new PageControl Father { get; set; }
            public GameIcon[] Icons { get; set; }
            public new IconLabelControl[] SurfaceLabels { get; set; }
            private ProfileBarLabelControl ProfileBarLabelControl { get; set; }
            #endregion
            //---------------------------------------------
            #region Constructors Region
            public HomeBarLabelControl(IRes myRes, PageControl father, 
                EventHandler profileClickEventHandler) : 
                base(myRes, LabelControlSpecies.HomeBarLabel, null, false)
            {
                Father = father;
                InitializeComponent(profileClickEventHandler);
            }
            #endregion
            //---------------------------------------------
            #region Get Methods Region
            public LabelControl GetProfileBar()
            {
                return ProfileBarLabelControl;
            }
            public LabelControl GetDiamondResLabel()
            {
                return ProfileBarLabelControl.DiamondResIconLabel;
            }
            #endregion
            //---------------------------------------------
        }
    }
}
