using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using libmpv2net;

namespace LibMpvWrapper
{
    public static class PropertyWatchExtensions
    {
        public static MpvPlayer WatchPropertyNone(this MpvPlayer player, params UnicodeBinaryString[] names)
        {
            foreach (var name in names)
                player.WatchProperty(name, mpv_format.None);
            return player;
        }
    }
}
