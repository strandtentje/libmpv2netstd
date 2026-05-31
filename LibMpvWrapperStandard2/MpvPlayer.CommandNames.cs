
using libmpv2net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibMpvWrapper
{
    public partial class MpvPlayer
    {
        internal readonly UnicodeBinaryString
            STR_PLAYLIST_NEXT = UnicodeBinaryString.From("playlist-next"),
            STR_PLAYLIST_PREV = UnicodeBinaryString.From("playlist-prev"),
            STR_PLAYLIST_NEXT_PLAYLIST = UnicodeBinaryString.From("playlist-next-playlist"),
            STR_PLAYLIST_PREV_PLAYLIST = UnicodeBinaryString.From("playlist-prev-playlist"),
            STR_PLAYLIST_PLAY_INDEX = UnicodeBinaryString.From("playlist-play-index"),
            STR_NONE = UnicodeBinaryString.From("none"),
            STR_CURRENT = UnicodeBinaryString.From("current"),
            STR_PLAYLIST_CLEAR = UnicodeBinaryString.From("playlist-clear"),
            STR_PLAYLIST_REMOVE = UnicodeBinaryString.From("playlist-remove"),
            STR_LOADFILE = UnicodeBinaryString.From("loadfile"),
            STR_LOADLIST = UnicodeBinaryString.From("loadlist"),
            STR_APPEND = UnicodeBinaryString.From("append"),
            STR_APPEND_PLAY = UnicodeBinaryString.From("append+play");

        internal readonly UnicodeBinaryString
            STR_SEEK = UnicodeBinaryString.From("seek"),
            STR_ABSOLUTE = UnicodeBinaryString.From("absolute"),
            STR_ABSOLUTE_PERCENT = UnicodeBinaryString.From("absolute-percent"),
            STR_RELATIVE = UnicodeBinaryString.From("relative"),
            STR_RELATIVE_PERCENT = UnicodeBinaryString.From("relative-percent"),
            STR_FRAME_STEP = UnicodeBinaryString.From("frame-step"),
            STR_STOP = UnicodeBinaryString.From("stop"),
            STR_KEYFRAMES = UnicodeBinaryString.From("keyframes"),
            STR_MUTE = UnicodeBinaryString.From("mute"),
            STR_PLAY = UnicodeBinaryString.From("play"),
            STR_KEEP_PLAYLIST = UnicodeBinaryString.From("keep-playlist");

        private void DisposeCommandNames()
        {
            STR_PLAYLIST_NEXT.Dispose();
            STR_PLAYLIST_PREV.Dispose();
            STR_PLAYLIST_NEXT_PLAYLIST.Dispose();
            STR_PLAYLIST_NEXT_PLAYLIST.Dispose();
            STR_PLAYLIST_PLAY_INDEX.Dispose();
            STR_NONE.Dispose();
            STR_CURRENT.Dispose();
            STR_PLAYLIST_CLEAR.Dispose();
            STR_PLAYLIST_REMOVE.Dispose();
            STR_LOADFILE.Dispose();
            STR_LOADLIST.Dispose();
            STR_APPEND.Dispose();
            STR_APPEND_PLAY.Dispose();

            STR_SEEK.Dispose();
            STR_ABSOLUTE.Dispose();
            STR_ABSOLUTE_PERCENT.Dispose();
            STR_RELATIVE.Dispose();
            STR_RELATIVE_PERCENT.Dispose();
            STR_FRAME_STEP.Dispose();
            STR_STOP.Dispose();
            STR_KEYFRAMES.Dispose();
            STR_MUTE.Dispose();
            STR_PLAY.Dispose();
            STR_KEEP_PLAYLIST.Dispose();
        }
    }
}
