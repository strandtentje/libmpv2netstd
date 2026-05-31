using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using libmpv2net;
using libmpv2net.Functions;

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
                var evtPtr = mpv_events.mpv_wait_event(this, 0.3);
                          
                var evt = Marshal.PtrToStructure<mpv_event>(evtPtr);

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
                case mpv_event_id.VideoReconfig:
                    IngestVideoReconfig(evt);
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
                    Console.Error.WriteLine("MPV Queue Overflow!");
                    break;
                case mpv_event_id.AudioReconfig:
                    // this shouldn't really happen
                    Console.Error.WriteLine("Audio Reconfig for some reason.");
                    break;
                case mpv_event_id.Hook:
                case mpv_event_id.Tick:
                case mpv_event_id.GetPropertyReply:
                case mpv_event_id.SetPropertyReply:
                case mpv_event_id.CommandReply:
                case mpv_event_id.ClientMessage:
                    // unused features
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

        public event PropertyChangeEventHandler PropertyChanged;
        private void IngestPropertyChange(mpv_event evt)
        {
            if (!WatchedPropertyIdNames.TryGetValue(evt.reply_userdata, out string name))
            {
                Debug.WriteLine("Received event for unwatched property");
                return;
            }

            var e = new PropertyChangeEventArgs(name);

            ThreadPool.QueueUserWorkItem(_ =>
            {
                if (PropertyChanged != null)
                    PropertyChanged.Invoke(this, e);
                HandlePropertyChange(e);
            });
        }

        public event EventHandler PlaybackRestart;
        private void IngestPlaybackRestart(mpv_event evt)
        {
            if (PlaybackRestart == null)
                return;
            ThreadPool.QueueUserWorkItem(_ =>
            {
                PlaybackRestart.Invoke(this, EventArgs.Empty);
            });
        }

        public event EventHandler Seek;
        private void IngestSeek(mpv_event evt)
        {
            if (Seek == null)
                return;
            ThreadPool.QueueUserWorkItem(_ =>
            {
                Seek.Invoke(this, EventArgs.Empty);
            });
        }

        public event EventHandler VideoReconfig;
        private void IngestVideoReconfig(mpv_event evt)
        {
            if (VideoReconfig == null)
                return;
            ThreadPool.QueueUserWorkItem(_ =>
            {
                VideoReconfig.Invoke(this, EventArgs.Empty);
            });
        }

        public event EventHandler Idle;
        private void IngestIdle(mpv_event evt)
        {
            if (Idle == null)
                return;
            ThreadPool.QueueUserWorkItem(_ =>
            {
                Idle.Invoke(this, EventArgs.Empty);
            });
        }

        public event EventHandler FileLoaded;
        private void IngestFileLoaded(mpv_event evt)
        {
            if (FileLoaded == null)
                return;
            ThreadPool.QueueUserWorkItem(_ =>
            {
                FileLoaded.Invoke(this, EventArgs.Empty);
            });
        }

        public event EndFileEventHandler EndOfFile, Stopped, Quit, FileError, Redirect;
        private void IngestEndFile(mpv_event evt)
        {
            mpv_end_file_reason reason;
            var e = EndFileEventArgs.From(evt, out reason);
            ThreadPool.QueueUserWorkItem(_ =>
            {
                switch (reason)
                {
                    case mpv_end_file_reason.Eof:
                        if (EndOfFile != null)
                            EndOfFile.Invoke(this, e);
                        break;
                    case mpv_end_file_reason.Stop:
                        if (Stopped != null)
                            Stopped.Invoke(this, e);
                        break;
                    case mpv_end_file_reason.Quit:
                        if (Quit != null)
                            Quit.Invoke(this, e);
                        Dispose();
                        break;
                    case mpv_end_file_reason.Error:
                        if (FileError != null)
                            FileError.Invoke(this, e);
                        break;
                    case mpv_end_file_reason.Redirect:
                        if (Redirect != null)
                            Redirect.Invoke(this, e);
                        break;
                    default:
                        break;
                }
            });            
        }

        public event StartFileEventHandler StartFile;
        private void IngestStartFile(mpv_event evt)
        {
            if (StartFile == null)
                return;

            var e = StartFileEventArgs.From(evt);
            ThreadPool.QueueUserWorkItem(_ =>
            {
                StartFile.Invoke(this, e);
            });
        }

        private void IngestLogEvent(mpv_event evt)
        {

        }

    }
}
