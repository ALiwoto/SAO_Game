using System.IO;
using System.Windows.Forms;
using System.Drawing.Text;
using WotoProvider;
using SAO.Constants;
using SAO.Controls;
using SAO.LoadingService;
using SAO.SandBox;
using SAO.Controls.Music;
using SAO.GameObjects.Resources;
using SAO.GameObjects.Characters;
using SAO.Security;

namespace SAO
{
    public partial class MainForm : GameControls.PageControl, IRes
    {
        public PrivateFontCollection PrivateFonts { get; set; }
        //--------------------------------------------
        public GameControls.LabelControl FirstLabel { get; set; }
        public GameControls.MenuItem StartItem { get; set; }
        public GameControls.MenuItem SettingsItem { get; set; }
        public GameControls.MenuItem ExitItem { get; set; }
        public SoundPlayer SoundPlayer { get; set; }
        /// <summary>
        /// There is a Image in the resources named logo1,
        /// that Image should appear in the Main page, where the user decide to
        /// start the game or leave it.
        /// </summary>
        public GameControls.PictureBoxControl LogoPictureBox { get; set; }
        public WotoRes MyRes { get; set; }
        public SandBoxBase ShowingSandBox { get; set; }
        //---------------------------------------------
        public bool IsConnecting { get; set; }
        public bool IsShowingSandBox { get; set; }
        public bool IsCheckingForUpdate { get; set; }
        public bool IsCheckingForUpdateEnded { get; set; }
        public bool IsTheLastVer { get; set; }
        public bool IsServerOnBreak { get; set; }
        public bool IsServerUpdating { get; set; }
        public bool IsServerOnline { get; set; }
        public bool IsTheFirstTime { get; set; }
        /// <summary>
        /// NOTE: this value is just a bool for the DateTimeWorker
        /// </summary>
        public bool MainMenuLoaded { get; set; }
        public bool CloseRequstFromSandBos { get; private set; }
        //-------------------------------------------------
        public StrongString ReleasingDate { get; set; } = null;
        //-------------------------------------------------
        //---------------------------------
        /// <summary>
        /// This is 8.
        /// </summary>
        public const uint EntryCount = 0b1000;
        //---------------------------------

