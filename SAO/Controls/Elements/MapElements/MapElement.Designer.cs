using System;
using System.Windows.Forms;
using System.Drawing;
using SAO.Constants;
using SAO.GameObjects.MapObjects;

namespace SAO.Controls.Elements.MapElements
{
    partial class MapElement
    {
        //-------------------------------------------------
        #region Designing Region
        private void InitializeComponent()
        {
            //----------------------------------
            //News:
            if (!FFramable)
            {
                if (!IsBackgroundElement)
                {
                    this.SurfaceControl = new GameControls.LabelControl(this)
                    {
                        DrawNothing = true,
                    };
                }
            }


            //----------------------------------
            //Names:
            //TabIndexes
            //FontAndTextAligns:
            //Sizes:
            //Locations:
            //Colors:
            if (!FFramable)
            {
                if (!IsBackgroundElement)
                {
                    this.SurfaceControl.SetColorTransparent();
                }
            }
            
            //this.SurfaceControl.BackColor = Color.Red;
            //ComboBoxes:
            //Enableds:
            //Texts:
            //AddRanges:
            //ToolTipSettings:
            //----------------------------------
            //Events:
            if (Movements != ElementMovements.NoMovements)
            {
                if (!IsBackgroundElement)
                {
                    this.SurfaceControl.MouseDown += Shocker;
                    this.SurfaceControl.MouseUp += Discharge;
                }
                else
                {
                    this.Map.Father.MouseDown += Shocker;
                    this.Map.Father.MouseUp += Discharge;
                }

            }
            //----------------------------------
            
        }

        
        #endregion
        //-------------------------------------------------
        #region All Settings Methods Region
        public void SetPictureName(string constParam)
        {
            this.Name = constParam +
                ThereIsConstants.ResourcesName.End_Res_Name;
        }
        /// <summary>
        /// This Function will set the Label.Text Property with the algorithm
        /// from MainForm.MyRes.
        /// </summary>
        public void SetPictureText()
        {
            // if the FFrame of this Element is true,
            // then it means this Element uses floated Frame,
            // and the this.SurfaceControl is null,
            // thus you cannot use it.
            if (!FFramable)
            {
                // checking if this Element is a Background Element or not,
                // if this is a Background Element, then the this.SurfaceControl 
                // is null and you should not use it.
                if (!IsBackgroundElement)
                {
                    // it means this Element is not a Background Element,
                    // and the this.SurfaceControl is not null,
                    // so you should set the Text Property of it.
                    this.SurfaceControl.Text = this.MyRes.GetString(
                        this.MyRes.GetString(this.Name) +
                        ThereIsConstants.ResourcesName.Separate_Character +
                        ThereIsConstants.AppSettings.Language +
                        this.CurrentStatus.ToString());
                }
            }
        }
        /// <summary>
        /// Setting the Text property to customValue.
        /// </summary>
        /// <param name="customValue">
        /// the custom Text.
        /// </param>
        public void SetPictureText(string customValue)
        {
            if (!FFramable)
            {
                // checking if this Element is a Background Element or not,
                // if this is a Background Element, then the this.SurfaceControl 
                // is null and you should not use it.
                if (!IsBackgroundElement)
                {
                    // it means this Element is not a Background Element,
                    // and the this.SurfaceControl is not null,
                    // so you should set the Text Property of it.
                    this.SurfaceControl.Text = customValue;
                }
            }
        }
        /// <summary>
        /// Set the <see cref="PictureBox.Image"/> Property with
        /// <see cref="Control.Name"/> propert (It should return the Image name in the Data folder.)
        /// look: <see cref="PictureBoxControl.MyRes"/>.
        /// </summary>
        public void SetPicture()
        {
            if (HasIcon && TheIcon != null)
            {
                this.ElementImage = this.OriginalImage =
                    TheIcon.OriginalImage;
            }
            else
            {
                if (!DontUseClickedImage)
                {
                    this.OriginalImage = Image.FromFile(ThereIsConstants.Path.Datas_Path +
                        ThereIsConstants.Path.DoubleSlash +
                        MyRes.GetString(
                        MyRes.GetString(Name) + ThereIsConstants.ResourcesName.Separate_Character +
                        ThereIsConstants.AppSettings.Language +
                        this.CurrentStatus.ToString()));
                    this.ElementImage = OriginalImage;
                }
                else
                {
                    this.ElementImage = Image.FromFile(ThereIsConstants.Path.Datas_Path +
                        ThereIsConstants.Path.DoubleSlash +
                        MyRes.GetString(
                        MyRes.GetString(Name) + ThereIsConstants.ResourcesName.Separate_Character +
                        ThereIsConstants.AppSettings.Language +
                        this.CurrentStatus.ToString()));
                }
            }
        }
        /// <summary>
        /// Setting the Image for graphical works,
        /// using <see cref="GraphicElements.MyRes"/> and 
        /// name of this element,
        /// wit rotateAngle value to rotate the image.
        /// </summary>
        /// <param name="rotateAngle"></param>
        public void SetPicture(float rotateAngle)
        {
            if (!DontUseClickedImage)
            {
                this.ElementImage = ThereIsConstants.Actions.RotateImage(
                    new Bitmap(Image.FromFile(ThereIsConstants.Path.Datas_Path +
                    ThereIsConstants.Path.DoubleSlash +
                    MyRes.GetString(
                        MyRes.GetString(Name) + ThereIsConstants.ResourcesName.Separate_Character +
                    ThereIsConstants.AppSettings.Language +
                    this.CurrentStatus.ToString()))), rotateAngle);
                this.ElementImage = OriginalImage;
            }
            else
            {
                this.ElementImage = ThereIsConstants.Actions.RotateImage(
                    new Bitmap(Image.FromFile(ThereIsConstants.Path.Datas_Path +
                    ThereIsConstants.Path.DoubleSlash +
                    MyRes.GetString(
                    MyRes.GetString(Name) + ThereIsConstants.ResourcesName.Separate_Character +
                    ThereIsConstants.AppSettings.Language +
                    this.CurrentStatus.ToString()))), rotateAngle);

            }
        }
        /// <summary>
        /// Setting the Graphical Image.
        /// </summary>
        /// <param name="image"></param>
        public void SetPicture(Image image)
        {
            this.ElementImage = image;
        }
        /// <summary>
        /// Setting the Graphical Image, using rotate.
        /// </summary>
        /// <param name="image"></param>
        /// <param name="rotateAngle"></param>
        public void SetPicture(Image image, float rotateAngle)
        {
            this.ElementImage = 
                ThereIsConstants.Actions.RotateImage(new Bitmap(image), rotateAngle);
        }
        /// <summary>
        /// Before using this function, please set the <see cref="CurrentStatus"/>
        /// to the status which the <see cref="CurrentStatus"/>++ is the name of the
        /// Clicked Image in the data folde.
        /// </summary>
        public void SetClickedPicture()
        {
            if (HasIcon && TheIcon != null && TheIcon.ClickedImage != null)
            {
                this.ClickedImage = TheIcon.ClickedImage;
            }
            else
            {
                if (!DontUseClickedImage)
                {
                    this.ClickedImage = Image.FromFile(ThereIsConstants.Path.Datas_Path +
                        ThereIsConstants.Path.DoubleSlash +
                        MyRes.GetString(
                        MyRes.GetString(Name) + ThereIsConstants.ResourcesName.Separate_Character +
                        ThereIsConstants.AppSettings.Language +
                        (this.CurrentStatus + 1).ToString()));
                }
                else
                {
                    return;
                }
            }
            
        }
        /// <summary>
        /// Set the ElementRectangle value 
        /// with the Element Size and Location,
        /// if and only if they are not null.
        /// </summary>
        public void SetElementRectangle()
        {
            // look, this method is somehow defferent 
            // from the other ones for setting the 
            // Rectangle.
            // in the others, you will check if the called method is the 
            // right one, if it is not a right method which called, you should
            // call the right method with the corrected value (if it was neccessary (I mean Rounding)).
            // but in this method, you will do all of the works here. okey? no needs to call another
            // method.
            //-----------------------------------
            if (FFramable)
            {
                // it means this Element is using float Frame,
                // so the this.SurfaceControl is null and cannot be used,
                // thus you should not use it here.
                this.ElementRectangleF = new RectangleF(this.ElementLocationF,
                    this.ElementSizeF);
                // checking if the properties are the same or not,
                // if they are not, then correct it.
                if (this.ElementRectangleF.Size != this.ElementSizeF)
                {
                    // checking if the SizeF properties of the Element are the same or not,
                    // if they are not, then correct it.
                    this.ElementSizeF = this.ElementRectangleF.Size;
                }
                if (this.ElementRectangleF.Location != this.ElementLocationF)
                {
                    // checking if the LocationF properties of the Element are the same or not,
                    // if they are not, then correct it.
                    this.ElementLocationF = this.ElementRectangleF.Location;
                }
            }
            else
            {
                // it means the FFrame is false and this Element is not
                // using floated Frame, so in the case that the 
                // Element is not a background, you should set the 
                // values for the this.SurfaceControl.
                this.ElementRectangle = new Rectangle(this.ElementLocation,
                    this.ElementSize);
                if (this.ElementRectangle.Size != this.ElementSize)
                {
                    // checking if the Size properties of the Element are the same or not,
                    // if they are not, then correct it.
                    this.ElementSize = this.ElementRectangle.Size;
                }
                if (this.ElementRectangle.Location != this.ElementLocation)
                {
                    // checking if the Location properties of the Element are the same or not,
                    // if they are not, then correct it.
                    this.ElementLocation = this.ElementRectangle.Location;
                }
                if (!IsBackgroundElement)
                {
                    // it means this Element is not a Baclground Element,
                    // so the this.SurfaceControl is not null,
                    // thus you should set the values for this.SurfaceControl too.
                    this.SurfaceControl.Size =
                        this.ElementRectangle.Size;
                    this.SurfaceControl.Location =
                        this.ElementRectangle.Location;
                }
            }
        }
        /// <summary>
        /// Set the <see cref="ElementRectangle"/>.
        /// </summary>
        /// <param name="rectangle">The Rectange.</param>
        public void SetElementRectangle(Rectangle rectangle)
        {
            if (!FFramable)
            {
                // this means you are in the right method, so do your work without
                // any regrets or worriment.
                this.ElementRectangle = rectangle;
                this.ElementLocation = rectangle.Location;
                this.ElementSize = rectangle.Size;
                if (!IsBackgroundElement)
                {
                    // it means this Element is not a background Element,
                    // and the this.SurfaceControl is not null,
                    // so you should set the Location and Size values for this.SurfaceControl.
                    this.SurfaceControl.Location = rectangle.Location;
                    this.SurfaceControl.Size = rectangle.Size;
                }
                else
                {
                    // you are not in the right method,
                    // cuz the FFrame value is true, thus the Surface Control
                    // is null and you should not set the Location and Size for it.
                    // please convert the rectangle value to the RectangleF 
                    // and call the another method.
                    this.SetElementRectangle((RectangleF)rectangle);
                    return;
                }
            }
        }
        public void SetElementRectangle(RectangleF rectangle)
        {
            // this method is a dangerous one.
            // cuz if your FFrame is not true, you should call another
            // method with the Rounded Rectangle, so please be carefull to not
            // call it out of your sense.
            if (FFramable)
            {
                // this means you are in the right method, so do your work without
                // any regrets or worriment.
                this.ElementRectangleF = rectangle;
                this.ElementLocationF = rectangle.Location;
                this.ElementSizeF = rectangle.Size;

            }
            else
            {
                // round the rectangleF value to the Rectangle and call
                // the right method.
                this.SetElementRectangle(Rectangle.Round(rectangle));
                return;
            }

        }
        /// <summary>
        /// Set the <see cref="SrcElementRectangle"/> to 
        /// it's full mode, using <see cref="ElementImage"/>'s
        /// Size.
        /// </summary>
        public void SetSrcRectangle()
        {
            if (FFramable)
            {
                this.SrcElementRectangleF =
                new RectangleF(0, 0,
                    this.ElementImage.Width, this.ElementImage.Height);
            }
            else
            {
                this.SrcElementRectangle =
                new Rectangle(0, 0,
                    this.ElementImage.Width, this.ElementImage.Height);
            }
            
        }
        /// <summary>
        /// Setting the SrcRectangle value with 
        /// specific rectangle value.
        /// </summary>
        /// <param name="rectangle">The specific rectangle</param>
        public void SetSrcRectangle(Rectangle rectangle)
        {
            this.SrcElementRectangle = rectangle;
        }
        public void SetSrcRectangle(RectangleF rectangle)
        {
            this.SrcElementRectangleF = rectangle;
        }
        /// <summary>
        /// Setting the SrcRectangle value with 
        /// specific rectangle value and then
        /// rotate the Graphical image with the 
        /// specific rotate value.
        /// </summary>
        /// <param name="rectangle">The specific rectangle value</param>
        /// <param name="rotate">The specific rotate value</param>
        public void SetSrcRectangle(Rectangle rectangle, float rotate)
        {
            this.SrcElementRectangle = rectangle;
            this.ElementImage =
                ThereIsConstants.Actions.RotateImage(new Bitmap(this.ElementImage),
                rotate);
        }
        public void SetSrcRectangle(RectangleF rectangle, float rotate)
        {
            this.SrcElementRectangleF = rectangle;
            this.ElementImage =
                ThereIsConstants.Actions.RotateImage(new Bitmap(this.ElementImage),
                rotate);
        }
        public void SetElementSize(Size size)
        {

            if (!FFramable)
            {
                // you are in the right method.


                if (!IsBackgroundElement)
                {
                    // this element is not Background element,
                    // so the this.SurfaceControl is not null.
                    this.ElementSize = size;
                    this.SurfaceControl.Size = size;

                }
                else
                {
                    // this element is a Background element,
                    // so the this.SurfaceControl is null.
                    this.ElementSize = size;
                    this.SurfaceControl.Size = size;
                }
                this.SetElementRectangle();

            }
            else
            {
                // you are not in the right method, please convert size
                // to the SizeF.
                this.SetElementSize((SizeF)size);
                return;
            }
        }
        public void SetElementSize(SizeF size)
        {
            this.ElementSizeF = size;
            this.SetElementRectangle();
        }
        public void SetElementSize()
        {
            if (ElementImage != null)
            {
                if (FFramable)
                {
                    this.ElementSizeF = ElementImage.Size;
                    this.SetElementRectangle();
                }
                else
                {
                    if (!IsBackgroundElement)
                    {
                        this.SurfaceControl.Size =
                        this.ElementSize = ElementImage.Size;

                    }
                    else
                    {
                        // cuz this.SurfaceControl is null.
                        this.ElementSize = ElementImage.Size;
                    }
                    this.SetElementRectangle();
                }
                
            }
            
        }
        public void SetElementLocation(Point point)
        {
            // check if this method is the right method or not.
            if (!FFramable)
            {
                if (!IsBackgroundElement)
                {
                    // cuz here, the this.SurfaceControl is not null.
                    this.SurfaceControl.Location = this.ElementLocation = point;
                }
                else
                {
                    // but here, the this.SurfaceControl is null.
                    this.ElementLocation = point;
                }
                this.SetElementRectangle();
            }
            else
            {
                this.SetElementLocation((PointF)point);
                return;
            }
            
        }
        public void SetElementLocation(PointF point)
        {
            // check if this method is the right one which you called,
            // if this is not the right one, it will call another method
            // with the corrected value (rounded).
            // be'cuz the value will be rounded, this method is dangerous 
            // method, so be carefull when you wanna use it.
            if (FFramable)
            {
                // it means this is the right method, do your best.
                this.ElementLocationF = point;
                this.SetElementRectangle();
            }
            else
            {
                // it means the FFrame property of this Element
                // is not true, so you should convert the location value to
                // LocationF(by rounding it) and call the another method,
                // which will use the this.SurfaceControl (if this Element is not a Background Element.).
                this.SetElementLocation((PointF)point);
                return;
            }
        }
        public void SetElementLocation(int x, int y)
        {
            // check if this method is the right method which called or not.
            if (!FFramable)
            {
                // check if this Element is a Background Element or not,
                // if this is a Background Element, you should not use the this.SurfaceControl.
                if (!IsBackgroundElement)
                {
                    // it means this Element is not a Background Element,
                    // so the this.SurfaceControl is not null,
                    // thus you should set the Location Property of the this.SurfaceControl too.
                    this.SurfaceControl.Location = this.ElementLocation = new Point(x, y);
                }
                else
                {
                    // it means this Element is a Background Element,
                    // so the this.SurfaceControl is null,
                    // thus you should not use it.
                    this.ElementLocation = new Point(x, y);
                }
                // call this method to update the Rectangle.
                this.SetElementRectangle();
            }
            else
            {
                // call the right method with arg of PointF.
                this.SetElementLocation(new PointF(x, y));
                return;
            }
            
        }
        public void SetElementLocation(float x, float y)
        {
            // check if this method is the right method to call,
            // the args are float, so this Element should use 
            // floated Frame in drawing itself, otherwise, you should
            // call the right method by conveting the float args (x and y)
            // to the integer.
            if (FFramable)
            {
                // it means this Element uses float Frame,
                // since this Element is using float Frame,
                // so the this.SurfaceControl is null,
                // thus you should not use the this.SurfaceControl.
                this.ElementLocationF = new PointF(x, y);
                this.SetElementRectangle();
            }
            else
            {
                // it means this Element is not a float Frame user,
                // so you should call the right method by converting the
                // float args (x and y) to integer.
                this.SetElementLocation(new Point((int)x, (int)y));
                return;
            }
        }
        #endregion
        //-------------------------------------------------
        #region All GraphicalWorks Region
        private void GraphicDrawing(object sender, PaintEventArgs e)
        {
            if (FFramable)
            {
                e.Graphics.DrawImage(this.ElementImage, this.ElementRectangleF,
                    this.SrcElementRectangleF, GraphicsUnit.Pixel);
            }
            else
            {
                e.Graphics.DrawImage(this.ElementImage, this.ElementRectangle,
                    this.SrcElementRectangle, GraphicsUnit.Pixel);
            }
        }

