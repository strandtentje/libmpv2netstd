using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using libmpv2net;
using System.Runtime.InteropServices;

namespace LibMpvWrapper
{
    public delegate void StartFileEventHandler(object sender, StartFileEventArgs e);
    public class StartFileEventArgs
    {
        public readonly long PlaylistIndex;
        public StartFileEventArgs(long playlistIndex)
        {
            this.PlaylistIndex = playlistIndex;
        }

        public static StartFileEventArgs From(mpv_event evt)
        {
            if (evt.event_id != mpv_event_id.StartFile)
                throw new ArgumentException("may only use startfile events");
            var startEvent = (mpv_event_start_file)Marshal.PtrToStructure(
                evt.data, typeof(mpv_event_start_file));
            return new StartFileEventArgs(startEvent.playlist_entry_id);
        }
    }
}
