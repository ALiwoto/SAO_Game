
namespace SAO.Controls
{
    partial class GameControls
    {
        public  partial class MapSigner : LabelControl
        {
            //------------------------------------------
            public LabelControl MessageLabel2 { get; set; }
            public MapSigner MapDisplayer { get; set; }
            //------------------------------------------
            public const string KingdomPreviewPictureBoxNameInRes = "KingdomPreviewPictureBox";
            //------------------------------------------
            //------------------------------------------
            //------------------------------------------
            //------------------------------------------
            public MapSigner(IRes myRes, 
                LabelControlSpecies myDesigningMode = LabelControlSpecies.MapSigner) : 
                base(myRes, myDesigningMode)
            {
                switch (DesigningMode)
                {
                    case LabelControlSpecies.MapSigner:
                        Initialize_ForMapSigner_Component();
                        break;
                    case LabelControlSpecies.MapDisplayer:
                        Initialize_ForMapDisplayer_Component();
                        break;
                }
                
            }
            public MapSigner(IRes myRes, uint currentStatus, 
                LabelControlSpecies myDesigningMode = LabelControlSpecies.MapDisplayer) :
                base(myRes, myDesigningMode)
            {
                CurrentStatus = currentStatus;
                switch (DesigningMode)
                {
                    case LabelControlSpecies.MapSigner:
                        Initialize_ForMapSigner_Component();
                        break;
                    case LabelControlSpecies.MapDisplayer:
                        Initialize_ForMapDisplayer_Component();
                        break;
                }
            }
            //------------------------------------------
        }

    }
}