        #endregion
        //-------------------------------------------------
        #region Applying Region
        /// <summary>
        /// Apply current objects and graphics to 
        /// the <see cref="Map.Father"/>,
        /// with the refrence of <see cref="MapElement.Map"/>.
        /// </summary>
        public override void Apply()
        {
            try
            {
                // checking if the Element already applied or not.
                if (this.IsApplied)
                {
                    // NOTICE: Do NOT apply the element twice!
                    return;
                }
                // set the this.IsApplied property to true,
                // so when this method is called for second time,
                // won't be applied anymore.
                this.IsApplied = true;
                // check if this Element is using floated Frame or not.
                if (FFramable)
                {
                    // it means this Element is using floated Frame
                    // for drawing, so the this.SurfaceControl is null,
                    // thus you should not add it to the Map.Father.
                    // also we will round the elementRectangleF property
                    // and send it as arg in Invalidate.
                    this.Map.Father.Paint -= this.GraphicDrawing;
                    this.Map.Father.Paint += this.GraphicDrawing;
                    this.Map.Father.Invalidate(Rectangle.Round(this.ElementRectangleF));
                    return;
                }
                else
                {
                    // check if this Element is a Background element or not.
                    if (IsBackgroundElement)
                    {
                        // it means this Element is a Background element,
                        // so the this.SurfaceControl is null,
                        // thus you should not add it to the Map.Father.
                        this.Map.Father.Paint -= this.GraphicDrawing;
                        this.Map.Father.Paint += this.GraphicDrawing;
                        this.Map.Father.Invalidate(this.ElementRectangle);
                        return;
                    }
                    else
                    {
                        // it means this Element is not a Background Element, 
                        // so you should add the this.SurfaceControl to the
                        // Map.Father.
                        this.Map.Father.Paint -= this.GraphicDrawing;
                        this.Map.Father.Paint += this.GraphicDrawing;
                        this.Map.Father.Controls.Add(this.SurfaceControl);
                        this.Map.Father.Invalidate(this.ElementRectangle);
                        return;
                    }
                }
            }
            catch
            {
                // Error ...
            }

        }
        public void Apply(bool applySurface)
        {
            try
            {
                // checking if the Element already applied or not.
                if (this.IsApplied)
                {
                    // NOTICE: Do NOT apply the element twice!
                    return;
                }
                // set the this.IsApplied property to true,
                // so when this method is called for second time,
                // won't be applied anymore.
                this.IsApplied = true;
                // check if this Element is using floated Frame or not.
                if (FFramable)
                {
                    // it means this Element is using floated Frame
                    // for drawing, so the this.SurfaceControl is null,
                    // thus you should not add it to the Map.Father.
                    // also we will round the elementRectangleF property
                    // and send it as arg in Invalidate.
                    this.Map.Father.Paint -= this.GraphicDrawing;
                    this.Map.Father.Paint += this.GraphicDrawing;
                    this.Map.Father.Invalidate(Rectangle.Round(this.ElementRectangleF));
                    return;
                }
                else
                {
                    // check if this Element is a Background element or not.
                    if (IsBackgroundElement)
                    {
                        // it means this Element is a Background element,
                        // so the this.SurfaceControl is null,
                        // thus you should not add it to the Map.Father.
                        this.Map.Father.Paint -= this.GraphicDrawing;
                        this.Map.Father.Paint += this.GraphicDrawing;
                        this.Map.Father.Invalidate(this.ElementRectangle);
                        return;
                    }
                    else
                    {
                        // it means this Element is not a Background Element, 
                        // so you should add the this.SurfaceControl to the
                        // Map.Father.
                        this.Map.Father.Paint -= this.GraphicDrawing;
                        this.Map.Father.Paint += this.GraphicDrawing;
                        if (applySurface)
                        {
                            this.Map.Father.Controls.Add(this.SurfaceControl);
                        }
                        this.Map.Father.Invalidate(this.ElementRectangle);
                        return;
                    }
                }
            }
            catch
            {
                // Error ...
            }
        }
        /// <summary>
        /// We will apply a fake surface for this MapElement,
        /// look, you can only use it when you are in <see cref="FFramable"/>
        /// mode, I mean this element should use floated frame for it's drawing.
        /// NOTICE: Please call <see cref="GenerateFakeSurface()"/>,
        /// before this method.
        /// for disposing fake surface, you just can call <see cref="Dispose()"/>.
        /// </summary>
        public void ApplyFakeSurface()
        {
            // check if this element uses floated frame for it's drawing or not.
            if (FFramable)
            {
                // checking if the fake surface already applied or not,
                // or even this element has a fake surface in the first place or not.
                if (HasFakeSurfaceApplied || !HasFakeSurface)
                {
                    // it means the fake surface already applied,
                    // so you don't need need to apply it again.
                    // or there is no fake suraface on this element,
                    // please first generate it.
                    return;
                }
                // set this bool property to true,
                // to not apply the fake surface anymore.
                // then add the fake surface to the father's control collection.
                this.HasFakeSurfaceApplied = true;
                this.Map.Father.Controls.Add(this.SurfaceControl);
            }
        }
        /// <summary>
        /// you should call this method for generating a fake surface control,
        /// then you should call <see cref="ApplyFakeSurface()"/>,
        /// to apply it.
        /// </summary>
        public void GenerateFakeSurface()
        {
            // check if this element uses floated frame for it's drawing or not.
            if (FFramable)
            {
                // check if there is a fake surface for this element or not.
                if (HasFakeSurface)
                {
                    // it means you already generated the fake surface for this element,
                    // so you don't need to do it again.
                    return;
                }
                // set this property to true, cuz you don't generate
                // the fake surface control anymore.
                this.HasFakeSurface = true;
                this.SurfaceControl = new GameControls.LabelControl(this)
                {
                    DrawNothing = true,
                };
                this.SurfaceControl.SetColorTransparent();
            }
        }
        /// <summary>
        /// Dispose and release all the graphics used by 
        /// this graphic Element.
        /// </summary>
        public override void Dispose()
        {
            if (!IsApplied)
            {
                return;
            }
            this.Map.Father.Paint       -= this.GraphicDrawing;
            if (this.SurfaceControl != null)
            {
                this.Map.Father.Controls.Remove(this.SurfaceControl);
                this.SurfaceControl.Dispose();
                this.SurfaceControl     = null;
            }
            this.IsApplied              = false;
            this.HasFakeSurface         = false;
            this.HasFakeSurfaceApplied  = false;
        }
        #endregion
        //-------------------------------------------------
        #region Overrided Methods Region
        public override void Shocker(object sender, MouseEventArgs e)
        {
            if(Movements != ElementMovements.NoMovements)
            {
                this.Map.MoveManager.Start();
                MapElement currentElement = null;
                for (int i = 0; i < this.Map.MapElements.Length; i++)
                {
                    currentElement = this.Map.MapElements[i];
                    currentElement.LastPoint = e.Location;
                }
                this.Map.SetActiveMapElement(this, true);

                if (!FFramable)
                {
                    if (IsBackgroundElement)
                    {
                        this.Map.Father.MouseMove += MoveMe;
                    }
                    else
                    {
                        //this.SurfaceControl.MouseMove += MoveMe;
                        this.Map.Father.MouseMove += MoveMe;
                    }
                }
                else
                {
                    // impossible to reach ...
                    // I wrote this part just to be understandable...
                    return;
                }
                this.Map.RemoveSurfaces();
                this.Map.Father.EnabledChanged  += MapFather_EnabledChanged;
                this.Map.Father.LostFocus       += MapFather_EnabledChanged;
                this.Map.Father.Leave           += MapFather_EnabledChanged;
                this.Map.Father.VisibleChanged  += MapFather_EnabledChanged;
                this.Map.Father.Resize          += MapFather_EnabledChanged;

                // do your work, which is defined in the GameClient
                this.MovementWorker?.Invoke(this, null);
            }
        }
        public override void MoveMe(object sender, MouseEventArgs e)
        {
            if (Math.Abs(e.Y - LastPoint.Y) < Map.AllowManNum &&
                Math.Abs(e.X - LastPoint.X) < Map.AllowManNum)
            {
                IsMovingAllowed = true;
                //this.Map.Father.Refresh();
                return;
            }
            else
            {
                Map.AllowManNum += 3f;
            }
            if (IsMoving || !IsMovingAllowed || !(Map.ElementsMoveAllowed))
            {
                IsMovingAllowed = true;
                return;
            }
            else
            {
                IsMoving = true;
                IsMovingAllowed = false;
            }


            switch (Movements)
            {
                case ElementMovements.VerticalHorizontalMovements:
                    {
                        // what the hell are you doing??
                        // if the FFrame of the Element is true,
                        // then the Element should not move at all! :|
                        // so in the first place you won't be able to come here ...
                        // but I write this if .. else condition just to 
                        // be understandable.
                        if (!this.FFramable)
                        {
                            if (ElementRectangle.Location.X + (e.X - this.LastPoint.X) > 1 ||
                                ElementRectangle.Location.Y + (e.Y - this.LastPoint.Y) > 1)
                            {
                                if ((e.X - this.LastPoint.X) > 0 ||
                                    (e.Y - this.LastPoint.Y) > 0)
                                {
                                    IsMoving = false;
                                    return;
                                }

                            }
                            if ((ElementRectangle.Location.X + ElementRectangle.Width) +
                                (e.X - this.LastPoint.X) < Map.Father.Width ||
                                (ElementRectangle.Location.Y + ElementRectangle.Height) +
                                (e.Y - this.LastPoint.Y) < Map.Father.Height)
                            {
                                if ((e.X - this.LastPoint.X) < 0 ||
                                    (e.Y - this.LastPoint.Y) < 0)
                                {
                                    IsMoving = false;
                                    return;
                                }
                            }
                            MapElement currentElement = null;
                            for (int i = 0; i < this.Map.MapElements.Length; i++)
                            {
                                currentElement = this.Map.MapElements[i];
                                if (!currentElement.FFramable)
                                {
                                    currentElement.SetElementLocation(new Point(
                                        currentElement.ElementRectangle.Location.X + (e.X - currentElement.LastPoint.X),
                                        currentElement.ElementRectangle.Location.Y + (e.Y - currentElement.LastPoint.Y)));
                                    currentElement.LastPoint = new Point(e.X, e.Y);

                                    if (!currentElement.IsBackgroundElement)
                                    {
                                        currentElement.SurfaceControl.Location =
                                            currentElement.ElementRectangle.Location;
                                        currentElement.SurfaceControl.Refresh();
                                    }
                                    
                                }
                                else
                                {
                                    // the currentElement is not Moveable.
                                    continue;
                                }
                                
                                /*
                                currentElement.GraphicDrawing(currentElement,
                                    new PaintEventArgs(Map.Father.CreateGraphics(),
                                    currentElement.ElementRectangle));
                                */
                                //currentElement.SurfaceControl.Refresh();
                                this.Map.Father.Invalidate(currentElement.ElementRectangle, true);
                            }
                            //this.SurfaceControl.Refresh();
                            //this.Map.Father.Invalidate();
                            this.Map.Father.Refresh();
                            this.MovementWorker?.Invoke(sender, e);
                            break;
                        }
                        else
                        {
                            // nothing, the Element is not moveable in floated frame mode.
                            break;
                        }
                        
                    }

            }
            IsMoving = false;
            if(Map.AllowManNum > 15)
            {
                Map.AllowManNum--;
            }
            
        }
        public override void MoveMe(int divergeX, int divergeY)
        {
            if (IsMoving || !IsMovingAllowed)
            {
                IsMovingAllowed = true;
                return;
            }
            else
            {
                IsMoving = true;
                IsMovingAllowed = false;
            }

            switch (Movements)
            {
                case ElementMovements.VerticalHorizontalMovements:
                    {
                        if (ElementRectangle.Location.X + divergeX >= 0)
                        {
                            if (divergeX > 0)
                            {
                                IsMoving = false;
                                this.IsMovingAllowed = true;
                                return;
                            }

                        }
                        if (ElementRectangle.Location.Y + divergeY >= 0)
                        {
                            if (divergeY > 0)
                            {
                                IsMoving = false;
                                this.IsMovingAllowed = true;
                                return;
                            }

                        }


                        if (!this.FFramable)
                        {
                            if ((ElementRectangle.Location.X + ElementRectangle.Width) +
                                divergeX < Map.Father.Width ||
                                (ElementRectangle.Location.Y + ElementRectangle.Height) +
                                divergeY < Map.Father.Height)
                            {
                                if (divergeX <= 0 || divergeY <= 0)
                                {
                                    IsMoving = false;
                                    this.IsMovingAllowed = true;
                                    return;
                                }
                            }
                            // define the currentElement :|
                            MapElement currentElement = null;
                            for (int i = 0; i < this.Map.MapElements.Length; i++)
                            {
                                currentElement = this.Map.MapElements[i];
                                // check if the currrentElement is using floated frame
                                // for drawing itself or not.
                                // if it is using floated frame, it means it is
                                // unmoveable(at the very least by this method.)
                                if (!currentElement.FFramable)
                                {
                                    currentElement.SetElementLocation(
                                        currentElement.ElementRectangle.Location.X + divergeX,
                                        currentElement.ElementRectangle.Location.Y + divergeY);
                                    // check if the currentElement is a Background element or not,
                                    // if it is not, then you should set the location of
                                    // the currentElement.SurfaceControl.
                                    if (!currentElement.IsBackgroundElement)
                                    {
                                        currentElement.SurfaceControl.Location =
                                            currentElement.ElementRectangle.Location;
                                        currentElement.SurfaceControl.Refresh();
                                    }
                                }
                                else
                                {
                                    // nothing, the currentElement is not Moveable,
                                    // cuz, it uses the floated Frame for drawing itself.
                                    // look, if you wanna move it, move it in another place...
                                    continue;
                                }
                                
                                this.Map.Father.Invalidate(currentElement.ElementRectangle, true);
                            }
                        }
                        else
                        {
                            break;
                        }

                        //this.SurfaceControl.Refresh();
                        //this.Map.Father.Invalidate();
                        this.Map.Father.Refresh();
                        this.MovementWorker?.Invoke(this, null);
                        break;
                    }

            }
            IsMoving = false;
        }
        public override void Discharge(object sender, MouseEventArgs e)
        {
            Map.AllowManNum = 20;
            if (this.Map.MoveManager != null)
            {
                this.Map.MoveManager.Stop();
            }
            this.IsMovingAllowed = true;
            if (FFramable)
            {
                // it means this Element is not a moveable element,
                // and the this.SurfaceControl is null,
                // so you don't need to do anything here..
                // in the first place it is impossible to reach here ... :|
            }
            else
            {
                // checking if this Element is a background element or not.
                if (!IsBackgroundElement)
                {
                    // it means this element is not a background element,
                    // so you need to remove the MoveMe event handler for
                    // its SurfaceControl.
                    //this.SurfaceControl.MouseMove -= MoveMe;
                    this.Map.Father.MouseMove -= MoveMe;
                }
                else
                {
                    // it means this element is a background element,
                    // so the this.SurfaceControl is null,
                    // thus you have to remove the MoveMe event handler for
                    // Map.Father ... 
                    this.Map.Father.MouseMove -= MoveMe;
                }
                this.Map.AddSurfaces();
            }
        }
        /// <summary>
        /// when the player is kerming and using some tricks like
        /// pressing alt + tab or something like that for mocking,
        /// this event will be called and will call the <see cref="Discharge(object, MouseEventArgs)"/>
        /// by force. :D
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MapFather_EnabledChanged(object sender, EventArgs e)
        {
            this.Discharge(sender, null);
            this.Map.Father.EnabledChanged  -= MapFather_EnabledChanged;
            this.Map.Father.LostFocus       -= MapFather_EnabledChanged;
            this.Map.Father.Leave           -= MapFather_EnabledChanged;
        }

        #endregion
        //-------------------------------------------------
    }
}
