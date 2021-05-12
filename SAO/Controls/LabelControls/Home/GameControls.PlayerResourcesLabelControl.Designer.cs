using System.Drawing;
using SAO.Constants;
using SAO.GameObjects.ServerObjects;
using SAO.Controls.Assets.Icons;

namespace SAO.Controls
{
    partial class GameControls
    {
        partial class PlayerResourcesLabelControl
        {
            //---------------------------------------------

            private void InitializeComponent()
            {
                //----------------------------------
                //News:
                this.PlusResIconLabel = new IconLabelControl(this,
                    GameIcon.GenerateIcon(Basis_Icons.s_btn_plus));
                this.ResIconLabel = new IconLabelControl(this,
                    GameIcon.GenerateIcon(this.ResourceType));
                //----------------------------------
                //Names:
                //TabIndexes
                //FontAndTextAligns:
                this.Font =
                    new Font(ThereIsConstants.Forming.TheMainForm.PrivateFonts.Families[1],
                    13, FontStyle.Bold);
                this.TextAlign = ContentAlignment.MiddleCenter;
                //Sizes:
                this.SetIconSize();
                this.SetIconSize(ResBackWidthRate * this.IconSizeF.Width,
                    ResBackHeightRate * this.IconSizeF.Height);
                this.PlusResIconLabel.SetIconSize(this.IconSizeF.Height,
                    this.IconSizeF.Height);
                this.ResIconLabel.SetIconSize(this.IconSizeF.Height,
                    this.IconSizeF.Height);
                this.Size =
                    new Size((int)(this.IconSizeF.Width +
                        this.PlusResIconLabel.IconSizeF.Width + 
                        this.ResIconLabel.IconSizeF.Width),
                        (int)this.IconSizeF.Height);
                this.PlusResIconLabel.Size =
                    Size.Round(this.PlusResIconLabel.IconSizeF);
                this.ResIconLabel.Size =
                    Size.Round(this.ResIconLabel.IconSizeF);
                //Locations:
                this.SetIconLocation();
                this.PlusResIconLabel.SetIconLocation();
                this.ResIconLabel.SetIconLocation();
                this.PlusResIconLabel.Location =
                    new Point(this.Width -
                    this.PlusResIconLabel.Width, 0);
                this.ResIconLabel.Location = default;
                //Rectangles:
                this.SetStringRectangle(new RectangleF(
                    this.ResIconLabel.Location.X + this.ResIconLabel.Width,
                    this.IconLocationF.Y,
                    this.Width - this.ResIconLabel.Width - 
                    this.PlusResIconLabel.Width,
                    this.Height));
                //Colors:
                this.SetTextColor(Color.GhostWhite);
                this.ResIconLabel.SetColorTransparent();
                //SoundEffects:
                this.ResIconLabel.SetLabelSoundEffects(Noises.NoNoise);
                this.SetLabelSoundEffects(Noises.NoNoise);
                //ComboBoxes:
                //Enableds:
                //Texts:
                this.SetLabelText(
                    ThereIsServer.GameObjects.MyProfile.PlayerResources[ResourceType].ToString());
                //AddRanges:
                //ToolTipSettings:
                //----------------------------------
                //Events:
                //----------------------------------
                //AddRanges:
                this.Controls.AddRange(new IconLabelControl[]
                {
                    this.PlusResIconLabel,
                    this.ResIconLabel,
                });
                this.Refresh();
            }
            //---------------------------------------------
            //---------------------------------------------
            //---------------------------------------------
        }
    }
}