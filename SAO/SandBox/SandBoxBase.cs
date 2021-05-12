using System.Windows.Forms;
using SAO.Controls;
using SAO.SandBox.HallSandBoxes;
using SAO.Client;
using SAO.GameObjects.Resources;

namespace SAO.SandBox
{
    //---------------------------------
    #region SandBox Classes Region
    /// <summary>
    /// Mother of the SandBoxes :)
    /// </summary>
    /// [ComVisible(true)]
    public abstract partial class SandBoxBase : GameControls.PageControl, IRes
    {
        //-------------------------------------------
        public GameControls.PageControl UnderForm { get; }
        public CustomDesign SandBoxCustomDesign { get; set; }
        public WotoRes MyRes { get; set; }
        public SandBoxBase ShowingAnotherSandBox { get; set; }
        public HallSandBox MyHallSandBox { get; set; }
        //--------------------------------------------
        //--------------------------------------------
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                // turn on WS_EX_TOOLWINDOW style bit
                cp.ExStyle |= 0x80;
                return cp;
            }
        }
        //--------------------------------------------

        public bool HasCustomDesign { get; set; }
        public bool IsShowingAnotherSandBox { get; set; }
        /// <summary>
        /// If this value was tru, beware that
        /// I CLOSED THE SANDBOX, so please don't close the 
        /// <see cref="GameClient"/>
        /// </summary>
        public bool ClosedByMe { get; set; }
        //------------------
        public const int from_the_edge = 10;
        public const int SeparatorLine_Height = 6;
        //-------------------------------------------
        protected virtual SandBoxMode Mode { get; }
        //-------------------------------------------
        public SandBoxBase(GameControls.PageControl currentForm)
        {
            ShowInTaskbar = false;
            UnderForm = currentForm;
            currentForm.Enabled = false;
            AllowDrop = false;
            //Mode = mode; It will set in another Classes :))
            InitializeComponent();
        }
        public SandBoxBase(GameControls.PageControl currentForm, CustomDesign customDesignValue)
        {
            Size = default;
            UnderForm = currentForm;
            currentForm.Enabled = false;
            currentForm.BringToFront();
            BringToFront();
            SandBoxCustomDesign = customDesignValue;
            AllowDrop = false;
            ShowInTaskbar = SandBoxCustomDesign.ShowInTaskBar;
            HasCustomDesign = true;
            InitializeComponent();
        }
        protected SandBoxBase()
        {

        }
        ~SandBoxBase()
        {

        }
        //-------------------------------------------
        public SandBoxMode GetMode() => Mode;
        public SandBoxBase GetTheHighestSandBox(bool WantMeToFocusThem, bool SetTheEnabledToFalse = true)
        {
            if (IsShowingAnotherSandBox && ShowingAnotherSandBox != null)
            {
                if (WantMeToFocusThem)
                {
                    if (MyHallSandBox != null)
                    {
                        MyHallSandBox.Focus();
                    }
                    Focus();
                    if(ShowingAnotherSandBox != null)
                    {
                        ShowingAnotherSandBox.Focus();
                    }
                    
                }
                if(SetTheEnabledToFalse && !(ShowingAnotherSandBox is HallSandBox) && Enabled)
                {
                    Enabled = false;
                }
                return ShowingAnotherSandBox.GetTheHighestSandBox(WantMeToFocusThem);
            }
            else
            {
                if (WantMeToFocusThem)
                {
                    if (MyHallSandBox != null)
                    {
                        MyHallSandBox.Focus();
                    }
                    Focus();
                    if(SetTheEnabledToFalse && Enabled)
                    {
                        //Enabled = false;
                    }
                }
                return this;
            }
        }
        public void SetTheHighestSandBox(SandBoxBase mySandBox)
        {
            if (IsShowingAnotherSandBox && ShowingAnotherSandBox != null)
            {
                Enabled = false;
                ShowingAnotherSandBox.Enabled = false;
                ShowingAnotherSandBox.SetTheHighestSandBox(mySandBox);
            }
            else
            {
                IsShowingAnotherSandBox = true;
                ShowingAnotherSandBox = mySandBox;
                mySandBox.Focus();
            }
        }
        
        //-------------------------------------------
    }
    #endregion
    //----------------------------------
}
