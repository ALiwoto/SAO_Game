using System.Drawing;
using SAO.SandBox;
using SAO.Controls.Assets.Icons;

namespace SAO.Controls
{
    partial class GameControls
    {
        partial class ChatInputControl
        {
            //---------------------------------------------
            #region Initialize Region
            private void InitializeComponent()
            {

                this.Size = new Size(this.BackLabel.Width,
                    this.BackLabel.Height / 12);
                this.Location =
                    new Point(0, this.BackLabel.Height - this.Height);
                //---------------------------------------------
                //---------------------------------------------
                //News:
                this.EmojiIconLabel = new IconLabelControl(this,
                    GameIcon.GenerateIcon(Main_Icons.s_main_chat_emoji));
                this.ChatBoxControl = new TextBoxControl();
                this.SendLabelControl = new IconLabelControl(this,
                    GameIcon.GenerateFakeIcon(FakeIcons.s_chat_send_fake));
                //---------------------------------------------
                //Names:
                //TabIndexes
                //FontAndTextAligns:
                this.ChatBoxControl.Font =
                    new Font(this.ChatBoxControl.Font.FontFamily,
                    13f, FontStyle.Regular);
                //Sizes:
                this.ChatBoxControl.Size =
                    new Size((3 * (this.Width / 4)) - 
                    (NoInternetConnectionSandBox.from_the_edge / 2),
                    this.ChatBoxControl.Height);
                this.EmojiIconLabel.SetIconSize();
                this.EmojiIconLabel.Size =
                    Size.Round(this.EmojiIconLabel.IconSizeF);
                this.SendLabelControl.Size =
                    new Size(3 * (this.Height / 5),
                    3 * (this.Height / 5));
                this.SendLabelControl.SetIconSize(this.SendLabelControl.Size);
                //Locations:
                this.ChatBoxControl.Location =
                    new Point(NoInternetConnectionSandBox.from_the_edge / 2,
                    (this.Height / 2) - 
                    (this.ChatBoxControl.Height / 2));
                this.EmojiIconLabel.SetIconLocation();
                this.EmojiIconLabel.Location =
                    new Point(this.ChatBoxControl.Location.X +
                    this.ChatBoxControl.Width +
                    NoInternetConnectionSandBox.from_the_edge,
                    (this.Height / 2) - (this.EmojiIconLabel.Height / 2));
                this.SendLabelControl.SetIconLocation();
                this.SendLabelControl.Location =
                    new Point(this.EmojiIconLabel.Location.X +
                    this.EmojiIconLabel.Width +
                    (NoInternetConnectionSandBox.from_the_edge / 2),
                    (this.Height / 2) - 
                    (this.SendLabelControl.Height / 2));
                //Colors:
                this.BackColor = Color.WhiteSmoke;
                //ComboBoxes:
                //Enableds:
                this.ChatBoxControl.AcceptsReturn = false;
                //Texts:
                //AddRanges:
                //ToolTipSettings:
                //GraphicWorks:
                //Effects:
                //---------------------------------------------
                //Events:

                //---------------------------------------------
                this.Controls.Add(this.ChatBoxControl);
                this.Controls.AddRange(new LabelControl[]
                {
                    this.EmojiIconLabel,
                    this.SendLabelControl
                });
                //---------------------------------------------
                //Final Blows:


            }
            #endregion
            //---------------------------------------------
        }
    }
}