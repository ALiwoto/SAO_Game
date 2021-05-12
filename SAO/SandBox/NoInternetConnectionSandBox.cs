using SAO.Controls;

namespace SAO.SandBox
{
    public partial class NoInternetConnectionSandBox : SandBoxBase
    {
        protected override SandBoxMode Mode { get; }
        public bool ClosedForRetry
        {
            get
            {
                return ClosedByMe;
            }
            set
            {
                ClosedByMe = value;
            }
        }
        //----------------------------------------------
        /// <summary>
        /// The First MessageLabel that shows the user: No Internet Connection.
        /// </summary>
        public GameControls.LabelControl MessageLabel1 { get; set; }
        /// <summary>
        /// The second MessageLabel that show the user: Check the Internet Connection and try again.
        /// </summary>
        public GameControls.LabelControl MessageLabel2 { get; set; }
        /// <summary>
        /// Exit Button in NoInternetConnection SandBox.
        /// </summary>
        public GameControls.ButtonControl ButtonControl1 { get; set; }
        /// <summary>
        /// Retry Button in NoInternetConnection SandBox.
        /// </summary>
        public GameControls.ButtonControl ButtonControl2 { get; set; }
        //--------------------------------------------
        /// <summary>
        /// The name of MessageLabel1 in the Resources without _name,
        /// <see cref="MessageLabel1"/>
        /// </summary>
        public const string SandBoxLabel1NameInRes = "SandBoxLabel1";
        /// <summary>
        /// The name of MessageLabel2 in the Resources without _name,
        /// <see cref="MessageLabel2"/>
        /// </summary>
        public const string SandBoxLabel2NameInRes = "SandBoxLabel2";
        /// <summary>
        /// The name of Button1 in the Resources without _name,
        /// <see cref="ButtonControl1"/>
        /// </summary>
        public const string SandBoxButton1NameInRes = "SandBoxButton1";
        /// <summary>
        /// The name of Button1 in the Resources without _name,
        /// <see cref="ButtonControl2"/>
        /// </summary>
        public const string SandBoxButton2NameInRes = "SandBoxButton2";
        /// <summary>
        /// The background Image key in the <see cref="SandBoxBase.MyRes"/>.
        /// </summary>
        public const string SandBoxBackGNameInRes = "BackGName";
        //-------------------------------------
        public NoInternetConnectionSandBox(GameControls.PageControl theUnderForm) :
            this(SandBoxMode.NoConnectionMode, theUnderForm)
        {
            ;
        }
        public NoInternetConnectionSandBox(SandBoxMode myMode,
            GameControls.PageControl theUnderForm) : base(theUnderForm)
        {
            Mode = myMode;
            ClosedForRetry = false;
            TopMost = true;
            switch (Mode)
            {
                case SandBoxMode.NoConnectionMode:
                    Initialize_NoConnection_Component();
                    break;
                case SandBoxMode.UserAlreadyExistMode:
                    Initialize_UserAlreadyExist_Component();
                    break;
                case SandBoxMode.UserNameOrPasswordWrongMode:
                    Initialize_UNOrPassWrong_Component();
                    break;
                case SandBoxMode.ConnectionClosedMode:
                    Initialize_ConnectionClosed_Component();
                    break;
                case SandBoxMode.Cant_LoadYourProfileMode:
                    Initialize_CantLoadYrProf_Component();
                    break;
                case SandBoxMode.LoggedOutSuccessfullyMode:
                    Initialize_LogedOutSuccessfully_Component();
                    break;
                case SandBoxMode.LogoutWarningMode:
                    Initialize_LogOutWarning_Component();
                    break;
                case SandBoxMode.CloseWarningMode:
                    Initialize_ClosingSandBox_Component();
                    break;
            }
            
        }
    }
}
