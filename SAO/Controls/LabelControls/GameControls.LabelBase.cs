using System.Drawing;
using System.Windows.Forms;

namespace SAO.Controls
{
    partial class GameControls
    {
        public abstract partial class LabelBase : Label
        {
            public virtual Color[] PaintColors { get; protected set; }
            public virtual Brush[] PaintBrushes { get; protected set; }
            public virtual Pen[] PaintPens { get; protected set; }
            public virtual LabelBase SurfacesLabels { get; protected set; }
            //---------------------------------------------
            public virtual bool DrawNothing { get; set; }
            //---------------------------------------------

            public LabelBase()
            {
                InitializeComponent();
            }
        }
    }
}
