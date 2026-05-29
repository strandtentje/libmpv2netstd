using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using libmpv2net;

namespace LibMpvWrapper
{
    public static class PropertyWatchExtensions
    {
        public static MpvPlayer WatchPropertyString(this MpvPlayer player, params string[] names)
        {
            foreach (var name in names)
                player.WatchProperty(name, mpv_format.String);
            return player;
        }
        public static MpvPlayer WatchPropertyDouble(this MpvPlayer player, params string[] names)
        {
            foreach (var name in names)
                player.WatchProperty(name, mpv_format.Double);
            return player;
        }
        public static MpvPlayer WatchPropertyLong(this MpvPlayer player, params string[] names)
        {
            foreach (var name in names)
                player.WatchProperty(name, mpv_format.Long);
            return player;
        }
        public static MpvPlayer WatchPropertyBool(this MpvPlayer player, params string[] names)
        {
            foreach (var name in names)
                player.WatchProperty(name, mpv_format.BoolFlag);
            return player;
        }
        public static MpvPlayer WatchPropertyNone(this MpvPlayer player, params string[] names)
        {
            foreach (var name in names)
                player.WatchProperty(name, mpv_format.None);
            return player;
        }
    }
}
