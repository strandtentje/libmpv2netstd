using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using libmpv2net.Functions;
using libmpv2net;

namespace LibMpvWrapper
{
    public static class PlaylistExtensions
    {
        public static void SendCommand(this MpvPlayer player, params object[] command)
        {
            mpv_commands.mpv_command(player, command);
        }

        /// <summary>
        /// Is next button under cue controls
        /// </summary>
        /// <param name="player"></param>
        public static void Next(this MpvPlayer player)
        {
            player.SendCommand("playlist-next");
        }

        /// <summary>
        /// Is previous button under cue controls
        /// </summary>
        /// <param name="player"></param>
        public static void Previous(this MpvPlayer player)
        {
            player.SendCommand("playlist-previous");
        }

        /// <summary>
        /// Is next playlist button under cue controls
        /// </summary>
        /// <param name="player"></param>
        public static void NextPlaylist(this MpvPlayer player)
        {
            player.SendCommand("playlist-next-playlist");
        }

        /// <summary>
        /// Is previous playlist button under cue controls
        /// </summary>
        /// <param name="player"></param>
        public static void PreviousPlaylist(this MpvPlayer player)
        {
            player.SendCommand("playlist-prev-playlist");
        }

        /// <summary>
        /// Is replay button under cue controls
        /// </summary>
        /// <param name="player"></param>
        public static void ReplayCurrent(this MpvPlayer player)
        {
            player.SendCommand("playlist-play-index", "current");
        }

        /// <summary>
        /// Is clear playlist button under cue controls
        /// </summary>
        /// <param name="player"></param>
        public static void ClearPlaylist(this MpvPlayer player)
        {
            player.SendCommand("playlist-clear");
        }

        /// <summary>
        /// Is stop playlist button under cue controls
        /// </summary>
        /// <param name="player"></param>
        public static void StopPlaylist(this MpvPlayer player)
        {
            player.SendCommand("playlist-play-index", "none");
        }

        /// <summary>
        /// Is skip and remove current under cue controls
        /// </summary>
        /// <param name="player"></param>
        public static void SkipAndRemoveCurrent(this MpvPlayer player)
        {
            player.SendCommand("playlist-remove", "current");
        }

        /// <summary>
        /// Is go to item under playlist controls
        /// </summary>
        /// <param name="player"></param>
        /// <param name="index"></param>
        public static void GoToPlaylistItem(this MpvPlayer player, int index)
        {
            player.SendCommand("playlist-play-index", index);
        }

        /// <summary>
        /// Is open media button on playlist controls
        /// </summary>
        /// <param name="player"></param>
        /// <param name="file"></param>
        public static void PlayNow(this MpvPlayer player, string file)
        {
            player.SendCommand("loadfile", file);
        }

        /// <summary>
        /// Is Append button in playlist controls
        /// </summary>
        /// <param name="player"></param>
        /// <param name="file"></param>
        public static void AppendPlaylist(this MpvPlayer player, string file)
        {
            player.SendCommand("loadfile", file, "append", 
                player.IdleAppendBehaviour);
        }

        /// <summary>
        /// Is open new playlist button in playlist controls
        /// </summary>
        /// <param name="player"></param>
        /// <param name="file"></param>
        public static void ReplacePlaylist(this MpvPlayer player, string file)
        {
            player.SendCommand("loadlist", file);
        }

        /// <summary>
        /// Is append playlist button in playlist controls
        /// </summary>
        /// <param name="player"></param>
        /// <param name="file"></param>
        public static void AppendAnotherPlaylist(this MpvPlayer player, string file)
        {
            player.SendCommand("loadlist", file, "append", 
                player.IdleAppendBehaviour);
        }

        /// <summary>
        /// Is trash icon in playlist controls
        /// </summary>
        /// <param name="player"></param>
        /// <param name="item"></param>
        public static void RemovePlaylistItem(this MpvPlayer player, int item)
        {
            player.SendCommand("playlist-remove", item);
        }
    }
}
