using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace libmpv2net
{
    /// <summary>
    /// End of File event
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public class mpv_event_end_file
    {
        public mpv_end_file_reason reason;
        /// <summary>
        /// May be negative if the reason is "error"
        /// </summary>
        public int error;
        /// <summary>
        /// Entry id that used to play, but no more.
        /// </summary>
        public long playlist_entry_id;
        /// <summary>
        /// If a new playlist or file was queued up after 
        /// playlist_entry_id, this id is the id of that item,
        /// or the first id of that playlist.
        /// </summary>
        public long playlist_insert_id;
        /// <summary>
        /// Total number of remaining entries in upcoming playlist.
        /// </summary>
        public int playlist_insert_num_entries;
    }
}
