// Copyright (C) ALiwoto 2019 - 2020
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of the source code.

using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;
using SAO.Constants;
using SAO.SandBox;
using SAO.GameObjects.Kingdoms;

namespace SAO.Controls
{
    partial class GameControls
    {
        partial class RankingBackGroundLabel
        {
            //-------------------------------------------------------

            //-------------------------------------------------------
            #region Ranking's BackGround Region Designing
            private void Initialize_ForRankingBackGround_Component()
            {
                this.Size = new Size(24 * (Father.Width / 45),
                    24 * (Father.Height / 30));
                //-----------------------------
                //News:
                //---------------------------
                this.UnlimitedPointWorks = new Point[]
                {
                    new Point(NoInternetConnectionSandBox.from_the_edge, 
                        ActiveKindRankingLabel.Location.Y + (ActiveKindRankingLabel.Height / 2)), // 1
                    new Point(NoInternetConnectionSandBox.from_the_edge +
                        (Width / 12),
                        ActiveKindRankingLabel.Location.Y + (ActiveKindRankingLabel.Height / 2) -
                        (Width / 24) - Location.Y), // 2
                    new Point(NoInternetConnectionSandBox.from_the_edge +
                        (Width / 12), 
                        (Width / 24)), // 3
                    new Point(NoInternetConnectionSandBox.from_the_edge +
                        (Width / 12) + (Width / 24), 0), // 4
                    new Point(Width, 0), // 5
                    new Point(Width, Height), // 6
                    new Point(NoInternetConnectionSandBox.from_the_edge +
                        (Width / 12), Height), // 7
                    new Point(NoInternetConnectionSandBox.from_the_edge +
                        (Width / 12), ActiveKindRankingLabel.Location.Y + 
                        (ActiveKindRankingLabel.Height / 2) +
                        (Width / 24)), // 8
                };
                this.TitleRanking = new RankingPlayerLabel(this, this, true);
                this.PlayersInRanking = new RankingPlayerLabel[LevelRankings.MAXIMUM_RANKS];
                for (int i = 0; i < LevelRankings.MAXIMUM_RANKS; i++)
                {
                    this.PlayersInRanking[i] = new RankingPlayerLabel(this, this)
                    {
                        Index = (uint)i,
                    };
                }
                this.PaintColors = new Color[]
                {
                    Color.FromArgb(210, Color.SandyBrown),
                };
                this.PaintBrushes = new SolidBrush[]
                {
                    new SolidBrush(this.PaintColors[0]),
                };
                //-----------------------------
                //Names:
                this.TitleRanking.MessageLabel1.SetLabelName(KingdomInfoSandBox.TitleRankingML1NameInRes);
                this.TitleRanking.MessageLabel2.SetLabelName(KingdomInfoSandBox.TitleRankingML2NameInRes);
                this.TitleRanking.MessageLabel3.SetLabelName(KingdomInfoSandBox.TitleRankingML3NameInRes);
                this.TitleRanking.MessageLabel4.SetLabelName(KingdomInfoSandBox.TitleRankingML4NameInRes);
                //TabIndexes:

                //FontsAndTextAligns:
                this.TitleRanking.Font =
                    this.Font =
                    new Font(ThereIsConstants.Forming.TheMainForm.PrivateFonts.Families[1],
                    9, FontStyle.Bold);
                this.TitleRanking.TextAlign =
                    this.TextAlign = ContentAlignment.MiddleCenter;
                for (int i = 0; i < LevelRankings.MAXIMUM_RANKS; i++)
                {
                    this.PlayersInRanking[i].Font = this.Font;
                    this.PlayersInRanking[i].TextAlign = this.TextAlign;
                }
                //Sizes:

                //Locations:
                this.TitleRanking.Location = 
                    new Point(UnlimitedPointWorks[2].X, 0);
                this.PlayersInRanking[0].Location =
                    new Point(TitleRanking.Location.X,
                    TitleRanking.Location.Y + TitleRanking.Height +
                    ThereIsConstants.AppSettings.Between_GameControls);
                for(int i = 1; i < PlayersInRanking.Length; i++)
                {
                    PlayersInRanking[i].Location =
                        new Point(PlayersInRanking[i - 1].Location.X,
                            PlayersInRanking[i - 1].Location.Y +
                            PlayersInRanking[i - 1].Height +
                            (ThereIsConstants.AppSettings.Between_GameControls / 2));
                }
                //Colors:
                this.SetColorTransparent();
                this.SetTextColor(Color.Transparent);
                this.TitleRanking.SetTextColor(Color.Black);
                this.TitleRanking.SetColorTransparent();
                for(int i = 0; i < PlayersInRanking.Length; i++)
                {
                    PlayersInRanking[i].SetColorTransparent();
                }

                //ComboBoxes:
                //Enableds:
                //Texts:
                this.TitleRanking.MessageLabel1.SetLabelText();
                this.TitleRanking.MessageLabel2.SetLabelText();
                this.TitleRanking.MessageLabel3.SetLabelText();
                this.TitleRanking.MessageLabel4.SetLabelText();

                //AddRanges:
                //ToolTipSettings:
                //Images:

                //Events:
                this.Paint += RankingBakcgroundLabel_Paint;
                this.ActiveKindRankingLabel.LocationChanged += ActiveRankingLabel_LocationChanged;
                //RankingPlayerLabel_LocationChanged
                /*
                for (int i = 0; i < PlayersInRanking.Length; i++)
                {
                    PlayersInRanking[i].LocationChanged += RankingPlayerLabel_LocationChanged;
                }
                */
                //-----------------------------
                this.Controls.Add(this.TitleRanking);
                for (int i = 0; i < PlayersInRanking.Length; i++)
                {
                    if(PlayersInRanking[i].Location.Y > 0 && 
                        PlayersInRanking[i].Location.Y <= Height)
                    {
                        this.Controls.Add(PlayersInRanking[i]);
                    }
                }
            }

