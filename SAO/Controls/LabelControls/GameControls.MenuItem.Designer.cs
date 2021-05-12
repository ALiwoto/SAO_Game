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
using System.Drawing.Drawing2D;

namespace SAO.Controls
{
    partial class GameControls
    {
        partial class MenuItem
        {



            #region Windows Form Designer generated code

            /// <summary>
            /// Required method for Designer support - do not modify
            /// the contents of this method with the code editor.
            /// </summary>
            private void InitializeComponent()
            {
                //-----------------------------------------------
                //News:
                //-----------------------------------------------
                //Names:
                //TabIndexes:
                //FontsAndTextAligns:
                this.Font = new Font(new FontFamily("Segoe UI"), 18, 
                    FontStyle.Italic | FontStyle.Bold);
                this.TextAlign = ContentAlignment.MiddleCenter;
                //Sizes:
                this.OriginalSize = this.Size = new Size(ItemWidth, ItemHeight);
                //Locations:
                //Colors:
                this.BackColor = Color.Transparent;
                this.ForeColor = Color.FromArgb(250, Color.WhiteSmoke);
                //ComboBoxes:
                //Enableds:
                //Texts:
                //AddRanges:
                //ToolTipSettings:
                //PolygonSettings:
                XStartPolygon = YStartPolygon = 10;
                WidthOfPolygon = 8 * (Width / 10);
                HeightOfPolygon = 8 * (Height / 10);
                LeanOfPolygon = 36;
                //-----------------------------------------------
                //Events:
                this.SizeChanged += MenuItem_SizeChanged;
                this.Paint += MenuItem_Paint;
                this.MouseEnter += MenuItem_MouseEnter;
                this.MouseLeave += MenuItem_MouseLeave;
                //-----------------------------------------------
            }

            private void MenuItem_SizeChanged(object sender, EventArgs e)
            {
                //XStartPolygon = YStartPolygon = 10;
                WidthOfPolygon = 8 * (Width / 10);
                HeightOfPolygon = 8 * (Height / 10);
                //LeanOfPolygon = 36;
            }

            private void MenuItem_MouseLeave(object sender, EventArgs e)
            {
                this.Size = OriginalSize;
                this.Location = OriginalLocation;
            }

            private void MenuItem_MouseEnter(object sender, EventArgs e)
            {
                this.Size = new Size((int)(1.13 * Size.Width), (int)(1.13 * Size.Height));
                this.Location = new Point(Location.X - (int)(0.03 * Size.Width),
                    Location.Y - (int)(0.03 * Size.Height));
            }

            private void MenuItem_Paint(object sender, PaintEventArgs e)
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.FillPolygon(new SolidBrush(Color.FromArgb(80, Color.Black)), new Point[]
                {
                    new Point(XStartPolygon, YStartPolygon),
                    new Point(XStartPolygon + LeanOfPolygon, YStartPolygon + HeightOfPolygon),
                    new Point(XStartPolygon + LeanOfPolygon + WidthOfPolygon, YStartPolygon + HeightOfPolygon),
                    new Point(XStartPolygon + WidthOfPolygon, YStartPolygon)
                });
            }





            #endregion
        }
    }
    
}
