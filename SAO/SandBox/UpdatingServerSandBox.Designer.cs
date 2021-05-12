// Copyright (C) ALiwoto 2019 - 2020
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of the source code.

using System.Windows.Forms;
using System.Drawing;
using SAO.Controls;
using SAO.Constants;
using SAO.GameObjects.Resources;
namespace SAO.SandBox
{
    partial class UpdatingServerSandBox
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        //private System.ComponentModel.IContainer components = null;


        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            //----------------------------------------------
            //Almost all of the Form Settings, setted in the SandBoxBase class, so you don't need
            // to set something in this place...
            this.Dock = DockStyle.None;
            //this.Focused = true;
            this.HelpButton = false;
            //----------------------------------------------
            this.MyRes = new WotoRes(typeof(UpdatingServerSandBox));
            this.MessageLabel1 = new GameControls.LabelControl(this);
            this.MessageLabel2 = new GameControls.LabelControl(this);
            this.ButtonControl1 = new GameControls.ButtonControl(this);
            this.ButtonControl2 = new GameControls.ButtonControl(this);
            //----------------------------------------------
            //names:
            this.MessageLabel1.SetLabelName(SandBoxLabel1NameInRes);
            //MessageBox.Show(MessageLabel1.Name);
            this.MessageLabel2.SetLabelName(SandBoxLabel2NameInRes);
            this.ButtonControl1.SetButtonName(SandBoxButton1NameInRes);
            this.ButtonControl2.SetButtonName(SandBoxButton2NameInRes);
            //TabIndexes:
            this.MessageLabel1.TabIndex = 0;
            this.MessageLabel2.TabIndex = 1;
            this.ButtonControl1.TabIndex = 2;
            this.ButtonControl1.TabIndex = 3;
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
            //this.MessageLabel1.BackColor = MessageLabel2.BackColor = Color.Transparent;
            this.MessageLabel1.ForeColor = MessageLabel2.ForeColor = Color.White;
            //ComboBoxes:
            //Enableds:
            //Texts:
            this.MessageLabel1.SetLabelText();
            //MessageBox.Show(MessageLabel1.Text);
            //That was for Debugging.
            this.MessageLabel2.SetLabelText();
            this.MessageLabel2.Text += " " + ReleaseDate;
            this.ButtonControl1.SetButtonText();
            this.ButtonControl2.SetButtonText();
            //AddRanges:
            //ToolTipSettings:
            //----------------------------------------------
            //Events:
            this.MessageLabel1.MouseDown += SandBoxBase_MouseDown;
            this.MessageLabel2.MouseDown += SandBoxBase_MouseDown;
            this.Paint += UpdatingServerSandBox_Paint;
            //----------------------------------------------
            Controls.AddRange(new Control[]
            {
                MessageLabel1,
                MessageLabel2,
                ButtonControl1,
                ButtonControl2
            });
        }
        //---------------------------------------
        private void UpdatingServerSandBox_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(new Pen(Color.White, 5), MessageLabel1.Location.X,
                MessageLabel1.Location.Y + MessageLabel1.Height, MessageLabel1.Location.X +
                MessageLabel1.Width, MessageLabel1.Location.Y + MessageLabel1.Height);
        }

        #endregion
    }
}
