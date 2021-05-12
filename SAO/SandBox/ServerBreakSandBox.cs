// Copyright (C) ALiwoto 2019 - 2020
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of the source code.

using SAO.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAO.SandBox
{
    public partial class ServerBreakSandBox : SandBoxBase
    {
        protected override SandBoxMode Mode { get; }
        public bool ClosedForRetry { get; set; }
        //--------------------------------------------------
        /// <summary>
        /// The First MessageLabel that shows the user: Server is on Break!.
        /// </summary>
        public GameControls.LabelControl MessageLabel1;
        /// <summary>
        /// The second MessageLabel that show the user: Server is on Break in this time,
        /// please try agian later.
        /// </summary>
        public GameControls.LabelControl MessageLabel2;
        /// <summary>
        /// Exit Button in ServerBreakSandBox.
        /// </summary>
        public GameControls.ButtonControl ButtonControl1;
        /// <summary>
        /// Retry Button in ServerBreakSandBox.
        /// </summary>
        public GameControls.ButtonControl ButtonControl2;
        //-------------------------------------------------
        /// <summary>
        /// The name of MessageLabel2 in the Resources without _name,
        /// <see cref="MessageLabel1"/>
        /// </summary>
        public const string SandBoxLabel1NameInRes = "SandBoxLabel1";
        /// <summary>
        /// The name of MessageLabel2 in the Resources without _name,
        /// <see cref="MessageLabel2"/>
        /// </summary>
        public const string SandBoxLabel2NameInRes = "SandBoxLabel2";
        /// <summary>
        /// The name of Button1 in the Resources without _name,
        /// <see cref="ButtonControl1"/>
        /// </summary>
        public const string SandBoxButton1NameInRes = "SandBoxButton1";
        /// <summary>
        /// The name of Button1 in the Resources without _name,
        /// <see cref="ButtonControl2"/>
        /// </summary>
        public const string SandBoxButton2NameInRes = "SandBoxButton2";
        //-------------------------------------------------
        public ServerBreakSandBox(GameControls.PageControl UnderForm) : base(UnderForm)
        {
            Mode = SandBoxMode.ServerOnBreakMode;
            ClosedForRetry = false;
            InitializeComponent();
        }
    }
}
