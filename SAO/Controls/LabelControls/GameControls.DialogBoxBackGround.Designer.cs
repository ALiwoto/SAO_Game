// Copyright (C) ALiwoto 2019 - 2020
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of the source code.

using System;
using System.Windows.Forms;
using System.Drawing;
using SAO.Constants;
using SAO.GameObjects.Characters;
using SAO.SandBox;

namespace SAO.Controls
{
    partial class GameControls
    {
        partial class DialogBoxBackGround
        {
            //-------------------------------------------------------
            #region Dialog background
            private void DesigningForDialogBoxBackGround()
            {
                this.Size = new Size(ThereIsConstants.Forming.GameClient.Width,
                    ThereIsConstants.Forming.GameClient.Height / 4);
                this.SingleClick = true;
                this.HasMouseClickedOnce = true; // I don't wanna run the clicked event.
                //------------------------------------------
                //News:
                this.MessageLabel1 = new LabelControl(this);
                this.HexagonImage = Image.FromFile(ThereIsConstants.Path.Datas_Path +
                    ThereIsConstants.Path.DoubleSlash +
                    MyRes.GetString(DialogBoxProvider.HexagonImgNameInRes));
                UnlimitedPointWorks = new Point[]
                {
                    new Point(0, Height / 4), // 1
                    new Point(6 * (Width / 80), Height / 4), // 2
                    new Point((2 * (Width / 20)) - (3 * (Width / 160)), 1 * (Height / 16)), // 3
                    new Point((2 * (Width / 20)) - (3 * (Width / 160)) + (1 * (Height / 16)), 1 * (Height / 16)), // 4
                    new Point((2 * (Width / 20)) - (3 * (Width / 160)) + (1 * (Height / 16)), 0), // 5
                    new Point(Width - ((2 * (Width / 20)) - (3 * (Width / 160)) + (1 * (Height / 16))), 0), // 6
                    new Point(Width - ((2 * (Width / 20)) - (3 * (Width / 160)) + (1 * (Height / 16))), 1 * (Height / 16)),// 7
                    new Point(Width - ((2 * (Width / 20)) - (3 * (Width / 160))), 1 * (Height / 16)), // 8
                    new Point(Width - (6 * (Width / 80)) , Height / 4), // 9
                    new Point(Width - 0, Height / 4), // 10
                    new Point(Width, Height), // 11
                    new Point(0, Height), // 12
                    new Point((2 * (Width / 20)) - (3 * (Width / 160)), 0), // 13
                    new Point(Width - ((2 * (Width / 20)) - (3 * (Width / 160))), Height), // 14
                    new Point((2 * (Width / 20)) - (3 * (Width / 160)), Height), // 15
                };
                //Names:
                this.MessageLabel1.SetLabelName(labelForTextName);
                //TabIndexes:
                //FontsAndTextAligns:
                this.MessageLabel1.Font = this.Font;
                this.MessageLabel1.TextAlign = ContentAlignment.MiddleCenter;
                //Sizes:
                
                this.MessageLabel1.Size =
                    new Size(4 * (Width / 5),
                    3 * (Height / 4));
                this.HexagonSize = this.HexagonImage.Size;

                //Locations:
                this.MessageLabel1.Location = UnlimitedPointWorks[3]; // 4
                //Rectangles:
                this.HexagonRectangle =
                    new Rectangle(
                        UnlimitedPointWorks[1], 
                        new Size(
                            (int)(1.306451612903226 * 
                            (this.Height - UnlimitedPointWorks[1].Y +
                            (4 * NoInternetConnectionSandBox.from_the_edge))), 
                        this.Height - UnlimitedPointWorks[1].Y +
                        (4 * NoInternetConnectionSandBox.from_the_edge)));
                this.SrcHexagonRectangle = new Rectangle(0, 0, this.HexagonSize.Width,
                    this.HexagonSize.Height);
                //Colors:
                this.BackColor = Color.Transparent;
                this.ForeColor = this.BackColor;
                this.MessageLabel1.BackColor = Color.Transparent;
                this.MessageLabel1.ForeColor = Color.GhostWhite;
                //Images:
                //ComboBoxes:
                //Enableds:
                this.MessageLabel1.SingleClick = true;
                //Texts:
                this.MessageLabel1.SetLabelText(this.Text);
                //AddRanges:
                //ToolTipSettings:
                //Events:
                this.Paint += DialogBackGroundLabelControl_Painting;
                this.Paint += HexagonDrawing;
                this.TextChanged += DialogBackGroundLabelControl_TextChanged;
                this.FontChanged += DialogBackGroundLabelControl_FontChanged;
                //------------------------------------------
                this.Controls.Add(this.MessageLabel1);
                //------------------------------------------
            }

