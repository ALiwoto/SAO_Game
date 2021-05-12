using System;
using System.Runtime.InteropServices;
using SAO.GameObjects.Math;
using SAO.GameObjects.Resources;
using SAO.GameObjects.MapObjects;
using SAO.Controls.Animation.AnimationCompanies;

namespace SAO.Controls.Animation
{
    [ComVisible(true)]
    public abstract partial class AnimationCompany : IRes, IAnimationFactory, IDisposable
    {
        //-------------------------------------------------
        #region protected fields
        protected Trigger topMostAnimationFactory;
        #endregion
        //-------------------------------------------------
        #region public Properties Region
        public virtual WotoRes MyRes { get; set; }
        /// <summary>
        /// Get the top-most Animation Factory.
        /// Please do NOT use this for ordinary situation,
        /// becuase it will return you the zero index of 
        /// <see cref="AnimationFactories"/>,
        /// so instead use 
        /// <see cref="AnimationFactories"/> directly.
        /// </summary>
        public virtual Trigger AnimationFactory
        {
            get
            {
                if (topMostAnimationFactory != null)
                {
                    return topMostAnimationFactory;
                }
                else
                {
                    if (AnimationFactories != null) 
                    {
                        if (AnimationFactories[0] != null) 
                        {
                            return AnimationFactories[0];
                        }
                    }
                }
                return null;
            }
            set
            {
                if (value != null) 
                {
                    if (AnimationFactories != null)
                    {
                        for (int i = 0; i < AnimationFactories.Length; i++)
                        {
                            if (AnimationFactories[i] == value)
                            {
                                topMostAnimationFactory = value;
                                break;
                            }
                            else
                            {
                                continue;
                            }
                        }
                    }
                }
            }
        }
        public virtual Randomic[] UnlimitedRandomicWorks { get; protected set; }
        public virtual Range[] GraphicsWorkRanges { get; set; }
        public virtual Trigger[] AnimationFactories { get; protected set; }
        public virtual GameControls.PageControl Father { get; protected set; }
        public virtual Map TheMap { get; protected set; }
        //-------------------------------------------------
        public virtual string Name { get; set; }
        //-------------------------------------------------
        /// <summary>
        /// This parameter should be true,
        /// otherwise you should dispose the whole
        /// Animation Company.
        /// </summary>
        public virtual bool UseAnimation { get; set; }
        //-------------------------------------------------
        /// <summary>
        /// Please override, then define it in each 
        /// company.
        /// </summary>
        public virtual AnimationCompaniesList Type { get; }
        #endregion
        //-------------------------------------------------
        #region Constructors and Destructor Region
        protected AnimationCompany()
        {
            UseAnimation = true;
            InitializeComponent();
        }

        /// <summary>
        /// The destructor
        /// </summary>
        ~AnimationCompany()
        {

        }
        #endregion
        //-------------------------------------------------
        #region static Methods Region
        public static AnimationCompany GetAnimationCompany(AnimationCompaniesList com,
            GameControls.PageControl father)
        {
            switch (com)
            {
                case AnimationCompaniesList.DreamWorksCompany:
                    {
                        return new DreamWorks(father);
                    }
            }
            return null;
        }
        #endregion
        //-------------------------------------------------
    }
}
