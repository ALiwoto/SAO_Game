// Copyright (C) ALiwoto 2019 - 2020
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of the source code.

using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using SAO.Controls;
using SAO.Constants;
using SAO.SandBox.HallSandBoxes;
using SAO.GameObjects.Characters;
using SAO.GameObjects.Players;
using SAO.GameObjects.ServerObjects;
using SAO.GameObjects.Resources;

namespace SAO.SandBox
{
    partial class FirstStoryLineSandBox
    {
        //----------------------------------------------
        #region BookStory(The First Story Line) SandBox Region.
        private void Initialize_BookStory_Component()
        {
            if (UseAnimation)
            {
                this.Size = new Size(9 * (UnderForm.Size.Width / 10),
                    8 * (UnderForm.Size.Height / 9));
                /*
                this.Location = new Point((UnderForm.Size.Width / 2)
                    - (this.Width / 2),
                    (UnderForm.Size.Height / 2) - (this.Height / 2)); */
                this.CenterToScreen();
                /* this.BackColor = Color.FromArgb(BackColor.A, 
                    Color.DarkKhaki); */
                this.BackColor = Color.DarkMagenta;
                this.TransparencyKey = Color.DarkMagenta;
                /*
                this.BackgroundImage = Image.FromFile(ThereIsConstants.Path.Datas_Path +
                    "\\imageedit_1_3951108645.png"); */
                this.BackgroundImageLayout = ImageLayout.Stretch;
                //----------------------------------
                //news:
                this.MyRes              = new WotoRes(typeof(FirstStoryLineSandBox));
                this.MessageLabel1      = new GameControls.LabelControl(this);
                this.MessageLabel2      = new GameControls.LabelControl(this);
                this.MessageLabel3      = new GameControls.LabelControl(this);
                this.BookPictureBox     = new GameControls.PictureBoxControl(this);
                this.MyHallSandBox      = 
                    new HallSandBox(ThereIsConstants.Forming.GameClient, this,
                        HallSandBoxMode.HallOfBookStoryMode, true, 
                        this.HallSandBoxAnimationTimerEndedWorking)
                    {
                        Visible = false
                    };
                //Names:
                this.MessageLabel1.SetLabelName(SandBoxLabel1NameInRes);
                this.MessageLabel2.SetLabelName(SandBoxLabel2NameInRes);
                this.MessageLabel3.SetLabelName(SandBoxLabel3NameInRes);
                //Set CurrentStatus:
                //this.MessageLabel1.CurrentStatus = this.MessageLabel3.CurrentStatus = StoryStep;
                //TabIndexes:
                //FontsAndTextAligns:
                this.MessageLabel1.Font = this.MessageLabel2.Font =
                    new Font(
                        ThereIsConstants.AppSettings.GameClient.PrivateFonts.Families[0],
                        20, FontStyle.Italic | FontStyle.Bold);
                this.MessageLabel3.Font = new Font(
                    ThereIsConstants.AppSettings.GameClient.PrivateFonts.Families[1],
                    14, FontStyle.Bold);
                this.MessageLabel1.TextAlign = MessageLabel2.TextAlign = 
                    MessageLabel3.TextAlign = ContentAlignment.MiddleCenter;
                //Sizes:
                this.MessageLabel1.Size = MessageLabel2.Size =
                    new Size(1 * (Width / 3),
                        5 * (Height / 7));
                this.MessageLabel3.Size = new Size(1 * (Width / 8),
                    1 * (Height / 5));
                this.BookPictureBox.Size = new Size(9 * (Width / 10),
                    9 * (Height / 10));
                //Locations:
                this.MessageLabel1.Location =
                    new Point((BookPictureBox.Width / 2) - MessageLabel1.Width +
                        (2 * NoInternetConnectionSandBox.from_the_edge),
                        4 * NoInternetConnectionSandBox.from_the_edge);
                this.MessageLabel2.Location =
                    new Point((BookPictureBox.Width / 2) + 
                        (2 * NoInternetConnectionSandBox.from_the_edge),
                        4 * NoInternetConnectionSandBox.from_the_edge);
                /*this.MessageLabel3.Location = new Point(MyHallSandBox.Width - 
                    (MessageLabel3.Width +
                    NoInternetConnectionSandBox.from_the_edge),
                    MyHallSandBox.Height - 
                    (MessageLabel3.Height + NoInternetConnectionSandBox.from_the_edge)); */
                this.BookPictureBox.Location = new Point((this.Width / 2) - (BookPictureBox.Width / 2),
                    (this.Height / 2) - (BookPictureBox.Height / 2));
                //Colors:
                this.BookPictureBox.BackColor =
                this.MessageLabel1.BackColor = MessageLabel2.BackColor = 
                    MessageLabel3.BackColor =
                Color.Transparent;
                this.MessageLabel3.ForeColor = Color.WhiteSmoke;
                //Images:
                this.BookPictureBox.Image = Image.FromFile(ThereIsConstants.Path.Datas_Path + "\\" +
                    MyRes.GetString(BookImageFileNameInRes));
                this.BookPictureBox.SizeMode =
                    PictureBoxSizeMode.StretchImage;
                //ComboBoxes:
                //Enableds:
                //Texts:
                this.MessageLabel1.SetLabelText();
                //this.MessageLabel2.SetLabelText();
                this.MessageLabel2.CurrentStatus = 0;
                this.MessageLabel3.SetLabelText();
                //AddRanges:
                //ToolTipSettings:
                //TimerSettings:

                //Events:
                this.MessageLabel1.Click += FirstStoryLineSandBox_Click;
                this.MessageLabel2.Click += FirstStoryLineSandBox_Click;
                this.BookPictureBox.Click += FirstStoryLineSandBox_Click;
                this.MyHallSandBox.Click += FirstStoryLineSandBox_Click;
                this.FormClosed += FirstStoryLineSandBox_FormClosed;
                //FinalBlow:
                this.MyHallSandBox.RemoveMovingClicking();
                //--------------------------------------
                this.BookPictureBox.Controls.AddRange(new Control[]
                {
                    this.MessageLabel1,
                    this.MessageLabel2
                });
                /*this.MyHallSandBox.Controls.Add(this.MessageLabel3);*/
                this.Controls.AddRange(new Control[]
                {
                    this.BookPictureBox
                });
                this.Visible = false;
                DesignStory1();
            }
            else
            {
                //MessageBox.Show("HERE");
            }
        }
        private void DesignStory1()
        {
            MyHallSandBox.Show();
            this.Hide();

        }

