// Copyright (C) ALiwoto 2019 - 2020
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of the source code.

using System.Drawing;
using System.Windows.Forms;
using SAO.Controls.Assets.Icons;
using SAO.Constants;

namespace SAO.Controls
{
    partial class GameControls
    {
        partial class IconLabelControl
        {
            //---------------------------------------------
            #region Initialize Region
            private void InitializeComponent()
            {
                
                //---------------------------------------------
                //---------------------------------------------
                //News:
                this.PaintColors = new Color[]
                {
                    Color.FromArgb(225, Color.LightGoldenrodYellow),
                };
                this.PaintBrushes = new Brush[]
                {
                    new SolidBrush(this.PaintColors[0]),
                };
                this.StringFormat = new StringFormat()
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center,
                };
                //---------------------------------------------
                //Names:
                //TabIndexes
                //FontAndTextAligns:
                this.Font = new Font(ThereIsConstants.Forming.TheMainForm.PrivateFonts.Families[1],
                    13, FontStyle.Bold);
                this.TextAlign = ContentAlignment.BottomCenter;
                //Sizes:
                this.SetIconSize();
                //Locations:
                this.SetIconLocation();
                //Colors:
                this.SetColorTransparent();
                this.SetTextColor(Color.LightGoldenrodYellow);
                //ComboBoxes:
                //Enableds:
                this.SingleClick            = true;
                this.HasMouseClickedOnce    = false;
                this.HasMouseDowned         = false;
                //Texts:
                //AddRanges:
                //ToolTipSettings:
                //GraphicWorks:
                //Effects:
                this.SetLabelSoundEffects(Noises.ClickNoise);
                //---------------------------------------------
                //Events:
                this.Paint += IconLabelControl_Paint;
                //---------------------------------------------
                //---------------------------------------------
                //Final Blows:
            }

            private void IconLabelControl_MouseUp(object sender, MouseEventArgs e)
            {
                this.GotoOriginalMode();
                this.HasMouseDowned = false;
            }

            private void IconLabelControl_MouseDown(object sender, MouseEventArgs e)
            {
                this.GotoClickedMode();
            }

