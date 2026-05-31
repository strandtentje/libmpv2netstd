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
        internal const string
            FILENAME_PROPERTY_RO = "filename",
            PATH_PROPERTY_RO = "path",
            MEDIA_TITLE_PROPERTY_RO = "media-title",
            DURATION_PROPERTY_RO = "duration",
            IDLE_ACTIVE_PROPERTY_RO = "idle-active",
            EOF_REACHED_PROPERTY_RO = "eof-reached",
            PLAYLIST_PLAYING_POS_PROPERTY_RO = "playlist-playing-pos",
            PLAYLIST_COUNT_PROPERTY_RO = "playlist-count",
            PAUSE_PROPERTY_RW = "pause",
            PLAYLIST_POS_PROPERTY_RW = "playlist-pos",
            LOOP_FILE_PROPERTY_RW = "loop-file",
            LOOP_PLAYLIST_PROPERTY_RW = "loop-playlist",
            PERCENT_POS_PROPERTY_RW = "percent-pos",
            TIME_POS_PROPERTY_RW = "time-pos",
            MUTE_RW = "mute",
            KEEPASPECT_WINDOW_RW = "keepaspect-window",
            FULLSCREEN_RW = "fullscreen",
            FS_MONITOR_RW = "fs-screen";

        private readonly UnicodeBinaryString
            STR_FILENAME_PROPERTY_RO = UnicodeBinaryString.From(FILENAME_PROPERTY_RO),
            STR_PATH_PROPERTY_RO = UnicodeBinaryString.From(PATH_PROPERTY_RO),
            STR_MEDIA_TITLE_PROPERTY_RO = UnicodeBinaryString.From(MEDIA_TITLE_PROPERTY_RO),
            STR_DURATION_PROPERTY_RO = UnicodeBinaryString.From(DURATION_PROPERTY_RO),
            STR_IDLE_ACTIVE_PROPERTY_RO = UnicodeBinaryString.From(IDLE_ACTIVE_PROPERTY_RO),
            STR_EOF_REACHED_PROPERTY_RO = UnicodeBinaryString.From(EOF_REACHED_PROPERTY_RO),
            STR_PLAYLIST_PLAYING_POS_PROPERTY_RO = UnicodeBinaryString.From(PLAYLIST_PLAYING_POS_PROPERTY_RO),
            STR_PLAYLIST_COUNT_PROPERTY_RO = UnicodeBinaryString.From(PLAYLIST_COUNT_PROPERTY_RO),
            STR_PAUSE_PROPERTY_RW = UnicodeBinaryString.From(PAUSE_PROPERTY_RW),
            STR_PLAYLIST_POS_PROPERTY_RW = UnicodeBinaryString.From(PLAYLIST_POS_PROPERTY_RW),
            STR_LOOP_FILE_PROPERTY_RW = UnicodeBinaryString.From(LOOP_FILE_PROPERTY_RW),
            STR_LOOP_PLAYLIST_PROPERTY_RW = UnicodeBinaryString.From(LOOP_PLAYLIST_PROPERTY_RW),
            STR_PERCENT_POS_PROPERTY_RW = UnicodeBinaryString.From(PERCENT_POS_PROPERTY_RW),
            STR_TIME_POS_PROPERTY_RW = UnicodeBinaryString.From(TIME_POS_PROPERTY_RW),
            STR_MUTE_RW = UnicodeBinaryString.From(MUTE_RW),
            STR_KEEPASPECT_WINDOW_RW = UnicodeBinaryString.From(KEEPASPECT_WINDOW_RW),
            STR_FULLSCREEN_RW = UnicodeBinaryString.From(FULLSCREEN_RW),
            STR_FS_MONITOR_RW = UnicodeBinaryString.From(FS_MONITOR_RW);

        private readonly UnicodeBinaryString
            STR_YES = UnicodeBinaryString.From("yes"),
            STR_NO = UnicodeBinaryString.From("no"),
            STR_INF = UnicodeBinaryString.From("inf");

        private void DisposePropertyNames()
        {
            STR_FILENAME_PROPERTY_RO.Dispose();
            STR_PATH_PROPERTY_RO.Dispose();
            STR_MEDIA_TITLE_PROPERTY_RO.Dispose();
            STR_DURATION_PROPERTY_RO.Dispose();
            STR_IDLE_ACTIVE_PROPERTY_RO.Dispose();
            STR_EOF_REACHED_PROPERTY_RO.Dispose();
            STR_PLAYLIST_PLAYING_POS_PROPERTY_RO.Dispose();
            STR_PLAYLIST_COUNT_PROPERTY_RO.Dispose();
            STR_PAUSE_PROPERTY_RW.Dispose();
            STR_PLAYLIST_POS_PROPERTY_RW.Dispose();
            STR_LOOP_FILE_PROPERTY_RW.Dispose();
            STR_LOOP_PLAYLIST_PROPERTY_RW.Dispose();
            STR_PERCENT_POS_PROPERTY_RW.Dispose();
            STR_TIME_POS_PROPERTY_RW.Dispose();
            STR_MUTE_RW.Dispose();
            STR_KEEPASPECT_WINDOW_RW.Dispose();
            STR_FULLSCREEN_RW.Dispose();
            STR_FS_MONITOR_RW.Dispose();
            STR_YES.Dispose();
            STR_NO.Dispose();
            STR_INF.Dispose();
        }
    }
}
