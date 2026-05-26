using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace libmpv2net
{
    /// <summary>
    /// Useful when passing a node to a function. Always 
    /// check the accompanied mpv_format before definitively
    /// assuming this points to a node.
    /// </summary>
    public struct mpv_node_pointer
    {
        public IntPtr handle;
    }
}
