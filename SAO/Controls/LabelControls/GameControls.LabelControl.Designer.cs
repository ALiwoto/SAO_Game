// Copyright (C) ALiwoto 2019 - 2020
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of the source code.

using System;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using SAO.Constants;
using SAO.SandBox;
using SAO.Security;
using SAO.Controls.Music;

namespace SAO.Controls
{
    partial class GameControls
    {
        partial class LabelControl
        {
            
            #region charname region
            private void DesigningForCharacterNameInDialog()
            {

                //------------------------------------------
                //News:
                this.MessageLabel1 = new LabelControl(this);
                //Names:
                //TabIndexes:
                //FontsAndTextAligns:
                this.MessageLabel1.Font = this.Font;
                this.MessageLabel1.TextAlign = ContentAlignment.MiddleCenter;
                //Sizes:
                this.Size = new Size((ThereIsConstants.Forming.GameClient.Width / 9),
                    2 * (ThereIsConstants.Forming.GameClient.Height / 32));
                this.MessageLabel1.Size =
                    new Size(Width - ((1 * (Height / 2)) + (1 * (Height / 2))),
                    this.Height);
                //Locations:
                if(UnlimitedPointWorks == null)
                {
                    UnlimitedPointWorks = new Point[]
                    {
                        new Point(0, 1 * (Height / 2)), // 1
                        new Point(1 * (Height / 2), 0), // 2
                        new Point(Width - (1 * (Height / 2)), 0), // 3
                        new Point(Width, 1 * (Height / 2)), // 4
                        new Point(Width - (1 * (Height / 2)), (1 * (Height / 2)) + (1 * (Height / 2))), // 5
                        new Point(1 * (Height / 2), (1 * (Height / 2)) + (1 * (Height / 2))), // 6
                        new Point(0, (1 * (Height / 2)) + (1 * (Height / 2))), // 7
                        new Point(Width, (1 * (Height / 2)) + (1 * (Height / 2))), // 8
                    };
                }
                this.MessageLabel1.Location = UnlimitedPointWorks[1]; // 2
                //Colors:
                this.MessageLabel1.BackColor =
                this.BackColor = Color.Transparent;
                this.MessageLabel1.ForeColor = Color.Black;
                //ComboBoxes:
                //Enableds:
                this.MessageLabel1.SingleClick = true;
                //Texts:
                this.MessageLabel1.SetLabelText(this.Text);
                //AddRanges:
                //ToolTipSettings:
                //Events:
                this.Paint += CharacterNameLabel_Painting;
                this.TextChanged += CharacterNameChanged;
                this.SizeChanged += CharacterNameLabel_SizeChanged;
                this.FontChanged += CharacterNameLabel_FontChanged;
                //------------------------------------------
                this.Controls.Add(this.MessageLabel1);
                //------------------------------------------
            }

            private void CharacterNameLabel_FontChanged(object sender, EventArgs e)
            {
                this.MessageLabel1.Font = this.Font;
            }

            private void CharacterNameLabel_SizeChanged(object sender, EventArgs e)
            {
                this.MessageLabel1.Size =
                    new Size(Width - ((1 * (Height / 2)) + (1 * (Height / 2))),
                    this.Height);
                UnlimitedPointWorks = new Point[]
                    {
                        new Point(0, 1 * (Height / 2)), // 1
                        new Point(1 * (Height / 2), 0), // 2
                        new Point(Width - (1 * (Height / 2)), 0), // 3
                        new Point(Width, 1 * (Height / 2)), // 4
                        new Point(Width - (1 * (Height / 2)), (1 * (Height / 2)) + (1 * (Height / 2))), // 5
                        new Point(1 * (Height / 2), (1 * (Height / 2)) + (1 * (Height / 2))), // 6
                        new Point(0, (1 * (Height / 2)) + (1 * (Height / 2))), // 7
                        new Point(Width, (1 * (Height / 2)) + (1 * (Height / 2))), // 8
                    };
                GC.Collect();
            }

            private void CharacterNameChanged(object sender, EventArgs e)
            {
                this.Size = new Size((6 * NoInternetConnectionSandBox.from_the_edge) +
                    (int)(Text.Length * Font.Size), this.Height);
                this.MessageLabel1.Text = this.Text;
            }

