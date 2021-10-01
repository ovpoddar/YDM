using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using YDM.Concept.Models;
using YDM.CustomeUserControl;
using YDM.Helper;
using YDM.Model;

namespace YDM.Pages
{
    public partial class Download : Form
    {
        private readonly int _maxDownload = Properties.Settings.Default.MaxDownload;

        public Dictionary<int, FileDownloadControl> queue;

        public Download()
        {
            InitializeComponent();

            queue = SettingHelper.Lists();

            var i = 0;
            while (i < queue.Count)
            {
                queue[i].DownloadState_Change_UpperLayer += DownloadState_Change;
                queue[i].Interaction_Happend += UserInteraction_Occered;

                flowLayoutPanel1.Controls.Add(queue[i]);
                i++;
            }
        }

        public void BtnResumeAll_Click(object sender, EventArgs e)
        {
            for (var i = 0; i < queue.Count; i++)
            {
                if (i < _maxDownload && queue[i].State != DownloadState.Completed && queue[i].State == DownloadState.Initialized)
                {
                    queue[i].Downloader.Start();
                    queue[i].BtnChangeState.Text = "Paused";
                }
                else
                {
                    try
                    {
                        queue[i].Downloader.Pause();
                        queue[i].BtnChangeState.Text = "Resume";
                    }
                    catch { }
                }
            }
        }

        private void BtnPauseAll_Click(object sender, EventArgs e)
        {
            for (var i = 0; i < queue.Count; i++)
            {
                try
                {
                    queue[i].Downloader.Pause();
                    queue[i].BtnChangeState.Text = "Resume";
                }
                catch { }
            }
        }

        public void Add(FileDownloadControl downloader)
        {
            downloader.DownloadState_Change_UpperLayer += DownloadState_Change;
            downloader.Interaction_Happend += UserInteraction_Occered;
            queue.Add(queue.Count, downloader);
            flowLayoutPanel1.Controls.Add(downloader);
        }

        private void UserInteraction_Occered(object sender, UserInteraction e)
        {
            if (e == UserInteraction.Resume)
                MakeSureTheDownloadStateDousNotExid();
            else if (e == UserInteraction.Dispose)
            {
                SettingHelper.DeleteItem(queue.FirstOrDefault(a => a.Value == sender).Key);
                // remove files;
                var downloade = sender as FileDownloadControl;
                downloade.Downloader.Dispose();
                downloade.Dispose();
            }
        }

        public void Add(List<FileDownloadControl> downloaders)
        {
            var i = 0;
            while (i < downloaders.Count)
            {
                downloaders[i].DownloadState_Change_UpperLayer += DownloadState_Change;
                downloaders[i].Interaction_Happend += UserInteraction_Occered;

                SettingHelper.AddItem(downloaders[i].Downloader.FinalFile, downloaders[i].Downloader.Files);

                queue.Add(queue.Count, downloaders[i]);
                flowLayoutPanel1.Controls.Add(downloaders[i]);
                i++;
            }
        }

        private void DownloadState_Change(object sender, DownloadState e)
        {
            if (e == DownloadState.Completed || e == DownloadState.Paused || e == DownloadState.Stopped)
            {
                for (var i = 0; i < queue.Count; i++)
                {
                    if (queue[i].State == DownloadState.Initialized)
                    {
                        queue[i].Downloader.Start();
                        queue[i].BtnChangeState.Text = "Paused";
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
            for (var i = 0; i < queue.Count; i++)
            {
                if (queue[i].State == DownloadState.Downloading)
                    tempQueue.Add(queue[i]);
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
