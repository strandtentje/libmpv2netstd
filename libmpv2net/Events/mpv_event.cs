using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace libmpv2net
{
    [StructLayout(LayoutKind.Sequential)]
    public struct mpv_event
    {
        /// <summary>
        /// Event ID
        /// </summary>
        public mpv_event_id event_id;
        /// <summary>
        /// When negative, is an mpv_error. Positive is good :)
        /// </summary>
        public int error;
        /// <summary>
        /// ulong that we assigned to track our event subscription.
        /// mpv only uses this to cancel async stuff if requested.
        /// </summary>
        public long reply_userdata;
        /// <summary>
        /// May point to:
        ///  - mpv_event_property for:
        ///     - _PROPERTY_REPLY
        ///     - _PROPERTY_CHANGE
        ///  - mpv_event_log_message for _LOG_MESSAGE
        ///  - mpv_client_message for _CLIENT_MESSAGE
        ///  - mpv_start_file for _START_FILE
        ///  - mpv_end_file for _END_FILE
        ///  - mpv_event_hook for _HOOK
        ///  - mpv_event_command for _COMMAND_REPLY
        /// </summary>
        public IntPtr data;
    }
}
