using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using SAO.SandBox;
using SAO.Security;
using SAO.GameObjects.Players;

namespace SAO.Controls.Elements.ChatElements
{
    partial class ChatElement
    {
        //-------------------------------------------------
        #region Designing Region
        private void InitializeComponent()
        {
            //----------------------------------
            //News:
            this.AvatarImage = 
                Message.SenderAvatar.GetImage(AvatarFormat.Format03, 
                this.Message.SenderAvatarFrame);
            this.AvatarFrameImage = Message.SenderAvatarFrame.GetImage(AvatarFormat.Format01);
            this.PaintColors = new Color[]
            {
                Color.Black,
                Color.FromArgb(201,201,201),
                Color.GhostWhite,
                this.Message.SenderSocialPosition.GetColorW(),
            };
            this.PaintBrushes = new Brush[]
            {
                new SolidBrush(this.PaintColors[0]),
                new SolidBrush(this.PaintColors[1]),
                new SolidBrush(this.PaintColors[2]),
                new SolidBrush(this.PaintColors[3]),
            };
            //----------------------------------
            //Names:
            //TabIndexes
            //FontAndTextAligns:
            try
            {
                this.MessageFont =
                new Font(new FontFamily("Segoe UI"),
                    14f, FontStyle.Regular);
                this.NameFont = this.PositionFont =
                    new Font(new FontFamily("Segoe UI"),
                        9.5f, FontStyle.Italic);
            }
            catch
            {
                this.MessageFont =
                new Font(FontFamily.GenericSansSerif,
                    14f, FontStyle.Regular);
                this.NameFont = this.PositionFont =
                    new Font(FontFamily.GenericSansSerif,
                        9.5f, FontStyle.Italic);
            }
            this.StringFormat = new StringFormat()
            {
                LineAlignment = StringAlignment.Near,
                Alignment = StringAlignment.Near,
                FormatFlags = StringFormatFlags.LineLimit,
                HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.Show,
                Trimming = StringTrimming.EllipsisCharacter,
            };
            //Sizes:
            var g = this.ChatBackgroundLabel.CreateGraphics();
            this.MaxWidth = this.ChatBackgroundLabel.Width -
                AVATAR_SIZE -
                (4 * NoInternetConnectionSandBox.from_the_edge);
            this.MinWidth = this.ChatBackgroundLabel.Width / 5;
            this.AvatarSizeF = new SizeF(AVATAR_SIZE, AVATAR_SIZE);
            this.PositionSizeF =
                new SizeF(this.FindWidth(this.Message.SenderSocialPosition.GetString(),
                this.PositionFont, g), ELEMENT_AVATAR_VERTICAL);
            this.NameSizeF =
                new SizeF(this.FindWidth(this.GetSenderName(), this.NameFont, g), 
                ELEMENT_AVATAR_VERTICAL);
            this.ElementSizeF =
                new SizeF(this.FindWidth(), this.FindHeight());
            if (this.AvatarFrameImage != null && !this.Message.SenderAvatarFrame.IsDefault)
            {
                this.AvatarFrameSizeF =
                    new SizeF(this.AvatarSizeF.Width +
                        this.Message.SenderAvatarFrame.GetWCost(),
                        this.AvatarSizeF.Height +
                        this.Message.SenderAvatarFrame.GetHCost());
            }
            //Locations:
            this.SetParams();
            //Colors:
            //this.SurfaceControl.BackColor = Color.Red;
            //ComboBoxes:
            //Enableds:
            //Texts:
            //AddRanges:
            //ToolTipSettings:
            //----------------------------------
            //Events:
            //----------------------------------

        }
        public void ReloadUPW()
        {
            if (this.IsMe)
            {
                this.UnlimitedEPointFWorks = new PointF[]
                {
                    new PointF(this.ElementLocationF.X,
                        this.ElementLocationF.Y), // 1
                    new PointF(this.ElementLocationF.X + this.ElementSizeF.Width - 
                        NoInternetConnectionSandBox.from_the_edge,
                        this.ElementLocationF.Y), // 2
                    new PointF(this.ElementLocationF.X + this.ElementSizeF.Width -
                        NoInternetConnectionSandBox.from_the_edge,
                        this.ElementLocationF.Y +
                        (this.ElementSizeF.Height / 2) -
                        NoInternetConnectionSandBox.from_the_edge), // 3
                    new PointF(this.ElementLocationF.X + this.ElementSizeF.Width,
                        this.ElementLocationF.Y +
                        (this.ElementSizeF.Height / 2) -
                        (NoInternetConnectionSandBox.from_the_edge / 2)), // 4
                    new PointF(this.ElementLocationF.X + this.ElementSizeF.Width -
                        NoInternetConnectionSandBox.from_the_edge,
                        this.ElementLocationF.Y +
                        this.ElementSizeF.Height / 2), // 5
                    new PointF(this.ElementLocationF.X + this.ElementSizeF.Width -
                        NoInternetConnectionSandBox.from_the_edge,
                        this.ElementLocationF.Y + this.ElementSizeF.Height), // 6
                    new PointF(this.ElementLocationF.X,
                        this.ElementLocationF.Y + this.ElementSizeF.Height), // 7
                };
            }
            else
            {
                this.UnlimitedEPointFWorks = new PointF[]
                {
                    new PointF(this.ElementLocationF.X,
                        this.ElementLocationF.Y), // 1
                    new PointF(this.ElementLocationF.X + this.ElementSizeF.Width,
                        this.ElementLocationF.Y), // 2
                    new PointF(this.ElementLocationF.X + this.ElementSizeF.Width,
                        this.ElementLocationF.Y + this.ElementSizeF.Height), // 3
                    new PointF(this.ElementLocationF.X,
                        this.ElementLocationF.Y + this.ElementSizeF.Height), // 4
                    new PointF(this.ElementLocationF.X,
                        this.ElementLocationF.Y +
                        this.ElementSizeF.Height / 2), // 5
                    new PointF(this.ElementLocationF.X -
                        NoInternetConnectionSandBox.from_the_edge,
                        this.ElementLocationF.Y +
                        (this.ElementSizeF.Height / 2) -
                        (NoInternetConnectionSandBox.from_the_edge / 2)), // 6
                    new PointF(this.ElementLocationF.X,
                        this.ElementLocationF.Y +
                        (this.ElementSizeF.Height / 2) -
                        NoInternetConnectionSandBox.from_the_edge), // 7
                };
            }
            
        }
        private float FindWidth()
        {
            Graphics graphics = this.ChatBackgroundLabel.CreateGraphics();
            SizeF measure;
            measure =
                graphics.MeasureString(Message.MessageContext.GetValue(), this.MessageFont);
            this.Lines =
                (int)Math.Ceiling(measure.Width / MaxWidth);

            return Math.Max(Math.Max(Math.Min(measure.Width, MaxWidth), MinWidth) +
                (IsMe ? AVATAR_ELEMENT : 0), 
                this.NameSizeF.Width + this.PositionSizeF.Width);

        }
        private float FindWidth(string value, Font font, Graphics graphics)
        {
            SizeF measure;
            measure =
                graphics.MeasureString(value, font);
            return measure.Width;
        }
        private float FindWidth(StrongString value, Font font, Graphics graphics)
        {
            return FindWidth(value.GetValue(), font, graphics);
        }
        private float FindHeight()
        {
            return (this.Lines + 1) * this.MessageFont.Height;
        }
        /// <summary>
        /// Setting the location and rectangle params with the help of 
        /// <see cref="StartPointF"/>.
        /// </summary>
        private void SetParams()
        {
            //Locations:
            if (this.IsMe)
            {
                this.AvatarLocationF =
                    new PointF(this.ChatBackgroundLabel.Width - 
                    this.AvatarSizeF.Width - GameControls.ChatBackgroundLabel.From_the_edge,
                    this.StartPointF.Y);
                this.AvatarFrameLocationF =
                    new PointF(this.AvatarLocationF.X +
                        this.Message.SenderAvatarFrame.GetXCost(),
                        this.AvatarLocationF.Y +
                        this.Message.SenderAvatarFrame.GetYCost());
                this.ElementLocationF =
                    new PointF(this.AvatarLocationF.X -
                    this.ElementSizeF.Width - ELEMENT_AVATAR,
                    this.AvatarLocationF.Y + ELEMENT_AVATAR_VERTICAL);
                this.NameLocationF =
                    new PointF(ElementLocationF.X,
                    this.ElementLocationF.Y - 
                    this.NameSizeF.Height);
                this.PosiotionLocationF =
                    new PointF(this.NameLocationF.X +
                    this.NameSizeF.Width, this.NameLocationF.Y);
            }
            else
            {
                this.AvatarLocationF = this.StartPointF;
                this.AvatarFrameLocationF =
                    new PointF(this.AvatarLocationF.X +
                        this.Message.SenderAvatarFrame.GetXCost(),
                        this.AvatarLocationF.Y +
                        this.Message.SenderAvatarFrame.GetYCost());
                this.ElementLocationF =
                    new PointF(this.AvatarLocationF.X +
                        this.AvatarSizeF.Width + AVATAR_ELEMENT, this.AvatarLocationF.Y +
                        ELEMENT_AVATAR_VERTICAL);
                this.PosiotionLocationF =
                    new PointF(this.ElementLocationF.X +
                    this.ElementSizeF.Width -
                    this.PositionSizeF.Width,
                    this.ElementLocationF.Y -
                    this.PositionSizeF.Height);
                this.NameLocationF =
                    new PointF(this.PosiotionLocationF.X - 
                    this.NameSizeF.Width, this.PosiotionLocationF.Y);
            }
            this.ReloadUPW();
            //Rectangles:
            this.AvatarRectangleF =
                new RectangleF(this.AvatarLocationF, this.AvatarSizeF);
            

            this.ElementRectangleF =
                new RectangleF(this.ElementLocationF, this.ElementSizeF);
            this.NameRectangleF =
                new RectangleF(this.NameLocationF, this.NameSizeF);
            this.PositionRectangleF =
                new RectangleF(this.PosiotionLocationF, this.PositionSizeF);
            this.SrcAvatarRectangleF =
                new RectangleF(SrcstartPoint, SrcstartPoint,
                this.AvatarImage.Width, this.AvatarImage.Height);
            // check if the avatar frame image is null or not
            // as well as check the frame if it's default frame or not
            if (this.AvatarFrameImage != null && !this.Message.SenderAvatarFrame.IsDefault)
            {
                // set the avatar dest frame rectangle
                this.AvatarFrameRectangleF =
                    new RectangleF(this.AvatarFrameLocationF, this.AvatarFrameSizeF);
                // set the src avatar rectangle
                this.SrcAvatarFrameRectangleF =
                    new RectangleF(
                        this.Message.SenderAvatarFrame.GetXEdge(),
                        this.Message.SenderAvatarFrame.GetYEdge(), 
                        this.AvatarFrameImage.Width +
                        this.Message.SenderAvatarFrame.GetWEdge(), 
                        this.AvatarFrameImage.Height +
                        this.Message.SenderAvatarFrame.GetHEdge());
            }
        }
        private string GetSenderName()
        {
            if (this.Message.IsMe)
            {
                return this.MyRes.GetString(YOU_STRING_NAME);
            }
            else
            {
                return this.Message.SenderName.GetValue();
            }
        }
        private string GetPositionString()
        {
            return this.Message.SenderSocialPosition.GetString().GetValue();
        }
        #endregion
        //-------------------------------------------------
        #region All GraphicalWorks Region
        private void GraphicDrawing(object sender, PaintEventArgs e)
        {
            if (this.IsDisposed || !this.IsApplied)
            {
                return;
            }
            Graphics graphics = e.Graphics;
            graphics.SmoothingMode = SmoothingMode.HighSpeed;
            graphics.DrawImage(this.AvatarImage, this.AvatarRectangleF,
                this.SrcAvatarRectangleF, GraphicsUnit.Pixel);
            if (this.AvatarFrameImage != null)
            {
                if (!this.Message.SenderAvatarFrame.IsDefault)
                {
                    graphics.DrawImage(this.AvatarFrameImage, this.AvatarFrameRectangleF,
                    this.SrcAvatarFrameRectangleF, GraphicsUnit.Pixel);
                }
            }
            graphics.FillPolygon(this.PaintBrushes[1], this.UnlimitedEPointFWorks);
            graphics.DrawString(this.Message.MessageContext.GetValue(),
                this.MessageFont, this.PaintBrushes[0],
                this.ElementRectangleF, this.StringFormat);
            graphics.DrawString(this.GetSenderName(),
                this.NameFont, this.PaintBrushes[2],
                this.NameRectangleF, this.StringFormat);
            graphics.DrawString(this.GetPositionString(),
                this.PositionFont, this.PaintBrushes[3],
                this.PositionRectangleF, this.StringFormat);
            //---------------------------------------------------------

            //graphics.InterpolationMode = InterpolationMode.High;
            //graphics.SmoothingMode = SmoothingMode.HighQuality;
            //graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            //graphics.CompositingQuality = CompositingQuality.HighQuality;
            // assuming g is the Graphics object on which you want to draw the text
            //GraphicsPath p = new GraphicsPath();
            //p.AddString(
            //    Message.MessageContext.GetValue(),             // text to draw
            //    this.MessageFont.FontFamily,  // or any other font family
            //    (int)this.MessageFont.Style,      // font style (bold, italic, etc.)
            //    graphics.DpiY * this.MessageFont.Size / 72,       // em size
            //    this.ElementRectangleF,              // location where to draw text
            //    this.StringFormat);          // set options here (e.g. center alignment)
            //graphics.DrawPath(new Pen(Color.Red, 0.4f), p);
            // + g.FillPath if you want it filled as well
            //graphics.FillPath(new SolidBrush(Color.Black), p);
        }
        #endregion
        //-------------------------------------------------
        #region Get Methods Region
        public PointF GetTopLeft()
        {
            return this.AvatarLocationF;
        }
        public PointF GetTopRight()
        {
            return 
                new PointF(this.ElementLocationF.X + this.ElementSizeF.Width,
                this.AvatarLocationF.Y);
        }
        public PointF GetBottomRight()
        {
            return
                new PointF(this.ElementLocationF.X + this.ElementSizeF.Width,
                this.AvatarLocationF.Y + this.ElementSizeF.Height);
        }
        public PointF GetBottomLeft()
        {
            return 
                new PointF(this.AvatarLocationF.X,
                this.ElementLocationF.Y + this.ElementSizeF.Height);
        }
        #endregion
        //-------------------------------------------------
        #region Set Methods Region
        public void SetStartPoint(PointF startPoint)
        {
            this.StartPointF = startPoint;
            this.SetParams();
        }
        public void SetStartPoint(float x, float y)
        {
            this.SetStartPoint(new PointF(x, y));
        }
        public float GetTotalHeight()
        {
            return
                this.GetBottomLeft().Y -
                this.GetTopLeft().Y;
        }
        public float GetTotalWidth()
        {
            return
                this.GetTopRight().X -
                this.GetTopLeft().X;
        }
        #endregion
        //-------------------------------------------------
        #region Applying Region
        public override void Apply()
        {
            // checking if the Element already applied or 
            // not disposed.
            if (this.IsApplied || this.IsDisposed)
            {
                // NOTICE: Do NOT apply the element twice!
                return;
            }
            // set the applied parameter to true, to don't 
            // apply this element anymore.
            this.IsApplied = true;
            // just-in-case, remove then add the graphic works of this element.
            this.ChatBackgroundLabel.Paint -= GraphicDrawing;
            this.ChatBackgroundLabel.Paint += GraphicDrawing;
        }
        public override void Dispose()
        {
            // check if this element has already applied or not,
            // this element should has been applied beforehand.
            // also check if this element has already disposed or not.
            if (!this.IsApplied || this.IsDisposed)
            {
                // it means this element has already disposed,
                // or not applied.
                return;
            }
            this.IsDisposed = true;
            this.IsApplied = false;
            using (var image = this.AvatarImage)
            {
                this.AvatarImage = null;
                if (image != null)
                {
                    image.Dispose();
                }
            }
            this.StringFormat.Dispose();
            this.MessageFont.Dispose();
            this.ChatBackgroundLabel.Paint -= GraphicDrawing;
        }
        #endregion
        //-------------------------------------------------
    }
}
