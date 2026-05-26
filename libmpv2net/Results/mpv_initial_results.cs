using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace libmpv2net
{
    public struct mpv_create_result
    {
        public mpv_result result;
        public void Assert(params object[] args)
        {
            result.ThrowOnFail("mpv_create", args);
        }
    }

    public struct mpv_initialize_result
    {
        public mpv_result result;
        public void Assert(params object[] args)
        {
            result.ThrowOnFail("mpv_initialize", args);
        }
    }
}
