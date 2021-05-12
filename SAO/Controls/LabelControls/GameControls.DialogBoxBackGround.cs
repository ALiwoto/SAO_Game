using System.Drawing;

namespace SAO.Controls
{
    
    partial class GameControls
    {
        public sealed partial class DialogBoxBackGround : LabelControl
        {
            //---------------------------------------------
            public Size HexagonSize { get; private set; }
            public Rectangle HexagonRectangle { get; private set; }
            public Rectangle SrcHexagonRectangle { get; private set; }
            public Image HexagonImage { get; private set; }
            //---------------------------------------------
            //---------------------------------------------
            //---------------------------------------------
            #region Constructor Region
            public DialogBoxBackGround(IRes myRes) : 
                base(myRes, LabelControlSpecies.DialogLabelBackGround)
            {
                DesigningForDialogBoxBackGround();
            }
            #endregion
        }
    }
}
