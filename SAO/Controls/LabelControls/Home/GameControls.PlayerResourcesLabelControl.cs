using SAO.Controls.Assets.Icons;
using WotoProvider.Enums;

namespace SAO.Controls
{
    partial class GameControls
    {
        private sealed partial class PlayerResourcesLabelControl : IconLabelControl
        {
            //---------------------------------------------
            #region Constants Region
            public const float ResBackWidthRate = 1.5f;
            public const float ResBackHeightRate = 1.2f;
            #endregion
            //---------------------------------------------
            #region Properties Region
            //---------------------------------------------
            public IconLabelControl PlusResIconLabel { get; private set; }
            public IconLabelControl ResIconLabel { get; private set; }

            //---------------------------------------------
            public PlayerResourceType ResourceType { get; }
            #endregion
            //---------------------------------------------

            //---------------------------------------------
            #region Constructors Region
            internal PlayerResourcesLabelControl(IRes myRes, PlayerResourceType resourceType)
                : base(myRes, GameIcon.GenerateIcon(Basis_Icons.s_prg_track_2))
            {
                ResourceType = resourceType;
                InitializeComponent();
            }
            #endregion
        }
    }
}
