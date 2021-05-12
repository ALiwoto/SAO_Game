// Copyright (C) ALiwoto 2019 - 2020
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of the source code.

using System;
using System.Drawing.Text;
using System.ComponentModel;
using System.Runtime.InteropServices;
using SAO.SandBox;
using SAO.Controls;
using SAO.Constants;
using SAO.Controls.Music;
using SAO.GameObjects.Troops;
using SAO.GameObjects.Heroes;
using SAO.GameObjects.Resources;
using SAO.GameObjects.Characters;
using SAO.GameObjects.MapObjects;
using SAO.GameObjects.ServerObjects;
using SAO.GameObjects.GameResources;

namespace SAO.Client
{
    [Browsable(true)]
    [ComVisible(true)]
    public partial class GameClient : GameControls.PageControl, IRes
    {
        //------------------------------------------------
        #region Constant's Region
        public const string GreatWorldMapFileNameInRes  = "GreatWorldMapFile_Name";
        public const string KojiMapFileNameInRes        = "KojiMapFile_Name";
        public const string FirstChurchBGMFileNameInRes = "FirstChurchBGMFile_Name";
        /// <summary>
        /// The _Name will set with the PictureBoxControl function.
        /// <see cref="GameControls.PictureBoxControl.SetPictureName(string)"/>
        /// </summary>
        public const string NerveGearFileNameInRes      = "NerveGearFile";
        public const string MessageLabel1NameInRes      = "GameClientLabel1";
        public const string MessageLabel2NameInRes      = "GameClientLabel2";
        public const string MessageLabel3NameInRes      = "GameClientLabel3";
        public const string MessageLabel4NameInRes      = "GameClientLabel4";
        public const int MapKeyMovingRate               = 25; // 5px
        #endregion
        //-------------------------------------------------
        #region Properties Region
        /// <summary>
        /// MyRes of the GameClient...
        /// </summary>
        public WotoRes MyRes { get; set; }
        public SoundPlayer GameCurrentMusic { get; set; }
        public SandBoxBase ShowingSandBox { get; set; }
        public SandBoxBase LoadingSandBox { get; set; }
        public PrivateFontCollection PrivateFonts { get; set; }
        public Trigger AnimationFactory { get; set; }
        /// <summary>
        /// NerveGear gif in the <see cref="GettingStarted()"/>
        /// </summary>
        public GameControls.PictureBoxControl NerveGearPictureBoxControl { get; set; }
        /// <summary>
        /// Loding Label in the <see cref="GettingStarted()"/>.
        /// and North Kingdom setted in: <see cref="ShowKojiTerritoryIn(bool)"/>
        /// </summary>
        public GameControls.LabelControl MessageLabel1 { get; set; }
        /// <summary>
        /// South Kingdom setted in: <see cref="ShowKojiTerritoryIn(bool)"/>
        /// </summary>
        public GameControls.LabelControl MessageLabel2 { get; set; }
        /// <summary>
        /// West Kingdom setted in: <see cref="ShowKojiTerritoryIn(bool)"/>
        /// </summary>
        public GameControls.LabelControl MessageLabel3 { get; set; }
        /// <summary>
        /// East Kingdom setted in: <see cref="ShowKojiTerritoryIn(bool)"/>
        /// </summary>
        public GameControls.LabelControl MessageLabel4 { get; set; }
        public GameControls.LabelControl[] GameSurfaceControls { get; private set; }
        public GameControls.HomeBarLabelControl HomeBarLabelControl { get; set; }
        public GameControls.ChatLabelControl ChatLabelControl { get; set; }
        public DialogBoxProvider DialogBoxProvider { get; set; }
        public Map TheMap { get; set; }
        //-------------------------------------------------
        public bool IsFirstTime { get; set; }
        public bool IsShowingSandBox { get; set; }
        public bool IsShowingDialogBox { get; set; }
        public bool IsLoading { get; set; }
        public bool IsLoadingEnded
        {
            get
            {
                return 
                    IsLoadingEnded1 && 
                    IsLoadingEnded2 && 
                    IsLoadingEnded3 &&
                    IsLoadingEnded4;
            }
            set
            {
                IsLoadingEnded1 = 
                IsLoadingEnded2 = 
                IsLoadingEnded3 =
                IsLoadingEnded4 =

                    value;
            }
        }
        /// <summary>
        /// for 
        /// <see cref="Player.PlayerTroops"/> in
        /// <see cref="PlayerTroopsLoadingTimerWorker(object, EventArgs)"/> with
        /// <see cref="Troop.LoadPlayerTroops()"/>
        /// </summary>
        public bool IsLoadingEnded1 { get; set; }
        /// <summary>
        /// for 
        /// <see cref="Player.PlayerMagicalTroops"/> in
        /// <see cref="PlayerMagicalTroopsLoadingTimer_Tick(object, EventArgs)"/> with
        /// <see cref="MagicalTroop.LoadPlayerMagicalTroop()"/>
        /// </summary>
        public bool IsLoadingEnded2 { get; set; }
        /// <summary>
        /// for 
        /// <see cref="Player.PlayerResources"/> in
        /// <see cref="PlayerResourcesLoadingTimer_Tick(object, EventArgs)"/> with
        /// <see cref="PlayerResources.LoadPlayerResources()"/>
        /// </summary>
        public bool IsLoadingEnded3 { get; set; }
        /// <summary>
        /// for 
        /// <see cref="Player.PlayerHeroes"/> in
        /// <see cref="PlayerHeroesLoadingTimer_Tick(object, EventArgs)"/> with
        /// <see cref="Hero.LoadPlayerHeroes()"/>
        /// </summary>
        public bool IsLoadingEnded4 { get; set; }
        #endregion
        //-------------------------------------------------
        #region Constructor's Region
        /// <summary>
        /// Constructor of the Game Client.
        /// </summary>
        /// <param name="TheFirstTime"></param>
        public GameClient(bool TheFirstTime)
        {
            IsFirstTime = TheFirstTime;
            PrivateFonts =
                ThereIsConstants.Forming.TheMainForm.PrivateFonts;
            InitializeComponent();
            if (!TheFirstTime)
            {
                GettingStarted();
            }
        }
        #endregion
        //------------------------------------------------
        #region Ordinary Method's Region
        /// <summary>
        /// Showing the NerveGear Gif while we are loading the 
        /// some Player info which are not loaded whe Yui loading sandBox was on.
        /// </summary>
        public void FirstTimeDesigning()
        {
            DesignForFirstTime();
        }
        public void GameClientHandler()
        {
            switch (ThereIsServer.GameObjects.MyProfile.StoryStep)
            {
                case StorySteps.TheFirstShowingWithBookStory: // When the player should see the book and select the Koji Empire and also the Element
                    Controls.Clear();
                    NerveGearPictureBoxControl.Dispose();
                    MessageLabel1.Dispose();
                    FirstTimeDesigning();
                    break;
                case StorySteps.KingdomSelectionStory: // When the player Already selected its Element but not Kingdom yet.
                    Controls.Clear();
                    NerveGearPictureBoxControl.Dispose();
                    MessageLabel1.Dispose();
                    ShowKojiTerritoryIn(true);
                    break;
                case StorySteps.TheFirstChurchStory: // When the player Already selected its Kingdom, thus we should show him The Church
                    Controls.Clear();
                    NerveGearPictureBoxControl.Dispose();
                    MessageLabel1.Dispose();
                    ShowFirstChurch(true);
                    break;
                case StorySteps.SeeYourHomeForFirstTimeStory: // When the player already passed the discussion in the church
                    Controls.Clear();
                    NerveGearPictureBoxControl.Dispose();
                    MessageLabel1.Dispose();
                    ShowFirstHome(true);
                    break;

                default:
                    break;
            }
        }
        #endregion
        //------------------------------------------------
    }
}
