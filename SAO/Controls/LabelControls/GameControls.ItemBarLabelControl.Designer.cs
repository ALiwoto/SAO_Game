using System;
using System.Drawing;
using System.Windows.Forms;
using SAO.Constants;

namespace SAO.Controls
{
    partial class GameControls
    {
        partial class ItemBarLabelControl
        {
            //---------------------------------
            private void InitializeComponent()
            {
                this.Size = 
                    new Size(24 * ((Father.Width - (24 * (Father.Height / 180))) / 85),
                    (24 * (Father.Height / 180)));
                //----------------------------------
                //News:
                this.UnlimitedPointWorks = new Point[]
                {
                    new Point(Width / 24, Width / 12), // 1
                    new Point((Width / 24) + (Width / 12), Width / 12), // 2
                    new Point((Width / 24) + (Width / 12), 0), // 3
                    new Point(Width, 0), // 4
                    new Point(Width, Height), // 5
                    new Point(0, Height), // 6
                };
                this.MessageLabel1 = new LabelControl(this);
                //----------------------------------
                //Names:
                //TabIndexes
                //FontAndTextAligns:
                this.Font = new Font(ThereIsConstants.Forming.TheMainForm.PrivateFonts.Families[1],
                    20.8f, FontStyle.Bold);
                this.MessageLabel1.TextAlign = this.TextAlign = ContentAlignment.MiddleCenter;
                //Sizes:
                this.MessageLabel1.Size = this.Size;
                //Locations:
                //Colors:
                this.SetColorTransparent();
                this.MessageLabel1.SetColorTransparent();
                this.ForeColor = Color.Black;
                //ComboBoxes:
                //Enableds:
                //Texts:
                this.MessageLabel1.SetLabelSoundEffects(Noises.ClickNoise);
                //AddRanges:
                //ToolTipSettings:
                //----------------------------------
                //Events:
                this.Paint += ItemBarLabelControl_Paint;
                this.SizeChanged += ItemBarLabelControl_SizeChanged;
                //----------------------------------
                this.Controls.Add(this.MessageLabel1);
            }

            private void ItemBarLabelControl_SizeChanged(object sender, EventArgs e)
            {
                this.MessageLabel1.Size = this.Size;
            }

            private void ItemBarLabelControl_Paint(object sender, PaintEventArgs e)
            {
                e.Graphics.FillPolygon(
                    new SolidBrush(Color.FromArgb(210, IsSelected ? Color.Gold : Color.WhiteSmoke)),
                    new Point[]
                    {
                        UnlimitedPointWorks[0], // 1
                        UnlimitedPointWorks[1], // 2
                        UnlimitedPointWorks[2], // 3
                        UnlimitedPointWorks[3], // 4
                        UnlimitedPointWorks[4], // 5
                        UnlimitedPointWorks[5], // 6
                    });
                e.Graphics.FillPie(
                    new SolidBrush(Color.FromArgb(210, IsSelected ? Color.Gold : Color.WhiteSmoke)),
                    new Rectangle(new Point(UnlimitedPointWorks[0].X, 0), 
                    new Size(2 * (UnlimitedPointWorks[2].X - UnlimitedPointWorks[0].X),
                        2 * (UnlimitedPointWorks[0].Y - UnlimitedPointWorks[2].Y))),
                    180, 90);
            }

            public override void ReloadUPW()
            {
                this.UnlimitedPointWorks = new Point[]
                {
                    new Point(Width / 24, Width / 12), // 1
                    new Point((Width / 24) + (Width / 12), Width / 12), // 2
                    new Point((Width / 24) + (Width / 12), 0), // 3
                    new Point(Width, 0), // 4
                    new Point(Width, Height), // 5
                    new Point(0, Height), // 6
                };
            }
            //---------------------------------
            //---------------------------------
            //---------------------------------
            //---------------------------------
        }
    }
}
