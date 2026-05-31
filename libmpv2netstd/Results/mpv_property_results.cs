using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace libmpv2net
{
    public struct mpv_set_property_result
    {
        public mpv_result result;
        public void Assert(params object[] args)
        {
            result.ThrowOnFail("mpv_set_property", args);
        }
    }

    public struct mpv_set_property_string_result
    {
        public mpv_result result;
        public void Assert(params object[] args)
        {
            result.ThrowOnFail("mpv_set_property_string", args);
        }
    }

    public struct mpv_del_property_result
    {
        public mpv_result result;
        public void Assert(params object[] args)
        {
            result.ThrowOnFail("mpv_del_property", args);
        }
    }

    public struct mpv_set_property_async_result
    {
        public mpv_result result;
        public void Assert(params object[] args)
        {
            result.ThrowOnFail("mpv_set_property_async", args);
        }
    }

    public struct mpv_get_property_result
    {
        public mpv_result result;
        public void Assert(params object[] args)
        {
            result.ThrowOnFail("mpv_get_property", args);
        }
    }

    public struct mpv_observe_property_result
    {
        public mpv_result result;
        public void Assert(params object[] args)
        {
            result.ThrowOnFail("mpv_observe_property", args);
        }
    }

    public struct mpv_unobserve_property_result
    {
        public mpv_result result;
        public void Assert(params object[] args)
        {
            result.ThrowOnFail("mpv_unobserve_property", args);
        }
    }
}
