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
    public partial class StatusView : Form
    {
        private MpvPlayer Player;

        public StatusView()
        {
            InitializeComponent();
        }

        internal void UsePlayer(MpvPlayer player)
        {
            this.Player = player;
            player.FileNameChanged += Player_FileNameChanged;
            player.PathChanged += Player_PathChanged;
            player.MediaTitleChanged += Player_MediaTitleChanged;
            player.DurationChanged += Player_DurationChanged;

            player.IdleChanged += Player_IdleChanged;
            player.EofChanged += Player_EofChanged;
            player.PauseChanged += Player_PauseChanged;
            player.MuteChanged += Player_MuteChanged;
            player.FileRepeatChanged += Player_FileRepeatChanged;
            player.PlaylistRepeatChanged += Player_PlaylistRepeatChanged;

            player.PercentageChanged += Player_PercentageChanged;
            player.TimeChanged += Player_TimeChanged;
            player.PlaylistIndexChanged += Player_PlaylistIndexChanged;
            player.PlaybackIndexChanged += Player_PlaybackIndexChanged;
            player.PlaylistCountChanged += Player_PlaylistCountChanged;

            player.NonPropertyEvent += this.Player_NonPropertyEvent;
            player.EndOfFile += Player_EndOfFile;
            player.Stopped += Player_Stopped;
            player.Quit += Player_Quit;
            player.FileError += Player_FileError;
            player.Redirect += Player_Redirect;
        }

        private void Player_Redirect(object sender, EndFileEventArgs e)
        {
            this.Invoke(new Action<object>(_ =>
            {
                LstEvents.Items.Add("ENDFILE:REDIRECT");
                if (!LstEvents.Focused && LstEvents.SelectedItems.Count == 0)
                {
                    LstEvents.TopIndex = LstEvents.Items.Count - 1;                     
                }
            }), new object[] { null });
        }

        private void Player_FileError(object sender, EndFileEventArgs e)
        {
            this.Invoke(new Action<object>(_ =>
            {
                LstEvents.Items.Add("ENDFILE:FILEERROR");
                if (!LstEvents.Focused && LstEvents.SelectedItems.Count == 0)
                {
                    LstEvents.TopIndex = LstEvents.Items.Count - 1;
                }
            }), new object[] { null });
        }

        private void Player_Quit(object sender, EndFileEventArgs e)
        {
            this.Invoke(new Action<object>(_ =>
            {
                LstEvents.Items.Add("ENDFILE:QUIT");
                if (!LstEvents.Focused && LstEvents.SelectedItems.Count == 0)
                {
                    LstEvents.TopIndex = LstEvents.Items.Count - 1;
                }
            }), new object[] { null });
        }

        private void Player_Stopped(object sender, EndFileEventArgs e)
        {
            this.Invoke(new Action<object>(_ =>
            {
                LstEvents.Items.Add("ENDFILE:STOPPED");
                if (!LstEvents.Focused && LstEvents.SelectedItems.Count == 0)
                {
                    LstEvents.TopIndex = LstEvents.Items.Count - 1;
                }
            }), new object[] { null });
        }

        private void Player_EndOfFile(object sender, EndFileEventArgs e)
        {
            this.Invoke(new Action<object>(_ =>
            {
                LstEvents.Items.Add("ENDFILE:EOF");
                if (!LstEvents.Focused && LstEvents.SelectedItems.Count == 0)
                {
                    LstEvents.TopIndex = LstEvents.Items.Count - 1;
                }
            }), new object[] { null });
        }

        private void Player_NonPropertyEvent(object sender, libmpv2net.mpv_event e)
        {
            if (e.event_id == libmpv2net.mpv_event_id.AudioReconfig || e.event_id == libmpv2net.mpv_event_id.VideoReconfig)
                return;
            this.Invoke(new Action<object>(_ =>
            {
                LstEvents.Items.Add(e.event_id);
                if (!LstEvents.Focused && LstEvents.SelectedItems.Count == 0)
                    LstEvents.TopIndex = LstEvents.Items.Count - 1;
            }), new object[] { null });
        }

        private void Player_MuteChanged(object sender, bool e)
        {
            this.Invoke(new Action(() =>
            {
                ChkMuted.Checked = e;
            }));
        }

        private void Player_PlaylistCountChanged(object sender, long e)
        {
            this.Invoke(new Action(() =>
            {
                TxtPlaylistCount.Text = e.ToString();
            }));
        }

        private void Player_PlaybackIndexChanged(object sender, long e)
        {
            this.Invoke(new Action(() =>
            {
                TxtPlbIndex.Text = e.ToString();
            }));
        }

        private void Player_PlaylistIndexChanged(object sender, long e)
        {
            this.Invoke(new Action(() =>
            {
                TxtPlsIndex.Text = e.ToString();
            }));
        }

        private void Player_TimeChanged(object sender, double e)
        {
            this.Invoke(new Action(() =>
            {
                TxtTimePos.Text = e.ToString("0.00");
            }));
        }

        private void Player_PercentageChanged(object sender, double e)
        {
            this.Invoke(new Action(() =>
            {
                TxtPercPos.Text = e.ToString("0.00");
            }));
        }

        private void Player_PlaylistRepeatChanged(object sender, bool e)
        {
            this.Invoke(new Action(() =>
            {
                ChkRepeatPls.Checked = e;
            }));
        }

        private void Player_FileRepeatChanged(object sender, bool e)
        {
            this.Invoke(new Action(() =>
            {
                ChkRepeat.Checked = e;
            }));
        }

        private void Player_PauseChanged(object sender, bool e)
        {
            this.Invoke(new Action(() =>
            {
                ChkPause.Checked = e;
            }));
        }

        private void Player_EofChanged(object sender, bool e)
        {
            this.Invoke(new Action(() =>
            {
                ChkEof.Checked = e;
            }));
        }

        private void Player_IdleChanged(object sender, bool e)
        {
            this.Invoke(new Action(() =>
            {
                ChkIdle.Checked = e;
            }));
        }

        private void Player_DurationChanged(object sender, double e)
        {
            this.Invoke(new Action(() =>
            {
                TxtCurrentDuration.Text = e.ToString();
            }));
        }

        private void Player_MediaTitleChanged(object sender, string e)
        {
            this.Invoke(new Action(() =>
            {
                TxtCurrentTitle.Text = e;
            }));
        }

        private void Player_PathChanged(object sender, string e)
        {
            this.Invoke(new Action(() =>
            {
                TxtCurrentPath.Text = e;
            }));
        }

        private void Player_FileNameChanged(object sender, string e)
        {
            this.Invoke(new Action(() =>
            {
                TxtCurrentFile.Text = e;
            }));
        }

        private void LstEvents_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                LstEvents.SelectedItem = null;
            }
        }
    }
}
