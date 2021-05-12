
namespace SAO.Controls
{
    partial class GameControls
    {
        public sealed partial class ChatInputControl : LabelControl
        {
            //---------------------------------------------
            #region Constants Region

            #endregion
            //---------------------------------------------
            #region Properties Region
            public LabelControl BackLabel { get; }
            public IconLabelControl EmojiIconLabel { get; private set; }
            public IconLabelControl SendLabelControl { get; private set; }
            public TextBoxControl ChatBoxControl { get; private set; }
            #endregion
            //---------------------------------------------
            #region Constructors Region
            public ChatInputControl(IRes myRes, LabelControl backLabel) :
                base(myRes, LabelControlSpecies.ChatInputLabel)
            {
                BackLabel = backLabel;
                InitializeComponent();
            }
            #endregion
            //---------------------------------------------
        }
    }
}
