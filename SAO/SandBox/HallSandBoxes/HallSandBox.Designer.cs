using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;
using WotoProvider.EventHandlers;
using SAO.Controls;
using SAO.Constants;
using SAO.GameObjects.Resources;

namespace SAO.SandBox.HallSandBoxes
{
    partial class HallSandBox
    {
        //-------------------------------------------------------
        private void Initialize_HallOfStory_Component()
        {
            if (UseAnimation)
            {
                //this.SuspendLayout();
                this.OriginalSize = new Size(19 * (UnderForm.Size.Width / 20),
                    18 * (UnderForm.Size.Height / 19));
                this.OriginalPoint = new Point((UnderForm.Size.Width / 2)
                    - (OriginalSize.Width / 2),
                    (UnderForm.Size.Height / 2) - (OriginalSize.Height / 2));
                this.Size = new Size(19 * (UnderForm.Size.Width / 20),
                    10 * (UnderForm.Size.Height / 19));


                //----------------------------------
                //news:
                this.AnimationTimer = new Trigger()
                {
                    SingleLineWorker = true,

                };
                this.MyRes = new WotoRes(typeof(HallSandBox));
                //Names:
                //TabIndexes:
                //FontsAndTextAligns:
                //Sizes:
                //Locations:
                //Colors:
                //this.BackColor = Color.White;
                //Images:
                
                //ComboBoxes:
                //Enableds:
                //Texts:
                //AddRanges:
                //ToolTipSettings:
                //TimerSettings:
                this.AnimationTimer.Interval = 100;
                this.AnimationTimer.Tick += AnimationTimer_Tick;
                //Events:
                this.SizeChanged += FirstStoryLineSandBox_SizeChanged;

                //FinalBlow:
                //this.ResumeLayout();
                this.AnimationTimer.Start();
                
            }
            else
            {
                //MessageBox.Show("HERE");
            }
        }
        private void FirstStoryLineSandBox_SizeChanged(object sender, EventArgs e)
        {
            this.Location = new Point((UnderForm.Size.Width / 2) -
                (Size.Width / 2), (UnderForm.Size.Height / 2) -
                (Size.Height / 2));
        }
        private async void AnimationTimer_Tick(Trigger sender, TickHandlerEventArgs<Trigger> e)
        {
            if ((Size.Height + BookStroryHallRate) < OriginalSize.Height)
            {
                //MessageBox.Show(Size.Width.ToString() + " " + Size.Height.ToString());
                this.Size = new Size(Size.Width, (Size.Height + BookStroryHallRate));
            }
            else
            {
                this.Size = OriginalSize;
                GC.Collect();
                ((Timer)sender).Enabled = false;
                if(EventAfterEndingTheAnimation != null)
                {
                    await Task.Delay(500);
                    this.BackgroundImageLayout = ImageLayout.Stretch;
                    this.BackgroundImage = Image.FromFile(ThereIsConstants.Path.Datas_Path + "\\" +
                        MyRes.GetString(FirstHallOfSecretsNameInRes));
                    EventAfterEndingTheAnimation?.Invoke(sender, e);
                }
            }

        }
        //-------------------------------------------------------
        private void Initialize_HallOfElements_Component()
        {
            if (UseAnimation)
            {
                this.OriginalSize = new Size(UnderForm.Size.Width,
                    UnderForm.Size.Height);
                this.OriginalPoint = new Point((UnderForm.Width / 2)
                    - (OriginalSize.Width / 2),
                    (UnderForm.Height / 2) - (OriginalSize.Height / 2));
                this.Size = new Size(UnderForm.Width ,
                    14 * (UnderForm.Size.Height / 19));


                //----------------------------------
                //news:
                this.AnimationTimer = new Trigger()
                {
                    SingleLineWorker = true,

                };
                this.MyRes = new WotoRes(typeof(HallSandBox));
                //Names:
                //TabIndexes:
                //FontsAndTextAligns:
                //Sizes:
                //Locations:
                //Colors:
                //Images:
                this.BackgroundImageLayout = ImageLayout.Stretch;
                this.BackgroundImage = Image.FromFile(ThereIsConstants.Path.Datas_Path + "\\" +
                    MyRes.GetString(ElementHallOfSecretsNameInRes));
                //ComboBoxes:
                //Enableds:
                //Texts:
                //AddRanges:
                //ToolTipSettings:
                //TimerSettings:
                this.AnimationTimer.Interval = 100;
                this.AnimationTimer.Tick += ElementsAnimationTimer_Tick;
                //Events:
                this.SizeChanged += HallOfElementSandBox_SizeChanged;

                //FinalBlow:
                this.AnimationTimer.Start();
            }
            else
            {
                //MessageBox.Show("HERE");
            }
        }
        private void HallOfElementSandBox_SizeChanged(object sender, EventArgs e)
        {
            this.Location = new Point((UnderForm.Size.Width / 2) -
                (Size.Width / 2), (UnderForm.Size.Height / 2) -
                (Size.Height / 2));
        }
        private void ElementsAnimationTimer_Tick(Trigger sender, TickHandlerEventArgs<Trigger> e)
        {
            if ((Size.Height + 50) < OriginalSize.Height)
            {
                //MessageBox.Show(Size.Width.ToString() + " " + Size.Height.ToString());
                this.Size = new Size(Size.Width, (Size.Height + 50));
            }
            else
            {
                this.Size = OriginalSize;
                GC.Collect();
                ((Timer)sender).Enabled = false;
                if (EventAfterEndingTheAnimation != null)
                {
                    EventAfterEndingTheAnimation(sender, e);
                }
            }

        }
        //-------------------------------------------------------
        //-------------------------------------------------------
        protected override void OnGotFocus(EventArgs e)
        {
            if (!IsHallUp)
            {
                IsHallUp = true;
            }
            base.OnGotFocus(e);
            ThereIsConstants.Forming.GameClient.Focus();
            MyFrontSandBox.Focus();
        }
        //-----------------------------------------------
        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            if (IsHallUp && !MyFrontSandBox.Focused)
            {
                IsHallUp = false;
            }
        }
        //-------------------------------------------------------

    }
}
