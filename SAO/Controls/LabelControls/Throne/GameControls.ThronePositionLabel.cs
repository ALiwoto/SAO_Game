// Copyright (C) ALiwoto 2019 - 2020
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of the source code.

using SAO.GameObjects.Kingdoms;

namespace SAO.Controls
{
    partial class GameControls
    {
        public partial class ThronePositionLabel : LabelControl
        {
            //---------------------------------------------
            /// <summary>
            /// This is my Throne Label which is background of me.
            /// I really wantes to name this ThroneBackgroundLabel,
            /// but mrwoto didn't accept.
            /// </summary>
            public ThroneLabel ThroneLabel { get; }
            //---------------------------------------------
            public ThronePositions Position { get; }
            //---------------------------------------------
            //---------------------------------------------
            //---------------------------------------------
            /// <summary>
            /// Throne Position Label Constructor.
            /// </summary>
            public ThronePositionLabel(IRes myRes, ThroneLabel myThroneLabel, 
                ThronePositions myPosition) :
                base(myRes, LabelControlSpecies.ThronePositionLabel)
            {
                ThroneLabel = myThroneLabel;
                Position = myPosition;
                InitializeComponent();
            }
        }
    }
    
}
