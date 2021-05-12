// Copyright (C) ALiwoto 2019 - 2020
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of the source code.

using System.Windows.Forms;
using System.Drawing;
using SAO.Client;
using SAO.SandBox;
using SAO.Constants;
using SAO.Security;
using SAO.GameObjects.Chatting;
using SAO.Controls.Assets.Icons;
using SAO.GameObjects.ServerObjects;

namespace SAO.Controls
{
    partial class GameControls
    {
        partial class ChatLabelControl
        {
            //---------------------------------------------
            #region Initialize Region
            private void InitializeComponent()
            {
                this.Size = new Size(this.Father.Width / 3, this.Father.Height);
                //---------------------------------------------
                //---------------------------------------------
                //News:
                this.FlashIconLabel = new IconLabelControl(this,
                    GameIcon.GenerateIcon(Chat_Icons.s_chat_btn_zoom));
                this.ChatIconLabel = new IconLabelControl(this,
                    GameIcon.GenerateIcon(Main_Icons.s_main_anx_chat));
                this.ChatBackgroundLabel = 
                    new ChatBackgroundLabel(this, this.Father, this);
                this.SystemChatBar = new ChatBarLabel(this, this,
                    ChatChannels.System_Chat);
                this.CrossChatBar = new ChatBarLabel(this, this,
                    ChatChannels.Cross_Chat);
                this.GeneralChatBar = new ChatBarLabel(this, this, true);
                this.KingdomChatBar = new ChatBarLabel(this,
                    this.ChatBackgroundLabel,
                    ThereIsServer.GameObjects.MyProfile.KingdomInfo.GetKingdomChannel(),
                    true);
                this.GuildChatBar = new ChatBarLabel(this,
                    this.ChatBackgroundLabel, ChatChannels.Guild_Chat);
                this.InputControl = new ChatInputControl(this, this);
                this.ReloadUPW();
                this.PaintColors = new Color[]
                {
                    Color.FromArgb(190, Color.DarkGray),
                };
                this.PaintBrushes = new Brush[]
                {
                    new SolidBrush(this.PaintColors[0]),
                };
                //---------------------------------------------
                //Names:
                //TabIndexes
                //FontAndTextAligns:
                //Sizes:
                this.FlashIconLabel.SetIconSize();
                this.ChatIconLabel.SetIconSize();
                this.ChatIconLabel.Size =
                    Size.Round(this.ChatIconLabel.IconSizeF);
                this.FlashIconLabel.Size =
                    Size.Round(this.FlashIconLabel.IconSizeF);
                
                //Locations:
                this.FlashIconLabel.SetIconLocation();
                this.ChatIconLabel.SetIconLocation();

                this.FlashIconLabel.Location =
                    new Point(this.Location.X + this.Width,
                    this.Location.Y + (this.Height / 2) -
                    (this.FlashIconLabel.Height / 2));
                this.ChatIconLabel.Location =
                    new Point(
                        (2 * NoInternetConnectionSandBox.from_the_edge),
                        ((this.BackLabel.UnlimitedPointWorks[3].Y -
                        this.BackLabel.UnlimitedPointWorks[2].Y) / 2) -
                        (this.ChatIconLabel.Height / 2));
                this.SystemChatBar.Location =
                    new Point(NoInternetConnectionSandBox.from_the_edge / 2, 
                    NoInternetConnectionSandBox.from_the_edge);
                this.CrossChatBar.Location =
                    new Point(this.SystemChatBar.Location.X,
                    this.SystemChatBar.Location.Y + 
                    this.SystemChatBar.Height + 
                    (NoInternetConnectionSandBox.from_the_edge / 2));
                this.GeneralChatBar.Location =
                    new Point(this.CrossChatBar.Location.X,
                    this.CrossChatBar.Location.Y +
                    this.CrossChatBar.Height +
                    (NoInternetConnectionSandBox.from_the_edge / 2));
                this.KingdomChatBar.Location =
                    new Point(NoInternetConnectionSandBox.from_the_edge, 0);
                this.GuildChatBar.Location =
                    new Point(KingdomChatBar.Location.X +
                    KingdomChatBar.Width, 0);
                //Colors:
                this.SetColorTransparent();
                //ComboBoxes:
                //Enableds:
                this.FlashIconLabel.SingleClick = true;
                this.ChatIconLabel.SingleClick  = true;
                //Texts:
                //AddRanges:
                //ToolTipSettings:
                //GraphicWorks:
                //Effects:
                //---------------------------------------------
                //Events:
                this.ChatIconLabel.Click += ChatIconLabel_Click;
                this.FlashIconLabel.Click += FlashIconLabel_Click;
                this.InputControl.SendLabelControl.Click += SendLabelControl_Click;
                //---------------------------------------------
                // AddRanges:
                this.Controls.AddRange(
                    this.ChatBackgroundLabel,
                    this.InputControl,
                    this.SystemChatBar,
                    this.CrossChatBar,
                    this.GeneralChatBar
                );
                this.ChatBackgroundLabel.Controls.AddRange(
                    this.KingdomChatBar,
                    this.GuildChatBar
                );
                //---------------------------------------------
                //Final Blows:
                this.LoadAllChannels();
            }
            private async void SendLabelControl_Click(object sender, System.EventArgs e)
            {
                if (!this.InputControl.ChatBoxControl.Enabled ||
                    this.InputControl.ChatBoxControl.Text.Length == 0)
                {
                    return;
                }
                StrongString str =
                    this.InputControl.ChatBoxControl.Text;
                // make sure that the context of the message, has more than 2 chars.
                // if the chatbox control is not enabled, then it means this channel
                // is not available yet, so you should not send the message.
                if (this.InputControl.ChatBoxControl.Text.Length < MINIMUM_LENGTH)
                {
                    str = str.Append(INSIDER, MINIMUM_LENGTH -
                        this.InputControl.ChatBoxControl.Text.Length + 1);
                }
                this.InputControl.SendLabelControl.Enabled = false;
                this.InputControl.ChatBoxControl.Clear();
               await this.ChatBackgroundLabel.SendMessage(str);
                this.InputControl.SendLabelControl.Enabled = true;
                this.InputControl.SendLabelControl.HasMouseClickedOnce = false;
            }
            private void FlashIconLabel_Click(object sender, System.EventArgs e)
            {
                this.RemoveChatFrame();
                this.FlashIconLabel.HasMouseClickedOnce = false;
            }
            private void ChatIconLabel_Click(object sender, System.EventArgs e)
            {
                this.ApplyChatFrame();
                this.ChatIconLabel.HasMouseClickedOnce = false;
            }
            public override void ReloadUPW()
            {
                
                this.UnlimitedPointWorks = new Point[]
                {
                    new Point(0, 0),    // 1
                    new Point(Width / 8, 0), // 2
                    new Point(Width, 0), // 3
                    new Point(Width, Height), // 4
                    new Point(Width / 8, Height), // 5
                    new Point(0, Height), // 6
                };
                
            }
            #endregion
            //---------------------------------------------
            #region Public Appling Method Region
            /// <summary>
            /// Apply and add the chat opening flasher to the
            /// <see cref="GameClient"/>.
            /// please don't use this method directly,
            /// instead use this method: <see cref="ApplyChatFrame()"/>.
            /// </summary>
            public void ApplyFlasher()
            {
                this.Father.Controls.Add(this.FlashIconLabel);
                this.FlashIconLabel.BringToFront();
            }
            /// <summary>
            /// Apply the Flasher,
            /// which player can close the flasher with it.
            /// you can use it when and only when 
            /// you have generated the chatLabelControl in the
            /// <see cref="GameClient.DesignForHome(bool)"/>.
            /// please don't use this method anymore.
            /// <!--
            ///     *** By ALi.w, 
            ///     *** SAO project: 2020 - 21
            ///     *** this describe has been writen in:
            ///     *** 2021 / 1 / 5 , Tue
            ///     *** ****************************
            /// -->
            /// </summary>
            public void ApplyChatIcon()
            {
                this.BackLabel.Controls.Add(this.ChatIconLabel);
                this.ChatIconLabel.BringToFront();
                this.BackLabel.Update();
            }
            /// <summary>
            /// Applying the chat label to the
            /// <see cref="GameClient"/>, 
            /// also please consider changing the appearnce of the 
            /// <see cref="FlashIconLabel"/>
            /// </summary>
            public void ApplyChatFrame()
            {
                if (this.IsChatFrameApplied)
                {
                    return;
                }
                this.SuspendLayout();
                this.InputControl.Controls.Add(this.InputControl.ChatBoxControl);
                this.Father.Controls.Add(this);
                this.BringToFront();
                this.InputControl.BringToFront();
                this.ResumeLayout();
                this.ApplyFlasher();
                this.IsChatFrameApplied = true;
            }
            /// <summary>
            /// please don't use this method directly,
            /// out of this class.
            /// instead use <see cref="RemoveChatFrame()"/>.
            /// </summary>
            public void RemoveFlasher()
            {
                this.Father.Controls.Remove(this.FlashIconLabel);
            }
            /// <summary>
            /// please don't use this mehod directly.
            /// use this method instead: <see cref="RemoveChatFrame()"/>.
            /// </summary>
            public void RemoveChatIcon()
            {
                this.Father.Controls.Remove(this.ChatIconLabel);
            }
            /// <summary>
            /// Please use this method in public.
            /// </summary>
            public void RemoveChatFrame()
            {
                if (!IsChatFrameApplied)
                {
                    return;
                }
                this.InputControl.Controls.Remove(this.InputControl.ChatBoxControl);
                //this.Controls.Remove(this.ChatBackgroundLabel);
                //this.Controls.Remove(this.InputControl);
                this.Father.Controls.Remove(this);
                this.RemoveFlasher();
                this.IsChatFrameApplied = false;
            }
            #endregion
            //---------------------------------------------
            #region Online Method's Region
            public void LoadAllChannels()
            {
                this.ChatBackgroundLabel.LoadAllChannels();
            }
            #endregion
            //---------------------------------------------
            #region protected override Methods Region
            protected override void OnPaint(PaintEventArgs e)
            {
                e.Graphics.FillPolygon(this.PaintBrushes[0], this.UnlimitedPointWorks);
                base.OnPaint(e);
            }
            #endregion
            //---------------------------------------------

        }
    }
}
