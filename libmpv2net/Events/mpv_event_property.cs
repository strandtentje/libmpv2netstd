using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace libmpv2net
{
    /// <summary>
    /// For async get properties
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct mpv_event_property
    {
        /// <summary>
        /// Name of the property we just received
        /// </summary>        
        public IntPtr name;
        /// <summary>
        /// format; thought data is mpv_node_pointer for ease, 
        /// always check this.
        /// </summary>
        public mpv_format format;
        public IntPtr data;
    }
}
