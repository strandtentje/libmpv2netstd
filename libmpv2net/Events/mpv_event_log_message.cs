using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace libmpv2net
{
    /// <summary>
    /// When logging was enabled, log messages come in here via 
    /// the mpv_event
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct mpv_event_log_message
    {
        [MarshalAs(UnmanagedType.LPStr)]
        public string prefix;
        /// <summary>
        /// no, error, fatal, warn, info, v, debug, trace.
        /// </summary>
        [MarshalAs(UnmanagedType.LPStr)]
        public string level_str;
        /// <summary>
        /// Message text.
        /// </summary>
        [MarshalAs(UnmanagedType.LPStr)]
        public string text;
        /// <summary>
        /// Like level_str but using the enum.
        /// </summary>
        public mpv_log_level level;
    }
}
