using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using libmpv2net;

namespace LibMpvWrapper
{
    public partial class MpvPlayer
    {
        private void StartPollingEvents()
        {
            var pollThread = new Thread(EventLoop);
            pollThread.Start();
        }
        private void EventLoop(object arg)
        {
            while (!this.IsDisposed)
            {
                var evt = mpv_events.mpv_wait_event(this, 0.3);
                DiscriminateEvent(evt);
            }
        }

        public event ErrorEventHandler Error;
        private void DiscriminateEvent(mpv_event evt)
        {
            if (EventWasError(evt))
                return;
            switch (evt.event_id)
            {
                case mpv_event_id.None:
                    break;
                case mpv_event_id.Shutdown:
                    this.Dispose();
                    break;
                case mpv_event_id.LogMessage:
                    IngestLogEvent(evt);
                    break;
                case mpv_event_id.GetPropertyReply:
                    // no async
                    break;
                case mpv_event_id.SetPropertyReply:
                    // no async
                    break;
                case mpv_event_id.CommandReply:
                    // no async
                    break;
                case mpv_event_id.StartFile:
                    IngestStartFile(evt);
                    break;
                case mpv_event_id.EndFile:
                    IngestEndFile(evt);
                    break;
                case mpv_event_id.FileLoaded:
                    IngestFileLoaded(evt);
                    break;
                case mpv_event_id.Idle:
                    IngestIdle(evt);
                    break;
                case mpv_event_id.Tick:
                    // no tick
                    break;
                case mpv_event_id.ClientMessage:
                    IngestClientMessage(evt);
                    break;
                case mpv_event_id.VideoReconfig:
                    IngestVideoReconfig(evt);
                    break;
                case mpv_event_id.AudioReconfig:
                    IngestAudioReconfig(evt);
                    break;
                case mpv_event_id.Seek:
                    IngestSeek(evt);
                    break;
                case mpv_event_id.PlaybackRestart:
                    IngestPlaybackRestart(evt);
                    break;
                case mpv_event_id.PropertyChange:
                    IngestPropertyChange(evt);
                    break;
                case mpv_event_id.QueueOverflow:
                    // whatever
                    break;
                case mpv_event_id.Hook:
                    // we don't hook
                    break;
                default:
                    break;
            }
        }

        private bool EventWasError(mpv_event evt)
        {
            ErrorEventArgs e;
            if (!ErrorEventArgs.TryFail(evt, out e))
                return false;
            else if (Error == null)
            {
                Console.Error.WriteLine(
                    "Received unhandled error event for {0}:{1}",
                    e.EventID.ToString(), e.ErrorCode.ToString());
                return true;
            }
            else
            {
                Error.Invoke(this, e);
                return true;
            }
        }

        private void IngestPropertyChange(mpv_event evt)
        {
            throw new NotImplementedException();
        }

        private void IngestPlaybackRestart(mpv_event evt)
        {
            throw new NotImplementedException();
        }

        private void IngestSeek(mpv_event evt)
        {
            throw new NotImplementedException();
        }

        private void IngestAudioReconfig(mpv_event evt)
        {
            throw new NotImplementedException();
        }

        private void IngestVideoReconfig(mpv_event evt)
        {
            throw new NotImplementedException();
        }

        private void IngestClientMessage(mpv_event evt)
        {
            throw new NotImplementedException();
        }

        private void IngestIdle(mpv_event evt)
        {
            throw new NotImplementedException();
        }

        private void IngestFileLoaded(mpv_event evt)
        {
            throw new NotImplementedException();
        }

        private void IngestEndFile(mpv_event evt)
        {
            throw new NotImplementedException();
        }

        public event StartFileEventHandler StartFile;
        private void IngestStartFile(mpv_event evt)
        {
            if (StartFile != null)
                StartFile.Invoke(this, StartFileEventArgs.From(evt));            
        }

        public event LogEventHandler Log;
        private void IngestLogEvent(mpv_event evt)
        {
            if (Log != null)
                Log.Invoke(this, LogEventArgs.From(evt));
        }

    }
}
