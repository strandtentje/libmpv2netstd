using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace libmpv2net
{
    public static class mpv_events
    {
        /// <summary>
        /// For a textual representation of our mpv_event_id enum.
        /// Shouldn't be too necessary in our managed code.
        /// </summary>
        /// <param name="event_id">Event ID</param>
        /// <returns></returns>
        [DllImport("libmpv-2.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.LPUTF8Str)]
        public static extern string mpv_event_name(mpv_event_id event_id);
        
        /// <summary>
        /// Converts an mpv_event into an mpv_node_unknown.
        /// use this with mpv_free_node_contents after.
        /// </summary>
        /// <param name="dst">Destination mpv_node pointer</param>
        /// <param name="src">Source event</param>
        /// <returns></returns>
        [DllImport("libmpv-2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern mpv_event_to_node_result mpv_event_to_node(
            mpv_node_pointer dst, [MarshalAs(UnmanagedType.LPStruct)] mpv_event src);

        /// <summary>
        /// Explicitly enable or disable a particular event.
        /// Typically, only the TICK-event isn't enabled by default.
        /// </summary>
        /// <param name="ctx">MPV Handle</param>
        /// <param name="event_id">Event ID to configure</param>
        /// <param name="enable">On or off.</param>
        /// <returns></returns>
        [DllImport("libmpv-2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern mpv_request_event_result mpv_request_event(
            mpv_handle ctx, mpv_event_id event_id, 
            [MarshalAs(UnmanagedType.Bool)] bool enable);
        
        /// <summary>
        /// Enable, disable or configure mpv directly complaining into 
        /// the terminal by setting the min. level.
        /// </summary>
        /// <param name="ctx">MPV Client Handle</param>
        /// <param name="min_level">no fatal error warn info v debug trace</param>
        /// <returns></returns>
        [DllImport("libmpv-2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern mpv_request_log_messages_result 
            mpv_request_log_messages(mpv_handle ctx, 
            [MarshalAs(UnmanagedType.LPUTF8Str)] ref string min_level);

        /// <summary>
        /// Wait or poll for the next incoming event synchronously.
        /// </summary>
        /// <param name="ctx">MPV Client Handle</param>
        /// <param name="timeout">0 to just pop an event, or higher
        /// to block a bit until the event comes in.</param>
        /// <returns></returns>
        [DllImport("libmpv-2.dll", CallingConvention = CallingConvention.Cdecl)]        
        public static extern IntPtr mpv_wait_event(
            mpv_handle ctx, double timeout);
        
        /// <summary>
        /// Unblocks any pending mpv_wait_event calls, and makes them return
        /// as though their timeout expired.
        /// </summary>
        /// <param name="ctx"></param>
        [DllImport("libmpv-2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void mpv_wakeup(mpv_handle ctx);
        
        /// <summary>
        /// Blocks until all async calls have been fulfilled.
        /// </summary>
        /// <param name="ctx">MPV client handle</param>
        [DllImport("libmpv-2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void mpv_wait_async_requests(mpv_handle ctx);
    }
}
