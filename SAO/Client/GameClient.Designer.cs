// Copyright (C) ALiwoto 2019 - 2020
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of the source code.

using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using SAO.SandBox;
using SAO.Controls;
using SAO.Constants;
using SAO.Controls.Music;
using SAO.GameObjects.Troops;
using SAO.GameObjects.Heroes;
using SAO.GameObjects.Chatting;
using SAO.GameObjects.Kingdoms;
using SAO.GameObjects.Resources;
using SAO.GameObjects.Characters;
using SAO.GameObjects.MapObjects;
using SAO.GameObjects.GameResources;
using SAO.GameObjects.ServerObjects;
using SAO.Controls.Elements.MapElements;

namespace SAO.Client
{
    partial class GameClient
    {
        //-------------------------------------------------
        #region Ordinary Region
        private void InitializeComponent()
        {
            this.KeyPreview = true;
            this.KeyDown += GameClient_KeyDown;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Size = Screen.PrimaryScreen.Bounds.Size;
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer
                | ControlStyles.UserPaint, true);
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.SetAutoSizeMode(AutoSizeMode.GrowAndShrink);
            this.KeyPreview = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.Black;
            this.Text = ThereIsConstants.Forming.TheMainForm.Text;
            //You should set this.BackGroundImage after...
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            //---------------------------------------------
            this.MyRes = new WotoRes(typeof(GameClient));
            this.GameCurrentMusic = new SoundPlayer(this, this);
            //---------------------------------------------
            //---------------------------------------------
            //
            //
            //
            //
            //Events:
            this.GotFocus += GameClient_GotFocus;
            this.FormClosed += GameClient_FormClosed;
            //---------------------------------------------
        }
        //---------------------------------------
        //---------------------------------------
        /// <summary>
        /// Don't call it from outside of <see cref="GameClient(bool)"/>
        /// </summary>
        private void GettingStarted()
        {
            this.BackColor = Color.Black;
            //----------------------------------
            //news:
            this.NerveGearPictureBoxControl = new GameControls.PictureBoxControl(this);
            this.MessageLabel1              = new GameControls.LabelControl(this);
            this.AnimationFactory           = new Trigger();
            //Names:
            this.NerveGearPictureBoxControl.SetPictureName(NerveGearFileNameInRes);
            this.MessageLabel1.SetLabelName(MessageLabel1NameInRes);
            //Set CurrentStatus:
            this.NerveGearPictureBoxControl.CurrentStatus   = 1;
            this.MessageLabel1.CurrentStatus                = 1;
            //TabIndexes:
            //FontsAndTextAligns:
            this.MessageLabel1.Font = new Font(PrivateFonts.Families[1]
                , 19, FontStyle.Bold);
            this.MessageLabel1.TextAlign = ContentAlignment.MiddleCenter;

            //Sizes:
            this.NerveGearPictureBoxControl.Size = new Size(this.Width / 5,
                this.Height / 3);
            this.MessageLabel1.Size = new Size(NerveGearPictureBoxControl.Width,
                this.Height / 6);
            //Locations:
            this.NerveGearPictureBoxControl.Location = new Point((this.Width / 2) -
                (NerveGearPictureBoxControl.Width / 2), (this.Height / 2) - 
                (NerveGearPictureBoxControl.Height / 2));
            this.MessageLabel1.Location = new Point(NerveGearPictureBoxControl.Location.X,
                NerveGearPictureBoxControl.Location.Y + NerveGearPictureBoxControl.Height +
                ThereIsConstants.AppSettings.Between_GameControls);
            //Colors:
            this.NerveGearPictureBoxControl.BackColor = Color.Transparent;
            this.MessageLabel1.SetColorTransparent();
            this.MessageLabel1.ForeColor = Color.White;
            //Images:
            this.NerveGearPictureBoxControl.SizeMode = PictureBoxSizeMode.StretchImage;
            this.NerveGearPictureBoxControl.SetPicture();
            //ComboBoxes:
            //Enableds:
            //Texts:
            this.MessageLabel1.SetLabelText();
            //AddRanges:
            //ToolTipSettings:
            //TimerSettings:
            this.AnimationFactory.Interval = 1000;
            this.AnimationFactory.Tick += ThereIsServer.Actions.TimeWorkerWorksForGameClientLoading;
            this.AnimationFactory.Enabled = true;
            //Events:


            //FinalBlow:
            Loading();
            //--------------------------------------
            this.Controls.AddRange(new Control[]
            {
                this.NerveGearPictureBoxControl,
                this.MessageLabel1
            });
        }
        //---------------------------------------
        private void GameClient_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.F10)
            {
                MessageBox.Show(Cursor.Position.X.ToString() + " " +
               Cursor.Position.Y.ToString());
                MessageBox.Show(this.Width.ToString() + " " + this.Height.ToString() + " ");
            }
            
        }

        private void GameClient_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.GameCurrentMusic.Stop();
            this.GameCurrentMusic.Dispose();
            ThereIsConstants.Forming.TheMainForm.Close();
        }

        private void GameClient_GotFocus(object sender, EventArgs e)
        {

            if (Focused)
            {
                if (IsShowingSandBox)
                {
                    if (!ShowingSandBox.Focused)
                    {
                        ShowingSandBox.Focus();
                    }
                }
            }
        }
        #endregion
        //-------------------------------------------------
        #region Home Designing Region
        private void DesignForHome(bool justLogin = true)
        {
            if (justLogin)
            {
                ; // nothing for now...
            }
            else
            {
                if (this.GameCurrentMusic != null) 
                {
                    this.GameCurrentMusic.Dispose();
                }
                if (this.BackgroundImage != null) 
                {
                    //this.BackgroundImage.Dispose(); Do NOT use .Dispose()
                    var image = this.BackgroundImage;
                    this.BackgroundImage = null;
                    image.Dispose();
                }
            }
            this.KeyPreview = true;
            //------------------------------------------------
            //-----------------------------
            //News:
            this.TheMap = Map.GenerateMap(this, MapMode.HomejunglenMap, true);
            this.TheMap.MapElements = new MapElement[]
            {
                    MapElement.GetMapElement(TheMap,
                    ElementsInMap.HomeJungleBack, TheMap,
                    false, ElementMovements.VerticalHorizontalMovements, HomeMapWorker, true),
                    MapElement.GetMapElement(TheMap,
                    ElementsInMap.MineInHomeJungle, TheMap,
                    false, ElementMovements.VerticalHorizontalMovements, HomeMapWorker),
                    MapElement.GetMapElement(TheMap,
                    ElementsInMap.FarmInHomeJungle, TheMap,
                    false, ElementMovements.VerticalHorizontalMovements, HomeMapWorker),
                    MapElement.GetMapElement(TheMap,
                    ElementsInMap.HouseInHomeJungle, TheMap,
                    false, ElementMovements.VerticalHorizontalMovements, HomeMapWorker),
                    MapElement.GetMapElement(TheMap,
                    ElementsInMap.GardenInHomeJungle, TheMap,
                    false, ElementMovements.VerticalHorizontalMovements, HomeMapWorker),
                    MapElement.GetMapElement(TheMap,
                    ElementsInMap.BoatInHomeJungle, TheMap,
                    false, ElementMovements.VerticalHorizontalMovements, HomeMapWorker),
            };
            this.HomeBarLabelControl = 
                new GameControls.HomeBarLabelControl(this, this, ProfileIcon_Click);
            this.ChatLabelControl = 
                GameControls.ChatLabelControl.GenerateChatLabel(this, this, 
                this.HomeBarLabelControl);
            //-----------------------------
            //Names:
            //TabIndexes:
            //FontsAndTextAligns:
            //Sizes:
            for(int i = 0; i < TheMap.MapElements.Length; i++)
            {
                this.TheMap.MapElements[i].SetElementSize();
            }
            //Locations:
            this.TheMap.MapElements[0].SetElementLocation(0, 0); // HomeJungle
            this.TheMap.MapElements[1].SetElementLocation(
                (int)(MapRates.RateOfMineInHomeX * Width),
                (int)(MapRates.RateOfMineInHomeY * Height));    // Mine in HomeJungle
            this.TheMap.MapElements[2].SetElementLocation(
                (int)(MapRates.RateOfFarmInHomeX * Width),
                (int)(MapRates.RateOfFarmInHomeY * Height));    // Farm in HomeJungle
            this.TheMap.MapElements[3].SetElementLocation(
                (int)(MapRates.RateOfHouseInHomeX * Width),
                (int)(MapRates.RateOfHouseInHomeY * Height));   // House in HomeJungle
            this.TheMap.MapElements[4].SetElementLocation(
                (int)(MapRates.RateOfGardenInHomeX * Width),
                (int)(MapRates.RateOfGardenInHomeY * Height));  // Garden in HomeJungle
            this.TheMap.MapElements[5].SetElementLocation(
                (int)(MapRates.RateOfBoatInHomeX * Width),
                (int)(MapRates.RateOfBoatInHomeY * Height));    // Boat in HomeJungle
            this.HomeBarLabelControl.Location = 
                new Point(0, this.Height - this.HomeBarLabelControl.Height);
            //Rectangles:
            //Colors:
            //ComboBoxes:
            //Enableds:

            //Texts:
            //AddRanges:
            //ToolTipSettings:
            //Events:
            this.KeyDown                                    -= HomeKeyManager_Down;
            this.KeyDown                                    -= HomeKeyManager;
            this.KeyUp                                      -= HomeKeyManager_Up;
            this.KeyDown                                    += HomeKeyManager_Down;
            this.KeyDown                                    += HomeKeyManager;
            this.KeyUp                                      += HomeKeyManager_Up;
            this.HomeBarLabelControl.SurfaceLabels[0].Click += MapIconInHomeBar_Click;
            this.HomeBarLabelControl.SurfaceLabels[1].Click += MapIconInHomeBar_Click;
            this.HomeBarLabelControl.SurfaceLabels[2].Click += MapIconInHomeBar_Click;
            this.HomeBarLabelControl.SurfaceLabels[3].Click += MapIconInHomeBar_Click;
            this.HomeBarLabelControl.SurfaceLabels[4].Click += MapIconInHomeBar_Click;
            this.HomeBarLabelControl.SurfaceLabels[5].Click += MapIconInHomeBar_Click;
            this.HomeBarLabelControl.SurfaceLabels[6].Click += MapIconInHomeBar_Click;
            //Final Blows:
            //---------------------------------------------
            this.TheMap.ApplyAllElements();
            this.Controls.AddRange(new Control[] 
            {
                this.HomeBarLabelControl,
            });
            this.HomeBarLabelControl.BringToFront();
            this.ChatLabelControl.ApplyChatIcon();
            //---------------------------------------------


        }

        private void MapIconInHomeBar_Click(object sender, EventArgs e)
        {
            if (sender is GameControls.LabelControl myLabel)
            {

                myLabel.HasMouseClickedOnce = false;
            }
        }
        private void ProfileIcon_Click(object sender, EventArgs e)
        {
            if(sender is GameControls.IconLabelControl myLabelControl)
            {
                // TODO: load player profile sandbox.



                myLabelControl.HasMouseClickedOnce = false;
            }
        }

        private void HomeKeyManager(object sender, KeyEventArgs e)
        {
            // check if there is chat frame on the screen or not.
            // in fact you will check if the chat frame applied or not.
            if (this.ChatLabelControl.IsChatFrameApplied)
            {
                // it means the chat frame is applied on the game client,
                // so you should not move the map.
                return;
            }
            // start the move manager (Trigger) of the current Map.
            this.TheMap.MoveManager.Start();
            switch (e.KeyCode)
            {
                case Keys.Left:
                {
                    if(TheMap.MapElements != null)
                    {
                        if(TheMap.MapElements[0] != null)
                        {
                            TheMap.MapElements[0].MoveMe(MapKeyMovingRate, 0);
                        }
                    }
                    break;
                }
                case Keys.Right:
                {
                    if (TheMap.MapElements != null)
                    {
                        if (TheMap.MapElements[0] != null)
                        {
                            TheMap.MapElements[0].MoveMe(-MapKeyMovingRate, 0);
                        }
                    }
                    break;
                }
                case Keys.Up:
                {
                    if (TheMap.MapElements != null)
                    {
                        if (TheMap.MapElements[0] != null)
                        {
                            TheMap.MapElements[0].MoveMe(0, MapKeyMovingRate);
                        }
                    }
                    break;
                }
                case Keys.Down:
                {
                    if (TheMap.MapElements != null)
                    {
                        if (TheMap.MapElements[0] != null)
                        {
                            TheMap.MapElements[0].MoveMe(0, -MapKeyMovingRate);
                        }
                    }
                    break;

                }


            }
            TheMap.MoveManager.Stop();
        }
        private void HomeKeyManager_Down(object sender, KeyEventArgs e)
        {
            // check if there is chat frame on the screen or not.
            // in fact you will check if the chat frame applied or not.
            if (this.ChatLabelControl.IsChatFrameApplied)
            {
                // it means the chat frame is applied on the game client,
                // so you should not move the map.
                return;
            }
            this.KeyDown -= HomeKeyManager_Down;
            this.TheMap.RemoveSurfaces();
        }
        private void HomeKeyManager_Up(object sender, KeyEventArgs e)
        {
            this.KeyDown -= HomeKeyManager_Down;
            this.KeyDown -= HomeKeyManager;
            this.KeyDown += HomeKeyManager_Down;
            this.KeyDown += HomeKeyManager;
            this.TheMap.AddSurfaces();
        }
        private void HomeMapWorker(object sender, EventArgs e)
        {
            if (!this.ChatLabelControl.IsChatFrameApplied)
            {
                return;
            }
            else
            {
                this.ChatLabelControl.RemoveChatFrame();
            }
        }


        #endregion
        //-------------------------------------------------
        #region FirstTime Designing Region
        private async void DesignForFirstTime()
        {
            this.BackColor = Color.Black;
            //---------------------------------------------------
            this.GameCurrentMusic.Next(Album.GenerateAlbum(
                wotoMusic.GenerateWotoMusic(Musics.FirstGameEnterMusic)), true);
            //this.GameCurrentMusic.PlayLooping();
            //-----------------------------------------------------
            await Task.Delay(100);
            await Task.Run(() =>
            {
                this.LoadMapWorld();
            });
            await Task.Delay(500);
            this.IsShowingSandBox = true;
            this.ShowingSandBox = new FirstStoryLineSandBox(this, true);
            this.Focus();
            this.TopMost = true;
            this.ShowingSandBox.MyHallSandBox.Focus();
            this.ShowingSandBox.MyHallSandBox.TopMost = true;
            this.ShowingSandBox.Hide();
            
        }
        private void LoadMapWorld()
        {
            this.BackgroundImage = Image.FromFile(ThereIsConstants.Path.Datas_Path + "\\" +
                MyRes.GetString(GreatWorldMapFileNameInRes));
        }
        #endregion
        //-------------------------------------------------
        #region Loading Region
        private void Loading()
        {
            IsLoading       = true;
            IsLoadingEnded  = false;
            //--------------------------------------------
            Timer DataLoadingTimer = new Timer();
            DataLoadingTimer.Interval   = 10;
            DataLoadingTimer.Tick       += PlayerTroopsLoadingTimerWorker;
            DataLoadingTimer.Enabled    = true;
            //-------------------------------------------
            Timer PlayerMagicalTroopsLoadingTimer = new Timer();
            PlayerMagicalTroopsLoadingTimer.Interval = 10;
            PlayerMagicalTroopsLoadingTimer.Tick += PlayerMagicalTroopsLoadingTimer_Tick;
            PlayerMagicalTroopsLoadingTimer.Enabled = true;
            //-------------------------------------------
            Timer PlayerResourcesLoadingTimer = new Timer();
            PlayerResourcesLoadingTimer.Interval = 10;
            PlayerResourcesLoadingTimer.Tick += PlayerResourcesLoadingTimer_Tick;
            PlayerResourcesLoadingTimer.Enabled = true;
            //-------------------------------------------
            //-------------------------------------------
            Timer PlayerHeroesLoadingTimer = new Timer();
            PlayerHeroesLoadingTimer.Interval = 10;
            PlayerHeroesLoadingTimer.Tick += PlayerHeroesLoadingTimer_Tick;
            PlayerHeroesLoadingTimer.Enabled = true;
            //-------------------------------------------
            //-------------------------------------------
            //-------------------------------------------
        }

        private async void PlayerHeroesLoadingTimer_Tick(object sender, EventArgs e)
        {
            //--------------------
            ((Timer)sender).Enabled = false;
            ((Timer)sender).Dispose();
            //--------------------
            ThereIsServer.GameObjects.MyProfile.PlayerHeroes =
                await HeroManager.GetHeroManager();
            //MessageBox.Show("4");
            //--------------------
            this.IsLoadingEnded4 = true;
        }

        private async void PlayerResourcesLoadingTimer_Tick(object sender, EventArgs e)
        {
            //--------------------
            ((Timer)sender).Enabled = false;
            ((Timer)sender).Dispose();
            //--------------------
            ThereIsServer.GameObjects.MyProfile.PlayerResources =
                await PlayerResources.LoadPlayerResources();

            //MessageBox.Show("3");

            //--------------------
            this.IsLoadingEnded3 = true;
        }

        private async void PlayerMagicalTroopsLoadingTimer_Tick(object sender, EventArgs e)
        {
            //--------------------
            ((Timer)sender).Enabled = false;
            ((Timer)sender).Dispose();
            //--------------------
            ThereIsServer.GameObjects.MyProfile.PlayerMagicalTroops =
                await MagicalTroop.LoadPlayerMagicalTroop();
            //MessageBox.Show("2");

            //--------------------
            this.IsLoadingEnded2 = true;

        }

        private async void PlayerTroopsLoadingTimerWorker(object sender, EventArgs e)
        {
            //--------------------
            ((Timer)sender).Enabled = false;
            ((Timer)sender).Dispose();
            //--------------------
            ThereIsServer.GameObjects.MyProfile.PlayerTroops = 
                await TroopManager.LoadTroopManager();


            //--------------------
            this.IsLoadingEnded1 = true;
        }
        public void LoadingSandBox_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (sender is YuiLoadingSandbox mySand)
            {
                if (mySand.ClosedByMe)
                {
                    ;
                }
                else
                {
                    this.Close();
                }
            }
        }
        #endregion
        //-------------------------------------------------
        #region Showing Region
        #region Koji Empire The First Entering
        /// <summary>
        /// The first time which player logged int.
        /// </summary>
        public void ShowKojiEmpire()
        {
            if(this.AnimationFactory == null)
            {
                this.AnimationFactory = new Trigger();
            }
            this.AnimationFactory.Tag = 1;
            this.AnimationFactory.Tick += AnimationFactory_ShowKojiEmpire_Tick;
            this.AnimationFactory.Interval = 60;
            this.AnimationFactory.Enabled = true;
            this.Paint += ShowKojiEmpireInMap_Paint;
        }

        private void ShowKojiEmpireInMap_Paint(object sender, PaintEventArgs e)
        {
            if (AnimationFactory != null)
            {
                if (AnimationFactory.Tag != null)
                {
                    //MessageBox.Show("HERE_END");
                    int myInt = 18 * (int)AnimationFactory.Tag;
                    e.Graphics.DrawArc(new Pen(Color.DarkRed, 9),
                        (float)(MapRates.RateOfKojiX * Width),
                        (float)(MapRates.RateOfKojiY * Height),
                        Width / 6,
                        Width / 6,
                        0, myInt);
                }
            }
        }
        private void AnimationFactory_ShowKojiEmpire_Tick(object sender, EventArgs e)
        {
            this.AnimationFactory.Tag = ((int)(this.AnimationFactory.Tag)) + 1;
            if (((int)(this.AnimationFactory.Tag)) == 20)
            {
                ((Timer)sender).Enabled = false;
                DialogContext myCon = new DialogContext(Dialogs.Dialog1_1_1);
                this.IsShowingDialogBox = true;
                this.DialogBoxProvider = new DialogBoxProvider(this.Controls, ref myCon);
                DialogBoxProvider.AfterDialogEndedEvent += ShowKojiEmpire_AfterDialogEndedEvent;
                DialogBoxProvider.SettingUpDialogWorks();
            }
            this.Invalidate();

        }

        private void ShowKojiEmpire_AfterDialogEndedEvent(object sender, EventArgs e)
        {
            //Setting the Click Event.
            this.Click += KojiEmpireClicked;
        }
        private void KojiEmpireClicked(object sender, EventArgs e)
        {
            if (Cursor.Position.X >= (float)(MapRates.RateOfKojiX * Width) &&
                Cursor.Position.X <= (float)(MapRates.RateOfKojiX * Width) + (Width / 6))
            {
                if (Cursor.Position.Y >= (float)(MapRates.RateOfKojiY * Height) &&
                    Cursor.Position.Y <= (float)(MapRates.RateOfKojiY * Height) + (Width / 6))
                {
                    this.Click -= KojiEmpireClicked;
                    this.DialogBoxProvider.CleaningUp();
                    this.IsShowingDialogBox = false;
                    this.DialogBoxProvider = null;
                    ShowKojiTerritory();
                }
            }

        }
        #endregion
        //-------------------------------------------------
        #region ElementSelection Showing Region
        /// <summary>
        /// Showing the Element selecting Hall.
        /// </summary>
        public void ShowKojiTerritory()
        {
            this.Paint -= ShowKojiEmpireInMap_Paint;
            this.BackgroundImage = Image.FromFile(ThereIsConstants.Path.Datas_Path + "\\" +
                MyRes.GetString(KojiMapFileNameInRes));
            this.ShowingSandBox = new FirstStoryLineSandBox(this, true, SandBoxMode.ElementSelectionMode);
            this.IsShowingDialogBox = false;
            this.IsShowingSandBox = true;
            this.Focus();
            this.TopMost = true;
            this.ShowingSandBox.MyHallSandBox.Focus();
            this.ShowingSandBox.MyHallSandBox.TopMost = true;
            this.ShowingSandBox.Hide();
        }
        #endregion
        //-------------------------------------------------
        #region KingdomSelection Region
        /// <summary>
        /// Use this method when player has already selected his 
        /// Element and he wants to select the kingdom or he just
        /// logged in to the game and you want him
        /// to select the Kingdom.
        /// </summary>
        public void ShowKojiTerritoryIn(bool justLogin = false)
        {
            if (justLogin)
            {
                //---------------------------------------------------
                this.GameCurrentMusic.Next(Album.GenerateAlbum(new wotoMusic[]
                    {
                        wotoMusic.GenerateWotoMusic(Musics.FirstGameEnterMusic),
                    }), true);
                //this.GameCurrentMusic.PlayLooping();
                this.BackgroundImage = Image.FromFile(ThereIsConstants.Path.Datas_Path + "\\" +
                    MyRes.GetString(KojiMapFileNameInRes));
                //-----------------------------------------------------
            }
            DialogContext myCon = new DialogContext(Dialogs.Dialog1_1_3);
            this.IsShowingDialogBox = true;
            this.DialogBoxProvider = new DialogBoxProvider(this.Controls, ref myCon);
            this.DialogBoxProvider.AfterDialogEndedEvent += ShowKingdoms_AfterDialogEndedEvent;
            this.DialogBoxProvider.SettingUpDialogWorks();
            //------------------------------------------------
            //-----------------------------
            //News:
            this.TheMap = Map.GenerateMap(this, MapMode.KojiKingdoms, false);
            this.TheMap.MapSigners = new GameControls.MapSigner[]
            {
                new GameControls.MapSigner(this),
                new GameControls.MapSigner(this),
                new GameControls.MapSigner(this),
                new GameControls.MapSigner(this),
                new GameControls.MapSigner(this)
                {
                    CurrentStatus = 2,
                },
            };
            this.TheMap.MapElements = new MapElement[]
            {
                MapElement.GetMapElement(TheMap,
                    CharacterInfo.GetCharacterInfo(GameCharacters.Dark_Lord, 1), TheMap),    // E1
                MapElement.GetMapElement(TheMap, ElementsInMap.Ruined_House1, TheMap, false),       // E2

                MapElement.GetMapElement(TheMap, ElementsInMap.CastleInKojiEmpire1, TheMap, false), // E3
                MapElement.GetMapElement(TheMap, ElementsInMap.Village_House1, TheMap, false),      // E4
                MapElement.GetMapElement(TheMap, ElementsInMap.Village_House1, TheMap, false),      // E5

                MapElement.GetMapElement(TheMap, ElementsInMap.CastleInKojiEmpire2, TheMap, false), // E6
                MapElement.GetMapElement(TheMap, ElementsInMap.Village_House1, TheMap, false),      // E7
                MapElement.GetMapElement(TheMap, ElementsInMap.Village_House1, TheMap, false),      // E8

                MapElement.GetMapElement(TheMap, ElementsInMap.CastleInKojiEmpire3, TheMap, false), // E9
                MapElement.GetMapElement(TheMap, ElementsInMap.Village_House1, TheMap, false),      // E10
                MapElement.GetMapElement(TheMap, ElementsInMap.Village_House1, TheMap, false),      // E11

                MapElement.GetMapElement(TheMap, ElementsInMap.CastleInKojiEmpire4, TheMap, false), // E12
                MapElement.GetMapElement(TheMap, ElementsInMap.Village_House1, TheMap, false),      // E13
                MapElement.GetMapElement(TheMap, ElementsInMap.Village_House1, TheMap, false),      // E14
            };
            this.TheMap.MapElements[0].GenerateFakeSurface();
            this.TheMap.AdvancedMapElements = new GameControls.MapElement[]
            {
                GameControls.MapElement.GetMapElement(TheMap, ElementsInMap.Fire1),
            };
            //-----------------------------
            //Names:
            this.TheMap.MapSigners[0].SetLabelName(MessageLabel1NameInRes);
            this.TheMap.MapSigners[1].SetLabelName(MessageLabel2NameInRes);
            this.TheMap.MapSigners[2].SetLabelName(MessageLabel3NameInRes);
            this.TheMap.MapSigners[3].SetLabelName(MessageLabel4NameInRes);
            this.TheMap.MapSigners[4].SetLabelName(MessageLabel4NameInRes);
            //TabIndexes:
            this.TheMap.MapSigners[0].CurrentStatus = 1; // North
            this.TheMap.MapSigners[1].CurrentStatus = 2; // South
            this.TheMap.MapSigners[2].CurrentStatus = 3; // West
            this.TheMap.MapSigners[3].CurrentStatus = 4; // East
            this.TheMap.MapSigners[4].CurrentStatus = 5; // Central Kingdom
            //FontsAndTextAligns:
            //Sizes:
            this.TheMap.MapSigners[4].Size =
                new Size(TheMap.MapSigners[4].Width / 2,
                TheMap.MapSigners[4].Height / 2);

            this.TheMap.MapElements[0].SetElementSize( 
                new SizeF(this.Width / 10, this.Height / 9)); // This is Dark-Lord.
            this.TheMap.MapElements[0].SurfaceControl.Size =
                Size.Round(TheMap.MapElements[0].ElementSizeF);
            this.TheMap.AdvancedMapElements[0].Size = 
                new Size(this.Width / 10, this.Height / 20); // This is fire.
            SizeF size = new SizeF(this.Width / 30, this.Height / 24);
            for (int i = 1; i < TheMap.MapElements.Length; i++)
            {
                this.TheMap.MapElements[i].SetElementSize(size);
            }
            //Locations:
            this.TheMap.MapSigners[0].Location = 
                new Point((int)(Width * MapRates.RateOfNorthKingdomX), 
                (int)(Height * MapRates.RateOfNorthKingdomY));          // North
            this.TheMap.MapSigners[1].Location = 
                new Point((int)(Width * MapRates.RateOfSouthKingdomX), 
                (int)(Height * MapRates.RateOfSouthKingdomY));          // South
            this.TheMap.MapSigners[2].Location =
                new Point((int)(Width * MapRates.RateOfWestKingdomX),
                (int)(Height * MapRates.RateOfWestKingdomY));           // West
            this.TheMap.MapSigners[3].Location = 
                new Point((int)(Width * MapRates.RateOfEastKingdomX),
                (int)(Height * MapRates.RateOfEastKingdomY));           // East


            this.TheMap.MapElements[0].SetElementLocation(
                new PointF((float)(this.Width * MapRates.RateOfDarkLordCKX), 
                (float)(this.Height * MapRates.RateOfDarkLordCKY))); // E1
            this.TheMap.MapElements[0].SurfaceControl.Location =
                Point.Round(this.TheMap.MapElements[0].ElementLocationF);
            this.TheMap.MapSigners[4].Location =
                new Point((int)(TheMap.MapElements[0].ElementLocationF.X + 
                    (TheMap.MapElements[0].Width / 2) -
                    (TheMap.MapSigners[4].Width / 2)),
                    (int)(TheMap.MapElements[0].ElementLocationF.Y +
                    TheMap.MapElements[0].Height));
            this.TheMap.AdvancedMapElements[0].Location =
                new Point((((int)TheMap.MapElements[0].Width / 2) -
                    (TheMap.AdvancedMapElements[0].Width / 2)),
                ((int)TheMap.MapElements[0].Height -
                (int)TheMap.AdvancedMapElements[0].Height)); // Fire should be added to the dark-Lord.
            this.TheMap.MapElements[1].SetElementLocation( // E2
                TheMap.MapElements[0].ElementLocationF.X -
                (TheMap.MapElements[1].Width / 2),
                TheMap.MapElements[0].ElementLocationF.Y +
                (TheMap.MapElements[0].Height / 2)); // E2 -- end



            this.TheMap.MapElements[2].SetElementLocation(
                TheMap.MapSigners[0].Location.X -
                (TheMap.MapElements[2].Width / 2),
                TheMap.MapSigners[0].Location.Y +
                (TheMap.MapSigners[0].Height / 2)); // E3
            this.TheMap.MapElements[3].SetElementLocation(
                TheMap.MapElements[2].ElementLocationF.X -
                (TheMap.MapElements[3].Width / 2),
                TheMap.MapElements[2].ElementLocationF.Y +
                (TheMap.MapElements[2].Height / 2)); // E4
            this.TheMap.MapElements[4].SetElementLocation(
                TheMap.MapElements[2].ElementLocationF.X +
                (TheMap.MapElements[2].Width / 2), 
                TheMap.MapElements[2].ElementLocationF.Y +
                (TheMap.MapElements[2].Height / 2)); // E5

            this.TheMap.MapElements[5].SetElementLocation(
                TheMap.MapSigners[2].Location.X -
                (TheMap.MapElements[5].Width / 2),
                TheMap.MapSigners[2].Location.Y +
                (TheMap.MapSigners[2].Height / 2)); // E6
            this.TheMap.MapElements[6].SetElementLocation(
                TheMap.MapElements[5].ElementLocationF.X -
                (TheMap.MapElements[6].Width / 2),
                TheMap.MapElements[5].ElementLocationF.Y +
                (TheMap.MapElements[5].Height / 2)); // E7
            this.TheMap.MapElements[7].SetElementLocation(
                TheMap.MapElements[5].ElementLocationF.X +
                (TheMap.MapElements[7].Width / 2),
                TheMap.MapElements[5].ElementLocationF.Y +
                (TheMap.MapElements[5].Height / 2)); // E8

            this.TheMap.MapElements[8].SetElementLocation(
                TheMap.MapSigners[1].Location.X -
                (TheMap.MapElements[8].Width / 2),
                TheMap.MapSigners[1].Location.Y +
                (TheMap.MapSigners[1].Height / 2)); // E9
            this.TheMap.MapElements[9].SetElementLocation(
                TheMap.MapElements[8].ElementLocationF.X -
                (TheMap.MapElements[9].Width / 2),
                TheMap.MapElements[8].ElementLocationF.Y +
                (TheMap.MapElements[8].Height / 2)); // E10
            this.TheMap.MapElements[10].SetElementLocation(
                TheMap.MapElements[8].ElementLocationF.X +
                (TheMap.MapElements[10].Width / 2),
                TheMap.MapElements[8].ElementLocationF.Y +
                (TheMap.MapElements[8].Height / 2)); // E11

            this.TheMap.MapElements[11].SetElementLocation(
                TheMap.MapSigners[3].Location.X -
                (TheMap.MapElements[11].Width / 2),
                TheMap.MapSigners[3].Location.Y +
                (TheMap.MapSigners[3].Height / 2)); // E12
            this.TheMap.MapElements[12].SetElementLocation(
                TheMap.MapElements[11].ElementLocationF.X -
                (TheMap.MapElements[12].Width / 2),
                TheMap.MapElements[11].ElementLocationF.Y +
                (TheMap.MapElements[11].Height / 2));  // E13
            this.TheMap.MapElements[13].SetElementLocation(
                TheMap.MapElements[11].ElementLocationF.X +
                (TheMap.MapElements[13].Width / 2),
                TheMap.MapElements[11].ElementLocationF.Y +
                (TheMap.MapElements[11].Height / 2));
            

            //Rectangles:
            //Colors:
            this.TheMap.MapSigners[0].ForeColor =
            this.TheMap.MapSigners[1].ForeColor =
            this.TheMap.MapSigners[2].ForeColor =
            this.TheMap.MapSigners[3].ForeColor = Color.GhostWhite;
            this.TheMap.MapSigners[4].ForeColor = Color.Black;
            //ComboBoxes:
            //Enableds:
            //Texts:
            //AddRanges:
            //ToolTipSettings:
            //Events:
            //Final Blows:
            this.TheMap.MapSigners[4].ReLoadUPW();
            //-----------------------------
            this.TheMap.MapElements[0].SurfaceControl.Controls.Add(
                this.TheMap.AdvancedMapElements[0]);
            //this.TheMap.MapElements[0].Controls.Add(TheMap.MapElements[1]); // Fire to dark-lord.
            this.Controls.AddRange(new Control[]
            {
                this.TheMap.MapElements[0].SurfaceControl,
                this.TheMap.MapSigners[0],
                this.TheMap.MapSigners[1],
                this.TheMap.MapSigners[2],
                this.TheMap.MapSigners[3],
                this.TheMap.MapSigners[4],

                //this.TheMap.MapElements[2], // Village House of North
                //this.TheMap.MapElements[3], // Village House of South
                //this.TheMap.MapElements[4], // Village House of West
                //this.TheMap.MapElements[5], // Village House of East
            });
            this.TheMap.ApplyAllElements();
            //Cursor.Position = this.TheMap.MapElements[0].SurfaceControl.Location;
        }
        private void ShowKingdoms_AfterDialogEndedEvent(object sender, EventArgs e)
        {
            this.TheMap.MapSigners[0].HasMouseClickedOnce =
            this.TheMap.MapSigners[1].HasMouseClickedOnce =
            this.TheMap.MapSigners[2].HasMouseClickedOnce =
            this.TheMap.MapSigners[3].HasMouseClickedOnce = 
            this.TheMap.MapSigners[4].HasMouseClickedOnce =
                false;
            this.TheMap.MapSigners[0].Click += KingdomMapSigner_Click;
            this.TheMap.MapSigners[1].Click += KingdomMapSigner_Click;
            this.TheMap.MapSigners[2].Click += KingdomMapSigner_Click;
            this.TheMap.MapSigners[3].Click += KingdomMapSigner_Click;
            this.TheMap.MapSigners[4].Click += ShowCenteralKingdomInfo;

        }
        private async void KingdomMapSigner_Click(object sender, EventArgs e)
        {
            if(sender is GameControls.MapSigner mySigner)
            {
                if(TheMap.MapDisplayer != null)
                {
                    TheMap.MapDisplayer.Dispose();
                    TheMap.MapDisplayer = null;
                }
                this.ShowingSandBox = this.LoadingSandBox = new YuiLoadingSandbox(this);
                this.LoadingSandBox.Show();
                this.IsShowingSandBox = true;
                TheMap.MapDisplayer =
                mySigner.MapDisplayer = new GameControls.MapSigner(this,
                    mySigner.CurrentStatus, GameControls.LabelControlSpecies.MapDisplayer);
                mySigner.MapDisplayer.CurrentStatus = mySigner.CurrentStatus;
                mySigner.MapDisplayer.Location = new Point(mySigner.Location.X +
                    (mySigner.Width / 2) - (mySigner.MapDisplayer.Width / 2),
                    mySigner.Location.Y - mySigner.MapDisplayer.Height -
                    (NoInternetConnectionSandBox.from_the_edge / 4));
                ThereIsServer.GameObjects.MyProfile.KingdomInfo =
                    await KingdomInfo.GetKingdomInfo(mySigner.MapDisplayer.CurrentStatus);
                this.LoadingSandBox.Close(true);
                this.ShowingSandBox = this.LoadingSandBox = null;
                this.IsShowingSandBox = false;
                mySigner.MapDisplayer.MessageLabel2.Text +=
                    ThereIsServer.GameObjects.MyProfile.KingdomInfo.KingdomName.GetValue();
                mySigner.MapDisplayer.MessageLabel1.AddClickEventToAllChild(KingdomMapSignerInfoLabel_Click);
                this.Controls.Add(mySigner.MapDisplayer);
                mySigner.HasMouseClickedOnce = false;
            }
            else
            {
                throw new Exception();
            }
        }
        private void ShowCenteralKingdomInfo(object sender, EventArgs e)
        {
            if (sender is GameControls.MapSigner mySigner)
            {
                this.IsShowingSandBox = true;
                KingdomInfoSandBox mySand =
                    new KingdomInfoSandBox(this);
                this.ShowingSandBox = mySand;
                this.ShowingSandBox.TopLevel = true;
                //MessageBox.Show(test.KingdomInfo.KingdomName);
                this.ShowingSandBox.Show();
                this.ShowingSandBox.Focus();
                mySigner.HasMouseClickedOnce = false;
            }
                
        }
        private void KingdomMapSignerInfoLabel_Click(object sender, EventArgs e)
        {

            this.IsShowingSandBox = true;
            KingdomInfoSandBox mySand = 
                new KingdomInfoSandBox(this,
                ThereIsServer.GameObjects.MyProfile.KingdomInfo);
            this.ShowingSandBox = mySand;
            this.ShowingSandBox.TopMost = true;
            //MessageBox.Show(test.KingdomInfo.KingdomName);
            this.ShowingSandBox.Show();
            this.ShowingSandBox.Focus();
            if(sender is GameControls.LabelControl labelControl)
            {
                labelControl.HasMouseClickedOnce = false;
                mySand.KingdomBackground.Image = 
                    ((GameControls.PictureBoxControl)labelControl.Parent.Parent).Image;
            }
        }
        #endregion
        //-------------------------------------------------
        #region TheFirstChurch Showing Design Region
        /// <summary>
        /// Use this method when player has already selected his 
        /// Kingdom and he wants to See The Part: discussion In The Church
        /// or he just
        /// logged in to the game and you want him
        /// to See The Part: discussion In The Church.
        /// </summary>
        /// <param name="justLogin"></param>
        public void ShowFirstChurch(bool justLogin = false)
        {
            if (justLogin)
            {
                this.GameCurrentMusic.Next(Album.GenerateAlbum(
                    wotoMusic.GenerateWotoMusic(Musics.FirstChurchMusic)
                ), true);
                //this.GameCurrentMusic.PlayLooping();
                this.BackgroundImage = Image.FromFile(ThereIsConstants.Path.Datas_Path + "\\" +
                    MyRes.GetString(FirstChurchBGMFileNameInRes));
            }
            else
            {
                this.TheMap.DisposeAllElements();
                this.GameCurrentMusic.Next(Album.GenerateAlbum(
                    wotoMusic.GenerateWotoMusic(Musics.FirstChurchMusic)), true);
                //this.GameCurrentMusic.PlayLooping();
                this.BackgroundImage = Image.FromFile(ThereIsConstants.Path.Datas_Path + "\\" +
                    MyRes.GetString(FirstChurchBGMFileNameInRes));
            }
            DialogContext myCon = new DialogContext(Dialogs.Dialog1_1_4);
            this.IsShowingDialogBox = true;
            this.DialogBoxProvider = new DialogBoxProvider(this.Controls, ref myCon);
            this.DialogBoxProvider.AfterDialogEndedEvent += FirstChurch_AfterDialogEndedEvent;
            this.DialogBoxProvider.SettingUpDialogWorks();



        }

        private void FirstChurch_AfterDialogEndedEvent(object sender, EventArgs e)
        {
            this.Click -= EnterHomeClick;
            this.Click += EnterHomeClick;
        }

        private async void EnterHomeClick(object sender, EventArgs e)
        {
            this.ShowingSandBox = this.LoadingSandBox = new YuiLoadingSandbox(this);
            this.LoadingSandBox.Show();
            this.IsShowingSandBox = true;
            this.Click -= EnterHomeClick;

            await ThereIsServer.GameObjects.MyProfile.ReloadMe();
            ThereIsServer.GameObjects.MyProfile.SetPlayerStoryStep(StorySteps.SeeYourHomeForFirstTimeStory);
            await ThereIsServer.GameObjects.MyProfile.UpdateMe();

            this.LoadingSandBox.Close(true);
            this.ShowingSandBox = this.LoadingSandBox = null;
            this.IsShowingSandBox = false;


            this.DialogBoxProvider.CleaningUp();
            ShowFirstHome();




        }



        #endregion
        //-------------------------------------------------
        #region SeeTheHomeForFirstTime Region
        public void ShowFirstHome(bool justLogin = false)
        {
            DesignForHome(justLogin);


            // also setting up some dialog...
        }

        #endregion
        #endregion
        //-------------------------------------------------
        #region Protected Region
        protected override void OnMouseClick(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (TheMap != null)
                {
                    if (TheMap.MapDisplayer != null)
                    {
                        TheMap.MapDisplayer.Dispose();
                        TheMap.MapDisplayer = null;
                    }
                }
            }
            base.OnMouseClick(e);
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            Application.Exit();
        }
        #endregion
        //-------------------------------------------------
    }
}
