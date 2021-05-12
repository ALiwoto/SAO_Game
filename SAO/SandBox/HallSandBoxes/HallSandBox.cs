using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Drawing.Text;
using System.Security;
using System.Globalization;
//using System.Threading;
using System.Media;
using SAO.Constants;
using SAO.Controls;
using SAO.SandBox;
using SAO.LoadingService;

namespace SAO.SandBox.HallSandBoxes
{
    public partial class HallSandBox : SandBoxBase
    {
        //-------------------------------------------------
        #region Constant's Region
        /// <summary>
        /// Used to get the name of file: Hall of secrets6 (check your files),
        /// file name in Res, then use: MyRes.GetString() to get the path in the Data folder.
        /// </summary>
        public const string FirstHallOfSecretsNameInRes = "HallOfSecrets6FileName";
        /// <summary>
        /// Used to get the name of file: Hall of secrets6 (check your files),
        /// file name in Res, then use: MyRes.GetString() to get the path in the Data folder.
        /// </summary>
        public const string ElementHallOfSecretsNameInRes = "HallOfSecrets15FileName";
        public const int BookStroryHallRate = 80;
        #endregion
        //-------------------------------------------------
        #region Properties Region
        public Size OriginalSize { get; set; }
        public Point OriginalPoint { get; set; }
        public Trigger AnimationTimer { get; set; }
        public EventHandler EventAfterEndingTheAnimation { get; set; }
        public CustomDesign CustomDesign { get; set; }
        public SandBoxBase MyFrontSandBox { get; set; }
        protected override SandBoxMode Mode { get; }
        public HallSandBoxMode HallMode { get; }
        //-----------------------------------------
        public bool IsHallUp { get; set; }
        /// <summary>
        /// Determine whether I should use Animation or not
        /// </summary>
        public bool UseAnimation { get; set; }
        #endregion
        //-------------------------------------------------
        #region Constructor's Region
        /// <summary>
        /// use this constructore for fun :|
        /// </summary>
        /// <param name="BackingForm">
        /// this parameter should be <see cref="ThereIsConstants.Forming.GameClient"/>
        /// </param>
        public HallSandBox(GameControls.PageControl BackingForm, 
            SandBoxBase myFrontSandBoxValue, HallSandBoxMode myMode,
            bool useAnimationValue = true,
            EventHandler eventAfterEndingTheAnimation = null) :
            base(BackingForm, new CustomDesign() {
                Dont_Set_Location = false,
                Dont_Set_Size = false,
                SandBoxOpacity = 0.7,
                SandBoxBackColor = Color.DarkGray,
            })
        {
            MyFrontSandBox                  = myFrontSandBoxValue;
            Mode                            = SandBoxMode.HallSandBoxMode;
            HallMode                        = myMode;
            UseAnimation                    = useAnimationValue;
            EventAfterEndingTheAnimation    = eventAfterEndingTheAnimation;
            switch (HallMode)
            {
                case HallSandBoxMode.HallOfBookStoryMode:
                    Initialize_HallOfStory_Component();
                    break;
                case HallSandBoxMode.HallOfElementMode:
                    Initialize_HallOfElements_Component();
                    break;
                default:
                    break;
            }
            
            Show();
        }
        public HallSandBox(GameControls.PageControl BackingForm, SandBoxBase myFrontSandBoxValue,
            HallSandBoxMode myMode,
            CustomDesign myCustomDesignValue, 
            bool useAnimationValue = true, EventHandler eventAfterEndingTheAnimation = null) :
            base(BackingForm, myCustomDesignValue)
        {
            MyFrontSandBox                  = myFrontSandBoxValue;
            Mode                            = SandBoxMode.HallSandBoxMode;
            HallMode                        = myMode;
            UseAnimation                    = useAnimationValue;
            CustomDesign                    = myCustomDesignValue;
            EventAfterEndingTheAnimation    = eventAfterEndingTheAnimation;
            switch (HallMode)
            {
                case HallSandBoxMode.HallOfBookStoryMode:
                    Initialize_HallOfStory_Component();
                    break;
                case HallSandBoxMode.HallOfElementMode:
                    Initialize_HallOfElements_Component();
                    break;
                default:
                    break;
            }

            Show();
        }
        #endregion
        //-------------------------------------------------
    }
}
