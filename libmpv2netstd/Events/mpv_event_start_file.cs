using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace libmpv2net
{
    /// <summary>
    /// When file was started
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct mpv_event_start_file
    {
        /// <summary>
        /// Playlist entry id of the file now loading, starting or
        /// generally just being commenced.
        /// </summary>
        public long playlist_entry_id;
    }
}
