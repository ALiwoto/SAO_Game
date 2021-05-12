using System;
using System.IO;
using System.Net;
using System.Text;
using System.Drawing;
using System.Management;
using System.Windows.Forms;
using System.Globalization;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Diagnostics.CodeAnalysis;
using WotoProvider;
using WotoProvider.Interfaces;
using WotoProvider.EventHandlers; 
using SAO.Client;
using SAO.SandBox;
using SAO.Security;
using SAO.Controls;
using SAO.LoadingService;
using SAO.GameObjects.ServerObjects;

namespace SAO.Constants
{
#pragma warning disable IDE0055
    /// <summary>
    /// ThereIsConstants :))
    /// </summary>
    [ComVisible(true)]
    public static class ThereIsConstants
    {
        //-------------------------------------------------
        #region Extensions Region
        public static StrongString ToStrong(this string value)
        {
            return new StrongString(value);
        }
        public static void AddRange(this Control.ControlCollection collection, params Control[] controls)
        {
            collection.AddRange(controls);
        }
        #endregion
        //-------------------------------------------------
        #region structors' Region
        public struct Actions
        {
            //---------------------------------------------
            #region MouseEvent Method's Region
            [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
            [SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
            public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);
            //------------
            //Mouse actions
            public const int MOUSEEVENTF_LEFTDOWN   = 0x02;
            public const int MOUSEEVENTF_LEFTUP     = 0x04;
            public const int MOUSEEVENTF_RIGHTDOWN  = 0x08;
            public const int MOUSEEVENTF_RIGHTUP    = 0x10;
            //------------
            #endregion
            //---------------------------------------------
            #region Service Method's Region
            /// <summary>
            /// Using for Generating Token and Also Checking the Token saved in the profile file.
            /// </summary>
            /// <returns></returns>
            public static StrongString OSの伊にファーエー所運()
            {
                string r = "";
                using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem"))
                {
                    ManagementObjectCollection information = searcher.Get();
                    if (information != null)
                    {
                        foreach (ManagementObject obj in information)
                        {
                            r = obj["Caption"].ToString() + " - " + obj["OSArchitecture"].ToString();
                        }
                    }
                    r = r.Replace("NT 5.1.2600", "XP");
                    r = r.Replace("NT 5.2.3790", "Server 2003");
                }
                return r;
            }
            //-----------------------------------------
            [SuppressMessage("Code Quality", "IDE0067:Dispose objects before losing scope", Justification = "<Pending>")]
            public static bool CheckForInternetConnection(ref bool IsIt)
            {
                try
                {
                    WebClient webClient = new WebClient();
                    webClient.DownloadFile(new Uri(AppSettings.ConnectionURL),
                        Path.main_Path + Path.Temporary_Folder_Name + Path.Google_Generate_File_Name);
                    IsIt = true;
                    return true;
                }
                catch
                {
                    IsIt = false;
                    return false;
                }
            }
            //------------------------------------------
            public static IDateProvider<DateTime, Trigger, StrongString> GetNistTime()
            {
                /*
              * 
              * 
              * 
              * var client = new TcpClient("time.nist.gov", 13);
              * using (var streamReader = new StreamReader(client.GetStream()))
              *  {
              *   var response = streamReader.ReadToEnd();
              *   
              *   var utcDateTimeString = response.Substring(7, 17);
              *   var localDateTime = DateTime.ParseExact(utcDateTimeString, "yy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal);
              *   return localDateTime;
              *  }
              */
                // This Part is Closed! Don't use this code plz! {ALi.w}
                //DateTime dateTime = DateTime.MinValue;

                //HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://nist.time.gov/actualtime.cgi?lzbc=siqm9b");
                //request.Method = "GET";
                //request.Accept = "text/html, application/xhtml+xml, */*";
                //request.UserAgent = "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.1; Trident/6.0)";
                //request.ContentType = "application/x-www-form-urlencoded";
                //request.CachePolicy = new RequestCachePolicy(RequestCacheLevel.NoCacheNoStore); //No caching
                //HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                //if (response.StatusCode == HttpStatusCode.OK)
                //{
                //StreamReader stream = new StreamReader(response.GetResponseStream());
                //string html = stream.ReadToEnd();//<timestamp time=\"1395772696469995\" delay=\"1395772696469995\"/>
                //string time = Regex.Match(html, @"(?<=\btime="")[^""]*").Value;
                //double milliseconds = Convert.ToInt64(time) / 1000.0;
                //dateTime = new DateTime(1970, 1, 1).AddMilliseconds(milliseconds).ToLocalTime();
                //}
                //return dateTime;
                var myHttpWebRequest = 
                    (HttpWebRequest)WebRequest.Create(AppSettings.TimeRequestURL);
                try
                {
                    return 
                        ToDateTime(myHttpWebRequest.GetResponse().Headers[AppSettings.DateHeaderKey].ToStrong());
                }
                catch
                {
                    ThereIsServer.ServerSettings.HasConnectionClosed = true;
                    NoInternetConnectionSandBox.PrepareConnectionClosedSandBox();
                    return DateProvider.GetUnlimited();
                }
            }
            public static IDateProvider<DateTime, Trigger, StrongString> ToDateTime(QString value)
            {
                return ToDateTime(value.GetStrong());
            }
            public static IDateProvider<DateTime, Trigger, StrongString> ToDateTime(StrongString value)
            {
                return DateProvider.Parse(value);
            }
            //------------------------------------------
            /// <summary>
            /// Time Worker Function that will execute every second!
            /// this is very important, so remember there is always risks in using this method.
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            public static void TimeWorkerWorks(object sender, EventArgs e)
            {
                if (Forming.TheMainForm.IsConnecting || Forming.TheMainForm.IsCheckingForUpdate)
                {
                    if (Forming.TheMainForm.FirstLabel.Text.IndexOf("...") != -1 && !Forming.TheMainForm.IsShowingSandBox)
                    {
                        Forming.TheMainForm.FirstLabel.Text = Forming.TheMainForm.FirstLabel.Text.Remove(Forming.TheMainForm.FirstLabel.Text.IndexOf("..."));
                    }
                    else if (Forming.TheMainForm.IsShowingSandBox)
                    {
                        Forming.TheMainForm.FirstLabel.Text = "No Connection";
                    }
                    else
                    {
                        Forming.TheMainForm.FirstLabel.Text += ".";
                    }
                }
                else if (Forming.TheMainForm.IsCheckingForUpdateEnded)
                {
                    Forming.TheMainForm.IsCheckingForUpdateEnded = false;
                    if (Forming.TheMainForm.IsServerOnBreak)
                    {
                        Forming.TheMainForm.IsServerOnBreak = false;
                        Forming.TheMainForm.ShowTheServerOnBreakSandBox();
                    }
                    else if (Forming.TheMainForm.IsServerUpdating)
                    {
                        Forming.TheMainForm.IsServerUpdating = false;
                        Forming.TheMainForm.ShowTheUpdatingServerSandBox();
                    }
                    else if (Forming.TheMainForm.IsServerOnline)
                    {
                        if (Forming.TheMainForm.IsTheLastVer)
                        {
                            ((Timer)sender).Enabled = false;
                            ((Timer)sender).Dispose();
                            Forming.TheMainForm.PreparingMainMenu();
                        }
                        else
                        {
                            MessageBox.Show("ONline But NOT The Last Version!");
                        }
                    }
                }
                GC.Collect();
            }
            public static void GlobalTimingWorker(Trigger sender, TickHandlerEventArgs<Trigger> handler)
            {
                if (ThereIsServer.ServerSettings.HasConnectionClosed)
                {
                    sender.Enabled = false;
                    sender.Dispose();
                    return;
                }
                if (Forming.TheMainForm.MainMenuLoaded)
                {
                    string test = AppSettings.GlobalTiming.GetString(false).GetValue();
                    Forming.TheMainForm.FirstLabel.Text = 
                        AppSettings.GlobalTiming.GetString(false).GetValue();
                    Forming.TheMainForm.FirstLabel.Refresh();
                    if (DateTime.Now.Second % 3 == 0)
                    {
                        Task.Run(() =>
                            {
                                GC.Collect();
                            }
                        );
                    }
                }
                else
                {
                    sender.Stop();
                    sender.Dispose();
                    return;
                }
            }
            #endregion
            //---------------------------------------------
            #region DllImports Region
            [DllImport("user32.dll")]
            public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
            [DllImport("user32.dll")]
            public static extern bool ReleaseCapture();
            public const int WM_NCLBUTTONDOWN   = 0xA1;
            public const int HT_CAPTION         = 0x2;
            //-----------------------------------------
            [DllImport("User32.dll")]
            public static extern int SendMessage(IntPtr hWnd, int msg, int wParam, ref int lParam);
            [DllImport("user32")]
            public static extern int ReleaseCapture(IntPtr hwnd);

            public const int WM_SYSCOMMAND = 0x112;
            public const int MOUSE_MOVE = 0xF012;
            //---------------------------------------------
            [DllImport("user32.dll")]
            public static extern int SendMessage(IntPtr hWnd, int wMsg, bool wParam, int lParam);

            public const int WM_SETREDRAW = 11;
            public static void SuspendDrawing(Control parent)
            {
                SendMessage(parent.Handle, WM_SETREDRAW, false, 0);
            }
            public static void ResumeDrawing(Control parent)
            {
                SendMessage(parent.Handle, WM_SETREDRAW, true, 0);
                parent.Refresh();
            }
            #endregion
            //---------------------------------------------
            #region Common Game Method's Region
            /// <summary>
            /// chec if the current version of the game is the 
            /// latest version.
            /// if it's not, you should show a sandbox... (not included here...)
            /// </summary>
            public static async void IsLastVersion()
            {
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                var targetFile = "ServerConfiguration";
                var existingFile =
                    await ThereIsServer.Actions.GetAllContentsByRef(ThereIsServer.ServersInfo.MyServers[0],
                    targetFile);
                await Task.Delay(300);
                if (existingFile.IsDeadCallBack || ThereIsServer.ServerSettings.HasConnectionClosed)
                {
                    NoInternetConnectionSandBox.PrepareConnectionClosedSandBox();
                    return; // don't set ServerSettings.IsWaitingForServerChecking = false;
                }
                if(File.Exists(Path.main_Path + Path.Temporary_Folder_Name + Path.ServerConfiguration_File_Name))
                {
                    File.Delete(Path.main_Path + Path.Temporary_Folder_Name + Path.ServerConfiguration_File_Name);
                }
                await Task.Run(() =>
                {
                    AppSettings.GlobalTiming = GetNistTime();
                });
                if (AppSettings.GlobalTiming.IsUnlimited)
                {
                    return;
                }
                AppSettings.DateTimeSettedWithNet = true;
                AppSettings.GlobalTimingWorker = new Trigger()
                {
                    Interval = 999
                };
                AppSettings.GlobalTiming.StartTicking();
                Forming.TheMainForm.SettingUpFiles();
                GC.Collect();
                AppSettings.GlobalTimingWorker.Tick += GlobalTimingWorker;
                AppSettings.GlobalTimingWorker.Start();
#pragma warning disable IDE0017 // Simplified :|
                ThereIsServer.ServerSettings.ServerChecker = new Trigger()
                {
                    Interval = 3000,
                };
                ThereIsServer.ServerSettings.ServerChecker.Tick +=
                    ThereIsServer.Actions.CheckingServerWorker;
                ThereIsServer.ServerSettings.ServerChecker.Enabled = true;
#pragma warning restore IDE0017
                Completed(existingFile.Decode());
            }
            public static void Completed(StrongString theText)
            {
                StrongString[] myString = theText.Split(ServerConfig.CharSeparator);
                ServerConfig config =
                    new ServerConfig(
                        (ServerStatus)myString[0].ToInt32(),
                        GameVersion.ParseToVersion(myString[1]), 
                        myString[2], myString[3]);
                if (config.ServerStatus == ServerStatus.Online)
                {
                    Forming.TheMainForm.IsServerOnline = true;
                    if (config.LastVersion == GameVersion.ParseToVersion(AppSettings.AppVersion))
                    {
                        Forming.TheMainForm.IsTheLastVer = true;
                    }
                    else
                    {
                        Forming.TheMainForm.IsTheLastVer = false;
                    }
                }
                else if (config.ServerStatus == ServerStatus.Breaking)
                {
                    Forming.TheMainForm.IsServerOnBreak = true;
                }
                else if (config.ServerStatus == ServerStatus.Updating)
                {
                    Forming.TheMainForm.IsServerUpdating = true;
                    Forming.TheMainForm.ReleasingDate = config.AccessDate.GetStrong();
                }
                Forming.TheMainForm.IsCheckingForUpdateEnded = true;
                Forming.TheMainForm.IsCheckingForUpdate = false;
            }
            //-------------------------------------------------------
            public static void ClearingUp()
            {
                if (Directory.Exists(Path.main_Path +
                    Path.Temporary_Folder_Name))
                {
                    try
                    {
                        Directory.Delete(Path.main_Path +
                        Path.Temporary_Folder_Name, true);
                    }
                    catch
                    {
                        ;//
                    }
                }
            }
            public static void ClearingPlayerProfile()
            {
                if (Directory.Exists(Path.Profile_Folder_Path))
                {
                    Directory.Delete(Path.Profile_Folder_Path, true);
                }
                if (File.Exists(Path.AccountInfo_File_Path))
                {
                    File.Delete(Path.AccountInfo_File_Path);
                }
                if (File.Exists(Path.ProfileList_File_Path))
                {
                    File.Delete(Path.ProfileList_File_Path);
                }
                
            }
            //-------------------------------------------------------
            public static Bitmap RotateImage(Bitmap bmp, float angle)
            {
                Bitmap rotatedImage = new Bitmap(bmp.Width, bmp.Height);
                rotatedImage.SetResolution(bmp.HorizontalResolution, bmp.VerticalResolution);

                using (Graphics g = Graphics.FromImage(rotatedImage))
                {
                    // Set the rotation point to the center in the matrix
                    g.TranslateTransform(bmp.Width / 2, bmp.Height / 2);
                    // Rotate
                    g.RotateTransform(angle);
                    // Restore rotation point in the matrix
                    g.TranslateTransform(-bmp.Width / 2, -bmp.Height / 2);
                    // Draw the image on the bitmap
                    g.DrawImage(bmp, new Point(0, 0));
                }

                return rotatedImage;
            }
            public static Bitmap RotateImage(Image bmp, float angle)
            {
                Bitmap rotatedImage = new Bitmap(bmp.Width, bmp.Height);
                rotatedImage.SetResolution(bmp.HorizontalResolution, bmp.VerticalResolution);
                using (Graphics g = Graphics.FromImage(rotatedImage))
                {
                    // Set the rotation point to the center in the matrix
                    g.TranslateTransform(bmp.Width / 2, bmp.Height / 2);
                    // Rotate
                    g.RotateTransform(angle);
                    // Restore rotation point in the matrix
                    g.TranslateTransform(-bmp.Width / 2, -bmp.Height / 2);
                    // Draw the image on the bitmap
                    g.DrawImage(bmp, new Point(0, 0));
                }
                return rotatedImage;
            }
            public static Image CropImage(Bitmap myBit, RectangleF section)
            {
                int w = Convert.ToInt32(section.Width),
                    h = Convert.ToInt32(section.Height);
                if (w == 0)
                {
                    w = 1;
                }
                if (h == 0)
                {
                    h = 1;
                }
                Bitmap bmp = new Bitmap(w, h);
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.DrawImage(myBit, 0, 0, section, GraphicsUnit.Pixel);
                }
                return bmp;
            }
            public static Image CropImage(Image myBit, RectangleF section)
            {
                int w = Convert.ToInt32(section.Width), 
                    h = Convert.ToInt32(section.Height);
                if (w == 0)
                {
                    w = 1;
                }
                if (h == 0)
                {
                    h = 1;
                }
                Bitmap bmp = new Bitmap(w, h);
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.DrawImage(myBit, 0, 0, section, GraphicsUnit.Pixel);
                }
                return bmp;
            }
            //-------------------------------------------------------
            public static void DisposeAllChild(Control myCon)
            {
                foreach (Control theChild in myCon.Controls)
                {
                    theChild.Dispose();
                }
            }
            //-------------------------------------------------------
            #endregion
            //---------------------------------------------
        }
        public struct Path
        {
            //---------------------------------------------------------------------------------
            /// <summary>
            /// The Application name.
            /// </summary>
            public const string App_Name                      = "SAO";
            /// <summary>
            /// The Format Flies.
            /// </summary>
            public const string FilesEnd_Name                 = ".Sao";
            /// <summary>
            /// Use it in the <see cref="SerializableAttribute"/> Classes.
            /// like: <see cref="ProfileInfo"/>
            /// </summary>
            public const string NotSet                        = "notSet";
            /// <summary>
            /// The Double Slash that you should use before the names in paths.
            /// </summary>
            public const string DoubleSlash                   = "\\";
            //-------------------------------------------
            //-------------------------------------------
            /// <summary>
            /// 
            /// </summary>
            public const string GameData_Directory_Name       = DoubleSlash + "GameDatas";
            /// <summary>
            /// 
            /// </summary>
            public const string ServerManager_Folder_Name     = DoubleSlash + "ServerManager";
            /// <summary>
            /// 
            /// </summary>
            public const string Data_Directory_Name           = DoubleSlash + "Data";
            /// <summary>
            /// Temporary Folder that should be deleted in the end of application running.
            /// </summary>
            public const string Temporary_Folder_Name         = DoubleSlash + 
                "a54-t47-e98-m29-p76-o44-r65-a10-r97-y66";
            //---------------------------
            /// <summary>
            /// 
            /// </summary>
            public const string Profile_First_Folder_Name     = DoubleSlash + "Profile";
            public const string ProfileInfo_File_Name         = DoubleSlash + "ProfileInfo" + FilesEnd_Name;
            //---------------------------
            //-------------------------------------------
            /// <summary>
            /// 
            /// </summary>
            public const string ServerConfiguration_File_Name = DoubleSlash + "ServerConfiguration" +
                FilesEnd_Name;
            /// <summary>
            /// You should use the 
            /// <see cref="AppSettings.CurrentProfileNum"/> in the front of this name.
            /// </summary>
            public const string Google_Generate_File_Name     = DoubleSlash + 
                "m97-G86-o40-o07-g24-l56-e45" + FilesEnd_Name;
            /// <summary>
            /// 
            /// </summary>
            public const string UpdateInfo_File_Name          = DoubleSlash + "UpdateInfo" + 
                FilesEnd_Name;
            /// <summary>
            ///
            /// </summary>
            public const string UpdateList_File_Name          = DoubleSlash + "UpdateList.dat";
            /// <summary>
            /// Account number and .Sao Must be added in the end of this parametter.
            /// </summary>
            public const string Account_Settings_File_Name    = DoubleSlash + "Settings" + 
                FilesEnd_Name;
            /// <summary>
            /// 
            /// </summary>
            public const string AccountInfo_File_Name         = DoubleSlash + "AccountInfo" + 
               FilesEnd_Name;
            /// <summary>
            /// 
            /// </summary>
            public const string ProfilesList_File_Name        = DoubleSlash + "ProfilesList.dat";
            //---------------------------------------------------------------------------------

