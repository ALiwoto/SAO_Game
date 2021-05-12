// Copyright (C) ALiwoto 2019 - 2020
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of the source code.

using System;
using System.Drawing;
using System.Windows.Forms;
using SAO.Controls;
using SAO.Constants;
using SAO.GameObjects.ServerObjects;
using SAO.GameObjects.Resources;

namespace SAO.SandBox
{
    partial class NoInternetConnectionSandBox
    {
        #region Designing Region
        /// <summary>
        /// No Internet Connection!
        /// </summary>
        private void Initialize_NoConnection_Component()
        {
            //----------------------------------------------
            //Almost all of the Form Settings, setted in the SandBoxBase class, so you don't need
            // to set something in this place...
            this.Dock = DockStyle.None;
            //this.Focused = true;
            this.HelpButton = false;
            this.CenterToScreen();
            this.BackgroundImageLayout = ImageLayout.Center;
            //----------------------------------------------
            this.MyRes = new WotoRes(typeof(NoInternetConnectionSandBox));
            this.BackgroundImage = Image.FromFile(ThereIsConstants.Path.Datas_Path +
                ThereIsConstants.Path.DoubleSlash + MyRes.GetString(SandBoxBackGNameInRes));
            this.MessageLabel1  = new GameControls.LabelControl(this);
            this.MessageLabel2  = new GameControls.LabelControl(this);
            this.ButtonControl1 = new GameControls.ButtonControl(this);
            this.ButtonControl2 = new GameControls.ButtonControl(this);
            //----------------------------------------------
            //names:
            this.MessageLabel1.SetLabelName(SandBoxLabel1NameInRes);
            this.MessageLabel2.SetLabelName(SandBoxLabel2NameInRes);
            this.ButtonControl1.SetButtonName(SandBoxButton1NameInRes);
            this.ButtonControl2.SetButtonName(SandBoxButton2NameInRes);
            //StatusNums:
            this.MessageLabel1.CurrentStatus  =
            this.MessageLabel2.CurrentStatus  =
            this.ButtonControl1.CurrentStatus =
            this.ButtonControl2.CurrentStatus = 1;
            //TabIndexes:
            this.MessageLabel1.TabIndex = 0;
            this.MessageLabel2.TabIndex = 1;
            this.ButtonControl1.TabIndex = 2;
            this.ButtonControl2.TabIndex = 3;

            //FontAndTextAligns:
            this.MessageLabel1.Font =
                        new Font(ThereIsConstants.Forming.TheMainForm.PrivateFonts.Families[1],
                        17, FontStyle.Bold);
            this.MessageLabel2.Font =
                new Font(ThereIsConstants.Forming.TheMainForm.PrivateFonts.Families[1],
                15, FontStyle.Bold);
            this.ButtonControl1.Font = this.ButtonControl2.Font =
                new Font(ThereIsConstants.Forming.TheMainForm.PrivateFonts.Families[1],
                14.3f, FontStyle.Bold);
            this.MessageLabel1.TextAlign = MessageLabel2.TextAlign = ContentAlignment.MiddleCenter;
            //Styles:
            this.ButtonControl1.FlatStyle = this.ButtonControl2.FlatStyle = FlatStyle.Flat;
            //Sizes:
            this.MessageLabel1.Size = new Size(Width - from_the_edge,
                        (Height / 3) - (SeparatorLine_Height / 2));
            this.MessageLabel2.Size = new Size(Width - from_the_edge,
                (1 * (Height / 3)) - (SeparatorLine_Height / 2));
            this.ButtonControl1.Size = ButtonControl2.Size =
                new Size((int)(1.4 * ButtonControl1.Width),
                (int)(1.6 * ButtonControl1.Height));
            this.ButtonControl1.SetOriginalSize(this.ButtonControl1.Size);
            this.ButtonControl2.SetOriginalSize(this.ButtonControl2.Size);
            //Locations:
            this.MessageLabel2.Dock = DockStyle.None;
            this.MessageLabel1.Location = new Point(from_the_edge / 2, 0);
            this.MessageLabel2.Location = new Point(MessageLabel1.Location.X, MessageLabel1.Location.Y +
                MessageLabel1.Height + SeparatorLine_Height);
            this.ButtonControl1.Location = new Point((MessageLabel2.Location.X +
                (MessageLabel2.Width / 2)) - (ButtonControl1.Width / 2) - (6 * from_the_edge),
                MessageLabel2.Location.Y + MessageLabel2.Height +
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
            this.ButtonControl1.BackColor = this.ButtonControl2.BackColor = Color.Black;
            this.MessageLabel1.ForeColor = MessageLabel2.ForeColor        = Color.White;
            //this.MessageLabel1.BackColor = MessageLabel2.BackColor = Color.Transparent;
            //ComboBoxes:
            //Enableds:
            //Texts:
            //MessageBox.Show(MessageLabel1.Text);
            //That was for Debugging.

            this.MessageLabel1.SetLabelText();
            this.MessageLabel2.SetLabelText();
            this.ButtonControl1.SetButtonText();
            this.ButtonControl2.SetButtonText();
            //AddRanges:
            //ToolTipSettings:
            //----------------------------------------------
            //Events:
            this.MessageLabel1.MouseDown += SandBoxBase_MouseDown;
            this.MessageLabel2.MouseDown += SandBoxBase_MouseDown;
            this.Paint += NoInternetConnectionSandBox_Paint;
            this.CancelButton = this.ButtonControl1;
            this.AcceptButton = this.ButtonControl2;
            //Note:
            //The this.ButtonControl1.Click and this.ButtonControl2.Click Events,
            //are setted in the UnderForm(MainForm) for NoConnectionMode.
            //----------------------------------------------
            this.Controls.AddRange(new Control[]
            {
                MessageLabel1,
                MessageLabel2,
                ButtonControl1,
                ButtonControl2
            });
        }
        /// <summary>
        /// This Username Already exists in the game.
        /// </summary>
        private void Initialize_UserAlreadyExist_Component()
        {
            //----------------------------------------------
            //Almost all of the Form Settings, setted in the SandBoxBase class, so you don't need
            // to set something in this place...
            this.Dock = DockStyle.None;
            //this.Focused = true;
            this.HelpButton = false;
            this.CenterToScreen();
            this.BackgroundImageLayout = ImageLayout.Center;
            //----------------------------------------------
            this.MyRes = new WotoRes(typeof(NoInternetConnectionSandBox));
            this.BackgroundImage = Image.FromFile(ThereIsConstants.Path.Datas_Path +
                ThereIsConstants.Path.DoubleSlash + MyRes.GetString(SandBoxBackGNameInRes));
            this.MessageLabel1 = new GameControls.LabelControl(this);
            this.MessageLabel2 = new GameControls.LabelControl(this);
            this.ButtonControl1 = new GameControls.ButtonControl(this);
            //----------------------------------------------
            //names:
            this.MessageLabel1.SetLabelName(SandBoxLabel1NameInRes);
            this.MessageLabel2.SetLabelName(SandBoxLabel2NameInRes);
            this.ButtonControl1.SetButtonName(SandBoxButton1NameInRes);
            //StatusNums:
            this.MessageLabel1.CurrentStatus =
            this.MessageLabel2.CurrentStatus =
            this.ButtonControl1.CurrentStatus = 2;
            //TabIndexes:
            this.MessageLabel1.TabIndex = 0;
            this.MessageLabel2.TabIndex = 1;
            this.ButtonControl1.TabIndex = 2;
            //FontAndTextAligns:
            this.MessageLabel1.Font =
                        new Font(ThereIsConstants.Forming.TheMainForm.PrivateFonts.Families[1],
                        17, FontStyle.Bold);
            this.MessageLabel2.Font =
                new Font(ThereIsConstants.Forming.TheMainForm.PrivateFonts.Families[1],
                15, FontStyle.Bold);
            this.ButtonControl1.Font =
                new Font(ThereIsConstants.Forming.TheMainForm.PrivateFonts.Families[1],
                14.3f, FontStyle.Bold);
            this.MessageLabel1.TextAlign = MessageLabel2.TextAlign = ContentAlignment.MiddleCenter;
            //Styles:
            this.ButtonControl1.FlatStyle = FlatStyle.Flat;
            //Sizes:
            this.MessageLabel1.Size = new Size(Width - from_the_edge,
                        (Height / 3) - (SeparatorLine_Height / 2));
            this.MessageLabel2.Size = new Size(Width - from_the_edge,
                (1 * (Height / 3)) - (SeparatorLine_Height / 2));
            this.ButtonControl1.Size =
                new Size((int)(1.4 * ButtonControl1.Width),
                (int)(1.6 * ButtonControl1.Height));
            this.ButtonControl1.SetOriginalSize(this.ButtonControl1.Size);
            //Locations:

            this.MessageLabel2.Dock = DockStyle.None;
            this.MessageLabel1.Location = new Point(from_the_edge / 2, 0);
            this.MessageLabel2.Location = new Point(MessageLabel1.Location.X, MessageLabel1.Location.Y +
                MessageLabel1.Height + SeparatorLine_Height);
            this.ButtonControl1.Location = new Point((MessageLabel2.Location.X +
                (MessageLabel2.Width / 2)) - (ButtonControl1.Width / 2),
                MessageLabel2.Location.Y + MessageLabel2.Height +
                (3 * ThereIsConstants.AppSettings.Between_GameControls));
            this.ButtonControl1.SetOriginalLocation(ButtonControl1.Location);
            //Colors:
            this.MessageLabel1.SetColorTransparent();
            this.MessageLabel2.SetColorTransparent();
            this.ButtonControl1.ForeColor = Color.White;
            this.ButtonControl1.BackColor = Color.Black;
            this.MessageLabel1.ForeColor = MessageLabel2.ForeColor = Color.White;
            //this.MessageLabel1.BackColor = MessageLabel2.BackColor = Color.Transparent;
            //ComboBoxes:
            //Enableds:
            //Texts:
            //MessageBox.Show(MessageLabel1.Text);
            //That was for Debugging.
            this.MessageLabel1.SetLabelText();
            this.MessageLabel2.SetLabelText();
            this.ButtonControl1.SetButtonText();
            //AddRanges:
            //ToolTipSettings:
            //----------------------------------------------
            //Events:
            this.MessageLabel1.MouseDown += SandBoxBase_MouseDown;
            this.MessageLabel2.MouseDown += SandBoxBase_MouseDown;
            this.Paint += NoInternetConnectionSandBox_Paint;
            this.ButtonControl1.Click += ButtonControl1_Click;
            this.CancelButton = this.ButtonControl1;
            this.AcceptButton = this.ButtonControl1;
            //----------------------------------------------
            this.Controls.AddRange(new Control[]
            {
                MessageLabel1,
                MessageLabel2,
                ButtonControl1,
            });
        }
        /// <summary>
        /// Username or password you entered is wrong.
        /// </summary>
        private void Initialize_UNOrPassWrong_Component()
        {
            //----------------------------------------------
            //Almost all of the Form Settings, setted in the SandBoxBase class, so you don't need
            // to set something in this place...
            this.Dock = DockStyle.None;
            //this.Focused = true;
            this.HelpButton = false;
            this.CenterToScreen();
            this.BackgroundImageLayout = ImageLayout.Center;
            //----------------------------------------------
            this.MyRes = new WotoRes(typeof(NoInternetConnectionSandBox));
            this.BackgroundImage = Image.FromFile(ThereIsConstants.Path.Datas_Path +
                ThereIsConstants.Path.DoubleSlash + MyRes.GetString(SandBoxBackGNameInRes));
            this.MessageLabel1 = new GameControls.LabelControl(this);
            this.MessageLabel2 = new GameControls.LabelControl(this);
            this.ButtonControl1 = new GameControls.ButtonControl(this);
            //----------------------------------------------
            //names:
            this.MessageLabel1.SetLabelName(SandBoxLabel1NameInRes);
            this.MessageLabel2.SetLabelName(SandBoxLabel2NameInRes);
            this.ButtonControl1.SetButtonName(SandBoxButton1NameInRes);
            //StatusNums:
            this.MessageLabel1.CurrentStatus =
            this.MessageLabel2.CurrentStatus = 3;
            this.ButtonControl1.CurrentStatus = 2;
            //TabIndexes:
            this.MessageLabel1.TabIndex = 0;
            this.MessageLabel2.TabIndex = 1;
            this.ButtonControl1.TabIndex = 2;
            //FontAndTextAligns:
            this.MessageLabel1.Font =
                        new Font(ThereIsConstants.Forming.TheMainForm.PrivateFonts.Families[1],
                        17, FontStyle.Bold);
            this.MessageLabel2.Font =
                new Font(ThereIsConstants.Forming.TheMainForm.PrivateFonts.Families[1],
                15, FontStyle.Bold);
            this.ButtonControl1.Font =
                new Font(ThereIsConstants.Forming.TheMainForm.PrivateFonts.Families[1],
                14.3f, FontStyle.Bold);
            this.MessageLabel1.TextAlign = MessageLabel2.TextAlign = ContentAlignment.MiddleCenter;
            //Styles:
            this.ButtonControl1.FlatStyle = FlatStyle.Flat;
            //Sizes:

            this.MessageLabel1.Size = new Size(Width - from_the_edge,
                (Height / 3) - (SeparatorLine_Height / 2));
            this.MessageLabel2.Size = new Size(Width - from_the_edge,
                (1 * (Height / 3)) - (SeparatorLine_Height / 2));
            this.ButtonControl1.Size =
                new Size((int)(1.4 * ButtonControl1.Width),
                (int)(1.6 * ButtonControl1.Height));
            this.ButtonControl1.SetOriginalSize(this.ButtonControl1.Size);
            //Locations:

            this.MessageLabel2.Dock = DockStyle.None;
            this.MessageLabel1.Location = new Point(from_the_edge / 2, 0);
            this.MessageLabel2.Location = new Point(MessageLabel1.Location.X, MessageLabel1.Location.Y +
                MessageLabel1.Height + SeparatorLine_Height);
            this.ButtonControl1.Location = new Point((MessageLabel2.Location.X +
                (MessageLabel2.Width / 2)) - (ButtonControl1.Width / 2),
                MessageLabel2.Location.Y + MessageLabel2.Height +
                (3 * ThereIsConstants.AppSettings.Between_GameControls));
            this.ButtonControl1.SetOriginalLocation(ButtonControl1.Location);
            //Colors:
            this.MessageLabel1.SetColorTransparent();
            this.MessageLabel2.SetColorTransparent();
            this.ButtonControl1.ForeColor = Color.White;
            this.ButtonControl1.BackColor = Color.Black;
            this.MessageLabel1.ForeColor = MessageLabel2.ForeColor = Color.White;
            //this.MessageLabel1.BackColor = MessageLabel2.BackColor = Color.Transparent;
            //ComboBoxes:
            //Enableds:
            //Texts:
            //MessageBox.Show(MessageLabel1.Text);
            //That was for Debugging.
            this.MessageLabel1.SetLabelText();
            this.MessageLabel2.SetLabelText();
            this.ButtonControl1.SetButtonText();
            //AddRanges:
            //ToolTipSettings:
            //----------------------------------------------
            //Events:
            this.MessageLabel1.MouseDown += SandBoxBase_MouseDown;
            this.MessageLabel2.MouseDown += SandBoxBase_MouseDown;
            this.Paint += NoInternetConnectionSandBox_Paint;
            this.ButtonControl1.Click += ButtonControl1_Click;
            this.CancelButton = this.ButtonControl1;
            this.AcceptButton = this.ButtonControl1;
            //----------------------------------------------
            Controls.AddRange(new Control[]
            {
                MessageLabel1,
                MessageLabel2,
                ButtonControl1,
            });
        }
        /// <summary>
        /// Cannot load your profile...
        /// </summary>
        private void Initialize_CantLoadYrProf_Component()
        {
            //----------------------------------------------
            //Almost all of the Form Settings, setted in the SandBoxBase class, so you don't need
            // to set something in this place...
            this.Dock = DockStyle.None;
            //this.Focused = true;
            this.HelpButton = false;
            this.CenterToScreen();
            this.BackgroundImageLayout = ImageLayout.Center;
            //----------------------------------------------
            this.MyRes = new WotoRes(typeof(NoInternetConnectionSandBox));
            this.BackgroundImage = Image.FromFile(ThereIsConstants.Path.Datas_Path +
                ThereIsConstants.Path.DoubleSlash + MyRes.GetString(SandBoxBackGNameInRes));
            this.MessageLabel1 = new GameControls.LabelControl(this);
            this.MessageLabel2 = new GameControls.LabelControl(this);
            this.ButtonControl1 = new GameControls.ButtonControl(this);
            //----------------------------------------------
            //names:
            this.MessageLabel1.SetLabelName(SandBoxLabel1NameInRes);
            this.MessageLabel2.SetLabelName(SandBoxLabel2NameInRes);
            this.ButtonControl1.SetButtonName(SandBoxButton1NameInRes);
            //StatusNums:
            this.MessageLabel1.CurrentStatus =
            this.MessageLabel2.CurrentStatus = 4;
            this.ButtonControl1.CurrentStatus = 2;
            //TabIndexes:
            this.MessageLabel1.TabIndex = 0;
            this.MessageLabel2.TabIndex = 1;
            this.ButtonControl1.TabIndex = 2;
            //FontAndTextAligns:
            this.MessageLabel1.Font =
                        new Font(ThereIsConstants.Forming.TheMainForm.PrivateFonts.Families[1],
                        17, FontStyle.Bold);
            this.MessageLabel2.Font =
                new Font(ThereIsConstants.Forming.TheMainForm.PrivateFonts.Families[1],
                15, FontStyle.Bold);
            this.ButtonControl1.Font =
                new Font(ThereIsConstants.Forming.TheMainForm.PrivateFonts.Families[1],
                14.3f, FontStyle.Bold);
            this.MessageLabel1.TextAlign = MessageLabel2.TextAlign = ContentAlignment.MiddleCenter;
            //Styles:
            this.ButtonControl1.FlatStyle = FlatStyle.Flat;
            //Sizes:

            this.MessageLabel1.Size = new Size(Width - from_the_edge,
                (Height / 3) - (SeparatorLine_Height / 2));
            this.MessageLabel2.Size = new Size(Width - from_the_edge,
                (1 * (Height / 3)) - (SeparatorLine_Height / 2));
            this.ButtonControl1.Size =
                new Size((int)(1.4 * ButtonControl1.Width),
                (int)(1.6 * ButtonControl1.Height));
            this.ButtonControl1.SetOriginalSize(this.ButtonControl1.Size);
            //Locations:

            this.MessageLabel2.Dock = DockStyle.None;
            this.MessageLabel1.Location = new Point(from_the_edge / 2, 0);
            this.MessageLabel2.Location = new Point(MessageLabel1.Location.X, MessageLabel1.Location.Y +
                MessageLabel1.Height + SeparatorLine_Height);
            this.ButtonControl1.Location = new Point((MessageLabel2.Location.X +
                (MessageLabel2.Width / 2)) - (ButtonControl1.Width / 2),
                MessageLabel2.Location.Y + MessageLabel2.Height +
                (3 * ThereIsConstants.AppSettings.Between_GameControls));
            this.ButtonControl1.SetOriginalLocation(ButtonControl1.Location);
            //Colors:
            this.MessageLabel1.SetColorTransparent();
            this.MessageLabel2.SetColorTransparent();
            this.ButtonControl1.ForeColor = Color.White;
            this.ButtonControl1.BackColor = Color.Black;
            this.MessageLabel1.ForeColor = MessageLabel2.ForeColor = Color.White;
            //this.MessageLabel1.BackColor = MessageLabel2.BackColor = Color.Transparent;
            //ComboBoxes:
            //Enableds:
            //Texts:
            //MessageBox.Show(MessageLabel1.Text);
            //That was for Debugging.
            this.MessageLabel1.SetLabelText();
            this.MessageLabel2.SetLabelText();
            this.ButtonControl1.SetButtonText();
            //AddRanges:
            //ToolTipSettings:
            //----------------------------------------------
            //Events:
            this.MessageLabel1.MouseDown += SandBoxBase_MouseDown;
            this.MessageLabel2.MouseDown += SandBoxBase_MouseDown;
            this.Paint += NoInternetConnectionSandBox_Paint;
            this.ButtonControl1.Click += ButtonControl1_Click;
            this.CancelButton = this.ButtonControl1;
            this.AcceptButton = this.ButtonControl1;
            //----------------------------------------------
            Controls.AddRange(new Control[]
            {
                MessageLabel1,
                MessageLabel2,
                ButtonControl1,
            });
        }
        /// <summary>
        /// Connection Closed!
        /// </summary>
        private void Initialize_ConnectionClosed_Component()
        {
            //----------------------------------------------
            //Almost all of the Form Settings, setted in the SandBoxBase class, so you don't need
            // to set something in this place...
            this.Dock = DockStyle.None;
            //this.Focused = true;
            this.HelpButton = false;
            this.CenterToScreen();
            this.BackgroundImageLayout = ImageLayout.Center;
            //----------------------------------------------
            this.MyRes = new WotoRes(typeof(NoInternetConnectionSandBox));
            this.BackgroundImage = Image.FromFile(ThereIsConstants.Path.Datas_Path +
                ThereIsConstants.Path.DoubleSlash + MyRes.GetString(SandBoxBackGNameInRes));
            this.MessageLabel1 = new GameControls.LabelControl(this);
            this.MessageLabel2 = new GameControls.LabelControl(this);
            this.ButtonControl1 = new GameControls.ButtonControl(this);
            //----------------------------------------------
            //names:
            this.MessageLabel1.SetLabelName(SandBoxLabel1NameInRes);
            this.MessageLabel2.SetLabelName(SandBoxLabel2NameInRes);
            this.ButtonControl1.SetButtonName(SandBoxButton1NameInRes);
            //StatusNums:
            this.MessageLabel1.CurrentStatus =
            this.MessageLabel2.CurrentStatus = 5;
            this.ButtonControl1.CurrentStatus = 1;
            //TabIndexes:
            this.MessageLabel1.TabIndex = 0;
            this.MessageLabel2.TabIndex = 1;
            this.ButtonControl1.TabIndex = 2;
            //FontAndTextAligns:
            this.MessageLabel1.Font =
                        new Font(ThereIsConstants.Forming.TheMainForm.PrivateFonts.Families[1],
                        17, FontStyle.Bold);
            this.MessageLabel2.Font =
                new Font(ThereIsConstants.Forming.TheMainForm.PrivateFonts.Families[1],
                15, FontStyle.Bold);
            this.ButtonControl1.Font =
                new Font(ThereIsConstants.Forming.TheMainForm.PrivateFonts.Families[1],
                14.3f, FontStyle.Bold);
            this.MessageLabel1.TextAlign = MessageLabel2.TextAlign = ContentAlignment.MiddleCenter;
            //Styles:
            this.ButtonControl1.FlatStyle = FlatStyle.Flat;
            //Sizes:

            this.MessageLabel1.Size = new Size(Width - from_the_edge,
                (Height / 3) - (SeparatorLine_Height / 2));
            this.MessageLabel2.Size = new Size(Width - from_the_edge,
                (1 * (Height / 3)) - (SeparatorLine_Height / 2));
            this.ButtonControl1.Size =
                new Size((int)(1.4 * ButtonControl1.Width),
                (int)(1.6 * ButtonControl1.Height));
            this.ButtonControl1.SetOriginalSize(this.ButtonControl1.Size);
            //Locations:

            this.MessageLabel2.Dock = DockStyle.None;
            this.MessageLabel1.Location = new Point(from_the_edge / 2, 0);
            this.MessageLabel2.Location = new Point(MessageLabel1.Location.X, MessageLabel1.Location.Y +
                MessageLabel1.Height + SeparatorLine_Height);
            this.ButtonControl1.Location = new Point((MessageLabel2.Location.X +
                (MessageLabel2.Width / 2)) - (ButtonControl1.Width / 2),
                MessageLabel2.Location.Y + MessageLabel2.Height +
                (3 * ThereIsConstants.AppSettings.Between_GameControls));
            this.ButtonControl1.SetOriginalLocation(ButtonControl1.Location);
            //Colors:
            this.MessageLabel1.SetColorTransparent();
            this.MessageLabel2.SetColorTransparent();
            this.ButtonControl1.ForeColor = Color.White;
            this.ButtonControl1.BackColor = Color.Black;
            this.MessageLabel1.ForeColor = MessageLabel2.ForeColor = Color.White;
            //this.MessageLabel1.BackColor = MessageLabel2.BackColor = Color.Transparent;
            //ComboBoxes:
            //Enableds:
            //Texts:
            //MessageBox.Show(MessageLabel1.Text);
            //That was for Debugging.
            this.MessageLabel1.SetLabelText();
            this.MessageLabel2.SetLabelText();
            this.ButtonControl1.SetButtonText();
            //AddRanges:
            //ToolTipSettings:
            //----------------------------------------------
            //Events:
            this.MessageLabel1.MouseDown += SandBoxBase_MouseDown;
            this.MessageLabel2.MouseDown += SandBoxBase_MouseDown;
            this.Paint += NoInternetConnectionSandBox_Paint;
            this.ButtonControl1.Click += ButtonControl1_Click;
            this.CancelButton = this.ButtonControl1;
            this.AcceptButton = this.ButtonControl1;
            //----------------------------------------------
            Controls.AddRange(new Control[]
            {
                MessageLabel1,
                MessageLabel2,
                ButtonControl1,
            });
        }
        /// <summary>
        /// Loged out successfully.
        /// </summary>
        private void Initialize_LogedOutSuccessfully_Component()
        {
            //----------------------------------------------
            //Almost all of the Form Settings, setted in the SandBoxBase class, so you don't need
            // to set something in this place...
            this.Dock = DockStyle.None;
            //this.Focused = true;
            this.HelpButton = false;
            this.CenterToScreen();
            this.BackgroundImageLayout = ImageLayout.Center;
            //----------------------------------------------
            this.MyRes = new WotoRes(typeof(NoInternetConnectionSandBox));
            this.BackgroundImage = Image.FromFile(ThereIsConstants.Path.Datas_Path +
                ThereIsConstants.Path.DoubleSlash + MyRes.GetString(SandBoxBackGNameInRes));
            this.MessageLabel1 = new GameControls.LabelControl(this);
            this.MessageLabel2 = new GameControls.LabelControl(this);
            this.ButtonControl1 = new GameControls.ButtonControl(this);
            //----------------------------------------------
            //names:
            this.MessageLabel1.SetLabelName(SandBoxLabel1NameInRes);
            this.MessageLabel2.SetLabelName(SandBoxLabel2NameInRes);
            this.ButtonControl1.SetButtonName(SandBoxButton1NameInRes);
            //StatusNums:
            this.MessageLabel1.CurrentStatus =
            this.MessageLabel2.CurrentStatus = 6;
            this.ButtonControl1.CurrentStatus = 2;
            //TabIndexes:
            this.MessageLabel1.TabIndex = 0;
            this.MessageLabel2.TabIndex = 1;
            this.ButtonControl1.TabIndex = 2;
            //FontAndTextAligns:
            this.MessageLabel1.Font =
                        new Font(ThereIsConstants.Forming.TheMainForm.PrivateFonts.Families[1],
                        17, FontStyle.Bold);
            this.MessageLabel2.Font =
                new Font(ThereIsConstants.Forming.TheMainForm.PrivateFonts.Families[1],
                15, FontStyle.Bold);
            this.ButtonControl1.Font =
                new Font(ThereIsConstants.Forming.TheMainForm.PrivateFonts.Families[1],
                14.3f, FontStyle.Bold);
            this.MessageLabel1.TextAlign = MessageLabel2.TextAlign = ContentAlignment.MiddleCenter;
            //Styles:
            this.ButtonControl1.FlatStyle = FlatStyle.Flat;
            //Sizes:

            this.MessageLabel1.Size = new Size(Width - from_the_edge,
                (Height / 3) - (SeparatorLine_Height / 2));
            this.MessageLabel2.Size = new Size(Width - from_the_edge,
                (1 * (Height / 3)) - (SeparatorLine_Height / 2));
            this.ButtonControl1.Size =
                new Size((int)(1.4 * ButtonControl1.Width),
                (int)(1.6 * ButtonControl1.Height));
            this.ButtonControl1.SetOriginalSize(this.ButtonControl1.Size);
            //Locations:

            this.MessageLabel2.Dock = DockStyle.None;
            this.MessageLabel1.Location = new Point(from_the_edge / 2, 0);
            this.MessageLabel2.Location = new Point(MessageLabel1.Location.X, MessageLabel1.Location.Y +
                MessageLabel1.Height + SeparatorLine_Height);
            this.ButtonControl1.Location = new Point((MessageLabel2.Location.X +
                (MessageLabel2.Width / 2)) - (ButtonControl1.Width / 2),
                MessageLabel2.Location.Y + MessageLabel2.Height +
                (3 * ThereIsConstants.AppSettings.Between_GameControls));
            this.ButtonControl1.SetOriginalLocation(ButtonControl1.Location);
            //Colors:
            this.MessageLabel1.SetColorTransparent();
            this.MessageLabel2.SetColorTransparent();
            this.ButtonControl1.ForeColor = Color.White;
            this.ButtonControl1.BackColor = Color.Black;
            this.MessageLabel1.ForeColor = MessageLabel2.ForeColor = Color.White;
            //this.MessageLabel1.BackColor = MessageLabel2.BackColor = Color.Transparent;
            //ComboBoxes:
            //Enableds:
            //Texts:
            //MessageBox.Show(MessageLabel1.Text);
            //That was for Debugging.
            this.MessageLabel1.SetLabelText();
            this.MessageLabel2.SetLabelText();
            this.ButtonControl1.SetButtonText();
            //AddRanges:
            //ToolTipSettings:
            //----------------------------------------------
            //Events:
            this.MessageLabel1.MouseDown += SandBoxBase_MouseDown;
            this.MessageLabel2.MouseDown += SandBoxBase_MouseDown;
            this.Paint += NoInternetConnectionSandBox_Paint;
            this.ButtonControl1.Click += ButtonControl1_Click;
            this.CancelButton = this.ButtonControl1;
            this.AcceptButton = this.ButtonControl1;
            //----------------------------------------------
            Controls.AddRange(new Control[]
            {
                MessageLabel1,
                MessageLabel2,
                ButtonControl1,
            });
        }
        private void Initialize_LogOutWarning_Component()
        {
            //----------------------------------------------
            //Almost all of the Form Settings, setted in the SandBoxBase class, so you don't need
            // to set something in this place...
            this.Dock = DockStyle.None;
            //this.Focused = true;
            this.HelpButton = false;
            this.CenterToScreen();
            this.BackgroundImageLayout = ImageLayout.Center;
            //----------------------------------------------
            this.MyRes = new WotoRes(typeof(NoInternetConnectionSandBox));
            this.BackgroundImage = Image.FromFile(ThereIsConstants.Path.Datas_Path +
                ThereIsConstants.Path.DoubleSlash + MyRes.GetString(SandBoxBackGNameInRes));
            this.MessageLabel1 = new GameControls.LabelControl(this);
            this.MessageLabel2 = new GameControls.LabelControl(this);
            this.ButtonControl1 = new GameControls.ButtonControl(this);
            this.ButtonControl2 = new GameControls.ButtonControl(this);
            //----------------------------------------------
            //names:
            this.MessageLabel1.SetLabelName(SandBoxLabel1NameInRes);
            this.MessageLabel2.SetLabelName(SandBoxLabel2NameInRes);
            this.ButtonControl1.SetButtonName(SandBoxButton1NameInRes);
            this.ButtonControl2.SetButtonName(SandBoxButton2NameInRes);
            //StatusNums:
            this.MessageLabel1.CurrentStatus =
            this.MessageLabel2.CurrentStatus = 7;
            this.ButtonControl1.CurrentStatus = 3;
            this.ButtonControl2.CurrentStatus = 2;
            //TabIndexes:
            this.MessageLabel1.TabIndex = 0;
            this.MessageLabel2.TabIndex = 1;
            this.ButtonControl1.TabIndex = 2;
            this.ButtonControl2.TabIndex = 3;

            //FontAndTextAligns:
            this.MessageLabel1.Font =
                        new Font(ThereIsConstants.Forming.TheMainForm.PrivateFonts.Families[1],
                        17, FontStyle.Bold);
            this.MessageLabel2.Font =
                new Font(ThereIsConstants.Forming.TheMainForm.PrivateFonts.Families[1],
                15, FontStyle.Bold);
            this.ButtonControl1.Font = this.ButtonControl2.Font =
                new Font(ThereIsConstants.Forming.TheMainForm.PrivateFonts.Families[1],
                14.3f, FontStyle.Bold);
            this.MessageLabel1.TextAlign = MessageLabel2.TextAlign = ContentAlignment.MiddleCenter;
            //Styles:
            this.ButtonControl1.FlatStyle = this.ButtonControl2.FlatStyle = FlatStyle.Flat;
            //Sizes:
            this.MessageLabel1.Size = new Size(Width - from_the_edge,
                        (Height / 3) - (SeparatorLine_Height / 2));
            this.MessageLabel2.Size = new Size(Width - from_the_edge,
                (1 * (Height / 3)) - (SeparatorLine_Height / 2));
            this.ButtonControl1.Size = ButtonControl2.Size =
                new Size((int)(1.4 * ButtonControl1.Width),
                (int)(1.6 * ButtonControl1.Height));
            this.ButtonControl1.SetOriginalSize(this.ButtonControl1.Size);
            this.ButtonControl2.SetOriginalSize(this.ButtonControl2.Size);
            //Locations:
            this.MessageLabel2.Dock = DockStyle.None;
            this.MessageLabel1.Location = new Point(from_the_edge / 2, 0);
            this.MessageLabel2.Location = new Point(MessageLabel1.Location.X, MessageLabel1.Location.Y +
                MessageLabel1.Height + SeparatorLine_Height);
            this.ButtonControl1.Location = new Point((MessageLabel2.Location.X +
                (MessageLabel2.Width / 2)) - (ButtonControl1.Width / 2) - (6 * from_the_edge),
                MessageLabel2.Location.Y + MessageLabel2.Height +
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
            this.ButtonControl1.BackColor = this.ButtonControl2.BackColor = Color.Black;
            this.MessageLabel1.ForeColor = MessageLabel2.ForeColor = Color.White;
            //this.MessageLabel1.BackColor = MessageLabel2.BackColor = Color.Transparent;
            //ComboBoxes:
            //Enableds:
            //Texts:
            //MessageBox.Show(MessageLabel1.Text);
            //That was for Debugging.

            this.MessageLabel1.SetLabelText();
            this.MessageLabel2.SetLabelText();
            this.ButtonControl1.SetButtonText();
            this.ButtonControl2.SetButtonText();
            //AddRanges:
            //ToolTipSettings:
            //----------------------------------------------
            //Events:
            this.MessageLabel1.MouseDown += SandBoxBase_MouseDown;
            this.MessageLabel2.MouseDown += SandBoxBase_MouseDown;
            this.ButtonControl1.Click += ButtonControl1_Click;
            this.Paint += NoInternetConnectionSandBox_Paint;
            this.CancelButton = this.ButtonControl1;
            this.AcceptButton = this.ButtonControl2;
            //Note:
            //The this.ButtonControl1.Click and this.ButtonControl2.Click Events,
            //are setted in the UnderForm(MainForm) for NoConnectionMode.
            //----------------------------------------------
            this.Controls.AddRange(new Control[]
            {
                MessageLabel1,
                MessageLabel2,
                ButtonControl1,
                ButtonControl2
            });
        }
        /// <summary>
        /// No Internet Connection!
        /// </summary>
        private void Initialize_ClosingSandBox_Component()
        {
            //----------------------------------------------
            //Almost all of the Form Settings, setted in the SandBoxBase class, so you don't need
            // to set something in this place...
            this.Dock = DockStyle.None;
            //this.Focused = true;
            this.HelpButton = false;
            this.CenterToScreen();
            this.BackgroundImageLayout = ImageLayout.Center;
            //----------------------------------------------
            this.MyRes = new WotoRes(typeof(NoInternetConnectionSandBox));
            this.BackgroundImage = Image.FromFile(ThereIsConstants.Path.Datas_Path +
                ThereIsConstants.Path.DoubleSlash + MyRes.GetString(SandBoxBackGNameInRes));
            this.MessageLabel1 = new GameControls.LabelControl(this);
            this.MessageLabel2 = new GameControls.LabelControl(this);
            this.ButtonControl1 = new GameControls.ButtonControl(this);
            this.ButtonControl2 = new GameControls.ButtonControl(this);
            //----------------------------------------------
            //names:
            this.MessageLabel1.SetLabelName(SandBoxLabel1NameInRes);
            this.MessageLabel2.SetLabelName(SandBoxLabel2NameInRes);
            this.ButtonControl1.SetButtonName(SandBoxButton1NameInRes);
            this.ButtonControl2.SetButtonName(SandBoxButton2NameInRes);
            //StatusNums:
            this.MessageLabel1.CurrentStatus =
            this.MessageLabel2.CurrentStatus = 8;
            this.ButtonControl1.CurrentStatus = 3;
            this.ButtonControl2.CurrentStatus = 3;
            //TabIndexes:
            this.MessageLabel1.TabIndex = 0;
            this.MessageLabel2.TabIndex = 1;
            this.ButtonControl1.TabIndex = 2;
            this.ButtonControl2.TabIndex = 3;

            //FontAndTextAligns:
            this.MessageLabel1.Font =
                        new Font(ThereIsConstants.Forming.TheMainForm.PrivateFonts.Families[1],
                        17, FontStyle.Bold);
            this.MessageLabel2.Font =
                new Font(ThereIsConstants.Forming.TheMainForm.PrivateFonts.Families[1],
                15, FontStyle.Bold);
            this.ButtonControl1.Font = this.ButtonControl2.Font =
                new Font(ThereIsConstants.Forming.TheMainForm.PrivateFonts.Families[1],
                14.3f, FontStyle.Bold);
            this.MessageLabel1.TextAlign = MessageLabel2.TextAlign = ContentAlignment.MiddleCenter;
            //Styles:
            this.ButtonControl1.FlatStyle = this.ButtonControl2.FlatStyle = FlatStyle.Flat;
            //Sizes:
            this.MessageLabel1.Size = new Size(Width - from_the_edge,
                        (Height / 3) - (SeparatorLine_Height / 2));
            this.MessageLabel2.Size = new Size(Width - from_the_edge,
                (1 * (Height / 3)) - (SeparatorLine_Height / 2));
            this.ButtonControl1.Size = ButtonControl2.Size =
                new Size((int)(1.4 * ButtonControl1.Width),
                (int)(1.6 * ButtonControl1.Height));
            this.ButtonControl1.SetOriginalSize(this.ButtonControl1.Size);
            this.ButtonControl2.SetOriginalSize(this.ButtonControl2.Size);
            //Locations:
            this.MessageLabel2.Dock = DockStyle.None;
            this.MessageLabel1.Location = new Point(from_the_edge / 2, 0);
            this.MessageLabel2.Location = new Point(MessageLabel1.Location.X, MessageLabel1.Location.Y +
                MessageLabel1.Height + SeparatorLine_Height);
            this.ButtonControl1.Location = new Point((MessageLabel2.Location.X +
                (MessageLabel2.Width / 2)) - (ButtonControl1.Width / 2) - (6 * from_the_edge),
                MessageLabel2.Location.Y + MessageLabel2.Height +
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
            this.ButtonControl1.BackColor = this.ButtonControl2.BackColor = Color.Black;
            this.MessageLabel1.ForeColor = MessageLabel2.ForeColor = Color.White;
            //this.MessageLabel1.BackColor = MessageLabel2.BackColor = Color.Transparent;
            //ComboBoxes:
            //Enableds:
            //Texts:
            //MessageBox.Show(MessageLabel1.Text);
            //That was for Debugging.

            this.MessageLabel1.SetLabelText();
            this.MessageLabel2.SetLabelText();
            this.ButtonControl1.SetButtonText();
            this.ButtonControl2.SetButtonText();
            //AddRanges:
            //ToolTipSettings:
            //----------------------------------------------
            //Events:
            this.MessageLabel1.MouseDown += SandBoxBase_MouseDown;
            this.MessageLabel2.MouseDown += SandBoxBase_MouseDown;
            this.Paint += NoInternetConnectionSandBox_Paint;
            this.CancelButton = this.ButtonControl1;
            this.AcceptButton = this.ButtonControl2;
            //Note:
            //The this.ButtonControl1.Click and this.ButtonControl2.Click Events,
            //are setted in the UnderForm(MainForm) for NoConnectionMode.
            //----------------------------------------------
            this.Controls.AddRange(new Control[]
            {
                MessageLabel1,
                MessageLabel2,
                ButtonControl1,
                ButtonControl2
            });
        }
        //--------------------------------------------------------------
        //--------------------------------------------------------------
        /// <summary>
        /// The Button Click :|
        /// for closing button though.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonControl1_Click(object sender, EventArgs e)
        {
            if(Mode == SandBoxMode.Cant_LoadYourProfileMode || Mode == SandBoxMode.LoggedOutSuccessfullyMode)
            {
                if (ThereIsConstants.Forming.TheMainForm.IsShowingSandBox)
                {
                    if (ThereIsConstants.Forming.TheMainForm.ShowingSandBox is CreateProfileSandBox mySandBox)
                    {
                        ThereIsConstants.Actions.ClearingPlayerProfile();
                        ClosedForRetry = true;
                        mySandBox.ClosedForRetry = true;
                        this.Close();
                        mySandBox.Close();
                    }
                }
                else
                {
                    ThereIsConstants.Actions.ClearingPlayerProfile();
                    ClosedForRetry = true;
                    this.Close();
                }
            }
            else if(Mode == SandBoxMode.ConnectionClosedMode)
            {
                if(ThereIsConstants.Forming.GameClient != null)
                {
                    ThereIsConstants.Forming.GameClient.Close();
                }
                else
                {
                    ThereIsConstants.Forming.TheMainForm.Close();
                }
            }
            else
            {
                ClosedForRetry = true;
                this.Close();
            }
            
        }

        //--------------------------------------------------------------
        private void NoInternetConnectionSandBox_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(new Pen(Color.White, 5), MessageLabel1.Location.X,
                MessageLabel1.Location.Y + MessageLabel1.Height, MessageLabel1.Location.X +
                MessageLabel1.Width, MessageLabel1.Location.Y + MessageLabel1.Height);
        }
        //--------------------------------------------------------------
        //--------------------------------------------------------------
        public static NoInternetConnectionSandBox PrepareConnectionClosedSandBox()
        {
            if (ThereIsServer.ServerSettings.HasConnectionClosed)
            {
                MessageBox.Show("BOOL WAS TRUE");
            }
#pragma warning disable CS0162
            throw new Exception();
            if (ThereIsConstants.AppSettings.IsShowingClosedSandBox || 
                ThereIsConstants.AppSettings.ConnectionClosedSandBox != null)
            {
                return ThereIsConstants.AppSettings.ConnectionClosedSandBox;
            }
            NoInternetConnectionSandBox connectionClosedSandBox;
            if (ThereIsConstants.Forming.GameClient != null && ThereIsConstants.Forming.GameClient.Visible)
            {
                connectionClosedSandBox =
                    new NoInternetConnectionSandBox(SandBoxMode.ConnectionClosedMode,
                        ThereIsConstants.Forming.GameClient);
                if (ThereIsConstants.Forming.GameClient.IsShowingSandBox)
                {
                    ThereIsConstants.Forming.GameClient.ShowingSandBox.
                        SetTheHighestSandBox(connectionClosedSandBox);
                }
                else
                {
                    ThereIsConstants.Forming.GameClient.IsShowingSandBox = true;
                    ThereIsConstants.Forming.GameClient.ShowingSandBox =
                        connectionClosedSandBox;
                }
                connectionClosedSandBox.Show();
                ThereIsConstants.AppSettings.IsShowingClosedSandBox = true;
                ThereIsConstants.AppSettings.ConnectionClosedSandBox = connectionClosedSandBox;
                return connectionClosedSandBox;
            }
            else
            {
                connectionClosedSandBox =
                    new NoInternetConnectionSandBox(SandBoxMode.ConnectionClosedMode,
                        ThereIsConstants.Forming.TheMainForm);
                if (ThereIsConstants.Forming.TheMainForm.IsShowingSandBox)
                {
                    ThereIsConstants.Forming.TheMainForm.ShowingSandBox.
                        SetTheHighestSandBox(connectionClosedSandBox);
                }
                else
                {
                    ThereIsConstants.Forming.TheMainForm.IsShowingSandBox = true;
                    ThereIsConstants.Forming.TheMainForm.ShowingSandBox =
                        connectionClosedSandBox;
                }
                connectionClosedSandBox.Show();
                ThereIsConstants.AppSettings.IsShowingClosedSandBox = true;
                ThereIsConstants.AppSettings.ConnectionClosedSandBox = connectionClosedSandBox;
                return connectionClosedSandBox;
            }

#pragma warning restore CS0162
        }
        public static NoInternetConnectionSandBox PrepareLogoutWarningSandBox()
        {
            NoInternetConnectionSandBox connectionClosedSandBox;
            if (ThereIsConstants.Forming.GameClient != null && ThereIsConstants.Forming.GameClient.Visible)
            {
                connectionClosedSandBox =
                    new NoInternetConnectionSandBox(SandBoxMode.LogoutWarningMode,
                        ThereIsConstants.Forming.GameClient);
                if (ThereIsConstants.Forming.GameClient.IsShowingSandBox)
                {
                    ThereIsConstants.Forming.GameClient.ShowingSandBox.
                        SetTheHighestSandBox(connectionClosedSandBox);
                }
                else
                {
                    ThereIsConstants.Forming.GameClient.IsShowingSandBox = true;
                    ThereIsConstants.Forming.GameClient.ShowingSandBox =
                        connectionClosedSandBox;
                }
                connectionClosedSandBox.Show();
                return connectionClosedSandBox;
            }
            else
            {
                connectionClosedSandBox =
                    new NoInternetConnectionSandBox(SandBoxMode.LogoutWarningMode,
                        ThereIsConstants.Forming.TheMainForm);
                if (ThereIsConstants.Forming.TheMainForm.IsShowingSandBox)
                {
                    ThereIsConstants.Forming.TheMainForm.ShowingSandBox.GetTheHighestSandBox(true);
                    ThereIsConstants.Forming.TheMainForm.ShowingSandBox.
                        SetTheHighestSandBox(connectionClosedSandBox);
                }
                else
                {
                    ThereIsConstants.Forming.TheMainForm.IsShowingSandBox = true;
                    ThereIsConstants.Forming.TheMainForm.ShowingSandBox =
                        connectionClosedSandBox;
                }
                connectionClosedSandBox.Show();
                return connectionClosedSandBox;
            }
        }
        //--------------------------------------------------------------




        #endregion
    }
}
