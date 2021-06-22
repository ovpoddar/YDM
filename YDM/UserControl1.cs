using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using YDM.Concept;
using YDM.Concept.Models;

namespace YDM
{
    public partial class UserControl1 : UserControl
    {
        public readonly YDMDownloader _downloader;

        public UserControl1(YDMDownloader downloader)
        {
            InitializeComponent();
            _downloader = downloader;
            _downloader.processing += process;

        }

        private void process(object sender, double e)
        {
            progressBar1.Value = 50;
        }

        private UserControl1()
        {
            InitializeComponent();
        }

        private void BtnStop_Click(object sender, EventArgs e)
        {
            _downloader.Stop();
        }

        private void BtnRestart_Click(object sender, EventArgs e)
        {
            _downloader.Restart();
        }

        private void BtnPause_Click(object sender, EventArgs e)
        {
            _downloader.Pause();
        }

        private void BtnPlay_Click(object sender, EventArgs e)
        {
            _downloader.Start();
        }
    }
}
