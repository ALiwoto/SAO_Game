using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;
using SAO.Constants;

namespace SAO.SandBox
{
    partial class SandBoxBase
    {
        //private IContainer components = null;
        //----------------------------------------------
        private void InitializeComponent()
        {
            if (!HasCustomDesign)
            {
                //this.components = new Container();
                this.AutoScaleMode = AutoScaleMode.Font;
                this.StartPosition = FormStartPosition.CenterParent;
                this.Size = new Size(2 * (UnderForm.Width / 5), UnderForm.Height / 3);
                this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer, true);
                this.KeyPreview = true;
                this.FormBorderStyle = FormBorderStyle.None;
                this.BackColor = Color.Black;
                this.Opacity = 0.7;
                //this.ShowInTaskbar = false;
            }
            else
            {
                //MessageBox.Show("HERE");
                this.AutoScaleMode = AutoScaleMode.Font;
                if (!SandBoxCustomDesign.Dont_Set_Size)
                {
                    if (SandBoxCustomDesign.SandBoxSize.Width != 0 &&
                        SandBoxCustomDesign.SandBoxSize.Height != 0)
                    {
                        this.Size = SandBoxCustomDesign.SandBoxSize;
                    }
                    else
                    {
                        this.Size = new Size(2 * (UnderForm.Width / 5), UnderForm.Height / 3);
                    }
                }
                if (SandBoxCustomDesign.SupportTransParentBackGroundColors)
                {
                    this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer | 
                        ControlStyles.SupportsTransparentBackColor, 
                        true);
                }
                else
                {
                    this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer, true);
                }
                
                this.KeyPreview = SandBoxCustomDesign.SandBoxKeyPreview;
                this.FormBorderStyle = FormBorderStyle.None;
                if(SandBoxCustomDesign.SandBoxBackColor != Color.Empty)
                {
                    this.BackColor = SandBoxCustomDesign.SandBoxBackColor;
                }
                else
                {
                    this.BackColor = Color.Black;
                }
                this.Opacity = SandBoxCustomDesign.SandBoxOpacity;
                if (SandBoxCustomDesign.CustomControlCollection != null)
                {
                    foreach (Control myControl in SandBoxCustomDesign.CustomControlCollection)
                    {
                        Controls.Add(myControl);
                    }
                }
                
            }
            //Events:
            this.MouseDown += SandBoxBase_MouseDown;
            this.FormClosed += SandBoxBase_FormClosed;
        }

        private void SandBoxBase_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.UnderForm.Enabled = true;
            this.UnderForm.Focus();
            this.UnderForm.BringToFront();
        }
        protected virtual void SandBoxBase_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                ThereIsConstants.Actions.ReleaseCapture();
                ThereIsConstants.Actions.SendMessage(Handle, ThereIsConstants.Actions.WM_NCLBUTTONDOWN,
                    ThereIsConstants.Actions.HT_CAPTION, 0);
            }
        }
        //----------------------------------------------
        /// <summary>
        /// Close the <see cref="SandBoxBase"/>
        /// </summary>
        /// <param name="closedByMe"></param>
        public void Close(bool closedByMe)
        {
            this.ClosedByMe = closedByMe;
            base.Close();
        }
        public void RemoveMovingClicking()
        {
            MouseDown -= SandBoxBase_MouseDown;
        }
        public void RemoveAllPainting()
        {
            FieldInfo f1 = typeof(Control).GetField("EventPaint",
                BindingFlags.Static | BindingFlags.NonPublic);

            object obj = f1.GetValue(this);
            PropertyInfo pi = this.GetType().GetProperty("Events",
                BindingFlags.NonPublic | BindingFlags.Instance);

            EventHandlerList list = (EventHandlerList)pi.GetValue(this, null);
            list.RemoveHandler(obj, list[obj]);
            //---------------------------------
            //---------------------------------
        }
        //----------------------------------------------
        protected override void OnGotFocus(EventArgs e)
        {
            if(IsShowingAnotherSandBox && ShowingAnotherSandBox != null)
            {
                ShowingAnotherSandBox.Focus();
            }
            else
            {

            }
            base.OnGotFocus(e);
        }

        //----------------------------------------------
    }
}
