using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibMpvWrapper
{
    public static class LifecycleExtensions
    {
        public static string AsKeepOpenArg(
            this Lifecycle cycle)
        {
            switch (cycle)
            {
                case Lifecycle.CloseAfterEnd:
                    return "no";
                    break;
                case Lifecycle.DontAutoplay:
                    return "always";
                    break;
                case Lifecycle.PauseAfterEnd:
                    return "yes";
                    break;
                default:
                    break;
            }
        }
    }
}
