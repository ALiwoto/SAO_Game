using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAO.SandBox
{

    public class ButtonsOnSandBox
    {
        public bool CancelButton { get; set; }
        public bool ReloadButton { get; set; }
        public bool YesButton { get; set; }
        public bool NoButton { get; set; }
        public bool ExitButton { get; set; }
        public bool SkipButton { get; set; }
        public ButtonsOnSandBox()
        {
            /*
            CancelButton = ReloadButton =
            YesButton = NoButton =
            ExitButton = false;
            */
            // All Values should be in default -> false.
        }
    }
}
