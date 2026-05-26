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
                string s = "filename";
                return mpv_properties.mpv_get_property_string(
                    this, ref s);
            }
        }

        public string CurrentFilePath
        {
            get
            {
                string s = "path";
                return mpv_properties.mpv_get_property_string(
                    this, ref s);
            }
        }

        public string CurrentTitle
        {
            get
            {
                string s = "media-title";
                return mpv_properties.mpv_get_property_string(
                    this, ref s);
            }
        }

        public double CurrentDuration
        {
            get
            {
                double val = 0;
                string s = "duration";
                mpv_properties.mpv_get_property(
                    this, ref s, 
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
                string s = "percent-pos";
                mpv_properties.mpv_get_property(
                    this, ref s, mpv_format.Double,
                    ref val).Assert();
                return val;
            }
            set
            {
                string s = "percent-pos";
                mpv_properties.mpv_set_property(
                    this, ref s, mpv_format.Double,
                    value).Assert();                    
            }
        }

        public double CurrentTimePosition
        {
            get
            {
                double val = 0;
                string s = "time-pos";
                mpv_properties.mpv_get_property(
                    this, ref s, mpv_format.Double,
                    ref val).Assert();

                return val;
            }
            set
            {
                string s = "time-pos";
                mpv_properties.mpv_set_property(
                    this, ref s, mpv_format.Double,
                    value).Assert();
            }
        }

        public bool IsIdle
        {
            get
            {
                string s = "idle-active";
                bool isIdle = false;
                mpv_properties.mpv_get_property(
                    this, ref s, mpv_format.BoolFlag,
                    ref isIdle).Assert();
                return isIdle;
            }
        }

        public bool IsEof
        {
            get
            {
                string s = "eof-reached";
                bool isEof = false;
                mpv_properties.mpv_get_property(
                    this, ref s, mpv_format.BoolFlag,
                    ref isEof).Assert();
                return isEof;
            }
        }

        public long PlaylistIndex
        {
            get
            {
                long pos = 0;
                string s = "playlist-pos";
                mpv_properties.mpv_get_property(
                    this, ref s, mpv_format.Long, ref pos).Assert();
                return pos;
            }
            set
            {
                string s = "playlist-pos";
                mpv_properties.mpv_set_property(
                    this, ref s, mpv_format.Long, value).Assert();
            }
        }

        public long PlaylistPlayingIndex
        {
            get
            {
                long pos = 0;
                string s = "playlist-playing-pos";
                mpv_properties.mpv_get_property(
                    this, ref s, mpv_format.Long, ref pos).Assert();
                return pos;
            }
        }

        public long PlaylistCount
        {
            get
            {
                long pos = 0;
                string s = "playlist-count";
                mpv_properties.mpv_get_property(
                    this, ref s, mpv_format.Long, ref pos).Assert();
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
                    string s = string.Format("playlist/{0}/filename", i);
                    files[i] = mpv_properties.mpv_get_property_string(
                        this, ref s);
                }
                return files;
            }
        }

        public bool RepeatFile
        {
            get
            {
                bool isRepeat = false;
                string s = "loop-file";
                mpv_properties.mpv_get_property(
                    this, ref s, mpv_format.BoolFlag, ref isRepeat).Assert();
                return isRepeat;
            }
            set
            {
                string s = "loop-file";
                mpv_properties.mpv_set_property(
                    this, ref s, mpv_format.BoolFlag, value).Assert();
            }
        }

        public bool RepeatPlaylist
        {
            get
            {
                bool isRepeat = false;
                var s = "loop-playlist";
                mpv_properties.mpv_get_property(
                    this, ref s, mpv_format.BoolFlag, 
                    ref isRepeat).Assert();
                return isRepeat;
            }
            set
            {
                var s = "loop-playlist";
                mpv_properties.mpv_set_property(
                    this, ref s, mpv_format.BoolFlag, 
                    value).Assert();
            }
        }
	}
}
