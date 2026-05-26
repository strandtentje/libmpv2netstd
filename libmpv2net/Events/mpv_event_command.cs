using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace libmpv2net
{
    /// <summary>
    /// If a command had result data, it'll be set here.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct mpv_event_command
    {
        /// <summary>
        /// Typically MPV_FORMAT_NONE, in case of both success and failure;
        /// use mpv_event.error to figure out if we had an error.
        /// </summary>
        public mpv_node_unknown result;
    }
}
