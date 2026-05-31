using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace libmpv2net
{
    /// <summary>
    /// When the format of the node is NodeList, its data will point
    /// to an allocation of mpv_node_list, which is a counted array.
    /// Natively, mpv_node_list is also mpv_node_map, but the last 64 bits 
    /// of the mpv_node_list don't get used when the format is NodeList.
    /// As such, this one has an IntPtr padding.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct mpv_node_list
    {
        /// <summary>
        /// Item count
        /// </summary>
        public int num;
        /// <summary>
        /// Item array
        /// </summary>
        [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)]        
        public mpv_node_unknown[] values;        
        /// <summary>
        /// Unused padding (see mpv_node_map)
        /// </summary>
        public IntPtr padding;
    }
}
