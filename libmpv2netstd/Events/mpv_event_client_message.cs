using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace libmpv2net
{
    /// <summary>
    /// When event id is client message
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct mpv_event_client_message
    {
        /// <summary>
        /// Array size.
        /// </summary>
        public int num_args;
        /// <summary>
        /// Arbitrary arguments, depends on the origin.
        /// </summary>
        [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)]
        public IntPtr[] args;
    }
}
