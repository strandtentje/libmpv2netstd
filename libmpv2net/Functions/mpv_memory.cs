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
        /// <summary>
        /// Like mpv_free, but for nodes allocated by MPV. Does not
        /// de-allocate whatever is in the node.
        /// </summary>
        /// <param name="node"></param>
        [DllImport("libmpv-2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void mpv_free_node_contents(mpv_node_pointer node);
    }
}
