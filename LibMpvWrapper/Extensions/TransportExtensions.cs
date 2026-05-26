using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using libmpv2net.Functions;
using libmpv2net;

namespace LibMpvWrapper
{
    public static class TransportExtensions
    {
        public static void SeekRelativeSeconds(this MpvPlayer player, int seconds)
        {
            player.SendCommand("seek", seconds, "relative", player.SeekBehaviour);
        }
        public static void SeekAbsoluteSeconds(this MpvPlayer player, int seconds)
        {
            player.SendCommand("seek", seconds, "absolute", player.SeekBehaviour);
        }
        public static void SeekAbsolutePercent(this MpvPlayer player, int percent)
        {
            player.SendCommand("seek", percent, "absolute-percent", 
                player.SeekBehaviour);
        }
        public static void SeekRelativePercent(this MpvPlayer player, int percent)
        {
            player.SendCommand("seek", percent, "relative-percent",
                player.SeekBehaviour);
        }
        public static void FrameStep(this MpvPlayer player, int frames)
        {
            player.SendCommand("frame-step", frames, player.FrameStepPlay, 
                player.FrameStepAudio);
        }
        public static void FullStop(this MpvPlayer player)
        {
            player.SendCommand("stop", player.StopBehaviour);
        }
    }
}
