﻿using System;
using System.Windows.Forms;
using YDM.Concept.Models;

namespace YDM
{
    public partial class Form1 : Form
    {
        private Concept.YDM _ydm;
        public Form1()
        {
            InitializeComponent();
            _ydm = new Concept.YDM();
            _ydm.ErrorFound += ErrorFound;
        }

        private void FoundVideo(object sender, VideoModel e)
        {
            var str = Output.Text + (string)e.Detais["title"];
            Output.Text = str;
        }

        private void ErrorFound(object sender, Exception e)
        {
            // Log into some were;
        }

        public async void Search_Click(object sender, EventArgs e)
        {
            var text = URL.Text;
            Output.Text = "";
            var ids = await _ydm.GetIDsAsync(text);
            var pro = new Progress<VideoModel>();
            pro.ProgressChanged += FoundVideo;
            var videos = _ydm.GetVideos(ids, pro, default);
        }

    }
}
