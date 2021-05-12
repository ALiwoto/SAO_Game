// Copyright (C) ALiwoto 2019 - 2020
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of the source code.

using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using WotoProvider.Enums;
using SAO.Controls;
using SAO.Constants;
using SAO.GameObjects.Kingdoms;
using SAO.GameObjects.Heroes;
using SAO.GameObjects.ServerObjects;
using SAO.GameObjects.Resources;
using SAO.GameObjects.Characters;

namespace SAO.SandBox
{
    partial class KingdomInfoSandBox
    {
        //----------------------------------------------
        #region Ordinary Initialization for KingdomInfoSandBox
        private void InitializeComponent()
        {
            this.Size = new Size(16 * (this.UnderForm.Width / 18),
                16 * (this.UnderForm.Height / 18));
            this.CenterToScreen();
            this.Opacity = 0.9;
            //----------------------------------
            //News:
            this.MyRes = new WotoRes(typeof(KingdomInfoSandBox));
            this.ActiveItemBar = this.ItemBarLabel1 =
                new GameControls.ItemBarLabelControl(this, GameControls.LabelControlSpecies.ItemBarLabel, this)
                {
                    IsSelected = true,
                };
            this.ItemBarLabel2 =
                new GameControls.ItemBarLabelControl(this, GameControls.LabelControlSpecies.ItemBarLabel, this);
            this.ItemBarLabel3 =
                new GameControls.ItemBarLabelControl(this, GameControls.LabelControlSpecies.ItemBarLabel, this);
            this.CancelButton = this.CloseLabel = 
                new GameControls.CloseLabel(this, this);
            //----------------------------------
            //Names:
            this.ItemBarLabel1.MessageLabel1.SetLabelName(ItemBar1NameInRes);
            this.ItemBarLabel2.MessageLabel1.SetLabelName(ItemBar2NameInRes);
            this.ItemBarLabel3.MessageLabel1.SetLabelName(ItemBar3NameInRes);
            this.ItemBarLabel1.SetLabelName(ItemBar1NameInRes);
            this.ItemBarLabel2.SetLabelName(ItemBar2NameInRes);
            this.ItemBarLabel3.SetLabelName(ItemBar3NameInRes);
            
            //TabIndexes
            //FontAndTextAligns:
            //Sizes:
            this.ItemBarLabel1.Size =
            this.ItemBarLabel2.Size =
            this.ItemBarLabel3.Size =
                new Size((Width - CloseLabel.Width -
                (2 * NoInternetConnectionSandBox.from_the_edge)) / 3,
                ItemBarLabel1.Height);
            
            //Locations:
            this.CloseLabel.Location = new Point(Width - CloseLabel.Width -
                NoInternetConnectionSandBox.from_the_edge,
                NoInternetConnectionSandBox.from_the_edge);
            this.ItemBarLabel2.Location = 
                new Point((CloseLabel.Location.X / 2) - 
                (ItemBarLabel2.Width / 2), NoInternetConnectionSandBox.from_the_edge / 2);
            this.ItemBarLabel1.Location = 
                new Point(ItemBarLabel2.Location.X - ItemBarLabel1.Width,
                ItemBarLabel2.Location.Y);
            this.ItemBarLabel3.Location = 
                new Point(ItemBarLabel2.Location.X +
                ItemBarLabel2.Width, ItemBarLabel2.Location.Y);
            //Colors:
            //ComboBoxes:
            //Enableds:
            //Texts:
            this.ItemBarLabel1.MessageLabel1.SetLabelText();
            this.ItemBarLabel2.MessageLabel1.SetLabelText();
            this.ItemBarLabel3.MessageLabel1.SetLabelText();
            //AddRanges:
            //ToolTipSettings:
            //FinalBlow:
            this.RemoveMovingClicking();
            this.ItemBarLabel1.ReloadUPW();
            this.ItemBarLabel2.ReloadUPW();
            this.ItemBarLabel3.ReloadUPW();
            //----------------------------------
            //Events:
            this.Paint += KingdomInfoSandBox_Paint;
            //this.ItemBarLabel1.MessageLabel1.Click += ItemBarLabel_Click; it is the default.
            this.ItemBarLabel2.MessageLabel1.Click += ItemBarLabel_Click;
            this.ItemBarLabel3.MessageLabel1.Click += ItemBarLabel_Click;
            //----------------------------------
            this.Controls.AddRange(new Control[]
            {
                this.ItemBarLabel1,
                this.ItemBarLabel2,
                this.ItemBarLabel3,
                this.CloseLabel,
            });

            /* Please NOTICE: 
             * DO NOT add anymore to the this.Controls,
             * the Kingdom Background will be added to the controls
             * by the following Method (DesingForInfo()),
             * after that, you should removing the controls from
             * KingdomBackground, no the controls.
             * 
             * Thanks, mrwoto.
             * Note by: mrwoto 
             *      in  14 / 11 / 2020, 19 : 47 PM.
             */

            //---------------------------------
            DesingForInfo();
        }

