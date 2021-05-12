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
        #region ALiwoto Design Region
        partial class ButtonControl
        {
            private void InitializeComponent()
            {
                //--------------------------------------
                this.FlatAppearance.BorderSize = 0;
                this.Paint += ButtonControl_Paint;
                this.MouseEnter += ButtonControl_MouseEnter;
                this.MouseLeave += ButtonControl_MouseLeave;
                //--------------------------------------
                //--------------------------------------
            }


            private void ButtonControl_Paint(object sender, PaintEventArgs e)
            {
                if (!Dont_Paint)
                {
                    e.Graphics.DrawPolygon(new Pen(this.ForeColor, 3.4f),
                    new Point[] {
                        new Point((Width / 10), 0),
                        new Point(Width - 1, 0),
                        new Point(Width - 1, 2 * (Height / 3)),
                        new Point(9 * (Width / 10), Height - 1),
                        new Point(0, Height - 1),
                        new Point(0, 1 * (Height / 3)),
                    });
                }
            }

            private void ButtonControl_MouseLeave(object sender, EventArgs e)
            {
                this.Size = OriginaleSize;
                this.Location = OriginalLocation;
            }

            private void ButtonControl_MouseEnter(object sender, EventArgs e)
            {
                this.Size = new Size((int)(1.13 * Size.Width), (int)(1.13 * Size.Height));
                this.Location = new Point(Location.X - (int)(0.13 * Size.Width),
                    Location.Y - (int)(0.13 * Size.Height));
            }

            //-------------------------------------------------
            /// <summary>
            /// Set the Button.Name Property with the Constant Parameter writed
            /// in ThereIsConstants.ResourcesNames.
            /// </summary>
            /// <param name="ConstParam">
            /// The Constant Parameter setted in <code> ThereIsConstants.ResourcesNames </code> 
            /// and in
            /// MainForm.MyRes.
            /// </param>
            public void SetButtonName(string ConstParam)
            {
                this.Name = ConstParam +
                    ThereIsConstants.ResourcesName.End_Res_Name;
            }
            /// <summary>
            /// This Function will set the Button.Text Property with the algorithm
            /// from MainForm.MyRes.
            /// </summary>
            public void SetButtonText()
            {
                this.Text = 
                    this.MyRes.GetString(
                    this.MyRes.GetString(this.Name) +
                    ThereIsConstants.ResourcesName.Separate_Character + 
                    ThereIsConstants.AppSettings.Language +
                    this.CurrentStatus.ToString());
            }
            public void SetButtonBackGround()
            {
                this.BackgroundImage = Image.FromFile(ThereIsConstants.Path.Datas_Path +
                    ThereIsConstants.Path.DoubleSlash +
                    this.MyRes.GetString(
                    this.MyRes.GetString(this.Name) +
                    ThereIsConstants.ResourcesName.Separate_Character +
                    ThereIsConstants.AppSettings.Language +
                    this.CurrentStatus.ToString()));
            }
            //-------------------------------------------------
            /// <summary>
            /// Setting the this.BackColor Parameter to Color.Transparent.
            /// </summary>
            public void SetColorTransparent()
            {
                this.BackColor = Color.Transparent;
            }
            //------------------------------------------------
            public void SetOriginalSize(Size theSize)
            {
                this.OriginaleSize = theSize;
            }
            public void SetOriginalLocation(Point theLocation)
            {
                this.OriginalLocation = theLocation;
            }
        }

        #endregion
    }
}