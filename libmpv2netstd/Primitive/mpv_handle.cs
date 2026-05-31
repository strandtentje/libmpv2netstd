using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace libmpv2net
{
    /// <summary>
    /// Client context used by the client API. Every client has its 
    /// own private handle.
    /// </summary>
    public struct mpv_handle
    {
        public IntPtr handle;
    }
}
