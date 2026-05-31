using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace libmpv2net
{
    /// <summary>
    /// When the format of the node is ByteArray, 
    /// the data field is a pointer to an mpv_byte_array_64.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct mpv_node_bytearraypointer
    {
        public mpv_byte_array_64 data;
        /// <summary>
        /// Must be ByteArray in this case.
        /// </summary>
        public mpv_format format;
    }
}
