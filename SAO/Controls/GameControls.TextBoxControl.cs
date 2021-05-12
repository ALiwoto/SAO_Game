// Copyright (C) ALiwoto 2019 - 2020
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of the source code.

using System.Windows.Forms;
using SAO.GameObjects.Resources;

namespace SAO.Controls
{
    partial class GameControls
    {
        public partial class TextBoxControl : TextBox, IParamControls, IRes
        {
            //------------------------------------------------
            public WotoRes MyRes { get; set; }
            //------------------------------------------------
            public ToolTip CustomToolTip { get; set; }
            //------------------------------------------------
            public bool DisableSelection { get; set; }
            public bool UseCustomToolTip { get; set; }
            //------------------------------------------------
            public uint CurrentStatus { get; set; }
            //------------------------------------------------
            private const int WM_SETFOCUS = 0x0007;
            private const int WM_KILLFOCUS = 0x0008;
            private const int EM_SHOWBALLOONTIP = 0x1503;
            //------------------------------------------------
            public TextBoxControl()
            {
                CurrentStatus = 1;
                DisableSelection = false;
                InitializeComponent();
            }
        }

    }
}
