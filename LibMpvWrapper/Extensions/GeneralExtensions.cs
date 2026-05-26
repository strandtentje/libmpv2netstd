using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using libmpv2net.Functions;
using libmpv2net;

namespace LibMpvWrapper
{
    public static class GeneralExtensions
    {
        public static void SendCommand(
            this MpvPlayer player,
            params object[] args)
        {
            mpv_commands.mpv_command(player, mpv_string.Create(args)).Assert(args);
        }
    }
}
