using System.Windows.Forms;
using System.Drawing;
using SAO.Controls;
using SAO.Constants;
using SAO.GameObjects.Resources;
namespace SAO.SandBox
{
    partial class YuiLoadingSandbox
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        //private System.ComponentModel.IContainer components = null;
        #region ALiwoto Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            //----------------------------------------------
            //Almost all of the Form Settings, setted in the SandBoxBase class, so you don't need
            // to set something in this place...
            this.Dock = DockStyle.None;
            //this.Focused = true;
            this.HelpButton = false;
            this.TopMost = true;
            //SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.StartPosition = FormStartPosition.CenterScreen;
            //----------------------------------------------
            this.MyRes = new WotoRes(typeof(YuiLoadingSandbox));
            this.YuiWaitingPictureBox = new GameControls.PictureBoxControl(this);
            this.YuiImage = new Bitmap(ThereIsConstants.Path.Datas_Path + ThereIsConstants.Path.DoubleSlash +
                                MyRes.GetString(YuiPicNameInRes));
            this.AnimationFactory = new Trigger()
            {
                Interval    = 45,
                Enabled     = false,
                Index       = 0,
            };
            this.UnlimitedRectangleFWorks = new RectangleF[]
            {
                //-----------------------------------------
		        //"00":{"x":541,"y":324,"w":178,"h":153},
		        //"01":{"x":359,"y":337,"w":178,"h":155},
		        //"02":{"x":538,"y":1,"w":174,"h":160}
		        //"03":{"x":356,"y":170,"w":174,"h":163},
		        //"04":{"x":1,"y":343,"w":175,"h":165},
		        //"05":{"x":1,"y":1,"w":175,"h":167},
		        //"06":{"x":179,"y":172,"w":173,"h":166},
		        //"07":{"x":1,"y":172,"w":174,"h":167},
		        //"08":{"x":180,"y":1,"w":174,"h":165},
		        //"09":{"x":180,"y":342,"w":175,"h":163},
                //"10":{"x":359,"y":1,"w":175,"h":160},
		        //"11":{"x":534,"y":165,"w":177,"h":155},
                //-----------------------------------------
                new RectangleF(new PointF(541, 324), new SizeF(178, 153)), // index : 0
                new RectangleF(new PointF(359, 337), new SizeF(178, 155)), // index : 1
                new RectangleF(new PointF(538, 1),   new SizeF(174, 160)), // index : 2
                new RectangleF(new PointF(356, 170), new SizeF(174, 163)), // index : 3
                new RectangleF(new PointF(1, 343),   new SizeF(175, 165)), // index : 4
                new RectangleF(new PointF(1, 1),     new SizeF(175, 167)), // index : 5
                new RectangleF(new PointF(179, 172), new SizeF(173, 166)), // index : 6
                new RectangleF(new PointF(1, 172),   new SizeF(174, 167)), // index : 7
                new RectangleF(new PointF(180, 1),   new SizeF(174, 165)), // index : 8
                new RectangleF(new PointF(180, 342), new SizeF(175, 163)), // index : 9
                new RectangleF(new PointF(359, 1),   new SizeF(175, 160)), // index : 10
                new RectangleF(new PointF(534, 165), new SizeF(177, 155)), // index : 11
            };
            //----------------------------------------------
            //names:

            //PictureBoxes:
            //this.YuiWaitingPictureBox.Image = Properties.Resources.YuiLoading;
            this.YuiWaitingPictureBox.Image =
                ThereIsConstants.Actions.CropImage(YuiImage,
                new RectangleF(new PointF(541, 324), new SizeF(178, 153)));
            TheW++;
            //TabIndexes:

            //FontAndTextAligns:

            //Styles:

            //Sizes:
            this.Size =
                this.YuiWaitingPictureBox.Size =
                new Size(180, 170);
            
            //Locations:

            //Colors:
            this.Opacity = 1;
            this.BackColor = Color.GhostWhite;
            this.TransparencyKey = Color.GhostWhite;
            //this.YuiWaitingPictureBox.BackColor = Color.Transparent;
            //ComboBoxes:
            //Enableds:
            //Texts:
            //AddRanges:
            //ToolTipSettings:
            //----------------------------------------------
            //Events:
            this.AnimationFactory.Tick += AnimationFactoryWorker;
            //----------------------------------------------
            Controls.AddRange(new Control[]
            {
                YuiWaitingPictureBox
            });
            AnimationFactory.Enabled = true;
        }
        public void AnimationFactoryWorker(object sender, System.EventArgs e)
        {
            if(YuiWaitingPictureBox == null || YuiWaitingPictureBox.IsDisposed || this.IsDisposed)
            {
                ((Timer)sender).Enabled = false;
                ((Timer)sender).Dispose();
            }

            this.YuiWaitingPictureBox.Image =
                            ThereIsConstants.Actions.CropImage(YuiImage, 
                            UnlimitedRectangleFWorks[TheW]);
            if(TheW == 11)
            {
                TheW = 0;
            }
            else
            {
                TheW++;
            }
            
        }
        //---------------------------------------
        protected override void Dispose(bool disposing)
        {
            this.AnimationFactory.Stop();
            this.AnimationFactory.Dispose();
            base.Dispose(disposing);
        }

        #endregion
    }
}
