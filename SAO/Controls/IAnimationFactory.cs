// Copyright (C) ALiwoto 2019 - 2020
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of the source code.

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
