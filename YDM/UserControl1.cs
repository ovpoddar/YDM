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
            label1.Text = _downloader.Filename;
            label2.Text = _downloader.Storepath;
        }

        private void process(object sender, ProcessingModel e)
        {
            label3.Text = $"{e.Percentage} %";
            progressBar1.Value = e.Percentage;
            label4.Text = $"{e.Filesize} / {_downloader.FileSize}";
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