        private void ItemBarLabel_Click(object sender, EventArgs e)
        {
            if (sender is GameControls.LabelControl label)
            {
                if(label.Parent is GameControls.ItemBarLabelControl itemBar)
                {
                    if (ActiveItemBar == itemBar)
                    {
                        return;
                    }
                    else
                    {
                        itemBar.IsSelected = true;
                        //itemBar.MessageLabel1.SetLabelSoundEffects(Noises.NoNoise);
                        itemBar.Invalidate();
                        itemBar.MessageLabel1.Click -= ItemBarLabel_Click;
                        ActiveItemBar.IsSelected = false;
                        ActiveItemBar.MessageLabel1.SetLabelSoundEffects(Noises.ClickNoise);
                        ActiveItemBar.MessageLabel1.Click += ItemBarLabel_Click;
                        ActiveItemBar.Invalidate();
                        switch (ActiveItemBar.RealName) // Removing Switch
                        {
                            case ItemBar1NameInRes:
                                ThereIsConstants.Actions.DisposeAllChild(this.KingdomBackground);
                                this.KingdomBackground.Controls.Clear();
                                this.KingdomBackground.Paint -= KingdomInfoSandBoxDesignForInfo_Paint;
                                this.KingdomBackground.Invalidate();
                                this.MessageLabel1 = this.MessageLabel2 =
                                this.MessageLabel3 = this.MessageLabel4 = null;
                                break;
                            case ItemBar2NameInRes:
                                ThereIsConstants.Actions.DisposeAllChild(this.KingdomBackground);
                                this.KingdomBackground.Controls.Clear();
                                this.MessageLabel1 = this.ActiveRankingLabel = null;
                                this.MessageLabel2 = this.MessageLabel2 =
                                this.MessageLabel3 = null;
                                break;
                            case ItemBar3NameInRes:
                                ThereIsConstants.Actions.DisposeAllChild(this.KingdomBackground);
                                this.KingdomBackground.Controls.Clear();
                                this.ThroneLabels = null;
                                break;
                            default:
                                // ?:
                                break;
                        }
                        GC.Collect();
                        //-------------------------------------
                        ActiveItemBar = itemBar;
                        
                        switch (ActiveItemBar.RealName) // Adding Switch
                        {
                            case ItemBar1NameInRes:
                                DesingForInfo(false);
                                break;
                            case ItemBar2NameInRes:
                                DesignForRankings();
                                break;
                            case ItemBar3NameInRes:
                                DesignForThrones();
                                break;
                            default:
                                // ?:
                                break;
                        }
                        this.KingdomBackground.Invalidate();
                    }
                    
                }
                
            }
        }

