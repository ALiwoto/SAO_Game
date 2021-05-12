// Copyright (C) ALiwoto 2019 - 2020
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of the source code.

using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using Octokit;
using SAO.Security;
using SAO.Constants;

namespace SAO.LoadingService
{
    partial class ServerConfiguration
    {
        private void InitializeComponent()
        {
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Size = new Size(Screen.PrimaryScreen.Bounds.Size.Width / 3,
                2 * (Screen.PrimaryScreen.Bounds.Size.Height / 3));
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer, true);
            //this.BackgroundImageLayout = ImageLayout.Stretch;
            this.SetAutoSizeMode(AutoSizeMode.GrowAndShrink);
            this.KeyPreview = true;
            this.StartPosition = FormStartPosition.CenterScreen;
            //this.FormBorderStyle = FormBorderStyle.None;
            //this.BackColor = Color.Black;
            //----------------------------------
            //News:
            this.MessageLabel1 = new System.Windows.Forms.Label();
            this.MessageLabel2 = new System.Windows.Forms.Label();
            this.MessageLabel3 = new System.Windows.Forms.Label();
            this.Button1 = new Button();
            this.Button2 = new Button();
            this.Button3 = new Button();
            //----------------------------------
            //Names:
            //TabInexes:
            //FontsAndTextAligns:
            //Sizes:
            this.MessageLabel1.Size =  this.MessageLabel2.Size =
            this.MessageLabel3.Size =
                new Size(myWidth, myHeight);
            //Locations:
            this.MessageLabel1.Location = new Point(10, 10);
            this.MessageLabel2.Location = new Point(MessageLabel1.Location.X,
                MessageLabel1.Location.Y + MessageLabel1.Height);
            this.MessageLabel3.Location = new Point(MessageLabel2.Location.X,
                MessageLabel2.Location.Y + MessageLabel2.Height);
            this.Button1.Location = new Point(MessageLabel1.Location.X +
                MessageLabel1.Width, MessageLabel1.Location.Y);
            this.Button2.Location = new Point(MessageLabel2.Location.X +
                MessageLabel2.Width, MessageLabel2.Location.Y);
            this.Button3.Location = new Point(MessageLabel3.Location.X +
                MessageLabel3.Width, MessageLabel3.Location.Y);
            //Colors:
            //ComboBoxes:
            //Enableds:
            //Texts:
            this.MessageLabel1.Text = "ServerConfiguration";
            this.MessageLabel2.Text = "UpdateList";
            this.Button1.Text = this.Button2.Text = this.Button3.Text =
                "Config";
            //AddRanges:
            //ToolTipSettings:
            //---------------------------------
            //Events:
            this.Button1.Click += Button1_Click;
            this.Button2.Click += Button2_Click;
            this.Button3.Click += Button3_Click;
            //----------------------------------
            Controls.AddRange(new Control[]
            {
                this.MessageLabel1,
                this.MessageLabel2,
                this.MessageLabel3,
                this.Button1,
                this.Button2,
                this.Button3
            });
        }
        //-------------------------------------------
        //-------------------------------------------
        private void PrepareTheSecondPage()
        {
            //-------------------------------------
            //news:
            this.MessageLabel4 = new System.Windows.Forms.Label();
            this.TextBox1 = new TextBox();
            this.TextBox2 = new TextBox();
            this.TextBox3 = new TextBox();
            this.TextBox4 = new TextBox();
            //-------------------------------------
            //Names:
            //TabInexes:
            //FontAndTextAligns:
            //Sizes:
            this.MessageLabel4.Size = MessageLabel1.Size;
            this.TextBox1.Size = TextBox2.Size = TextBox3.Size = TextBox4.Size =
                new Size(myWidth, TextBox1.Height);
            //Locations:
            this.MessageLabel4.Location = new Point(MessageLabel3.Location.X,
                MessageLabel3.Location.Y + MessageLabel3.Height);
            this.TextBox1.Location = new Point(MessageLabel1.Location.X +
                MessageLabel1.Width + ThereIsConstants.AppSettings.Between_GameControls,
                MessageLabel1.Location.Y);
            this.TextBox2.Location = new Point(MessageLabel2.Location.X +
                MessageLabel2.Width + ThereIsConstants.AppSettings.Between_GameControls,
                MessageLabel2.Location.Y);
            this.TextBox3.Location = new Point(MessageLabel3.Location.X +
                MessageLabel3.Width + ThereIsConstants.AppSettings.Between_GameControls,
                MessageLabel3.Location.Y);
            this.TextBox4.Location = new Point(MessageLabel4.Location.X +
                MessageLabel4.Width + ThereIsConstants.AppSettings.Between_GameControls,
                MessageLabel4.Location.Y);
            this.Button1.Location = new Point(MessageLabel4.Location.X,
                MessageLabel4.Location.Y + MessageLabel4.Height +
                ThereIsConstants.AppSettings.Between_GameControls);
            //Color:
            //ComboBoxes:
            //Enableds:
            //Texts:
            this.MessageLabel1.Text = "Server Status: ";
            this.MessageLabel2.Text = "The Last Version: ";
            this.MessageLabel3.Text = "UpdateInfo Path: ";
            this.MessageLabel4.Text = "Access Date: ";
            this.Button1.Text = "Generate";
            //AddRanges:
            //ToolTipSettings:
            //-------------------------------------
            //Events:
            //-------------------------------------
            Controls.AddRange(new Control[]
            {
                MessageLabel4,
                TextBox1,
                TextBox2,
                TextBox3,
                TextBox4
            });
            //------------------------------------
            //Showing:
            this.MessageLabel1.Show();
            this.MessageLabel2.Show();
            this.MessageLabel3.Show();
            this.MessageLabel4.Show();
            this.TextBox1.Show();
            this.TextBox2.Show();
            this.TextBox3.Show();
            this.TextBox4.Show();
            this.Button1.Show();
        }
        //-------------------------------------------
        //-------------------------------------------

        private void Button3_Click(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if(Button2.Text == "Config")
            {
                UpdateInfo info = new UpdateInfo(GameVersion.BasicVersion, 1, "notSet", "notSet", "NOOOO");
                FileStream myFile = new FileStream(ThereIsConstants.Path.main_Path +
                    ThereIsConstants.Path.ServerManager_Folder_Name +
                    ThereIsConstants.Path.UpdateInfo_File_Name, System.IO.FileMode.OpenOrCreate,
                    FileAccess.ReadWrite);
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(myFile, info);
                myFile.Close();
                myFile.Dispose();
            }

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if(Button1.Text == "Config")
            {
                HideAll();
                PrepareTheSecondPage();
            }
            else if(Button1.Text == "Generate")
            {
                ServerConfig mySrCfg = new ServerConfig((ServerStatus)(Convert.ToInt32(TextBox1.Text)),
                    GameVersion.ParseToVersion(TextBox2.Text), 
                    TextBox3.Text.ToStrong(), 
                    TextBox4.Text.ToStrong());
                if(mySrCfg.ServerStatus == ServerStatus.Online)
                {
                    MessageBox.Show("HI");
                }
                else
                {
                    MessageBox.Show(mySrCfg.ServerStatus.ToString());
                }

            }
            

        }
    }
}