            /// <summary>
            /// The main Path of SBM.
            /// It doesn't consist back slash (\) in the end of it.
            /// </summary>
            public static string main_Path                    =
                Environment.GetFolderPath(Environment.SpecialFolder.Programs) +
                DoubleSlash + App_Name;
            /// <summary>
            /// GameDatas Path that contains <see cref="Profile_Folder_Path"/>
            /// in it.
            /// Don't use it Directly for getting ProfilePath.
            /// You should use ProfilePath instead.
            /// </summary>
            public static string GameDatas_Path               = main_Path + GameData_Directory_Name;
            /// <summary>
            /// 
            /// </summary>
            public static string Datas_Path                   = main_Path + Data_Directory_Name;
            /// <summary>
            /// Notice: Please Don't use <see cref="AppSettings.CurrentProfileNum"/>,
            /// because I already used it in the <see cref="Profile_Folder_Path"/>
            /// </summary>
            /// <exception cref="FileNotFoundException"></exception>
            public static string Profile_Folder_Path
            {
                get
                {
                    return GameDatas_Path + Profile_First_Folder_Name +
                        AppSettings.CurrentProfileNum;
                }
            }
            /// <summary>
            /// get the ProfileInfo File Path with this property,
            /// use it in <see cref="ProfileInfo"/>
            /// </summary>
            public static string ProfileInfo_File_Path
            {
                get
                {
                    return Profile_Folder_Path + ProfileInfo_File_Name;
                }
            }
            /// <summary>
            /// Get the AccountInfoFile Path.
            /// Also check this: <see cref="AccountInfo_File_Name"/>
            /// </summary>
            public static string AccountInfo_File_Path
            {
                get
                {
                    return main_Path + AccountInfo_File_Name;
                }
            }
            /// <summary>
            /// Get the ProfileList file Path.
            /// Also check the <see cref="ProfilesList_File_Name"/>
            /// </summary>
            public static string ProfileList_File_Path
            {
                get
                {
                    return main_Path + ProfilesList_File_Name;
                }
            }