        private void KingdomInfoSandBox_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(new Pen(Color.GhostWhite, 4),
                0, this.ItemBarLabel1.Location.Y +
                this.ItemBarLabel1.Height + NoInternetConnectionSandBox.from_the_edge,
                this.Width,
                this.ItemBarLabel1.Location.Y +
                this.ItemBarLabel1.Height + NoInternetConnectionSandBox.from_the_edge);
        }
        #endregion
        //----------------------------------------------
        #region Ordinary Initialization for KingdomInfoSandBox(Centeral)
        private void Initialize_ForCenteralKingdom_Component()
        {
            this.Size = new Size(16 * (this.UnderForm.Width / 18),
                16 * (this.UnderForm.Height / 18));
            this.CenterToScreen();
            this.Opacity = 0.9;
            //----------------------------------
            //News:
            this.MyRes = new WotoRes(typeof(KingdomInfoSandBox));
            this.KingdomBackground = new GameControls.PictureBoxControl(this)
            {
                Father = this,
            };
            this.CancelButton = this.CloseLabel =
                new GameControls.CloseLabel(this, this);
            //----------------------------------
            //Names:
            this.KingdomBackground.SetPictureName(KingdomBGRuinedCityNameInRes);
            //TabIndexes
            //FontAndTextAligns:
            //Sizes:
            this.KingdomBackground.Size = this.Size;
            //Locations:
            this.CloseLabel.Location = new Point(Width - CloseLabel.Width -
                NoInternetConnectionSandBox.from_the_edge,
                NoInternetConnectionSandBox.from_the_edge);
            //Colors:
            this.KingdomBackground.SetColorTransparent();
            //ComboBoxes:
            //Enableds:
            //Texts:
            //AddRanges:
            //ToolTipSettings:
            //ImageSettings:
            this.KingdomBackground.SizeMode = PictureBoxSizeMode.StretchImage;
            this.KingdomBackground.SetPicture();
            //FinalBlow:
            this.RemoveMovingClicking();
            //----------------------------------
            //Events:

            //----------------------------------
            this.KingdomBackground.Controls.Add(this.CloseLabel);
            this.Controls.Add(this.KingdomBackground);
        }
        #endregion
        //----------------------------------------------
        #region Design for the Kingdom info in KingdomInfoSandBox
        private void DesingForInfo(bool firstTime = true)
        {
            if (firstTime)
            {

                //----------------------------------
                //News:
                this.KingdomBackground  = new GameControls.PictureBoxControl(this)
                {
                    Father = this,
                };
                this.MessageLabel1      = new GameControls.LabelControl(this);
                this.MessageLabel2      = new GameControls.LabelControl(this);
                this.MessageLabel3      = new GameControls.LabelControl(this);
                this.MessageLabel4      = new GameControls.LabelControl(this);
                this.InfoLabel          = 
                    new GameControls.InfoLabel(this, this, InfoLabels.KSKISBIL);
                //----------------------------------
                //Names:
                this.MessageLabel1.SetLabelName(KingdomNameLabelNameInRes);
                this.MessageLabel3.SetLabelName(KingdomLevelLabelNameInRes);
                this.InfoLabel.SetLabelName(InfoLabelNameInRes);
                //TabIndexes
                //FontAndTextAligns:
                this.MessageLabel1.Font = this.MessageLabel2.Font =
                    this.MessageLabel3.Font = this.MessageLabel4.Font =
                    new Font(ThereIsConstants.Forming.TheMainForm.PrivateFonts.Families[1],
                        21, FontStyle.Bold);
                this.MessageLabel1.TextAlign = this.MessageLabel2.TextAlign =
                    this.MessageLabel3.TextAlign = this.MessageLabel4.TextAlign =
                    this.ItemBarLabel1.TextAlign;
                //Sizes:
                this.KingdomBackground.Size = new Size(Width, Height -
                    ((24 * (this.Height / 180)) +
                    (2 * NoInternetConnectionSandBox.from_the_edge)));
                this.MessageLabel1.Size = MessageLabel2.Size =
                    MessageLabel3.Size = MessageLabel4.Size =
                    new Size(Width / 4, Height / 6);
                //Locations:
                this.KingdomBackground.Location =
                    new Point((Width / 2) - (KingdomBackground.Width / 2),
                    Height - KingdomBackground.Height);
                this.MessageLabel1.Location = new Point((Width / 2) -
                    MessageLabel1.Width, Height / 3);
                this.MessageLabel2.Location = new Point((Width / 2), Height / 3);
                this.MessageLabel3.Location = new Point(MessageLabel1.Location.X,
                    MessageLabel1.Location.Y +
                    MessageLabel1.Height);
                this.MessageLabel4.Location = new Point(MessageLabel2.Location.X,
                    MessageLabel2.Location.Y + MessageLabel2.Height);
                this.InfoLabel.Location =
                    new Point((this.Width / 2) - (InfoLabel.Width / 2),
                    MessageLabel3.Location.Y + MessageLabel3.Height +
                    (2 * NoInternetConnectionSandBox.from_the_edge));
                //Colors:
                this.KingdomBackground.SetColorTransparent();
                this.MessageLabel1.SetColorTransparent();
                this.MessageLabel2.SetColorTransparent();
                this.MessageLabel3.SetColorTransparent();
                this.MessageLabel4.SetColorTransparent();
                this.MessageLabel1.SetTextColor(Color.LightGoldenrodYellow);
                this.MessageLabel2.SetTextColor(Color.LightGoldenrodYellow);
                this.MessageLabel3.SetTextColor(Color.LightGoldenrodYellow);
                this.MessageLabel4.SetTextColor(Color.LightGoldenrodYellow);
                //ComboBoxes:
                //Enableds:
                //Texts:
                this.MessageLabel1.SetLabelText();
                this.MessageLabel2.SetLabelText("#" + KingdomInfo.Index.ToString() +
                    " " + KingdomInfo.KingdomName.GetValue());
                this.MessageLabel3.SetLabelText();
                this.MessageLabel4.SetLabelText(KingdomInfo.KingdomLevel.ToString());
                this.InfoLabel.MessageLabel1.SetLabelText();
                //AddRanges:
                //ToolTipSettings:
                //ImagesSettings:
                this.KingdomBackground.SizeMode = PictureBoxSizeMode.StretchImage;
                //----------------------------------
                //Events:
                this.KingdomBackground.Paint += KingdomInfoSandBoxDesignForInfo_Paint;
                this.InfoLabel.MessageLabel1.Click += EnterKingdom_Clicked;
                //----------------------------------
                this.KingdomBackground.Controls.AddRange(new Control[]
                {
                    this.MessageLabel1,
                    this.MessageLabel2,
                    this.MessageLabel3,
                    this.MessageLabel4,
                    this.InfoLabel,
                });
                this.Controls.AddRange(new Control[]
                {
                    this.KingdomBackground,
                });
                //----------------------------------
            }
            else
            {

                //----------------------------------
                //News:
                this.MessageLabel1 = new GameControls.LabelControl(this);
                this.MessageLabel2 = new GameControls.LabelControl(this);
                this.MessageLabel3 = new GameControls.LabelControl(this);
                this.MessageLabel4 = new GameControls.LabelControl(this);
                this.InfoLabel =
                    new GameControls.InfoLabel(this, this, InfoLabels.KSKISBIL);
                //----------------------------------
                //Names:
                this.MessageLabel1.SetLabelName(KingdomNameLabelNameInRes);
                this.MessageLabel3.SetLabelName(KingdomLevelLabelNameInRes);
                this.InfoLabel.SetLabelName(InfoLabelNameInRes);
                //TabIndexes
                //FontAndTextAligns:
                this.MessageLabel1.Font = this.MessageLabel2.Font =
                    this.MessageLabel3.Font = this.MessageLabel4.Font =
                    new Font(ThereIsConstants.Forming.TheMainForm.PrivateFonts.Families[1],
                        21, FontStyle.Bold);
                this.MessageLabel1.TextAlign = this.MessageLabel2.TextAlign =
                    this.MessageLabel3.TextAlign = this.MessageLabel4.TextAlign =
                    this.ItemBarLabel1.TextAlign;
                //Sizes:

                this.MessageLabel1.Size = MessageLabel2.Size =
                    MessageLabel3.Size = MessageLabel4.Size =
                    new Size(Width / 4, Height / 6);
                //Locations:

                this.MessageLabel1.Location = new Point((Width / 2) -
                    MessageLabel1.Width, Height / 3);
                this.MessageLabel2.Location = new Point((Width / 2), Height / 3);
                this.MessageLabel3.Location = new Point(MessageLabel1.Location.X,
                    MessageLabel1.Location.Y +
                    MessageLabel1.Height);
                this.MessageLabel4.Location = new Point(MessageLabel2.Location.X,
                    MessageLabel2.Location.Y + MessageLabel2.Height);
                this.InfoLabel.Location =
                    new Point((this.Width / 2) - (InfoLabel.Width / 2),
                    MessageLabel3.Location.Y + MessageLabel3.Height +
                    (2 * NoInternetConnectionSandBox.from_the_edge));
                //Colors:

                this.MessageLabel1.SetColorTransparent();
                this.MessageLabel2.SetColorTransparent();
                this.MessageLabel3.SetColorTransparent();
                this.MessageLabel4.SetColorTransparent();
                this.MessageLabel1.SetTextColor(Color.LightGoldenrodYellow);
                this.MessageLabel2.SetTextColor(Color.LightGoldenrodYellow);
                this.MessageLabel3.SetTextColor(Color.LightGoldenrodYellow);
                this.MessageLabel4.SetTextColor(Color.LightGoldenrodYellow);
                this.InfoLabel.MessageLabel1.SetLabelText();
                //ComboBoxes:
                //Enableds:
                //Texts:
                this.MessageLabel1.SetLabelText();
                this.MessageLabel2.SetLabelText("#" + KingdomInfo.Index.ToString() +
                    " " + KingdomInfo.KingdomName);
                this.MessageLabel3.SetLabelText();
                this.MessageLabel4.SetLabelText(KingdomInfo.KingdomLevel.ToString());
                //AddRanges:
                //ToolTipSettings:
                //ImagesSettings:
                this.KingdomBackground.SizeMode = PictureBoxSizeMode.StretchImage;
                //----------------------------------
                //Events:
                this.KingdomBackground.Paint += KingdomInfoSandBoxDesignForInfo_Paint;
                this.InfoLabel.MessageLabel1.Click += EnterKingdom_Clicked;
                //----------------------------------
                this.KingdomBackground.Controls.AddRange(new Control[]
                {
                    this.MessageLabel1,
                    this.MessageLabel2,
                    this.MessageLabel3,
                    this.MessageLabel4,
                    this.InfoLabel,
                });

                //----------------------------------
            }

        }

