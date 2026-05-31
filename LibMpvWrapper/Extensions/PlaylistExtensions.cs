using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using libmpv2net.Functions;
using libmpv2net;
using System.Diagnostics;

namespace LibMpvWrapper
{
    public static class PlaylistExtensions
    {
        public static void SendCommand(this MpvPlayer player, params UnicodeBinaryString[] command)
        {
            try
            {
                var ptrs = command.Select(x => x.HGlobal).ToArray();
                mpv_commands.mpv_command(player, ptrs).Assert(command);
            }
            catch (MpvCallException e)
            {
                switch (e.Error)
                {
                    case mpv_error.Success:
                    case mpv_error.NoMemory:
                    case mpv_error.Uninitialized:
                    case mpv_error.PropertyUnavailable:
                    case mpv_error.PropertyError:
                    case mpv_error.CommandError:
                    case mpv_error.LoadingFailed:
                    case mpv_error.NothingToPlay:
                    case mpv_error.UnknownFormat:
                        Debug.WriteLine(e.ToString());
                        Debug.WriteLine(e.Message);
                        return;

                    case mpv_error.EventQueueFull:
                    case mpv_error.InvalidParameter:
                    case mpv_error.OptionNotFound:
                    case mpv_error.OptionFormat:
                    case mpv_error.OptionError:
                    case mpv_error.PropertyNotFound:
                    case mpv_error.PropertyFormat:
                    case mpv_error.AudioOutputFailed:
                    case mpv_error.VideoOutputFailed:
                    case mpv_error.Unsupported:
                    case mpv_error.NotImplemented:
                    case mpv_error.Generic:
                    default:
                        throw;
                }
            }
        }
        
        /// <summary>
        /// Is next button under cue controls
        /// </summary>
        /// <param name="player"></param>
        public static void Next(this MpvPlayer player)
        {
            player.SendCommand(player.STR_PLAYLIST_NEXT);
        }

        /// <summary>
        /// Is previous button under cue controls
        /// </summary>
        /// <param name="player"></param>
        public static void Previous(this MpvPlayer player)
        {
            player.SendCommand(player.STR_PLAYLIST_PREV);
        }

        /// <summary>
        /// Is next playlist button under cue controls
        /// </summary>
        /// <param name="player"></param>
        public static void NextPlaylist(this MpvPlayer player)
        {
            player.SendCommand(player.STR_PLAYLIST_NEXT_PLAYLIST);
        }

        /// <summary>
        /// Is previous playlist button under cue controls
        /// </summary>
        /// <param name="player"></param>
        public static void PreviousPlaylist(this MpvPlayer player)
        {
            player.SendCommand(player.STR_PLAYLIST_PREV_PLAYLIST);
        }

        /// <summary>
        /// Is replay button under cue controls
        /// </summary>
        /// <param name="player"></param>
        public static void ReplayCurrent(this MpvPlayer player)
        {
            player.SendCommand(player.STR_PLAYLIST_PLAY_INDEX, player.STR_CURRENT);
        }

        /// <summary>
        /// Is clear playlist button under cue controls
        /// </summary>
        /// <param name="player"></param>
        public static void ClearPlaylist(this MpvPlayer player)
        {
            player.SendCommand(player.STR_PLAYLIST_CLEAR);
        }

        /// <summary>
        /// Is stop playlist button under cue controls
        /// </summary>
        /// <param name="player"></param>
        public static void StopPlaylist(this MpvPlayer player)
        {
            player.SendCommand(player.STR_PLAYLIST_PLAY_INDEX, player.STR_NONE);
        }

        /// <summary>
        /// Is skip and remove current under cue controls
        /// </summary>
        /// <param name="player"></param>
        public static void SkipAndRemoveCurrent(this MpvPlayer player)
        {
            player.SendCommand(player.STR_PLAYLIST_REMOVE, player.STR_CURRENT);
        }

        /// <summary>
        /// Is go to item under playlist controls
        /// </summary>
        /// <param name="player"></param>
        /// <param name="index"></param>
        public static void GoToPlaylistItem(this MpvPlayer player, int index)
        {
            using (var numString = UnicodeBinaryString.From(index.ToString()))
                player.SendCommand(player.STR_PLAYLIST_PLAY_INDEX, numString);
        }

        /// <summary>
        /// Is open media button on playlist controls
        /// </summary>
        /// <param name="player"></param>
        /// <param name="file"></param>
        public static void PlayNow(this MpvPlayer player, string file)
        {
            using (var fileString = UnicodeBinaryString.From(file))
                player.SendCommand(player.STR_LOADFILE, fileString);
        }

        /// <summary>
        /// Is Append button in playlist controls
        /// </summary>
        /// <param name="player"></param>
        /// <param name="file"></param>
        public static void AppendPlaylist(this MpvPlayer player, string file)
        {
            if (player.IsPlayAfterAppend)
            {
                using (var fileString = UnicodeBinaryString.From(file))
                    player.SendCommand(player.STR_LOADFILE, fileString, player.STR_APPEND_PLAY);
            }
            else
            {
                using (var fileString = UnicodeBinaryString.From(file))
                    player.SendCommand(player.STR_LOADFILE, fileString, player.STR_APPEND);
            }
        }

        /// <summary>
        /// Is open new playlist button in playlist controls
        /// </summary>
        /// <param name="player"></param>
        /// <param name="file"></param>
        public static void ReplacePlaylist(this MpvPlayer player, string file)
        {
            using (var fileString = UnicodeBinaryString.From(file))
                player.SendCommand(player.STR_LOADLIST, fileString);
        }

        /// <summary>
        /// Is append playlist button in playlist controls
        /// </summary>
        /// <param name="player"></param>
        /// <param name="file"></param>
        public static void AppendAnotherPlaylist(this MpvPlayer player, string file)
        {
            if (player.IsPlayAfterAppend)
            {
                using (var fileString = UnicodeBinaryString.From(file))
                    player.SendCommand(player.STR_LOADLIST, fileString, player.STR_APPEND_PLAY);
            }
            else
            {
                using (var fileString = UnicodeBinaryString.From(file))
                    player.SendCommand(player.STR_LOADLIST, fileString, player.STR_APPEND);
            }
        }

        /// <summary>
        /// Is trash icon in playlist controls
        /// </summary>
        /// <param name="player"></param>
        /// <param name="item"></param>
        public static void RemovePlaylistItem(this MpvPlayer player, int item)
        {
            using (var numString = UnicodeBinaryString.From(item.ToString()))
                player.SendCommand(player.STR_PLAYLIST_REMOVE, numString);
        }
    }
}
