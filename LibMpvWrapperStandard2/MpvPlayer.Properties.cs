using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using libmpv2net.Functions;
using libmpv2net;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Globalization;

namespace LibMpvWrapper
{
    public partial class MpvPlayer
    {
        public string CurrentFileName
        {
            get
            {
                return mpv_properties.mpv_get_property_string(
                    this, STR_FILENAME_PROPERTY_RO);
            }
        }

        public double Speed
        {
            get
            {
                return double.TryParse(
                    mpv_properties.mpv_get_property_string(this, STR_SPEED_RW),
                    NumberStyles.Any, CultureInfo.InvariantCulture, out double spd)
                    ? spd
                    : 1;
            }
            set
            {
                using (var ubs = UnicodeBinaryString.From(value.ToString(CultureInfo.InvariantCulture)))
                    mpv_properties.mpv_set_property_string(this, STR_SPEED_RW.HGlobal, ubs.HGlobal);
            }
        }

        public string CurrentFilePath
        {
            get
            {
                return mpv_properties.mpv_get_property_string(
                    this, STR_PATH_PROPERTY_RO);
            }
        }

        public string CurrentTitle
        {
            get
            {
                return mpv_properties.mpv_get_property_string(
                    this, STR_MEDIA_TITLE_PROPERTY_RO);
            }
        }