        private async void EnterKingdom_Clicked(object sender, EventArgs e)
        {
            //[-- ALi.w --]
            ThereIsConstants.Forming.GameClient.GameCurrentMusic.Stop();
            ThereIsConstants.Forming.GameClient.LoadingSandBox = new YuiLoadingSandbox(this);
            ThereIsConstants.Forming.GameClient.ShowingSandBox.
                    SetTheHighestSandBox(ThereIsConstants.Forming.GameClient.LoadingSandBox);
            ThereIsConstants.Forming.GameClient.LoadingSandBox.Location =
                    new Point((Screen.PrimaryScreen.Bounds.Size.Width / 2) -
                    (ThereIsConstants.Forming.GameClient.LoadingSandBox.Width / 2),
                    (Screen.PrimaryScreen.Bounds.Size.Height / 2) -
                    (ThereIsConstants.Forming.GameClient.LoadingSandBox.Height / 2));
            ThereIsConstants.Forming.GameClient.LoadingSandBox.FormClosed +=
                    ThereIsConstants.Forming.GameClient.LoadingSandBox_FormClosed;
            ThereIsConstants.Forming.GameClient.LoadingSandBox.Show();
            ThereIsConstants.Forming.GameClient.LoadingSandBox.TopMost = true;
            await ThereIsServer.GameObjects.MyProfile.ReloadMe();
            await ThereIsServer.GameObjects.MyProfile.ReloadPlayerInfo();
            if(ThereIsServer.GameObjects.MyProfile.PlayerHeroes == null)
            {
                ThereIsServer.GameObjects.MyProfile.PlayerHeroes =
                    await HeroManager.GetHeroManager();
                if(ThereIsServer.GameObjects.MyProfile.PlayerHeroes == null)
                {
                    NoInternetConnectionSandBox.PrepareConnectionClosedSandBox();
                }
            }
            else
            {
                await ThereIsServer.GameObjects.MyProfile.PlayerHeroes.ReloadHeroes();
            }
            ThereIsServer.GameObjects.MyProfile.SetPlayerStoryStep(StorySteps.TheFirstChurchStory);
            ThereIsServer.GameObjects.MyProfile.SetPlayerKingdom((SAO_Kingdoms)(KingdomInfo.Index));
            ThereIsServer.GameObjects.MyProfile.ResumePlayerPower();
            await ThereIsServer.GameObjects.MyProfile.PlayerHeroes.AddHero(
                Hero.GenerateHero(ThereIsServer.GameObjects.MyProfile.ThePlayerElement));
            await ThereIsServer.GameObjects.MyProfile.UpdatePlayerInfo();
            await ThereIsServer.GameObjects.MyProfile.UpdateMe();
            if (ThereIsConstants.Forming.GameClient.LoadingSandBox is YuiLoadingSandbox mySand)
            {
                mySand.Close(true);
            }
            ThereIsConstants.Forming.GameClient.DialogBoxProvider.CleaningUp();
            ThereIsConstants.Forming.GameClient.DialogBoxProvider = null;
            ThereIsConstants.Forming.GameClient.IsShowingDialogBox = false;
            this.Close(true);
            ThereIsConstants.Forming.GameClient.Controls.Clear();
            ThereIsConstants.Forming.GameClient.ShowFirstChurch();
        }

