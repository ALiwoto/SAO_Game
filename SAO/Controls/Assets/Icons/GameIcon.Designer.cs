using System.Drawing;
using SAO.Constants;
using SAO.Security;
using SAO.GameObjects.Players;
using SAO.GameObjects.Resources;

namespace SAO.Controls.Assets.Icons
{
    partial class GameIcon
    {
        //-------------------------------------------------
        #region Initialize Region
        private void InitializeComponent()
        {
            //-----------------------------------------
            //News:
            this.MyRes = new WotoRes(typeof(GameIcon));
            //-----------------------------------------
            //Names:
            //TabIndexes:
            //FontAndTextAligns:
            //Sizes:
            //Locations:
            //Colors:
            //ComboBoxes:
            //Enableds:
            //Booleans:
            this.HasClicked = this.MyRes.StringExists(TheIcon.ToString() + UnClicked) &&
                this.MyRes.StringExists(TheIcon.ToString() + Clicked);
            //Texts:
            //AddRanges:
            //ToolTipSettings:
            //-----------------------------------------
            //Events:
            //-----------------------------------------
            if (this.HasClicked)
            {
                this.SetOriginalImage();
                this.SetClickedImage();
            }
            else
            {
                this.SetOriginalImage(this.HasClicked);
            }
        }
        private void SetOriginalImage(bool hasClicked = true)
        {
            StrongString myString;
            StrongString[] myStrings;
            this.OriginalImage =
                Image.FromFile(GetRealFilePath());
            if (hasClicked)
            {
                myString = this.MyRes.GetString(TheIcon.ToString() + UnClicked);
            }
            else
            {
                myString = this.MyRes.GetString(TheIcon.ToString());
            }
            myStrings = myString.Split(
                new string[]
                {
                    X_End,
                    Y_End,
                    W_End,
                    H_End,
                    R_End,
                    Separator1,
                    Separator2,
                });
            this.OriginalRectangle =
                new RectangleF(
                    myStrings[0].ToInt32(),
                    myStrings[1].ToInt32(),
                    myStrings[2].ToInt32(),
                    myStrings[3].ToInt32());
            var image = this.OriginalImage;
            // check if the length of this array is more than 4 or not
            if (myStrings.Length > 4)
            {
                // it means this icon should rotate.
                this.OriginalImage =
                ThereIsConstants.Actions.RotateImage(
                    ThereIsConstants.Actions.CropImage(OriginalImage, OriginalRectangle), 
                    myStrings[4].ToSingle());
            }
            else
            {
                this.OriginalImage =
                ThereIsConstants.Actions.CropImage(OriginalImage, OriginalRectangle);
            }
            image.Dispose();
        }
        private void SetClickedImage()
        {
            StrongString myString;
            StrongString[] myStrings;
            this.ClickedImage =
                Image.FromFile(GetRealFilePath());

            myString = this.MyRes.GetString(TheIcon.ToString() + Clicked);
            myStrings = myString.Split(
                    X_End,
                    Y_End,
                    W_End,
                    H_End,
                    R_End,
                    Separator1,
                    Separator2);
            this.ClickedRectangle =
                new Rectangle(myStrings[0].ToInt32(),
                    myStrings[1].ToInt32(),
                    myStrings[2].ToInt32(),
                    myStrings[3].ToInt32());
            var image = this.ClickedImage;
            // check if the length of this array is more than 4 or not
            if (myStrings.Length > 4)
            {
                // it means this icon should rotate.
                this.ClickedImage =
                ThereIsConstants.Actions.RotateImage(
                    ThereIsConstants.Actions.CropImage(ClickedImage, ClickedRectangle),
                    myStrings[4].ToSingle());
            }
            else
            {
                this.ClickedImage =
                ThereIsConstants.Actions.CropImage(ClickedImage, ClickedRectangle);
            }
            image.Dispose();
        }
        private void InitializeByAvatarComponent(in AvatarFormat format)
        {
            //-----------------------------------------
            //News:
            this.MyRes = new WotoRes(typeof(GameIcon));
            //-----------------------------------------
            //Names:
            //TabIndexes:
            //FontAndTextAligns:
            //Images:
            this.OriginalImage = TheAvatar.GetImage(format);
            //Sizes:
            //Locations:
            //Colors:
            //ComboBoxes:
            //Enableds:
            //Booleans:
            this.HasClicked = false; // Avatars are not Clicked Images.
            //Texts:
            //AddRanges:
            //ToolTipSettings:
            //-----------------------------------------
            //Events:
            //-----------------------------------------
        }
        private void InitializeFakeIconComponent()
        {
            //-----------------------------------------
            //News:
            this.MyRes = new WotoRes(typeof(GameIcon));
            //-----------------------------------------
            //Names:
            //TabIndexes:
            //FontAndTextAligns:
            //Images:

            //Sizes:
            //Locations:
            //Colors:
            //ComboBoxes:
            //Enableds:
            //Booleans:
            this.HasClicked = this.MyRes.StringExists(TheIcon.ToString() + UnClicked) &&
                this.MyRes.StringExists(TheIcon.ToString() + Clicked);
            //Texts:
            //AddRanges:
            //ToolTipSettings:
            //-----------------------------------------
            //Events:
            //-----------------------------------------
            if (this.HasClicked)
            {
                this.SetOriginalFakeImage();
                this.SetClickedFakeImage();
            }
            else
            {
                this.SetOriginalFakeImage(this.HasClicked);
            }
        }
        private void SetOriginalFakeImage(bool hasClicked = true)
        {
            if (hasClicked)
            {
                this.OriginalImage =
                    Image.FromFile(ThereIsConstants.Path.Datas_Path +
                    ThereIsConstants.Path.DoubleSlash +
                    this.MyRes.GetString(TheIcon.ToString() + UnClicked));
            }
            else
            {
                this.OriginalImage =
                    Image.FromFile(ThereIsConstants.Path.Datas_Path +
                    ThereIsConstants.Path.DoubleSlash +
                    this.MyRes.GetString(TheIcon.ToString()));
            }
        }
        private void SetClickedFakeImage()
        {
            this.ClickedImage =
                Image.FromFile(ThereIsConstants.Path.Datas_Path +
                    ThereIsConstants.Path.DoubleSlash +
                    this.MyRes.GetString(TheIcon.ToString() + Clicked));
        }
        #endregion
        //-------------------------------------------------
        #region Ordinary Methods
        public RectangleF GetOriginalRectangleF()
        {
            return new RectangleF(0, 0, this.OriginalImage.Width,
                this.OriginalImage.Height);
        }
        public RectangleF GetClickedRectangleF()
        {
            return new RectangleF(0, 0, this.ClickedImage.Width,
                this.ClickedImage.Height);
        }
        public void FixOriginalIcon(RectangleF rectangleF)
        {
            this.OriginalImage =
                ThereIsConstants.Actions.CropImage(this.OriginalImage, rectangleF);
        }
        public void FixClickedIcon(RectangleF rectangleF)
        {
            this.ClickedImage =
                ThereIsConstants.Actions.CropImage(this.OriginalImage, rectangleF);
        }
        /// <summary>
        /// Realese all recollection :/
        /// </summary>
        public void Dispose()
        {
            if (this.IsDisposed)
            {
                return;
            }
            if (this.OriginalImage != null)
            {
                using (var image = OriginalImage)
                {
                    this.OriginalImage = null;
                    image.Dispose();
                }
            }
            if (this.ClickedImage != null)
            {
                using (var image = ClickedImage)
                {
                    this.ClickedImage = null;
                    image.Dispose();
                }
            }
            if (this.MyRes != null)
            {
                this.MyRes.ReleaseAllResources();
                this.MyRes = null;
            }
            this.IsDisposed = true;
        }
        #endregion
        //-------------------------------------------------

    }
}
