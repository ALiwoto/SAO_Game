
namespace WotoProvider.EventHandlers
{
    public class VolumeChangedEventArgs : WotoEventArgs
    {
        public uint NewVolume { get; }
        public VolumeChangedEventArgs(uint theNewVolume, WotoCreation wotoCreation) : 
            base(wotoCreation)
        {
            NewVolume = theNewVolume;

        }
    }
}
