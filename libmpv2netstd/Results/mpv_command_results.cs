using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace libmpv2net
{
    public struct mpv_command_result
    {
        public mpv_result result;
        public void Assert(params object[] args)
        {
            result.ThrowOnFail("mpv_command", args);
        }
    }

    public struct mpv_command_node_result
    {
        public mpv_result result;
        public void Assert(params object[] args)
        {
            result.ThrowOnFail("mpv_command_node_result", args);
        }
    }

    public struct mpv_command_ret_result
    {
        public mpv_result result;
        public void Assert(params object[] args)
        {
            result.ThrowOnFail("mpv_command_ret_result", args);
        }
    }

    public struct mpv_command_string_result
    {
        public mpv_result result;
        public void Assert(params object[] args)
        {
            result.ThrowOnFail("mpv_command_string_result", args);
        }
    }

    public struct mpv_command_async_result
    {
        public mpv_result result;
        public void Assert(params object[] args)
        {
            result.ThrowOnFail("mpv_command_async_result", args);
        }
    }

    public struct mpv_command_node_async_result
    {
        public mpv_result result;
        public void Assert(params object[] args)
        {
            result.ThrowOnFail("mpv_command_node_async_result", args);
        }
    }

    public struct mpv_abort_async_command_result
    {
        public mpv_result result;
        public void Assert(params object[] args)
        {
            result.ThrowOnFail("mpv_abort_async_command_result", args);
        }
    }
}
