using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibMpvWrapper
{
    /// <summary>
    /// When to advance and terminate the mpv session
    /// </summary>
    public enum PlaylistLifecycle
    {
        /// <summary>
        /// When the playlist has run out and playback has stopped,
        /// MPV closes.
        /// </summary>
        CloseAfterEnd,
        /// <summary>
        /// When the playlist is about to advance, pause the player.
        /// Player will not close if the playlist has run out.
        /// </summary>
        DontAutoplay,
        /// <summary>
        /// When the playlist is done advancing and there are no 
        /// items left, pause instead of stopping the player.
        /// </summary>
        PauseAfterEnd,
    }
}
