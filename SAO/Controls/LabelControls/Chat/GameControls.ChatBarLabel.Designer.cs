// Copyright (C) ALiwoto 2019 - 2020
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of the source code.

using System.Drawing;
using System.Windows.Forms;
using SAO.SandBox;
using SAO.Constants;
using SAO.GameObjects.Chatting;
using SAO.Controls.Assets.Icons;

namespace SAO.Controls
{
    partial class GameControls
    {
        partial class ChatBarLabel
        {
            //---------------------------------------------
            #region Initialize Region
            private void InitializeBarComponent()
            {
                this.Size =
                    new Size((this.ChatLabel.Width / 8),
                    (this.ChatLabel.Width / 12));
                //---------------------------------------------
                //---------------------------------------------
                //News:
                this.UnlimitedPointWorks = new Point[]
                {
                    new Point(0, 0), // 1
                    new Point(Width, 0), // 2
                    new Point(Width, Height), // 3
                    new Point(0, Height), // 4
                };
                this.ReloadPaints();
                //---------------------------------------------
                //Names:
                this.SetLabelName(!IsGeneral ? Channel.ToString() : 
                    GeneralLabelNameInRes);
                //TabIndexes
                //FontAndTextAligns:
                this.Font =
                    new Font(ThereIsConstants.Forming.TheMainForm.PrivateFonts.Families[1],
                    12.4f, FontStyle.Bold);
                this.TextAlign = ContentAlignment.MiddleCenter;
                //Sizes:


                //Locations:


                //Colors:
                this.SetColorTransparent();
                //this.SetTextColor(!IsSelected ? Color.Black : Color.FloralWhite);
                this.SetLabelText();
                this.SetLabelSoundEffects(Noises.ClickNoise);
                //ComboBoxes:
                //Enableds:
                //Texts:
                //AddRanges:
                //ToolTipSettings:
                //GraphicWorks:
                //Effects:
                //---------------------------------------------
                //Events:
                //---------------------------------------------

                //---------------------------------------------
                //Final Blows:
            }
            private void ReloadPaints()
            {
                this.PaintColors = new Color[]
                {
                    Color.FromArgb(180, IsSelected ? Color.Black : Color.FloralWhite),
                };
                this.PaintBrushes = new Brush[]
                {
                    new SolidBrush(this.PaintColors[0]),
                };
                this.SetTextColor(!IsSelected ? Color.Black : Color.FloralWhite);
            }
            protected override void OnPaint(PaintEventArgs e)
            {
                if (GoldenIcon != null)
                {
                    this.SetColorTransparent();
                    Graphics graphics = e.Graphics;
                    graphics.DrawImage(GoldenIcon.OriginalImage,
                        new Rectangle(0, 0, this.Width,
                        this.Height),
                        new Rectangle(0, 0, this.GoldenIcon.OriginalImage.Width,
                        this.GoldenIcon.OriginalImage.Height), GraphicsUnit.Pixel);
                    base.OnPaint(e);
                    return;
                }
                e.Graphics.FillPolygon(this.PaintBrushes[0], this.UnlimitedPointWorks);
                base.OnPaint(e);
            }
            private void InitializeGeneralComponent()
            {
                this.Size =
                    new Size((this.ChatBackground.Width - 
                    (2 * NoInternetConnectionSandBox.from_the_edge)) / 2,
                    (this.ChatBackground.Width / 10));
                this.GoldenIcon = GameIcon.GenerateFakeIcon(FakeIcons.s_golden_btn_chat);
                //this.ImageAlign = ContentAlignment.MiddleCenter;
                //---------------------------------------------
                //---------------------------------------------
                //News:
                this.UnlimitedPointWorks = new Point[]
                {
                    new Point(0, 0), // 1
                    new Point(Width, 0), // 2
                    new Point(Width, Height), // 3
                    new Point(0, Height), // 4
                };
                this.PaintColors = new Color[]
                {
                    Color.Transparent,
                };
                this.PaintBrushes = new Brush[]
                {
                    new SolidBrush(this.PaintColors[0]),
                };
                //---------------------------------------------
                //Names:
                this.SetLabelName(Channel.ToString());
                //TabIndexes
                //FontAndTextAligns:
                this.Font =
                    new Font(ThereIsConstants.Forming.TheMainForm.PrivateFonts.Families[1],
                    13.4f, FontStyle.Bold);
                this.TextAlign = ContentAlignment.MiddleCenter;
                //Sizes:


                //Locations:


                //Colors:
                this.SetColorTransparent();
                this.SetTextColor(Color.Black);
                this.SetLabelText();
                this.SetLabelSoundEffects(Noises.ClickNoise);
                //ComboBoxes:
                //Enableds:
                //Texts:
                //AddRanges:
                //ToolTipSettings:
                //GraphicWorks:
                //Effects:
                //---------------------------------------------
                //Events:
                //---------------------------------------------

                //---------------------------------------------
                //Final Blows:
            }
            #endregion
            //---------------------------------------------
            #region Get Method's Region
            /// <summary>
            /// Get <see cref="ChatBarLabel.MyChatManager"/> of this
            /// Chat bar.
            /// </summary>
            /// <returns></returns>
            public ChatManager GetChatManager()
            {
                // check if this chat bar is a general mode chat bar or not.
                if (IsGeneral)
                {
                    // it means this chat bar is a general mode chat bar
                    // and should return it's child manager.
                    if (this.KingdomChatBar != null && this.GuildChatBar != null)
                    {
                        if (this.KingdomChatBar.IsSelected)
                        {
                            return this.KingdomChatBar.MyChatManager;
                        }
                        else
                        {
                            return this.GuildChatBar.MyChatManager;
                        }
                    }
                    return null;
                }
                else
                {
                    return this.MyChatManager;
                }
            }
            #endregion
            //---------------------------------------------
            #region Set Method's Region
            public void SetChatManager(ChatManager manager)
            {
                // check if this chat bar is a general mode chat bar or not.
                if (IsGeneral)
                {
                    // it means this chat bar is a general mode chat bar
                    // and should return it's child manager.
                    if (this.KingdomChatBar != null && this.GuildChatBar != null)
                    {
                        if (this.KingdomChatBar.IsSelected)
                        {
                            this.KingdomChatBar.MyChatManager = manager; ;
                        }
                        else
                        {
                            this.GuildChatBar.MyChatManager = manager;
                        }
                    }
                    return;
                }
                else
                {
                    this.MyChatManager = manager;
                }
            }
            public void SetChildsChatBar(ChatBarLabel kingdomChatBar, 
                ChatBarLabel guildChatBar)
            {
                this.KingdomChatBar = kingdomChatBar;
                this.GuildChatBar   = guildChatBar;
            }
            public void ChangeChildSelection(ChatBarLabel clickedChatBar)
            {
                if (this.IsGeneral)
                {
                    if (this.KingdomChatBar != null && this.GuildChatBar != null)
                    {
                        if (this.KingdomChatBar.IsSelected)
                        {
                            if (clickedChatBar == this.KingdomChatBar)
                            {
                                return;
                            }
                            this.KingdomChatBar.IsSelected = false;
                            this.GuildChatBar.IsSelected = true;
                        }
                        else
                        {
                            if (clickedChatBar == this.GuildChatBar)
                            {
                                return;
                            }
                            this.KingdomChatBar.IsSelected = true;
                            this.GuildChatBar.IsSelected = false;
                        }
                    }
                }
            }
            public void SelectMe()
            {
                this.IsSelected = true;
                this.ReloadPaints();
                this.Refresh();
            }
            public void UnSelectMe()
            {
                this.IsSelected = false;
                this.ReloadPaints();
                this.Refresh();
            }
            #endregion
            //---------------------------------------------
        }
    }
}