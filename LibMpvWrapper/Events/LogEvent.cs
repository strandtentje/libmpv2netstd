using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using libmpv2net;
using System.Runtime.InteropServices;

namespace LibMpvWrapper
{
    public delegate void LogEventHandler(object sender, LogEventArgs e);
    public class LogEventArgs : EventArgs
    {
        public readonly mpv_log_level Level;
        public readonly string Prefix, Text;
        public LogEventArgs(mpv_log_level level, string prefix, string text)
        {
            this.Level = level;
            this.Prefix = prefix;
            this.Text = text;
        }
        public static LogEventArgs From(mpv_event evt)
        {
            if (evt.event_id != mpv_event_id.LogMessage)
                throw new ArgumentException("may only use logmessage events");
            var logMessage = (mpv_event_log_message)Marshal.PtrToStructure(
                evt.data, typeof(mpv_event_log_message));
            return new LogEventArgs(logMessage.level, logMessage.prefix, 
                logMessage.text);
        }
    }

}