        public double CurrentDuration
        {
            get
            {
                if (mpv_properties.mpv_get_property(
                        this, STR_DURATION_PROPERTY_RO, mpv_format.Double) is double dbl)
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
                        this, STR_IDLE_ACTIVE_PROPERTY_RO, mpv_format.BoolFlag)
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
                        this, STR_EOF_REACHED_PROPERTY_RO, mpv_format.BoolFlag)
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
                        this, STR_PLAYLIST_PLAYING_POS_PROPERTY_RO, mpv_format.Long)
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
                        this, STR_PLAYLIST_COUNT_PROPERTY_RO, mpv_format.Long)
                    is long lng)
                    return lng;
                Debug.WriteLine("Playlist Count property was null");
                return 0L;
            }
        }

        public int DisplayWidth
        {
            get
            {
                var widthString = mpv_properties.mpv_get_property_string(
                    this, STR_DISPLAY_WIDTH_RO);
                return !string.IsNullOrWhiteSpace(widthString) && int.TryParse(widthString, out int widthInt)
                    ? widthInt
                    : -1;
            }
        }

        public int DisplayHeight
        {
            get
            {
                var heightString = mpv_properties.mpv_get_property_string(
                    this, STR_DISPLAY_HEIGHT_RO);
                return !string.IsNullOrWhiteSpace(heightString) && int.TryParse(heightString, out int heightInt)
                    ? heightInt
                    : -1;
            }
        }

        public string[] PlaylistFiles => GetPlaylistQueueFiles(0);

        public string[] GetPlaylistQueueFiles(int startAt, int cap = -1) =>
            EnumeratePlaylistQueueFiles(startAt, cap).ToArray();

        public IEnumerable<string> EnumeratePlaylistQueueFiles(int startAt, int cap = -1)
        {
            var pc = PlaylistCount;
            var size = pc - startAt;

            if (cap != -1)
                size = Math.Min(size, cap);

            if (size < 1) yield break;

            var ph = new string('0', pc.ToString(CultureInfo.InvariantCulture).Length);
            using (var sptr = UnicodeBinaryString.From(string.Format("playlist/{0}/filename", ph)))
                for (int i = startAt; i < startAt + size; i++)
                {
                    var qry = sptr.Overwrite(i.ToString(ph), "playlist/".Length);
                    // Debug.WriteLine(qry.ToString());
                    yield return mpv_properties.mpv_get_property_string(this, qry);
                }
        }

        public string[] GetPlaylistHistoricFiles(int startAt, int cap = -1) =>
            EnumeratePlaylistHistoricFiles(startAt, cap).ToArray();

        public IEnumerable<string> EnumeratePlaylistHistoricFiles(int startAt, int cap = -1)
        {
            var size = startAt;
            if (cap != -1)
                size = Math.Min(size, cap);

            var ph = new string('0', startAt.ToString(CultureInfo.InvariantCulture).Length);
            using (var sptr = UnicodeBinaryString.From(string.Format("playlist/{0}/filename", ph)))
                for (int i = 0; i < size; i++)
                {
                    var qry = sptr.Overwrite(i.ToString(ph), "playlist/".Length);
                    yield return mpv_properties.mpv_get_property_string(this, qry);
                }
        }

        public string[] PlaylistTitles => GetPlaylistQueueTitles(0);

        public string[] GetPlaylistQueueTitles(int startAt, int cap = -1) =>
            EnumeratePlaylistQueueTitles(startAt, cap).ToArray();

        public IEnumerable<string> EnumeratePlaylistQueueTitles(int startAt, int cap = -1)
        {
            var pc = PlaylistCount;
            var size = pc - startAt;

            if (cap != -1)
                size = Math.Min(size, cap);

            if (size < 1) yield break;

            var ph = new string('0', pc.ToString(CultureInfo.InvariantCulture).Length);
            using (var sptr = UnicodeBinaryString.From(string.Format("playlist/{0}/title", ph)))
                for (int i = startAt; i < startAt + size; i++)
                    yield return mpv_properties.mpv_get_property_string(this,
                        sptr.Overwrite(i.ToString(ph), "playlist/".Length));
        }

        public string[] GetPlaylistHistoricTitles(int startAt, int cap = -1) =>
            EnumeratePlaylistHistoricTitles(startAt, cap).ToArray();

        public IEnumerable<string> EnumeratePlaylistHistoricTitles(int startAt, int cap = -1)
        {
            var size = startAt;
            if (cap != -1)
                size = Math.Min(size, cap);

            var ph = new string('0', startAt.ToString(CultureInfo.InvariantCulture).Length);
            using (var sptr = UnicodeBinaryString.From(string.Format("playlist/{0}/title", ph)))
                for (int i = 0; i < size; i++)
                {
                    var qry = sptr.Overwrite(i.ToString(ph), "playlist/".Length);
                    yield return mpv_properties.mpv_get_property_string(this, qry);
                }
        }

        public (string file, string title)[] GetHistoryFileTitles(int startAt, int cap) =>
            GetPlaylistHistoricFiles(startAt, cap).Zip(GetPlaylistHistoricTitles(startAt, cap),
                (s, s1) => (s, s1)).ToArray();

        public (string file, string title)[] GetQueueFileTitles(int startAt, int cap) =>
            GetPlaylistQueueFiles(startAt, cap).Zip(GetPlaylistQueueTitles(startAt, cap),
                (s, s1) => (s, s1)).ToArray();

        public string[] PlaylistSources => EnumeratePlaylistSources().ToArray();

        public IEnumerable<string> EnumeratePlaylistSources()
        {
            var ph = new string('0', PlaylistCount.ToString(CultureInfo.InvariantCulture).Length);
            using (var sptr = UnicodeBinaryString.From(string.Format("playlist/{0}/playlist-path", ph)))
                for (int i = 0; i < PlaylistCount; i++)
                    yield return mpv_properties.mpv_get_property_string(this,
                        sptr.Overwrite(i.ToString(ph), "playlist/".Length));
        }

        public string[] PlaylistPlaying => EnumeratePlaylistPlaying().ToArray();

        public IEnumerable<string> EnumeratePlaylistPlaying()
        {
            var ph = new string('0', PlaylistCount.ToString(CultureInfo.InvariantCulture).Length);
            using (var sptr = UnicodeBinaryString.From(string.Format("playlist/{0}/playing", ph)))
                for (int i = 0; i < PlaylistCount; i++)
                    yield return mpv_properties.mpv_get_property_string(this,
                        sptr.Overwrite(i.ToString(ph), "playlist/".Length));
        }

        public IEnumerable<PlaylistMember> EnumeratePlaylistMembers()
        {
            using (var fileEnumerator = EnumeratePlaylistQueueFiles(0).GetEnumerator())
            using (var titleEnumerator = EnumeratePlaylistQueueTitles(0).GetEnumerator())
            using (var sourceEnumerator = EnumeratePlaylistSources().GetEnumerator())
            using (var playingEnumerator = EnumeratePlaylistSources().GetEnumerator())
                for (int i = 0;
                     fileEnumerator.MoveNext() && titleEnumerator.MoveNext() && sourceEnumerator.MoveNext() &&
                     playingEnumerator.MoveNext();
                     i++)
                    yield return new PlaylistMember(i, fileEnumerator.Current, titleEnumerator.Current,
                        sourceEnumerator.Current, playingEnumerator.Current);
        }

        public PlaylistMember[] PlaylistMembers => EnumeratePlaylistMembers().ToArray();

        public bool IsPause
        {
            get
            {
                if (mpv_properties.mpv_get_property(this, STR_PAUSE_PROPERTY_RW, mpv_format.BoolFlag) is bool bln)
                    return bln;
                Debug.WriteLine("Pause property was null");
                return false;
            }
            set
            {
                var choice = value ? STR_YES : STR_NO;
                mpv_properties.mpv_set_property_string(this,
                    STR_PAUSE_PROPERTY_RW.HGlobal, choice.HGlobal).Assert(STR_PAUSE_PROPERTY_RW, choice);
            }
        }

        public bool IsFullscreen
        {
            get
            {
                if (mpv_properties.mpv_get_property(this, STR_FULLSCREEN_RW,
                        mpv_format.BoolFlag) is bool bln)
                    return bln;
                Debug.WriteLine("Fullscreen property was null");
                return false;
            }
            set
            {
                var choice = value ? STR_YES : STR_NO;
                mpv_properties.mpv_set_property_string(this,
                    STR_FULLSCREEN_RW.HGlobal, choice.HGlobal).Assert(
                    STR_FULLSCREEN_RW, choice);
            }
        }

        public bool IsAspectLocked
        {
            get
            {
                if (mpv_properties.mpv_get_property(this, STR_KEEPASPECT_WINDOW_RW,
                        mpv_format.BoolFlag) is bool bln)
                    return bln;
                Debug.WriteLine("keepaspect property was null");
                return false;
            }
            set
            {
                var choice = value ? STR_YES : STR_NO;
                mpv_properties.mpv_set_property_string(this,
                    STR_KEEPASPECT_WINDOW_RW.HGlobal, choice.HGlobal).Assert(
                    STR_KEEPASPECT_WINDOW_RW, choice);
            }
        }

        public bool IsMute
        {
            get
            {
                if (mpv_properties.mpv_get_property(this, STR_MUTE, mpv_format.BoolFlag) is bool bln)
                    return bln;
                Debug.WriteLine("mute property was null");
                return false;
            }
            set
            {
                var choice = value ? STR_YES : STR_NO;
                mpv_properties.mpv_set_property_string(this, STR_MUTE_RW.HGlobal, choice.HGlobal)
                    .Assert(STR_MUTE_RW, choice);
            }
        }

        public long PlaylistIndex
        {
            get
            {
                if (mpv_properties.mpv_get_property(this,
                        STR_PERCENT_POS_PROPERTY_RW, mpv_format.Long) is long lng)
                    return lng;
                Debug.WriteLine("playlist index property was null");
                return 0L;
            }
            set { mpv_properties.mpv_set_property(this, STR_PERCENT_POS_PROPERTY_RW, value); }
        }

        public long FullscreenMonitor
        {
            get
            {
                if (mpv_properties.mpv_get_property(this,
                        STR_FS_MONITOR_RW, mpv_format.Long) is long lng)
                    return lng;
                Debug.WriteLine("playlist index property was null");
                return 0L;
            }
            set
            {
                using (var monString = UnicodeBinaryString.From(value.ToString()))
                    mpv_properties.mpv_set_property_string(this,
                        STR_FS_MONITOR_RW.HGlobal, monString.HGlobal).Assert(
                        STR_FS_MONITOR_RW, monString);
            }
        }

        /// <summary>
        /// On transport controls as file repeat button
        /// </summary>
        public bool RepeatFile
        {
            get { return mpv_properties.mpv_get_property_string(this, STR_LOOP_FILE_PROPERTY_RW) != "no"; }
            set
            {
                var choice = value ? STR_INF : STR_NO;
                mpv_properties.mpv_set_property_string(this, STR_LOOP_FILE_PROPERTY_RW.HGlobal, choice.HGlobal)
                    .Assert(STR_LOOP_FILE_PROPERTY_RW, choice);
            }
        }

        /// <summary>
        /// On playlist controls as playlist repeat button
        /// </summary>
        public bool RepeatPlaylist
        {
            get
            {
                var v = mpv_properties.mpv_get_property_string(this, STR_LOOP_PLAYLIST_PROPERTY_RW).ToLower().Trim();
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
                var choice = value ? STR_INF : STR_NO;
                mpv_properties.mpv_set_property_string(
                    this, STR_LOOP_PLAYLIST_PROPERTY_RW.HGlobal, choice.HGlobal);
            }
        }

        /// <summary>
        /// Shown by transport controls trackbar and textbox
        /// </summary>
        public double CurrentPercentagePosition
        {
            get
            {
                try
                {
                    var v = mpv_properties.mpv_get_property(
                        this, STR_PERCENT_POS_PROPERTY_RW, mpv_format.Double);
                    if (v is double dbl)
                        return dbl;
                    Debug.WriteLine("current % pos was null");
                    return 0.0;
                }
                catch (Exception ex)
                {
                    return 0;
                }
            }
            set { mpv_properties.mpv_set_property(this, STR_PERCENT_POS_PROPERTY_RW, value); }
        }

        /// <summary>
        /// Shown by transport controls textbox
        /// </summary>
        public double CurrentTimePosition
        {
            get
            {
                try
                {
                    var v = mpv_properties.mpv_get_property(this, STR_TIME_POS_PROPERTY_RW, mpv_format.Double);
                    if (v is double dbl)
                        return dbl;

                    Debug.WriteLine("time pos property was null");
                    return 0;
                }
                catch (Exception ex)
                {
                    return 0;
                }
            }
            set { mpv_properties.mpv_set_property(this, STR_TIME_POS_PROPERTY_RW, value); }
        }
    }
}