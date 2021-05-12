using System;
using System.Collections.Generic;
using System.Text;

namespace WotoProvider.EventHandlers
{
    public delegate void TickHandler<T>(T sender, TickHandlerEventArgs<T> handler) where T : class;
}
