using System;
using System.Drawing;
using SAO.Controls.Assets.Icons;
using SAO.GameObjects.MapObjects;
using SAO.GameObjects.Characters;

namespace SAO.Controls.Elements.MapElements
{
    public partial class MapElement : GraphicElements
    {
        //-------------------------------------------------
        #region Properties Region
        public Image ElementImage { get; protected set; }
        public Image OriginalImage { get; protected set; }
        public Image ClickedImage { get; protected set; }
        //-------------------------------------------------
        public Map Map { get; protected set; }
        //--------------------------------------------------
        public Size ElementSize { get; protected set; }
        public SizeF ElementSizeF { get; protected set; }
        public Point ElementLocation { get; protected set; }
        public PointF ElementLocationF { get; protected set; }
        public Rectangle ElementRectangle { get; protected set; }
        public RectangleF ElementRectangleF { get; protected set; }
        public Rectangle SrcElementRectangle { get; protected set; }
        public RectangleF SrcElementRectangleF { get; protected set; }
        //--------------------------------------------------
        public override ElementMovements Movements { get; }
        public ElementsInMap ElementInMapType { get; protected set; }
        public GameIcon TheIcon { get; }
        //-------------------------------------------------
        public bool DontUseClickedImage { get; set; }
        public bool IsMoving { get; protected set; }
        public bool IsMovingAllowed { get; protected set; }
        public bool FFramable { get; }
        public bool HasIcon { get; protected set; }
        /// <summary>
        /// if this value is true, then you should not use 
        /// Surface Control.
        /// </summary>
        public bool IsBackgroundElement { get; }
        public bool HasFakeSurface { get; protected set; }
        public bool HasFakeSurfaceApplied { get; protected set; }
        //-------------------------------------------------
        public string Name { get; protected set; }
        /// <summary>
        /// get the Text protperty of the SurfaceControl of this Element.
        /// if the Element has no Surfacecontrol, you will get null,
        /// so be carefull.
        /// </summary>
        public string Text
        {
            get
            {
                if (!FFramable)
                {
                    if (!IsBackgroundElement)
                    {
                        if (SurfaceControl != null && SurfaceControl.Text != null)
                        {
                            return SurfaceControl.Text;
                        }
                    }
                }
                return null;
            }
        }
        /// <summary>
        /// get the Text protperty of the SurfaceControl of this Element.
        /// if the Element has no Surfacecontrol, you will get an empty string.
        /// this Property is a fixed version of <see cref="Text"/>,
        /// and it will use <see cref="Text"/> in order to obrain the Text
        /// Property of the SurfaceControl.
        /// </summary>
        public string FixedText
        {
            get
            {
                if (Text == null)
                {
                    return string.Empty;
                }
                else
                {
                    return Text;
                }
            }
        }
        //-------------------------------------------------
        public float Width
        {
            get
            {
                if (FFramable)
                {
                    return ElementSizeF.Width;
                }
                else
                {
                    return ElementSize.Width;
                }
                
            }
        }
        public float Height
        {
            get
            {
                if (FFramable)
                {
                    return ElementSizeF.Height;
                }
                else
                {
                    return ElementSize.Height;
                }
                
            }
        }
        
