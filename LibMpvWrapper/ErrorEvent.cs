using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using libmpv2net;

namespace LibMpvWrapper
{
    public delegate void ErrorEventHandler(object sender, ErrorEventArgs e);
    public class ErrorEventArgs
    {
        public readonly mpv_event_id EventID;
        public readonly mpv_error ErrorCode;
        public ErrorEventArgs(mpv_event_id id, mpv_error errorCode)
        {
            this.EventID = id;
            this.ErrorCode = errorCode;
        }
        public static bool TryFail(mpv_event evt, out ErrorEventArgs e)
        {
            if (evt.error >= 0) 
            {
                e = null;
                return false;
            }
            else if (evt.error < -20)
            {
                e = new ErrorEventArgs(evt.event_id, mpv_error.Generic);
                return true;
            }
            else
            {
                e = new ErrorEventArgs(evt.event_id, (mpv_error)evt.error);
                return true;
            }
        }
    }
}
