// Copyright (C) ALiwoto 2019 - 2020
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of the source code.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using SAO.Controls;
using SAO.Constants;

namespace SAO.Controls
{
    partial class GameControls
    {
        partial class MapElement
        {
            //---------------------------------
            private void InitializeComponent()
            {

                //----------------------------------
                //News:

                //----------------------------------
                //Names:
                //TabIndexes
                //FontAndTextAligns:

                //Sizes:
                //Locations:
                //Colors:

                //ComboBoxes:
                //Enableds:
                //Texts:
                //AddRanges:
                //ToolTipSettings:
                //----------------------------------
                //Events:
                this.MouseDown += MapElement_MouseDown;
                //----------------------------------
            }

            private void MapElement_MouseDown(object sender, MouseEventArgs e)
            {
                switch (this.ElementMovements)
                {
                    case ElementMovements.VerticalHorizontalMovements:
                        break;
                    case ElementMovements.HorizontalMovements:
                        break;
                    case ElementMovements.VerticalMovements:
                        break;
                    case ElementMovements.NoMovements:
                        break;
                }
            }


            //---------------------------------
            //---------------------------------
            //---------------------------------
            //---------------------------------
        }
    }
}