            //-------------------------------------------
            /*
            * public static string[] AccNames = new string[]
            * {
            *   "\\SAOTest - mrwoto175",
            *    "\\SAOTest - MST12",
            *    "\\SAOTest - fighterman",
            *    "\\SAOTest - unlasting",
            *    "\\SAOTest - mrwoto189"
            * };
            */
            /*
             * public static string WorldMap1_FileName = "\\WorldMap.png"; */
            /*
             * public static string FirstMusic = "\\SAO-WelcomeMusic.wav"; */
            /*
             * public static string CurrentAccount = AccNames[0]; */
            //---------------------------------------------------------------------------------
        }
        public struct ResourcesName
        {
            /// <summary>
            /// With Separate Character, please do NOT use it again.
            /// </summary>
            public const string End_Res_Name = Separate_Character + "Name";
            /// <summary>
            /// The name of FirstLable for Form1 in the Resources without _name;
            /// </summary>
            public const string FirstLabelNameInRes = "Label1";
            public const string Separate_Character = "_";
            //--------------------Labels----------------------------------
            
            //----------------------------------------------
            public const string Item1ForMainMenuNameInRes = "Item1";
            public const string Item2ForMainMenuNameInRes = "Item2";
            public const string Item3ForMainMenuNameInRes = "Item3";
            public const string Item4ForMainMenuNameInRes = "Item4";
            //-------------------Buttons----------------------------------
            
        }
        public struct Forming
        {
            /// <summary>
            /// The MainForm in the Application.
            /// in fact, it is the main menu and the game is different.
            /// </summary>
            public static MainForm TheMainForm { get; set; }
            public static GameClient GameClient
            {
                get
                {
                    return AppSettings.GameClient;
                }
                set
                {
                    AppSettings.GameClient = value;
                }
            }
        }
        public struct AppSettings
        {
            //--------------------------------------
            //-----------------
            /// <summary>
            /// E = English, J = Japanese
            /// </summary>
            public static char Language              = 'E';
            /// <summary>
            /// Please Notice that this is not an Index,
            /// so it should start with 1,
            /// and also the maximum value of this int would be: 
            /// <see cref="MAXIMUM_PROFILE"/>. <code></code>
            /// Use it in <see cref=""/>
            /// </summary>
            public static int CurrentProfileNum      = 1;
            public static CultureInfo CultureInfo    = new CultureInfo("en-US");
            //-----------------
            //--------------------------------------
            public static bool IsShowingClosedSandBox = false;
            public static NoInternetConnectionSandBox ConnectionClosedSandBox { get; set; }
            //--------------------------------------
            //-----------------
            public const string AppVersion          = "1.1.1.5014";
            public const string AppVerCodeName      = "5014Re";
            public const string AppVerToken         = "";
            public const string CompanyName         = "wotoTeam";
            public const string CompanyCopyRight    = "© wotoTeam - 2021";
            public const string DateTimeFormat      = "ddd, dd MMM yyyy HH:mm:ss 'GMT'";
            public const string TimeFormat          = "HH:mm:ss";
            public const string TimeRequestURL      = @"https://microsoft.com";
            public const string ConnectionURL       = @"http://google.com/generate_204";
            public const string DateHeaderKey       =  "date";
            //-----------------
            public const int MAXIMUM_PROFILE        = 64;
            //-----------------
            public const StringSplitOptions SplitOption = StringSplitOptions.RemoveEmptyEntries;
            //-------------------------------------
            /// <summary>
            /// Determine whether <see cref="GlobalTiming"/>, has been set with 
            /// interner: <see cref="TimeRequestURL"/>, or not.
            /// </summary>
            public static bool DateTimeSettedWithNet = false;
            /// <summary>
            /// The Time Worker.
            /// </summary>
            public static Timer TimeWorker           = new Timer();
            /// <summary>
            /// Global Timing worker.
            /// it will add seconds to the 
            /// <see cref="GlobalTiming"/>
            /// </summary>
            public static Trigger GlobalTimingWorker   { get; set; }
            /// <summary>
            /// Global Date and Time Parameter.
            /// </summary>
            public static IDateProvider<DateTime, Trigger, StrongString> GlobalTiming { get; set; }
            /// <summary>
            /// the default time out for database.
            /// </summary>
            public static TimeSpan DefaultDataBaseTimeOut { get; } = new TimeSpan(0, 0, 6);
            /// <summary>
            /// The Game Client of the game.
            /// this is after the main form.
            /// </summary>
            public static GameClient GameClient      { get; set; }
            public static WotoCreation WotoCreation { get; set; }
            //--------------------------------------
            public static IDECoderProvider<StrongString, QString> DECoder { get; set; }
            //--------------------------------------
            /// <summary>
            /// The Spaces between two GameControls in the game.
            /// the unit is pixel.
            /// </summary>
            public const int Between_GameControls    = 4;
            //--------------------------------------
        }
        #endregion
        //-------------------------------------------------
    }
#pragma warning restore IDE0055
}
