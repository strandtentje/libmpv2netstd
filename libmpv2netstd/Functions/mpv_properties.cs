using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace libmpv2net.Functions
{
    public static class mpv_properties
    {
        [DllImport("libmpv-2.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern mpv_set_property_result mpv_set_property(
            mpv_handle ctx,
            IntPtr name,
            mpv_format format,
            IntPtr data);

        public static void mpv_set_property(
            mpv_handle ctx, UnicodeBinaryString name_ptr, mpv_format format, IntPtr data)
        {
            mpv_set_property(ctx, name_ptr.HGlobal, format, data).Assert(name_ptr, format, data);
        }

        public static void mpv_set_property(
            mpv_handle ctx, UnicodeBinaryString name_ptr, long data)
        {
            mpv_set_property(ctx, name_ptr, mpv_format.Long, new IntPtr(data));
        }
        public static void mpv_set_property(
            mpv_handle ctx, UnicodeBinaryString name_ptr, double data)
        {
            mpv_set_property(ctx, name_ptr, mpv_format.Long, new IntPtr(
                BitConverter.ToInt64(BitConverter.GetBytes(data), 0)));
        }

        [DllImport("libmpv-2.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern mpv_set_property_result mpv_set_property(
            mpv_handle ctx,
            IntPtr name,
            mpv_format format,
            double data);

        [DllImport("libmpv-2.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern mpv_set_property_result mpv_set_property(
            mpv_handle ctx,
            IntPtr name,
            mpv_format format,
            long data);

        [DllImport("libmpv-2.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern mpv_set_property_string_result mpv_set_property_string(
            mpv_handle ctx,
            IntPtr name,
            IntPtr value_str_ptr);

        [DllImport("libmpv-2.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern mpv_del_property_result mpv_del_property(
            mpv_handle ctx,
            IntPtr name);

        [DllImport("libmpv-2.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern mpv_set_property_async_result mpv_set_property_async(
            mpv_handle ctx,
            long reply_userdata,
            IntPtr name,
            mpv_format format,
            IntPtr data);

        [DllImport("libmpv-2.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern mpv_get_property_result mpv_get_property(
            mpv_handle ctx,
            IntPtr name,
            mpv_format format,
            IntPtr data);

        public static object mpv_get_property(
            mpv_handle ctx,
            UnicodeBinaryString name_ptr,
            mpv_format format)
        {
            var data_ptr = Marshal.AllocHGlobal(IntPtr.Size);

            try
            {
                mpv_get_property(ctx, name_ptr.HGlobal, format, data_ptr).Assert(name_ptr, format);

                var data = Marshal.PtrToStructure<IntPtr>(data_ptr);
                try
                {
                    var result = data.ToObject(format);
                    return result;
                }
                finally
                {
                    mpv_memory.mpv_free(data, format);
                }
            }
            catch (MpvCallException ex)
            {
                if (ex.Error == mpv_error.PropertyUnavailable)
                {
                    Debug.WriteLine(string.Format(
                        "property {0} wasnt available yet", name_ptr.ToString()));
                    return null;
                }
                throw;
            }
            finally
            {
                Marshal.FreeHGlobal(data_ptr);
            }
        }

        [DllImport("libmpv-2.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr mpv_get_property_string(
            mpv_handle ctx,
            IntPtr name);

        public static string mpv_get_property_string(
            mpv_handle ctx, UnicodeBinaryString name_ptr)
        {
            IntPtr valuePtr = mpv_get_property_string(ctx, name_ptr.HGlobal);
            if (valuePtr == IntPtr.Zero)
                return null;

            try
            {
                var str = new UnicodeBinaryString(valuePtr);
                var valueString = str.ToString();
                return valueString;
            }
            finally
            {
                mpv_memory.mpv_free(valuePtr);
            }
        }

        [DllImport("libmpv-2.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern mpv_observe_property_result mpv_observe_property(
            mpv_handle ctx,
            long reply_userdata,
            IntPtr name,
            mpv_format format);

        [DllImport("libmpv-2.so", CallingConvention = CallingConvention.Cdecl)]
        public static extern mpv_unobserve_property_result mpv_unobserve_property(
            mpv_handle ctx, long registered_reply_userdata);
    }
}
