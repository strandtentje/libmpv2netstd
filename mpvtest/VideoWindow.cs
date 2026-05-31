using LibMpvWrapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace mpvtest
{
    public partial class VideoWindow : Form
    {
        private MpvPlayer Player;

        private readonly CueControls _cueControls = new CueControls();
        private readonly PlaylistControls _plsControls = new PlaylistControls();
        private readonly StatusView _statusView = new StatusView();
        private readonly TransportControls _transportControls = new TransportControls();

        public VideoWindow()
        {
            InitializeComponent();
            this.Shown += Form1_Shown;
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            var factory = new MpvPlayerFactory();
            this.Player = factory.CreatePlayer(this.Handle, PlaylistLifecycle.PauseAfterEnd);

            this.Player.Mute = true;

            _cueControls.Show(this);
            _plsControls.Show(this);
            _statusView.Show(this);
            _transportControls.Show(this);

            _cueControls.UsePlayer(this.Player);
            _plsControls.UsePlayer(this.Player);
            _statusView.UsePlayer(this.Player);
            _transportControls.UsePlayer(this.Player);

            this.PersistPosition();
            _cueControls.PersistPosition();
            _plsControls.PersistPosition();
            _statusView.PersistPosition();
            _transportControls.PersistPosition();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public new void Dispose()
        {
            base.Dispose();
            this.Player.Dispose();
        }

        private void VideoWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Player.Dispose();
        }
    }
}
