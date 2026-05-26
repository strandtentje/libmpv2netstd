using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace libmpv2net
{
    public class MpvCallException : Exception
    {
        private readonly mpv_error Error;
        private readonly int ResultCode;
        private readonly string Caller, Args;
        public MpvCallException(mpv_error error, string caller, string args) :
            base(string.Format("MPV returned error {0} for {1} with args {2}",
            Enum.GetName(typeof(mpv_error), error), caller, args))
        {
            this.Error = error;
            this.ResultCode = (int)error;
            this.Caller = caller;
            this.Args = args;
        }

        public MpvCallException(int resultCode, string caller, string args) :
            base(string.Format("MPV returned code {0} for {1} with args {2}"))
        {
            this.Error = mpv_error.Generic;
            this.ResultCode = resultCode;
            this.Caller = caller;
            this.Args = args;
        }
    }
}
