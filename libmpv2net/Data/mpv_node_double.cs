using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace libmpv2net
{
    /// <summary>
    /// When the node format is Double, the data field is a plain double.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct mpv_node_double
    {
        public double data;
        public mpv_format format;
    }
}
