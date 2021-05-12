// Copyright (C) ALiwoto 2019 - 2020
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of the source code.

using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using SAO.Controls;
using SAO.Constants;
using SAO.GameObjects.Players;
using SAO.GameObjects.ServerObjects;
using SAO.GameObjects.Resources;

namespace SAO.SandBox
{
    partial class CreateProfileSandBox
    {
        //-------------------------------------------------
        #region Initializes Region
        //-----------------------------------------
        private void InitializeComponent()
        {
            this.SuspendLayout();
            //----------------------------------------------
            //Almost all of the Form Settings, setted in the SandBoxBase class, so you don't need
            // to set something in this place...
            this.Dock = DockStyle.None;
            this.HelpButton = false;
            this.Size = new Size((3 * Width) / 4, (5 * Height) / 3);
            //----------------------------------------------
            this.MyRes          = new WotoRes(typeof(CreateProfileSandBox));
            this.MessageLabel1  = new GameControls.LabelControl(this);
            this.MessageLabel2  = new GameControls.LabelControl(this);
            this.MessageLabel3  = new GameControls.LabelControl(this);
            this.MessageLabel4  = new GameControls.LabelControl(this);
            this.MessageLabel5  = new GameControls.LabelControl(this);
            this.TextBox1       = new GameControls.TextBoxControl();
            this.TextBox2       = new GameControls.TextBoxControl();
            this.TextBox3       = new GameControls.TextBoxControl();
            this.ButtonControl1 = new GameControls.ButtonControl(this);
            this.ButtonControl2 = new GameControls.ButtonControl(this);
            //----------------------------------------------
            //names:
            this.MessageLabel1.SetLabelName(SandBoxLabel1NameInRes);
            this.MessageLabel2.SetLabelName(SandBoxLabel2NameInRes);
            this.MessageLabel3.SetLabelName(SandBoxLabel3NameInRes);
            this.MessageLabel4.SetLabelName(SandBoxLabel4NameInRes);
            this.MessageLabel5.SetLabelName(SandBoxLabel5NameInRes);
            this.ButtonControl1.SetButtonName(SandBoxButton1NameInRes);
            this.ButtonControl2.SetButtonName(SandBoxButton2NameInRes);
            //TabIndexes:
            this.MessageLabel1.TabIndex = 0;
            this.MessageLabel2.TabIndex = 1;
            this.TextBox1.TabIndex = 2;
            this.TextBox2.TabIndex = 3;
            this.TextBox3.TabIndex = 4;
            this.ButtonControl1.TabIndex = 5;
            this.ButtonControl2.TabIndex = 6;
            //FontAndTextAligns:
            this.MessageLabel1.Font = new Font(ThereIsConstants.Forming.TheMainForm.PrivateFonts.Families[1]
                    , 18, FontStyle.Bold);
            this.MessageLabel2.Font = this.MessageLabel3.Font = MessageLabel4.Font =
                new Font(ThereIsConstants.Forming.TheMainForm.PrivateFonts.Families[1]
                    , 14, FontStyle.Bold);
            this.MessageLabel5.Font =
                new Font(ThereIsConstants.Forming.TheMainForm.PrivateFonts.Families[1]
                , 13, FontStyle.Bold | FontStyle.Underline);
            this.ButtonControl1.Font = this.ButtonControl2.Font = 
                new Font(ThereIsConstants.Forming.TheMainForm.PrivateFonts.Families[1],
                14.3f, FontStyle.Bold);
            this.TextBox1.Font = this.TextBox2.Font = this.TextBox3.Font =
                new Font(ThereIsConstants.Forming.TheMainForm.PrivateFonts.Families[1]
                    , 15, FontStyle.Bold);
            this.TextBox2.PasswordChar = TextBox3.PasswordChar = '*';
            this.MessageLabel1.TextAlign = MessageLabel5.TextAlign =
                ContentAlignment.MiddleCenter;
            this.MessageLabel2.TextAlign = MessageLabel3.TextAlign = MessageLabel4.TextAlign =
                ContentAlignment.MiddleLeft;
            this.TextBox1.TextAlign = TextBox2.TextAlign = TextBox3.TextAlign =
                HorizontalAlignment.Center;
            //Styles:
            this.ButtonControl1.FlatStyle = this.ButtonControl2.FlatStyle = FlatStyle.Flat;
            //Sizes:
            this.MessageLabel1.Size = new Size(Width - from_the_edge,
                (Height / 6) - (SeparatorLine_Height / 2));
            this.MessageLabel2.Size = this.MessageLabel3.Size = MessageLabel4.Size =
                new Size(Width - (10 * from_the_edge),
                (1 * (Height / 8)) - (4 * SeparatorLine_Height));
            this.MessageLabel5.Size = new Size(Width - (25 * from_the_edge),
                (1 * (Height / 8)) - (4 * SeparatorLine_Height));
            this.TextBox1.Size = TextBox2.Size = TextBox3.Size =
                new Size(Width - (4 * from_the_edge),
                (1 * (Height / 7)) - (SeparatorLine_Height / 2));
            this.ButtonControl1.Size = ButtonControl2.Size =
                new Size((int)(1.4 * ButtonControl1.Width),
                (int)(1.6 * ButtonControl1.Height));
            this.ButtonControl1.SetOriginalSize(this.ButtonControl1.Size);
            this.ButtonControl2.SetOriginalSize(this.ButtonControl2.Size);
            //Locations:
            this.MessageLabel2.Dock = DockStyle.None;
            this.MessageLabel1.Location = new Point(from_the_edge / 2, 0);
            this.MessageLabel2.Location = new Point(MessageLabel1.Location.X +
                (MessageLabel1.Width / 2) - (MessageLabel2.Width / 2),
                MessageLabel1.Location.Y +
                MessageLabel1.Height + SeparatorLine_Height);
            this.TextBox1.Location = new Point(MessageLabel1.Location.X +
                (MessageLabel1.Width / 2) - (TextBox1.Width / 2),
                MessageLabel2.Location.Y + MessageLabel2.Height +
                SeparatorLine_Height);
            this.MessageLabel3.Location = new Point(MessageLabel2.Location.X,
                TextBox1.Location.Y + TextBox1.Height +
                (2 * SeparatorLine_Height));
            this.TextBox2.Location = new Point(MessageLabel1.Location.X +
                (MessageLabel1.Width / 2) - (TextBox2.Width / 2),
                MessageLabel3.Location.Y + MessageLabel3.Height +
                SeparatorLine_Height);
            this.MessageLabel4.Location = new Point(MessageLabel2.Location.X,
                TextBox2.Location.Y + TextBox2.Height +
                (2 * SeparatorLine_Height));
            this.TextBox3.Location = new Point(MessageLabel1.Location.X +
                (MessageLabel1.Width / 2) - (TextBox3.Width / 2),
                MessageLabel4.Location.Y + MessageLabel4.Height +
                SeparatorLine_Height);
            this.MessageLabel5.Location = new Point(MessageLabel3.Location.X + 
                (MessageLabel3.Width / 2) - (MessageLabel5.Width / 2),
                TextBox3.Location.Y + TextBox3.Height +
                SeparatorLine_Height + (1 * from_the_edge));
            this.ButtonControl1.Location = new Point((MessageLabel2.Location.X +
                (MessageLabel2.Width / 2)) - (ButtonControl1.Width / 2) - (6 * from_the_edge),
                MessageLabel5.Location.Y + MessageLabel5.Height +
                (3 * ThereIsConstants.AppSettings.Between_GameControls));
            this.ButtonControl2.Location = new Point(ButtonControl1.Location.X +
                ButtonControl1.Width + (6 * ThereIsConstants.AppSettings.Between_GameControls)
                , ButtonControl1.Location.Y);
            this.ButtonControl1.SetOriginalLocation(ButtonControl1.Location);
            this.ButtonControl2.SetOriginalLocation(ButtonControl2.Location);
            //Colors:
            this.MessageLabel1.SetColorTransparent();
            this.MessageLabel2.SetColorTransparent();
            this.ButtonControl1.ForeColor = this.ButtonControl2.ForeColor = Color.White;
            this.MessageLabel2.ForeColor = this.MessageLabel3.ForeColor = this.MessageLabel4.ForeColor =
                MessageLabel5.ForeColor =
                Color.White;
            this.ButtonControl1.BackColor = this.ButtonControl2.BackColor = Color.Black;
            this.MessageLabel1.ForeColor = MessageLabel2.ForeColor = Color.White;
            //ComboBoxes:
            //Enableds:
            this.TextBox1.UseCustomToolTip =
            this.TextBox2.UseCustomToolTip =
            this.TextBox3.UseCustomToolTip =
                true;
            this.TextBox1.AllowDrop = true;
            //Texts:
            this.MessageLabel1.SetLabelText();
            this.MessageLabel2.SetLabelText();
            this.MessageLabel3.SetLabelText();
            this.MessageLabel4.SetLabelText();
            this.MessageLabel5.SetLabelText();
            this.ButtonControl1.SetButtonText();
            this.ButtonControl2.SetButtonText();

            //AddRanges:
            //ToolTipSettings:
            //----------------------------------------------
            //Events:
            this.TextBox1.TextChanged += TextBox2_TextChanged;
            this.TextBox2.TextChanged += TextBox2_TextChanged;
            this.TextBox3.TextChanged += TextBox2_TextChanged;
            this.MessageLabel1.MouseDown += SandBoxBase_MouseDown;
            this.MessageLabel2.MouseDown += SandBoxBase_MouseDown;
            this.MessageLabel5.MouseEnter += MessageLabel5_MouseEnter;
            this.MessageLabel5.MouseLeave += MessageLabel5_MouseLeave;
            this.MessageLabel5.Click += MessageLabel5_Click;
            this.ButtonControl1.Click += ButtonControl1_Click;
            this.ButtonControl2.Click += ButtonControl2_Click;
            this.Paint += CreateProfileSandBox_Paint;
            this.EnabledChanged += CreateProfileSandBox_EnabledChanged;
            this.GotFocus += CreateProfileSandBox_GotFocus;
            //----------------------------------------------
            Controls.AddRange(new Control[]
            {
                MessageLabel1,
                MessageLabel2,
                MessageLabel3,
                MessageLabel4,
                MessageLabel5,
                TextBox1,
                TextBox2,
                TextBox3,
                ButtonControl1,
                ButtonControl2
            });
            //---------------------------------------------
            this.ResumeLayout();
        }
        //-----------------------------------------
        private void Initialize_LinkStart()
        {
            //----------------------------------------------
            //Almost all of the Form Settings, setted in the SandBoxBase class, so you don't need
            // to set something in this place...
            this.Dock = DockStyle.None;
            //this.Focused = true;
            this.HelpButton = false;
            this.Size = new Size((3 * Width) / 4, (5 * Height) / 3);
            
            this.BackgroundImageLayout = ImageLayout.Center;
            //----------------------------------------------
            this.MyRes = new WotoRes(typeof(CreateProfileSandBox));
            this.BackgroundImage = Image.FromFile(ThereIsConstants.Path.Datas_Path +
                ThereIsConstants.Path.DoubleSlash + MyRes.GetString(TheBackGroundNameInRes));
            this.MessageLabel1 = new GameControls.LabelControl(this);
            this.MessageLabel2 = new GameControls.LabelControl(this);
            this.CancelButton = this.CloseLabel = new GameControls.CloseLabel(this, this);
            this.MessageLabel4 =
                new GameControls.LabelControl(this, GameControls.LabelControlSpecies.LinkStart, this);
            this.MessageLabel5 = new GameControls.LabelControl(this);
            this.TextBox1 = new GameControls.TextBoxControl();
            this.AnimationFactory = new Trigger();
            //----------------------------------------------
            //names:
            this.MessageLabel1.SetLabelName(SandBoxLabel1NameInRes);
            this.MessageLabel2.SetLabelName(SandBoxLabel2NameInRes);
            this.MessageLabel5.SetLabelName(SandBoxLabel5NameInRes);
            this.MessageLabel4.SetLabelName(SandBoxLabel4NameInRes);
            //TabIndexes:
            this.MessageLabel1.TabIndex = 0;
            this.MessageLabel2.TabIndex = 1;
            this.MessageLabel4.TabIndex = 2;
            this.MessageLabel1.CurrentStatus = 3;
            this.MessageLabel2.CurrentStatus = 2;
            this.MessageLabel4.CurrentStatus = 2;
            this.MessageLabel5.CurrentStatus = 2;
            //Images:
            //FontAndTextAligns:
            this.MessageLabel1.Font = new Font(ThereIsConstants.Forming.TheMainForm.PrivateFonts.Families[1]
                    , 18, FontStyle.Bold);
            this.MessageLabel2.Font = 
                new Font(ThereIsConstants.Forming.TheMainForm.PrivateFonts.Families[1]
                    , 14, FontStyle.Bold);
            this.MessageLabel5.Font =
                new Font(ThereIsConstants.Forming.TheMainForm.PrivateFonts.Families[1]
                , 13, FontStyle.Bold | FontStyle.Underline);
            this.TextBox1.Font = 
                new Font(ThereIsConstants.Forming.TheMainForm.PrivateFonts.Families[1]
                    , 15, FontStyle.Bold);
            this.MessageLabel4.Font =
                new Font(ThereIsConstants.Forming.TheMainForm.PrivateFonts.Families[1],
                14.3f, FontStyle.Bold);
            this.MessageLabel1.TextAlign = MessageLabel5.TextAlign =
                ContentAlignment.MiddleCenter;
            this.MessageLabel2.TextAlign = 
                ContentAlignment.MiddleCenter;
            this.TextBox1.TextAlign = 
                HorizontalAlignment.Center;
            this.MessageLabel4.TextAlign = ContentAlignment.MiddleCenter;
            //Styles:
            this.MessageLabel4.FlatStyle = FlatStyle.Flat;
            //Sizes:
            this.MessageLabel1.Size = new Size(Width,
                (Height / 6) - (SeparatorLine_Height / 2));
            this.MessageLabel2.Size = 
                new Size(Width - (10 * from_the_edge),
                (1 * (Height / 8)) - (4 * SeparatorLine_Height));
            this.MessageLabel5.Size = new Size(Width - (25 * from_the_edge),
                (1 * (Height / 8)) - (4 * SeparatorLine_Height));
            this.TextBox1.Size = 
                new Size(Width - (4 * from_the_edge),
                (1 * (Height / 7)) - (SeparatorLine_Height / 2));
            //Locations:
            this.MessageLabel2.Dock = CloseLabel.Dock =
                DockStyle.None;
            this.MessageLabel1.Location = new Point(from_the_edge / 2, 0);
            this.CloseLabel.Location = new Point(Width - CloseLabel.Width -
                (2 * from_the_edge), from_the_edge);
            this.MessageLabel2.Location = 
                new Point((Width / 2) - (MessageLabel2.Width / 2),
                MessageLabel1.Location.Y +
                MessageLabel1.Height + SeparatorLine_Height);
            this.TextBox1.Location = new Point(MessageLabel1.Location.X +
                (MessageLabel1.Width / 2) - (TextBox1.Width / 2),
                MessageLabel2.Location.Y + MessageLabel2.Height +
                SeparatorLine_Height);
            this.MessageLabel5.Location = new Point((Width / 2) - 
                (MessageLabel5.Width / 2), Height - 
                (MessageLabel5.Height +
                SeparatorLine_Height + (1 * from_the_edge)));
            this.MessageLabel4.Location = new Point((Width / 2) - 
                (MessageLabel4.Width / 2), 
                MessageLabel5.Location.Y - (SeparatorLine_Height + MessageLabel4.Height) -
                (3 * ThereIsConstants.AppSettings.Between_GameControls));
            //Colors:
            this.MessageLabel1.SetColorTransparent();
            this.MessageLabel2.SetColorTransparent();
            this.MessageLabel4.ForeColor = Color.Black;
            this.MessageLabel2.ForeColor  =
                MessageLabel5.ForeColor =
                Color.White;
            this.MessageLabel4.SetColorTransparent();
            this.MessageLabel1.ForeColor = MessageLabel2.ForeColor = Color.White;
            //ComboBoxes:
            //Enableds:
            this.TextBox1.DisableSelection = true;
            this.TextBox1.ReadOnly = true;
            this.TextBox1.HideSelection = true;
            //Texts:
            this.MessageLabel1.SetLabelText();
            this.MessageLabel2.SetLabelText();
            this.MessageLabel5.SetLabelText();
            this.MessageLabel4.SetLabelText();
            //AddRanges:
            //ToolTipSettings:
            //----------------------------------------------
            //Events:
            this.MessageLabel1.MouseDown += SandBoxBase_MouseDown;
            this.MessageLabel2.MouseDown += SandBoxBase_MouseDown;
            this.MessageLabel5.MouseEnter += MessageLabel5_MouseEnter;
            this.MessageLabel5.MouseLeave += MessageLabel5_MouseLeave;
            this.MessageLabel5.Click += MessageLabel5_Click;
            //this.MessageLabel4.Click += ButtonControl2_Click;  Check the CallMe(true) function.
            this.Paint += CreateProfileSandBox_Paint;
            this.GotFocus += CreateProfileSandBox_GotFocus;
            this.Shown += CreateProfileSandBox_Shown;
            //---------AnimationFactory:
            this.AnimationFactory.Tick += AnimationFactoryWorker;
            this.AnimationFactory.Interval = 50;
            this.AnimationFactory.Enabled = true;
            this.CurrentNum = 0;

            //----------------------------------------------
            this.MessageLabel1.Controls.Add(CloseLabel);
            this.Controls.AddRange(new Control[]
            {
                MessageLabel1,
                MessageLabel2,
                MessageLabel4,
                MessageLabel5,
                TextBox1,
            });

        }

