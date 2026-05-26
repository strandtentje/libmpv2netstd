using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace libmpv2net
{
    /// <summary>
    /// Normally equivalent to directly expressing a string marshalled
    /// as lpstr, but useful for string arrays.
    /// </summary>
    public struct mpv_string
    {
        [MarshalAs(UnmanagedType.LPStr)]
        public string value;
    }
}
