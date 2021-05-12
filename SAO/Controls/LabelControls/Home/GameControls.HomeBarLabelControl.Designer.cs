// Copyright (C) ALiwoto 2019 - 2020
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of the source code.

using System;
using System.Drawing;
using System.Windows.Forms;
using SAO.Controls.Assets.Icons;

namespace SAO.Controls
{
    partial class GameControls
    {
        partial class HomeBarLabelControl
        {
            //---------------------------------------------
            #region Initialize Region
            private void InitializeComponent(EventHandler profileClickEventHandler)
            {
                this.SuspendLayout();
                this.Size = new Size(Father.Width, 48 * (Father.Height / 236));
                //-----------------------------------------
                //News:
                this.ProfileBarLabelControl = new ProfileBarLabelControl(this);
                this.UnlimitedPointWorks    = new Point[]
                {
                    new Point(0, Height / 2),                           // 1
                    new Point((Width / 2) - (Height / 2), Height / 2),  // 2
                    new Point(Width / 2, 0),                            // 3
                    new Point((Width / 2) + (Height / 2), Height / 2),  // 4
                    new Point(Width, Height / 2),                       // 5
                    new Point(Width, Height),                           // 6
                    new Point(0, Height),                               // 7
                    new Point(Width / 2, Height),                       // 8
                };
                this.PaintColors            = new Color[]
                {
                    Color.FromArgb(220, Color.Black),
                    Color.FromArgb(230, Color.LightGoldenrodYellow),
                };
                this.PaintBrushes           = new Brush[]
                {
                    new SolidBrush(this.PaintColors[0]),
                };
                this.PaintPens              = new Pen[]
                {
                    new Pen(this.PaintColors[1], 1.4f),
                };
                this.Icons                  = new GameIcon[]
                {
                    GameIcon.GenerateIcon(Main_Icons.s_main_map_go),        // index : 0
                    GameIcon.GenerateIcon(Game_Main_Icons.s_nav_icon_1),    // index : 1
                    GameIcon.GenerateIcon(Game_Main_Icons.s_nav_icon_5),    // index : 2
                    GameIcon.GenerateIcon(Game_Main_Icons.s_play_icon_27),  // index : 3
                    GameIcon.GenerateIcon(Game_Main_Icons.s_play_icon_19),  // index : 4
                    GameIcon.GenerateIcon(Game_Main_Icons.s_nav_icon_3),    // index : 5
                    GameIcon.GenerateIcon(Game_Main_Icons.s_nav_icon_6),    // index : 6
                };
                this.SurfaceLabels          = new IconLabelControl[]
                {
                    new IconLabelControl(this, this.Icons[0]), // main map, index : 0
                    new IconLabelControl(this, this.Icons[1]), // main map, index : 1
                    new IconLabelControl(this, this.Icons[2]), // main map, index : 2
                    new IconLabelControl(this, this.Icons[3]), // main map, index : 3
                    new IconLabelControl(this, this.Icons[4]), // main map, index : 4
                    new IconLabelControl(this, this.Icons[5]), // main map, index : 5
                    new IconLabelControl(this, this.Icons[6]), // main map, index : 6
                };
                //-----------------------------------------
                //Names:
                this.SurfaceLabels[0].SetLabelName(Map_Go_IconNameInRes);
                this.SurfaceLabels[1].SetLabelName(Heroes_IconNameInRes);
                this.SurfaceLabels[2].SetLabelName(Recruit_IconNameInRes);
                this.SurfaceLabels[3].SetLabelName(Arena_IconNameInRes);
                this.SurfaceLabels[4].SetLabelName(Dungeons_IconNameInRes);
                this.SurfaceLabels[5].SetLabelName(Bag_IconNameInRes);
                this.SurfaceLabels[6].SetLabelName(Guild_IconNameInRes);
                //TabIndexes:
                //FontAndTextAligns:
                //Sizes:
                int sideWidth = UnlimitedPointWorks[1].X - UnlimitedPointWorks[0].X; // left and right have the same width.

                this.SurfaceLabels[0].Size = 
                    new Size(UnlimitedPointWorks[3].X -
                    UnlimitedPointWorks[1].X, Height);

                this.SurfaceLabels[1].Size =
                this.SurfaceLabels[2].Size =
                this.SurfaceLabels[3].Size =
                this.SurfaceLabels[4].Size =
                this.SurfaceLabels[5].Size =
                this.SurfaceLabels[6].Size =
                    new Size(sideWidth / 4,
                    Height - UnlimitedPointWorks[1].Y);

                this.SurfaceLabels[0].SetIconSize();
                this.SurfaceLabels[1].SetIconSize();
                this.SurfaceLabels[2].SetIconSize();
                this.SurfaceLabels[3].SetIconSize();
                this.SurfaceLabels[4].SetIconSize();
                this.SurfaceLabels[5].SetIconSize();
                this.SurfaceLabels[6].SetIconSize();

                this.SurfaceLabels[0].SetIconSize(1.2f * this.SurfaceLabels[0].IconSizeF.Width,
                    1.2f * this.SurfaceLabels[0].IconSizeF.Height);
                //Locations:
                this.SurfaceLabels[0].Location = new Point(UnlimitedPointWorks[1].X,
                    UnlimitedPointWorks[2].Y);
                this.SurfaceLabels[1].Location = new Point((sideWidth / 3) - 
                    this.SurfaceLabels[1].Width, UnlimitedPointWorks[0].Y);
                this.SurfaceLabels[2].Location = new Point((2 * (sideWidth / 3)) -
                    this.SurfaceLabels[2].Width, SurfaceLabels[1].Location.Y);
                this.SurfaceLabels[3].Location = new Point((3 * (sideWidth / 3)) -
                    this.SurfaceLabels[3].Width, SurfaceLabels[2].Location.Y);

                this.SurfaceLabels[4].Location = new Point(UnlimitedPointWorks[3].X, 
                    SurfaceLabels[3].Location.Y);
                this.SurfaceLabels[5].Location = new Point(UnlimitedPointWorks[3].X +
                    (1 * (sideWidth / 3)),
                    SurfaceLabels[4].Location.Y);
                this.SurfaceLabels[6].Location = new Point(UnlimitedPointWorks[3].X +
                    (2 * (sideWidth / 3)),
                    SurfaceLabels[5].Location.Y);
                this.ProfileBarLabelControl.Location = default; // 0, 0

                this.SurfaceLabels[0].SetIconLocation();
                this.SurfaceLabels[1].SetIconLocation();
                this.SurfaceLabels[2].SetIconLocation();
                this.SurfaceLabels[3].SetIconLocation();
                this.SurfaceLabels[4].SetIconLocation();
                this.SurfaceLabels[5].SetIconLocation();
                this.SurfaceLabels[6].SetIconLocation();
                //Colors:
                this.SetColorTransparent();
                //ComboBoxes:
                //Enableds:
                this.ProfileBarLabelControl.AvatarIconLabel.SingleClick = true;
                //Texts:
                this.SurfaceLabels[0].SetLabelText();
                this.SurfaceLabels[1].SetLabelText();
                this.SurfaceLabels[2].SetLabelText();
                this.SurfaceLabels[3].SetLabelText();
                this.SurfaceLabels[4].SetLabelText();
                this.SurfaceLabels[5].SetLabelText();
                this.SurfaceLabels[6].SetLabelText();
                //AddRanges:
                //ToolTipSettings:
                //ImageSettings:
                //-----------------------------------------
                //Events:
                this.Paint -= HomeBarLabelControl_Paint;
                this.ProfileBarLabelControl.AvatarIconLabel.Click -= profileClickEventHandler;
                this.Paint += HomeBarLabelControl_Paint;
                this.ProfileBarLabelControl.AvatarIconLabel.Click += profileClickEventHandler;
                //-----------------------------------------
                this.Controls.AddRange(this.SurfaceLabels);
                this.Father.Controls.Add(this.ProfileBarLabelControl);
                //-----------------------------------------
                this.ResumeLayout();
            }
            private void HomeBarLabelControl_Paint(object sender, PaintEventArgs e)
            {
                e.Graphics.FillPolygon(this.PaintBrushes[0], new PointF[] 
                { 
                    UnlimitedPointWorks[0], // 1
                    UnlimitedPointWorks[1], // 2
                    UnlimitedPointWorks[2], // 3
                    UnlimitedPointWorks[3], // 4
                    UnlimitedPointWorks[4], // 5
                    UnlimitedPointWorks[5], // 6
                    UnlimitedPointWorks[6], // 7
                });
                e.Graphics.DrawLines(this.PaintPens[0], new PointF[]
                {
                    UnlimitedPointWorks[0], // 1
                    UnlimitedPointWorks[1], // 2
                    UnlimitedPointWorks[2], // 3
                    UnlimitedPointWorks[3], // 4
                    UnlimitedPointWorks[4], // 5
                });
                e.Graphics.DrawLines(this.PaintPens[0], new PointF[]
                {
                    UnlimitedPointWorks[1], // 2
                    UnlimitedPointWorks[7], // 8
                    UnlimitedPointWorks[3], // 4
                });
            }
            #endregion
            //---------------------------------------------
            #region Overrided Methods Region
            public override void ReloadUPW()
            {
                this.UnlimitedPointWorks = new Point[]
                {
                    new Point(0, Height / 2),                           // 1
                    new Point((Width / 2) - (Height / 2), Height / 2),  // 2
                    new Point(Width / 2, 0),                            // 3
                    new Point((Width / 2) + (Height / 2), Height / 2),  // 4
                    new Point(Width, Height / 2),                       // 5
                    new Point(Width, Height),                           // 6
                    new Point(0, Height),                               // 7
                    new Point(Width / 2, Height),                       // 8
                };
            }
            protected override void Dispose(bool disposing)
            {
                this.Father.Controls.Remove(ProfileBarLabelControl);
                this.ProfileBarLabelControl.Dispose();
                base.Dispose(disposing);
            }
            #endregion
            //---------------------------------------------
        }
    }
}