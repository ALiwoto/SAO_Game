using System;
namespace WotoProvider.EventHandlers
{
    public class WotoEventArgs : EventArgs
    {
        public WotoCreation WotoCreation { get; }

        public WotoEventArgs(WotoCreation wotoCreation)
        {
            WotoCreation = wotoCreation;
        }
    }
}
