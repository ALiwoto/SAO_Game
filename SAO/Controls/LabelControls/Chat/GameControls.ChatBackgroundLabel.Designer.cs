// Copyright (C) ALiwoto 2019 - 2020
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of the source code.

using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;
using WotoProvider.EventHandlers;
using SAO.SandBox;
using SAO.Security;
using SAO.GameObjects.Math;
using SAO.GameObjects.Chatting;
using SAO.GameObjects.ServerObjects;
using SAO.Controls.Elements.ChatElements;

namespace SAO.Controls
{
    partial class GameControls
    {
        partial class ChatBackgroundLabel
        {
            //---------------------------------------------
            #region Initialize Region
            private void InitializeComponent()
            {
                this.Size =
                    new Size(12 * ((((this.BackLabel.Width) -
                    (this.BackLabel.Width / 8)) - 
                    NoInternetConnectionSandBox.from_the_edge) / 12), 
                    this.BackLabel.Height - 
                    (this.BackLabel.Height / 10) -
                    (2 * NoInternetConnectionSandBox.from_the_edge));
                this.Location = new Point((this.BackLabel.Width / 8) +
                    (NoInternetConnectionSandBox.from_the_edge / 2),
                    NoInternetConnectionSandBox.from_the_edge);
                //---------------------------------------------
                //---------------------------------------------
                //News:
                this.ReloadUPW();
                this.PaintColors = new Color[]
                {
                    Color.FromArgb(180, Color.Black),
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


                //Locations:

                //Colors:
                this.SetColorTransparent();
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

            private void GeneralChilds_Click(object sender, System.EventArgs e)
            {
                if (sender is ChatBarLabel chatBar)
                {
                    this.BackLabel.GeneralChatBar.ChangeChildSelection(chatBar);
                }
                this.CurrentChatManager = this.BackLabel.GeneralChatBar.GetChatManager();
                this.UpdateChatMessageDesign(false, true);
            }

            private void MyChatBars_Click(object sender, System.EventArgs e)
            {
                if (sender is ChatBarLabel chatBar)
                {
                    if (this.ActiveChatBar == chatBar)
                    {
                        return;
                    }
                    this.ActiveChatBar.UnSelectMe();
                    this.ActiveChatBar = chatBar;
                    this.CurrentChatManager = this.ActiveChatBar.GetChatManager();
                    this.ActiveChatBar.SelectMe();
                    if (!this.IsShowingGeneral)
                    {
                        if (this.ActiveChatBar.IsGeneral)
                        {
                            this.ShowGeneral();
                            this.UpdateChatMessageDesign(false, true);
                            return;
                        }
                    }
                    else
                    {
                        // this condition is absolutly true,
                        // I added it just in case.
                        if (!this.ActiveChatBar.IsGeneral)
                        {
                            this.UnShowGeneral();
                        }
                    }
                    this.UpdateChatMessageDesign();
                }
            }

            public override void ReloadUPW()
            {

                this.UnlimitedPointWorks = new Point[]
                {
                    new Point(0, 0), // 1
                    new Point(Width / 2, 0), // 2
                    new Point(Width, 0), // 3
                    new Point(Width, Height), // 4
                    new Point(Width - (Width / 12), Height), // 5
                    new Point(Width - (Width / 12) -
                        NoInternetConnectionSandBox.from_the_edge, Height), // 6
                    new Point(Width / 2, Height), // 7
                    new Point(NoInternetConnectionSandBox.from_the_edge, Height), // 8
                    new Point(0, Height), // 9
                };
            }
            private void UpdateChatMessageDesign(in bool afterUpdate = false, in bool byForce = false)
            {
                if (this.CurrentChatManager is null)
                {
                    this.DisposeAllChatElements();
                    this.BackLabel.InputControl.ChatBoxControl.Text =
                        "this channel is not available yet.";
                    this.BackLabel.InputControl.ChatBoxControl.Enabled = false;
                    this.Refresh();
                    return;
                }
                else
                {
                    if (!this.BackLabel.InputControl.ChatBoxControl.Enabled)
                    {
                        this.BackLabel.InputControl.ChatBoxControl.Enabled = true;
                        this.BackLabel.InputControl.ChatBoxControl.Text = 
                            string.Empty;
                    }
                }
                if (CheckEquality())
                {
                    if (!byForce)
                    {
                        return;
                    }
                }
                if (afterUpdate && this.ChatElements.Length != 0)
                {
                    if (this.CurrentChatManager.ChatMessages.Length == 0)
                    {
                        this.UpdateElements(true);
                        return;
                    }
                    ChatElement[] oldElements = this.ChatElements;
                    this.ChatElements =
                        new ChatElement[this.CurrentChatManager.ChatMessages.Length];
                    for (int i = 0; i < this.ChatElements.Length; i++)
                    {
                        this.ChatElements[i] =
                            ChatElement.GenerateChatElement(this, this,
                            this.CurrentChatManager.ChatMessages[i]);
                    }
                    int inEqualityInt = GetEqualityInt(oldElements);
                    ChatElement finalElement;
                    if (inEqualityInt - 1 >= oldElements.Length)
                    {
                        finalElement = oldElements[inEqualityInt - 2];
                    }
                    else if (inEqualityInt <= 0)
                    {
                        finalElement = oldElements[inEqualityInt];
                    }
                    else
                    {
                        finalElement = oldElements[inEqualityInt - 1];
                    }
                    float myY = finalElement.StartPointF.Y;
                    if (myY > this.Height)
                    {
                        this.ChatElements[inEqualityInt].SetStartPoint(
                            new PointF(From_the_edge, finalElement.StartPointF.Y +
                            finalElement.GetTotalHeight() +
                         BetweenElements));
                        this.SetAnotherStarPoint(inEqualityInt, oldElements);
                        this.UpdateElements(true);
                    }
                    else
                    {
                        this.ChatElements[this.ChatElements.Length - 1].SetStartPoint(
                            new PointF(From_the_edge, this.Height -
                             this.ChatElements[this.ChatElements.Length - 1].GetTotalHeight() -
                             BetweenElements));
                        this.SetAnotherStarPoint();
                        this.UpdateElements(true);
                    }
                }
                else
                {
                    this.ChatElements =
                        new ChatElement[this.CurrentChatManager.ChatMessages.Length];
                    for (int i = 0; i < this.ChatElements.Length; i++)
                    {
                        this.ChatElements[i] =
                            ChatElement.GenerateChatElement(this, this,
                            this.CurrentChatManager.ChatMessages[i]);
                    }
                    if (this.CurrentChatManager.ChatMessages.Length == 0)
                    {
                        this.UpdateElements(true);
                        return;
                    }

                    this.ChatElements[this.ChatElements.Length - 1].SetStartPoint(
                        new PointF(From_the_edge, this.Height -
                         this.ChatElements[this.ChatElements.Length - 1].GetTotalHeight() -
                         BetweenElements));
                    this.SetAnotherStarPoint();
                    this.UpdateElements(true);
                }
                
            }
            private void UpdateChatMessageDesign(in MessageList theNewList)
            {

            }
            /// <summary>
            /// set the start point of the elements compared to the last 
            /// element's Start point.
            /// </summary>
            private void SetAnotherStarPoint()
            {
                for (int i = this.ChatElements.Length - 2; i >= 0; i--)
                {
                    this.ChatElements[i].SetStartPoint(
                        this.ChatElements[i + 1].StartPointF.X,
                        this.ChatElements[i + 1].StartPointF.Y -
                        this.ChatElements[i].GetTotalHeight() - BetweenElements);
                }
            }
            private void SetAnotherStarPoint(in int inEquality, ChatElement[] oldElements)
            {
                for (int i = 0; i < inEquality; i++)
                {
                    this.ChatElements[i].SetStartPoint(oldElements[i].StartPointF);
                }
                for (int i = inEquality + 1; i < this.ChatElements.Length; i++)
                {
                    this.ChatElements[i].SetStartPoint(
                        this.ChatElements[i - 1].StartPointF.X,
                        this.ChatElements[i - 1].StartPointF.Y +
                        this.ChatElements[i - 1].GetTotalHeight() + BetweenElements);
                }
            }
            private void UpdateElements(in bool disposeThem = false)
            {
                if (disposeThem)
                {
                    this.MouseDown -= Shocker;
                    this.MouseUp -= Discharge;
                    this.DisposeAllChatElements();
                    if (this.ChatElements != null)
                    {
                        for (int i = 0; i < this.ChatElements.Length; i++)
                        {
                            this.ChatElements[i].Apply();
                        }
                        this.AppliedChatElements = this.ChatElements;
                    }
                    this.MouseDown += Shocker;
                    this.MouseUp += Discharge;
                }
                
                this.Refresh();
            }
            private void DisposeAllChatElements()
            {
                if (this.AppliedChatElements != null)
                {
                    for (int i = 0; i < AppliedChatElements.Length; i++)
                    {
                        this.AppliedChatElements[i].Dispose();
                    }
                }
            }
            private void ShowGeneral()
            {
                if (this.IsShowingGeneral)
                {
                    return;
                }
                this.IsShowingGeneral = true;
                this.Controls.Add(this.BackLabel.KingdomChatBar);
                this.Controls.Add(this.BackLabel.GuildChatBar);
            }
            private void UnShowGeneral()
            {
                if (!this.IsShowingGeneral)
                {
                    return;
                }
                this.IsShowingGeneral = false;
                this.Controls.Remove(this.BackLabel.KingdomChatBar);
                this.Controls.Remove(this.BackLabel.GuildChatBar);
            }
            /// <summary>
            /// checking equality of the <see cref="CurrentChatManager"/>
            /// messages with the <see cref="ChatElements"/> messages.
            /// </summary>
            /// <returns></returns>
            private bool CheckEquality()
            {
                if (CurrentChatManager is null || ChatElements is null)
                {
                    return false;
                }
                if (CurrentChatManager.ChatMessages.Length != ChatElements.Length)
                {
                    return false;
                }
                for (int i = 0; i < CurrentChatManager.ChatMessages.Length; i++)
                {
                    if (this.ChatElements[i].Message != this.CurrentChatManager.ChatMessages[i])
                    {
                        return false;
                    }
                }
                return true;
            }
            private bool CheckEqualityByPass(in ChatElement[] elements)
            {
                if (CurrentChatManager is null || elements is null)
                {
                    return false;
                }
                if (CurrentChatManager.ChatMessages.Length != elements.Length)
                {
                    return false;
                }
                for (int i = 0; i < CurrentChatManager.ChatMessages.Length; i++)
                {
                    if (elements[i].Message != this.CurrentChatManager.ChatMessages[i])
                    {
                        return false;
                    }
                }
                return true;
            }
            private int GetEqualityInt(in ChatElement[] elements)
            {
                if (CurrentChatManager is null || ChatElements is null)
                {
                    return -1;
                }
                if (CheckEqualityByPass(elements))
                {
                    return CurrentChatManager.ChatMessages.Length - 1;
                }
                bool lastIntSetted = false;
                int lastInt = 0;
                for (int i = CurrentChatManager.ChatMessages.Length - 1; i > 0 ; i--)
                {
                    if (i >= elements.Length)
                    {
                        return i - 1;
                    }
                    if (elements[i].Message != this.CurrentChatManager.ChatMessages[i])
                    {
                        lastInt = i;
                        if (!lastIntSetted)
                        {
                            lastIntSetted = true;
                        }
                        continue;
                    }
                    else
                    {
                        if (lastIntSetted)
                        {
                            return lastInt;
                        }
                    }
                }
                return elements.Length - 1;
            }
            #endregion
            //---------------------------------------------
            #region Online Method's Region
            public void LoadAllChannels()
            {
                this.IsLoadingChannels = true;
                this.IsChannelsLoaded = false;
                //-----------------------------------------
                Trigger crossChatTrigger = new Trigger(true);
                crossChatTrigger.Tick += CrossChatTrigger_Tick;
                crossChatTrigger.Start();
                //-----------------------------------------
                Trigger kingdomChatTrigger = new Trigger(true);
                kingdomChatTrigger.Tick += KingdomChatTrigger_Tick;
                kingdomChatTrigger.Start();
                //-----------------------------------------
                Trigger channelsChecker = new Trigger()
                {
                    Interval = 1000,
                    Enabled = false,
                };
                channelsChecker.Tick += ChannelsChecker_Tick;
                channelsChecker.Start();
                //-----------------------------------------
                return;
            }

            private void ChannelsChecker_Tick(Trigger sender, TickHandlerEventArgs<Trigger> handler)
            {
                if (!IsChannelsLoaded)
                {
                    return;
                }
                this.IsLoadingChannels = false;
                this.UpdateChatMessageDesign();
                sender.Stop();
                sender.Dispose();
                //-----------------------------------------
                this.BackLabel.GeneralChatBar.SetChildsChatBar(
                    this.BackLabel.KingdomChatBar,
                    this.BackLabel.GuildChatBar);
                this.ActiveChatBar = this.BackLabel.GeneralChatBar;
                this.BackLabel.KingdomChatBar.Click += GeneralChilds_Click;
                this.BackLabel.GuildChatBar.Click += GeneralChilds_Click;
                this.BackLabel.GeneralChatBar.Click += MyChatBars_Click;
                this.BackLabel.CrossChatBar.Click += MyChatBars_Click;
                this.BackLabel.SystemChatBar.Click += MyChatBars_Click;
                //-----------------------------------------
                this.CrossChatManager.KeepAlive();
                this.KingdomChatManager.KeepAlive();
            }

            private async void KingdomChatTrigger_Tick(Trigger sender, TickHandlerEventArgs<Trigger> handler)
            {
                this.CurrentChatManager = this.KingdomChatManager =
                    await ChatManager.GetChatManager(
                        ThereIsServer.GameObjects.MyProfile.KingdomInfo.GetKingdomChannel(), this);
                this.CurrentChatManager.Updated -= CurrentChatManager_Updated;
                this.CurrentChatManager.Updated += CurrentChatManager_Updated;
                // this.BackLabel.KingdomChatBar.SelectMe(); already selected in the
                // chatlabel.
                this.BackLabel.KingdomChatBar.SetChatManager(this.KingdomChatManager);
                this.ActiveChatBar = this.BackLabel.KingdomChatBar;
                this.IsShowingGeneral = true;
                this.IsKingdomChannelLoaded = true;
                
            }

            private void CurrentChatManager_Updated(ChatManager manager, ChatBackgroundLabel chatBackground)
            {
                this.UpdateChatMessageDesign(true);
            }

            private async void CrossChatTrigger_Tick(Trigger sender, TickHandlerEventArgs<Trigger> handler)
            {
                this.CrossChatManager =
                    await ChatManager.GetChatManager(ChatChannels.Cross_Chat, this);
                this.BackLabel.CrossChatBar.SetChatManager(this.CrossChatManager);
                IsCrossChannelLoaded = true;
            }

            public async Task<bool> SendMessage(StrongString message)
            {
                await this.CurrentChatManager.SendMessage(
                    ChatMessage.GenerateChatMessage(ThereIsServer.GameObjects.MyProfile,
                    message));
                this.UpdateChatMessageDesign();
                return true;
            }
            #endregion
            //---------------------------------------------
            #region Element Moving Region
            public void Shocker(object sender, MouseEventArgs e)
            {
                if (this.CurrentChatManager is null)
                {
                    return;
                }
                if (Movements != ElementMovements.NoMovements)
                {
                    this.LastPoint = e.Location;
                    this.MouseMove -= MoveMe;
                    this.MouseMove += MoveMe;
                }
            }
            public void MoveMe(object sender, MouseEventArgs e)
            {
                
                
                switch (Movements)
                {
                    case ElementMovements.NoMovements:
                        break;
                    case ElementMovements.VerticalMovements:
                        {
                            float divergeY = e.Y - LastPoint.Y;
                            if (Unit.Abs(divergeY) < MoveLimitationRate)
                            {
                                return;
                            }
                            ChatElement currentElement = 
                                this.ChatElements[this.ChatElements.Length - 1];
                            if (currentElement.StartPointF.Y + divergeY < 
                                this.Height - currentElement.GetTotalHeight() - 
                                BetweenElements)
                            {
                                return;
                            }
                            currentElement.SetStartPoint(
                                new PointF(currentElement.StartPointF.X, 
                                currentElement.StartPointF.Y + 
                                divergeY));
                            this.LastPoint = e.Location;
                            this.SetAnotherStarPoint();
                            this.UpdateElements();
                            break;
                        }
                    case ElementMovements.HorizontalMovements:
                        break;
                    case ElementMovements.VerticalHorizontalMovements:
                        break;
                    default:
                        break;
                }
            }
            public void MoveMe(int divergeX, int divergeY)
            {
                
            }
            public void Discharge(object sender, MouseEventArgs e)
            {
                this.MouseMove -= MoveMe;
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