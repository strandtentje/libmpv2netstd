using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace libmpv2net
{
    public struct mpv_load_config_file_result
    {
        public mpv_result result;
        public void Assert(params object[] args)
        {
            result.ThrowOnFail("mpv_load_config_file", args);
        }
    }

    public struct mpv_set_option_result
    {
        public mpv_result result;
        public void Assert(params object[] args)
        {
            result.ThrowOnFail("mpv_set_option", args);
        }
    }

    public struct mpv_set_option_string_result
    {
        public mpv_result result;
        public void Assert(params object[] args)
        {
            result.ThrowOnFail("mpv_set_option_string", args);
        }        
    }
}
