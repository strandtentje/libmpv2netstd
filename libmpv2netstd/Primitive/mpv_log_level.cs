using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace libmpv2net
{
    public enum mpv_log_level
    {
        None = 0,
        Fatal = 10,
        Error = 20,
        Warn = 30,
        Info = 40,
        Verbose = 50,
        Debug = 60,
        Trace = 70,
    }
}
