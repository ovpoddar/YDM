using SHOpenFolderAndSelectItems;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using YDM.Concept;
using YDM.Concept.Models;
using YDM.Model;
using YDM.Properties;

namespace YDM.CustomeUserControl
{
    public partial class FileDownloadControl : UserControl
    {
        public DownloadState State;

        public YDMDownloader Downloader;
        public EventHandler<UserInteraction> Interaction_Happend;

        public FileDownloadControl(YDMDownloader downloader)
        {
            InitializeComponent();
            Downloader = downloader;
            LblName.Text = Downloader.Filename;
            LblInternalPath.Text = Path.Combine(Downloader.Storepath, Downloader.Filename);
            BtnCancel.Visible = true;
            BtnChangeState.Visible = true;
            Downloader.processing += OnProcessing;
            Downloader.DownloadstateChange += DownloadState_change;
            State = Downloader.DownloadState;
        }

        private void DownloadState_change(object sender, DownloadState e) => 
            State = e;

        private void OnProcessing(object sender, ProcessingModel e)
        {
            LblPercentage.Text = e.Percentage.ToString() + "%";
            ProgressBar.Value = e.Percentage;
            LblSizeMoniter.Text = $"{e.Filesize} of {Downloader.FileSize}"; 
        }

        private void BtnDispose_Click(object sender, EventArgs e)
        {
            if (Downloader.DownloadState != DownloadState.Stopped)
                Downloader.Stop();
            Dispose();
        }

        private void BtnOpenFolder_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(Downloader.Storepath))
                ShowSelectedInExplorer.FilesOrFolders(LblInternalPath.Text);
            else
                return;
        }

        public void BtnChangeState_Click(object sender, EventArgs e)
        {
            if (Downloader.DownloadState == DownloadState.Paused)
            {
                BtnChangeState.Text = "Resume";
                Downloader.Resume();
                Interaction_Happend.Invoke(this, UserInteraction.Resume);
            }
            else
            {
                BtnChangeState.Text = "Paused";
                Downloader.Pause();
                Interaction_Happend.Invoke(this, UserInteraction.Paused);
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Downloader.Stop();
            BtnCancel.Visible = false;
            BtnStart.Visible = true;
            Interaction_Happend.Invoke(this, UserInteraction.Stopped);
        }

        private void BtnRetry_Click(object sender, EventArgs e)
        {
            Downloader.Restart();
            BtnCancel.Visible = true;
            BtnStart.Visible = false;
        }
    }
}
