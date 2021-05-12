using System;
using System.Drawing;
using WotoProvider.Enums;
using SAO.Constants;
using SAO.GameObjects.Resources;
using SAO.GameObjects.Players;

namespace SAO.Controls.Assets.Icons
{
    public sealed partial class GameIcon : IRes, IDisposable
    {
        //-------------------------------------------------
        #region Constants Region
        public const string Clicked = "_down";
        public const string UnClicked = "_up";
        public const string X_End = "\"x\"";
        public const string Y_End = "\"y\"";
        public const string W_End = "\"w\"";
        public const string H_End = "\"h\"";
        public const string R_End = "\"r\"";
        public const string Separator1 = ":";
        public const string Separator2 = ",";
        #endregion
        //-------------------------------------------------
        #region Properties Region
        public Enum TheIcon { get; }
        public Avatar TheAvatar { get; }
        public WotoRes MyRes { get; set; }
        public Image OriginalImage { get; private set; }
        public RectangleF OriginalRectangle { get; private set; }
        public Image ClickedImage { get; private set; }
        public RectangleF ClickedRectangle { get; private set; }
        //-------------------------------------------------
        public bool HasClicked { get; private set; }
        public bool IsFakeIcon { get; private set; }
        public bool IsDisposed { get; private set; }
        #endregion
        //-------------------------------------------------
        #region Constructors Region
        private GameIcon(Enum theIcon)
        {
            TheIcon = theIcon;
            InitializeComponent();
        }
        private GameIcon(in Avatar theAvatar, in AvatarFormat format)
        {
            TheAvatar = theAvatar;
            InitializeByAvatarComponent(in format);
        }
        private GameIcon(FakeIcons fakeIcon)
        {
            IsFakeIcon  = true;
            TheIcon     = fakeIcon;
            InitializeFakeIconComponent();
        }
        #endregion
        //-------------------------------------------------
        #region Ordinary Methods Region
        public Image GetImage(bool clickedVer = false)
        {
            return (clickedVer && (ClickedImage != null)) ? 
                ClickedImage : OriginalImage;
        }
        public string GetRealFilePath()
        {
            string test = ThereIsConstants.Path.Datas_Path +
                ThereIsConstants.Path.DoubleSlash +
                MyRes.GetString(TheIcon.GetType().Name);
            return test;
        }
        #endregion
        //-------------------------------------------------
        #region static Methods Region
        /// <summary>
        /// Generate a new GameIcon related to the enum you send.
        /// if the enum is not a valid enum, you will get an error.
        /// </summary>
        /// <param name="theIcon">
        /// this enum should be <see cref="Main_Icons"/> or
        /// <see cref="Game_Main_Icons"/>.
        /// </param>
        /// <returns></returns>
        public static GameIcon GenerateIcon(in Enum theIcon)
        {
            switch (theIcon)
            {
                // check if the icon enum passed is a fake icon or not.
                case FakeIcons fakeIcon:
                    {
                        // return the specific method instead of this method.
                        return GenerateFakeIcon(fakeIcon);
                    }

                // check if the enum passed is a player resources enum or not.
                case PlayerResourceType resourceType:
                    {
                        // return the specific method for this work instead of this method.
                        return GenerateIcon(resourceType);
                    }
                default:
                    // nothing.
                    break;
            }
            GameIcon icon = new GameIcon(theIcon);
            return icon;
        }
        public static GameIcon GenerateIcon(in Avatar theAvatar, in AvatarFormat format)
        {
            GameIcon icon = new GameIcon(in theAvatar, in format);
            return icon;
        }
        public static GameIcon GenerateIcon(PlayerResourceType resourceType)
        {
            switch (resourceType)
            {
                case PlayerResourceType.NaN:
                    return null;
                case PlayerResourceType.Coupon:
                    return new GameIcon(Basis_Icons.s_res_1002);
                case PlayerResourceType.Diamond:
                    return new GameIcon(Basis_Icons.s_res_1003);
                case PlayerResourceType.Stone:
                    return null;
                case PlayerResourceType.Silver:
                    return null;
                case PlayerResourceType.Coin:
                    return new GameIcon(Basis_Icons.s_res_1001);
                case PlayerResourceType.Mana:
                    return new GameIcon(Basis_Icons.s_res_1004);
                case PlayerResourceType.MP:
                    return null;
                default:
                    return null;
            }
        }
        public static GameIcon GenerateFakeIcon(FakeIcons theIcon)
        {
            GameIcon icon = new GameIcon(theIcon);
            return icon;
        }
        #endregion
        //-------------------------------------------------
        #region Operators Region
        public static implicit operator Image(GameIcon v)
        {
            return v.GetImage();
        }
        #endregion
        //-------------------------------------------------

    }
}
