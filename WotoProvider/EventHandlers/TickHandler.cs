// Copyright (C) ALiwoto 2019 - 2020
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of the source code.

using System;
using System.Collections.Generic;
using System.Text;

namespace WotoProvider.EventHandlers
{
    public delegate void TickHandler<T>(T sender, TickHandlerEventArgs<T> handler) where T : class;
}
