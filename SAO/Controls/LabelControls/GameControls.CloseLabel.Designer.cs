// Copyright (C) ALiwoto 2019 - 2020
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of the source code.

using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace SAO.Controls
{
    partial class GameControls
    {
        partial class CloseLabel
        {
            //---------------------------------------------
            #region Closing Label region
            private void DesigningForClosingLabel()
            {
                this.Size = new Size(8 * (Father.Height / 80),
                    8 * (Father.Height / 80));
                //------------------------------------------
                //News:
                //Names:
                //TabIndexes:
                //FontsAndTextAligns:
                //Sizes:

                //Locations:
                if (UnlimitedPointWorks == null)
                {
                    UnlimitedPointWorks = new Point[]
                    {
                        new Point(1 * (Width / 8), 1 * (Height / 8)), // 1
                        new Point(7 * (Width / 8), 1 * (Height / 8)), // 2
                        new Point(1 * (Width / 8), 7 * (Height / 8)), // 3
                        new Point(7 * (Width / 8), 7 * (Height / 8)), // 4
                        new Point(0, 0 ), // 5
                        new Point(Width - 1, 0), // 6
                        new Point(Width - 1, Height - 1), // 7
                        new Point(0, Height - 1), // 8
                    };
                }
                //Colors:
                this.SetColorTransparent();
                //ComboBoxes:
                //Enableds:
                //Texts:
                //AddRanges:
                //ToolTipSettings:
                //Events:
                this.Paint += ClosingLabelControl_Paint;
                this.MouseEnter += ClosingLabelControl_MouseEnter;
                this.MouseLeave += ClosingLabelControl_MouseLeave;
                this.MouseDown += ClosingLabelControl_MouseDown;
                this.MouseUp += CLosingLabelControl_MouseUp;
                this.Click += ClosingLabelControl_Click;
                //------------------------------------------

                //-----------------------------------------
            }

            private void CLosingLabelControl_MouseUp(object sender, MouseEventArgs e)
            {
                HasMouseDowned = false;
            }

            private void ClosingLabelControl_MouseDown(object sender, MouseEventArgs e)
            {
                HasMouseDowned = true;
            }

            private async void ClosingLabelControl_Click(object sender, EventArgs e)
            {
                this.Enabled = false;
                await Task.Delay(100);
                this.Father.ClosedByMe = true;
                this.Father.Close();
            }

            private void ClosingLabelControl_MouseLeave(object sender, EventArgs e)
            {
                this.Cursor = Cursors.Default;
            }

            private void ClosingLabelControl_MouseEnter(object sender, EventArgs e)
            {
                this.Cursor = Cursors.Hand;
            }

            private void ClosingLabelControl_Paint(object sender, PaintEventArgs e)
            {
                if (!HasMouseDowned)
                {
                    e.Graphics.FillPolygon(new SolidBrush(Color.FromArgb(200, Color.Black)),
                    new Point[]
                    {
                        UnlimitedPointWorks[4], // 5
                        UnlimitedPointWorks[5], // 6
                        UnlimitedPointWorks[6], // 7
                        UnlimitedPointWorks[7], // 8
                    });
                    e.Graphics.DrawPolygon(new Pen(Color.FromArgb(200, Color.FloralWhite), 1.8f),
                        new Point[]
                        {
                        UnlimitedPointWorks[4], // 5
                        UnlimitedPointWorks[5], // 6
                        UnlimitedPointWorks[6], // 7
                        UnlimitedPointWorks[7], // 8
                        });
                    e.Graphics.DrawLine(new Pen(Color.GhostWhite, 1.8f),
                        UnlimitedPointWorks[0], // 1
                        UnlimitedPointWorks[3] // 4
                        );
                    e.Graphics.DrawLine(new Pen(Color.GhostWhite, 1.8f),
                        UnlimitedPointWorks[1], // 2
                        UnlimitedPointWorks[2] // 3
                        );
                }
                else
                {
                    e.Graphics.FillPolygon(new SolidBrush(Color.FromArgb(110, Color.Gold)),
                    new Point[]
                    {
                        UnlimitedPointWorks[4], // 5
                        UnlimitedPointWorks[5], // 6
                        UnlimitedPointWorks[6], // 7
                        UnlimitedPointWorks[7], // 8
                    });
                    e.Graphics.DrawPolygon(new Pen(Color.FromArgb(200, Color.FloralWhite), 1.4f),
                        new Point[]
                        {
                        UnlimitedPointWorks[4], // 5
                        UnlimitedPointWorks[5], // 6
                        UnlimitedPointWorks[6], // 7
                        UnlimitedPointWorks[7], // 8
                        });
                    e.Graphics.DrawLine(new Pen(Color.Black, 1.8f),
                        UnlimitedPointWorks[0], // 1
                        UnlimitedPointWorks[3] // 4
                        );
                    e.Graphics.DrawLine(new Pen(Color.Black, 1.8f),
                        UnlimitedPointWorks[1], // 2
                        UnlimitedPointWorks[2] // 3
                        );
                }
            }
            #endregion
            //---------------------------------------------
            //---------------------------------------------
            //---------------------------------------------
            public void NotifyDefault(bool myDefault)
            {

            }
            public void PerformClick()
            {
                this.OnClick(new EventArgs()
                {

                });
            }
            //---------------------------------------------
        }
    }
}
