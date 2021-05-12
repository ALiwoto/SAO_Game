// Copyright (C) ALiwoto 2019 - 2020
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of the source code.

using System.Drawing;
using SAO.SandBox;
using SAO.GameObjects.Kingdoms;
using SAO.GameObjects.Players;

namespace SAO.Controls
{
    partial class GameControls
    {
        public sealed partial class ThroneLabel : LabelControl
        {
            #region Constants Region
            //---------------------------------------------
            /// <summary>
            /// USe it like this: ThronePosition.ToString() + 
            /// GuiltyCrownPicsEndNameInRe.
            /// </summary>
            public const string GuiltyCrownPicsEndNameInRes = "Pic";
            #endregion
            //---------------------------------------------
            #region Properties
            public ThroneNameLabel ThroneNameLabel { get; private set; }
            public ThronePositionLabel ThronePositionLabel { get; private set; }
            /// <summary>
            /// Using for setting the Guilty Crown for King
            /// or Queen or ... (Other Throne...)
            /// </summary>
            public PictureBoxControl GuiltyCrown { get; private set; }
            //---------------------------------------------
            public PlayerInfo PlayerInfo { get; private set; }
            public Image PlayerAvatarImage { get; private set; }
            public Size PlayerAvatarSize { get; private set; }
            public Rectangle PlayerAvatarRectangle { get; private set; }
            public Rectangle SrcPlayerAvatarRectangle { get; private set; }
            //---------------------------------------------
            /// <summary>
            /// The Throne Position of this Throne Label.
            /// </summary>
            public ThronePositions ThronePosition { get; }
            #endregion
            //---------------------------------------------
            #region Boolean Region
            /// <summary>
            /// When this is a Preview version of 
            /// Throne label, user can't click on the
            /// players in the throne of the kingdom
            /// and can't see their profile.
            /// Why?! 'cuz he is in the
            /// <see cref="KingdomInfoSandBox"/> and wants to
            /// select kingdom, so he SHOULD NOT see the
            /// players' profile in the throne.
            /// </summary>
            public bool IsPreview { get; }
            #endregion
            //---------------------------------------------
            #region Constructors Region
            /// <summary>
            /// Throne Label.
            /// </summary>
            public ThroneLabel(IRes myRes, SandBoxBase myFather,
                ThronePositions thronePosition,
                bool isPreview = true) : 
                base(myRes, LabelControlSpecies.ThroneLabel, 
                    myFather, false)
            {
                IsPreview = isPreview;
                ThronePosition = thronePosition;
                InitializeComponent();
            }
            #endregion
        }
    }
    
}
