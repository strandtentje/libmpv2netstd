using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace libmpv2net
{
    /// <summary>
    /// When the mode format is a byte array, the mpv_node data 
    /// will point to an allocation of mpv_byte_array.
    /// This mpv_byte_array_32 is likely never used unless your
    /// libmpv-2 is explicity built against 32-bit.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct mpv_byte_array_32
    {
        [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)]
        public byte[] data;
        public int size;
    }
}
