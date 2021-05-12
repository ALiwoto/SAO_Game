// Copyright (C) ALiwoto 2019 - 2020
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of the source code.

using System.IO;
using System.Windows.Forms;
using SAO.Constants;
using SAO.Controls;

namespace SAO.LoadingService
{
    public partial class ServerConfiguration : GameControls.PageControl
    {
        /// <summary>
        /// ServerConfiguration MessageLabel in the first page of this Form, <code></code>
        /// and it should be ServerStatus MessageLabel in the Second page of this Form.
        /// </summary>
        public Label MessageLabel1;
        /// <summary>
        /// UpdateList MessageLabel on the first page of this Form, <code></code>
        /// and theLastVersion MessageLabel on the Second page of this Form.
        /// </summary>
        public Label MessageLabel2;
        /// <summary>
        /// Some Bullshit that not setted in the first page of this Form,
        /// <code></code> and it should be updateInfoPath MessageLabel in the Second page of this Form.
        /// </summary>
        public Label MessageLabel3;
        /// <summary>
        /// accessDate that should use in the Second page of this Form.
        /// </summary>
        public Label MessageLabel4;
        /// <summary>
        /// Config Button in front of: <see cref="MessageLabel1"/>,
        /// </summary>
        public Button Button1;
        /// <summary>
        /// Config Button in front of: <see cref="MessageLabel2"/>,
        /// </summary>
        public Button Button2;
        /// <summary>
        /// Config Button in front of: <see cref="MessageLabel3"/>,
        /// </summary>
        public Button Button3;
        /// <summary>
        /// TextBox1 in the front of <see cref="MessageLabel1"/> 
        /// in the second page of this Form that should get the Server Status 
        /// from the admin, <code> </code>
        /// Server Status should be <c> 85 </c> for <see cref="ServerStatus.Online"/>
        /// <code></code>
        /// or be <c> 100 </c> for <see cref="ServerStatus.Updating"/> <code></code>
        /// or be <c> 200 </c> for <see cref="ServerStatus.Breaking"/> to convert.
        /// </summary>
        public TextBox TextBox1;
        /// <summary>
        /// TextBox2 is theLastVersion textBox that should be in front of <see cref="MessageLabel2"/>, 
        /// <code></code> and it should get a string that can be converted to a <see cref="GameVersion"/>
        /// Obj via <see cref="GameVersion.ParseToVersion(string)"/>
        /// </summary>
        public TextBox TextBox2;
        /// <summary>
        /// this is the updateInfoPath textBox that should appear in front of <see cref="MessageLabel3"/> in
        /// the Second page of this Form.
        /// </summary>
        public TextBox TextBox3;
        /// <summary>
        /// accessDate TextBox that should appear in front of <see cref="MessageLabel4"/> in the
        /// Second page of this Form.
        /// </summary>
        public TextBox TextBox4;
        private const int myWidth = 100;
        private const int myHeight = 40;

        public ServerConfiguration()
        {
            InitializeComponent();
            if(!Directory.Exists(ThereIsConstants.Path.main_Path +
                    ThereIsConstants.Path.ServerManager_Folder_Name))
            {
                Directory.CreateDirectory(ThereIsConstants.Path.main_Path +
                    ThereIsConstants.Path.ServerManager_Folder_Name);
            }
        }
        //--------------------------------------
        



        //---------------------------------------
        public void HideAll()
        {
            for (int i = 0; i < Controls.Count; i++)
            {
                Control myControl = Controls[i];
                if (myControl is TextBox || myControl is Label || myControl is Button
                    || myControl is GroupBox || myControl is RadioButton || myControl is ComboBox)
                {
                    myControl.Hide();
                }
            }
        }
    }
}
