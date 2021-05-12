﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace SAO.Controls
{
    interface IMoveable
    {
        Point LastPoint { get; set; }
        //--------------------------------------------
        ElementMovements Movements { get; }

        //--------------------------------------------
        //--------------------------------------------
        void Shocker(object sender, MouseEventArgs e);
        void Discharge(object sender, MouseEventArgs e);
        void MoveMe(object sender, MouseEventArgs e);

    }
}
