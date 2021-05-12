using System;

namespace SAO.Controls
{
    public interface IAnimationFactory
    {
        Trigger AnimationFactory { get; set; }
        bool UseAnimation { get; set; }
        void AnimationFactoryWorker(object sender, EventArgs e);
    }
}
