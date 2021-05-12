using System.Drawing;
using static System.Windows.Forms.Control;

namespace SAO.SandBox
{
    /// <summary>
    /// Custom design for SandBox
    /// </summary>
    public class CustomDesign
    {
        //-------------------------------------------------
        #region Properties Region
        public Size SandBoxSize { get; set; }
        public Point SandBoxLocation { get; set; }
        public Image SandBoxBackGroundImage { get; set; }
        public Color SandBoxBackColor { get; set; } = Color.Empty;
        public SandBoxBase TheSandBox { get; set; }
        public ControlCollection CustomControlCollection { get; set; }
        public ButtonsOnSandBox SandBoxButtons { get; set; }
        public double SandBoxOpacity { get; set; }
        public bool ShowInTaskBar { get; set; }
        public bool SandBoxKeyPreview { get; set; }
        /// <summary>
        /// If this property was true, then you should not set the size in the
        /// <see cref="SandBoxBase.InitializeComponent()"/>
        /// </summary>
        public bool Dont_Set_Size { get; set; }
        /// <summary>
        /// If this property was true, then you should not set the Location in the
        /// <see cref="SandBoxBase.InitializeComponent()"/>
        /// </summary>
        public bool Dont_Set_Location { get; set; }
        /// <summary>
        /// It will use for: SetSyle;
        /// </summary>
        public bool SupportTransParentBackGroundColors { get; set; }
        #endregion
        //-------------------------------------------------
        #region Constructor's Region
        public CustomDesign()
        {

        }
        public CustomDesign(Size SandBoxSizeValue, Point SandBoxLocationValue,
            Image SandBoxBackGroundImageValue, Color SandBoxBackColorValue, 
            SandBoxBase TheSandBoxValue, 
            ControlCollection CustomControlCollectionValue = null,
            ButtonsOnSandBox SandBoxButtonsValue = null,
            double SandBoxOpacityValue = 1,
            bool ShowInTaskBarValue = false,
            bool SandBoxKeyPreviewValue = false,
            bool DontSetSize = false,
            bool DontSetLocation = false,
            bool supportTransParentBackGroundColorsValue = false)
        {
            SandBoxSize = SandBoxSizeValue;
            SandBoxLocation = SandBoxLocationValue;
            SandBoxBackGroundImage = SandBoxBackGroundImageValue;
            SandBoxBackColor = SandBoxBackColorValue;
            TheSandBox = TheSandBoxValue;
            CustomControlCollection = CustomControlCollectionValue;
            SandBoxButtons = SandBoxButtonsValue;
            SandBoxOpacity = SandBoxOpacityValue;
            ShowInTaskBar = ShowInTaskBarValue;
            SandBoxKeyPreview = SandBoxKeyPreviewValue;
            Dont_Set_Size = DontSetSize;
            Dont_Set_Location = DontSetLocation;
            SupportTransParentBackGroundColors = supportTransParentBackGroundColorsValue;
        }
        #endregion
        //-------------------------------------------------
    }
}
