using System.Drawing;
using System.Windows.Forms;
using SAO.GameObjects.Players;

namespace SAO.Controls
{
    partial class GameControls
    {
        partial class ThroneLabel
        {
            //---------------------------------------------
            #region Designing Region
            private void InitializeComponent()
            {
                this.Size = new Size(24 * (this.Father.Width / 110),
                    24 * (this.Father.Height / 85));
                //----------------------------------
                //News:
                this.ThroneNameLabel            = new ThroneNameLabel(this, this);
                this.ThronePositionLabel        = new ThronePositionLabel(this, this,
                    this.ThronePosition);
                this.GuiltyCrown                = new PictureBoxControl(this, true);
                this.UnlimitedPointWorks        = new Point[]
                {
                    new Point(0, Width / 24), // 1
                    new Point(Width / 24, Width / 24), // 2
                    new Point(Width / 24, 0), // 3
                    new Point(Width - (Width / 4), 0), // 4
                    new Point(Width, Width / 4), // 5
                    new Point(Width, Height), // 6
                    new Point(0, Height), // 7
                };
                this.PaintColors                = new Color[]
                {
                    Color.FromArgb(240, Color.DarkGoldenrod),
                };
                this.PaintBrushes               = new SolidBrush[]
                {
                    new SolidBrush(this.PaintColors[0]),
                };
                //----------------------------------
                //Names:
                this.GuiltyCrown.SetPictureName(this.ThronePosition.ToString() +
                    GuiltyCrownPicsEndNameInRes);
                //TabIndexes
                //FontAndTextAligns:
                
                //Sizes:
                this.GuiltyCrown.Size =
                    new Size(UnlimitedPointWorks[4].X - UnlimitedPointWorks[3].X,
                    UnlimitedPointWorks[4].Y - UnlimitedPointWorks[3].Y);
                this.PlayerAvatarSize = new Size(
                    this.Height - ThroneNameLabel.Height +
                    (4 * UnlimitedPointWorks[1].Y),
                    this.Height - ThroneNameLabel.Height +
                    (4 * UnlimitedPointWorks[1].Y));
                //Locations:
                this.GuiltyCrown.Location = UnlimitedPointWorks[3];
                this.ThroneNameLabel.Location = new Point(0,
                    this.Height - ThroneNameLabel.Height);

                
                


                this.ThronePositionLabel.Location = new Point(0,
                    ThroneNameLabel.Location.Y -
                    ThronePositionLabel.Height);




                //Rectangles:
                this.PlayerAvatarRectangle =
                    new Rectangle(
                        new Point((this.Width / 2) -
                        (PlayerAvatarSize.Width / 2),
                        UnlimitedPointWorks[2].Y),
                        PlayerAvatarSize);
                //Colors:
                this.SetColorTransparent();
                this.GuiltyCrown.SetColorTransparent();
                //ComboBoxes:
                //Enableds:
                //Texts:
                //AddRanges:
                //ToolTipSettings:
                //Pictures:
                this.GuiltyCrown.SizeMode = PictureBoxSizeMode.StretchImage;
                this.GuiltyCrown.SetPicture(45f);

                //----------------------------------
                //Events:
                this.Paint += ThroneLabel_Paint;
                //----------------------------------
                this.Controls.AddRange(new Control[]
                {
                    this.ThroneNameLabel,
                    this.GuiltyCrown,
                    this.ThronePositionLabel,
                });

            }

            private void AvatarDrawing(object sender, PaintEventArgs e)
            {
                e.Graphics.DrawImage(this.PlayerAvatarImage,
                    this.PlayerAvatarRectangle, this.SrcPlayerAvatarRectangle, GraphicsUnit.Point);
            }

            private void ThroneLabel_Paint(object sender, PaintEventArgs e)
            {
                e.Graphics.FillPolygon(this.PaintBrushes[0],
                    UnlimitedPointWorks);
                e.Graphics.FillPie(this.PaintBrushes[0],
                    new Rectangle(
                        new Point(0, 0),
                        new Size(2 * (UnlimitedPointWorks[2].X - UnlimitedPointWorks[0].X),
                            2 * (UnlimitedPointWorks[0].Y - UnlimitedPointWorks[2].Y))),
                    180, 90);
            }
            #endregion
            //---------------------------------------------
            #region Online Method's Region
            public async void ReloadMe(PlayerInfo playerInfo)
            {
                this.PlayerInfo = playerInfo;
                await this.PlayerInfo.ReloadPlayerInfo();
                this.PlayerAvatarImage =
                    this.PlayerInfo.PlayerAvatar.GetImage(AvatarFormat.Format01);
                this.SrcPlayerAvatarRectangle = new Rectangle(new Point(0, 0),
                    new Size(this.PlayerAvatarImage.Width, this.PlayerAvatarImage.Height));
                this.ThroneNameLabel.MessageLabel1.SetLabelText(this.PlayerInfo.PlayerName);
                this.Paint += this.AvatarDrawing;
                this.Invalidate();
            }
            #endregion
            //---------------------------------------------
            #region Protected and Overrides Region
            public override void ReloadUPW()
            {
                this.UnlimitedPointWorks = new Point[]
                {
                    new Point(0, Width / 24), // 1
                    new Point(Width / 24, Width / 24), // 2
                    new Point(Width / 24, 0), // 3
                    new Point(Width - (Width / 12), 0), // 4
                    new Point(Width, Width / 12), // 5
                    new Point(Width, Height), // 6
                    new Point(0, Height), // 7
                };
            }
            #endregion
            //---------------------------------------------
        }
    }

}
