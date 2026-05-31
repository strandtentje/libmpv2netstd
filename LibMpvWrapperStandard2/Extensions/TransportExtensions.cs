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
            using (var secondsStr = UnicodeBinaryString.From(seconds.ToString()))
                if (player.IsSeekToKeyframes)
                    player.SendCommand(player.STR_SEEK, secondsStr, player.STR_ABSOLUTE, player.STR_KEYFRAMES);
                else
                    player.SendCommand(player.STR_SEEK, secondsStr, player.STR_ABSOLUTE);
        }

        /// <summary>
        /// On transport controls as percentage text box
        /// </summary>
        /// <param name="player"></param>
        /// <param name="percent"></param>
        public static void SeekAbsolutePercent(this MpvPlayer player, int percent)
        {
            using (var percentStr = UnicodeBinaryString.From(percent.ToString()))
                if (player.IsSeekToKeyframes)
                    player.SendCommand(player.STR_SEEK, percentStr, player.STR_ABSOLUTE_PERCENT, player.STR_KEYFRAMES);
                else
                    player.SendCommand(player.STR_SEEK, percentStr, player.STR_ABSOLUTE_PERCENT);
        }

        /// <summary>
        /// Is go back/forwards in seconds on transport controls
        /// </summary>
        /// <param name="player"></param>
        /// <param name="seconds"></param>
        public static void SeekRelativeSeconds(this MpvPlayer player, int seconds)
        {
            using (var secondsStr = UnicodeBinaryString.From(seconds.ToString()))
                if (player.IsSeekToKeyframes)
                    player.SendCommand(player.STR_SEEK, secondsStr, player.STR_RELATIVE, player.STR_KEYFRAMES);
                else
                    player.SendCommand(player.STR_SEEK, secondsStr, player.STR_RELATIVE);
        }
        /// <summary>
        /// Is go back/forwards in % on transport controls
        /// </summary>
        /// <param name="player"></param>
        /// <param name="percent"></param>
        public static void SeekRelativePercent(this MpvPlayer player, int percent)
        {
            using (var percentStr = UnicodeBinaryString.From(percent.ToString()))
                if (player.IsSeekToKeyframes)
                    player.SendCommand(player.STR_SEEK, percentStr, player.STR_RELATIVE_PERCENT, player.STR_KEYFRAMES);
                else
                    player.SendCommand(player.STR_SEEK, percentStr, player.STR_RELATIVE_PERCENT);
        }

        /// <summary>
        /// Is framestep buttons on transport controls
        /// </summary>
        /// <param name="player"></param>
        /// <param name="frames"></param>
        public static void FrameStep(this MpvPlayer player, int frames)
        {
            using (var frameStr = UnicodeBinaryString.From(frames.ToString()))
                if (player.IsFramestepMuted && player.IsFramestepImmediate)
                    player.SendCommand(player.STR_FRAME_STEP, frameStr, player.STR_MUTE, player.STR_PLAY);
                else if (!player.IsFramestepMuted && player.IsFramestepImmediate)
                    player.SendCommand(player.STR_FRAME_STEP, frameStr, player.STR_PLAY);
                else if (player.IsFramestepMuted && !player.IsFramestepImmediate)
                    player.SendCommand(player.STR_FRAME_STEP, frameStr, player.STR_MUTE);
                else
                    player.SendCommand(player.STR_FRAME_STEP, frameStr);
        }

        /// <summary>
        /// Is stop button on transport controls
        /// </summary>
        /// <param name="player"></param>
        public static void FullStop(this MpvPlayer player)
        {
            if (player.IsStopClear)
                player.SendCommand(player.STR_STOP);
            else
                player.SendCommand(player.STR_STOP, player.STR_KEEP_PLAYLIST);
        }
    }
}
