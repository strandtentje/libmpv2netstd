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
        public static void Next(this MpvPlayer player)
        {
            player.SendCommand("playlist-next");
        }
        public static void Previous(this MpvPlayer player)
        {
            player.SendCommand("playlist-previous");
        }
        public static void NextPlaylist(this MpvPlayer player)
        {
            player.SendCommand("playlist-next-playlist");
        }
        public static void PreviousPlaylist(this MpvPlayer player)
        {
            player.SendCommand("playlist-prev-playlist");
        }
        public static void GoToPlaylistItem(this MpvPlayer player, int index)
        {
            player.SendCommand("playlist-play-index", index);
        }
        public static void ReplayCurrent(this MpvPlayer player)
        {
            player.SendCommand("playlist-play-index", "current");
        }
        public static void StopPlaylist(this MpvPlayer player)
        {
            player.SendCommand("playlist-play-index", "none");
        }
        public static void PlayNow(this MpvPlayer player, string file)
        {
            player.SendCommand("loadfile", file);
        }
        public static void AppendPlaylist(this MpvPlayer player, string file)
        {
            player.SendCommand("loadfile", file, "append", 
                player.IdleAppendBehaviour);
        }
        public static void ReplacePlaylist(this MpvPlayer player, string file)
        {
            player.SendCommand("loadlist", file);
        }
        public static void AppendAnoterhPlaylist(this MpvPlayer player, string file)
        {
            player.SendCommand("loadlist", file, "append", 
                player.IdleAppendBehaviour);
        }
        public static void ClearPlaylist(this MpvPlayer player)
        {
            player.SendCommand("playlist-clear");
        }
        public static void RemovePlaylistItem(this MpvPlayer player, int item)
        {
            player.SendCommand("playlist-remove", item);
        }
        public static void SkipAndRemoveCurrent(this MpvPlayer player)
        {
            player.SendCommand("playlist-remove", "current");
        }
    }
}
