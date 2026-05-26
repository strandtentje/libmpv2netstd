using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using libmpv2net;
using System.Threading;
using libmpv2net.Functions;

namespace LibMpvWrapper
{
    public partial class MpvPlayer
    {
        private readonly object PropertyWatchLock = new object();
        private readonly Dictionary<string, long> WatchedProperties =
            new Dictionary<string, long>();
        private long PropertyWatchNumber = 1000L;

        public void WatchProperty(string name, mpv_format fmt)
        {
            long watchNumber;
            lock (PropertyWatchLock)
            {
                if (WatchedProperties.ContainsKey(name))
                    return;
                watchNumber = Interlocked.Increment(ref PropertyWatchNumber);
                WatchedProperties[name] = watchNumber;

                mpv_properties.
                    mpv_observe_property(this, watchNumber, name, fmt).
                    Assert(watchNumber, name, fmt);
            }
        }

        public void UnwatchProperty(string name)
        {
            lock (PropertyWatchLock)
            {
                long watchNumber;
                if (!WatchedProperties.TryGetValue(name, out watchNumber))
                    return;
                WatchedProperties.Remove(name);

                mpv_properties.mpv_unobserve_property(this, watchNumber);
            }
        }
    }
}
