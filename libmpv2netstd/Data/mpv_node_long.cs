using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace libmpv2net
{
    /// <summary>
    /// When the mpv_format is Long, the heading data will contain 
    /// a 64 bit long int.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct mpv_node_long
    {
        public long data;
        public mpv_format format;
    }
}
