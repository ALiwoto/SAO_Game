// Copyright (C) ALiwoto 2019 - 2020
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of the source code.

using System;
using System.Drawing;
using System.Windows.Forms;
using SAO.Constants;

namespace SAO.Controls
{
    partial class GameControls
    {
        partial class InfoLabel
        {
            //---------------------------------------------
            #region InfoLabel Region
            private void DesigningForInfoLabelMDKSIL()
            {
                this.SingleClick = true;
                this.Size = new Size(12 * (ThereIsConstants.Forming.GameClient.Width / 100),
                    2 * (ThereIsConstants.Forming.GameClient.Height / 75));
                //-----------------------------------------
                //News:
                this.MessageLabel1 = new LabelControl(this);
                this.UnlimitedPointWorks = new Point[]
                {
                    new Point(0, 1 * (Width / 12)), // 1
                    new Point(1 * (Width / 12), 1 * (Width / 12)), // 2
                    new Point(1 * (Width / 12), 0), // 3
                    new Point(11 * (Width / 12), 0), // 4
                    new Point(11 * (Width / 12), 1 * (Width / 12)), // 5
                    new Point(Width, 1 * (Width / 12)), // 6
                    new Point(Width, Height - (1 * (Width / 12))), // 7
                    new Point(11 * (Width / 12), Height - (1 * (Width / 12))), // 8
                    new Point(11 * (Width / 12), Height), // 9
                    new Point(1 * (Width / 12), Height), // 10
                    new Point(1 * (Width / 12), Height - (1 * (Width / 12))), // 11
                    new Point(0, Height - (1 * (Width / 12))), // 12
                };
                this.PaintColors = new Color[]
                {
                    Color.FromArgb(225, Color.Gold),
                };
                this.PaintBrushes = new Brush[]
                {
                    new SolidBrush(this.PaintColors[0]),
                };
                //-----------------------------
                //Names:
                this.MessageLabel1.SetLabelName(labelForTextName);
                //TabIndexes:
                this.MessageLabel1.CurrentStatus = 1;
                //FontsAndTextAligns:
                this.Font = new Font(ThereIsConstants.Forming.TheMainForm.PrivateFonts.Families[1],
                    13, FontStyle.Bold);
                this.MessageLabel1.Font = this.Font;
                this.MessageLabel1.TextAlign = ContentAlignment.MiddleCenter;
                //Sizes:

                this.MessageLabel1.Size = this.Size;
                //Locations:
                
                this.MessageLabel1.Location = new Point((this.Width / 2) -
                    (this.MessageLabel1.Width / 2), (this.Height / 2) - (this.MessageLabel1.Height / 2));
                //Colors:
                this.SetColorTransparent();
                this.MessageLabel1.SetColorTransparent();
                //ComboBoxes:
                //Enableds:
                this.MessageLabel1.SingleClick = true;
                //Texts:
                this.MessageLabel1.SetLabelText();
                //AddRanges:
                //ToolTipSettings:
                //Events:
                this.SizeChanged += InfoLabel_SizeChanged;
                this.Paint += InfoLabel_Paint;
                //-----------------------------
                this.Controls.Add(this.MessageLabel1);

            }

            private void InfoLabel_SizeChanged(object sender, EventArgs e)
            {
                this.ReloadUPW();
            }
            private void InfoLabel_Paint(object sender, PaintEventArgs e)
            {
                e.Graphics.FillPolygon(this.PaintBrushes[0],
                    new Point[]
                    {
                        UnlimitedPointWorks[0], // 1
                        UnlimitedPointWorks[1], // 2
                        UnlimitedPointWorks[2], // 3
                        UnlimitedPointWorks[3], // 4
                        UnlimitedPointWorks[4], // 5
                        UnlimitedPointWorks[5], // 6
                        UnlimitedPointWorks[6], // 7
                        UnlimitedPointWorks[7], // 8
                        UnlimitedPointWorks[8], // 9
                        UnlimitedPointWorks[9], // 10
                        UnlimitedPointWorks[10], // 11
                        UnlimitedPointWorks[11], // 12
                    });
                e.Graphics.FillPie(this.PaintBrushes[0],
                    new Rectangle(new Point(0, 0), // 1
                    new Size(2 * (Width / 12), 2 * (Width / 12))),
                    180, 90);
                e.Graphics.FillPie(this.PaintBrushes[0],
                    new Rectangle(new Point(UnlimitedPointWorks[3].X - (1 * (Width / 12)), 0),
                    new Size(2 * (Width / 12), 2 * (Width / 12))),
                    270, 90);
                e.Graphics.FillPie(this.PaintBrushes[0],
                    new Rectangle(new Point(UnlimitedPointWorks[7].X - (1 * (Width / 12)),
                    UnlimitedPointWorks[7].Y - (1 * (Width / 12))),
                    new Size(2 * (Width / 12), 2 * (Width / 12))),
                    0, 90);
                e.Graphics.FillPie(this.PaintBrushes[0],
                    new Rectangle(new Point(UnlimitedPointWorks[10].X - (1 * (Width / 12)),
                    UnlimitedPointWorks[10].Y - (1 * (Width / 12))),
                    new Size(2 * (Width / 12), 2 * (Width / 12))),
                    90, 90);
            }

