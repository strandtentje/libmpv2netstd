using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace libmpv2net
{
    /// <summary>
    /// When the mpv_format is NodeList, node_unknown can be 
    /// cast to this to retrieve the mpv_node_list from the pointer.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct mpv_node_listpointer
    {
        [MarshalAs(UnmanagedType.LPStruct)]
        public mpv_node_list data;
        /// <summary>
        /// Must be NodeList
        /// </summary>
        public mpv_format format;
    }
}
