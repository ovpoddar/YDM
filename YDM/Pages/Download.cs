﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using YDM.Concept.Models;
using YDM.CustomeUserControl;
using YDM.Model;

namespace YDM.Pages
{
    public partial class Download : Form
    {
        private const int _maxDownload = 2;

        public Dictionary<int, FileDownloadControl> _queue;

        public Download()
        {
            InitializeComponent();
            _queue = new Dictionary<int, FileDownloadControl>();
        }

        public void BtnResumeAll_Click(object sender, EventArgs e)
        {
            for (var i = 0; i < _queue.Count; i++)
            {
                if (i < _maxDownload && _queue[i].State != DownloadState.Completed)
                {
                    _queue[i].Downloader.Start();
                    _queue[i].BtnChangeState.Text = "Paused";
                }
                else
                {
                    try
                    {
                        _queue[i].Downloader.Pause();
                        _queue[i].BtnChangeState.Text = "Resume";
                    }
                    catch { }
                }
            }
        }

        private void BtnPauseAll_Click(object sender, EventArgs e)
        {
            for (var i = 0; i < _queue.Count; i++)
            {
                try
                {
                    _queue[i].Downloader.Pause();
                    _queue[i].BtnChangeState.Text = "Resume";
                }
                catch { }
            }
        }

        public void Add(FileDownloadControl downloader)
        {
            downloader.Downloader.DownloadstateChange += DownloadState_Change;
            downloader.Interaction_Happend += UserInteraction_Occered;
            _queue.Add(_queue.Count, downloader);
            flowLayoutPanel1.Controls.Add(downloader);
        }

        private void UserInteraction_Occered(object sender, UserInteraction e)
        {
            if (e == UserInteraction.Resume)
                MakeSureTheDownloadStateDousNotExid();
        }

        public void Add(List<FileDownloadControl> downloaders)
        {
            var i = 0;
            while (i < downloaders.Count)
            {
                _queue.Add(_queue.Count, downloaders[i]);
                flowLayoutPanel1.Controls.Add(downloaders[i]);
                i++;
            }
        }

        private void DownloadState_Change(object sender, DownloadState e)
        {
            if (e == DownloadState.Completed || e == DownloadState.Paused || e == DownloadState.Stopped)
            {
                for (var i = 0; i < _queue.Count; i++)
                {
                    if (_queue[i].State == DownloadState.Initialized)
                    {
                        _queue[i].Downloader.Start();
                        _queue[i].BtnChangeState.Text = "Paused";
                        break;
                    }
                }
                MakeSureTheDownloadStateDousNotExid();
            }
            else
            {
            }
        }

        private void MakeSureTheDownloadStateDousNotExid()
        {
            var tempQueue = new List<FileDownloadControl>();
            for (var i = 0; i < _queue.Count; i++)
            {
                if (_queue[i].State == DownloadState.Downloading)
                    tempQueue.Add(_queue[i]);
            }

            if (tempQueue.Count > _maxDownload)
            {
                for (var i = 0; i < tempQueue.Count; i++)
                {
                    if (i >= _maxDownload)
                        continue;
                    else
                    {
                        tempQueue[i].Downloader.Pause();
                        tempQueue[i].BtnChangeState.Text = "Resume";
                    }
                }
            }
        }

    }
}
