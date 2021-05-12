using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SAO.SandBox;

namespace SAO.Controls
{
    partial class GameControls
    {
        public partial class CloseLabel : LabelControl, IButtonControl
        {
            //---------------------------------------------
            #region Properties Region
            //---------------------------------------------
            public DialogResult DialogResult { get; set; }
            //---------------------------------------------


            #endregion
            //---------------------------------------------
            #region Constructors Region
            public CloseLabel(IRes myRes, SandBoxBase myFather) : 
                base(myRes, LabelControlSpecies.CloseLabel, myFather)
            {
                DesigningForClosingLabel();
            }
            #endregion
            //---------------------------------------------
        }
    }
}
