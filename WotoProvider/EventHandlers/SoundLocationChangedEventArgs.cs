namespace WotoProvider.EventHandlers
{
    public class SoundLocationChangedEventArgs : WotoEventArgs
    {
        public string NewLocation { get; }
        public SoundLocationChangedEventArgs(string theNewLocation, WotoCreation wotoCreation) :
            base(wotoCreation)
        {
            NewLocation = theNewLocation;
        }
    }
}
