using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace libmpv2net.Functions
{
    public static class mpv_properties
    {
        [DllImport("libmpv-2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern mpv_set_property_result mpv_set_property(mpv_handle ctx,
            [MarshalAs(UnmanagedType.LPStr)] string name, mpv_format format,
            mpv_node_pointer data);

        [DllImport("libmpv-2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern mpv_set_property_result mpv_set_property(mpv_handle ctx,
            [MarshalAs(UnmanagedType.LPStr)] string name, mpv_format format,
            double data);

        [DllImport("libmpv-2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern mpv_set_property_result mpv_set_property(mpv_handle ctx,
            [MarshalAs(UnmanagedType.LPStr)] string name, mpv_format format,
            long data);

        [DllImport("libmpv-2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern mpv_set_property_result mpv_set_property(mpv_handle ctx,
            [MarshalAs(UnmanagedType.LPStr)] string name, mpv_format format,
            [MarshalAs(UnmanagedType.Bool)] bool data);

        [DllImport("libmpv-2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern mpv_set_property_string_result 
            mpv_set_property_string(mpv_handle ctx,
            [MarshalAs(UnmanagedType.LPStr)] string name,
            [MarshalAs(UnmanagedType.LPStr)] string data);

        [DllImport("libmpv-2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern mpv_del_property_result mpv_del_property(mpv_handle ctx,
            [MarshalAs(UnmanagedType.LPStr)] string name);

        [DllImport("libmpv-2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern mpv_set_property_async_result 
            mpv_set_property_async(mpv_handle ctx,
            long reply_userdata, [MarshalAs(UnmanagedType.LPStr)] string name,
            mpv_format format, mpv_node_pointer data);

        [DllImport("libmpv-2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern mpv_get_property_result mpv_get_property(
            mpv_handle ctx, [MarshalAs(UnmanagedType.LPStr)] string name,
            mpv_format format, mpv_node_pointer data);

        [DllImport("libmpv-2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern mpv_get_property_result mpv_get_property(
            mpv_handle ctx, [MarshalAs(UnmanagedType.LPStr)] string name,
            mpv_format format,
            ref double dbl);

        [DllImport("libmpv-2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern mpv_get_property_result mpv_get_property(
            mpv_handle ctx, [MarshalAs(UnmanagedType.LPStr)] string name,
            mpv_format format,
            ref long int64);

        [DllImport("libmpv-2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern mpv_get_property_result mpv_get_property(
            mpv_handle ctx, [MarshalAs(UnmanagedType.LPStr)] string name,
            mpv_format format,
            [MarshalAs(UnmanagedType.Bool)] ref bool dbl);

        [DllImport("libmpv-2.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.LPStr)]
        public static extern string mpv_get_property_string(mpv_handle ctx,
            [MarshalAs(UnmanagedType.LPStr)] string name);

        [DllImport("libmpv-2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern mpv_observe_property_result mpv_observe_property(
            mpv_handle ctx, long reply_userdata, 
            [MarshalAs(UnmanagedType.LPStr)] string name, mpv_format format);

        [DllImport("libmpv-2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern mpv_unobserve_property_result 
            mpv_unobserve_property(mpv_handle ctx, long registered_reply_userdata);
    }
}
