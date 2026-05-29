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
        /// <summary>
        /// On transport controls as time text box
        /// </summary>
        /// <param name="player"></param>
        /// <param name="seconds"></param>
        public static void SeekAbsoluteSeconds(this MpvPlayer player, int seconds)
        {
            player.SendCommand("seek", seconds, "absolute", player.SeekBehaviour);
        }

        /// <summary>
        /// On transport controls as percentage text box
        /// </summary>
        /// <param name="player"></param>
        /// <param name="percent"></param>
        public static void SeekAbsolutePercent(this MpvPlayer player, int percent)
        {
            player.SendCommand("seek", percent, "absolute-percent",
                player.SeekBehaviour);
        }

        /// <summary>
        /// Is go back/forwards in seconds on transport controls
        /// </summary>
        /// <param name="player"></param>
        /// <param name="seconds"></param>
        public static void SeekRelativeSeconds(this MpvPlayer player, int seconds)
        {
            player.SendCommand("seek", seconds, "relative", player.SeekBehaviour);
        }
        /// <summary>
        /// Is go back/forwards in % on transport controls
        /// </summary>
        /// <param name="player"></param>
        /// <param name="percent"></param>
        public static void SeekRelativePercent(this MpvPlayer player, int percent)
        {
            player.SendCommand("seek", percent, "relative-percent",
                player.SeekBehaviour);
        }

        /// <summary>
        /// Is framestep buttons on transport controls
        /// </summary>
        /// <param name="player"></param>
        /// <param name="frames"></param>
        public static void FrameStep(this MpvPlayer player, int frames)
        {
            player.SendCommand("frame-step", frames, player.FrameStepPlay, 
                player.FrameStepAudio);
        }

        /// <summary>
        /// Is stop button on transport controls
        /// </summary>
        /// <param name="player"></param>
        public static void FullStop(this MpvPlayer player)
        {
            player.SendCommand("stop", player.StopBehaviour);
        }
    }
}
