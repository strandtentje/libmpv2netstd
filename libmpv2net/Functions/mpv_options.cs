using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace libmpv2net.Functions
{
    public static class mpv_options
    {
        /// <summary>
        /// Use this before initialize to load a config file.
        /// </summary>
        /// <param name="handle">MPV Context handle</param>
        /// <param name="filename">Full absolute path to config file</param>
        /// <returns></returns>
        [DllImport("libmpv-2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern mpv_load_config_file_result
            mpv_load_config_file(mpv_handle handle,
            [MarshalAs(UnmanagedType.LPUTF8Str)] ref string filename);

        /// <summary>
        /// Set option you'd otherwise set via the config file, 
        /// before initialize.
        /// </summary>
        /// <param name="ctx">MPV Context handle</param>
        /// <param name="name">Option name</param>
        /// <param name="format">Option format</param>
        /// <param name="data">Pointer to node or data</param>
        /// <returns></returns>
        [DllImport("libmpv-2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern mpv_set_option_result mpv_set_option(
            mpv_handle ctx, mpv_option_name name,
            mpv_format format, mpv_node_pointer data);

        /// <summary>
        /// Set option you'd otherwise set via the config file, 
        /// before initialize. Overload that has long; mind the mpv_format.
        /// </summary>
        /// <param name="ctx">MPV Context handle</param>
        /// <param name="name">Option name</param>
        /// <param name="format">Option format</param>
        /// <param name="data">Pointer to node or data</param>
        /// <returns></returns>
        [DllImport("libmpv-2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern mpv_set_option_result mpv_set_option(
            mpv_handle ctx, mpv_option_name name, mpv_format format, ref long data);

        /// <summary>
        /// Set option you'd otherwise set via the config file, 
        /// before initialize. Overload that has string; mind the mpv_format.
        /// </summary>
        /// <param name="ctx">MPV Context handle</param>
        /// <param name="name">Option name</param>
        /// <param name="format">Option format</param>
        /// <param name="data">Pointer to node or data</param>
        /// <returns></returns>
        [DllImport("libmpv-2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern mpv_set_option_result mpv_set_option(
            mpv_handle ctx, mpv_option_name name,
            mpv_format format, [MarshalAs(UnmanagedType.LPUTF8Str)] ref string data);

        /// <summary>
        /// Like mpv_set_option, but uses strings and automatic parsing.
        /// Convenient.
        /// </summary>
        /// <param name="ctx">MPV Context Handle</param>
        /// <param name="name">Option name</param>
        /// <param name="data">Option data.</param>
        /// <returns></returns>
        [DllImport("libmpv-2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern mpv_set_option_string_result mpv_set_option_string(
            mpv_handle ctx, mpv_option_name name,
            [MarshalAs(UnmanagedType.LPUTF8Str)] ref string data);
    }
}
