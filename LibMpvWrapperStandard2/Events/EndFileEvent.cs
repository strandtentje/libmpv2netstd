using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using libmpv2net;
using System.Runtime.InteropServices;

namespace LibMpvWrapper
{
    public delegate void EndFileEventHandler(object sender, EndFileEventArgs e);
    public class EndFileEventArgs : EventArgs
    {
        public readonly mpv_error Error;
        public readonly long EntryId, InsertId;
        public readonly int EntryCount;
        public EndFileEventArgs(mpv_error error, long entryId, long insertId,
            int entryCount)
        {
            this.Error = error;
            this.EntryId = entryId;
            this.InsertId = insertId;
            this.EntryCount = entryCount;
        }
        public static EndFileEventArgs From(mpv_event evt, 
            out mpv_end_file_reason reason)
        {
            if (evt.event_id != mpv_event_id.EndFile)
                throw new ArgumentException("can only use this with endfile evt");
            var endEvent = (mpv_event_end_file)Marshal.PtrToStructure(
                evt.data, typeof(mpv_event_end_file));
            reason = endEvent.reason;
            return new EndFileEventArgs(                
                (mpv_error)endEvent.error,
                endEvent.playlist_entry_id,
                endEvent.playlist_insert_id,
                endEvent.playlist_insert_num_entries);
        }
    }
}
