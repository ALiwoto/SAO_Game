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
        partial class RankingKindLabel
        {
            //-------------------------------------------------------
            #region RankingKindLabel Region Designing
            private void Initialize_ForRankingKind_Component()
            {
                this.Size = new Size(12 * (Father.Width / 48),
                    12 * (Father.Height / 72));
                //-----------------------------
                //News:
                //---------------------------
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
                this.MessageLabel1 = new LabelControl(this);
                //-----------------------------
                //Names:

                //TabIndexes:

                //FontsAndTextAligns:
                this.Font = this.MessageLabel1.Font =
                    new Font(ThereIsConstants.Forming.TheMainForm.PrivateFonts.Families[1],
                    17, FontStyle.Bold);
                this.MessageLabel1.TextAlign =
                    this.TextAlign = ContentAlignment.MiddleCenter;
                //Sizes:
                this.MessageLabel1.Size = this.Size;
                //Locations:

                //Colors:
                this.SetColorTransparent();
                this.MessageLabel1.SetColorTransparent();
                this.SetTextColor(Color.Transparent);
                this.MessageLabel1.SetTextColor(Color.Black);

                //ComboBoxes:
                //Enableds:
                //Texts:
                this.MessageLabel1.SetLabelSoundEffects(Noises.ClickNoise);
                //AddRanges:
                //ToolTipSettings:
                //Images:

                //Events:
                this.Paint += RankingLabel_Paint;
                this.TextChanged += RankingLabel_TextChanged;
                //-----------------------------
                this.Controls.Add(this.MessageLabel1);
            }

            private void RankingLabel_TextChanged(object sender, EventArgs e)
            {
                this.MessageLabel1.SetLabelText(this.Text);
            }
            private void RankingLabel_Paint(object sender, PaintEventArgs e)
            {
                e.Graphics.FillPolygon(new SolidBrush(Color.FromArgb(125,
                    IsSelected ? Color.Gold : Color.WhiteSmoke)),
                    UnlimitedPointWorks);
                e.Graphics.FillPie(new SolidBrush(Color.FromArgb(125,
                    IsSelected ? Color.Gold : Color.WhiteSmoke)),
                    new Rectangle(new Point(0, 0), // 1
                    new Size(2 * (Width / 12), 2 * (Width / 12))),
                        180, 90);
                e.Graphics.FillPie(new SolidBrush(Color.FromArgb(125,
                    IsSelected ? Color.Gold : Color.WhiteSmoke)),
                    new Rectangle(new Point(UnlimitedPointWorks[3].X -
                        (1 * (Width / 12)), 0),
                    new Size(2 * (Width / 12), 2 * (Width / 12))),
                        270, 90);
                e.Graphics.FillPie(new SolidBrush(Color.FromArgb(125,
                    IsSelected ? Color.Gold : Color.WhiteSmoke)),
                    new Rectangle(new Point(UnlimitedPointWorks[7].X - (1 * (Width / 12)),
                        UnlimitedPointWorks[7].Y - (1 * (Width / 12))),
                    new Size(2 * (Width / 12), 2 * (Width / 12))),
                        0, 90);
                e.Graphics.FillPie(new SolidBrush(Color.FromArgb(125,
                    IsSelected ? Color.Gold : Color.WhiteSmoke)),
                    new Rectangle(new Point(UnlimitedPointWorks[10].X - (1 * (Width / 12)),
                        UnlimitedPointWorks[10].Y - (1 * (Width / 12))),
                    new Size(2 * (Width / 12), 2 * (Width / 12))),
                        90, 90);
            }

            #endregion
            //-------------------------------------------------------
            //-------------------------------------------------------
            //-------------------------------------------------------
            //-------------------------------------------------------
            //-------------------------------------------------------
            //-------------------------------------------------------
            //-------------------------------------------------------
            //-------------------------------------------------------

            /// <summary>
            /// I don't want any text, I will set the Text of
            /// <see cref="LabelControl.MessageLabel1"/>
            /// instead.
            /// </summary>
            public override void SetLabelText()
            {
                this.MessageLabel1.Text = this.MyRes.GetString(
                    this.MyRes.GetString(this.Name) +
                    ThereIsConstants.ResourcesName.Separate_Character +
                    ThereIsConstants.AppSettings.Language +
                    this.CurrentStatus.ToString());

            }
            /// <summary>
            /// Reload the Unlimited Point Works.
            /// </summary>
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
            //-------------------------------------------------------
        }
    }
}
