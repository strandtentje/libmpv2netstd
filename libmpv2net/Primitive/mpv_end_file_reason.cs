using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace libmpv2net
{
    public enum mpv_end_file_reason
    {
        Eof = 0,
        Stop = 2,
        Quit = 3,
        Error = 4,
        Redirect = 5,
    }
}
