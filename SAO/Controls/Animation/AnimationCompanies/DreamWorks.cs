
namespace SAO.Controls.Animation.AnimationCompanies
{
    /// <summary>
    /// DreamWorks Animation Company Version 1.0.0.0
    /// Used for creating the Animation in the 
    /// <see cref="MainForm"/>.
    /// </summary>
    public sealed partial class DreamWorks : AnimationCompany
    {
        //-------------------------------------------------
        #region Constants Region
        public const string DefaultDreamWorksName       =
            "DreamWorks AnimationCompany -- wotoTeam Cop.";
        public const string AnimationFactoriesFirstName =
            "DreamWorks AnimationFactory Num ";
        public const float CloudMovesRate                = 0.3f; // 2 px
        public const int MAX_CLOUD                       = 7;
        public const int MIN_CLOUD                       = 3;
        #endregion
        //-------------------------------------------------
        #region Properties Region
        public bool DreamWorksInNight { get; private set; }
        #endregion
        //-------------------------------------------------
        #region Constructors Region
        /// <summary>
        /// Please do NOT use this constructor directly,
        /// please instead use 
        /// <see cref="AnimationCompany.GetAnimationCompany(AnimationCompaniesList)"/>.
        /// </summary>
        /// <param name="father"></param>
        public DreamWorks(GameControls.PageControl father, bool night = false) : base()
        {
            Father              = father;
            DreamWorksInNight   = night;
            InitializeComponent();
        }
        #endregion
        //-------------------------------------------------
    }
}
