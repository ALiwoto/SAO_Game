using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using SAO.Constants;

namespace SAO.Controls
{
    partial class GameControls
    {
        public partial class MenuItem : LabelControl
        {
            private const int ItemWidth = 310;
            private const int ItemHeight = 80;
            private int XStartPolygon;
            private int YStartPolygon;
            private int WidthOfPolygon;
            private int HeightOfPolygon;
            private int LeanOfPolygon;
            public Size OriginalSize { get; set; }
            public Point OriginalLocation { get; set; }
            public MenuItem(IRes myIRes) : base(myIRes)
            {
                InitializeComponent();
            }
        }
    }
    
}
