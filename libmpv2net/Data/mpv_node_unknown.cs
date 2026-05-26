using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace libmpv2net
{
    /// <summary>
    /// Useful when ingesting return values and a bridge struct
    /// is needed to determine the actual format.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct mpv_node_unknown
    {
        public IntPtr AnyData;
        public mpv_format Format;
    }
}
