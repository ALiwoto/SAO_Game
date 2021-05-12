using System.Drawing;
using SAO.Controls.Assets.Icons;

namespace SAO.Controls
{
    partial class GameControls
    {
        public partial class IconLabelControl : LabelControl
        {
            //---------------------------------------------
            #region Properties Region
            public GameIcon TheIcon { get; private set; }
            public RectangleF IconRectangleF { get; private set; }
            public RectangleF StringRectangleF { get; private set; }
            public SizeF IconSizeF { get; private set; }
            public PointF IconLocationF { get; private set; }
            public StringFormat StringFormat { get; private set; }
            //---------------------------------------------
            public string FakeText { get; private set; }
            public override string Text { get => string.Empty; set => FakeText = value; }
            //---------------------------------------------
            public bool IsInClickedMode { get; private set; }
            #endregion
            //---------------------------------------------
            #region Constructors Region
            public IconLabelControl(IRes myRes, GameIcon theIcon) : base(myRes)
            {
                TheIcon = theIcon;
                InitializeComponent();
            }
            #endregion
            //---------------------------------------------
        }
    }
}