            private void ActiveRankingLabel_LocationChanged(object sender, EventArgs e)
            {
                ReloadUPW();
            }

            private void RankingBakcgroundLabel_Paint(object sender, PaintEventArgs e)
            {
                e.Graphics.FillPolygon(PaintBrushes[0], UnlimitedPointWorks);
            }
            public void SetActiveRankingKind(RankingKindLabel rankingLabel, bool setAnyway = false)
            {
                if(this.ActiveKindRankingLabel == rankingLabel && !setAnyway)
                {
                    return;
                }
                
                this.ActiveKindRankingLabel = rankingLabel;
                ReloadUPW();
                this.TitleRanking.MessageLabel3.CurrentStatus = 
                this.TitleRanking.MessageLabel4.CurrentStatus =
                    (uint)ActiveKindRankingLabel.RankingsMode;
                this.TitleRanking.MessageLabel3.SetLabelText();
                this.TitleRanking.MessageLabel4.SetLabelText();

                if (ActiveKindRankingLabel.RankingsMode == RankingsMode.PowerRankings)
                {
                    for (int i = 0; i < PlayersInRanking.Length; i++)
                    {
                        PlayersInRanking[i].MessageLabel1.SetLabelText((i + 1).ToString());
                        PlayersInRanking[i].MessageLabel2.SetLabelText(
                            this.KingdomInfo.Rankings.PowerRankings.PlayerNames[i]);
                        PlayersInRanking[i].MessageLabel3.SetLabelText(string.Empty);
                        PlayersInRanking[i].MessageLabel4.SetLabelText(
                            this.KingdomInfo.Rankings.PowerRankings.PlayerPowers[i].ToString());
                    }
                }
                else if(ActiveKindRankingLabel.RankingsMode == RankingsMode.LevelRankings)
                {
                    for (int i = 0; i < PlayersInRanking.Length; i++)
                    {
                        PlayersInRanking[i].MessageLabel1.SetLabelText((i + 1).ToString());
                        PlayersInRanking[i].MessageLabel2.SetLabelText(
                            this.KingdomInfo.Rankings.LevelRankings.PlayerNames[i]);
                        PlayersInRanking[i].MessageLabel3.SetLabelText(
                            this.KingdomInfo.Rankings.LevelRankings.PlayerLevels[i].ToString());
                        PlayersInRanking[i].MessageLabel4.SetLabelText(
                            this.KingdomInfo.Rankings.LevelRankings.PlayerTotalExp[i].ToString());
                    }
                }
                for(int i = 0; i < PlayersInRanking.Length; i++)
                {
                    if(PlayersInRanking[i].Parent != null)
                    {
                        this.Controls.Remove(PlayersInRanking[i]);
                    }
                }
                this.PlayersInRanking[0].Location =
                    new Point(TitleRanking.Location.X,
                        TitleRanking.Location.Y + TitleRanking.Height +
                        ThereIsConstants.AppSettings.Between_GameControls);
                for (int i = 1; i < PlayersInRanking.Length; i++)
                {
                    PlayersInRanking[i].Location =
                        new Point(PlayersInRanking[i - 1].Location.X,
                        PlayersInRanking[i - 1].Location.Y +
                        PlayersInRanking[i - 1].Height +
                        (ThereIsConstants.AppSettings.Between_GameControls / 2));
                }
                for (int i = 0; i < PlayersInRanking.Length; i++)
                {
                    if (PlayersInRanking[i].Location.Y > 0 &&
                        PlayersInRanking[i].Location.Y <= Height)
                    {
                        this.Controls.Add(PlayersInRanking[i]);
                    }
                }
                
            }
            public void SetActiveRankingPlayer(RankingPlayerLabel playerLabel , bool setAnyway = false)
            {
                if (this.ActivePlayerRankingLabel == playerLabel && !setAnyway)
                {
                    return;
                }
                this.ActivePlayerRankingLabel = playerLabel;
            }
            public void CallMeForWork()
            {
                if (this.IsWorking)
                {
                    return;
                }
                else
                {
                    this.IsWorking = true;
                }
                for(int i = ((int)this.ActivePlayerRankingLabel.Index - 1); i >= 0; i--)
                {
                    this.PlayersInRanking[i].Location =
                        new Point(PlayersInRanking[i + 1].Location.X,
                        PlayersInRanking[i + 1].Location.Y -
                        PlayersInRanking[i + 1].Height -
                        (ThereIsConstants.AppSettings.Between_GameControls / 2));
                    if (PlayersInRanking[i].Location.Y > 0 &&
                        PlayersInRanking[i].Location.Y <= PlayersInRanking[i].BackgroundLabel.Height)
                    {
                        if (PlayersInRanking[i].Parent == null)
                        {
                            this.Controls.Add(PlayersInRanking[i]);
                        }
                    }
                    else
                    {
                        if (PlayersInRanking[i].Parent != null)
                        {
                            this.Controls.Remove(PlayersInRanking[i]);
                        }
                    }
                }

                for (int i = ((int)this.ActivePlayerRankingLabel.Index + 1); 
                    i < PlayersInRanking.Length; i++)
                {
                        this.PlayersInRanking[i].Location =
                        new Point(PlayersInRanking[i - 1].Location.X,
                        PlayersInRanking[i - 1].Location.Y +
                        PlayersInRanking[i - 1].Height +
                        (ThereIsConstants.AppSettings.Between_GameControls / 2));
                    if (PlayersInRanking[i].Location.Y > 0 &&
                        PlayersInRanking[i].Location.Y <= PlayersInRanking[i].BackgroundLabel.Height)
                    {
                        
                        if (PlayersInRanking[i].Parent == null)
                        {
                            this.Controls.Add(PlayersInRanking[i]);
                        }
                    }
                    else
                    {
                        if (PlayersInRanking[i].Parent != null)
                        {
                            this.Controls.Remove(PlayersInRanking[i]);
                        }
                    }
                }
                this.Update();
                this.IsWorking = false;
            }