        public void AnimationFactoryWorker(object sender, EventArgs e)
        {
            if (!Enabled)
            {
                return;
            }
            if(CurrentNum <= MAXIMUM_TICK)
            {
                this.BackgroundImage =
                    ThereIsConstants.Actions.RotateImage(
                        new Bitmap(Image.FromFile(ThereIsConstants.Path.Datas_Path +
                    ThereIsConstants.Path.DoubleSlash + MyRes.GetString(TheBackGroundNameInRes))), 
                        CurrentNum * 0.5f);
                CurrentNum++;
            }
            else
            {
                ClosedForRetry = true;
                if (IsShowingAnotherSandBox)
                {
                    if(ShowingAnotherSandBox != null && !ShowingAnotherSandBox.IsDisposed)
                    {
                        if(ShowingAnotherSandBox is NoInternetConnectionSandBox)
                        {
                            ShowingAnotherSandBox.FormClosed -= ErrorSandBox_FormClosed;
                        }
                        ShowingAnotherSandBox.Close();
                    }
                }
                Close();
            }
            
        }

        private async void CreateProfileSandBox_Shown(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                Thread.Sleep(100);
            });
            CallMe();
        }

        #endregion
        //-------------------------------------------------
        #region Designing Region
        private void CreateProfileSandBox_GotFocus(object sender, EventArgs e)
        {
            if (UnderForm.Enabled)
            {
                UnderForm.Enabled = false;
            }
        }

        /// <summary>
        /// Or sign in to your Profile,
        /// this function will run when the user clicked on that MessageLabel,
        /// I mean: <see cref="MessageLabel5"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MessageLabel5_Click(object sender, EventArgs e)
        {
            if (IsLinkStartMode)
            {
                NoInternetConnectionSandBox mySandBox =
                    NoInternetConnectionSandBox.PrepareLogoutWarningSandBox();
                mySandBox.ButtonControl2.Click += LogoutWarningButtonControl2_Click1;
                mySandBox.FormClosed += ErrorSandBox_FormClosed;


            }
            else
            {
                IsCreatingMode = false;
                IsSignInMode = true;
                Controls.Remove(MessageLabel4);
                Controls.Remove(MessageLabel5);
                Controls.Remove(TextBox3);
                MessageLabel1.CurrentStatus = 2;
                MessageLabel1.SetLabelText();
            }
            
        }

        private void LogoutWarningButtonControl2_Click1(object sender, EventArgs e)
        {
            if(ShowingAnotherSandBox is NoInternetConnectionSandBox mySandBox)
            {
                mySandBox.ClosedForRetry = true;
                mySandBox.Close();
            }
            ThereIsServer.GameObjects.MyProfile.LogOut();
            IsShowingAnotherSandBox = true;
            ShowingAnotherSandBox =
                LoadingSandBox = new YuiLoadingSandbox(this);
            LoadingSandBox.Location =
                new Point((Screen.PrimaryScreen.Bounds.Size.Width / 2) -
                (LoadingSandBox.Width / 2),
                (Screen.PrimaryScreen.Bounds.Size.Height / 2) -
                (LoadingSandBox.Height / 2));
            LoadingSandBox.FormClosed += LoadingSandBox_FormClosed;
            LoadingSandBox.Show();
        }

        private void MessageLabel5_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void MessageLabel5_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void CreateProfileSandBox_EnabledChanged(object sender, EventArgs e)
        {
            ButtonControl1.ForeColor = ButtonControl2.ForeColor = Color.White;
        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {
            //MessageBox.Show("SG");
            if (IsCreatingMode)
            {
                if (TextBox3.Text == TextBox2.Text && TextBox2.Text.Length >= 8)
                {
                    ButtonControl2.ForeColor = Color.LightGreen;
                }
                else
                {
                    if (ButtonControl2.ForeColor != Color.Pink)
                    {
                        ButtonControl2.ForeColor = Color.Pink;
                    }
                }
                if (TextBox3.Text.Length >= TextBox2.Text.Length)
                {
                    if (TextBox3.Text != TextBox2.Text)
                    {
                        if (MessageLabel4.ForeColor != Color.Pink)
                        {
                            MessageLabel4.ForeColor = Color.Pink;
                        }
                    }
                    else
                    {
                        if (MessageLabel4.ForeColor == Color.Pink)
                        {
                            MessageLabel4.ForeColor = Color.White;
                        }
                    }
                }
                else
                {
                    if (MessageLabel4.ForeColor == Color.Pink)
                    {
                        MessageLabel4.ForeColor = Color.White;
                    }
                }
            }
            else if (IsSignInMode)
            {
                if(TextBox1.TextLength < 3 || TextBox2.TextLength < 8)
                {
                    if (ButtonControl2.ForeColor != Color.Pink)
                    {
                        ButtonControl2.ForeColor = Color.Pink;
                    }
                }
                else
                {
                    if (ButtonControl2.ForeColor != Color.LightGreen)
                    {
                        ButtonControl2.ForeColor = Color.LightGreen;
                    }
                }
            }
        }

        private void ButtonControl2_Click(object sender, EventArgs e)
        {
            if (IsLinkStartMode) //for LinkStart Label Click Event
            {
                IsCheckingForExisting = true;
                if ((bool)this.MessageLabel4.Tag)
                {
                    return;
                }
                else
                {
                    this.MessageLabel4.Tag = false;
                }
                //bool result = false;
                
                /*
                Me theNewAcc = new Me(false, TextBox1.Text, TextBox2.Text);
                ThereIsServer.ServerSettings.MyProfile = theNewAcc; 
                */


                ThereIsServer.GameObjects.MyProfile.Link_Start(true);
                IsShowingAnotherSandBox = true;
                ShowingAnotherSandBox = LoadingSandBox = new YuiLoadingSandbox(this);
                LoadingSandBox.Location =
                    new Point((Screen.PrimaryScreen.Bounds.Size.Width / 2) -
                    (LoadingSandBox.Width / 2),
                    (Screen.PrimaryScreen.Bounds.Size.Height / 2) -
                    (LoadingSandBox.Height / 2));
                LoadingSandBox.FormClosed += LoadingSandBox_FormClosed;
                LoadingSandBox.Show();
            }
            else
            {
                if (ButtonControl2.ForeColor == Color.LightGreen)
                {
                    if (IsSignInMode)
                    {
                        IsCheckingForExisting = true;
                        //bool result = false;
                        Me theNewAcc = new Me(false, TextBox1.Text, TextBox2.Text);
                        ThereIsServer.ServerSettings.MyProfile = theNewAcc;
                        IsShowingAnotherSandBox = true;
                        ShowingAnotherSandBox = LoadingSandBox =
                            new YuiLoadingSandbox(this);
                        LoadingSandBox.Location = 
                            new Point((Screen.PrimaryScreen.Bounds.Size.Width / 2) -
                            (LoadingSandBox.Width / 2),
                            (Screen.PrimaryScreen.Bounds.Size.Height / 2) -
                            (LoadingSandBox.Height / 2));
                        LoadingSandBox.FormClosed += LoadingSandBox_FormClosed;
                        LoadingSandBox.Show();
                    }
                    else if (IsCreatingMode)
                    {
                        IsCheckingForExisting = true;
                        Me theNewAcc = new Me(true, TextBox1.Text, TextBox2.Text);
                        ThereIsServer.ServerSettings.MyProfile = theNewAcc;
                        IsShowingAnotherSandBox = true;
                        ShowingAnotherSandBox = LoadingSandBox = 
                            new YuiLoadingSandbox(this);
                        LoadingSandBox.Location = new Point((Screen.PrimaryScreen.Bounds.Size.Width / 2) -
                            (LoadingSandBox.Width / 2), (Screen.PrimaryScreen.Bounds.Size.Height / 2) -
                            (LoadingSandBox.Height / 2));
                        LoadingSandBox.FormClosed += LoadingSandBox_FormClosed;
                        LoadingSandBox.Show();
                        if (ThereIsConstants.Forming.TheMainForm.SoundPlayer != null)
                        {
                            ThereIsConstants.Forming.TheMainForm.SoundPlayer.Stop();
                        }
                    }

                }
            }
            
            
        }

        private void LoadingSandBox_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(sender is YuiLoadingSandbox mySandBox)
            {
                if (mySandBox.ClosedByMe)
                {
                    IsShowingAnotherSandBox = false;
                    ShowingAnotherSandBox   = null;
                    mySandBox.Dispose();
                    GC.Collect();
                }
                else
                {
                    this.ClosedForRetry     = false;
                    IsShowingAnotherSandBox = false;
                    ShowingAnotherSandBox   = null;
                    this.Close();
                }
            }
        }

        private void ButtonControl1_Click(object sender, EventArgs e)
        {
            Close(true);
        }

        private void CreateProfileSandBox_Paint(object sender, PaintEventArgs e)
        {
            if (!IsLinkStartMode)
            {
                e.Graphics.DrawLine(new Pen(Color.White, 5),
                    MessageLabel1.Location.X + from_the_edge,
                    MessageLabel1.Location.Y + MessageLabel1.Height,
                    MessageLabel1.Location.X +
                    MessageLabel1.Width - from_the_edge,
                    MessageLabel1.Location.Y + MessageLabel1.Height);
                e.Graphics.DrawLine(new Pen(Color.White, 2),
                    TextBox1.Location.X + (2 * from_the_edge),
                    TextBox1.Location.Y + TextBox1.Height +
                    from_the_edge,
                    TextBox1.Location.X +
                    TextBox1.Width - (2 * from_the_edge),
                    TextBox1.Location.Y + TextBox1.Height + from_the_edge);
                e.Graphics.DrawLine(new Pen(Color.White, 2),
                    TextBox2.Location.X + (2 * from_the_edge),
                    TextBox2.Location.Y + TextBox2.Height +
                    from_the_edge,
                    TextBox2.Location.X +
                    TextBox2.Width - (2 * from_the_edge),
                    TextBox2.Location.Y + TextBox2.Height + from_the_edge);
            }
            else
            {
                e.Graphics.DrawLine(new Pen(Color.White, 5),
                    MessageLabel1.Location.X + from_the_edge,
                    MessageLabel1.Location.Y + MessageLabel1.Height,
                    MessageLabel1.Location.X +
                    MessageLabel1.Width - from_the_edge,
                    MessageLabel1.Location.Y + MessageLabel1.Height);
                e.Graphics.DrawLine(new Pen(Color.White, 2),
                    TextBox1.Location.X + (2 * from_the_edge),
                    TextBox1.Location.Y + TextBox1.Height +
                    from_the_edge,
                    TextBox1.Location.X +
                    TextBox1.Width - (2 * from_the_edge),
                    TextBox1.Location.Y + TextBox1.Height + from_the_edge);
                e.Graphics.DrawLine(new Pen(Color.White, 2),
                    MessageLabel4.Location.X + (2 * from_the_edge),
                    MessageLabel4.Location.Y + MessageLabel4.Height +
                    from_the_edge,
                    MessageLabel4.Location.X +
                    MessageLabel4.Width - (2 * from_the_edge),
                    MessageLabel4.Location.Y + MessageLabel4.Height + 
                    from_the_edge);
            }

        }
        //------------------------------------------------------
        /// <summary>
        /// Just use it when you are not in the GameClient.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void ErrorSandBox_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (HasLoggedOut)
            {
                if (sender is NoInternetConnectionSandBox mySandBox)
                {
                    if (mySandBox.ClosedForRetry)
                    {
                        await Task.Run(() =>
                        {
                            System.Threading.Thread.Sleep(100);
                        });
                        this.Close(true);
                        this.IsShowingAnotherSandBox = false;
                        this.ShowingAnotherSandBox = null;
                    }
                    else
                    {
                        this.Close();
                        await Task.Run(() =>
                        {
                            System.Threading.Thread.Sleep(100);
                        });
                        this.UnderForm.Close();
                    }
                }
                await Task.Delay(100);
                if (!(this.IsDisposed))
                {
                    this.Show();
                    this.Enabled = true;
                    this.Focus();
                }
            }
            else
            {
                if (sender is NoInternetConnectionSandBox mySandBox)
                {
                    if (mySandBox.ClosedForRetry)
                    {
                        await Task.Delay(100);
                        if (!this.IsDisposed)
                        {
                            this.UnderForm.Enabled = false;
                            ThereIsConstants.Forming.TheMainForm.IsShowingSandBox = true;
                            if(LoadingSandBox == null || LoadingSandBox.IsDisposed)
                            {
                                this.Show();
                                this.Enabled = true;
                                this.Focus();
                                this.IsShowingAnotherSandBox = false;
                                this.ShowingAnotherSandBox = null;
                            }
                            
                        }
                    }
                    else
                    {
                        this.Close();
                        await Task.Run(() =>
                        {
                            System.Threading.Thread.Sleep(100);
                        });
                        this.UnderForm.Close();
                    }
                }
                await Task.Run(() =>
                {
                    System.Threading.Thread.Sleep(100);
                });
                if (!this.IsDisposed)
                {
                    this.Show();
                    this.Focus();
                }
                
            }
            
        }

        #endregion
        //------------------------------------------------------
    }
}
