using System;
using System.Drawing;
using System.Windows.Forms;
using WotoProvider.Enums;
using SAO.Constants;

namespace SAO.Controls
{
    partial class GameControls
    {
        partial class MapSigner
        {
            //----------------------------------------------
            #region Short MapSigner Region
            private void Initialize_ForMapSigner_Component()
            {
                this.SingleClick = true;
                //-----------------------------
                //News:
                //-----------------------------
                //Names:
                //TabIndexes:
                //FontsAndTextAligns:
                //Sizes:
                this.Size = new Size(2 * (ThereIsConstants.Forming.GameClient.Width / 56),
                    16 * (ThereIsConstants.Forming.GameClient.Height / 160));
                //Locations:
                this.UnlimitedPointWorks = new Point[]
                {
                    new Point(0, 0), // 1
                    new Point(Width, 0), // 2
                    new Point(Width, 5 * (Height / 8)), // 3
                    new Point(1 * (Width / 2), Height), // 4
                    new Point(0, 5 * (Height / 8)), // 5
                };
                //Colors:
                this.SetColorTransparent();
                //ComboBoxes:
                //Enableds:
                //Texts:
                //AddRanges:
                //ToolTipSettings:
                //Events:
                this.MouseEnter += MapSigner_MouseEnter;
                this.MouseLeave += MapSigner_MouseLeave;
                this.Paint += MapSigner1_Paint;
                //-----------------------------

            }


            private void MapSigner1_Paint(object sender, PaintEventArgs e)
            {
                e.Graphics.FillPolygon(new SolidBrush(Color.FromArgb(225, this.ForeColor)),
                    new Point[]
                    {
                        UnlimitedPointWorks[0], // 1
                        UnlimitedPointWorks[1], // 2
                        UnlimitedPointWorks[2], // 3
                        UnlimitedPointWorks[3], // 4
                        UnlimitedPointWorks[4], // 5

                    });
            }

            private void MapSigner_MouseLeave(object sender, EventArgs e)
            {
                this.Cursor = Cursors.Default;
            }

            private void MapSigner_MouseEnter(object sender, EventArgs e)
            {
                this.Cursor = Cursors.Hand;
            }
            #endregion
            //----------------------------------------------
            //----------------------------------------------
            #region MapDisplayer Region.
            private void Initialize_ForMapDisplayer_Component()
            {
                this.Size = new Size(12 * (ThereIsConstants.Forming.GameClient.Width / 84),
                    2 * (ThereIsConstants.Forming.GameClient.Height / 12));
                //-----------------------------
                //News:
                this.MessageLabel1 = 
                    new InfoLabel(this, this.Father, InfoLabels.MDKSIL);
                this.MessageLabel2 = new LabelControl(this);
                this.PictureBoxControl1 = new PictureBoxControl(this);
                //---------------------------
                this.UnlimitedPointWorks = new Point[]
                {
                    new Point(0, 1 * (Width / 12)), // 1
                    new Point(1 * (Width / 12), 1 * (Width / 12)), // 2
                    new Point(1 * (Width / 12), 0), // 3
                    new Point(11 * (Width / 12), 0), // 4
                    new Point(11 * (Width / 12), 1 * (Width / 12)), // 5
                    new Point(Width, 1 * (Width / 12)), // 6
                    new Point(Width, Height - (1 * (Width / 12))), // 7
                    new Point(11 * (Width / 12), Height - (1 * (Width / 12))), // 8
                    new Point(11 * (Width / 12), Height), // 9
                    new Point(1 * (Width / 12), Height), // 10
                    new Point(1 * (Width / 12), Height - (1 * (Width / 12))), // 11
                    new Point(0, Height - (1 * (Width / 12))), // 12
                };
                //-----------------------------
                //Names:
                this.PictureBoxControl1.SetPictureName(KingdomPreviewPictureBoxNameInRes);
                //TabIndexes:
                this.PictureBoxControl1.CurrentStatus = this.CurrentStatus;
                //FontsAndTextAligns:
                this.MessageLabel2.Font =
                    new Font(ThereIsConstants.Forming.TheMainForm.PrivateFonts.Families[1],
                    11, FontStyle.Bold);
                this.MessageLabel2.TextAlign = ContentAlignment.MiddleCenter;
                //Sizes:
                this.MessageLabel2.Size = new Size(UnlimitedPointWorks[4].X -
                    UnlimitedPointWorks[1].X,
                    UnlimitedPointWorks[1].Y - UnlimitedPointWorks[2].Y);
                this.PictureBoxControl1.Size = new Size(UnlimitedPointWorks[5].X - UnlimitedPointWorks[0].X,
                    UnlimitedPointWorks[10].Y - UnlimitedPointWorks[1].Y);
                //Locations:
                this.MessageLabel2.Location =
                    new Point(((UnlimitedPointWorks[3].X - UnlimitedPointWorks[2].X) / 2) -
                    (MessageLabel2.Width / 2), UnlimitedPointWorks[2].Y);
                this.PictureBoxControl1.Location = UnlimitedPointWorks[0];
                this.MessageLabel1.Location = 
                    new Point((this.Width / 2) - (this.MessageLabel1.Width / 2),
                    UnlimitedPointWorks[10].Y - (2 * this.MessageLabel1.Height));
                //Colors:
                this.SetColorTransparent();
                this.MessageLabel2.SetColorTransparent();
                this.MessageLabel2.ForeColor = Color.GhostWhite;
                //ComboBoxes:
                //Enableds:
                //Texts:
                this.MessageLabel2.SetLabelText("#" + CurrentStatus.ToString() + " ");
                //AddRanges:
                //ToolTipSettings:
                //Images:
                this.PictureBoxControl1.SetPicture();
                this.PictureBoxControl1.SizeMode = PictureBoxSizeMode.StretchImage;
                //Events:
                this.SizeChanged += MapDisplayer_SizeChanged;
                this.Paint += MapDisplayer_Paint;
                this.MessageLabel1.AddEnterEventToAllChild(MapSigner_MouseEnter);
                this.MessageLabel1.AddLeaveEventToAllChild(MapSigner_MouseLeave);
                //-----------------------------
                this.Controls.AddRange(new Control[]
                {
                    this.MessageLabel2,
                    this.PictureBoxControl1,
                });
                this.PictureBoxControl1.Controls.Add(this.MessageLabel1);
            }