            private void IconLabelControl_Paint(object sender, PaintEventArgs e)
            {
                if (!IsInClickedMode)
                {
                    e.Graphics.DrawImage(this.TheIcon.OriginalImage, this.IconRectangleF,
                    this.TheIcon.GetOriginalRectangleF(), GraphicsUnit.Pixel);
                }
                else
                {
                    e.Graphics.DrawImage(this.TheIcon.ClickedImage, this.IconRectangleF,
                    this.TheIcon.GetClickedRectangleF(), GraphicsUnit.Pixel);
                }
                e.Graphics.DrawString(this.FakeText, this.Font, this.PaintBrushes[0], 
                    this.StringRectangleF, this.StringFormat);
            }
            #endregion
            //---------------------------------------------
            #region Settings Methods Region
            /// <summary>
            /// This method will set the Icon location
            /// which we should draw it on the labelControl,
            /// by default.
            /// The default is Center.
            /// </summary>
            public void SetIconLocation()
            {
                this.IconLocationF =
                    new PointF((this.Width / 2) - (this.IconSizeF.Width / 2),
                    (this.Height / 2) - (this.IconSizeF.Height / 2));
                this.SetIconRectangle();
            }
            public void SetIconLocation(float x, float y)
            {
                this.IconLocationF = new PointF(x, y);
                this.SetIconRectangle();
            }
            public void SetIconLocation(PointF pointF)
            {
                this.IconLocationF = pointF;
                this.SetIconRectangle();
            }
            public void SetIconSize()
            {
                if (IsInClickedMode)
                {
                    this.IconSizeF = this.TheIcon.ClickedImage.Size;

                }
                else
                {
                    this.IconSizeF = this.TheIcon.OriginalImage.Size;

                }
                this.SetIconRectangle();
            }
            public void SetIconSize(float w, float h)
            {
                this.IconSizeF = new SizeF(w, h);
                this.SetIconRectangle();
            }
            public void SetIconSize(SizeF sizeF)
            {
                this.IconSizeF = sizeF;
                this.SetIconRectangle();
            }
            public void SetIconRectangle()
            {
                this.IconRectangleF = new RectangleF(this.IconLocationF, this.IconSizeF);
                // setting the StringRectangleF by default algorithm.
                this.SetStringRectangle();
            }
            public void SetIconRectangle(RectangleF rectangleF)
            {
                this.IconRectangleF = rectangleF;
                this.IconSizeF = this.IconRectangleF.Size;
                this.IconLocationF = this.IconRectangleF.Location;
                // setting the StringRectangleF by default algorithm.
                this.SetStringRectangle();
            }
            public void SetStringRectangle()
            {
                this.StringRectangleF =
                    new RectangleF(0, this.IconLocationF.Y + this.IconSizeF.Height -
                    (this.FontHeight / 2), this.Width, this.FontHeight);
            }
            public void SetStringRectangle(bool setInMiddle)
            {
                if (setInMiddle)
                {
                    this.SetStringRectangle(
                        new RectangleF(0, this.IconLocationF.Y +
                            (this.IconSizeF.Height / 2) - (this.Font.Height / 2),
                            this.IconSizeF.Width, this.IconSizeF.Height));
                }
                else
                {
                    this.SetStringRectangle();
                }
            }
            public void SetStringRectangle(RectangleF rectangleF)
            {
                this.StringRectangleF = rectangleF;
            }
            /// <summary>
            /// WARNING -- WARNING
            /// danger zone: please use this method only when you are
            /// really have to change the Icon of this IconLabel.
            /// don't use it if you know nothing about it.
            /// <!--You know nothing John Snow.-->
            /// </summary>
            public void ChangeTheIcon(GameIcon gameIcon)
            {
                this.SuspendLayout();
                this.Paint -= IconLabelControl_Paint;

                //---------------------------------------------
                //---------------------------------------------
                //News:
                using (var icon = TheIcon)
                {
                    TheIcon = gameIcon;
                    icon.Dispose();
                }
                //---------------------------------------------
                //Names:
                //TabIndexes
                //FontAndTextAligns:
                //Sizes:
                this.SetIconSize();
                //Locations:
                this.SetIconLocation();
                //Colors:
                //ComboBoxes:
                //Enableds:
                //Texts:
                //AddRanges:
                //ToolTipSettings:
                //GraphicWorks:
                //Effects:
                //---------------------------------------------
                //Events:
                this.Paint += IconLabelControl_Paint;
                //---------------------------------------------
                //---------------------------------------------
                //Final Blows:
            }
            #endregion
            //---------------------------------------------
            #region Ordinary Methods
            public void GotoClickedMode()
            {
                if (this.TheIcon.HasClicked)
                {
                    IsInClickedMode = true;
                    this.Refresh();
                }
            }
            public void GotoOriginalMode()
            {
                if (this.IsInClickedMode)
                {
                    this.IsInClickedMode = false;
                    this.Refresh();
                }
            }
            #endregion
            //---------------------------------------------
            #region Overrided Methods Region
            protected override void OnMouseDown(MouseEventArgs e)
            {
                if (this.TheIcon.HasClicked)
                {
                    IconLabelControl_MouseDown(this, e);
                }
                if (HasMouseDowned)
                {
                    return;
                }
                HasMouseDowned = true;
                base.OnMouseDown(e);
            }
            protected override void OnMouseUp(MouseEventArgs e)
            {
                if (this.TheIcon.HasClicked && HasMouseDowned)
                {
                    IconLabelControl_MouseUp(this, e);
                }
                if (!HasMouseDowned)
                {
                    return;
                }
                base.OnMouseUp(e);
                HasMouseDowned = false;
            }
            public override void RefreshPaintWorks()
            {
                base.RefreshPaintWorks();
            }
            public override void SetPaintColor(Color color, int index)
            {
                if (this.PaintColors != null)
                {
                    if (index < this.PaintColors.Length)
                    {
                        this.PaintColors[index] = color;
                        this.PaintBrushes[index] = new SolidBrush(this.PaintColors[0]);
                    }
                }
            }
            public override void SetPaintBrush(Brush brush, int index)
            {
                if (this.PaintBrushes != null)
                {
                    if (index < this.PaintBrushes.Length)
                    {
                        this.PaintBrushes[index] = brush;
                    }
                }
            }
            public override void SetPaintPen(Pen pen, int index)
            {
                if (this.PaintPens != null)
                {
                    if (index < this.PaintPens.Length)
                    {
                        this.PaintPens[index] = pen;

                    }
                }
            }
            public override void SetTextColor(Color color)
            {
                this.SetPaintColor(color, 0);
            }
            #endregion
            //---------------------------------------------
        }
    }
}