            #endregion
            //---------------------------------------------
            #region InfoLabel KSKISBIL Region
            private void DesigningForInfoLabelKSKISBIL()
            {
                this.SingleClick = true;
                this.Size = new Size(12 * (this.Father.Width / 28),
                    12 * (this.Father.Height / 78));
                //-----------------------------------------
                //News:
                this.MessageLabel1 = new LabelControl(this);
                this.UnlimitedPointWorks = new Point[]
                {
                    new Point(0, 1 * (Width / 12)), // 1
                    new Point(1 * (Width / 12), 1 * (Width / 12)), // 2
                    new Point(1 * (Width / 12), 0), // 3
                    new Point(11 * (Width / 12), 0), // 4
                    new Point(11 * (Width / 12), 1 * (Width / 12)), // 5
                    new Point(Width, 1 * (Width / 12)), // 6
                    new Point(Width, Height - (1 * (Width / 12))), // 7
                    new Point(11 * (Width / 12), Height - (1 * (Width / 12))), // 8
                    new Point(11 * (Width / 12), Height), // 9
                    new Point(1 * (Width / 12), Height), // 10
                    new Point(1 * (Width / 12), Height - (1 * (Width / 12))), // 11
                    new Point(0, Height - (1 * (Width / 12))), // 12
                };
                this.PaintColors = new Color[]
                {
                    Color.FromArgb(225, Color.DarkGreen),
                };
                this.PaintBrushes = new Brush[]
                {
                    new SolidBrush(this.PaintColors[0]),
                };
                //-----------------------------
                //Names:
                //TabIndexes:
                this.MessageLabel1.CurrentStatus = 1;
                //FontsAndTextAligns:
                this.Font = new Font(ThereIsConstants.Forming.TheMainForm.PrivateFonts.Families[1],
                    17f, FontStyle.Bold);
                this.MessageLabel1.Font = this.Font;
                this.MessageLabel1.TextAlign = ContentAlignment.MiddleCenter;
                //Sizes:
                this.MessageLabel1.Size = this.Size;
                //Locations:
                //Colors:
                this.SetColorTransparent();
                this.MessageLabel1.SetColorTransparent();
                this.MessageLabel1.SetTextColor(Color.Pink);
                //ComboBoxes:
                //Enableds:
                this.MessageLabel1.SingleClick = true;
                //Texts:
                //SoudEffects:
                this.MessageLabel1.SetLabelSoundEffects(Noises.ClickNoise);
                //AddRanges:
                //ToolTipSettings:
                //Events:
                this.SizeChanged += InfoLabel_SizeChanged;
                this.Paint += InfoLabel_Paint;
                this.MessageLabel1.MouseDown += InfoLabel_MouseDown;
                this.MessageLabel1.MouseUp += InfoLabel_MouseUp;
                //-----------------------------
                this.Controls.Add(this.MessageLabel1);

            }

            private void InfoLabel_MouseUp(object sender, MouseEventArgs e)
            {
                if (UseAnimation)
                {
                    HasMouseDowned = false;
                    this.PaintBrushes[0] = 
                        new SolidBrush(this.PaintColors[0]);
                    this.Invalidate();
                }
            }

            private void InfoLabel_MouseDown(object sender, MouseEventArgs e)
            {
                if (UseAnimation)
                {
                    HasMouseDowned = true;
                    this.PaintBrushes[0] = 
                        new SolidBrush(Color.FromArgb(225, Color.DarkSeaGreen));
                    this.Invalidate();
                }
            }

            #endregion

            //---------------------------------------------
            #region overrided Methods region
            public override void SetLabelName(string constParam)
            {
                this.RealName = constParam;
                this.Name = this.RealName +
                    ThereIsConstants.ResourcesName.End_Res_Name;
                if(this.MessageLabel1 != null)
                {
                    this.MessageLabel1.SetLabelName(constParam);
                }
            }
            public override void SetLabelText()
            {
                this.MessageLabel1.Text = this.MyRes.GetString(
                    this.MyRes.GetString(this.Name) +
                    ThereIsConstants.ResourcesName.Separate_Character +
                    ThereIsConstants.AppSettings.Language +
                    this.CurrentStatus.ToString());
            }
            public override void ReloadUPW()
            {
                this.UnlimitedPointWorks = new Point[]
                {
                    new Point(0, 1 * (Width / 12)), // 1
                    new Point(1 * (Width / 12), 1 * (Width / 12)), // 2
                    new Point(1 * (Width / 12), 0), // 3
                    new Point(11 * (Width / 12), 0), // 4
                    new Point(11 * (Width / 12), 1 * (Width / 12)), // 5
                    new Point(Width, 1 * (Width / 12)), // 6
                    new Point(Width, Height - (1 * (Width / 12))), // 7
                    new Point(11 * (Width / 12), Height - (1 * (Width / 12))), // 8
                    new Point(11 * (Width / 12), Height), // 9
                    new Point(1 * (Width / 12), Height), // 10
                    new Point(1 * (Width / 12), Height - (1 * (Width / 12))), // 11
                    new Point(0, Height - (1 * (Width / 12))), // 12
                };
            }

            #endregion
            //---------------------------------------------
        }
    }
}