            private void DialogBackGroundLabelControl_TextChanged(object sender, EventArgs e)
            {
                if (this.Text.Length != 0)
                {
                    this.MessageLabel1.Text = this.Text;
                    this.Text = "";
                }
                else
                {
                    ;
                }
            }
            private void DialogBackGroundLabelControl_FontChanged(object sender, EventArgs e)
            {
                this.MessageLabel1.Font = this.Font;

            }
            private void DialogBackGroundLabelControl_Painting(object sender, PaintEventArgs e)
            {
                e.Graphics.FillPolygon(new SolidBrush(Color.FromArgb(170, Color.Black)),
                    new Point[] {
                        UnlimitedPointWorks[0],     // 1
                        UnlimitedPointWorks[1],     // 2
                        UnlimitedPointWorks[2],     // 3
                        UnlimitedPointWorks[3],     // 4
                        UnlimitedPointWorks[4],     // 5
                        UnlimitedPointWorks[5],     // 6
                        UnlimitedPointWorks[6],     // 7
                        UnlimitedPointWorks[7],     // 8
                        UnlimitedPointWorks[8],     // 9
                        UnlimitedPointWorks[9],     // 10
                        UnlimitedPointWorks[10],    // 11
                        UnlimitedPointWorks[11]     // 12
                    });

                e.Graphics.DrawLines(new Pen(Color.FromArgb(210, Color.GhostWhite), 2),
                    new Point[]
                    {
                        UnlimitedPointWorks[0], // 1
                        UnlimitedPointWorks[1], // 2
                        UnlimitedPointWorks[2], // 3
                    });
                e.Graphics.DrawLine(new Pen(Color.FromArgb(210, Color.GhostWhite), 2),
                    UnlimitedPointWorks[4],     // 5
                    UnlimitedPointWorks[5]);    // 6
                e.Graphics.DrawLines(new Pen(Color.FromArgb(210, Color.GhostWhite), 2),
                    new Point[]
                    {
                        UnlimitedPointWorks[7],     // 8
                        UnlimitedPointWorks[8],     // 9
                        UnlimitedPointWorks[9],     // 10
                        UnlimitedPointWorks[10],    // 11
                        UnlimitedPointWorks[11],    // 12
                    });
                e.Graphics.FillPie(new SolidBrush(Color.FromArgb(170, Color.Black)),
                    new Rectangle(UnlimitedPointWorks[12],
                    new Size(2 * (UnlimitedPointWorks[4].X - UnlimitedPointWorks[12].X),
                        2 * (UnlimitedPointWorks[2].Y - UnlimitedPointWorks[12].Y))),
                    180, 90);
                e.Graphics.FillPie(new SolidBrush(Color.FromArgb(170, Color.Black)),
                    new Rectangle(new Point(UnlimitedPointWorks[5].X -
                        (UnlimitedPointWorks[4].X - UnlimitedPointWorks[12].X),
                        UnlimitedPointWorks[5].Y),
                    new Size(2 * (UnlimitedPointWorks[4].X - UnlimitedPointWorks[12].X),
                        2 * (UnlimitedPointWorks[2].Y - UnlimitedPointWorks[12].Y))),
                    270, 90);
                e.Graphics.DrawArc(new Pen(Color.FromArgb(210, Color.GhostWhite), 2),
                    new Rectangle(UnlimitedPointWorks[12],
                    new Size(2 * (UnlimitedPointWorks[4].X - UnlimitedPointWorks[12].X),
                        2 * (UnlimitedPointWorks[2].Y - UnlimitedPointWorks[12].Y))),
                    180, 90);
                e.Graphics.DrawArc(new Pen(Color.FromArgb(210, Color.GhostWhite), 2),
                    new Rectangle(new Point(UnlimitedPointWorks[5].X -
                        (UnlimitedPointWorks[4].X - UnlimitedPointWorks[12].X),
                        UnlimitedPointWorks[5].Y),
                    new Size(2 * (UnlimitedPointWorks[4].X - UnlimitedPointWorks[12].X),
                        2 * (UnlimitedPointWorks[2].Y - UnlimitedPointWorks[12].Y))),
                    270, 90);
            }

            private void HexagonDrawing(object sender, PaintEventArgs e)
            {
                e.Graphics.DrawImage(this.HexagonImage, this.HexagonRectangle,
                    this.SrcHexagonRectangle, GraphicsUnit.Point);
            }

            #endregion
            //------------------------------------------------------
        }
    }
}
