using System;
using System.Drawing;
using System.Windows.Forms;
using SAO.Constants;
namespace SAO.Controls
{
    partial class GameControls
    {
        partial class TextBoxControl
        {
            private void InitializeComponent()
            {
                this.CustomToolTip = new ToolTip();
                //--------------------------------------
                this.MouseEnter += TextBoxControl_MouseEnter;
                this.MouseLeave += TextBoxControl_MouseLeave;
                //--------------------------------------
                //--------------------------------------
            }

            private void TextBoxControl_MouseLeave(object sender, EventArgs e)
            {
                //this.Size = OriginaleSize;
                //this.Location = OriginalLocation;
            }

            private void TextBoxControl_MouseEnter(object sender, EventArgs e)
            {
                //this.Size = new Size((int)(1.13 * Size.Width), (int)(1.13 * Size.Height));
                //this.Location = new Point(Location.X - (int)(0.13 * Size.Width),
                    //Location.Y - (int)(0.13 * Size.Height));
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
            public void SetTextBoxName(string ConstParam)
            {
                this.Name = ConstParam +
                    ThereIsConstants.ResourcesName.End_Res_Name;
            }
            /// <summary>
            /// This Function will set the Button.Text Property with the algorithm
            /// from MainForm.MyRes.
            /// </summary>
            public void SetTextBoxText()
            {
                this.Text = this.MyRes.GetString(
                    this.MyRes.GetString(this.Name) +
                    ThereIsConstants.ResourcesName.Separate_Character + 
                    ThereIsConstants.AppSettings.Language +
                    this.CurrentStatus.ToString());
            }
            public void SetTextBoxText(string theText)
            {
                this.Text = theText;
            }
            //-------------------------------------------------
            //-------------------------------------------------
            /// <summary>
            /// Setting the this.BackColor Parameter to Color.Transparent.
            /// </summary>
            public void SetColorTransparent()
            {
                this.BackColor = Color.Transparent;
            }
            //-------------------------------------------------
            #region overrides Region
            protected override void WndProc(ref Message m)
            {
                if (m.Msg == WM_SETFOCUS && DisableSelection)
                {
                    m.Msg = WM_KILLFOCUS;
                }
                if (m.Msg == EM_SHOWBALLOONTIP && UseCustomToolTip)
                {
                    m.Msg = 0;
                    m.Result = (IntPtr)0;
                }
                base.WndProc(ref m);
            }
            protected override void OnDragEnter(DragEventArgs drgevent)
            {
                drgevent.Effect = DragDropEffects.Copy;
                this.Text = (string)drgevent.Data.GetData(DataFormats.Text);
            }
            protected override void OnDragLeave(EventArgs e)
            {
                this.Text = "";
            }
            #endregion
        }
    }
}
