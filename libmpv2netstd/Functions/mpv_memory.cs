using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace libmpv2net.Functions
{
    public static class mpv_memory
    {
        /// <summary>
        /// When the function documents it requires its return
        /// value to be freed, use this.
        /// </summary>
        /// <param name="data">Pointer to MPV-allocated data.</param>
        [DllImport("libmpv-2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void mpv_free(IntPtr data);

        public static void mpv_free(IntPtr data, mpv_format fmt)
        {
            switch (fmt)
            {
                case mpv_format.Node:
                    mpv_free_node_contents(data);
                    break;
                case mpv_format.String:
                case mpv_format.OsdString:
                case mpv_format.ByteArray:
                    mpv_free(data);
                    break;
                case mpv_format.NodeArray:
                    break;
                case mpv_format.NodeMap:
                    break;

                case mpv_format.None:
                case mpv_format.BoolFlag:
                case mpv_format.Long:
                case mpv_format.Double:                
                default:
                    break;
            }
        }

        /// <summary>
        /// Like mpv_free, but for nodes allocated by MPV. Does not
        /// de-allocate whatever is in the node.
        /// </summary>
        /// <param name="node"></param>
        [DllImport("libmpv-2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void mpv_free_node_contents(IntPtr node_ptr);
    }
}
