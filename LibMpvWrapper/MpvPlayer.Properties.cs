using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using libmpv2net.Functions;
using libmpv2net;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace LibMpvWrapper
{
    public partial class MpvPlayer
    {
        private const string
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
            MUTE_RW = "mute";

        public string CurrentFileName
        {
            get
            {
                return mpv_properties.mpv_get_property_string(
                    this, FILENAME_PROPERTY_RO);
            }
        }

        public string CurrentFilePath
        {
            get
            {
                return mpv_properties.mpv_get_property_string(
                    this, PATH_PROPERTY_RO);
            }
        }

        public string CurrentTitle
        {
            get
            {
                return mpv_properties.mpv_get_property_string(
                    this, MEDIA_TITLE_PROPERTY_RO);
            }
        }

        public double CurrentDuration
        {
            get
            {
                if (mpv_properties.mpv_get_property(
                    this, DURATION_PROPERTY_RO, mpv_format.Double) is double dbl)
                    return dbl;
                Debug.WriteLine("Duration Property was null");
                return 0;
            }
        }

        public bool IsIdle
        {
            get
            {
                if (mpv_properties.mpv_get_property(
                    this, IDLE_ACTIVE_PROPERTY_RO, mpv_format.BoolFlag)
                    is bool bln)
                    return bln;
                Debug.WriteLine("Idle Property was null");
                return false;
            }
        }

        public bool IsEof
        {
            get
            {
                if (mpv_properties.mpv_get_property(
                    this, EOF_REACHED_PROPERTY_RO, mpv_format.BoolFlag)
                    is bool bln)
                    return bln;
                Debug.WriteLine("IsEOF Property was null");
                return false;
            }
        }

        public long PlaylistPlayingIndex
        {
            get
            {
                if (mpv_properties.mpv_get_property(
                    this, PLAYLIST_PLAYING_POS_PROPERTY_RO, mpv_format.Long)
                    is long lng)
                    return lng;
                Debug.WriteLine("Playlist playing pos property was null");
                return 0L;
            }
        }

        public long PlaylistCount
        {
            get
            {
                if (mpv_properties.mpv_get_property(
                    this, PLAYLIST_COUNT_PROPERTY_RO, mpv_format.Long)
                    is long lng)
                    return lng;
                Debug.WriteLine("Playlist Count property was null");
                return 0L;
            }
        }

        public string[] PlaylistFiles
        {
            get
            {
                string[] files = new string[PlaylistCount];
                for (int i = 0; i < files.Length; i++)
                {
                    string s = string.Format("playlist/{0}/filename", i);
                    files[i] = mpv_properties.mpv_get_property_string(
                        this, s);
                }
                return files;
            }
        }
        public string[] PlaylistTitles
        {
            get
            {
                string[] titles = new string[PlaylistCount];
                for (int i = 0; i < titles.Length; i++)
                {
                    string s = string.Format("playlist/{0}/title", i);
                    titles[i] = mpv_properties.mpv_get_property_string(
                        this, s);
                }
                return titles;
            }
        }
        public string[] PlaylistSources
        {
            get
            {
                string[] sources = new string[PlaylistCount];
                for (int i = 0; i < sources.Length; i++)
                {
                    string s = string.Format("playlist/{0}/playlist-path", i);
                    sources[i] = mpv_properties.mpv_get_property_string(
                        this, s);
                }
                return sources;
            }
        }
        public string[] PlaylistPlaying
        {
            get
            {
                string[] playings = new string[PlaylistCount];
                for (int i = 0; i < playings.Length; i++)
                {
                    string s = string.Format("playlist/{0}/playing", i);
                    playings[i] = mpv_properties.mpv_get_property_string(
                        this, s);
                }
                return playings;
            }
        }

        public PlaylistMember[] PlaylistMembers
        {
            get
            {
                var files = PlaylistFiles;
                var titles = PlaylistTitles;
                var sources = PlaylistSources;
                var playings = PlaylistPlaying;

                var count = Math.Min(Math.Min(files.Length, titles.Length), Math.Min(sources.Length, playings.Length));
                var members = new PlaylistMember[count];

                for (int i = 0; i < count; i++)
                {
                    members[i] = new PlaylistMember(i, files[i], titles[i], sources[i], playings[i]);
                }
                return members;
            }
        }

        private static readonly IntPtr
            YesStringPtr = "yes".ToMemory(),
            NoStringPtr = "no".ToMemory();

        public bool IsPause
        {
            get
            {
                if (mpv_properties.mpv_get_property(this,
                    PAUSE_PROPERTY_RW, mpv_format.BoolFlag) is bool bln)
                    return bln;
                Debug.WriteLine("Pause property was null");
                return false;
            }
            set
            {
                using (var n = PAUSE_PROPERTY_RW.ToMemory())
                    mpv_properties.mpv_set_property_string(
                        this, n, value ? YesStringPtr : NoStringPtr).
                        Assert(PAUSE_PROPERTY_RW, value);
            }
        }

        public bool Mute
        {
            get
            {
                if (mpv_properties.mpv_get_property(this, MUTE_RW, mpv_format.BoolFlag) is bool bln)
                    return bln;
                Debug.WriteLine("mute property was null");
                return false;
            }
            set
            {
                using (var n = MUTE_RW.ToMemory())
                    mpv_properties.mpv_set_property_string(
                        this, n, value ? YesStringPtr : NoStringPtr).Assert(MUTE_RW, value);
            }

        }
        public long PlaylistIndex
        {
            get
            {
                if (mpv_properties.mpv_get_property(this,
                    PERCENT_POS_PROPERTY_RW, mpv_format.Long) is long lng)
                    return lng;
                Debug.WriteLine("playlist index property was null");
                return 0L;
            }
            set
            {
                mpv_properties.mpv_set_property(this, PERCENT_POS_PROPERTY_RW, value);
            }
        }

        /// <summary>
        /// On transport controls as file repeat button
        /// </summary>
        public bool RepeatFile
        {
            get
            {
                return mpv_properties.mpv_get_property_string(
                    this, LOOP_FILE_PROPERTY_RW).ToLower() != "no";
            }
            set
            {
                mpv_properties.mpv_set_property_string(
                    this, LOOP_FILE_PROPERTY_RW, value ? "inf" : "no");
            }
        }

        /// <summary>
        /// On playlist controls as playlist repeat button
        /// </summary>
        public bool RepeatPlaylist
        {
            get
            {
                var v = mpv_properties.mpv_get_property_string(
                    this, LOOP_PLAYLIST_PROPERTY_RW).ToLower().Trim();
                switch (v)
                {
                    case "inf":
                        return true;
                    case "no":
                        return false;
                    default:
                        Debug.WriteLine("loop playlist property was null");
                        return false;
                }
            }
            set
            {
                mpv_properties.mpv_set_property_string(
                    this, LOOP_PLAYLIST_PROPERTY_RW, value ? "inf" : "no");
            }
        }

        /// <summary>
        /// Shown by transport controls trackbar and textbox
        /// </summary>
        public double CurrentPercentagePosition
        {
            get
            {
                var v = mpv_properties.mpv_get_property(this, PERCENT_POS_PROPERTY_RW,
                    mpv_format.Double);
                if (v is double dbl)
                    return dbl;
                Debug.WriteLine("current % pos was null");
                return 0.0;
            }
            set
            {
                mpv_properties.mpv_set_property(this, PERCENT_POS_PROPERTY_RW, value);
            }
        }

        /// <summary>
        /// Shown by transport controls textbox
        /// </summary>
        public double CurrentTimePosition
        {
            get
            {
                var v = mpv_properties.mpv_get_property(this,
                    TIME_POS_PROPERTY_RW, mpv_format.Double);
                if (v is double dbl)
                    return dbl;

                Debug.WriteLine("time pos property was null");
                return 0;
            }
            set
            {
                mpv_properties.mpv_set_property(this, TIME_POS_PROPERTY_RW, value);
            }
        }
    }
}
