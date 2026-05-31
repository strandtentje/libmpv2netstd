using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace libmpv2net
{
    public struct mpv_event_to_node_result
    {
        public mpv_result result;
        public void Assert(params object[] args)
        {
            result.ThrowOnFail("mpv_event_to_node", args);
        }
    }

    public struct mpv_request_event_result
    {
        public mpv_result result;
        public void Assert(params object[] args)
        {
            result.ThrowOnFail("mpv_request_event", args);
        }
    }

    public struct mpv_request_log_messages_result
    {
        public mpv_result result;
        public void Assert(params object[] args)
        {
            result.ThrowOnFail("mpv_request_log_messages", args);
        }
    }

    public struct mpv_wait_event_result
    {
        public mpv_result result;
        public void Assert(params object[] args)
        {
            result.ThrowOnFail("mpv_wait_event", args);
        }
    }
}