            private void MapDisplayer_SizeChanged(object sender, EventArgs e)
            {
                //-------------------------------------------
                this.ReLoadUPW();
            }

            private void MapDisplayer_Paint(object sender, PaintEventArgs e)
            {
                e.Graphics.FillPolygon(new SolidBrush(Color.FromArgb(225, Color.Black)),
                    new Point[]
                    {
                        UnlimitedPointWorks[0], // 1
                        UnlimitedPointWorks[1], // 2
                        UnlimitedPointWorks[2], // 3
                        UnlimitedPointWorks[3], // 4
                        UnlimitedPointWorks[4], // 5
                        UnlimitedPointWorks[5], // 6
                        UnlimitedPointWorks[6], // 7
                        UnlimitedPointWorks[7], // 8
                        UnlimitedPointWorks[8], // 9
                        UnlimitedPointWorks[9], // 10
                        UnlimitedPointWorks[10], // 11
                        UnlimitedPointWorks[11], // 12
                    });
                e.Graphics.FillPie(new SolidBrush(Color.FromArgb(210, Color.Black)),
                    new Rectangle(new Point(0, 0), // 1
                    new Size(2 * (Width / 12), 2 * (Width / 12))),
                    180, 90);
                e.Graphics.FillPie(new SolidBrush(Color.FromArgb(210, Color.Black)),
                    new Rectangle(new Point(UnlimitedPointWorks[3].X - (1 * (Width / 12)), 0),
                    new Size(2 * (Width / 12), 2 * (Width / 12))),
                    270, 90);
                e.Graphics.FillPie(new SolidBrush(Color.FromArgb(210, Color.Black)),
                    new Rectangle(new Point(UnlimitedPointWorks[7].X - (1 * (Width / 12)),
                    UnlimitedPointWorks[7].Y - (1 * (Width / 12))),
                    new Size(2 * (Width / 12), 2 * (Width / 12))),
                    0, 90);
                e.Graphics.FillPie(new SolidBrush(Color.FromArgb(210, Color.Black)),
                    new Rectangle(new Point(UnlimitedPointWorks[10].X - (1 * (Width / 12)),
                    UnlimitedPointWorks[10].Y - (1 * (Width / 12))),
                    new Size(2 * (Width / 12), 2 * (Width / 12))),
                    90, 90);
            }
            #endregion
            //----------------------------------------------
            public void ReLoadUPW()
            {
                this.Size = new Size(8 * (this.Width / 8),
                    8 * (this.Height / 8));
                this.UnlimitedPointWorks = new Point[]
                {
                    new Point(0, 0), // 1
                    new Point(Width, 0), // 2
                    new Point(Width, 5 * (Height / 8)), // 3
                    new Point(1 * (Width / 2), Height), // 4
                    new Point(0, 5 * (Height / 8)), // 5
                };
            }
        }
    }
}