            private void CharacterNameLabel_Painting(object sender, PaintEventArgs e)
            {
                e.Graphics.FillPolygon(new SolidBrush(Color.WhiteSmoke),
                    new Point[] {
                        UnlimitedPointWorks[0], // 1
                        UnlimitedPointWorks[1], // 2
                        UnlimitedPointWorks[2], // 3
                        UnlimitedPointWorks[3], // 4
                        UnlimitedPointWorks[4], // 5
                        UnlimitedPointWorks[5], // 6

                    });
                e.Graphics.FillPolygon(new SolidBrush(Color.FromArgb(170, Color.Black)),
                    new Point[] {
                        UnlimitedPointWorks[0], // 1
                        UnlimitedPointWorks[6], // 7
                        UnlimitedPointWorks[5], // 6

                    });
                e.Graphics.FillPolygon(new SolidBrush(Color.FromArgb(170, Color.Black)),
                    new Point[] {
                        UnlimitedPointWorks[3], // 4
                        UnlimitedPointWorks[7], // 8
                        UnlimitedPointWorks[4], // 5

                    });
            }
            #endregion
            //-------------------------------------------------
            #region Link Start region
            private void DesigningForLinkStart()
            {

                this.SingleClick = true;
                //------------------------------------------
                //News:
                this.MessageLabel1 = new LabelControl(this);
                this.AnimationFactory = new Trigger()
                {
                    Running_Worker = false,
                };
                //Names:
                //TabIndexes And Numbers :
                this.Rate_of_incline = 0;
                //FontsAndTextAligns:
                this.MessageLabel1.Font = this.Font;
                this.MessageLabel1.TextAlign = ContentAlignment.MiddleCenter;
                //Sizes:
                this.Size = 
                    new Size(
                        6 * ((((CreateProfileSandBox)Father).Width -
                        (2 * CreateProfileSandBox.from_the_edge)) / 6),
                        6 * (((CreateProfileSandBox)Father).Height / 36));
                this.MessageLabel1.Size = this.Size;
                //Locations:
                if (UnlimitedPointWorks == null)
                {
                    UnlimitedPointWorks = new Point[]
                    {
                        new Point(0, 1 * (Height / 6)), // 1
                        new Point(1 * (Width / 3), 1 * (Height / 6)), // 2
                        new Point((1 * (Width / 3)) + (1 * (Height / 6)), 0), // 3
                        new Point((2 * (Width / 3)) - (1 * (Height / 6)), 0), // 4
                        new Point(2 * (Width / 3), 1 * (Height / 6)), // 5
                        new Point(Width, 1 * (Height / 6)), // 6
                        new Point(Width, 5 * (Height / 6)), // 7
                        new Point(2 * (Width / 3), 5 * (Height / 6)), // 8
                        new Point((2 * (Width / 3)) - (1 * (Height / 6)), Height), // 9
                        new Point((1 * (Width / 3)) + (1 * (Height / 6)), Height), // 10
                        new Point(1 * (Width / 3), 5 * (Height / 6)), // 11
                        new Point(0, 5 * (Height / 6)), // 12
                        new Point(0, 1 * (Height / 6)), // 13
                    };
                }

                this.MessageLabel1.Location = new Point((Width / 2) -
                    (this.MessageLabel1.Width / 2), (Height / 2) - (this.MessageLabel1.Height / 2));
                //Colors:
                this.MessageLabel1.BackColor =
                this.BackColor = Color.Transparent;
                this.MessageLabel1.ForeColor = Color.Black;
                //ComboBoxes:
                //Enableds:
                this.MessageLabel1.SingleClick = true;
                //Texts:
                this.MessageLabel1.SetLabelText(this.Text);
                this.MessageLabel1.SetLabelSoundEffects(Noises.ClickNoise);
                //AddRanges:
                //ToolTipSettings:
                //AnimationFactorySettings:
                this.AnimationFactory.Interval = 10;
                //Events:
                this.Tag = false;
                this.AnimationFactory.Tick += AnimationFactoryWorker;
                this.Paint += LinkStartLabel_Painting;
                this.TextChanged += LinkStart_TextChanged;
                this.SizeChanged += LinkStartLabel_SizeChanged;
                this.FontChanged += LinkStartLabel_FontChanged;
                //------------------------------------------
                Controls.Add(this.MessageLabel1);
                //------------------------------------------
                //Final Blow:
                this.AnimationFactory.Enabled = true;
            }

