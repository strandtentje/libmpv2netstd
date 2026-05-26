using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace libmpv2net
{
    /// <summary>
    /// When the mpv_format is string or osdstring, the data 
    /// is a pointer to a null-terminated unicode string.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct mpv_node_string
    {
        [MarshalAs(UnmanagedType.LPUTF8Str)]
        public string data;
        public mpv_format format;   
    }
}
