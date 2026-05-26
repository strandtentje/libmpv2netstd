using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace libmpv2net.Functions
{
    public static class mpv_initial
    {
        /// <summary>
        /// Returns the MPV_CLIENT_API_VERSION the mpv source has been 
        /// compiled with
        /// </summary>
        /// <returns>API Version</returns>
        [DllImport("libmpv-2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern ulong 
            mpv_client_api_version();

        /// <summary>
        /// This must be called first to having something to talk against
        /// so as to operate mpv.
        /// </summary>
        /// <returns></returns>
        [DllImport("libmpv-2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern mpv_create_result mpv_create();

        /// <summary>
        /// This must also be called, after mpv_create, to actually start up
        /// mpv.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        [DllImport("libmpv-2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern mpv_initialize_result mpv_initialize(mpv_handle handle);

        /// <summary>
        /// To destroy a context or client context
        /// </summary>
        /// <param name="handle"></param>
        [DllImport("libmpv-2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void mpv_destroy(mpv_handle handle);

        /// <summary>
        /// Terminate and destroy everything
        /// </summary>
        /// <param name="handle"></param>
        [DllImport("libmpv-2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void mpv_terminate_destroy(mpv_handle handle);

        /// <summary>
        /// Create a kind of sub-context. Check docs. Seems spooky.
        /// </summary>
        /// <param name="handle"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        [DllImport("libmpv-2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern mpv_handle mpv_create_client(mpv_handle handle, 
            [MarshalAs(UnmanagedType.LPStr)] string name);
    }
}
