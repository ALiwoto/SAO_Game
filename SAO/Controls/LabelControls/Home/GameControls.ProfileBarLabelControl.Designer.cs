// Copyright (C) ALiwoto 2019 - 2020
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of the source code.

using System.Drawing;
using System.Windows.Forms;
using WotoProvider.Enums;
using SAO.SandBox;
using SAO.Constants;
using SAO.GameObjects.Players;
using SAO.Controls.Assets.Icons;
using SAO.GameObjects.ServerObjects;

namespace SAO.Controls
{
    partial class GameControls
    {
        partial class ProfileBarLabelControl
        {
            //---------------------------------------------
            //---------------------------------------------
            //---------------------------------------------
            #region Initialize Region
            private void InitializeComponent()
            {
                this.SuspendLayout();
                //-----------------------------------------
                //News:
                this.Profile_NavIcon = GameIcon.GenerateIcon(Main_Icons.s_main_role_bg);
                this.Profile_NavIconLabel = new IconLabelControl(this, this.Profile_NavIcon);
                this.AvatarIconLabel = new IconLabelControl(this,
                    GameIcon.GenerateIcon(ThereIsServer.GameObjects.MyProfile.PlayerAvatar, 
                     AvatarFormat.Format02));
                this.ExpTrackIconLabel = new IconLabelControl(this,
                    GameIcon.GenerateIcon(Main_Icons.s_main_exp_track));
                this.ExpThumbIconLabel = new IconLabelControl(this,
                    GameIcon.GenerateIcon(Main_Icons.s_main_exp_thumb));
                this.TimeIconLabel = new IconLabelControl(this,
                    GameIcon.GenerateFakeIcon(FakeIcons.s_time_icon_fake));
                this.DiamondResIconLabel = new PlayerResourcesLabelControl(this,
                    PlayerResourceType.Diamond);
                this.CouponResIconLabel = new PlayerResourcesLabelControl(this,
                     PlayerResourceType.Coupon);
                this.CoinResIconLabel = new PlayerResourcesLabelControl(this,
                    PlayerResourceType.Coin);
                this.ManaResIconLabel = new PlayerResourcesLabelControl(this,
                    PlayerResourceType.Mana);


                this.PlayerNameLabelControl = new LabelControl(this);
                this.PlayerLvlLabelControl = new LabelControl(this);
                this.GameTimeTrigger = new Trigger()
                {
                    Index = 0,
                    Enabled = false,
                    Running_Worker = false,
                    SingleLineWorker = true,
                    Interval = 1000,
                    Name = GameTimeTriggerName,
                };
                //-----------------------------------------
                //Names:
                //TabIndexes:
                //FontAndTextAligns:
                this.PlayerNameLabelControl.Font = this.TimeIconLabel.Font =
                    new Font(ThereIsConstants.Forming.TheMainForm.PrivateFonts.Families[1],
                    15, FontStyle.Bold);
                this.PlayerLvlLabelControl.Font =
                    new Font(ThereIsConstants.Forming.TheMainForm.PrivateFonts.Families[1],
                    11, FontStyle.Bold);
                this.ExpThumbIconLabel.Font =
                    new Font(ThereIsConstants.Forming.TheMainForm.PrivateFonts.Families[1],
                    12, FontStyle.Bold);
                this.PlayerNameLabelControl.TextAlign   = ContentAlignment.MiddleLeft;
                this.PlayerLvlLabelControl.TextAlign    = ContentAlignment.BottomCenter;
                this.ExpThumbIconLabel.TextAlign        = ContentAlignment.TopRight;
                this.TimeIconLabel.TextAlign            = ContentAlignment.MiddleCenter;
                this.TimeIconLabel.Image =
                    Image.FromFile(ThereIsConstants.Path.Datas_Path + 
                    ThereIsConstants.Path.DoubleSlash + 
                    this.MyRes.GetString(GameTimerBGNameInRes));
                //Sizes:
                Size roundedSize = Size.Round(Profile_NavIconLabel.IconSizeF); // rounded size of nav Icon.
                this.Profile_NavIconLabel.SetIconSize();
                this.ExpTrackIconLabel.SetIconSize();
                this.TimeIconLabel.SetIconSize();

                this.AvatarIconLabel.SetIconSize(Profile_NavIconLabel.IconSizeF.Height -
                (2 * (NoInternetConnectionSandBox.from_the_edge / 5)),
                Profile_NavIconLabel.IconSizeF.Height - 
                (2 * (NoInternetConnectionSandBox.from_the_edge / 5)));
                this.Size = this.Profile_NavIconLabel.Size =
                    new Size(roundedSize.Width + NoInternetConnectionSandBox.from_the_edge,
                        roundedSize.Height + NoInternetConnectionSandBox.from_the_edge);
                this.AvatarIconLabel.Size =
                    new Size(Profile_NavIconLabel.Height -
                    NoInternetConnectionSandBox.from_the_edge,
                    Profile_NavIconLabel.Height);
                this.PlayerNameLabelControl.Size =
                    new Size(roundedSize.Width - roundedSize.Height, 
                    (10 * (roundedSize.Height / 16)));
                this.PlayerLvlLabelControl.Size =
                    new Size((12 * (roundedSize.Height / 16)),
                    (6 * (roundedSize.Height / 16)));
                this.ExpTrackIconLabel.Size =
                    new Size(roundedSize.Width - PlayerLvlLabelControl.Width,
                    PlayerLvlLabelControl.Height);
                float test = (float)ThereIsServer.GameObjects.MyProfile.GetAdvancingExp();
                this.ExpThumbIconLabel.TheIcon.FixOriginalIcon(new RectangleF(0, 0,
                    (((float)ThereIsServer.GameObjects.MyProfile.GetAdvancingExp()) * 
                    ExpTrackIconLabel.IconSizeF.Width),
                    ExpThumbIconLabel.TheIcon.OriginalImage.Height));
                this.ExpThumbIconLabel.SetIconSize();
                this.ExpThumbIconLabel.Size = ExpTrackIconLabel.Size;




                this.TimeIconLabel.Size = this.TimeIconLabel.TheIcon.OriginalImage.Size;
                //Locations:
                this.Profile_NavIconLabel.SetIconLocation(NoInternetConnectionSandBox.from_the_edge,
                NoInternetConnectionSandBox.from_the_edge);
                this.AvatarIconLabel.SetIconLocation(default);
                this.TimeIconLabel.SetIconLocation(default);
                this.ExpTrackIconLabel.SetIconLocation(0,
                    (ExpTrackIconLabel.Height / 2) - 
                    (ExpTrackIconLabel.IconSizeF.Height / 2));
                this.AvatarIconLabel.Location = new Point(NoInternetConnectionSandBox.from_the_edge +
                    (NoInternetConnectionSandBox.from_the_edge / 10),
                    NoInternetConnectionSandBox.from_the_edge +
                    (NoInternetConnectionSandBox.from_the_edge / 10));
                this.PlayerNameLabelControl.Location = 
                    new Point(AvatarIconLabel.Location.X + (7 * (AvatarIconLabel.Width / 6)),
                    AvatarIconLabel.Location.Y + 
                    (NoInternetConnectionSandBox.from_the_edge / 10));
                this.PlayerLvlLabelControl.Location =
                    new Point(AvatarIconLabel.Location.X + AvatarIconLabel.Width - 
                    (3 * (NoInternetConnectionSandBox.from_the_edge / 2)),
                    AvatarIconLabel.Location.Y + AvatarIconLabel.Height -
                    (3 * (NoInternetConnectionSandBox.from_the_edge / 2)) -
                    PlayerLvlLabelControl.Height);
                this.ExpTrackIconLabel.Location =
                    new Point(PlayerLvlLabelControl.Location.X +
                    PlayerLvlLabelControl.Width,
                    PlayerLvlLabelControl.Location.Y);
                this.ExpThumbIconLabel.SetIconLocation(this.ExpTrackIconLabel.IconLocationF);
                this.ExpThumbIconLabel.Location = default;
                this.TimeIconLabel.Location = new Point(Father.Width -
                    TimeIconLabel.Width - (2 * NoInternetConnectionSandBox.from_the_edge),
                    (2 * NoInternetConnectionSandBox.from_the_edge));

                this.DiamondResIconLabel.Location =
                    new Point(this.TimeIconLabel.Location.X - this.DiamondResIconLabel.Width -
                    (5 * NoInternetConnectionSandBox.from_the_edge), this.TimeIconLabel.Location.Y);
                this.CouponResIconLabel.Location =
                    new Point(this.DiamondResIconLabel.Location.X - this.CouponResIconLabel.Width -
                    (4 * NoInternetConnectionSandBox.from_the_edge),
                    this.DiamondResIconLabel.Location.Y);
                this.CoinResIconLabel.Location =
                    new Point(this.CouponResIconLabel.Location.X - this.CoinResIconLabel.Width -
                    (4 * NoInternetConnectionSandBox.from_the_edge),
                    this.CouponResIconLabel.Location.Y);
                this.ManaResIconLabel.Location =
                    new Point(this.CoinResIconLabel.Location.X - this.ManaResIconLabel.Width -
                    (4 * NoInternetConnectionSandBox.from_the_edge),
                    this.CoinResIconLabel.Location.Y);
                //Rectangle:
                this.TimeIconLabel.SetStringRectangle(true);
                //Colors:
                this.SetColorTransparent();
                this.PlayerNameLabelControl.SetColorTransparent();
                this.PlayerLvlLabelControl.SetColorTransparent();
                this.PlayerNameLabelControl.SetTextColor(Color.Black);
                this.PlayerLvlLabelControl.SetTextColor(Color.Black);
                this.ExpThumbIconLabel.SetTextColor(Color.GhostWhite);
                this.TimeIconLabel.SetTextColor(Color.Black);
                //ComboBoxes:
                //Enableds:
                //Texts:
                this.PlayerNameLabelControl.SetLabelText(ThereIsServer.GameObjects.MyProfile.PlayerName.GetValue());
                this.PlayerLvlLabelControl.SetLabelText(ThereIsServer.GameObjects.MyProfile.PlayerLevel.ToString());
                this.ExpThumbIconLabel.SetLabelText(
                    ThereIsServer.GameObjects.MyProfile.PlayerCurrentExp.ToString() + 
                    " / " +
                    ThereIsServer.GameObjects.MyProfile.GetNeededExpForNextLvl());
                this.TimeIconLabel.SetLabelText(
                    ThereIsConstants.AppSettings.GlobalTiming.GetString(true).GetValue());
                //AddRanges:
                //ToolTipSettings:
                //ImageSettings:
                //-----------------------------------------
                //Events:
                this.GameTimeTrigger.Tick += GameTimeTrigger_Tick;
                //-----------------------------------------
                this.ExpTrackIconLabel.Controls.Add(this.ExpThumbIconLabel);
                this.Profile_NavIconLabel.Controls.AddRange(new Control[]
                {
                    this.AvatarIconLabel,
                    this.PlayerNameLabelControl,
                    this.PlayerLvlLabelControl,
                    this.ExpTrackIconLabel,
                });
                this.Controls.Add(this.Profile_NavIconLabel);
                this.Father.Controls.AddRange(new Control[]
                {
                    this.TimeIconLabel,
                    this.DiamondResIconLabel,
                    this.CouponResIconLabel,
                    this.CoinResIconLabel,
                    this.ManaResIconLabel,
                });
                //-----------------------------------------
                this.ResumeLayout();
                this.GameTimeTrigger.Start();
            }

            private void GameTimeTrigger_Tick(object sender, System.EventArgs e)
            {
                this.TimeIconLabel.SetLabelText(
                    ThereIsConstants.AppSettings.GlobalTiming.GetString(true).GetValue());
                this.TimeIconLabel.Refresh();
            }

            #endregion
            //---------------------------------------------
        }
    }
}