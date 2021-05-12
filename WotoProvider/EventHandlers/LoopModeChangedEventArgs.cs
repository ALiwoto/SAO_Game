// Copyright (C) ALiwoto 2019 - 2020
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of the source code.

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