            private void LinkStartLabelControl_MouseLeave(object sender, EventArgs e)
            {
                if (MESoundEffects != Noises.NoNoise)
                {
                    Cursor = Cursors.Default;
                }
            }

            private void LinkStartLabelControl_MouseEnter(object sender, EventArgs e)
            {
                if (MESoundEffects != Noises.NoNoise)
                {
                    Cursor = Cursors.Hand;
                }
            }

            private void LinkStartLabelControl_MouseClick(object sender, EventArgs e)
            {
                if (MESoundEffects != Noises.NoNoise)
                {
                    Task.Run(() =>
                    {
                        SoundPlayer.MakeNoise(MESoundEffects);
                    });
                    //MessageBox.Show("HERE");
                }
            }

            private void LinkStartLabel_FontChanged(object sender, EventArgs e)
            {
                this.MessageLabel1.Font = this.Font;
            }

            private void LinkStartLabel_SizeChanged(object sender, EventArgs e)
            {
                this.MessageLabel1.Size =
                    new Size(2 * (Width / 9), (4 * (Height / 6)));
                this.MessageLabel1.Location = new Point((Width / 2) -
                    (this.MessageLabel1.Width / 2), (Height / 2) - 
                    (this.MessageLabel1.Height / 2));
                UnlimitedPointWorks = new Point[]
                    {
                        new Point(0, 1 * (Height / 6)), // 1
                        new Point(1 * (Width / 3), 1 * (Height / 6)), // 2
                        new Point((1 * (Width / 3)) + (1 * (Height / 6)), 0), // 3
                        new Point((2 * (Width / 3)) - (1 * (Height / 6)), 0), // 4
                        new Point(2 * (Width / 3), 1 * (Height / 6)), // 5
                        new Point(Width, 1 * (Height / 6)), // 6
                        new Point(Width, 5 * (Height / 6)), // 7
                        new Point(2 * (Width / 3), 5 * (Height / 6)), // 8
                        new Point((2 * (Width / 3)) - (1 * (Height / 6)), Height), // 9
                        new Point((1 * (Width / 3)) + (1 * (Height / 6)), Height), // 10
                        new Point(1 * (Width / 3), 5 * (Height / 6)), // 11
                        new Point(0, 5 * (Height / 6)), // 12
                        new Point(0, 5 * (Height / 6)), // 13

                    };
                GC.Collect();
            }

            private void LinkStart_TextChanged(object sender, EventArgs e)
            {
                /*
                this.Size = new Size((6 * NoInternetConnectionSandBox.from_the_edge) +
                    (int)(Text.Length * Font.Size), this.Height);*/
                this.MessageLabel1.Text = this.Text;
            }

