using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace LibMpvWrapper
{
    public partial class MpvPlayer : IDisposable
    {
        private readonly System.Threading.Timer PropertyPoller;
        private long TimeSignals = 0L;
        private long PercentageSignals = 0L;

        private void PollPropertiesLoop(object state)
        {
            if (Interlocked.Exchange(ref TimeSignals, 0L) > 0L)
                TimeChanged?.Invoke(this, this.CurrentTimePosition);
            if (Interlocked.Exchange(ref PercentageSignals, 0L) > 0L)
                PercentageChanged?.Invoke(this, this.CurrentPercentagePosition);
        }
    }
}
