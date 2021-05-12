using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAO.GameObjects.Chatting
{
    public delegate Task<bool> ChatReloadedEventHandler(ChatMessage message);
}
