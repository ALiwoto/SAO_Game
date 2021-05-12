// Copyright (C) ALiwoto 2019 - 2020
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of the source code.


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
