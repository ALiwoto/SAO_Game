// Copyright (C) ALiwoto 2019 - 2020
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of the source code.

using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Drawing.Text;
using System.Security;
using System.Globalization;
using System.Media;
using SAO.Constants;
using SAO.Controls;
using SAO.SandBox;
using SAO.LoadingService;

namespace SAO.SandBox
{
    public partial class FirstStoryLineSandBox : SandBoxBase
    {
        //---------------------------------------------
        //----------------------------------------------
        /// <summary>
        /// If you are in the first story mode, then:
        /// This is the MessageLabel tha should be displayed at
        /// left page of the <see cref="BookPictureBox"/>.
        /// But if you are in the Element selection Mode,
        /// this is the MessageLabel1.
        /// </summary>
        public GameControls.LabelControl MessageLabel1 { get; set; }
        /// <summary>
        /// If you are in the first story mode, then:
        /// This is the MessageLabel tha should be displayed at
        /// Right page of the <see cref="BookPictureBox"/>.
        /// But if you are in the Element selection Mode,
        /// this is the MessageLabel2.
        /// </summary>
        public GameControls.LabelControl MessageLabel2 { get; set; }
        /// <summary>
        /// If you are in the first story mode, then:
        /// This MessageLabel should be displayed on the <see cref="MyHallSandBox"/>,
        /// and It says: "Click on the Book" ...
        /// But if you are in the Element selection Mode,
        /// this is the MessageLabel3.
        /// </summary>
        public GameControls.LabelControl MessageLabel3 { get; set; }
        /// <summary>
        /// This is MessageLabel4 which should be assigned only in the 
        /// Element Selection Mode.
        /// </summary>
        public GameControls.LabelControl MessageLabel4 { get; set; }
        /// <summary>
        /// This is MessageLabel5 which should be assigned only in the 
        /// Element Selection Mode.
        /// </summary>
        public GameControls.LabelControl MessageLabel5 { get; set; }
        /// <summary>
        /// This is MessageLabel6 which should be assigned only in the 
        /// Element Selection Mode.
        /// </summary>
        public GameControls.LabelControl MessageLabel6 { get; set; }
        /// <summary>
        /// This is MessageLabel7 which should be assigned only in the 
        /// Element Selection Mode.
        /// </summary>
        public GameControls.LabelControl MessageLabel7 { get; set; }
        /// <summary>
        /// This is PictureBoxControl1 which should be assigned only in the 
        /// Element Selection Mode.
        /// </summary>
        public GameControls.PictureBoxControl PictureBoxControl1 { get; set; }
        /// <summary>
        /// This is PictureBoxControl1 which should be assigned only in the 
        /// Element Selection Mode.
        /// </summary>
        public GameControls.PictureBoxControl PictureBoxControl2 { get; set; }
        /// <summary>
        /// This is PictureBoxControl1 which should be assigned only in the 
        /// Element Selection Mode.
        /// </summary>
        public GameControls.PictureBoxControl PictureBoxControl3 { get; set; }
        /// <summary>
        /// This is PictureBoxControl1 which should be assigned only in the 
        /// Element Selection Mode.
        /// </summary>
        public GameControls.PictureBoxControl PictureBoxControl4 { get; set; }
        /// <summary>
        /// This is PictureBoxControl1 which should be assigned only in the 
        /// Element Selection Mode.
        /// </summary>
        public GameControls.PictureBoxControl PictureBoxControl5 { get; set; }
        /// <summary>
        /// This is PictureBoxControl1 which should be assigned only in the 
        /// Element Selection Mode.
        /// </summary>
        public GameControls.PictureBoxControl PictureBoxControl6 { get; set; }

        /// <summary>
        /// This is PictureBoxControl7 which should be assigned only in the 
        /// Element Selection Mode.
        /// </summary>
        public GameControls.PictureBoxControl PictureBoxControl7 { get; set; }

        /// <summary>
        /// This is BookPictureBox which should be assigned only in the 
        /// First StoryLine Mode.
        /// </summary>
        public GameControls.PictureBoxControl BookPictureBox { get; set; }
        //----------------------------------------------
        public bool UseAnimation { get; set; }
        protected override SandBoxMode Mode { get; }
        //----------------------------------------------
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
        /// The name of MessageLabel6 in the Resources without _name,
        /// <see cref="MessageLabel6"/>
        /// </summary>
        public const string SandBoxLabel6NameInRes = "SandBoxLabel6";
        /// <summary>
        /// The name of MessageLabel6 in the Resources without _name,
        /// <see cref="MessageLabel6"/>
        /// </summary>
        public const string SandBoxLabel7NameInRes = "SandBoxLabel7";
        /// <summary>
        /// The Book Image File Name :|.
        /// </summary>
        public const string BookImageFileNameInRes = "BookImageFileName";

        /// <summary>
        /// The Element bg Image File Name :|.
        /// </summary>
        public const string ElementBGFileNameInRes = "ElementBgFileName";
        public const string ElementPicControl1NameInRes = "ElementPicControl1";
        public const string ElementPicControl2NameInRes = "ElementPicControl2";
        public const string ElementPicControl3NameInRes = "ElementPicControl3";
        public const string ElementPicControl4NameInRes = "ElementPicControl4";
        public const string ElementPicControl5NameInRes = "ElementPicControl5";
        public const string ElementPicControl6NameInRes = "ElementPicControl6";
        public const string ElementPicControl7NameInRes = "ElementPicControl7";
        //----------------------------------------------
        public FirstStoryLineSandBox(GameControls.PageControl CurrentForm, bool useAnimation = false,
            SandBoxMode myMode = SandBoxMode.FirstStoryLineMode) :
            base(CurrentForm, new CustomDesign()
            {
                SandBoxOpacity = 1,
                CustomControlCollection = null,
                SandBoxBackGroundImage = null,
                SandBoxButtons = null,
                Dont_Set_Location = true,
                Dont_Set_Size = true,
                ShowInTaskBar = false,
                SandBoxKeyPreview = false,
                SupportTransParentBackGroundColors = true
            })
        {
            UseAnimation    = useAnimation;
            Mode            = myMode;
            switch (Mode)
            {
                case SandBoxMode.FirstStoryLineMode:
                    Initialize_BookStory_Component();
                    break;
                case SandBoxMode.ElementSelectionMode:
                    Initialize_ElementSelection_Component();
                    break;
                default:
                    break;
            }
        }
    }
}
