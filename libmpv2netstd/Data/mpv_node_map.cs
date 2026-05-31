using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace libmpv2net
{
    /// <summary>
    /// Works like mpv_node_list and is natively implemented 
    /// using thesame struct, but on our end we use a different 
    /// struct to only access the keys in case we're dealing with
    /// a mpv_node_map
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct mpv_node_map
    {
        public int num;
        [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)]
        public mpv_node_unknown[] values;
        [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)]
        public IntPtr[] keys;
    }
}
