// Copyright (C) ALiwoto 2019 - 2020
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of the source code.

using SAO.Controls;
using SAO.Constants;
using SAO.GameObjects.Kingdoms;
namespace SAO.SandBox
{
#pragma warning disable IDE0055
    public sealed partial class KingdomInfoSandBox : SandBoxBase
    {
        //--------------------------------------------------
        #region Constants Region
        public const string ItemBar1NameInRes                   = "ItemBar1";
        public const string ItemBar2NameInRes                   = "ItemBar2";
        public const string ItemBar3NameInRes                   = "ItemBar3";
        public const string InfoLabelNameInRes                  = "EnteringInfoLabel";
        public const string KingdomNameLabelNameInRes           = "KingdomNameLabel";
        public const string KingdomLevelLabelNameInRes          = "KingdomLevelLabel";
        public const string KingdomInfoSandBoxLabel1NameInRes   = "KISLabel1";
        public const string KingdomInfoSandBoxLabel2NameInRes   = "KISLabel2";
        public const string KingdomInfoSandBoxLabel3NameInRes   = "KISLabel3";
        public const string TitleRankingML1NameInRes            = "TitleRankingML1";
        public const string TitleRankingML2NameInRes            = "TitleRankingML2";
        public const string TitleRankingML3NameInRes            = "TitleRankingML3";
        public const string TitleRankingML4NameInRes            = "TitleRankingML4";
        public const string KingdomBGRuinedCityNameInRes        = "RuinedCity1";
        #endregion
        //--------------------------------------------------
        #region Properties Region
        /// <summary>
        /// ItemBarLabel1 which says: Info
        /// </summary>
        public GameControls.ItemBarLabelControl ItemBarLabel1 { get; private set; }
        /// <summary>
        /// ItemBarLabel1 which says: Rankings
        /// </summary>
        public GameControls.ItemBarLabelControl ItemBarLabel2 { get; private set; }
        /// <summary>
        /// ItemBarLabel1 which says: Throne
        /// </summary>
        public GameControls.ItemBarLabelControl ItemBarLabel3 { get; private set; }
        /// <summary>
        /// The Current and Active ItemBar.
        /// </summary>
        public GameControls.ItemBarLabelControl ActiveItemBar { get; private set; }
        /// <summary>
        /// this is for closing, so, <see cref="GameControls.LabelControlSpecies"/> in the
        /// <see cref="GameControls.LabelControl.LabelControl(IRes, GameControls.LabelControlSpecies, SandBoxBase, bool)"/>
        /// should be <see cref="GameControls.LabelControlSpecies.CloseLabel"/>
        /// </summary>
        public GameControls.CloseLabel CloseLabel { get; private set; }
        public GameControls.LabelControl MessageLabel1 { get; private set; }
        public GameControls.LabelControl MessageLabel2 { get; private set; }
        public GameControls.LabelControl MessageLabel3 { get; private set; }
        public GameControls.LabelControl MessageLabel4 { get; private set; }
        public GameControls.ThroneLabel[] ThroneLabels { get; private set; }
        public GameControls.InfoLabel InfoLabel { get; private set; }
        /// <summary>
        /// The Kingdom Background Picture.
        /// </summary>
        public GameControls.PictureBoxControl KingdomBackground { get; private set; }


        /// <summary>
        /// When we are in the ItemBar Ranking, you should set this.
        /// </summary>
        public GameControls.RankingKindLabel ActiveRankingLabel { get; set; }
        //--------------------------------------------------
        public KingdomInfo KingdomInfo { get; set; }
        //--------------------------------------------------
        /// <summary>
        /// If this KingdomInfoSandBox, is preview,
        /// then that means player has not yet selected his Kingdom.
        /// </summary>
        public bool IsPreview { get; set; }

        #endregion
        //--------------------------------------------------
        #region Constructors Region
        /// <summary>
        /// Create new instance of this KingdomInfoSandBox.
        /// </summary>
        /// <param name="myBackPage">
        /// it is either <see cref="ThereIsConstants.Forming.GameClient"/>,
        /// or ..
        /// </param>
        /// <param name="IsPreview"></param>
        public KingdomInfoSandBox(GameControls.PageControl myBackPage, 
            KingdomInfo myKingdomInfo,
            bool isPreview = true):
            base(myBackPage)
        {
            Mode        = SandBoxMode.KingdomInfoMode;
            IsPreview   = isPreview;
            KingdomInfo = myKingdomInfo;
            InitializeComponent();
            
        }
        /// <summary>
        /// Please use this constructor if and only if you want to
        /// display the centeral kingdom with ruined city.
        /// in fact, I will display a ruined Kingdom.
        /// thanks from 
        /// <c> #SADRAartworks,
        /// </c> 
        /// for his works.
        /// </summary>
        /// <param name="myBackPage"></param>
        /// <param name="isPreview"></param>
        public KingdomInfoSandBox(GameControls.PageControl myBackPage, 
            bool isPreview = true) : base(myBackPage)
        {
            Mode = SandBoxMode.KingdomInfoMode;
            IsPreview = isPreview;
            Initialize_ForCenteralKingdom_Component();
        }
        #endregion
        //--------------------------------------------------
        #region Overrided Properties Region
        protected override SandBoxMode Mode { get; }
        #endregion
    }
#pragma warning restore IDE0055
}
