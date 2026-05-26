using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using libmpv2net.Functions;
using libmpv2net;
using System.Runtime.InteropServices;

namespace LibMpvWrapper
{
	public partial class MpvPlayer
	{
        public string CurrentFileName
        {
            get
            {
                return mpv_properties.mpv_get_property_string(
                    this, "filename");
            }
        }

        public string CurrentFilePath
        {
            get
            {
                return mpv_properties.mpv_get_property_string(
                    this, "path");
            }
        }

        public string CurrentTitle
        {
            get
            {
                return mpv_properties.mpv_get_property_string(
                    this, "media-title");
            }
        }

        public double CurrentDuration
        {
            get
            {
                double val = 0;

                mpv_properties.mpv_get_property(
                    this, "duration", 
                    libmpv2net.mpv_format.Double, 
                    ref val).Assert();

                return val;
            }
        }

        public double CurrentPercentagePosition
        {
            get
            {
                double val = 0;

                mpv_properties.mpv_get_property(
                    this, "percent-pos", mpv_format.Double,
                    ref val).Assert();

                return val;
            }
            set
            {
                mpv_properties.mpv_set_property(
                    this, "percent-pos", mpv_format.Double,
                    value).Assert();                    
            }
        }

        public double CurrentTimePosition
        {
            get
            {
                double val = 0;

                mpv_properties.mpv_get_property(
                    this, "time-pos", mpv_format.Double,
                    ref val).Assert();

                return val;
            }
            set
            {
                mpv_properties.mpv_set_property(
                    this, "time-pos", mpv_format.Double,
                    value).Assert();
            }
        }

        public bool IsIdle
        {
            get
            {
                bool isIdle = false;
                mpv_properties.mpv_get_property(
                    this, "idle-active", mpv_format.BoolFlag,
                    ref isIdle).Assert();
                return isIdle;
            }
        }

        public bool IsEof
        {
            get
            {
                bool isEof = false;
                mpv_properties.mpv_get_property(
                    this, "eof-reached", mpv_format.BoolFlag,
                    ref isEof).Assert();
                return isEof;
            }
        }

        public long PlaylistIndex
        {
            get
            {
                long pos = 0;
                mpv_properties.mpv_get_property(
                    this, "playlist-pos", mpv_format.Long, ref pos).Assert();
                return pos;
            }
            set
            {
                mpv_properties.mpv_set_property(
                    this, "playlist-pos", mpv_format.Long, value).Assert();
            }
        }

        public long PlaylistPlayingIndex
        {
            get
            {
                long pos = 0;
                mpv_properties.mpv_get_property(
                    this, "playlist-playing-pos", mpv_format.Long, ref pos).Assert();
                return pos;
            }
        }

        public long PlaylistCount
        {
            get
            {
                long pos = 0;
                mpv_properties.mpv_get_property(
                    this, "playlist-count", mpv_format.Long, ref pos).Assert();
                return pos;
            }
        }

        public string[] PlaylistFiles
        {
            get
            {
                string[] files = new string[PlaylistCount];
                for (int i = 0; i < files.Length; i++)
                {
                    files[i] = mpv_properties.mpv_get_property_string(
                        this, string.Format("playlist/{0}/filename", i));
                }
                return files;
            }
        }

        public bool RepeatFile
        {
            get
            {
                bool isRepeat = false;
                mpv_properties.mpv_get_property(
                    this, "loop-file", mpv_format.BoolFlag, ref isRepeat).Assert();
                return isRepeat;
            }
            set
            {
                mpv_properties.mpv_set_property(
                    this, "loop-file", mpv_format.BoolFlag, value).Assert();
            }
        }

        public bool RepeatPlaylist
        {
            get
            {
                bool isRepeat = false;
                mpv_properties.mpv_get_property(
                    this, "loop-playlist", mpv_format.BoolFlag, 
                    ref isRepeat).Assert();
                return isRepeat;
            }
            set
            {
                mpv_properties.mpv_set_property(
                    this, "loop-playlist", mpv_format.BoolFlag, 
                    value).Assert();
            }
        }
	}
}
