using System;
namespace WotoProvider.EventHandlers
{
    public class LoopModeChangedEventArgs : WotoEventArgs
    {
        public bool LoopModeTurnedOn { get; set; }
        public LoopModeChangedEventArgs(bool loopModeTurnedOn, WotoCreation wotoCreation) : base(wotoCreation)
        {
            LoopModeTurnedOn = loopModeTurnedOn;
        }
    }
}
