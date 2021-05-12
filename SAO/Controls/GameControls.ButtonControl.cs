// Copyright (C) ALiwoto 2019 - 2020
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of the source code.

using System.Drawing;
using System.Windows.Forms;
using SAO.GameObjects.Resources;
namespace SAO.Controls
{
    partial class GameControls
    {
        public partial class ButtonControl : Button, IParamControls, IRes
        {
            public uint CurrentStatus { get; set; }
            private Size OriginaleSize { get; set; }
            private Point OriginalLocation { get; set; }
            public WotoRes MyRes { get; set; }
            public bool Dont_Paint { get; set; }
            public ButtonControl(IRes myRes, bool dontPaint = false)
            {
                MyRes = myRes.MyRes;
                CurrentStatus = 1;
                Dont_Paint = dontPaint;
                InitializeComponent();
            }
        }

    }

}
