using System;
using System.Windows.Forms;

namespace SAO.Controls.Animation
{
    partial class AnimationCompany
    {
        //-------------------------------------------------
        #region Initialize Region
        private void InitializeComponent()
        {
            //---------------------------------------------
            //---------------------------------------------
            //---------------------------------------------
            //---------------------------------------------
            //---------------------------------------------
        }
        #endregion
        //-------------------------------------------------
        #region Graphics Work
        protected virtual void GraphicDrawing(object sender, PaintEventArgs e)
        {

        }
        public virtual void Dispose()
        {
            // ...
        }
        #endregion

        #region FactoryWorker
        public virtual void AnimationFactoryWorker(object sender, EventArgs e)
        {
            /*
             * Something like this:
             * switch(((Trigger)sender).Index)
             *      case 0:
             *          // ....
             *      case 1:
             *          // ....
             * * * * * * * * * * * * * * * * *
             * BY: ALi.w && mrwoto :
             *      08 / 12 / 2020
             * * * * * * * * * * * * * * * * *
             */
        }
        public virtual void SetTopMostFactory(uint index)
        {

        }
        public virtual void Apply()
        {
            // ...
        }
        public virtual void Apply(bool applySurfaces)
        {
            // ...
        }
        #endregion
        //-------------------------------------------------

    }
}