        public uint Index { get; set; }
        public uint MyI { get; set; }
        public uint MyJ { get; set; }
        //-------------------------------------------------
        public event EventHandler MovementWorker;
        //-------------------------------------------------
        #endregion
        //-------------------------------------------------
        #region Costructors Region
        /// <summary>
        /// We will use <see cref="ElementSizeF"/> 
        /// instead of <see cref="ElementSize"/>,
        /// <see cref="ElementLocationF"/> instead of 
        /// <see cref="ElementLocation"/> and so on...
        /// </summary>
        /// <param name="myRes"></param>
        /// <param name="map"></param>
        protected MapElement(IRes myRes, Map map) : base(myRes)
        {
            Movements           = ElementMovements.NoMovements;
            Map                 = map;
            FFramable           = true;
            InitializeComponent();
        }
        protected MapElement(IRes myRes, Map map, ElementMovements movements,
            EventHandler @event, bool isBackgroundElement = false) : base(myRes)
        {
            Movements           = movements;
            MovementWorker      = @event;
            Map                 = map;
            FFramable           = 
                Movements       == ElementMovements.NoMovements;
            IsBackgroundElement = isBackgroundElement;
            InitializeComponent();
        }
        protected MapElement(IRes myRes, Map map, GameIcon icon) : base(myRes)
        {
            Movements   = ElementMovements.NoMovements;
            Map         = map;
            TheIcon     = icon;
            FFramable   = true;
            HasIcon     = true;
            InitializeComponent();
        }
        protected MapElement(IRes myRes, Map map, GameIcon icon,
            ElementMovements movements,
            EventHandler @event, bool isBackground = false) : base(myRes)
        {
            Movements           = movements;
            MovementWorker      = @event;
            Map                 = map;
            TheIcon             = icon;
            FFramable           =
                Movements       == ElementMovements.NoMovements;
            IsBackgroundElement = isBackground;
            HasIcon             = true;
            InitializeComponent();
        }
        #endregion
        //-------------------------------------------------
        #region Static Methods Region
        /// <summary>
        /// Get (Generate) the a new Map Elemenet
        /// which is a character.
        /// </summary>
        /// <param name="res">
        /// this res should be <see cref="Map.MyRes"/>.
        /// </param>
        /// <param name="character"></param>
        /// <returns></returns>
        public static MapElement GetMapElement(IRes res, Character character, Map theMap, 
            bool clickedImage = false)
        {
            MapElement element = new MapElement(res, theMap)
            {
                ElementInMapType = ElementsInMap.Character,
                DontUseClickedImage = !clickedImage,
            };
            element.SetPicture(character.GetCharacterImage());
            element.SetSrcRectangle();
            return element;
        }
        /// <summary>
        /// Get the MapElement by setting the element type,
        /// this type should not be <see cref="ElementsInMap.Character"/>
        /// </summary>
        /// <param name="res"></param>
        /// <param name="element"></param>
        /// <returns></returns>
        public static MapElement GetMapElement(IRes res, ElementsInMap elementT, Map theMap,
            bool clickedImage = false)
        {
            MapElement element = new MapElement(res, theMap)
            {
                ElementInMapType = elementT,
                DontUseClickedImage = !clickedImage,
            };
            element.SetPictureName(element.ElementInMapType.ToString());
            element.SetPicture();
            element.SetSrcRectangle();
            return element;
        }
        public static MapElement GetMapElement(IRes res, GameIcon elementIcon, Map theMap,
            bool clickedImage = false)
        {
            MapElement element = new MapElement(res, theMap, elementIcon)
            {
                DontUseClickedImage = !clickedImage,
            };
            element.SetPicture();
            if (clickedImage)
            {
                element.SetClickedPicture();
            }
            element.SetSrcRectangle();
            return element;
        }
        public static MapElement GetMapElement(IRes res, ElementsInMap elementT, Map theMap,
            bool clickedImage, ElementMovements movements,
            EventHandler @event, bool isBackground = false)
        {
            MapElement element = new MapElement(res, theMap, movements, @event, isBackground)
            {
                ElementInMapType = elementT,
                DontUseClickedImage = !clickedImage,
            };
            element.SetPictureName(element.ElementInMapType.ToString());
            element.SetPicture();
            element.SetSrcRectangle();
            return element;
        }
        public static MapElement GetMapElement(IRes res, GameIcon elementIcon, Map theMap,
            bool clickedImage, ElementMovements movements,
            EventHandler @event, bool isBackground = false)
        {
            MapElement element = new MapElement(res, theMap, elementIcon, movements, @event, isBackground)
            {
                DontUseClickedImage = !clickedImage,
            };
            element.SetPictureName(element.ElementInMapType.ToString());
            element.SetPicture();
            element.SetSrcRectangle();
            return element;
        }
        #endregion
        //-------------------------------------------------
    }
}
