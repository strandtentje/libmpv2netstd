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
        /// <summary>
        /// Is under transport controls as radio btns
        /// </summary>

        public MpvPlayer(mpv_handle handle, bool watchProperties = true)
        {
            this.Handle = handle;
            this.PropertyPoller = new System.Threading.Timer(
                new System.Threading.TimerCallback(PollPropertiesLoop), null, 100, 100);
            StartPollingEvents();
            if (!watchProperties) return;
            this.WatchPropertyNone(
                STR_FILENAME_PROPERTY_RO, 
                STR_PATH_PROPERTY_RO, 
                STR_MEDIA_TITLE_PROPERTY_RO, 
                STR_DURATION_PROPERTY_RO,
                STR_PERCENT_POS_PROPERTY_RW, 
                STR_TIME_POS_PROPERTY_RW, 
                STR_PLAYLIST_PLAYING_POS_PROPERTY_RO,
                STR_PLAYLIST_COUNT_PROPERTY_RO, 
                STR_PLAYLIST_POS_PROPERTY_RW, 
                STR_IDLE_ACTIVE_PROPERTY_RO,
                STR_EOF_REACHED_PROPERTY_RO,
                STR_PAUSE_PROPERTY_RW, 
                STR_LOOP_FILE_PROPERTY_RW, 
                STR_LOOP_PLAYLIST_PROPERTY_RW,
                STR_MUTE_RW);
        }

        /// <summary>
        /// Is seek to keyframes checkbox in transport controls.
        /// </summary>
        public bool IsSeekToKeyframes { get; set; }

        /// <summary>
        /// Is mute during framestep in transport controls
        /// </summary>
        public bool IsFramestepMuted { get; set; }

        /// <summary>
        /// Is play after frameskip checkbox in transport controls
        /// </summary>
        public bool IsFramestepImmediate { get; set; }


        /// <summary>
        /// Is under transport controls under checkbox stop-clear
        /// </summary>
        public bool IsStopClear { get; set; }

        /// <summary>
        /// Is under playlist controls as auto play button
        /// </summary>
        public bool IsPlayAfterAppend { get; set; }

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
            try
            {
                mpv_events.mpv_wakeup(this);
                mpv_initial.mpv_terminate_destroy(this);
            }
            finally
            {
                DisposeCommandNames();
                DisposePropertyNames();
            }
        }

        #endregion
    }
}
