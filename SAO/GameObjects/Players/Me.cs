using System;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Diagnostics.CodeAnalysis;
using SAO.SandBox;
using SAO.Security;
using SAO.Constants;
using SAO.GameObjects.Math;
using SAO.GameObjects.Troops;
using SAO.GameObjects.Heroes;
using SAO.GameObjects.Guilds;
using SAO.GameObjects.Kingdoms;
using SAO.GameObjects.Chatting;
using SAO.GameObjects.Characters;
using SAO.GameObjects.ServerObjects;
using SAO.GameObjects.GameResources;

namespace SAO.GameObjects.Players
{
    /// <summary>
    /// Notice:
    /// In the creating part, you should create all the info, such as
    /// <see cref="Troop"/> for <see cref="Player.PlayerTroops"/>,
    /// <see cref="PlayerResources"/> for <see cref="Player.PlayerResources"/>,
    /// <see cref="Village"/> for <see cref="Player.PlayerVillages"/>, etc...<code></code>
    /// but <see cref="Hero"/> for <see cref="Player.PlayerHeroes"/>,
    /// should be created with <see cref="Hero.CreatePlayerHeroes(Hero[])"/>,
    /// right after the Element selecting of Tohsaka.
    /// </summary>
    [SuppressMessage("Code Quality", "IDE0067:Dispose objects before losing scope", Justification = "<Pending>")]
    [SuppressMessage("Style", "IDE0017:Simplify object initialization", Justification = "<Pending>")]
    public partial class Me : Player
    {
        //-----------------------------------------------------------
        #region Constants Region
        /// <summary>
        /// Use this one for object <see cref="Me"/>,
        /// There is another constant like this, 
        /// check: <see cref="PlayerInfo.FileEndName"/>,
        /// that is for just the PlayerInfo Information.
        /// </summary>
        public const string FileEndName2    = "_これはミです";
        public const int PlayerLvlParamCal1 = 10;
        public const int PlayerLvlParamCal2 = 2;
        public const int PlayerLvlParamCal3 = 4;
        #endregion
        //-----------------------------------------------------------
        #region Offline Properties Region
        /// <summary>
        /// Notice: Do NOT save it to the server,
        /// and also do NOT load it from the server ME,
        /// you should load it with <see cref="PlayerInfo.PlayerKingdom"/>,
        /// look: <see cref="KingdomInfo.GetKingdomInfo(uint)"/>.
        /// </summary>
        public KingdomInfo KingdomInfo { get; set; }
        //---------------------------------------
        //---------------------------------------
        public bool HasLogin { get; set; }
        public bool HasAccExist { get; set; }
        public bool IsWaitingForSecuredWorking { get; set; }
        public bool IsSecuredMeWorkingOver { get; set; }
        public bool CreatingAcc { get; set; }
        public bool SignInAcc { get; set; }
        public bool LinkStart { get; set; }
        public bool IsOnSecondStepOfLinkStart { get; set; }
        //---------------------------------------
        public string Username { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        #endregion
        //-----------------------------------------------------------
        #region Servering Properties Region
        /// <summary>
        /// This one should be loaded from the server. <code></code>
        /// The Code is: 0.
        /// </summary>
        public StorySteps StoryStep { get; private set; } = StorySteps.TheFirstShowingWithBookStory;
        /// <summary>
        /// The Player's Avatar Frame List. <code></code>
        /// The Code is: 1.
        /// </summary>
        public AvatarFrameList AvatarFrameList { get; private set; }
        /// <summary>
        /// The Special Avatars which user allowed to use. <code></code>
        /// The Code is: 2.
        /// </summary>
        public AvatarList AvatarList { get; private set; }
        /// <summary>
        /// The list of the blocked player which are blocked by me. XD <code></code>
        /// The Code is: 3.
        /// </summary>
        public ChatBlockList MyBlockList { get; private set; }
        #endregion
        //-----------------------------------------------------------
        #region Constructor Region
        /// <summary>
        /// preparing the loading data or the creating the player datas:
        /// <see cref="PlayerInfo"/> and <see cref="Player"/> and <see cref="Me"/>.
        /// </summary>
        /// <param name="createAcc"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public Me(bool createAcc, string username, string password)
        {
            if (createAcc)
            {
                //-------------------------------------
                Username    = username;
                Password    = password;
                CreatingAcc = true;
                SignInAcc   = false;
                //-------------------------------------
                Timer CheckingForExistingUserTimer                  = new Timer();
                CheckingForExistingUserTimer.Interval               = 10;
                CheckingForExistingUserTimer.Tick                   +=
                    CheckingForExistingUserTimer_Tick;
                CheckingForExistingUserTimer.Enabled                = true;
                if (ThereIsServer.ServerSettings.TimeWorker == null)
                {
                    ThereIsServer.ServerSettings.TimeWorker         = new Timer();
                }
                ThereIsServer.ServerSettings.TimeWorker.Interval    = 1000;
                ThereIsServer.ServerSettings.TimeWorker.Tick        += 
                    ThereIsServer.Actions.TimeWorkerWorksForCreating;
                ThereIsServer.ServerSettings.TimeWorker.Enabled     = true;
                //-------------------------------------
            }
            else
            {
                //-------------------------------------
                Username    = username;
                Password    = password;
                CreatingAcc = false;
                SignInAcc   = true;
                //-------------------------------------
                Timer CheckingForExistingUserTimer      = new Timer();
                CheckingForExistingUserTimer.Interval   = 10;
                CheckingForExistingUserTimer.Tick       +=
                    CheckingForExistingUserTimer_Tick;
                CheckingForExistingUserTimer.Enabled    = true;
                if (ThereIsServer.ServerSettings.TimeWorker == null)
                {
                    ThereIsServer.ServerSettings.TimeWorker = new Timer();
                }
                ThereIsServer.ServerSettings.TimeWorker.Interval    = 1000;
                ThereIsServer.ServerSettings.TimeWorker.Tick        +=
                    ThereIsServer.Actions.TimeWorkerWorksForSigningIn;
                ThereIsServer.ServerSettings.TimeWorker.Enabled     = true;
                //-------------------------------------
            }
        }
        /// <summary>
        /// Checking the existance of this profile.
        /// For Link Start.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="theToken"></param>
        public Me(string username, string theToken)
        {
            //-------------------------------------
            Username                    = username;
            Token                       = theToken;
            CreatingAcc                 = false;
            SignInAcc                   = false;
            LinkStart                   = true;
            IsOnSecondStepOfLinkStart   = false;
            //-------------------------------------
            Timer CheckingForExistingUserTimer = new Timer();
            CheckingForExistingUserTimer.Interval = 10;
            CheckingForExistingUserTimer.Tick +=
                CheckingForExistingUserTimer_Tick;
            CheckingForExistingUserTimer.Enabled = true;
            if (ThereIsServer.ServerSettings.TimeWorker == null)
            {
                ThereIsServer.ServerSettings.TimeWorker = new Timer();
            }
            ThereIsServer.ServerSettings.TimeWorker.Interval = 1000;
            ThereIsServer.ServerSettings.TimeWorker.Tick +=
                ThereIsServer.Actions.TimeWorkerWorksForPriLinkStart;
            ThereIsServer.ServerSettings.TimeWorker.Enabled = true;
            //-------------------------------------
        }
        #endregion
        //-----------------------------------------------------------
        #region Creating Region
        //--------------------------
        public void CreatePlayerProfile()
        {
            //---------------------------------------------
            Timer CreateProfileTimer    = new Timer();
            CreateProfileTimer.Interval = 10;
            CreateProfileTimer.Tick     += CreatePlayerInfoTimer_Tick;
            CreateProfileTimer.Enabled  = true;
            //---------------------------------------------
            Timer CreateMeTimer         = new Timer();
            CreateMeTimer.Interval      = 10;
            CreateMeTimer.Tick          += CreateMeTimer_Tick;
            CreateMeTimer.Enabled       = true;
            //---------------------------------------------
            Timer Create_Player_Timer = new Timer();
            Create_Player_Timer.Interval = 10;
            Create_Player_Timer.Tick += Create_Player_Timer_Tick;
            Create_Player_Timer.Enabled = true;
            Timer CreatePlayerTroops_Timer = new Timer();
            CreatePlayerTroops_Timer.Interval = 10;
            CreatePlayerTroops_Timer.Tick += CreatePlayerTroops_Tick;
            CreatePlayerTroops_Timer.Enabled = true;
            Timer CreatePlayerMagicalTroops_Timer = new Timer();
            CreatePlayerMagicalTroops_Timer.Interval = 10;
            CreatePlayerMagicalTroops_Timer.Tick += CreatePlayerMagicalTroops_Tick;
            CreatePlayerMagicalTroops_Timer.Enabled = true;
            Timer CreatePlayerResources_Timer = new Timer();
            CreatePlayerResources_Timer.Interval = 10;
            CreatePlayerResources_Timer.Tick += CreatePlayerResources_Tick;
            CreatePlayerResources_Timer.Enabled = true;
            Timer CreatePlayerHeroes_Timer = new Timer();
            CreatePlayerHeroes_Timer.Interval = 10;
            CreatePlayerHeroes_Timer.Tick += CreatePlayerHeroes_Tick;
            CreatePlayerHeroes_Timer.Enabled = true;
            //---------------------------------------------
        }
        //--------------------------
        /// <summary>
        /// Checking for Existance, setting the <see cref="CreateProfileSandBox.DoesPlayerExists"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void CheckingForExistingUserTimer_Tick(object sender, EventArgs e)
        {
            ((Timer)sender).Enabled = false;
            ((Timer)sender).Dispose();
            var targetFile = Username + ThereIsServer.ServersInfo.EndCheckingFileName;
            HasAccExist = 
                await ThereIsServer.Actions.DeleteFile(ThereIsServer.ServersInfo.MyServers[0], targetFile,
                new DataBaseDeleteRequest("DeletedForCheckingBySAO", "NoSHA"));
            if (ThereIsServer.ServerSettings.HasConnectionClosed)
            {
                NoInternetConnectionSandBox.PrepareConnectionClosedSandBox();
                return;
            }
            if (HasAccExist)
            {
                if (ThereIsConstants.Forming.TheMainForm.IsShowingSandBox)
                {
                    CreateProfileSandBox mySand =
                        (CreateProfileSandBox)ThereIsConstants.Forming.TheMainForm.ShowingSandBox;
                    mySand.IsCheckingForExistingEnded = true;
                    mySand.DoesPlayerExists = true;
                }
                return;
            }
            else
            {
                if (ThereIsConstants.Forming.TheMainForm.IsShowingSandBox)
                {
                    CreateProfileSandBox mySand =
                        (CreateProfileSandBox)ThereIsConstants.Forming.TheMainForm.ShowingSandBox;
                    mySand.IsCheckingForExistingEnded = true;
                    mySand.DoesPlayerExists = false;
                }
            }

            /*

            try
            {
                await ThereIsServer.ServersInfo.Server1.ServerClient.
                    Repository.Content.DeleteFile(ThereIsServer.ServersInfo.Server1.Owner,
                    ThereIsServer.ServersInfo.Server1.Repo, targetFile,
                    new DeleteFileRequest("DeletedForCheckingBySAO", "NoSHA"));
                await ThereIsServer.ServersInfo.Server1.ServerClient.
                    Repository.Content.CreateFile(ThereIsServer.ServersInfo.Server1.Owner,
                    ThereIsServer.ServersInfo.Server1.Repo, targetFile,
                    new CreateFileRequest("ReCreatedBySAO", "SAO"));
                HasAccExist = true;

                if (ThereIsConstants.Forming.TheMainForm.IsShowingSandBox)
                {
                    CreateProfileSandBox mySand =
                        (CreateProfileSandBox)ThereIsConstants.Forming.TheMainForm.ShowingSandBox;
                    mySand.IsCheckingForExistingEnded = true;
                    mySand.DoesPlayerExists = true;
                }
                return;
            }
            catch(NotFoundException)
            {
                
                HasAccExist = false;
                if (ThereIsConstants.Forming.TheMainForm.IsShowingSandBox)
                {
                    CreateProfileSandBox mySand =
                        (CreateProfileSandBox)ThereIsConstants.Forming.TheMainForm.ShowingSandBox;
                    mySand.IsCheckingForExistingEnded = true;
                    mySand.DoesPlayerExists = false;
                }
            }
            catch(ApiException)
            {
                HasAccExist = true;
                if (ThereIsConstants.Forming.TheMainForm.IsShowingSandBox)
                {
                    CreateProfileSandBox mySand =
                        (CreateProfileSandBox)ThereIsConstants.Forming.TheMainForm.ShowingSandBox;
                    mySand.IsCheckingForExistingEnded = true;
                    mySand.DoesPlayerExists = true;
                }
                return;
            }
            */
        }


        /// <summary>
        /// Information for parameters at: <see cref="PlayerInfo"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void CreatePlayerInfoTimer_Tick(object sender, EventArgs e)
        {
            ((Timer)sender).Enabled = false;
            ((Timer)sender).Dispose();
            //-----------------------------------------------
            PlayerName          = Username;                             // 1
            PlayerLevel         = 0;                                    // 2
            PlayerLVLRanking    = 0;                                    // 3
            PlayerPowerRanking  = 0;                                    // 4
            PlayerGuildName     = NotSetString;                         // 5
            GuildPosition       = GuildPosition.NotJoined;              // 6
            LastSeen            = ThereIsConstants.AppSettings.GlobalTiming; // 7
            PlayerPower         = new Unit(0);                          // 8
            PlayerIntro         = NotSetString;                         // 9
            PlayerAvatar        = Avatar.GetDefaultAvatar();            // 10
            PlayerAvatarFrame   = AvatarFrame.GetDefaultAvatarFrame();  // 11
            PlayerVIPlvl        = 0;                                    // 12
            PlayerCurrentExp    = Unit.GetBasicUnit();                  // 13
            PlayerTotalExp      = Unit.GetBasicUnit();                  // 14
            PlayerCurrentVIPExp = Unit.GetBasicUnit();                  // 15
            ThePlayerElement    = PlayerElement.NotSet;                 // 16
            PlayerKingdom       = SAO_Kingdoms.NotSet;                  // 17
            SocialPosition      = SocialPosition.GetSocialPosition();   // 18
            //-----------------------------------------------
            var targetFile = Username + FileEndName;
            await ThereIsServer.Actions.CreateFile(ThereIsServer.ServersInfo.MyServers[0], 
                        targetFile,
                        new DataBaseCreation("Testing for Creating", 
                        QString.Parse(PlayerInfoGetForServer())));
            //------------------------------------------------------
            StrongString myString = string.Empty;
#pragma warning disable IDE0059
            SecuredMe Hi = new SecuredMe(ref myString);
#pragma warning restore IDE0059
            await ThereIsServer.Actions.CreateFile(ThereIsServer.ServersInfo.MyServers[0],
                        Username + ThereIsServer.ServersInfo.EndCheckingFileName,
                        new DataBaseCreation("ReCreatedBySAO", QString.Parse(myString)));
            //------------------------------------------------------



            ((CreateProfileSandBox)ThereIsConstants.Forming.TheMainForm.ShowingSandBox).IsCreatingEnded1 = true;
            IsWaitingForSecuredWorking = true;

#pragma warning disable IDE0059
            SecuredMe MeSecured = new SecuredMe(true, Username, Password, this);
#pragma warning restore IDE0059
            GC.Collect();
        }


        /// <summary>
        /// Information for parameters at: <see cref="Me"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void CreateMeTimer_Tick(object sender, EventArgs e)
        {
            ((Timer)sender).Enabled = false;
            ((Timer)sender).Dispose();
            //-----------------------------------------------
            AvatarFrameList = AvatarFrameList.GenerateEmptyList();
            AvatarList      = AvatarList.GenerateEmptyList();
            MyBlockList     = ChatBlockList.GenerateBlankChatBlockList();
            //-----------------------------------------------
            var targetFile = Username + FileEndName2;
            await ThereIsServer.Actions.CreateFile(ThereIsServer.ServersInfo.MyServers[0], 
                        targetFile,
                        new DataBaseCreation("Testing for Creating", 
                        QString.Parse(MeGetForServer())));
            ((CreateProfileSandBox)ThereIsConstants.Forming.TheMainForm.ShowingSandBox).IsCreatingEnded2 = true;
            GC.Collect();
        }

        //--------------------------------------------------
        private async void Create_Player_Timer_Tick(object sender, EventArgs e)
        {
            ((Timer)sender).Enabled = false;
            ((Timer)sender).Dispose();
            //-----------------------------------------------



            //-----------------------------------------------
            var targetFile = Username + EndFileName_Player;
            string myCon = CastleLvl.ToString() + CharSeparater;
            await ThereIsServer.Actions.CreateFile(ThereIsServer.ServersInfo.MyServers[0], 
                        targetFile,
                        new DataBaseCreation("Testing for Creating", myCon));
            //-----------------------------------------------
            //-----------------------------------------------



            ((CreateProfileSandBox)ThereIsConstants.Forming.TheMainForm.ShowingSandBox).IsCreatingEnded3 = true;
            GC.Collect();
        }
        //--------------------------------------------------
        private async void CreatePlayerTroops_Tick(object sender, EventArgs e)
        {
            ((Timer)sender).Enabled = false;
            ((Timer)sender).Dispose();
            //-----------------------------------------------
            PlayerTroops = TroopManager.GetTroopManager(Troop.GetBasicTroops());


            //-----------------------------------------------
            //-----------------------------------------------
            await Troop.CreatePlayerTroops(PlayerTroops.Troops);
            //-----------------------------------------------



            ((CreateProfileSandBox)ThereIsConstants.Forming.TheMainForm.ShowingSandBox).IsCreatingEnded4 = true;
            GC.Collect();
        }
        //--------------------------------------------------
        private async void CreatePlayerMagicalTroops_Tick(object sender, EventArgs e)
        {
            ((Timer)sender).Enabled = false;
            ((Timer)sender).Dispose();
            //-----------------------------------------------



            //-----------------------------------------------
            //-----------------------------------------------
            await MagicalTroop.CreatePlayerMagicalTroops(MagicalTroop.GetBasicMagicalTroop());
            //-----------------------------------------------



            ((CreateProfileSandBox)ThereIsConstants.Forming.TheMainForm.ShowingSandBox).IsCreatingEnded5 = true;
            GC.Collect();
        }
        //--------------------------------------------------
        private async void CreatePlayerResources_Tick(object sender, EventArgs e)
        {
            ((Timer)sender).Enabled = false;
            ((Timer)sender).Dispose();
            //-----------------------------------------------
            PlayerResources = PlayerResources.GetBasicPlayerResources();


            //-----------------------------------------------
            //-----------------------------------------------
            await PlayerResources.CreatePlayerResources(PlayerResources);
            //-----------------------------------------------



            ((CreateProfileSandBox)ThereIsConstants.Forming.TheMainForm.ShowingSandBox).IsCreatingEnded6 = true;
            GC.Collect();
        }
        //--------------------------------------------------
        /// <summary>
        /// Information for parameters at: <see cref="Player"/>,
        /// in: <see cref="Player.EndFileName_Player"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void CreatePlayerHeroes_Tick(object sender, EventArgs e)
        {
            ((Timer)sender).Enabled = false;
            ((Timer)sender).Dispose();
            //-----------------------------------------------



            //-----------------------------------------------
            //-----------------------------------------------
            await Hero.CreatePlayerHeroes();
            //-----------------------------------------------



            ((CreateProfileSandBox)ThereIsConstants.Forming.TheMainForm.ShowingSandBox).IsCreatingEnded7 = true;
            GC.Collect();
        }
        #endregion
        //-----------------------------------------------------------
        #region Login and loading Region
        public void Login(bool AfterConfirmingSecuredMe = false)
        {
            if (!AfterConfirmingSecuredMe)
            {
                IsWaitingForSecuredWorking = true;
                #pragma warning disable IDE0059
                //SecuredMe MeSecured = new SecuredMe(true, Username, Password, this);
                SecuredMe MeSecured = new SecuredMe(Username, Password, true, this);
                #pragma warning restore IDE0059
            }
            else
            {

                //---------------------------------------------
                Timer LoadProfileInfoTimer = new Timer();
                LoadProfileInfoTimer.Interval = 10;
                LoadProfileInfoTimer.Tick += LoadPlayerInfoTimer_Tick;
                LoadProfileInfoTimer.Enabled = true;
                //---------------------------------------------
                Timer LoadMeTimer = new Timer();
                LoadMeTimer.Interval = 10;
                LoadMeTimer.Tick += LoadMeTimer_Tick;
                LoadMeTimer.Enabled = true;
                //---------------------------------------------
                Timer Load_Player_Timer = new Timer();
                Load_Player_Timer.Interval = 10;
                Load_Player_Timer.Tick += Load_Player_Timer_Tick;
                Load_Player_Timer.Enabled = true;
                //---------------------------------------------
                Timer TokenObj_Timer = new Timer();
                TokenObj_Timer.Interval = 10;
                TokenObj_Timer.Tick += TokenObj_Timer_Tick;
                TokenObj_Timer.Enabled = true;
                //---------------------------------------------
            }

        }


        //--------------------------
        private async void TokenObj_Timer_Tick(object sender, EventArgs e)
        {
            //-----------------
            ((Timer)sender).Enabled = false;
            ((Timer)sender).Dispose();
            //-----------------
            StrongString myString = string.Empty;
#pragma warning disable IDE0059
            SecuredMe Hi = new SecuredMe(ref myString);
#pragma warning restore IDE0059
            //MessageBox.Show(myString);
            var ExistingFiles = 
                await ThereIsServer.Actions.GetAllContentsByRef(ThereIsServer.ServersInfo.MyServers[0],
                        Username + ThereIsServer.ServersInfo.EndCheckingFileName);
            if (ExistingFiles.IsDeadCallBack || ThereIsServer.ServerSettings.HasConnectionClosed)
            {
                NoInternetConnectionSandBox.PrepareConnectionClosedSandBox();
                return; // don't set ServerSettings.IsWaitingForServerChecking = false;
            }
            await ThereIsServer.Actions.UpdateFile(ThereIsServer.ServersInfo.MyServers[0],
                        Username + ThereIsServer.ServersInfo.EndCheckingFileName,
                        new DataBaseUpdateRequest("SAO", QString.Parse(myString), ExistingFiles.Sha));
            ThereIsServer.ServerSettings.TokenObj = myString;
            ((CreateProfileSandBox)ThereIsConstants.Forming.TheMainForm.ShowingSandBox).IsSignInEnded4 = true;
            //-----------------
            GC.Collect();
        }
        /// <summary>
        /// Use this function to load datas which are necessary for <see cref="PlayerInfo"/>,
        /// which are saved at: <see cref="PlayerInfo.FileEndName"/> at the Server.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void LoadPlayerInfoTimer_Tick(object sender, EventArgs e)
        {
            ((Timer)sender).Enabled = false;
            ((Timer)sender).Dispose();
            //-----------------------------------------------
            var targetFile = Username + FileEndName;
            var existingFile =
                await ThereIsServer.Actions.GetAllContentsByRef(ThereIsServer.ServersInfo.MyServers[0], 
                        targetFile);
            if (existingFile.IsDeadCallBack || ThereIsServer.ServerSettings.HasConnectionClosed)
            {
                NoInternetConnectionSandBox.PrepareConnectionClosedSandBox();
                return; // don't set ServerSettings.IsWaitingForServerChecking = false;
            }
            SetPlayerInfoParams(existingFile.Decode());

            // Update the LastSeen of the player.
            LastSeen = ThereIsConstants.AppSettings.GlobalTiming;
            await UpdatePlayerInfo();

            ((CreateProfileSandBox)ThereIsConstants.Forming.TheMainForm.ShowingSandBox).IsSignInEnded1 = true;
            GC.Collect();
        }
        /// <summary>
        /// Use it to load the datas for <see cref="Me"/>'s information,
        /// in the <see cref="FileEndName2"/> at the server.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void LoadMeTimer_Tick(object sender, EventArgs e)
        {
            ((Timer)sender).Enabled = false;
            ((Timer)sender).Dispose();
            //-----------------------------------------------
            var targetFile = Username + FileEndName2;
            var existingFile =
                await ThereIsServer.Actions.GetAllContentsByRef(ThereIsServer.ServersInfo.MyServers[0], 
                        targetFile);
            if (existingFile.IsDeadCallBack || ThereIsServer.ServerSettings.HasConnectionClosed)
            {
                NoInternetConnectionSandBox.PrepareConnectionClosedSandBox();
                return; // don't set ServerSettings.IsWaitingForServerChecking = false;
            }
            SetParams(existingFile.Decode());
            ((CreateProfileSandBox)ThereIsConstants.Forming.TheMainForm.ShowingSandBox).IsSignInEnded2 = true;
            GC.Collect();
        }
        /// <summary>
        /// with this fuctions, you will load the Information for <see cref="Player"/> in
        /// the <see cref="Player.EndFileName_Player"/> at server.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Load_Player_Timer_Tick(object sender, EventArgs e)
        {
            ((Timer)sender).Enabled = false;
            ((Timer)sender).Dispose();
            //-----------------------------------------------
            var targetFile = Username + EndFileName_Player;
            var existingFile =
                await ThereIsServer.Actions.GetAllContentsByRef(ThereIsServer.ServersInfo.MyServers[0], 
                        targetFile);
            if (existingFile.IsDeadCallBack || ThereIsServer.ServerSettings.HasConnectionClosed)
            {
                NoInternetConnectionSandBox.PrepareConnectionClosedSandBox();
                return; // don't set ServerSettings.IsWaitingForServerChecking = false;
            }
            SetPlayerParams(existingFile.Decode());
            ((CreateProfileSandBox)ThereIsConstants.Forming.TheMainForm.ShowingSandBox).IsSignInEnded3 = true;
            GC.Collect();
        }
        #endregion
        //-----------------------------------------------------------
        #region Link_Start and LogOut Region
        //--------------------------
        public void Link_Start(bool IsAfterSecuredMe = false)
        {
            if (!IsAfterSecuredMe)
            {
                IsWaitingForSecuredWorking = true;
                #pragma warning disable IDE0059
                //SecuredMe MeSecured = new SecuredMe(true, Username, Password, this);
                SecuredMe MeSecured = new SecuredMe(Username, Token, this);
                #pragma warning restore IDE0059
            }
            else
            {
                //-------------------------------------
                //Username = username;
                //Token = theToken;
                //CreatingAcc = false;
                //SignInAcc = false;
                //LinkStart = true;
                IsOnSecondStepOfLinkStart = true;
                //-------------------------------------
                Timer CheckingForExistingUserTimer = new Timer();
                CheckingForExistingUserTimer.Interval = 10;
                CheckingForExistingUserTimer.Tick +=
                    CheckingForExistingUserTimer_Tick;
                CheckingForExistingUserTimer.Enabled = true;
                if (ThereIsServer.ServerSettings.TimeWorker == null)
                {
                    ThereIsServer.ServerSettings.TimeWorker = new Timer();
                }
                ThereIsServer.ServerSettings.TimeWorker.Interval = 1000;
                ThereIsServer.ServerSettings.TimeWorker.Tick +=
                    ThereIsServer.Actions.TimeWorkerWorksForPriLinkStart;
                ThereIsServer.ServerSettings.TimeWorker.Enabled = true;
                //-------------------------------------
            }
        }
        //--------------------------
        public void LogOut(bool AfterChecking = false, bool DontClearOnServer = false)
        {
            if (AfterChecking)
            {
                if (DontClearOnServer) // do it later.
                {

                }
                else
                {
                    IsWaitingForSecuredWorking = true;
#pragma warning disable IDE0059
                    //SecuredMe MeSecured = new SecuredMe(true, Username, Password, this);
                    SecuredMe MeSecured = new SecuredMe(Username, this, Token);
#pragma warning restore IDE0059
                }

            }
            else
            {
                //--------------------------------------------
                Timer CheckingForExistingUserTimer = new Timer();
                CheckingForExistingUserTimer.Interval = 10;
                CheckingForExistingUserTimer.Tick +=
                    CheckingForExistingUserTimer_Tick;
                CheckingForExistingUserTimer.Enabled = true;
                if (ThereIsServer.ServerSettings.TimeWorker == null)
                {
                    ThereIsServer.ServerSettings.TimeWorker = new Timer();
                }
                ThereIsServer.ServerSettings.TimeWorker.Interval = 1000;
                ThereIsServer.ServerSettings.TimeWorker.Tick +=
                    ThereIsServer.Actions.TimeWorkerWorksForLogingOut;
                ThereIsServer.ServerSettings.TimeWorker.Enabled = true;
            }


        }
        #endregion
        //-----------------------------------------------------------
        #region Setting Methods Region
            // These Methods are offline, so you should update the player info
            // after using these method, they will only change the
            // Properties.
        private void SetParams(StrongString serverValue)
        {
            StrongString[] myStrings = serverValue.Split(CharSeparater);
            StoryStep       = (StorySteps)myStrings[0].ToUInt16();        // 0
            AvatarFrameList = AvatarFrameList.Parse(myStrings[1]);  // 1
            AvatarList      = AvatarList.Parse(myStrings[2]);            // 2
            MyBlockList     = ChatBlockList.Parse(myStrings[3]);        // 3
        }
        /// <summary>
        /// Use it Just once, and in the Element Selection with the Tohsaka's 
        /// Dialog.
        /// </summary>
        /// <param name="playerElement"></param>
        public void SetPlayerElement(PlayerElement playerElement)
        {
            ThePlayerElement = playerElement;
        }
        public void SetPlayerKingdom(SAO_Kingdoms playerKingdom)
        {
            PlayerKingdom = playerKingdom;
        }
        public bool SetSocialPosition(PlayerSocialPosition position = PlayerSocialPosition.OrdinaryPlayer)
        {
            SocialPosition = SocialPosition.GetSocialPosition(position);
            return true;
        }
        public bool SetSocialPosition(StrongString value)
        {
            SocialPosition = SocialPosition.GetSocialPosition(value);
            return true;
        }
        public void SetPlayerStoryStep()
        {
            StoryStep = StoryStep++;
        }
        public void SetPlayerStoryStep(StorySteps step)
        {
            StoryStep = step;
        }
        /// <summary>
        /// set the new avatar of the player, 
        /// if the avatar is special and is not in the
        /// avatar list of the player, this method will return
        /// false. if the new avatar value is already 
        /// selevted, will return false.
        /// </summary>
        /// <param name="avatar">
        /// The new Avatar value.
        /// </param>
        /// <returns>
        /// true, if the operation was successful,
        /// otherwise false.
        /// </returns>
        public bool SetPlayerAvatar(Avatar avatar)
        {
            if (avatar == null || PlayerAvatar == avatar)
            {
                return false;
            }
            if (avatar.IsSpecial)
            {
                if (!AvatarList[avatar])
                {
                    return false;
                }
            }
            PlayerAvatar = avatar;
            return true;
        }
        public bool SetPlayerAvatar(StrongString avatarString)
        {
            return SetPlayerAvatar(Avatar.ConvertToAvatar(avatarString));
        }
        public bool AddPlayerAvatar(StrongString avatarString)
        {
            return AddPlayerAvatar(Avatar.ConvertToAvatar(avatarString));
        }
        public bool AddPlayerAvatar(Avatar avatar)
        {
            if (!avatar.IsSpecial)
            {
                return false;
            }
            AvatarList.AddAvatar(avatar);
            return true;
        }
        public bool SetPlayerAvatarFrame(AvatarFrame frame)
        {
            if (!AvatarFrameList[frame])
            {
                return false;
            }
            PlayerAvatarFrame = frame;
            return true;
        }
        public bool SetPlayerAvatarFrame(StrongString frameString)
        {
            return SetPlayerAvatarFrame(AvatarFrame.ParseToAvatarFrame(frameString));
        }
        public bool AddAvatarFrame(AvatarFrame frame)
        {
            AvatarFrameList.AddAvatarFrame(frame);
            return true;
        }
        public bool AddAvatarFrame(StrongString frameString)
        {
            return AddAvatarFrame(AvatarFrame.ParseToAvatarFrame(frameString));
        }
        /// <summary>
        /// Resume total Player Power.
        /// </summary>
        public void ResumePlayerPower()
        {
            Unit thePower   = Unit.GetBasicUnit();
            thePower        += PlayerHeroes.GetTotalHeroesPower();
            thePower        += PlayerTroops.GetTotalTroopsPower();
            PlayerPower     = thePower;
        }
        #endregion
        //-----------------------------------------------------------
        #region Getting Methods Region
        public Unit GetNeededExpForNextLvl()
        {
            int n = PlayerLevel / PlayerLvlParamCal1, m = PlayerLevel / PlayerLvlParamCal2,
                l = PlayerLvlParamCal3 * (PlayerLevel + 1);
            ulong myLong = (ulong)(((int)System.Math.Pow(n, PlayerLvlParamCal3)) + 
                (PlayerLvlParamCal3 * m) + 
                (l * (PlayerLevel + 1)));
            return Unit.ConvertToUnit(myLong);
        }
        /// <summary>
        /// getting a float between 0 and 1 which
        /// indicate the advancing of the player in leveling.
        /// </summary>
        /// <returns></returns>
        public double GetAdvancingExp()
        {
            return ((double)PlayerCurrentExp.ConvertToInt()) / GetNeededExpForNextLvl().ConvertToInt();
        }
        private StrongString MeGetForServer()
        {
            return
                ((ushort)StoryStep).ToString()              + CharSeparater + // 0
                AvatarFrameList.GetForServer().GetValue()   + CharSeparater + // 1
                AvatarList.GetForServer().GetValue()        + CharSeparater + // 2
                MyBlockList.GetForServer().GetValue()       + CharSeparater;  // 3
        }
        #endregion
        //-----------------------------------------------------------
        #region Online Servering Methods Region
        //These Methods are online workings, 
        //so you should 
        public async Task<bool> ReloadMe()
        {
            var targetFile = Username + FileEndName2;
            var existingFile =
                await ThereIsServer.Actions.GetAllContentsByRef(ThereIsServer.ServersInfo.MyServers[0], 
                        targetFile);
            if (existingFile.IsDeadCallBack || ThereIsServer.ServerSettings.HasConnectionClosed)
            {
                NoInternetConnectionSandBox.PrepareConnectionClosedSandBox();
                return false; // don't set ServerSettings.IsWaitingForServerChecking = false;
            }
            SetParams(existingFile.Decode());
            return true;
        }
        public async Task<DataBaseDataChangedInfo> UpdateMe()
        {
            //-----------------------------------------------
            var targetFile = Username + FileEndName2;
            
            var existingFile =
                await ThereIsServer.Actions.GetAllContentsByRef(ThereIsServer.ServersInfo.MyServers[0], 
                        targetFile);
            if (existingFile.IsDeadCallBack || ThereIsServer.ServerSettings.HasConnectionClosed)
            {
                NoInternetConnectionSandBox.PrepareConnectionClosedSandBox();
                return null; // don't set ServerSettings.IsWaitingForServerChecking = false;
            }
            return await ThereIsServer.Actions.UpdateFile(ThereIsServer.ServersInfo.MyServers[0], 
                        targetFile,
                        new DataBaseUpdateRequest("Testing for Creating", 
                        QString.Parse(MeGetForServer()),
                        existingFile.Sha));
        }
        #endregion
        //-----------------------------------------------------------
    }

}
