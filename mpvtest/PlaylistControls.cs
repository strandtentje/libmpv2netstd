using LibMpvWrapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mpvtest
{
    public partial class PlaylistControls : Form
    {
        private MpvPlayer Player;

        public PlaylistControls()
        {
            InitializeComponent();
        }

        internal void UsePlayer(MpvPlayer player)
        {
            this.Player = player;
            Player.PlaylistCountChanged += Player_PlaylistChanged;
            Player.PlaybackIndexChanged += Player_PlaylistChanged;            
        }

        private void Player_PlaylistChanged(object sender, long e)
        {
            var items = Player.PlaylistMembers;
            this.BeginInvoke(new Action(() =>
            {
                DatPlaylist.DataSource = items;
            }));
        }

        private void ButRemove_Click(object sender, EventArgs e)
        {            
            foreach (var item in DatPlaylist.SelectedRows.OfType<DataGridViewRow>())
            {
                if (item.Tag is PlaylistMember mem)
                {
                    Player.RemovePlaylistItem(mem.Ordinal);
                    return;
                }                
            }
        }

        private void DatPlaylist_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            ButRemove.Enabled = true;
            ButPlayThis.Enabled = true;
        }

        private void DatPlaylist_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            ButRemove.Enabled = false;
            ButPlayThis.Enabled = false;
        }

        private void ButPlayThis_Click(object sender, EventArgs e)
        {
            foreach (var item in DatPlaylist.SelectedRows.OfType<DataGridViewRow>())
            {
                if (item.Tag is PlaylistMember mem)
                {
                    Player.GoToPlaylistItem(mem.Ordinal);
                    return;
                }
            }
        }

        private void ButOpenForPlayback_Click(object sender, EventArgs e)
        {
            if (OpenMediaFile.ShowDialog() != DialogResult.OK) return;
            Player.PlayNow(OpenMediaFile.FileName);
        }

        private void ChkEnableAutoplay_CheckedChanged(object sender, EventArgs e)
        {
            Player.IsPlayAfterAppend = ChkEnableAutoplay.Checked;
        }

        private void ButAppendFile_Click(object sender, EventArgs e)
        {
            if (OpenMediaFile.ShowDialog() != DialogResult.OK) return;
            Player.PlayNow(OpenMediaFile.FileName);
        }

        private void ButReplacePlaylist_Click(object sender, EventArgs e)
        {
            if (OpenMediaFile.ShowDialog() != DialogResult.OK) return;
            Player.ReplacePlaylist(OpenMediaFile.FileName);
        }

        private void ButAppendPlaylist_Click(object sender, EventArgs e)
        {
            if (OpenMediaFile.ShowDialog() != DialogResult.OK) return;
            Player.AppendPlaylist(OpenMediaFile.FileName);
        }
    }
}