            #endregion

            //-------------------------------------------------------

            //-------------------------------------------------------
            //-------------------------------------------------------
            //-------------------------------------------------------
            //-------------------------------------------------------
            //-------------------------------------------------------
            //-------------------------------------------------------

            public override void ReloadUPW()
            {
                this.UnlimitedPointWorks = new Point[]
                {
                    new Point(NoInternetConnectionSandBox.from_the_edge,
                        ActiveKindRankingLabel.Location.Y + (ActiveKindRankingLabel.Height / 2)), // 1
                    new Point(NoInternetConnectionSandBox.from_the_edge +
                        (Width / 12),
                        ActiveKindRankingLabel.Location.Y +
                        (ActiveKindRankingLabel.Height / 2) -
                        (Width / 24) - Location.Y), // 2
                    new Point(NoInternetConnectionSandBox.from_the_edge +
                        (Width / 12),
                        (Width / 24)), // 3
                    new Point(NoInternetConnectionSandBox.from_the_edge +
                        (Width / 12) + (Width / 24), 0), // 4
                    new Point(Width, 0), // 5
                    new Point(Width, Height), // 6
                    new Point(NoInternetConnectionSandBox.from_the_edge +
                        (Width / 12), Height), // 7
                    new Point(NoInternetConnectionSandBox.from_the_edge +
                        (Width / 12), ActiveKindRankingLabel.Location.Y +
                        (ActiveKindRankingLabel.Height / 2) +
                        (Width / 24)), // 8
                };
            }
            //-------------------------------------------------------
        }
    }
}