            private void LinkStartLabel_Painting(object sender, PaintEventArgs e)
            {
                e.Graphics.FillPolygon(new SolidBrush(Color.FromArgb(200, Color.LightSkyBlue)),
                    new Point[] {
                        UnlimitedPointWorks[0], // 1
                        UnlimitedPointWorks[1], // 2
                        UnlimitedPointWorks[2], // 3
                        UnlimitedPointWorks[3], // 4
                        UnlimitedPointWorks[4], // 5
                        UnlimitedPointWorks[5], // 6
                        UnlimitedPointWorks[6], // 7
                        UnlimitedPointWorks[7], // 8
                        UnlimitedPointWorks[8], // 9
                        UnlimitedPointWorks[9], // 10
                        UnlimitedPointWorks[10], // 11
                        UnlimitedPointWorks[11], // 12

                    });
                e.Graphics.DrawLines(new Pen(Color.FromArgb(200, Color.WhiteSmoke)),
                    new Point[]
                    {
                        UnlimitedPointWorks[0], // 1
                        UnlimitedPointWorks[1], // 2
                        UnlimitedPointWorks[2], // 3
                        UnlimitedPointWorks[3], // 4
                        UnlimitedPointWorks[4], // 5
                        UnlimitedPointWorks[5], // 6

                    });
                e.Graphics.DrawLines(new Pen(Color.FromArgb(200, Color.WhiteSmoke)),
                    new Point[]
                    {
                        UnlimitedPointWorks[6], // 7
                        UnlimitedPointWorks[7], // 8
                        UnlimitedPointWorks[8], // 9
                        UnlimitedPointWorks[9], // 10
                        UnlimitedPointWorks[10], // 11
                        UnlimitedPointWorks[11], // 12

                    });
                //--------------------------------
                e.Graphics.DrawLines(new Pen(Color.FromArgb(170, Color.AliceBlue)),
                    new Point[]
                    {
                        UnlimitedPointWorks[1], // 2
                        UnlimitedPointWorks[2], // 3
                        UnlimitedPointWorks[3], // 4
                        UnlimitedPointWorks[4], // 5

                    });
                e.Graphics.DrawLines(new Pen(Color.FromArgb(60, Color.DarkViolet), 3.6f),
                    new Point[]
                    {
                        UnlimitedPointWorks[7], // 8
                        UnlimitedPointWorks[8], // 9
                        UnlimitedPointWorks[9], // 10
                        UnlimitedPointWorks[10], // 11

                    });
                e.Graphics.DrawLines(new Pen(Color.FromArgb(60, Color.DarkViolet), 3.7f),
                    new Point[]
                    {
                        UnlimitedPointWorks[0], // 1
                        UnlimitedPointWorks[1], // 2

                    });
                e.Graphics.DrawLines(new Pen(Color.FromArgb(60, Color.DarkViolet), 3.7f),
                    new Point[]
                    {
                        UnlimitedPointWorks[4], // 5
                        UnlimitedPointWorks[5], // 6

                    });
                e.Graphics.DrawLines(new Pen(Color.FromArgb(160, Color.AliceBlue), 3.7f),
                    new Point[]
                    {
                        UnlimitedPointWorks[6], // 7
                        UnlimitedPointWorks[7], // 8

                    });
                e.Graphics.DrawLines(new Pen(Color.FromArgb(160, Color.AliceBlue), 3.7f),
                    new Point[]
                    {
                        UnlimitedPointWorks[10], // 11
                        UnlimitedPointWorks[11], // 12

                    });
                e.Graphics.FillPie(new SolidBrush(Color.FromArgb(200, Color.OrangeRed)),
                    new Rectangle(new Point(UnlimitedPointWorks[UnlimitedPointWorks.Length - 1].X +
                    ((UnlimitedPointWorks[UnlimitedPointWorks.Length - 1].X == 0)? 0 :
                    -10),
                    UnlimitedPointWorks[UnlimitedPointWorks.Length - 1].Y - 5),
                    new Size(10, 10)), 0, 360);
            }
            #endregion
            //-------------------------------------------------
            #region ElementBackground region
            private void DesigningForElementBackGround()
            {

                //------------------------------------------
                //News:
                this.AnimationFactory = new Trigger();
                //Names:
                //TabIndexes:
                //Images:
                this.Image = Image.FromFile(ThereIsConstants.Path.Datas_Path +
                    ThereIsConstants.Path.DoubleSlash +
                    MyRes.GetString(FirstStoryLineSandBox.ElementBGFileNameInRes));
                //FontsAndTextAligns:
                //Sizes:
                //Locations:
                //Colors:
                this.SetColorTransparent();
                //ComboBoxes:
                //Enableds:
                //Texts:
                //AddRanges:
                //ToolTipSettings:
                //AnimationFactorySettings:
                this.AnimationFactory.Tick += AnimationFactoryWorker;
                this.AnimationFactory.Interval = 50;
                //this.AnimationFactory.Enabled = true;
                this.CurrentAnimationStatus = 0;
                //Events:
                this.MouseEnter += ElementLabelControl_MouseEnter;
                this.MouseLeave += ElementLabelControl_MouseLeave;
                this.MouseDown += ElementLabelControl_MouseDown;
                this.MouseUp += ElementLabelControl_MouseUp;
                //------------------------------------------

                //-----------------------------------------
            }