        private void KingdomInfoSandBoxDesignForInfo_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(new Pen(Color.FromArgb(220, Color.Gold), 4),
                MessageLabel1.Location.X + NoInternetConnectionSandBox.from_the_edge,
                MessageLabel1.Location.Y,
                MessageLabel2.Location.X + MessageLabel2.Width -
                NoInternetConnectionSandBox.from_the_edge,
                MessageLabel1.Location.Y);
            e.Graphics.DrawLine(new Pen(Color.FromArgb(220, Color.Gold), 4),
                MessageLabel2.Location.X + MessageLabel2.Width,
                MessageLabel2.Location.Y + NoInternetConnectionSandBox.from_the_edge,
                MessageLabel2.Location.X + MessageLabel2.Width,
                MessageLabel4.Location.Y + MessageLabel4.Height -
                NoInternetConnectionSandBox.from_the_edge);
            e.Graphics.DrawLine(new Pen(Color.FromArgb(220, Color.Gold), 4),
                MessageLabel3.Location.X + NoInternetConnectionSandBox.from_the_edge,
                MessageLabel3.Location.Y + MessageLabel3.Height,
                MessageLabel4.Location.X + MessageLabel4.Width -
                NoInternetConnectionSandBox.from_the_edge,
                MessageLabel4.Location.Y + MessageLabel4.Height);
            e.Graphics.DrawLine(new Pen(Color.FromArgb(220, Color.Gold), 4),
                MessageLabel3.Location.X,
                MessageLabel3.Location.Y + MessageLabel3.Height -
                NoInternetConnectionSandBox.from_the_edge,
                MessageLabel1.Location.X,
                MessageLabel1.Location.Y + NoInternetConnectionSandBox.from_the_edge);
            //-----------------
            e.Graphics.DrawArc(new Pen(Color.FromArgb(220, Color.Gold), 4),
                new Rectangle(
                    MessageLabel1.Location.X, MessageLabel1.Location.Y,
                    2 * NoInternetConnectionSandBox.from_the_edge,
                    2 * NoInternetConnectionSandBox.from_the_edge),
                180, 90);
            e.Graphics.DrawArc(new Pen(Color.FromArgb(220, Color.Gold), 4),
                new Rectangle(
                    MessageLabel2.Location.X + MessageLabel2.Width -
                    (2 * NoInternetConnectionSandBox.from_the_edge),
                    MessageLabel2.Location.Y,
                    2 * NoInternetConnectionSandBox.from_the_edge,
                    2 * NoInternetConnectionSandBox.from_the_edge),
                270, 90);
            e.Graphics.DrawArc(new Pen(Color.FromArgb(220, Color.Gold), 4),
                new Rectangle(
                    MessageLabel4.Location.X + MessageLabel4.Width -
                    (2 * NoInternetConnectionSandBox.from_the_edge),
                    MessageLabel4.Location.Y + MessageLabel4.Height -
                    (2 * NoInternetConnectionSandBox.from_the_edge),
                    2 * NoInternetConnectionSandBox.from_the_edge,
                    2 * NoInternetConnectionSandBox.from_the_edge), 
                0, 90);
            e.Graphics.DrawArc(new Pen(Color.FromArgb(220, Color.Gold), 4),
                new Rectangle(
                    MessageLabel3.Location.X,
                    MessageLabel3.Location.Y + MessageLabel3.Height -
                    (2 * NoInternetConnectionSandBox.from_the_edge),
                    2 * NoInternetConnectionSandBox.from_the_edge,
                    2 * NoInternetConnectionSandBox.from_the_edge),
                90, 90);
        }
        #endregion
        //----------------------------------------------
        #region Design for the kingdom Rankings
        private async void DesignForRankings()
        {

            //----------------------------------
            //News:
            this.MessageLabel1 = this.ActiveRankingLabel =
                new GameControls.RankingKindLabel(this, this, RankingsMode.PowerRankings)
                {
                    IsSelected = true,
                };
            this.MessageLabel2 =
                new GameControls.RankingKindLabel(this, this, RankingsMode.LevelRankings);
            this.MessageLabel3 = new GameControls.RankingBackGroundLabel(this, this,
                this.ActiveRankingLabel, this.KingdomInfo);
            //----------------------------------
            //Names:
            this.MessageLabel1.SetLabelName(KingdomInfoSandBoxLabel1NameInRes);
            this.MessageLabel2.SetLabelName(KingdomInfoSandBoxLabel2NameInRes);
            //TabIndexes
            this.MessageLabel1.CurrentStatus = 1;
            //FontAndTextAligns:
            this.MessageLabel1.Font = this.MessageLabel2.Font =
                new Font(ThereIsConstants.Forming.TheMainForm.PrivateFonts.Families[1],
                    21, FontStyle.Bold);
            //Sizes:

            //Locations:
            this.MessageLabel1.Location = 
                new Point(2 * NoInternetConnectionSandBox.from_the_edge, 
                KingdomBackground.Height / 3);
            this.MessageLabel2.Location = new Point(MessageLabel1.Location.X,
                MessageLabel1.Location.Y + MessageLabel1.Height +
                NoInternetConnectionSandBox.from_the_edge);
            this.MessageLabel3.Location = new Point(this.MessageLabel1.Location.X +
                MessageLabel1.Width + NoInternetConnectionSandBox.from_the_edge,
                NoInternetConnectionSandBox.from_the_edge);
            //Colors:

            //ComboBoxes:
            //Enableds:

            //Texts:
            this.MessageLabel1.SetLabelText();
            this.MessageLabel2.SetLabelText();


            //AddRanges:
            //ToolTipSettings:
            //ImagesSettings:
            //FinalBlow:
            await ReloadRankings();
            if(MessageLabel3 is GameControls.RankingBackGroundLabel rankingBack)
            {
                rankingBack.SetActiveRankingKind((GameControls.RankingKindLabel)this.MessageLabel1, true);
            }
            //----------------------------------
            //Events:
            this.MessageLabel1.AddClickEventToAllChild(ChangeRankingLabelKindWithClick);
            this.MessageLabel2.AddClickEventToAllChild(ChangeRankingLabelKindWithClick);
            //----------------------------------
            this.KingdomBackground.Controls.AddRange(new Control[]
            {
                this.MessageLabel1,
                this.MessageLabel2,
                this.MessageLabel3,
            });
            //----------------------------------

        }
        private async void ChangeRankingLabelKindWithClick(object sender, EventArgs e)
        {
            if(sender is GameControls.LabelControl label &&
                label.Parent is GameControls.RankingKindLabel rankingLabel &&
                this.MessageLabel3 is GameControls.RankingBackGroundLabel rankingBack)
            {
                await ReloadRankings(rankingLabel.RankingsMode);
                this.ActiveRankingLabel.IsSelected = false;
                this.ActiveRankingLabel = rankingLabel;
                this.ActiveRankingLabel.IsSelected = true;
                rankingBack.SetActiveRankingKind(rankingLabel);
                this.KingdomBackground.Invalidate();
            }
        }
        private async Task<bool> ReloadRankings()
        {
            this.IsShowingAnotherSandBox = true;
            this.ShowingAnotherSandBox =
                new YuiLoadingSandbox(this);
            this.ShowingAnotherSandBox.Show();
            this.KingdomInfo.Rankings =
                await KingdomRankings.GetKingdomRankings(this.KingdomInfo);
            this.ShowingAnotherSandBox.ClosedByMe = true;
            this.ShowingAnotherSandBox.Close();
            this.ShowingAnotherSandBox.Dispose();
            return true;
        }
        private async Task<bool> ReloadRankings(RankingsMode myMode)
        {
            switch (myMode)
            {
                case RankingsMode.PowerRankings:
                    this.IsShowingAnotherSandBox = true;
                    this.ShowingAnotherSandBox =
                        new YuiLoadingSandbox(this);
                    this.ShowingAnotherSandBox.Show();
                    this.KingdomInfo.Rankings.PowerRankings =
                        await PowerRankings.GetPowerRankings(this.KingdomInfo);
                    this.ShowingAnotherSandBox.ClosedByMe = true;
                    this.ShowingAnotherSandBox.Close();
                    this.ShowingAnotherSandBox.Dispose();
                    break;
                case RankingsMode.LevelRankings:
                    this.IsShowingAnotherSandBox = true;
                    this.ShowingAnotherSandBox =
                        new YuiLoadingSandbox(this);
                    this.ShowingAnotherSandBox.Show();
                    this.KingdomInfo.Rankings.LevelRankings =
                        await LevelRankings.GetLevelRankings(this.KingdomInfo);
                    this.ShowingAnotherSandBox.ClosedByMe = true;
                    this.ShowingAnotherSandBox.Close();
                    this.ShowingAnotherSandBox.Dispose();
                    break;
                default:
                    return false;
            }
            
            return true;
        }
        #endregion
        //----------------------------------------------
        #region Design for the kingdom Throne
        private async void DesignForThrones()
        {
            
            //----------------------------------
            //News:
            this.ThroneLabels = new GameControls.ThroneLabel[KingdomThrone.MAXIMUM_POSITION];
            for(int i = 0; i < KingdomThrone.MAXIMUM_POSITION; i++)
            {
                this.ThroneLabels[i] =
                    new GameControls.ThroneLabel(this, this, (ThronePositions)(i + 1));
            }
            //----------------------------------
            //Names:
            //TabIndexes

            //FontAndTextAligns:

            //Sizes:

            //Locations:
            this.ThroneLabels[0].Location = 
                new Point((this.KingdomBackground.Width / 2) -
                    this.ThroneLabels[0].Width -
                    (4 * NoInternetConnectionSandBox.from_the_edge), 
                    (this.KingdomBackground.Height / 3) - 
                    this.ThroneLabels[0].Height); // King

            this.ThroneLabels[1].Location =
                new Point((this.KingdomBackground.Width / 2) +
                    (4 * NoInternetConnectionSandBox.from_the_edge),
                    (this.KingdomBackground.Height / 3) -
                    this.ThroneLabels[1].Height); // Queen




            this.ThroneLabels[3].Location =
                new Point((Width / 2) - (ThroneLabels[3].Width / 2),
                (this.KingdomBackground.Height / 2) -
                ThroneLabels[2].Height / 2); // Minister Of Wealth

            this.ThroneLabels[2].Location =
                new Point(ThroneLabels[3].Location.X - 
                ThroneLabels[2].Width -
                (8 * NoInternetConnectionSandBox.from_the_edge),
                ThroneLabels[3].Location.Y); // Minister Of War

            this.ThroneLabels[4].Location =
                new Point(ThroneLabels[3].Location.X +
                ThroneLabels[3].Width +
                (8 * NoInternetConnectionSandBox.from_the_edge),
                (this.KingdomBackground.Height / 2) -
                ThroneLabels[4].Height / 2); // Minister Of Hierarch



            /*
            this.ThroneLabels[2].Location =
                new Point((this.KingdomBackground.Width / 3) -
                this.ThroneLabels[2].Width -
                (4 * NoInternetConnectionSandBox.from_the_edge),
                (this.KingdomBackground.Height / 2) -
                ThroneLabels[2].Height / 2); // Minister Of War

            this.ThroneLabels[3].Location =
                new Point((this.KingdomBackground.Width / 3) +
                (4 * NoInternetConnectionSandBox.from_the_edge),
                (this.KingdomBackground.Height / 2) -
                ThroneLabels[3].Height / 2); // Minister Of Wealth

            this.ThroneLabels[4].Location =
                new Point((2 * (this.KingdomBackground.Width / 3)) +
                (4 * NoInternetConnectionSandBox.from_the_edge),
                (this.KingdomBackground.Height / 2) -
                ThroneLabels[4].Height / 2); // Minister Of Hierarch

            */







            this.ThroneLabels[5].Location =
                new Point((this.KingdomBackground.Width / 2) -
                    this.ThroneLabels[5].Width -
                    (4 * NoInternetConnectionSandBox.from_the_edge),
                    (2 * (this.KingdomBackground.Height / 3))); // Guardians' Chief

            this.ThroneLabels[6].Location =
                new Point((this.KingdomBackground.Width / 2) +
                    (4 * NoInternetConnectionSandBox.from_the_edge),
                    (2 * (this.KingdomBackground.Height / 3))); // Clown
            //Colors:

            //ComboBoxes:
            //Enableds:

            //Texts:



            //AddRanges:
            //ToolTipSettings:
            //ImagesSettings:
            //FinalBlow:
            await ReloadThrone();
            //----------------------------------
            //Events:

            //----------------------------------
            this.KingdomBackground.Controls.AddRange(this.ThroneLabels);
            //----------------------------------

        }
        private async Task<bool> ReloadThrone()
        {
            this.IsShowingAnotherSandBox = true;
            this.ShowingAnotherSandBox =
                new YuiLoadingSandbox(this);
            this.ShowingAnotherSandBox.Show();
            this.KingdomInfo.Throne =
                    await KingdomThrone.GetKingdomThrone(this.KingdomInfo);
            foreach (GameControls.ThroneLabel throneLabel in this.ThroneLabels)
            {
                throneLabel.ReloadMe(this.KingdomInfo.Throne.GetPlayerInfo(throneLabel.ThronePosition));
            }
            this.ShowingAnotherSandBox.ClosedByMe = true;
            this.ShowingAnotherSandBox.Close();
            this.ShowingAnotherSandBox.Dispose();
            return true;
        }
        #endregion
        //----------------------------------------------
    }
}
