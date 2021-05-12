using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using WotoProvider.WotoTools;
using SAO.Constants;
using SAO.Controls;
using SAO.Controls.Music;
using SAO.Controls.Animation;
using SAO.SandBox;
using SAO.LoadingService;
using SAO.GameObjects.Resources;
using SAO.Security;

namespace SAO
{
    partial class MainForm
    {
        //-------------------------------------------------
        #region Ordinary Region for MainForm
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
            Application.Exit();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (!(this.SoundPlayer is null))
            {
                this.SoundPlayer.Stop();
            }
            base.OnClosing(e);
        }

        #endregion
        //-------------------------------------------------
        #region mrwoto Designing Region

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Size = Screen.PrimaryScreen.Bounds.Size;
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer, true);
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.SetAutoSizeMode(AutoSizeMode.GrowAndShrink);
            this.KeyPreview = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.Black;
            this.MyRes = new WotoRes(typeof(MainForm));
            this.BackgroundImage = (Image)MyRes.GetObject(EntryPicNameInRes +
                ((DateTime.Now.Second % EntryCount)).ToString());
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            SettingUpFonts();
            //-----------------------------------
            this.FirstLabel = new GameControls.LabelControl(this);
            this.SoundPlayer = new SoundPlayer(this, this);
            //-----------------------------------
            //Names:
            this.FirstLabel.SetLabelName(FirstLabelNameInRes);
            //TabIndexes:
            this.FirstLabel.TabIndex = 0;
            //FontAndTextAligns:
            this.FirstLabel.Font = new Font(PrivateFonts.Families[1]
                , 19, FontStyle.Bold);
            this.FirstLabel.TextAlign = ContentAlignment.MiddleCenter;
            //Sizes:
            this.FirstLabel.Size = 
                new Size(Width / 6, Height / 6);
            //Locations:
            this.FirstLabel.Location = new Point((Width - FirstLabel.Width) - 
                (2 * SandBoxBase.from_the_edge),
                (Height - FirstLabel.Height) - SandBoxBase.from_the_edge);
            //Colors:
            this.FirstLabel.ForeColor = Color.DarkSeaGreen;
            this.FirstLabel.BackColor = Color.Transparent;
            //ComboBoxes:
            //Enableds:
            //Texts:
            this.FirstLabel.SetLabelText();
            //MessageBox.Show(FirstLabel.Name);
            this.Text = "-- Sword Art Online --";
            //AddRanges:
            //ToolTipSettings:
            //-----------------------------------
            //Events:
            this.KeyDown += MainForm_KeyDown;
            this.Shown += MainForm_Shown;
            this.GotFocus += MainForm_GotFocus;
            this.KeyDown += Form1_KeyDown;
            this.Closing += MainForm_Closing;
            //----------------------------------
            //Controls:
            //----------------------------------
            this.ResumeLayout();
        }

        private async void MainForm_Closing(object sender, CancelEventArgs e)
        {
            await Task.Run(() =>
            {
                ThereIsConstants.Actions.ClearingUp();
            });
        }



        //private ChatManager test;
        public void PreparingMainMenu()
        {
            int nowH = DateTime.Now.ToLocalTime().Hour;
            this.BackgroundImage.Dispose();
            //----------------------------------------------------------
            //News:
            this.FirstLabel.Text    = string.Empty;
            this.MainMenuLoaded     = true;
            this.StartItem          = new GameControls.MenuItem(this);
            this.SettingsItem       = new GameControls.MenuItem(this);
            this.ExitItem           = new GameControls.MenuItem(this);
            this.LogoPictureBox     = new GameControls.PictureBoxControl(this, true);
            this.AnimationCompanies = new AnimationCompany[]
            {
                AnimationCompany.GetAnimationCompany(AnimationCompaniesList.DreamWorksCompany,
                    this),
            };
            //----------------------------------------------------------
            //Names:
            this.StartItem.SetLabelName(ThereIsConstants.ResourcesName.Item1ForMainMenuNameInRes);
            this.SettingsItem.SetLabelName(ThereIsConstants.ResourcesName.Item2ForMainMenuNameInRes);
            this.ExitItem.SetLabelName(ThereIsConstants.ResourcesName.Item3ForMainMenuNameInRes);
            //TabInexes:
            //FontsAndTextAligns:
            //PicturesSet:
            this.LogoPictureBox.BackgroundImageLayout = ImageLayout.Stretch;
            if (nowH < 19 && nowH > 7)
            {
                this.BackgroundImage = (Image)MyRes.GetObject(AinCradNameInRes + 1);
                this.LogoPictureBox.Image = (Image)MyRes.GetObject(LogoNameInRes + 1);
            }
            else
            {
                this.BackgroundImage = (Image)MyRes.GetObject(AinCradNameInRes + 2);
                this.LogoPictureBox.Image = (Image)MyRes.GetObject(LogoNameInRes + 2);
            }
            //Sizes:
            this.LogoPictureBox.Size = new Size(LogoPictureBox.Image.Width,
               2 * LogoPictureBox.Image.Height);
            //Locations:
            this.LogoPictureBox.Location = new Point(Width - LogoPictureBox.Width -
                (2 * ThereIsConstants.AppSettings.Between_GameControls),
                2 * ThereIsConstants.AppSettings.Between_GameControls);
            this.StartItem.OriginalLocation = this.StartItem.Location = 
                new Point(Width / 16, 2 * (Height / 19));
            this.SettingsItem.OriginalLocation = this.SettingsItem.Location = 
                new Point(StartItem.Location.X,
                    StartItem.Location.Y + StartItem.Height +
                    (4 * ThereIsConstants.AppSettings.Between_GameControls));
            this.ExitItem.OriginalLocation = this.ExitItem.Location = 
                new Point(SettingsItem.Location.X,
                    SettingsItem.Location.Y + SettingsItem.Height +
                    (4 * ThereIsConstants.AppSettings.Between_GameControls));
            //Colors:
            this.LogoPictureBox.BackColor = Color.Transparent;
            //ComboBoxes:
            //Enableds:
            this.StartItem.SingleClick = true;
            //Texts:
            this.StartItem.SetLabelText();
            this.SettingsItem.SetLabelText();
            this.ExitItem.SetLabelText();

            //AddRanges:
            //ToolTipSettings:
            //Music:
            this.SoundPlayer.Next(Album.GenerateAlbum(new wotoMusic[]
            {
                wotoMusic.GenerateWotoMusic(Musics.StoryOfThePast),
                wotoMusic.GenerateWotoMusic(Musics.ToTheGrandLine),
            }), true);
            //----------------------------------------------------------
            //Events:
            this.StartItem.Click += StartItem_Click;
            this.VisibleChanged += MainForm_VisibleChanged;
            
            //----------------------------------------------------------
            this.Controls.AddRange(new Control[]
            {
                LogoPictureBox,
                StartItem,
                SettingsItem,
                ExitItem
            });
            // Final Blow:
            for (int i = 0; i < this.AnimationCompanies.Length; i++)
            {
                this.AnimationCompanies[i].Apply(false);
            }
        }
        private void MainForm_VisibleChanged(object sender, EventArgs e)
        {
            if(ThereIsConstants.Forming.GameClient != null)
            {
                ReleaseAllResources();
            }
        }

        private void StartItem_Click(object sender, EventArgs e)
        {

            if (Directory.Exists(ThereIsConstants.Path.Profile_Folder_Path) &&
                File.Exists(ThereIsConstants.Path.ProfileInfo_File_Path))
            {
                ProfileInfo myInfo = ProfileInfo.FromFile(ThereIsConstants.Path.ProfileInfo_File_Path);
                CreateProfileSandBox myCreate = new CreateProfileSandBox(this, myInfo, true);
                this.IsShowingSandBox = true;
                this.ShowingSandBox = myCreate;
                myCreate.Show();
                this.Enabled = false;
                myCreate.Location = new Point((this.Width / 2) - (myCreate.Width / 2),
                    (this.Height / 2) - (myCreate.Height / 2));
                myCreate.FormClosed += CreateNewProfileSandBox_FormClosed;
            }
            else
            {
                this.IsShowingSandBox = true;
                this.ShowingSandBox = new CreateProfileSandBox(this);
                this.ShowingSandBox.Show();
                this.Enabled = false;
                this.ShowingSandBox.Location = new Point((this.Width / 2) - 
                    (ShowingSandBox.Width / 2),
                    (this.Height / 2) - (ShowingSandBox.Height / 2));
                this.ShowingSandBox.FormClosed += CreateNewProfileSandBox_FormClosed;
            }

            this.StartItem.HasMouseClickedOnce = false;
        }

        private void CreateNewProfileSandBox_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (ShowingSandBox.ClosedByMe)
            {
                this.Enabled = true;
                this.ShowingSandBox = null;
                this.IsShowingSandBox = false;
            }
            else
            {
                this.Enabled = true;
                this.ShowingSandBox = null;
                this.IsShowingSandBox = false;
                this.Close();
            }
        }

        private void MainForm_GotFocus(object sender, EventArgs e)
        {
            if (Focused)
            {
                if (IsShowingSandBox)
                {
                    ShowingSandBox.GetTheHighestSandBox(true);
                }
            }
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.F10)
            {
                ServerConfiguration test1 = new ServerConfiguration();
                test1.Show();
                test1.Focus();
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            /*if(e.KeyCode == Keys.Enter)
            {
                MessageBox.Show(Width + "  " + Height);
            }
            */
            /*
            if (e.KeyCode == Keys.F8)
            {
                for(; ; )
                {
                    Chat_Icons now = (Chat_Icons)test;
                    GameIcon icon = GameIcon.GenerateIcon(now);
                    this.LogoPictureBox.Image = icon.OriginalImage;
                    MessageBox.Show(now.ToString());
                    if (icon.HasClicked)
                    {
                        this.LogoPictureBox.Image = icon.ClickedImage;
                    }
                    test++;
                    MessageBox.Show(now.ToString());
                    if (test == 5)
                    {
                        break;
                    }
                }
            }
            */


        }
        private async void MainForm_Shown(object sender, EventArgs e)
        {
            bool Mine = false;
            //---------------------------------------------
            this.Controls.AddRange(new Control[]
            {
                this.FirstLabel
            });
            this.FirstLabel.Refresh();
            //---------------------------------------------
            if (Taskbar.IsShowing && sender is MainForm)
            {
                this.Shown -= MainForm_Shown;
                Taskbar.Hide();
            }
            await Task.Run(() =>
            {
                ThereIsConstants.Actions.CheckForInternetConnection(ref Mine);
            });
            if (Mine)
            {
                //DateTime Current = ThereIsConstants.Actions.GetNistTime();
                //Current = Current.ToLocalTime();
                this.FirstLabel.Text = "Checking for updates...";
                this.IsConnecting = false;
                this.IsShowingSandBox = false;
                this.IsCheckingForUpdate = true;
                //ThereIsConstants.AppSettings.AppDateTime = Current;
                //ThereIsConstants.AppSettings.DateTimeSettedWithNet = true;
                ThereIsConstants.Actions.IsLastVersion();
                //System.Threading.Thread.Sleep(2000);
            }
            else
            {
                NoInternetConnectionSandBox myTest = new NoInternetConnectionSandBox(this);
                this.IsShowingSandBox = true;
                this.ShowingSandBox = myTest;
                myTest.Show();
                myTest.Location = new Point((this.Width / 2) - (myTest.Width / 2), 
                    (this.Height / 2) - (myTest.Height / 2));
                myTest.ClosedForRetry = false;
                //-----------------------------------------------
                myTest.FormClosed += MyTest_FormClosed;
                myTest.ButtonControl1.Click += ButtonControl1_Click;
                myTest.ButtonControl2.Click += ButtonControl2_Click;
                //------------------------------------------------
            }
            
        }
        //-------------------------------------------------------------------
        private void PreparingServerOnBreakSandBox()
        {
            ServerBreakSandBox mySandBox = new ServerBreakSandBox(this);
            this.IsShowingSandBox = true;
            this.ShowingSandBox = mySandBox;
            mySandBox.Show();
            mySandBox.Location = new Point((this.Width / 2) - (mySandBox.Width / 2),
                (this.Height / 2) - (mySandBox.Height / 2));
            mySandBox.ClosedForRetry = false;
            //-----------------------------------------------
            mySandBox.FormClosed += MyTest_FormClosed;
            mySandBox.ButtonControl1.Click += ButtonControl1_Click;
            mySandBox.ButtonControl2.Click += ButtonControl2_Click;
            //------------------------------------------------
        }
        private void PreparingServerIsUpdatingSandBox(StrongString releaseDate)
        {
            UpdatingServerSandBox mySandBox = new UpdatingServerSandBox(this, ref releaseDate);
            this.IsShowingSandBox = true;
            this.ShowingSandBox = mySandBox;
            mySandBox.Show();
            mySandBox.Location = new Point((this.Width / 2) - (mySandBox.Width / 2),
                (this.Height / 2) - (mySandBox.Height / 2));
            mySandBox.ClosedForRetry = false;
            //-----------------------------------------------
            mySandBox.FormClosed += MyTest_FormClosed;
            mySandBox.ButtonControl1.Click += ButtonControl1_Click;
            mySandBox.ButtonControl2.Click += ButtonControl2_Click;
            //------------------------------------------------
        }
        private async void ButtonControl2_Click(object sender, EventArgs e)
        {
            SandBoxBase Father = (SandBoxBase)(((Button)sender).Parent);
            if(Father is NoInternetConnectionSandBox)
            {
                ((NoInternetConnectionSandBox)Father).ClosedForRetry = true;
            }
            else if(Father is ServerBreakSandBox)
            {
                ((ServerBreakSandBox)Father).ClosedForRetry = true;
            }
            else if (Father is UpdatingServerSandBox)
            {
                ((UpdatingServerSandBox)Father).ClosedForRetry = true;
            }
            Enabled = true;
            ((Button)sender).Enabled = false;
            this.FirstLabel.SetLabelText();
            Focus();
            Father.Close();
            Father.Dispose();
            this.IsConnecting = true;
            this.IsShowingSandBox = false;
            this.IsCheckingForUpdate = false;
            this.IsCheckingForUpdateEnded = false;
            this.IsTheLastVer = false;
            this.IsServerOnBreak = false;
            this.IsServerUpdating = false;
            this.IsServerOnline = false;
            this.ReleasingDate = null;
            GC.Collect();
            await Task.Run(() =>
            {
                Thread.Sleep(2000);
            });
            MainForm_Shown(sender, e);
        }

        private void MyTest_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(sender is NoInternetConnectionSandBox)
            {
                NoInternetConnectionSandBox Father = (NoInternetConnectionSandBox)sender;
                if (Father.ClosedForRetry)
                {

                }
                else
                {
                    Close();
                }
            }
            else if(sender is ServerBreakSandBox)
            {
                ServerBreakSandBox Father = (ServerBreakSandBox)sender;
                if (Father.ClosedForRetry)
                {

                }
                else
                {
                    Close();
                }
            }
            else if (sender is UpdatingServerSandBox)
            {
                UpdatingServerSandBox Father = (UpdatingServerSandBox)sender;
                if (Father.ClosedForRetry)
                {

                }
                else
                {
                    Close();
                }
            }
        }

        private void ButtonControl1_Click(object sender, EventArgs e)
        {
            SandBoxBase Father = (SandBoxBase)(((Button)sender).Parent);
            if(Father is NoInternetConnectionSandBox)
            {
                ((NoInternetConnectionSandBox)Father).ClosedForRetry = false;
            }
            else if(Father is ServerBreakSandBox)
            {
                ((ServerBreakSandBox)Father).ClosedForRetry = false;
            }
            else if (Father is UpdatingServerSandBox)
            {
                ((UpdatingServerSandBox)Father).ClosedForRetry = false;
            }
            Father.Close();
            Father.Dispose(); 
            this.IsConnecting = true;
            this.IsShowingSandBox = false;
            this.IsCheckingForUpdate = false;
            this.IsCheckingForUpdateEnded = false;
            this.IsTheLastVer = false;
            this.IsServerOnBreak = false;
            this.IsServerUpdating = false;
            this.IsServerOnline = false;
            this.ReleasingDate = null;
            GC.Collect();
        }
        //-----------------------------------------------------------------
        /// <summary>
        /// this method will be clled by windows.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
        }

        //---------------------------------------------------------
        private void ReleaseRecollection()
        {
            this.LogoPictureBox.Image.Dispose();
            this.LogoPictureBox.Dispose();
            this.FirstLabel.Dispose();
            this.StartItem.Dispose();
            this.SettingsItem.Dispose();
            this.ExitItem.Dispose();
            this.BackgroundImage.Dispose();
            if (this.ShowingSandBox != null)
            {
                this.ShowingSandBox.Dispose();
            }
            this.ShowingSandBox = null;
            this.SoundPlayer.Dispose();
            GC.Collect();
        }
        //-----------------------------------------------------------
        #endregion
        //-------------------------------------------------
    }
}