        private void FirstStoryLineSandBox_FormClosed(object sender, FormClosedEventArgs e)
        {
            MyHallSandBox.Close();
            if(MessageLabel1.CurrentStatus == 0)
            {
                if (!ThereIsConstants.Forming.GameClient.Enabled)
                {
                    ThereIsConstants.Forming.GameClient.Enabled = true;
                    ThereIsConstants.Forming.GameClient.ShowKojiEmpire();
                }
                ThereIsConstants.Forming.GameClient.Focus();
            }
            else
            {
                ThereIsConstants.AppSettings.GameClient.Close();
            }
            
        }

        private void FirstStoryLineSandBox_Click(object sender, EventArgs e)
        {
            if(MessageLabel1.CurrentStatus <= 2)
            {
                if(MessageLabel1.CurrentStatus == 1 &&
                    MessageLabel2.CurrentStatus == 0)
                {
                    MessageLabel2.CurrentStatus = 1;
                    MessageLabel2.SetLabelText();
                    return;
                }
                else if(MessageLabel1.CurrentStatus == 1 && MessageLabel2.CurrentStatus == 1)
                {
                    MessageLabel2.SetLabelText(String.Empty);
                    this.MessageLabel1.CurrentStatus++;
                    this.MessageLabel1.SetLabelText();
                    return;
                }
                else if(MessageLabel1.CurrentStatus == 2)
                {
                    
                    MessageLabel1.CurrentStatus++; //For if else
                    MessageLabel2.CurrentStatus++;
                    MessageLabel2.SetLabelText();
                    MessageLabel2.Show();
                    return;
                }
            }
            else
            {
                MessageLabel1.CurrentStatus = 0;
                if (!ThereIsConstants.Forming.GameClient.Enabled)
                {
                    ThereIsConstants.Forming.GameClient.Enabled = true;
                }
                this.MessageLabel1.Dispose();
                this.MessageLabel3.Dispose();
                ThereIsConstants.Forming.GameClient.Focus();
                ThereIsConstants.Forming.GameClient.ShowKojiEmpire();
                Close();
            }
        }
        private async void HallSandBoxAnimationTimerEndedWorking(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                Thread.Sleep(500);
            });
            this.MessageLabel3.Location = new Point(MyHallSandBox.Width -
                    (MessageLabel3.Width +
                    NoInternetConnectionSandBox.from_the_edge),
                    MyHallSandBox.Height -
                    (MessageLabel3.Height + NoInternetConnectionSandBox.from_the_edge));
            this.MyHallSandBox.Controls.Add(this.MessageLabel3);
            this.Region =
                new Region(new RectangleF(0, 0,
                    ThereIsConstants.Forming.GameClient.Width,
                    ThereIsConstants.Forming.GameClient.Height));
            this.MyHallSandBox.Click += FirstStoryLineSandBox_Click;
            this.Show();
            this.TopMost = true;
        }
        #endregion
        //----------------------------------------------
        #region ElementSelection SandBox Region

        private void Initialize_ElementSelection_Component()
        {
            if (UseAnimation)
            {
                this.Size = new Size(UnderForm.Width,
                    UnderForm.Height);
                /*
                this.Location = new Point((UnderForm.Size.Width / 2)
                    - (this.Width / 2),
                    (UnderForm.Size.Height / 2) - (this.Height / 2)); */
                this.CenterToScreen();
                /* this.BackColor = Color.FromArgb(BackColor.A, 
                    Color.DarkKhaki); */
                this.BackColor = 
                this.TransparencyKey = Color.DarkMagenta;
                /*
                this.BackgroundImage = Image.FromFile(ThereIsConstants.Path.Datas_Path +
                    "\\imageedit_1_3951108645.png"); */
                this.BackgroundImageLayout = ImageLayout.Stretch;
                //----------------------------------
                //news:
                this.MyRes = new WotoRes(typeof(FirstStoryLineSandBox));
                this.MessageLabel1 = new GameControls.LabelControl(this, 
                    GameControls.LabelControlSpecies.ElementBackGround, this);
                this.MessageLabel2 = new GameControls.LabelControl(this, 
                    GameControls.LabelControlSpecies.ElementBackGround, this);
                this.MessageLabel3 = new GameControls.LabelControl(this, 
                    GameControls.LabelControlSpecies.ElementBackGround, this);
                this.MessageLabel4 = new GameControls.LabelControl(this,
                    GameControls.LabelControlSpecies.ElementBackGround, this);
                this.MessageLabel5 = new GameControls.LabelControl(this,
                    GameControls.LabelControlSpecies.ElementBackGround, this);
                this.MessageLabel6 = new GameControls.LabelControl(this,
                    GameControls.LabelControlSpecies.ElementBackGround, this);
                this.MessageLabel7 = new GameControls.LabelControl(this,
                    GameControls.LabelControlSpecies.ElementBackGround, this);
                this.PictureBoxControl1 = new GameControls.PictureBoxControl(this, true, 
                    MessageLabel1);
                this.PictureBoxControl2 = new GameControls.PictureBoxControl(this, true,
                    MessageLabel2);
                this.PictureBoxControl3 = new GameControls.PictureBoxControl(this, true,
                    MessageLabel3);
                this.PictureBoxControl4 = new GameControls.PictureBoxControl(this, true,
                    MessageLabel4);
                this.PictureBoxControl5 = new GameControls.PictureBoxControl(this, true,
                    MessageLabel5);
                this.PictureBoxControl6 = new GameControls.PictureBoxControl(this, true,
                    MessageLabel6);
                this.PictureBoxControl7 = new GameControls.PictureBoxControl(this, true,
                    MessageLabel7);
                this.MyHallSandBox =
                    new HallSandBox(ThereIsConstants.Forming.GameClient, this,
                        HallSandBoxMode.HallOfElementMode, true,
                        this.ElementHallAnimationTimerEndedWorking)
                    {
                        Visible = false
                    };
                //Names:
                this.MessageLabel1.SetLabelName(SandBoxLabel1NameInRes);
                this.MessageLabel2.SetLabelName(SandBoxLabel2NameInRes);
                this.MessageLabel3.SetLabelName(SandBoxLabel3NameInRes);
                this.MessageLabel4.SetLabelName(SandBoxLabel4NameInRes);
                this.MessageLabel5.SetLabelName(SandBoxLabel5NameInRes);
                this.MessageLabel6.SetLabelName(SandBoxLabel6NameInRes);
                this.MessageLabel7.SetLabelName(SandBoxLabel7NameInRes);
                this.PictureBoxControl1.SetPictureName(ElementPicControl1NameInRes);
                this.PictureBoxControl2.SetPictureName(ElementPicControl2NameInRes);
                this.PictureBoxControl3.SetPictureName(ElementPicControl3NameInRes);
                this.PictureBoxControl4.SetPictureName(ElementPicControl4NameInRes);
                this.PictureBoxControl5.SetPictureName(ElementPicControl5NameInRes);
                this.PictureBoxControl6.SetPictureName(ElementPicControl6NameInRes);
                this.PictureBoxControl7.SetPictureName(ElementPicControl7NameInRes);
                //Set CurrentStatus:
                this.MessageLabel1.CurrentStatus = 3;
                this.MessageLabel2.CurrentStatus = 3;
                this.MessageLabel3.CurrentStatus = 2;
                this.MessageLabel4.CurrentStatus = 1;
                this.MessageLabel5.CurrentStatus = 1;
                this.MessageLabel6.CurrentStatus = 1;
                this.MessageLabel6.CurrentStatus = 1;
                //TabIndexes:
                //FontsAndTextAligns:
                this.MessageLabel1.Font = this.MessageLabel2.Font =
                   this.MessageLabel3.Font = this.MessageLabel4.Font =
                   this.MessageLabel5.Font = this.MessageLabel6.Font =
                   this.MessageLabel7.Font = 
                    new Font(
                        ThereIsConstants.AppSettings.GameClient.PrivateFonts.Families[1],
                        20, FontStyle.Bold);
                this.MessageLabel1.TextAlign = MessageLabel2.TextAlign =
                    MessageLabel3.TextAlign = MessageLabel4.TextAlign =
                    MessageLabel5.TextAlign = MessageLabel6.TextAlign =
                    MessageLabel7.TextAlign = 
                    ContentAlignment.BottomCenter;
                //Sizes:
                this.MessageLabel1.Size = MessageLabel2.Size =
                    MessageLabel3.Size = MessageLabel4.Size =
                    MessageLabel5.Size = MessageLabel6.Size =
                    MessageLabel7.Size = 
                    PictureBoxControl1.Size = PictureBoxControl2.Size =
                    PictureBoxControl3.Size =
                    PictureBoxControl4.Size =
                    PictureBoxControl5.Size = PictureBoxControl6.Size =
                    PictureBoxControl7.Size =
                    new Size(6 * (Width / 48),
                        6 * (Height / 48));
                /*
                PictureBoxControl1.Size = PictureBoxControl2.Size =
                    PictureBoxControl3.Size =
                    //PictureBoxControl4.Size =
                    PictureBoxControl5.Size = PictureBoxControl6.Size =
                    new Size(MessageLabel1.Width / 2,
                    MessageLabel1.Height / 2);
                */
                //Locations:
                this.MessageLabel1.Location =
                    new Point((this.Width / 2) - 
                    (MessageLabel1.Width / 2),
                        2 * NoInternetConnectionSandBox.from_the_edge);
                this.MessageLabel2.Location = new Point(MessageLabel1.Location.X +
                    MessageLabel1.Width + (MessageLabel1.Width / 2),
                    MessageLabel1.Location.Y + MessageLabel1.Height);
                this.MessageLabel3.Location = new Point(MessageLabel2.Location.X,
                    MessageLabel2.Location.Y + MessageLabel2.Height +
                    MessageLabel2.Height);
                this.MessageLabel4.Location = new Point(MessageLabel1.Location.X,
                    MessageLabel3.Location.Y + MessageLabel3.Height);
                this.MessageLabel5.Location = new Point(MessageLabel1.Location.X -
                    MessageLabel1.Width - (MessageLabel1.Width / 2), 
                     MessageLabel3.Location.Y);
                this.MessageLabel6.Location = new Point(MessageLabel5.Location.X,
                    MessageLabel2.Location.Y);
                this.MessageLabel7.Location = new Point(MessageLabel1.Location.X,
                    MessageLabel2.Location.Y + MessageLabel2.Height);
                this.PictureBoxControl1.Location = 
                this.PictureBoxControl2.Location = 
                this.PictureBoxControl3.Location = 
                this.PictureBoxControl4.Location = 
                this.PictureBoxControl5.Location = 
                this.PictureBoxControl6.Location = 
                this.PictureBoxControl7.Location =
                    new Point(0,
                        (-1) * NoInternetConnectionSandBox.from_the_edge);
                //Colors:
                this.MessageLabel1.BackColor = MessageLabel2.BackColor =
                    MessageLabel3.BackColor =  MessageLabel4.BackColor =
                    MessageLabel5.BackColor = MessageLabel6.BackColor =
                    MessageLabel7.BackColor = 
                Color.Transparent;
                this.MessageLabel1.ForeColor = Color.LightGoldenrodYellow;
                this.MessageLabel2.ForeColor = Color.Green;
                this.MessageLabel3.ForeColor = Color.AliceBlue;
                this.MessageLabel4.ForeColor = Color.DimGray;
                this.MessageLabel5.ForeColor = Color.LightYellow;
                this.MessageLabel6.ForeColor = Color.OrangeRed;
                this.MessageLabel7.ForeColor = Color.Magenta;
                //Images:
                this.PictureBoxControl1.SizeMode = PictureBoxControl2.SizeMode =
                    PictureBoxControl3.SizeMode = PictureBoxControl4.SizeMode =
                    PictureBoxControl5.SizeMode = PictureBoxControl6.SizeMode =
                    PictureBoxControl7.SizeMode =
                    PictureBoxSizeMode.CenterImage;
                this.MessageLabel1.ImageAlign =
                this.MessageLabel2.ImageAlign =
                this.MessageLabel3.ImageAlign =
                this.MessageLabel4.ImageAlign =
                this.MessageLabel5.ImageAlign =
                this.MessageLabel6.ImageAlign =
                this.MessageLabel7.ImageAlign =
                    ContentAlignment.TopCenter;
                this.PictureBoxControl1.SetPicture();
                this.PictureBoxControl2.SetPicture();
                this.PictureBoxControl3.SetPicture();
                this.PictureBoxControl4.SetPicture();
                this.PictureBoxControl5.SetPicture();
                this.PictureBoxControl6.SetPicture();
                this.PictureBoxControl7.SetPicture();
                //ComboBoxes:
                //Enableds:
                this.MessageLabel1.UseAnimation =
                this.MessageLabel2.UseAnimation =
                this.MessageLabel3.UseAnimation =
                this.MessageLabel4.UseAnimation =
                this.MessageLabel5.UseAnimation =
                this.MessageLabel6.UseAnimation =
                this.MessageLabel7.UseAnimation =
                    true;
                //Texts:
                this.MessageLabel1.SetLabelText();
                this.MessageLabel2.SetLabelText();
                this.MessageLabel3.SetLabelText();
                this.MessageLabel4.SetLabelText();
                this.MessageLabel5.SetLabelText();
                this.MessageLabel6.SetLabelText();
                this.MessageLabel7.SetLabelText();
                //AddRanges:
                //ToolTipSettings:
                //TimerSettings:

                //Events:
                this.FormClosed += ElementSelectionSandBox_FormClosed;
                
                /*
                this.MessageLabel1.Click += FirstStoryLineSandBox_Click;
                this.MessageLabel2.Click += FirstStoryLineSandBox_Click;
                this.BookPictureBox.Click += FirstStoryLineSandBox_Click;
                this.MyHallSandBox.Click += FirstStoryLineSandBox_Click;
                */
                //FinalBlow:
                this.MyHallSandBox.RemoveMovingClicking();
                this.RemoveMovingClicking();
                //--------------------------------------
                this.MessageLabel1.Controls.Add(this.PictureBoxControl1);
                this.MessageLabel2.Controls.Add(this.PictureBoxControl2);
                this.MessageLabel3.Controls.Add(this.PictureBoxControl3);
                this.MessageLabel4.Controls.Add(this.PictureBoxControl4);
                this.MessageLabel5.Controls.Add(this.PictureBoxControl5);
                this.MessageLabel6.Controls.Add(this.PictureBoxControl6);
                this.MessageLabel7.Controls.Add(this.PictureBoxControl7);
                /*this.MyHallSandBox.Controls.Add(this.MessageLabel3);*/
                this.Controls.AddRange(new Control[]
                {
                    MessageLabel1,
                    MessageLabel2,
                    MessageLabel3,
                    MessageLabel4,
                    MessageLabel5,
                    MessageLabel6,
                    MessageLabel7,
                });
                this.Visible = false;
                DesignElements();
            }
            else
            {
                //MessageBox.Show("HERE");
            }
        }

        private void DesignElements()
        {
            MyHallSandBox.Show();
            this.Hide();

        }

        private void ElementSelectionSandBox_FormClosed(object sender, FormClosedEventArgs e)
        {
            MyHallSandBox.Close();
            if (ThereIsServer.GameObjects.MyProfile.ThePlayerElement != PlayerElement.NotSet)
            {
                if (!ThereIsConstants.Forming.GameClient.Enabled)
                {
                    ThereIsConstants.Forming.GameClient.Enabled = true;
                    
                }
                ThereIsConstants.Forming.GameClient.Focus();
            }
            else
            {
                ThereIsConstants.AppSettings.GameClient.Close();
            }

        }
        /// <summary>
        /// You want me to tell you about this bullshit?
        /// so listen carefully 'cuz this function, yes, the very
        /// existance of this function in the very existance of 
        /// now is the very important...
        /// mrwoto: enough with your bullshit,
        /// this function will only set the <see cref="PlayerInfo.ThePlayerElement"/>,
        /// just it.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Element_Click(object sender, EventArgs e)
        {
            if(sender is GameControls.PictureBoxControl myPicCon)
            {
                ThereIsConstants.Forming.GameClient.LoadingSandBox = new YuiLoadingSandbox(this);
                ThereIsConstants.Forming.GameClient.ShowingSandBox.
                    SetTheHighestSandBox(ThereIsConstants.Forming.GameClient.LoadingSandBox);
                ThereIsConstants.Forming.GameClient.LoadingSandBox.Location =
                    new Point((Screen.PrimaryScreen.Bounds.Size.Width / 2) -
                    (ThereIsConstants.Forming.GameClient.LoadingSandBox.Width / 2),
                    (Screen.PrimaryScreen.Bounds.Size.Height / 2) -
                    (ThereIsConstants.Forming.GameClient.LoadingSandBox.Height / 2));
                ThereIsConstants.Forming.GameClient.LoadingSandBox.FormClosed += 
                    ThereIsConstants.Forming.GameClient.LoadingSandBox_FormClosed;
                ThereIsConstants.Forming.GameClient.LoadingSandBox.Show();
                ThereIsConstants.Forming.GameClient.LoadingSandBox.TopMost = true;
                await ThereIsServer.GameObjects.MyProfile.ReloadPlayerInfo();
                ThereIsConstants.Forming.GameClient.TopMost = false;
                await ThereIsServer.GameObjects.MyProfile.ReloadMe();

                switch (myPicCon.Name.Replace(ThereIsConstants.ResourcesName.End_Res_Name, string.Empty))
                {
                    case ElementPicControl1NameInRes:
                    case SandBoxLabel1NameInRes:
                        ThereIsServer.GameObjects.MyProfile.SetPlayerElement(
                            PlayerElement.LightElement);
                        break;
                    case ElementPicControl2NameInRes:
                    case SandBoxLabel2NameInRes:
                        ThereIsServer.GameObjects.MyProfile.SetPlayerElement(
                            PlayerElement.WindElement);
                        break;
                    case ElementPicControl3NameInRes:
                    case SandBoxLabel3NameInRes:
                        ThereIsServer.GameObjects.MyProfile.SetPlayerElement(
                            PlayerElement.WaterElement);
                        break;
                    case ElementPicControl4NameInRes:
                    case SandBoxLabel4NameInRes:
                        ThereIsServer.GameObjects.MyProfile.SetPlayerElement(
                            PlayerElement.DarkMatter);
                        break;
                    case ElementPicControl5NameInRes:
                    case SandBoxLabel5NameInRes:
                        ThereIsServer.GameObjects.MyProfile.SetPlayerElement(
                            PlayerElement.EarthElement);
                        break;
                    case ElementPicControl6NameInRes:
                    case SandBoxLabel6NameInRes:
                        ThereIsServer.GameObjects.MyProfile.SetPlayerElement(
                            PlayerElement.FireElement);
                        break;
                    case ElementPicControl7NameInRes:
                    case SandBoxLabel7NameInRes:
                        ThereIsServer.GameObjects.MyProfile.SetPlayerElement(
                            PlayerElement.PlasmaElement);
                        break;
                    default:
                        MessageBox.Show(myPicCon.Name);
                        break;
                }
                ThereIsServer.GameObjects.MyProfile.SetPlayerStoryStep(StorySteps.KingdomSelectionStory);
                await ThereIsServer.GameObjects.MyProfile.UpdatePlayerInfo();
                await ThereIsServer.GameObjects.MyProfile.UpdateMe();
                if (ThereIsConstants.Forming.GameClient.LoadingSandBox is YuiLoadingSandbox mySand)
                {
                    mySand.Close(true);
                }
                ThereIsConstants.Forming.GameClient.DialogBoxProvider.CleaningUp();
                this.MyHallSandBox.Close(true);
                this.Close(true);
                ThereIsConstants.Forming.GameClient.ShowKojiTerritoryIn();
            }
            else
            {
                throw new Exception();
            }
        }
        private async void ElementHallAnimationTimerEndedWorking(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                Thread.Sleep(500);
            });
            this.Show();
            this.TopMost = true;
            DialogContext myCon = new DialogContext("d_1_1_2");
            ThereIsConstants.Forming.GameClient.IsShowingDialogBox = true;
            ThereIsConstants.Forming.GameClient.DialogBoxProvider = 
                new DialogBoxProvider(this.Controls, ref myCon);
            ThereIsConstants.Forming.GameClient.DialogBoxProvider.AfterDialogEndedEvent += 
                DialogBoxProvider_AfterDialogEndedEvent;
            ThereIsConstants.Forming.GameClient.DialogBoxProvider.SettingUpDialogWorks();
            //Events:
            this.MyHallSandBox.MouseDown  += ThereIsConstants.Forming.GameClient.DialogBoxProvider.Owner_Click;
            this.PictureBoxControl1.Click += ThereIsConstants.Forming.GameClient.DialogBoxProvider.Owner_Click;
            this.PictureBoxControl2.Click += ThereIsConstants.Forming.GameClient.DialogBoxProvider.Owner_Click;
            this.PictureBoxControl3.Click += ThereIsConstants.Forming.GameClient.DialogBoxProvider.Owner_Click;
            this.PictureBoxControl4.Click += ThereIsConstants.Forming.GameClient.DialogBoxProvider.Owner_Click;
            this.PictureBoxControl5.Click += ThereIsConstants.Forming.GameClient.DialogBoxProvider.Owner_Click;
            this.PictureBoxControl6.Click += ThereIsConstants.Forming.GameClient.DialogBoxProvider.Owner_Click;
            this.PictureBoxControl7.Click += ThereIsConstants.Forming.GameClient.DialogBoxProvider.Owner_Click;
            //this.TopMost = false;
        }

        private void DialogBoxProvider_AfterDialogEndedEvent(object sender, EventArgs e)
        {
            this.MyHallSandBox.MouseDown  -= ThereIsConstants.Forming.GameClient.DialogBoxProvider.Owner_Click;
            this.PictureBoxControl1.Click -= ThereIsConstants.Forming.GameClient.DialogBoxProvider.Owner_Click;
            this.PictureBoxControl2.Click -= ThereIsConstants.Forming.GameClient.DialogBoxProvider.Owner_Click;
            this.PictureBoxControl3.Click -= ThereIsConstants.Forming.GameClient.DialogBoxProvider.Owner_Click;
            this.PictureBoxControl4.Click -= ThereIsConstants.Forming.GameClient.DialogBoxProvider.Owner_Click;
            this.PictureBoxControl5.Click -= ThereIsConstants.Forming.GameClient.DialogBoxProvider.Owner_Click;
            this.PictureBoxControl6.Click -= ThereIsConstants.Forming.GameClient.DialogBoxProvider.Owner_Click;
            this.PictureBoxControl7.Click -= ThereIsConstants.Forming.GameClient.DialogBoxProvider.Owner_Click;
            //----------------------------------------------
            this.PictureBoxControl1.Click += Element_Click;
            this.PictureBoxControl2.Click += Element_Click;
            this.PictureBoxControl3.Click += Element_Click;
            this.PictureBoxControl4.Click += Element_Click;
            this.PictureBoxControl5.Click += Element_Click;
            this.PictureBoxControl6.Click += Element_Click;
            this.PictureBoxControl7.Click += Element_Click;
        }
        #endregion
        //----------------------------------------------
        #region Overrided Methods Region
        protected override void OnGotFocus(EventArgs e)
        {
            if (!MyHallSandBox.IsHallUp)
            {
                MyHallSandBox.Focus();
            }
            base.OnGotFocus(e);
        }
        #endregion
        //----------------------------------------------

        //----------------------------------------------
    }
}