            public void ElementLabelControl_MouseUp(object sender, MouseEventArgs e)
            {
                if (DesigningMode == LabelControlSpecies.ElementBackGround)
                {
                    this.Paint -= LabelControl_Paint;
                }
                    this.SetColorTransparent();
                HasMouseDowned = false;
            }

            public void ElementLabelControl_MouseDown(object sender, MouseEventArgs e)
            {
                if(DesigningMode == LabelControlSpecies.ElementBackGround)
                {
                    this.Paint += LabelControl_Paint;
                }
                else
                {
                    this.BackColor = Color.Gold;
                }
                
                HasMouseDowned = true;
            }

            private void LabelControl_Paint(object sender, PaintEventArgs e)
            {
                e.Graphics.FillPie(new SolidBrush(Color.FromArgb(170, Color.Gold)),
                    new Rectangle(Width <= Height ? 0 : (Math.Abs(Width - Height) / 2),
                    Width >= Height ? 0 : (Math.Abs(Width - Height) / 2), 
                    Math.Min(Width, Height),
                    Math.Min(Width, Height)), 
                    0, 360);
            }

            public void ElementLabelControl_MouseLeave(object sender, EventArgs e)
            {
                this.AnimationFactory.Enabled = false;
                this.CurrentAnimationStatus = 0;
                this.Cursor = Cursors.Default;
                this.Image = Image.FromFile(ThereIsConstants.Path.Datas_Path +
                    ThereIsConstants.Path.DoubleSlash +
                    MyRes.GetString(FirstStoryLineSandBox.ElementBGFileNameInRes));
            }

            public void ElementLabelControl_MouseEnter(object sender, EventArgs e)
            {
                this.AnimationFactory.Enabled = true;
                this.Cursor = Cursors.Hand;
            }



            #endregion
            //-------------------------------------------------
            
