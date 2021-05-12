// Copyright (C) ALiwoto 2019 - 2020
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of the source code.

using System.Drawing;
using System.Windows.Forms;
using SAO.Constants;

namespace SAO.Controls
{
    partial class GameControls
    {
        partial class ThronePositionLabel
        {
            private void InitializeComponent()
            {
                this.Size = new Size(24 * (this.ThroneLabel.Width / 48),
                    (int)(24 * ((double)this.ThroneLabel.Height / 86.96)));

                //----------------------------------
                //News:
                this.MessageLabel1 = new LabelControl(this);
                this.UnlimitedPointWorks = new Point[]
                {
                    new Point(0, 0), // 1
                    new Point(Width - (1 * (Width / 6)), 0), // 2
                    new Point(Width, Height), // 3
                    new Point(0, Height), // 4
                };
                this.PaintColors = new Color[]
                {
                    Color.FromArgb(210, Color.Black),
                    Color.GhostWhite,
                };
                this.PaintBrushes = new Brush[]
                {
                    new SolidBrush(this.PaintColors[0]),
                };
                this.PaintPens = new Pen[]
                {
                    new Pen(PaintColors[1], 1.5f),
                };
                //----------------------------------
                //Names:
                this.MessageLabel1.SetLabelName(this.Position.ToString());
                //TabIndexes
                //FontAndTextAligns:
                this.Font = this.MessageLabel1.Font =
                    new Font(ThereIsConstants.Forming.TheMainForm.PrivateFonts.Families[1],
                    12, FontStyle.Bold);
                this.MessageLabel1.TextAlign = ContentAlignment.MiddleCenter;
                //Sizes:
                this.MessageLabel1.Size = this.Size;
                //Locations:
                //Colors:
                this.SetColorTransparent();
                this.MessageLabel1.SetColorTransparent();
                this.MessageLabel1.SetTextColor(Color.LightGoldenrodYellow);
                //ComboBoxes:
                //Enableds:
                //Texts:
                this.MessageLabel1.SetLabelText();
                //AddRanges:
                //ToolTipSettings:
                //----------------------------------
                //Events:
                this.Paint += ThronePositionLabel_Paint;
                //----------------------------------
                this.Controls.Add(this.MessageLabel1);
            }

            private void ThronePositionLabel_Paint(object sender, PaintEventArgs e)
            {
                e.Graphics.FillPolygon(this.PaintBrushes[0], this.UnlimitedPointWorks);
                e.Graphics.DrawLines(this.PaintPens[0], this.UnlimitedPointWorks);
            }
        }
    }

}
