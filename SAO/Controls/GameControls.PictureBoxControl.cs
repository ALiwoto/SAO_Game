// Copyright (C) ALiwoto 2019 - 2020
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of the source code.

using System.Drawing;
using System.Windows.Forms;
using SAO.SandBox;
using SAO.GameObjects.Resources;

namespace SAO.Controls
{
    partial class GameControls
    {
        public partial class PictureBoxControl : PictureBox, IRes
        {
            //-------------------------------------------------
            public uint CurrentStatus { get; set; }
            //-------------------------------------------------
            public WotoRes MyRes { get; set; }
            public Image OriginalImage { get; set; }
            public Image ClickedImage { get; set; }
            public LabelControl BackGroundLabelControl { get; }
            public SandBoxBase Father { get; set; }
            //-------------------------------------------------
            public bool DontUseClickedImage { get; set; }
            //-------------------------------------------------
            public PictureBoxControl(IRes myRes, bool dontUseClickedImage = true,
                LabelControl myBackgroundControl = null)
            {
                MyRes = myRes.MyRes;
                CurrentStatus = 1;
                DontUseClickedImage = dontUseClickedImage;
                BackGroundLabelControl = myBackgroundControl;
                InitializeComponent();
            }
        }
    }
}
