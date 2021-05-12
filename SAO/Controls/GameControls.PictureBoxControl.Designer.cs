// Copyright (C) ALiwoto 2019 - 2020
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of the source code.

using System.Drawing;
using System.Windows.Forms;
using SAO.Constants;

namespace SAO.Controls
{
    partial class GameControls
    {
        partial class PictureBoxControl
        {
            private void InitializeComponent()
            {
                //--------------------------------------

                //--------------------------------------
                this.MouseDown += PictureBoxControl_MouseDown;
                this.MouseUp += PictureBoxControl_MouseUp;
                if(BackGroundLabelControl != null)
                {
                    this.MouseEnter += this.BackGroundLabelControl.ElementLabelControl_MouseEnter;
                    this.MouseLeave += this.BackGroundLabelControl.ElementLabelControl_MouseLeave;
                    this.MouseDown += this.BackGroundLabelControl.ElementLabelControl_MouseDown;
                    this.MouseUp += this.BackGroundLabelControl.ElementLabelControl_MouseUp;
                }
                //--------------------------------------
                SetColorTransparent();
            }


            private void PictureBoxControl_MouseUp(object sender, MouseEventArgs e)
            {
                if (!DontUseClickedImage && ClickedImage != null &&
                    OriginalImage != null)
                {
                    this.Image = OriginalImage;
                }
                else
                {
                    return;
                }
            }

            private void PictureBoxControl_MouseDown(object sender, MouseEventArgs e)
            {
                if (!DontUseClickedImage && ClickedImage != null &&
                    OriginalImage != null)
                {
                    this.Image = ClickedImage;
                }
                else
                {
                    return;
                }
            }

            //-------------------------------------------------
            #region All Set Are Here :"
            /// <summary>
            /// Set the Label.Name Property with the Constant Parameter writed
            /// in <see cref="ThereIsConstants.ResourcesName"/> 
            /// with the <see cref="ThereIsConstants.ResourcesName.End_Res_Name"/>
            /// </summary>
            /// <param name="ConstParam">
            /// The Constant Parameter setted in 
            /// <see cref="ThereIsConstants.ResourcesName "/> 
            /// and in
            /// <see cref="MainForm.MyRes"/>.
            /// </param>
            public void SetPictureName(string constParam)
            {
                this.Name = constParam +
                    ThereIsConstants.ResourcesName.End_Res_Name;
            }
            /// <summary>
            /// This Function will set the Label.Text Property with the algorithm
            /// from MainForm.MyRes.
            /// </summary>
            public void SetPictureText()
            {
                this.Text = this.MyRes.GetString(
                    this.MyRes.GetString(this.Name) +
                    ThereIsConstants.ResourcesName.Separate_Character +
                    ThereIsConstants.AppSettings.Language +
                    this.CurrentStatus.ToString());
            }
            /// <summary>
            /// Setting the Text property to customValue.
            /// </summary>
            /// <param name="customValue">
            /// the custom Text.
            /// </param>
            public void SetPictureText(string customValue)
            {
                this.Text = customValue;
            }
            /// <summary>
            /// Set the <see cref="PictureBox.Image"/> Property with
            /// <see cref="Control.Name"/> propert (It should return the Image name in the Data folder.)
            /// look: <see cref="PictureBoxControl.MyRes"/>.
            /// </summary>
            public void SetPicture()
            {
                if (!DontUseClickedImage)
                {
                    this.OriginalImage = Image.FromFile(ThereIsConstants.Path.Datas_Path +
                        ThereIsConstants.Path.DoubleSlash +
                        MyRes.GetString(
                        MyRes.GetString(Name) + ThereIsConstants.ResourcesName.Separate_Character +
                        ThereIsConstants.AppSettings.Language +
                        this.CurrentStatus.ToString()));
                    this.Image = OriginalImage;
                }
                else
                {
                    this.Image = Image.FromFile(ThereIsConstants.Path.Datas_Path +
                        ThereIsConstants.Path.DoubleSlash +
                        MyRes.GetString(
                        MyRes.GetString(Name) + ThereIsConstants.ResourcesName.Separate_Character +
                        ThereIsConstants.AppSettings.Language +
                        this.CurrentStatus.ToString()));
                }
            }
            public void SetPicture(float rotateAngle)
            {
                if (!DontUseClickedImage)
                {
                    this.Image = ThereIsConstants.Actions.RotateImage(
                        new Bitmap(Image.FromFile(ThereIsConstants.Path.Datas_Path +
                        ThereIsConstants.Path.DoubleSlash +
                        MyRes.GetString(
                            MyRes.GetString(Name) + ThereIsConstants.ResourcesName.Separate_Character +
                        ThereIsConstants.AppSettings.Language +
                        this.CurrentStatus.ToString()))), rotateAngle);
                    this.Image = OriginalImage;
                }
                else
                {
                    this.Image = ThereIsConstants.Actions.RotateImage(
                        new Bitmap(Image.FromFile(ThereIsConstants.Path.Datas_Path +
                        ThereIsConstants.Path.DoubleSlash +
                        MyRes.GetString(
                        MyRes.GetString(Name) + ThereIsConstants.ResourcesName.Separate_Character +
                        ThereIsConstants.AppSettings.Language +
                        this.CurrentStatus.ToString()))), rotateAngle);
                        
                }
            }
            public void SetPicture(Image image)
            {
                this.Image = image;
            }
            public void SetPicture(Image image, float rotateAngle)
            {
                this.Image = ThereIsConstants.Actions.RotateImage(new Bitmap(image), rotateAngle);
            }
            /// <summary>
            /// Before using this function, please set the <see cref="CurrentStatus"/>
            /// to the status which the <see cref="CurrentStatus"/>++ is the name of the
            /// Clicked Image in the data folde.
            /// </summary>
            public void SetClickedPicture()
            {
                if (!DontUseClickedImage)
                {
                    this.ClickedImage = Image.FromFile(ThereIsConstants.Path.Datas_Path +
                        ThereIsConstants.Path.DoubleSlash +
                        MyRes.GetString(
                        MyRes.GetString(Name) + ThereIsConstants.ResourcesName.Separate_Character +
                        ThereIsConstants.AppSettings.Language +
                        (this.CurrentStatus + 1).ToString()));
                }
                else
                {
                    return;
                }
            }
            #endregion
            //-------------------------------------------------
            /// <summary>
            /// Setting the this.BackColor Parameter to Color.Transparent.
            /// </summary>
            public void SetColorTransparent()
            {
                this.BackColor = Color.Transparent;
            }

        }
    }
}