            //-------------------------------------------------
            public void AnimationFactoryWorker(object sender, EventArgs e)
            {
                if (this.AnimationFactory.Running_Worker)
                {
                    return;
                }
                this.AnimationFactory.Running_Worker = true;
                if (UseAnimation)
                {
                    if(DesigningMode == LabelControlSpecies.ElementBackGround)
                    {
                        if (CurrentAnimationStatus < 180)
                        {
                            this.Image =
                                ThereIsConstants.Actions.RotateImage(
                                    new Bitmap(Image.FromFile(ThereIsConstants.Path.Datas_Path +
                                        ThereIsConstants.Path.DoubleSlash +
                                        MyRes.GetString(FirstStoryLineSandBox.ElementBGFileNameInRes))),
                                    CurrentAnimationStatus * 0.5f);
                            CurrentAnimationStatus++;
                        }
                        else
                        {
                            CurrentAnimationStatus = 0;
                        }
                    }
                    else if(DesigningMode == LabelControlSpecies.LinkStart)
                    {
                        bool IsSpotted = false;
                        int bottomIndex = 0;
                        for(int i = 0; i < UnlimitedPointWorks.Length - 1; i++)
                        {
                            // The Animation spotted point should always has the last Index.
                            if(UnlimitedPointWorks[UnlimitedPointWorks.Length - 1] == UnlimitedPointWorks[i])
                            {
                                IsSpotted = true;
                                bottomIndex = i;
                                break;
                            }
                            else
                            {
                                continue;
                            }
                        }
                        if (IsSpotted)
                        {
                            if(bottomIndex == UnlimitedPointWorks.Length - 2)
                            {
                                if(UnlimitedPointWorks[0].X == UnlimitedPointWorks[bottomIndex].X)
                                {
                                    Rate_of_incline = -1f;
                                    From_The_Edge_Of_Darkness = true;
                                }
                                else
                                {
                                    if (From_The_Edge_Of_Darkness)
                                    {
                                        From_The_Edge_Of_Darkness = false;
                                    }
                                    Rate_of_incline =
                                        ((float)(UnlimitedPointWorks[0].Y) -
                                        UnlimitedPointWorks[bottomIndex].Y) /
                                        Math.Abs((UnlimitedPointWorks[0].X -
                                        UnlimitedPointWorks[bottomIndex].X));
                                    if (UnlimitedPointWorks[0].X <
                                        UnlimitedPointWorks[bottomIndex].X)
                                    {
                                        Going_Sunny = false;
                                    }
                                    else
                                    {
                                        Going_Sunny = true;
                                    }
                                }
                                
                            }
                            else
                            {
                                if (UnlimitedPointWorks[bottomIndex + 1].X ==
                                    UnlimitedPointWorks[bottomIndex].X)
                                {
                                    Rate_of_incline = -2f;
                                    From_The_Edge_Of_Darkness = true;
                                }
                                else
                                {
                                    if (From_The_Edge_Of_Darkness)
                                    {
                                        From_The_Edge_Of_Darkness = false;
                                    }
                                    Rate_of_incline =
                                        ((float)(UnlimitedPointWorks[bottomIndex + 1].Y) -
                                        UnlimitedPointWorks[bottomIndex].Y) /
                                        Math.Abs((UnlimitedPointWorks[bottomIndex + 1].X -
                                        UnlimitedPointWorks[bottomIndex].X));
                                    if (UnlimitedPointWorks[bottomIndex + 1].X < 
                                        UnlimitedPointWorks[bottomIndex].X)
                                    {
                                        Going_Sunny = false;
                                    }
                                    else
                                    {
                                        Going_Sunny = true;
                                    }
                                }
                                
                            }
                        }
                        if(From_The_Edge_Of_Darkness)
                        {
                            if(Rate_of_incline == -1)
                            {
                                UnlimitedPointWorks[UnlimitedPointWorks.Length - 1] =
                                    new Point(UnlimitedPointWorks[
                                        UnlimitedPointWorks.Length - 1].X,
                                        UnlimitedPointWorks[
                                        UnlimitedPointWorks.Length - 1].Y - 1);
                            }
                            else
                            {
                                UnlimitedPointWorks[UnlimitedPointWorks.Length - 1] =
                                    new Point(UnlimitedPointWorks[
                                        UnlimitedPointWorks.Length - 1].X,
                                        UnlimitedPointWorks[
                                        UnlimitedPointWorks.Length - 1].Y + 1);
                            }
                        }
                        else
                        {
                            UnlimitedPointWorks[UnlimitedPointWorks.Length - 1] =
                            new Point(UnlimitedPointWorks[
                                UnlimitedPointWorks.Length - 1].X + (Going_Sunny ? 1 : -1),
                                UnlimitedPointWorks[
                                    UnlimitedPointWorks.Length - 1].Y +
                                    (int)Rate_of_incline);
                        }
                        
                    }
                }
                this.Refresh();
                this.AnimationFactory.Running_Worker = false;
            }

