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
                this.ChkRepeatPls.CheckedChanged -= ChkRepeatPls_CheckedChanged;
                try
                {
                    this.ChkRepeatPls.Checked = e;
                }
                finally
                {
                    this.ChkRepeatPls.CheckedChanged += ChkRepeatPls_CheckedChanged;
                }
            }));
        }

        private void Player_FileRepeatChanged(object sender, bool e)
        {
            this.Invoke(new Action(() =>
            {
                this.ChkRepeatFile.CheckedChanged -= ChkRepeatFile_CheckedChanged;
                try
                {
                    this.ChkRepeatFile.Checked = e;
                }
                finally
                {
                    this.ChkRepeatFile.CheckedChanged += ChkRepeatFile_CheckedChanged;
                }
            }));
        }

        private void Player_PauseChanged(object sender, bool e)
        {
            this.Invoke(new Action(() =>
            {
                this.ChkPauseFile.CheckedChanged -= ChkPauseFile_CheckedChanged;
                try
                {
                    this.ChkPauseFile.Checked = e;
                }
                finally
                {
                    this.ChkPauseFile.CheckedChanged += ChkPauseFile_CheckedChanged;
                }
            }));
        }

        private void ChkPauseFile_CheckedChanged(object sender, EventArgs e)
        {
            this.Player.PauseChanged -= Player_PauseChanged;
            try
            {
                this.Player.IsPause = ChkPauseFile.Checked;
            }
            finally
            {
                this.Player.PauseChanged += Player_PauseChanged;
            }
        }
        private void ChkRepeatFile_CheckedChanged(object sender, EventArgs e)
        {
            this.Player.FileRepeatChanged -= Player_FileRepeatChanged;
            try
            {
                this.Player.RepeatFile = ChkRepeatFile.Checked;
            }
            finally
            {
                this.Player.FileRepeatChanged += Player_FileRepeatChanged;
            }   
        }
        private void ChkRepeatPls_CheckedChanged(object sender, EventArgs e)
        {
            this.Player.PlaylistRepeatChanged -= Player_PlaylistRepeatChanged;
            try
            {
                this.Player.RepeatPlaylist = ChkRepeatPls.Checked;
            }
            finally
            {
                this.Player.PlaylistRepeatChanged += Player_PlaylistRepeatChanged;
            }
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
