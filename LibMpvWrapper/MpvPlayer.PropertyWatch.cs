using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using libmpv2net;
using System.Threading;
using libmpv2net.Functions;
using System.Runtime.InteropServices;

namespace LibMpvWrapper
{
    public partial class MpvPlayer
    {
        private readonly object PropertyWatchLock = new object();
        private readonly
            Dictionary<string, long> WatchedPropertyNameIds = new Dictionary<string, long>();
        private readonly
            Dictionary<long, string> WatchedPropertyIdNames = new Dictionary<long, string>();
        private long PropertyWatchNumber = 1000L;

        public void WatchProperty(string name, mpv_format fmt)
        {
            long watchNumber;
            lock (PropertyWatchLock)
            {
                if (WatchedPropertyNameIds.ContainsKey(name))
                    return;
                watchNumber = Interlocked.Increment(ref PropertyWatchNumber);
                WatchedPropertyNameIds[name] = watchNumber;
                WatchedPropertyIdNames[watchNumber] = name;

                using (var name_ptr = name.ToMemory())
                    mpv_properties.
                        mpv_observe_property(this, watchNumber, name_ptr, fmt).
                        Assert(watchNumber, name, fmt);
            }
        }

        public void UnwatchProperty(string name)
        {
            lock (PropertyWatchLock)
            {
                long watchNumber;
                if (!WatchedPropertyNameIds.TryGetValue(name, out watchNumber))
                    return;
                WatchedPropertyIdNames.Remove(watchNumber);
                WatchedPropertyNameIds.Remove(name);

                mpv_properties.mpv_unobserve_property(this, watchNumber);
            }
        }
    }
}
