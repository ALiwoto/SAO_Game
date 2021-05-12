// Copyright (C) ALiwoto 2019 - 2020
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of the source code.

namespace SAO.Controls
{
    partial class GameControls
    {
        public partial class ThroneNameLabel : LabelControl
        {
            //---------------------------------------------
            /// <summary>
            /// This is my Throne Label which is background of me.
            /// I really wantes to name this ThroneBackgroundLabel,
            /// but mrwoto didn't accept.
            /// </summary>
            public ThroneLabel ThroneLabel { get; }
            //---------------------------------------------
            //---------------------------------------------
            //---------------------------------------------
            //---------------------------------------------
            /// <summary>
            /// Throne Name Label.
            /// </summary>
            public ThroneNameLabel(IRes myRes, ThroneLabel myThroneLabel) : 
                base(myRes, LabelControlSpecies.ThroneNameLabel)
            {
                ThroneLabel = myThroneLabel;
                InitializeComponent();
            }
        }
    }
}
