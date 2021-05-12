// Copyright (C) ALiwoto 2019 - 2020
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of the source code.

using System.Drawing;
using SAO.Controls;
using SAO.GameObjects.ServerObjects;

namespace SAO.SandBox
{
    public sealed partial class YuiLoadingSandbox : SandBoxBase, IAnimationFactory
    {
        //----------------------------------------------
        public GameControls.PictureBoxControl YuiWaitingPictureBox { get; set; }
        public RectangleF[] UnlimitedRectangleFWorks { get; private set; }
        public Trigger AnimationFactory { get; set; }
        public Bitmap YuiImage { get; private set; }
        //----------------------------------------------
        public int TheW { get; set; }
        //----------------------------------------------
        public bool UseAnimation { get; set; }
        //----------------------------------------------
        public const string YuiPicNameInRes = "YuiPicName";
        //----------------------------------------------
        public YuiLoadingSandbox(GameControls.PageControl theUnderForm) : base(theUnderForm)
        {
            ClosedByMe      = false;
            UseAnimation    = true; // Yui SHOULD be Animated.
            if (!ThereIsServer.ServerSettings.HasConnectionClosed)
            {
                TopMost = true;
            }
            InitializeComponent();
        }
    }
}
