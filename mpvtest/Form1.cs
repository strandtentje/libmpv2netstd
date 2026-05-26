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
    public partial class Form1 : Form
    {
        private MpvPlayer Player;

        public Form1()
        {
            InitializeComponent();
            this.Shown += Form1_Shown;
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            var factory = new MpvPlayerFactory();
            this.Player = factory.CreatePlayer(this.Handle, PlaylistLifecycle.PauseAfterEnd);

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.Player.PlayNow(openFileDialog1.FileName);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public new void Dispose()
        {
            base.Dispose();
            this.Player.Dispose();
        }
    }
}
