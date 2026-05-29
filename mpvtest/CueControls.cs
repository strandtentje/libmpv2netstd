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
    public partial class CueControls : Form
    {
        private MpvPlayer Player = null;

        public CueControls()
        {
            InitializeComponent();
        }

        internal void UsePlayer(MpvPlayer player)
        {
            if (Player != null) return;
            this.Player = player;

            this.Player.PauseChanged += Player_PauseChanged;
            this.Player.FileRepeatChanged += Player_FileRepeatChanged;
            this.Player.PlaylistRepeatChanged += Player_PlaylistRepeatChanged;
        }

        private void Player_PlaylistRepeatChanged(object sender, bool e)
        {
            this.Invoke(new Action(() =>
            {
                if (ChkRepeatPls.Checked != e)
                    ChkRepeatPls.Checked = e;
            }));
        }

        private void Player_FileRepeatChanged(object sender, bool e)
        {
            this.Invoke(new Action(() =>
            {
                if (ChkPauseFile.Checked != e)
                    ChkPauseFile.Checked = e;
            }));
        }

        private void Player_PauseChanged(object sender, bool e)
        {
            this.Invoke(new Action(() =>
            {
                if (ChkPauseFile.Checked != e)
                    ChkPauseFile.Checked = e;
            }));
        }

        private void ChkPauseFile_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkPauseFile.Checked != Player.IsPause)
                Player.IsPause = ChkPauseFile.Checked;
        }
        private void ChkRepeatFile_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkRepeatFile.Checked != Player.RepeatFile)
                Player.RepeatFile = ChkRepeatFile.Checked;
        }
        private void ChkRepeatPls_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkRepeatPls.Checked != Player.RepeatPlaylist)
                Player.RepeatPlaylist = ChkRepeatPls.Checked;
        }

        private void ButPrevPls_Click(object sender, EventArgs e)
        {
            Player.PreviousPlaylist();
        }

        private void ButReplay_Click(object sender, EventArgs e)
        {
            Player.ReplayCurrent();
        }

        private void ButPrev_Click(object sender, EventArgs e)
        {
            Player.Previous();
        }

        private void ButNext_Click(object sender, EventArgs e)
        {
            Player.Next();
        }

        private void ButClearPlaylist_Click(object sender, EventArgs e)
        {
            Player.ClearPlaylist();
        }

        private void ButStopPlaylist_Click(object sender, EventArgs e)
        {
            Player.StopPlaylist();
        }

        private void ButSkipAndRemove_Click(object sender, EventArgs e)
        {
            Player.SkipAndRemoveCurrent();
        }

        private void ButNextPlaylist_Click(object sender, EventArgs e)
        {
            Player.NextPlaylist();
        }
    }
}
