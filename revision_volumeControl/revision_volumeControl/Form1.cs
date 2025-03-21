using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace revision_volumeControl
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            trackBarVolume.Minimum = 0;
            trackBarVolume.Maximum = 100;
            trackBarVolume.Value = 50;
            axWindowsMediaPlayer1.settings.volume = trackBarVolume.Value;
            axWindowsMediaPlayer1.Visible = false;
            lblVolume.Text = $"Volume: {trackBarVolume.Value}%";

            trackBarVolume.Scroll += (s, e) => AdjustVolume();
            btnMute.Click += (s, e) => MuteMusic();
            btnPlay.Click += (s, e) => PlayMusic();
            btnPause.Click += (s, e) => PauseMusic();
            timer1.Tick += (s, e) => UpdateTime();
        }

        private void PlayMusic()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "MP3 Files|*.mp3";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                axWindowsMediaPlayer1.URL = openFileDialog.FileName;
                axWindowsMediaPlayer1.Ctlcontrols.play();
                timer1.Start(); 
            }
        }

        private void PauseMusic()
        {
            axWindowsMediaPlayer1.Ctlcontrols.pause();
        }

        private void MuteMusic()
        {
            axWindowsMediaPlayer1.settings.volume = 0;
            trackBarVolume.Value = 0;
        }
        private void AdjustVolume()
        {
            axWindowsMediaPlayer1.settings.volume = trackBarVolume.Value;
            lblVolume.Text = $"Volume: {trackBarVolume.Value}%";
        }
        private void UpdateTime()
        {
            if (axWindowsMediaPlayer1.currentMedia != null)
            {
                double currentTime = axWindowsMediaPlayer1.Ctlcontrols.currentPosition;
                double duration = axWindowsMediaPlayer1.currentMedia.duration;

                lblTime.Text = $"{FormatTime(currentTime)} / {FormatTime(duration)}";
            }
        }

        private string FormatTime(double seconds)
        {
            int min = (int)(seconds / 60);
            int sec = (int)(seconds % 60);
            return $"{min:D2}:{sec:D2}";
        }
    }
}
