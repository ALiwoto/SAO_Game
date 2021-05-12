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
        partial class RankingPlayerLabel
        {
            //-------------------------------------------------------
            //-------------------------------------------------------
            //-------------------------------------------------------
            #region Ranking's Player Region Designing
            private void Initialize_ForRankingPlayer_Component()
            {
                this.Size = new Size(BackgroundLabel.UnlimitedPointWorks[4].X -
                    BackgroundLabel.UnlimitedPointWorks[2].X,
                    2 * (BackgroundLabel.UnlimitedPointWorks[2].Y -
                    BackgroundLabel.UnlimitedPointWorks[3].Y));
                //-----------------------------
                //News:
                this.UnlimitedPointWorks = new Point[]
                {

                    new Point((Width / 24), 0), // 1
                    new Point(Width, 0), // 2
                    new Point(Width, Height), // 3
                    new Point(0, Height), // 4
                    new Point(0, (Width / 24)), // 5
                    
                };
                this.MessageLabel1 = new LabelControl(this); // The Rank of Player
                this.MessageLabel2 = new LabelControl(this); // The Name of Player
                this.MessageLabel3 = new LabelControl(this); // GetTheValue1: Level
                this.MessageLabel4 = new LabelControl(this); // GetTheValue2: Exp and Power
                //---------------------------
                //-----------------------------
                //Names:

                //TabIndexes:

                //FontsAndTextAligns:
                this.MessageLabel1.Font =
                    new Font(ThereIsConstants.Forming.TheMainForm.PrivateFonts.Families[1],
                    10, FontStyle.Bold);
                this.MessageLabel2.Font =
                this.MessageLabel3.Font =
                this.MessageLabel4.Font =
                this.Font =
                    new Font(ThereIsConstants.Forming.TheMainForm.PrivateFonts.Families[1],
                    13, FontStyle.Bold);
                this.MessageLabel1.TextAlign =
                this.MessageLabel2.TextAlign =
                this.MessageLabel3.TextAlign =
                this.MessageLabel4.TextAlign =
                this.TextAlign = ContentAlignment.MiddleCenter;

                //Sizes:
                this.MessageLabel1.Size =
                    new Size(UnlimitedPointWorks[0].X - UnlimitedPointWorks[4].X,
                    Height);
                this.MessageLabel2.Size =
                    new Size(2 * ((UnlimitedPointWorks[1].X - UnlimitedPointWorks[0].X)
                    / 5), Height);
                this.MessageLabel3.Size =
                    new Size(1 * ((UnlimitedPointWorks[1].X - UnlimitedPointWorks[0].X)
                    / 5), Height);
                this.MessageLabel4.Size =
                    new Size(((UnlimitedPointWorks[1].X - UnlimitedPointWorks[0].X) -
                    ((2 * ((UnlimitedPointWorks[1].X - UnlimitedPointWorks[0].X) / 5)) +
                    (1 * ((UnlimitedPointWorks[1].X - UnlimitedPointWorks[0].X) / 5)))),
                    Height);
                //Locations:
                this.MessageLabel1.Location = new Point(0, 0);
                this.MessageLabel2.Location = new Point(MessageLabel1.Location.X +
                    MessageLabel1.Width, MessageLabel1.Location.Y);
                this.MessageLabel3.Location = new Point(MessageLabel2.Location.X +
                    MessageLabel2.Width, MessageLabel2.Location.Y);
                this.MessageLabel4.Location = new Point(MessageLabel3.Location.X +
                    MessageLabel3.Width, MessageLabel3.Location.Y);
                //Colors:
                this.SetColorTransparent();
                this.MessageLabel1.SetColorTransparent();
                this.MessageLabel2.SetColorTransparent();
                this.MessageLabel3.SetColorTransparent();
                this.MessageLabel4.SetColorTransparent();
                this.SetTextColor(Color.Transparent);
                this.MessageLabel1.SetTextColor(
                    IsTitleRanking ? Color.Gray : 
                    Color.LightGoldenrodYellow);
                this.MessageLabel2.SetTextColor(Color.Black);
                this.MessageLabel3.SetTextColor(Color.Black);
                this.MessageLabel4.SetTextColor(Color.Black);

                //ComboBoxes:
                //Enableds:
                //Texts:

                //AddRanges:
                //ToolTipSettings:
                //Images:

                //Events:
                this.MessageLabel1.MouseDown += Shocker;
                this.MessageLabel2.MouseDown += Shocker;
                this.MessageLabel3.MouseDown += Shocker;
                this.MessageLabel4.MouseDown += Shocker;
                this.MessageLabel1.MouseUp += Discharge;
                this.MessageLabel2.MouseUp += Discharge;
                this.MessageLabel3.MouseUp += Discharge;
                this.MessageLabel4.MouseUp += Discharge;
                this.Paint += PlayerRankingLabel_Paint;
                //-----------------------------
                this.Controls.AddRange(new LabelControl[]
                {
                    this.MessageLabel1,
                    this.MessageLabel2,
                    this.MessageLabel3,
                    this.MessageLabel4,
                });

            }

            private void RankingPlayerLabel_LocationChanged(object sender, EventArgs e)
            {
                if (IsMoving)
                {
                    return;
                }
                else
                {
                    IsMoving = true;
                }
                /*
                if(sender is RankingLabel p && false)
                {
                    if (p.Index == 0)
                    {
                        if (p.BackgroundLabel.PlayersInRanking[p.Index + 1].Location.Y ==
                            p.Location.Y + p.Height +
                            (ThereIsConstants.AppSettings.Between_GameControls / 2))
                        {
                            return;
                        }
                        else
                        {
                            p.BackgroundLabel.PlayersInRanking[p.Index + 1].Location =
                                new Point(p.Location.X, p.Location.Y + p.Height +
                                    (ThereIsConstants.AppSettings.Between_GameControls / 2));
                            p.Parent.Invalidate();

                        }
                    }
                    // this PlayerRankingLabel is the Last.
                    else if (p.Index == p.BackgroundLabel.PlayersInRanking.Length - 1)
                    {
                        if (p.BackgroundLabel.PlayersInRanking[p.Index - 1].Location.Y ==
                            p.Location.Y - p.Height -
                            (ThereIsConstants.AppSettings.Between_GameControls / 2))
                        {
                            return;
                        }
                        else
                        {
                            p.BackgroundLabel.PlayersInRanking[p.Index - 1].Location =
                                new Point(p.Location.X, p.Location.Y - p.Height -
                                    (ThereIsConstants.AppSettings.Between_GameControls / 2));
                            p.Parent.Invalidate();
                        }
                    }
                    // it is in the middle.
                    else
                    {
                        if ((p.BackgroundLabel.PlayersInRanking[p.Index + 1].Location.Y ==
                            p.Location.Y + p.Height +
                            (ThereIsConstants.AppSettings.Between_GameControls / 2)) &&
                            (p.BackgroundLabel.PlayersInRanking[p.Index - 1].Location.Y ==
                            p.Location.Y - p.Height -
                            (ThereIsConstants.AppSettings.Between_GameControls / 2)))
                        {

                            return;
                        }
                        else
                        {
                            if ((p.BackgroundLabel.PlayersInRanking[p.Index + 1].Location.Y !=
                                p.Location.Y + p.Height +
                                (ThereIsConstants.AppSettings.Between_GameControls / 2)))
                            {
                                p.BackgroundLabel.PlayersInRanking[p.Index + 1].Location =
                                new Point(p.Location.X, p.Location.Y + p.Height +
                                    (ThereIsConstants.AppSettings.Between_GameControls / 2));
                                p.Parent.Invalidate();

                            }
                            if ((p.BackgroundLabel.PlayersInRanking[p.Index - 1].Location.Y !=
                                p.Location.Y - p.Height -
                                (ThereIsConstants.AppSettings.Between_GameControls / 2)))
                            {
                                p.BackgroundLabel.PlayersInRanking[p.Index - 1].Location =
                                new Point(p.Location.X, p.Location.Y - p.Height -
                                    (ThereIsConstants.AppSettings.Between_GameControls / 2));
                                p.Parent.Invalidate();
                            }


                        }
                    }
                }

                */


                this.BackgroundLabel.CallMeForWork();
                IsMoving = false;
            }

            private void PlayerRankingLabel_Paint(object sender, PaintEventArgs e)
            {
                e.Graphics.FillPolygon(new SolidBrush(
                    IsTitleRanking ? Color.PaleGoldenrod : Color.LightSlateGray),
                    new Point[]
                    {
                        UnlimitedPointWorks[0], // 1
                        UnlimitedPointWorks[1], // 2
                        UnlimitedPointWorks[2], // 3
                        UnlimitedPointWorks[3], // 4
                        UnlimitedPointWorks[4], // 5
                    });
            }

            public void Discharge(object sender, MouseEventArgs e)
            {
                this.LocationChanged -= this.RankingPlayerLabel_LocationChanged;
                if (sender is GameControls.LabelControl myLabel)
                {
                    myLabel.MouseMove -= MoveMe;
                }
            }

            public void Shocker(object sender, MouseEventArgs e)
            {
                if (Movements != ElementMovements.NoMovements)
                {
                    this.LastPoint = e.Location;
                    this.BackgroundLabel.SetActiveRankingPlayer(this, true);
                    this.LocationChanged += this.RankingPlayerLabel_LocationChanged;
                    if(sender is GameControls.LabelControl myLabel)
                    {
                        myLabel.MouseMove += MoveMe;
                    }

                }
            }

            public void MoveMe(object sender, MouseEventArgs e)
            {
                if (Math.Abs(e.Y - LastPoint.Y) < 10)
                {
                    return;
                }
                // Movements is ElementMovements.VerticalMovements,
                // So the Location.Y should be changed.
                this.Location =
                    new Point(this.Location.X,
                        this.Location.Y + (e.Y - LastPoint.Y));
                this.LastPoint = e.Location;
                
            }



            #endregion


            //-------------------------------------------------------
            //-------------------------------------------------------
            //-------------------------------------------------------
            //-------------------------------------------------------
            //-------------------------------------------------------
            //-------------------------------------------------------

            /// <summary>
            /// Reload the Unlimited Point Works.
            /// </summary>
            public override void ReloadUPW()
            {
                this.UnlimitedPointWorks = new Point[]
                {

                    new Point((Width / 24), 0), // 1
                    new Point(Width, 0), // 2
                    new Point(Width, Height), // 3
                    new Point(0, Height), // 4
                    new Point(0, (Width / 24)), // 5
                    
                };
            }
            //-------------------------------------------------------
        }
    }
}