            /// <summary>
            /// Set the Label.Name Property with the Constant Parameter writed
            /// in ThereIsConstants.ResourcesNames.
            /// </summary>
            /// <param name="ConstParam">
            /// The Constant Parameter setted in <code> ThereIsConstants.ResourcesNames </code> 
            /// and in
            /// MainForm.MyRes.
            /// </param>
            public override void SetLabelName(string constParam)
            {
                this.RealName = constParam;
                this.Name = this.RealName +
                    ThereIsConstants.ResourcesName.End_Res_Name;
            }
            /// <summary>
            /// This Function will set the Label.Text Property with the algorithm
            /// from MainForm.MyRes.
            /// </summary>
            public override void SetLabelText()
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
            public override void SetLabelText(string customValue)
            {
                this.Text = customValue;
            }
            /// <summary>
            /// Setting the Text property to customValue.
            /// </summary>
            /// <param name="customValue">
            /// the custom Text.
            /// </param>
            public override void SetLabelText(StrongString customValue)
            {
                this.Text = customValue.GetValue();
            }
            /// <summary>
            /// Setting the this.BackColor Parameter to <see cref="Color.Transparent"/>
            /// </summary>
            public override void SetColorTransparent()
            {
                if(this.BackColor != Color.Transparent)
                {
                    this.BackColor = Color.Transparent; // The Back Color Should be Transparent.
                }
                
            }
            /// <summary>
            /// Setting the TextColor of this LabelControl.
            /// </summary>
            /// <param name="color"></param>
            public override  void SetTextColor(Color color)
            {
                ForeColor = color;
            }
            /// <summary>
            /// Setting the Mouse Sound Effects on this Label,
            /// Notice: when you are using this method, all the
            /// Events Clicks will be removed from the 
            /// LabelControl, so you should add them again.
            /// </summary>
            /// <param name="theValue">
            /// the Noise.
            /// No Noise, No Hand.
            /// </param>
            public override void SetLabelSoundEffects(Noises theValue)
            {
                MESoundEffects = theValue;
                //---------------------------------
                FieldInfo f1 = typeof(Control).GetField("EventClick",
                BindingFlags.Static | BindingFlags.NonPublic);

                object obj = f1.GetValue(this);
                PropertyInfo pi = this.GetType().GetProperty("Events",
                    BindingFlags.NonPublic | BindingFlags.Instance);

                EventHandlerList list = (EventHandlerList)pi.GetValue(this, null);
                list.RemoveHandler(obj, list[obj]);
                //---------------------------------
                f1 = typeof(Control).GetField("EventMouseEnter",
                BindingFlags.Static | BindingFlags.NonPublic);

                obj = f1.GetValue(this);
                pi = this.GetType().GetProperty("Events",
                    BindingFlags.NonPublic | BindingFlags.Instance);

                list = (EventHandlerList)pi.GetValue(this, null);
                list.RemoveHandler(obj, list[obj]);
                //---------------------------------
                switch (this.MESoundEffects)
                {
                    case Noises.ClickNoise:
                        this.Click      -= this.LinkStartLabelControl_MouseClick;
                        this.MouseEnter -= this.LinkStartLabelControl_MouseEnter;
                        this.MouseLeave -= this.LinkStartLabelControl_MouseLeave;
                        this.Click      += this.LinkStartLabelControl_MouseClick;
                        this.MouseEnter += this.LinkStartLabelControl_MouseEnter;
                        this.MouseLeave += this.LinkStartLabelControl_MouseLeave;
                        break;
                    default:
                        break;
                }
            }
            /// <summary>
            /// Adding the myEvent Click Event to all of my children.
            /// </summary>
            /// <param name="myEvent"></param>
            public override void AddClickEventToAllChild(EventHandler myEvent, bool setForMyself = false)
            {
                foreach(Control myCon in Controls)
                {
                    myCon.Click -= myEvent;
                    myCon.Click += myEvent;
                    if (myCon is LabelControl goodBoy)
                    {
                        goodBoy.AddClickEventToAllChild(myEvent, setForMyself);
                    }
                }
                if (setForMyself)
                {
                    this.Click -= myEvent;
                    this.Click += myEvent;
                }
            }
            public override void AddEnterEventToAllChild(EventHandler myEvent, bool setForMyself = true)
            {
                foreach (Control myCon in Controls)
                {
                    myCon.MouseEnter -= myEvent;
                    myCon.MouseEnter += myEvent;
                    if (myCon is LabelControl goodBoy)
                    {
                        goodBoy.AddEnterEventToAllChild(myEvent, setForMyself);
                    }
                }
                if (setForMyself)
                {
                    this.MouseEnter -= myEvent;
                    this.MouseEnter += myEvent;
                }
            }
            public override void AddLeaveEventToAllChild(EventHandler myEvent, bool setForMyself = true)
            {
                foreach (Control myCon in Controls)
                {
                    myCon.MouseLeave -= myEvent;
                    myCon.MouseLeave += myEvent;
                    if (myCon is LabelControl goodBoy)
                    {
                        goodBoy.AddLeaveEventToAllChild(myEvent, setForMyself);
                    }
                }
                if (setForMyself)
                {
                    this.MouseLeave -= myEvent;
                    this.MouseLeave += myEvent;
                }
            }
            //------------------------------------------------------------
            protected override void OnClick(EventArgs e)
            {
                if (SingleClick)
                {
                    if (HasMouseClickedOnce)
                    {
                        return;
                    }
                    else
                    {
                        HasMouseClickedOnce = true;
                    }
                }
                base.OnClick(e);
            }
        }
    }
}
