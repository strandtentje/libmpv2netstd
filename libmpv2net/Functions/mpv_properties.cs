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
        [DllImport("libmpv-2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern mpv_set_property_result mpv_set_property(
            mpv_handle ctx,
            IntPtr name,
            mpv_format format,
            IntPtr data);

        public static void mpv_set_property(
            mpv_handle ctx, string name, mpv_format format, IntPtr data)
        {
            using (var name_ptr = name.ToMemory())
                mpv_set_property(ctx, name_ptr, format, data).Assert(name, data);
        }

        public static void mpv_set_property(
            mpv_handle ctx, string name, long data)
        {
            mpv_set_property(ctx, name, mpv_format.Long, new IntPtr(data));
        }
        public static void mpv_set_property(
            mpv_handle ctx, string name, double data)
        {
            mpv_set_property(ctx, name, mpv_format.Long, new IntPtr(
                BitConverter.ToInt64(BitConverter.GetBytes(data), 0)));
        }

        [DllImport("libmpv-2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern mpv_set_property_result mpv_set_property(
            mpv_handle ctx,
            IntPtr name,
            mpv_format format,
            double data);

        [DllImport("libmpv-2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern mpv_set_property_result mpv_set_property(
            mpv_handle ctx,
            IntPtr name,
            mpv_format format,
            long data);

        [DllImport("libmpv-2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern mpv_set_property_string_result mpv_set_property_string(
            mpv_handle ctx,
            IntPtr name,
            IntPtr value_str_ptr);

        public static void mpv_set_property_string(
            mpv_handle ctx, string name, string value)
        {
            using (var name_ptr = name.ToMemory())
            using (var value_ptr = value.ToMemory())
                mpv_set_property_string(ctx, name_ptr, value_ptr).Assert(name, value);
        }

        [DllImport("libmpv-2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern mpv_del_property_result mpv_del_property(
            mpv_handle ctx,
            IntPtr name);

        [DllImport("libmpv-2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern mpv_set_property_async_result mpv_set_property_async(
            mpv_handle ctx,
            long reply_userdata,
            IntPtr name,
            mpv_format format,
            IntPtr data);

        [DllImport("libmpv-2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern mpv_get_property_result mpv_get_property(
            mpv_handle ctx,
            IntPtr name,
            mpv_format format,
            IntPtr data);

        public static object mpv_get_property(
            mpv_handle ctx, string name, mpv_format format)
        {
            using (var name_ptr = name.ToMemory())
                return mpv_get_property(ctx, name, name_ptr, format);
        }

        public static object mpv_get_property(
            mpv_handle ctx,
            string name,
            IntPtr name_ptr,
            mpv_format format)
        {
            var data_ptr = Marshal.AllocHGlobal(IntPtr.Size);

            try
            {
                mpv_get_property(ctx, name_ptr, format, data_ptr).
                    Assert(name, format);

                var data = Marshal.PtrToStructure<IntPtr>(data_ptr);

                var result = data.ToObject(format);

                mpv_memory.mpv_free(data, format);

                return result;
            }
            catch(MpvCallException ex)
            {
                if (ex.Error == mpv_error.PropertyUnavailable)
                {
                    Debug.WriteLine(string.Format(
                        "property {0} wasnt available yet", name));
                    return null;
                }
                throw;
            }
            finally
            {
                Marshal.FreeHGlobal(data_ptr);
            }
        }

        [DllImport("libmpv-2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr mpv_get_property_string(
            mpv_handle ctx,
            IntPtr name);

        public static string mpv_get_property_string(
            mpv_handle ctx, string name)
        {
            using (var name_ptr = name.ToMemory())
            {
                IntPtr valuePtr = mpv_get_property_string(ctx, name_ptr);
                if (valuePtr == IntPtr.Zero)
                    return null;

                var valueString = Marshal.PtrToStringUni(valuePtr);
                mpv_memory.mpv_free(valuePtr);
                return valueString;
            }
        }

        [DllImport("libmpv-2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern mpv_observe_property_result mpv_observe_property(
            mpv_handle ctx,
            long reply_userdata,
            IntPtr name,
            mpv_format format);

        [DllImport("libmpv-2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern mpv_unobserve_property_result mpv_unobserve_property(
            mpv_handle ctx, long registered_reply_userdata);
    }
}
