using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using libmpv2net;

namespace LibMpvWrapper
{
    public static class PropertyWatchExtensions
    {
        public static void WatchPropertyString(this MpvPlayer player, string name)
        {
            player.WatchProperty(name, mpv_format.String);
        }
        public static void WatchPropertyDouble(this MpvPlayer player, string name)
        {
            player.WatchProperty(name, mpv_format.Double);
        }
        public static void WatchPropertyLong(this MpvPlayer player, string name)
        {
            player.WatchProperty(name, mpv_format.Long);
        }
        public static void WatchPropertyBool(this MpvPlayer player, string name)
        {
            player.WatchProperty(name, mpv_format.BoolFlag);
        }
        public static void WatchPropertyNoValue(this MpvPlayer player, string name)
        {
            player.WatchProperty(name, mpv_format.None);
        }
    }
}
