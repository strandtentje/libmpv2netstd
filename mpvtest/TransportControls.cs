using LibMpvWrapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mpvtest
{
    public partial class TransportControls : Form
    {
        private MpvPlayer Player;

        public TransportControls()
        {
            InitializeComponent();
        }

        internal void UsePlayer(MpvPlayer player)
        {
            this.Player = player;
            this.Player.PercentageChanged += Player_PercentageChanged;
            this.Player.TimeChanged += Player_TimeChanged;
            this.Player.PauseChanged += Player_PauseChanged;
            this.Player.FileRepeatChanged += Player_FileRepeatChanged;
        }
        private void Player_MuteChanged(object sender, bool e)
        {
            this.Invoke(new Action(() =>
            {
                this.ChkMuted.CheckedChanged -= ChkMuted_CheckedChanged;
                try
                {
                    this.ChkMuted.Checked = e;
                }
                finally
                {
                    this.ChkMuted.CheckedChanged += ChkMuted_CheckedChanged;
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
                    Debug.WriteLine("event pause going from chk={0} to player={1}", ChkPauseFile.Checked, e);
                    this.ChkPauseFile.Checked = e;
                }
                finally
                {
                    this.ChkPauseFile.CheckedChanged += ChkPauseFile_CheckedChanged;
                }
            }));
        }

        private void Player_TimeChanged(object sender, double e)
        {
            this.Invoke(new Action(() =>
            {
                TxtTime.Text = TimeSpan.FromSeconds(e).ToString(@"hh\:mm\:ss");
            }));
        }

        private void Player_PercentageChanged(object sender, double e)
        {
            this.Invoke(new Action(() =>
            {
                TxtPercentage.Text = string.Format("{0}%", e.ToString("000.0"));
                TrackProgress.Value = Math.Min(100, Math.Max(0, (int)e));
            }));
        }

        private void TxtPercentage_Enter(object sender, EventArgs e)
        {
            if (this.Player == null) return;
            this.Player.PercentageChanged -= Player_PercentageChanged;
        }

        private void TxtPercentage_Leave(object sender, EventArgs e)
        {
            if (this.Player == null) return;
            this.Player.PercentageChanged += Player_PercentageChanged;
        }

        private void TrackProgress_Enter(object sender, EventArgs e)
        {
            if (this.Player == null) return;
            this.Player.PercentageChanged -= Player_PercentageChanged;
        }

        private void TrackProgress_Leave(object sender, EventArgs e)
        {
            if (this.Player == null) return;
            this.Player.PercentageChanged += Player_PercentageChanged;
        }

        private void TxtTime_Enter(object sender, EventArgs e)
        {
            if (this.Player == null) return;
            this.Player.TimeChanged -= Player_TimeChanged;
        }

        private void TxtTime_Leave(object sender, EventArgs e)
        {
            if (this.Player == null) return;
            this.Player.TimeChanged += Player_TimeChanged;
        }

        private void TxtPercentage_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    ChkPauseFile.Focus();
                    break;
                case Keys.Enter:
                    var vlu = new string(TxtPercentage.Text.Where(char.IsNumber).ToArray());

                    ChkPauseFile.Focus();

                    if (int.TryParse(vlu, NumberStyles.Integer, CultureInfo.InvariantCulture, out int prc))
                    {
                        Player.SeekAbsolutePercent(prc);
                    }
                    break;
            }
        }

        private void TrackProgress_MouseUp(object sender, MouseEventArgs e)
        {
            var vlu = TrackProgress.Value;

            ChkPauseFile.Focus();

            Player.SeekAbsolutePercent(vlu);
        }

        private void TrackProgress_KeyUp(object sender, KeyEventArgs e)
        {
            Player.SeekAbsolutePercent(TrackProgress.Value);
        }

        private void TxtTime_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    ChkPauseFile.Focus();
                    break;
                case Keys.Enter:
                    var vlu = TxtTime.Text;

                    ChkPauseFile.Focus();

                    if (TimeSpan.TryParse(vlu, CultureInfo.InvariantCulture, out var r))
                    {
                        Player.SeekAbsoluteSeconds((int)r.TotalSeconds);
                    }
                    break;
            }
        }

        private void ButSeekRelBack10_Click(object sender, EventArgs e)
        {
            Player.SeekRelativeSeconds(-10);
        }

        private void ButSeekRelFwd10_Click(object sender, EventArgs e)
        {
            Player.SeekRelativeSeconds(10);
        }

        private void ButSeekPercBack10_Click(object sender, EventArgs e)
        {
            Player.SeekRelativePercent(-10);
        }

        private void ButGo0_Click(object sender, EventArgs e)
        {
            Player.SeekAbsolutePercent(0);
        }

        private void ButGo50_Click(object sender, EventArgs e)
        {
            Player.SeekAbsolutePercent(50);
        }

        private void ButSeekPercFwd10_Click(object sender, EventArgs e)
        {
            Player.SeekRelativePercent(10);
        }

        private void ButPrevFrame_Click(object sender, EventArgs e)
        {
            Player.FrameStep(-1);
        }

        private void ButNextFrame_Click(object sender, EventArgs e)
        {
            Player.FrameStep(1);
        }

        private void ChkSeekToKeyframe_CheckedChanged(object sender, EventArgs e)
        {
            Player.IsSeekToKeyframes = ChkSeekToKeyframe.Checked;
        }

        private void ChkPlayAfterFrameSeek_CheckedChanged(object sender, EventArgs e)
        {
            Player.IsFramestepImmediate = ChkPlayAfterFrameSeek.Checked;
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

        private void ChkPauseFile_CheckedChanged(object sender, EventArgs e)
        {
            this.Player.PauseChanged -= Player_PauseChanged;
            try
            {                
                Debug.WriteLine("user pause going from player={0} to chk={1}", this.Player.IsPause, ChkPauseFile.Checked);
                this.Player.IsPause = ChkPauseFile.Checked;
            }
            finally
            {
                this.Player.PauseChanged += Player_PauseChanged;
            }
        }

        private void ChkMuted_CheckedChanged(object sender, EventArgs e)
        {
            this.Player.MuteChanged -= Player_MuteChanged;
            try
            {
                this.Player.IsMute = ChkMuted.Checked;
            }
            finally
            {
                this.Player.MuteChanged += Player_MuteChanged;
            }
        }

        private void ButFullStop_Click(object sender, EventArgs e)
        {
            Player.FullStop();
        }

        private void ChkStopClear_CheckedChanged(object sender, EventArgs e)
        {
            if (Player.IsStopClear != ChkStopClear.Checked)
                Player.IsStopClear = ChkStopClear.Checked;
        }

        private void ChkMuteDuringFrameSeek_CheckedChanged(object sender, EventArgs e)
        {
            if (Player.IsFramestepMuted != ChkMuteDuringFrameSeek.Checked)
                ChkMuteDuringFrameSeek.Checked = Player.IsFramestepMuted;
        }

    }
}
