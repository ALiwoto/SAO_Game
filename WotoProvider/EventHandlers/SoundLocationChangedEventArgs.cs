﻿// Copyright (C) ALiwoto 2019 - 2020
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of the source code.

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
