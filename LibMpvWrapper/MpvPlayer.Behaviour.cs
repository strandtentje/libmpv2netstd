using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using libmpv2net;
using libmpv2net.Functions;

namespace LibMpvWrapper
{
    public partial class MpvPlayer : IDisposable
    {
        public bool IsDisposed { get; private set; }
        public readonly mpv_handle Handle;
        public string SeekBehaviour { get; private set; }
        public string FrameStepAudio { get; private set; }
        public string FrameStepPlay { get; private set; }
        public string StopBehaviour { get; private set; }
        public string IdleAppendBehaviour { get; private set; }

        public MpvPlayer(mpv_handle handle)
        {
            this.Handle = handle;
            StartPollingEvents();
        }

        public bool IsSeekToKeyframes
        {
            get
            {
                return SeekBehaviour == "keyframes";
            }
            set
            {
                if (value)
                    SeekBehaviour = "keyframes";
                else
                    SeekBehaviour = null;
            }
        }

        public bool IsFramestepMuted
        {
            get
            {
                return FrameStepAudio == "mute";
            }
            set
            {
                if (value)
                    FrameStepAudio = "mute";
                else
                    FrameStepAudio = null;
            }
        }

        public bool IsFramestepImmediate
        {
            get
            {
                return FrameStepPlay == "seek";
            }
            set
            {
                if (value)
                    FrameStepPlay = "seek";
                else
                    FrameStepPlay = "play";
            }
        }

        public bool IsStopClear
        {
            get
            {
                return StopBehaviour == "keep-playlist";
            }
            set
            {
                if (value)
                    StopBehaviour = "keep-playlist";
                else
                    StopBehaviour = null;
            }
        }

        public bool IsPlayAfterAppend
        {
            get
            {
                return IdleAppendBehaviour == "play";
            }
            set
            {
                if (value)
                    IdleAppendBehaviour = "play";
                else
                    IdleAppendBehaviour = null;
            }
        }

        public static implicit operator mpv_handle(MpvPlayer player)
        {
            return player.Handle;
        }

        #region IDisposable Members

        private readonly object DisposeLock = new object();

        public void Dispose()
        {
            lock (DisposeLock)
            {
                if (this.IsDisposed) return;
                this.IsDisposed = true;
            }
            mpv_events.mpv_wakeup(this);
            mpv_initial.mpv_terminate_destroy(this);
        }

        #endregion
    }
}
