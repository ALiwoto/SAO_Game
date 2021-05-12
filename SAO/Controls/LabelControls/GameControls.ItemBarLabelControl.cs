// Copyright (C) ALiwoto 2019 - 2020
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of the source code.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAO.SandBox;

namespace SAO.Controls
{
    partial class GameControls
    {
        public partial class ItemBarLabelControl : LabelControl
        {
            //-------------------------------------
            public bool IsSelected { get; set; }
            //-------------------------------------
            //-------------------------------------
            //-------------------------------------
            public ItemBarLabelControl(IRes myRes, LabelControlSpecies myMode,
                SandBoxBase myFather = null) : base(myRes,
                    myMode, myFather, false)
            {

                switch (DesigningMode)
                {
                    case LabelControlSpecies.ItemBarLabel:
                        InitializeComponent();
                        break;
                    default:
                        break;
                }
            }
        }
    }
    
}