        //-------------------------------------------------
        public MainForm()
        {

            IsConnecting                = true;
            IsShowingSandBox            = false;
            IsCheckingForUpdate         = false;
            IsCheckingForUpdateEnded    = false;
            IsTheLastVer                = false;
            IsServerOnBreak             = false;
            IsServerUpdating            = false;
            IsServerOnline              = false;
            IsTheFirstTime              = false;
            MainMenuLoaded              = false;
            ReleasingDate               = null;
            //-------------------------------------
            ThereIsConstants.AppSettings.DECoder = new DECoder();
            if (ThereIsConstants.Forming.TheMainForm == null)
            {
                ThereIsConstants.Forming.TheMainForm = this;
            }

            InitializeComponent();
            if (!Directory.Exists(ThereIsConstants.Path.main_Path +
                ThereIsConstants.Path.Temporary_Folder_Name))
            {
                Directory.CreateDirectory(ThereIsConstants.Path.main_Path +
                ThereIsConstants.Path.Temporary_Folder_Name);
            }
            else
            {
                Directory.Delete(ThereIsConstants.Path.main_Path +
                ThereIsConstants.Path.Temporary_Folder_Name, true);
                Directory.CreateDirectory(ThereIsConstants.Path.main_Path +
                ThereIsConstants.Path.Temporary_Folder_Name);
            }
            ThereIsConstants.AppSettings.TimeWorker.Enabled = true;
            ThereIsConstants.AppSettings.TimeWorker.Interval = 1000;
            ThereIsConstants.AppSettings.TimeWorker.Tick += ThereIsConstants.Actions.TimeWorkerWorks;
            ThereIsConstants.AppSettings.WotoCreation = WotoCreation.GenerateWotoCreation();





            //UnlimitedBladeWorks();
            /*
            Hero myHero1 = Hero.GenerateHero(GameObjects.Players.PlayerElement.WaterElement), 
                myHero2;
            for(; ; )
            {
                myHero2 = Hero.GenerateHero(GameObjects.Players.PlayerElement.WindElement);
                MessageBox.Show(myHero2.HP.ToString());
            }
            
            */

        }
        //----------------------------------------
        public void ShowTheServerOnBreakSandBox()
        {
            PreparingServerOnBreakSandBox();
        }
        public void ShowTheUpdatingServerSandBox()
        {
            PreparingServerIsUpdatingSandBox(ReleasingDate);
        }
        //----------------------------------------
        public void SettingUpFiles()
        {
            if(!File.Exists(ThereIsConstants.Path.AccountInfo_File_Path))
            {
                AccountInfo myInfo = new AccountInfo();
                AccountInfo.UpdateInfo(myInfo, ThereIsConstants.Path.AccountInfo_File_Path);
                if(File.Exists(ThereIsConstants.Path.main_Path +
                    ThereIsConstants.Path.ProfilesList_File_Name))
                {
                    File.Delete(ThereIsConstants.Path.main_Path +
                    ThereIsConstants.Path.ProfilesList_File_Name);
                }
            }
            else
            {
                AccountInfo theInfo = 
                    AccountInfo.FromFile(ThereIsConstants.Path.AccountInfo_File_Path);
                theInfo.LastLogin = 
                    ThereIsConstants.AppSettings.GlobalTiming.GetString(false).GetValue();
                AccountInfo.UpdateInfo(theInfo, ThereIsConstants.Path.AccountInfo_File_Path);
                if (!File.Exists(ThereIsConstants.Path.main_Path +
                ThereIsConstants.Path.ProfilesList_File_Name))
                {
                    File.Delete(ThereIsConstants.Path.main_Path +
                        ThereIsConstants.Path.AccountInfo_File_Name);

                    AccountInfo myInfo = new AccountInfo();
                    AccountInfo.UpdateInfo(myInfo, ThereIsConstants.Path.AccountInfo_File_Path);
                }
            }
            if (!File.Exists(ThereIsConstants.Path.main_Path +
                ThereIsConstants.Path.ProfilesList_File_Name))
            {
                FileStream myFile = new FileStream(ThereIsConstants.Path.main_Path +
                ThereIsConstants.Path.ProfilesList_File_Name, FileMode.OpenOrCreate, FileAccess.Write);
                BinaryWriter writer = new BinaryWriter(myFile);
                ProfilesList myList = new ProfilesList();
                for(int i = 0; i < ThereIsConstants.AppSettings.MAXIMUM_PROFILE; i++)
                {
                    myFile.Position = i * ProfilesList.SIZE;
                    writer.Write(myList.ProfileName);
                    writer.Write(myList.LastLogin);
                    writer.Write(myList.Description);
                }
                myFile.Close();
                writer.Close();
                myFile.Dispose();
                writer.Dispose();
            }
            if(!Directory.Exists(ThereIsConstants.Path.main_Path +
                ThereIsConstants.Path.GameData_Directory_Name))
            {
                Directory.CreateDirectory(ThereIsConstants.Path.main_Path +
                ThereIsConstants.Path.GameData_Directory_Name);
            }
        }
        private void SettingUpFonts()
        {
            
            PrivateFonts = new PrivateFontCollection();
            PrivateFonts.AddFontFile(ThereIsConstants.Path.Datas_Path + 
                ThereIsConstants.Path.DoubleSlash +
                MyRes.GetString(SAOFontFileNameInRes));
            PrivateFonts.AddFontFile(ThereIsConstants.Path.Datas_Path +
                ThereIsConstants.Path.DoubleSlash +
                MyRes.GetString(OldStoryFileNameInRes));


            /*
            //Create your private font collection object.
            PrivateFonts = new PrivateFontCollection();

            //Select your font from the resources.
            //My font here is "Digireu.ttf"
            int fontLength = Properties.Resources.SAOWelcomeTT_Bold.Length;

            // create a buffer to read in to
            byte[] fontdata = Properties.Resources.SAOWelcomeTT_Bold;

            // create an unsafe memory block for the font data
            IntPtr data = Marshal.AllocCoTaskMem(fontLength);

            // copy the bytes to the unsafe memory block
            Marshal.Copy(fontdata, 0, data, fontLength);

            // pass the font to the font collection
            PrivateFonts.AddMemoryFont(data, fontLength);
            */
        }
        //----------------------------------------
        /// <summary>
        /// Coming Up when the program is reRunning :)
        /// </summary>
        public void ComeOnUp()
        {

            if(ThereIsConstants.Forming.GameClient != null)
            {
                ThereIsConstants.Forming.GameClient.WindowState = FormWindowState.Normal;
                if (ThereIsConstants.Forming.GameClient.IsShowingSandBox)
                {
                    ThereIsConstants.Forming.GameClient.Show();
                    ThereIsConstants.Forming.GameClient.Focus();
                    ThereIsConstants.Forming.GameClient.ShowingSandBox.GetTheHighestSandBox(true);
                }
                else
                {
                    ThereIsConstants.Forming.GameClient.Focus();
                }
            }
            else
            {
                WindowState = FormWindowState.Normal;
                if (ThereIsConstants.Forming.TheMainForm == null)
                {
                    ThereIsConstants.Forming.TheMainForm = this;
                }
                if (IsShowingSandBox)
                {
                    ShowingSandBox.GetTheHighestSandBox(true);
                    Enabled = false;
                }
                else
                {
                    Show();
                    Focus();
                }
            }
            
        }
        /// <summary>
        /// Releasing All resources that you created in this Form.
        /// </summary>
        public void ReleaseAllResources()
        {
            ReleaseRecollection();
        }
    }
    //---------------------------------------
    //---------------------------------------
    partial class MainForm
    {
        //Strings for Resources in MainForm...
        public const string FirstLabelNameInRes = "Label1"; 
        public const string EntryPicNameInRes = "SwordEntry";
        public const string SAOFontFileNameInRes = "FirstFontFile_Name";
        public const string OldStoryFileNameInRes = "SecondFontFile_Name";
        public const string AinCradNameInRes = "Aincrad";
        public const string LogoNameInRes = "logo";
    }
    partial class MainForm
    {
        public void UnlimitedBladeWorks()
        {
            /*
            DialogContext myTest = new DialogContext("d_1_1_2");
            myTest.EditDialog(0, "Tohsaka", 1, "There are 7 types of Elements in this world,\n" +
                "you should select one of them as your main Element.", true);
            myTest.UpdateDialog();
            */


            DialogContext myTest = new DialogContext(Dialogs.Dialog1_1_4);

            myTest.AddDialog(GameCharacters.Kirito_The_BlackSwordsman.ToString(),
                1, "The church??!\n" +
                "Why are we here??", true);
            myTest.AddDialog(GameCharacters.Archbishop,
                1, "You guys have been summoned here " +
                "to help us.", false);
            myTest.AddDialog(GameCharacters.Kirito_The_BlackSwordsman,
                1, "To help you??", true);


            myTest.UpdateDialog();

            /*
            DialogContext myTest = new DialogContext(Dialogs.Dialog1_1_4, true);
            myTest.AddDialog(GameCharacters.Archbishop.ToString(),
                1, "Welcome to our fatherland, Koji Empire,\n" +
                "courageous Heroes.");

            myTest.AddDialog(GameCharacters.Kirito_The_BlackSwordsman.ToString(),
                1, "Where are we??");

            myTest.AddDialog(GameCharacters.Archbishop.ToString(),
                1, "You are in the Great Holy Church of the Koji Empire ...");

            myTest.UpdateDialog();
            */


            /*
            DialogContext myTest2 = new DialogContext("d_1_1_3", true);
            myTest2.AddDialog("Kotomine", 1, "There are 5 Kingdoms in the Koji Empire");
            myTest2.AddDialog("Kotomine", 1, "But The Dark-Lord ruined the centeral kingdom,\n" +
                "so basically The Koji Empire has 4 kingdoms at this time...");
            myTest2.AddDialog("Kotomine", 1, "Select one of these kingdoms in the map...");
            myTest2.UpdateDialog();
            */

            /*
            Hero.CreateHero(
                HeroSerialize.GenerateHeroSerialize(
                    "6002", "Ducker",
                    HeroSkill.GenerateHeroSkill(
                        new Skill[]
                        {
                            Skill.GenerateSkill("Assualt", // The Skill Name
                            0, // This is the Skill index
                                SkillRate.GenerateSkillRate(
                                    new Unit(2), // Skill HP Rate
                                    new Unit(6), // Skill ATK Rate
                                    new Unit(2),// Skill INT Rate
                                    new Unit(0),// Skill DEF Rate
                                    new Unit(2),// Skill RES Rate
                                    new Unit(4),// Skill SPD Rate
                                    new Unit(1),// Skill PEN Rate
                                    new Unit(0)),// Skill Block Rate
                                "6002", // This is the Hero ID
                                @"C:\Users\mrwoto\Programming\Project\SAO\myImages\Skills\64_64\1022.png" // Skill Image
                                ),
                            Skill.GenerateSkill("Sharp Dagger", // This is the Skill Name
                            1, // This is the Skill index.
                                SkillRate.GenerateSkillRate(
                                    new Unit(4), // Skill HP Rate
                                    new Unit(12), // Skill ATK Rate
                                    new Unit(6), // Skill INT Rate
                                    new Unit(1), // Skill DEF Rate
                                    new Unit(2), // Skill RES Rate
                                    new Unit(4), // Skill SPD Rate
                                    new Unit(0), // Skill PEN Rate
                                    new Unit(14)), // Skill Block Rate
                                "6002", // This is the Hero ID
                                @"C:\Users\mrwoto\Programming\Project\SAO\myImages\Skills\64_64\2022.png") // Skill's Image
                        }
                            ).GetForSerialize(), 
                    2,  // This is Skill's Count
                    WotoProvider.Enums.HeroType.CommonHero,
                    GameObjects.Players.PlayerElement.WindElement,
                             new Unit(8), // HP Rate
                             new Unit(16), // ATK Rate
                             new Unit(4), // INT Rate
                             new Unit(2), // DEF Rate
                             new Unit(4), // RES Rate
                             new Unit(6), // SPD Rate
                             new Unit(4), // PEN Rate
                             new Unit(2), // Block Rate
                             @"C:\Users\mrwoto\Programming\Project\SAO\myImages\Heroes_580_500\1022.png"
                                    ));
            
            */

        }
    }


}
