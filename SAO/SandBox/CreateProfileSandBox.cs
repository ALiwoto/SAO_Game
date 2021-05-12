// Copyright (C) ALiwoto 2019 - 2020
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of the source code.

using System;
using System.Drawing;
using System.Windows.Forms;
using SAO.Controls;
using SAO.LoadingService;
using SAO.GameObjects.Players;
using SAO.GameObjects.ServerObjects;

namespace SAO.SandBox
{
    public sealed partial class CreateProfileSandBox : SandBoxBase, IAnimationFactory
    {

        protected override SandBoxMode Mode { get; }
        //-------------------------------------
        /// <summary>
        /// The First MessageLabel that shows the user: Create New Profile.
        /// Or : Sign in to your Profile.
        /// </summary>
        public GameControls.LabelControl MessageLabel1 { get; set; }
        /// <summary>
        /// The second MessageLabel that show the user: username:
        /// </summary>
        public GameControls.LabelControl MessageLabel2 { get; set; }
        /// <summary>
        /// The second MessageLabel that show the user: password:
        /// </summary>
        public GameControls.LabelControl MessageLabel3 { get; set; }
        /// <summary>
        /// The fourth MessageLabel that shows Rewrite password.
        /// </summary>
        public GameControls.LabelControl MessageLabel4 { get; set; }
        /// <summary>
        /// The fifth MessageLabel that shows the user: or sign in to your profile ...
        /// </summary>
        public GameControls.LabelControl MessageLabel5 { get; set; }
        public GameControls.CloseLabel CloseLabel { get; set; }
        /// <summary>
        /// The First TextBox for username Entry.
        /// </summary>
        public GameControls.TextBoxControl TextBox1 { get; set; }
        /// <summary>
        /// The second TextBox for password Entry.
        /// </summary>
        public GameControls.TextBoxControl TextBox2 { get; set; }
        /// <summary>
        /// The third TextBox for rewriting the password.
        /// </summary>
        public GameControls.TextBoxControl TextBox3 { get; set; }
        /// <summary>
        /// cancel Button in CreateProfile SandBox.
        /// </summary>
        public GameControls.ButtonControl ButtonControl1 { get; set; }
        /// <summary>
        /// confirm Button in CreateProfile SandBox.
        /// </summary>
        public GameControls.ButtonControl ButtonControl2 { get; set; }
        /*

        /// <summary>
        /// Close PictureBox in the LinkStart Mode.
        /// </summary>
        public GameControls.PictureBoxControl PictureBoxControl1 { get; set; }
        /// <summary>
        /// LinkStart PictureBox in the LinkStart Mode :|
        /// </summary>
        public GameControls.PictureBoxControl PictureBoxControl2 { get; set; }

        */
        //------------------------------------------
        public Trigger AnimationFactory { get; set; }
        public int CurrentNum { get; set; }
        public const int MAXIMUM_TICK = 0x2D0;
        //------------------------------------------
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
        public bool IsCheckingForExisting { get; set; }
        public bool IsCheckingForExistingEnded { get; set; }
        public bool DoesPlayerExists { get; set; }
        public bool IsCreatingMode { get; set; }
        public bool IsSignInMode { get; set; }
        public bool IsLinkStartMode { get; set; }
        public bool IsWaitingForCreating { get; set; }
        public bool IsWaitingForSignIn{ get; set; }
        public bool IsCreatingEnded
        {
            get
            {
                return IsCreatingEnded1 && 
                    IsCreatingEnded2 && 
                    IsCreatingEnded3 &&
                    IsCreatingEnded4 &&
                    IsCreatingEnded5 &&
                    IsCreatingEnded6 &&
                    IsCreatingEnded7 
                    ;
            }
            set
            {
                IsCreatingEnded1 = 
                    IsCreatingEnded2 = 
                    IsCreatingEnded3 =
                    IsCreatingEnded4 =
                    IsCreatingEnded5 =
                    IsCreatingEnded6 =
                    IsCreatingEnded7 =
                    value;
            }
        }
        /// <summary>
        /// Use this for <see cref="Me.CreateProfileInfoTimer_Tick(object, EventArgs)"/>,
        /// Which is for <see cref="PlayerInfo"/>'s Information saving.
        /// </summary>
        public bool IsCreatingEnded1 { get; set; }
        /// <summary>
        /// Use this for <see cref="Me.CreateMeTimer_Tick(object, EventArgs)"/>,
        /// Which is for <see cref="Me"/>'s Information saving.
        /// </summary>
        public bool IsCreatingEnded2 { get; set; }
        /// <summary>
        /// Use this for <see cref="Me.Create_Player_Timer_Tick(object, EventArgs)(object, EventArgs)"/>,
        /// Which is for <see cref="Player"/>'s Information saving,
        /// in the <see cref="Player.EndFileName_Player"/>
        /// </summary>
        public bool IsCreatingEnded3 { get; set; }
        public bool IsCreatingEnded4 { get; set; }
        public bool IsCreatingEnded5 { get; set; }
        public bool IsCreatingEnded6 { get; set; }
        public bool IsCreatingEnded7 { get; set; }
        /// <summary>
        /// use this property to detemine wheter all the 
        /// IsSignIn parameters are true or not.
        /// in the constructor, this will be false.
        /// </summary>
        public bool IsSignInEnded
        {
            get
            {
                return IsSignInEnded1 && IsSignInEnded2 && IsSignInEnded3 && IsSignInEnded4;
            }
            set
            {
                IsSignInEnded1 = IsSignInEnded2 = IsSignInEnded3 = IsSignInEnded4 =
                    value;
            }
        }
        /// <summary>
        /// use in: <see cref="Me.LoadPlayerInfoTimer_Tick(object, EventArgs)"/>,
        /// for loading the <see cref="PlayerInfo"/>'s information.
        /// </summary>
        public bool IsSignInEnded1 { get; set; }
        /// <summary>
        /// use in : <see cref="Me.LoadMeTimer_Tick(object, EventArgs)"/>,
        /// for loading the <see cref="Me"/>'s information.
        /// </summary>
        public bool IsSignInEnded2 { get; set; }
        /// <summary>
        /// use in : <see cref="Me.Load_Player_Timer_Tick(object, EventArgs)"/>,
        /// for loading the <see cref="Player"/>'s information.
        /// </summary>
        public bool IsSignInEnded3 { get; set; }
        /// <summary>
        /// use in : <see cref="Me.TokenObj_Timer_Tick(object, EventArgs)"/>,
        /// for Preparing the <see cref="ThereIsServer.ServerSettings.TokenObj"/>'s information.
        /// </summary>
        public bool IsSignInEnded4 { get; set; }
        public bool UseAnimation { get; set; }
        public bool HasLoggedOut { get; set; }
        //------------------------------------------
        //------------------------------------------
        /// <summary>
        /// Yiu Loading SandBox with Yui Loading Gif :||| <code></code>
        /// Don't Tell Me Why :"
        /// </summary>
        public YuiLoadingSandbox LoadingSandBox { get; set; }
        /// <summary>
        /// The Profile Info which is necessary for Link Start Mode.
        /// </summary>
        public ProfileInfo ProfileInf { get; set; }
        //-------------------------------------------
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
        /// The name of MessageLabel3 in the Resources without _name,
        /// <see cref="MessageLabel3"/>
        /// </summary>
        public const string SandBoxLabel3NameInRes = "SandBoxLabel3";
        /// <summary>
        /// The name of MessageLabel4 in the Resources without _name,
        /// <see cref="MessageLabel4"/>
        /// </summary>
        public const string SandBoxLabel4NameInRes = "SandBoxLabel4";
        /// <summary>
        /// The name of MessageLabel5 in the Resources without _name,
        /// <see cref="MessageLabel5"/>
        /// </summary>
        public const string SandBoxLabel5NameInRes = "SandBoxLabel5";
        /// <summary>
        /// The name of Button1 in the Resources without _name,
        /// <see cref="ButtonControl1"/>
        /// </summary>
        public const string SandBoxButton1NameInRes = "SandBoxButton1";
        /// <summary>
        /// The name of Button1 in the Resources without _name,
        /// <see cref="ButtonControl1"/>
        /// </summary>
        public const string SandBoxButton2NameInRes = "SandBoxButton2";
        /// <summary>
        /// The Background Key name in the Res.
        /// </summary>
        public const string TheBackGroundNameInRes = "TheBackG_Name";
        //-------------------------------------------
        /// <summary>
        /// consider this constructor will prepare the <see cref="IsCreatingMode"/>
        /// or <see cref="IsSignInMode"/>, so the user can sign up or sign in.
        /// </summary>
        /// <param name="theUnderForm"></param>
        public CreateProfileSandBox(GameControls.PageControl theUnderForm, 
            bool useAnimation = false) : base(theUnderForm)
        {
            IsCheckingForExisting       = false;
            IsCheckingForExistingEnded  = false;
            DoesPlayerExists            = false;
            IsCreatingMode              = true;
            IsSignInMode                = false;
            IsWaitingForCreating        = false;
            IsWaitingForSignIn          = false;
            IsCreatingEnded             = false;
            IsSignInEnded               = false;
            UseAnimation                = useAnimation;
            InitializeComponent();
        }
        /// <summary>
        /// Consider this constructor will Load the pri-data of the profile (Link Start)
        /// </summary>
        /// <param name="theUnderForm"></param>
        /// <param name="theAccInfo"></param>
        public CreateProfileSandBox(GameControls.PageControl theUnderForm, ProfileInfo theProfInfo,
            bool useAnimation = false) : base(theUnderForm)
        {
            IsCheckingForExisting       = false;
            IsCheckingForExistingEnded  = false;
            DoesPlayerExists            = false;
            IsCreatingMode              = false;
            IsSignInMode                = false;
            IsLinkStartMode             = true;
            IsWaitingForCreating        = false;
            IsWaitingForSignIn          = false;
            IsCreatingEnded             = false;
            IsSignInEnded               = false;
            HasLoggedOut                = false;
            ProfileInf                  = theProfInfo;
            UseAnimation                = useAnimation;
            Initialize_LinkStart();
            //------------------------------------------------
            
        }
        public void CallMe(bool AfterSecuredWorkingOver = false)
        {
            if (!AfterSecuredWorkingOver)
            {
                //This part should run shortly after appearance of the SandBox
                //And should prepare the yui sandbox and checking for existance and etc..
                IsCheckingForExisting = true;
                //bool result = false;
                Me theMe = new Me(ProfileInf.UserName, ProfileInf.TheToken);
                ThereIsServer.ServerSettings.MyProfile = theMe;
                IsShowingAnotherSandBox = true;
                LoadingSandBox = new YuiLoadingSandbox(this);
                LoadingSandBox.Location = new Point((Screen.PrimaryScreen.Bounds.Size.Width / 2) -
                    (LoadingSandBox.Width / 2), (Screen.PrimaryScreen.Bounds.Size.Height / 2) -
                    (LoadingSandBox.Height / 2));
                LoadingSandBox.FormClosed += LoadingSandBox_FormClosed;
                LoadingSandBox.Show();
            }
            else
            {
                //However, this part should run when the secured working has ended already...
                //And should be called in the thereIsServer class
                IsSignInEnded = false;
                //Texts:
                MessageLabel1.SetLabelText(ProfileInf.UserName);
                TextBox1.SetTextBoxText(ProfileInf.LastLogin);
                //Events:
                MessageLabel4.AddClickEventToAllChild(ButtonControl2_Click);
            }
            
        }

    }
}
