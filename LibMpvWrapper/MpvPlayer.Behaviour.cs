using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        /// <summary>
        /// Is under transport controls as radio btns
        /// </summary>
        public string StopBehaviour { get; private set; }
        /// <summary>
        /// Is under playlist controls under auto play
        /// </summary>
        public string IdleAppendBehaviour { get; private set; }

        public MpvPlayer(mpv_handle handle, bool watchProperties = true)
        {
            var version = mpv_initial.mpv_client_api_version();
            Debug.WriteLine(version);

            var pl = mpv_properties.mpv_get_property(
                handle, "property-list", mpv_format.String);

            Debug.WriteLine(pl);

            this.Handle = handle;
            StartPollingEvents();
            if (!watchProperties) return;
            this.WatchPropertyNone(
                "filename", "path", "media-title", "duration", "percent-pos", "time-pos", "playlist-playing-pos", 
                "playlist-count", "playlist-pos", "idle-active", "eof-reached", "pause", "loop-file", "loop-playlist");            
        }

        /// <summary>
        /// Is seek to keyframes checkbox in transport controls.
        /// </summary>
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

        /// <summary>
        /// Is mute during framestep in transport controls
        /// </summary>
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

        /// <summary>
        /// Is play after frameskip checkbox in transport controls
        /// </summary>
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


        /// <summary>
        /// Is under transport controls under checkbox stop-clear
        /// </summary>
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

        /// <summary>
        /// Is under playlist controls as auto play button
        /// </summary>
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
