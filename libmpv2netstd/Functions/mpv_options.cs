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
            mpv_load_config_file(
            mpv_handle handle,
            IntPtr filename_str_ptr);

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
            mpv_handle ctx,
            IntPtr name,
            mpv_format format,
            IntPtr data_ptr);

        public static void mpv_set_option(
            mpv_handle ctx, string name, IntPtr data)
        {
            using (var name_ptr = name.ToMemory())
                mpv_set_option(ctx, name_ptr.HGlobal, mpv_format.Long, data);
        }

        public static void mpv_set_option(
            mpv_handle ctx, string name, long data)
        {
            using (var name_ptr = name.ToMemory())
                mpv_set_option(ctx, name_ptr.HGlobal, mpv_format.Long, new IntPtr(data));
        }

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
            mpv_handle ctx, IntPtr name, IntPtr data_str_ptr);

        public static void mpv_set_option_string(
            mpv_handle ctx, string name, string value)
        {
            using (var name_ptr = name.ToMemory())
            using (var val_ptr = value.ToMemory())
                mpv_set_option_string(ctx, name_ptr.HGlobal, val_ptr.HGlobal).Assert(name, value);
        }


    }
}
