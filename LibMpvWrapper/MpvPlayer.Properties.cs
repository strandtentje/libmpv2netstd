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

        public string[] PlaylistFiles
        {
            get
            {
                string[] files = new string[PlaylistCount];
                var ph = new string('0', files.Length.ToString(CultureInfo.InvariantCulture).Length);
                using (var sptr = UnicodeBinaryString.From(string.Format("playlist/{0}/filename", ph)))
                    for (int i = 0; i < files.Length; i++)
                    {
                        var qry = sptr.Overwrite(i.ToString(ph), "playlist/".Length);
                        Debug.WriteLine(qry.ToString());
                        files[i] = mpv_properties.mpv_get_property_string(this, qry);
                    }
                return files;
            }
        }
        public string[] PlaylistTitles
        {
            get
            {
                string[] titles = new string[PlaylistCount];
                var ph = new string('0', titles.Length.ToString(CultureInfo.InvariantCulture).Length);
                using (var sptr = UnicodeBinaryString.From(string.Format("playlist/{0}/filename", ph)))
                    for (int i = 0; i < titles.Length; i++)
                        titles[i] = mpv_properties.mpv_get_property_string(this, sptr.Overwrite(i.ToString(ph), "playlist/".Length));
                return titles;
            }
        }
        public string[] PlaylistSources
        {
            get
            {
                string[] sources = new string[PlaylistCount];
                var ph = new string('0', sources.Length.ToString(CultureInfo.InvariantCulture).Length);
                using (var sptr = UnicodeBinaryString.From(string.Format("playlist/{0}/playlist-path", ph)))
                    for (int i = 0; i < sources.Length; i++)
                        sources[i] = mpv_properties.mpv_get_property_string(this, sptr.Overwrite(i.ToString(ph), "playlist/".Length));
                return sources;
            }
        }
        public string[] PlaylistPlaying
        {
            get
            {
                string[] playings = new string[PlaylistCount];
                var ph = new string('0', playings.Length.ToString(CultureInfo.InvariantCulture).Length);
                using (var sptr = UnicodeBinaryString.From(string.Format("playlist/{0}/playing", ph)))
                    for (int i = 0; i < playings.Length; i++)
                        playings[i] = mpv_properties.mpv_get_property_string(this, sptr.Overwrite(i.ToString(ph), "playlist/".Length));

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
                mpv_properties.mpv_set_property_string(this, STR_PAUSE_PROPERTY_RW.HGlobal, choice.HGlobal).
                    Assert(STR_PAUSE_PROPERTY_RW, choice);
            }
        }

        public bool Mute
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
                mpv_properties.mpv_set_property_string(this, STR_MUTE_RW.HGlobal, choice.HGlobal).Assert(STR_MUTE_RW, choice);
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
            set
            {
                mpv_properties.mpv_set_property(this, STR_PERCENT_POS_PROPERTY_RW, value);
            }
        }

        /// <summary>
        /// On transport controls as file repeat button
        /// </summary>
        public bool RepeatFile
        {
            get
            {
                return mpv_properties.mpv_get_property_string(this, STR_LOOP_FILE_PROPERTY_RW) != "no";
            }
            set
            {
                var choice = value ? STR_INF : STR_NO;
                mpv_properties.
                    mpv_set_property_string(this, STR_LOOP_FILE_PROPERTY_RW.HGlobal, choice.HGlobal).
                    Assert(STR_LOOP_FILE_PROPERTY_RW, choice);
            }
        }

        /// <summary>
        /// On playlist controls as playlist repeat button
        /// </summary>
        public bool RepeatPlaylist
        {
            get
            {
                var v = mpv_properties.
                    mpv_get_property_string(this, STR_LOOP_PLAYLIST_PROPERTY_RW).
                    ToLower().
                    Trim();
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
                var v = mpv_properties.mpv_get_property(
                    this, STR_PERCENT_POS_PROPERTY_RW, mpv_format.Double);
                if (v is double dbl)
                    return dbl;
                Debug.WriteLine("current % pos was null");
                return 0.0;
            }
            set
            {
                mpv_properties.mpv_set_property(this, STR_PERCENT_POS_PROPERTY_RW, value);
            }
        }

        /// <summary>
        /// Shown by transport controls textbox
        /// </summary>
        public double CurrentTimePosition
        {
            get
            {
                var v = mpv_properties.mpv_get_property(this, STR_TIME_POS_PROPERTY_RW, mpv_format.Double);
                if (v is double dbl)
                    return dbl;

                Debug.WriteLine("time pos property was null");
                return 0;
            }
            set
            {
                mpv_properties.mpv_set_property(this, STR_TIME_POS_PROPERTY_RW, value);
            }
        }
    }
}
