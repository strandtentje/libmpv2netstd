using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibMpvWrapper
{
    public static class LifecycleExtensions
    {
        public static string AsKeepOpenArg(
            this PlaylistLifecycle cycle)
        {
            switch (cycle)
            {
                case PlaylistLifecycle.CloseAfterEnd:
                    return "no";
                case PlaylistLifecycle.DontAutoplay:
                    return "always";
                case PlaylistLifecycle.PauseAfterEnd:
                    return "yes";                    
                default:
                    throw new ArgumentException("unknown lifecycle param", "cycle");
            }
        }
    }
}
