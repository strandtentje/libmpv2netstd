using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace libmpv2net
{
    /// <summary>
    /// not sure what this is for.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct mpv_event_hook
    {
        [MarshalAs(UnmanagedType.LPUTF8Str)]
        public string name;
        ulong id;
    }
}
