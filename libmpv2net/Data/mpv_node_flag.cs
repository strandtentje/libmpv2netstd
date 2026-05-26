using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace libmpv2net
{
    /// <summary>
    /// When the mpv_format is BooleanFlag, the data field contains
    /// a C-style bool as a 32-bit int. Because the mpv_node natively 
    /// uses a union for this field, this value lives in a 64 bit allocation
    /// of which the first 32 bits are used for the C style int, and the
    /// remainder is a suprise :)
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct mpv_node_flag
    {
        [MarshalAs(UnmanagedType.Bool)]
        public bool data;        
        public int pad;
        public mpv_format format;
    }
}
