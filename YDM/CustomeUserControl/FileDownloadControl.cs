using SHOpenFolderAndSelectItems;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using YDM.Concept;
using YDM.Concept.Models;
using YDM.Helper;
using YDM.Model;
using YDM.Pages;

namespace YDM.CustomeUserControl
{
    public partial class FileDownloadControl : UserControl
    {
        public DownloadState State;

        public YDMDownloader Downloader;
        public EventHandler<UserInteraction> Interaction_Happend;
        public EventHandler<DownloadState> DownloadState_Change_UpperLayer;

        public FileDownloadControl(YDMDownloader downloader)
        {
           
            InitializeComponent();
            Downloader = downloader;
            LblName.Text = Downloader.FinalFileName;
            LblInternalPath.Text = downloader.FinalFile;
            BtnCancel.Visible = true;
            BtnChangeState.Visible = true;
            Downloader.processing += OnProcessing;
            Downloader.DownloadstateChange += DownloadState_change;
            State = Downloader.DownloadState;
            LblSizeMoniter.Text = $"{downloader.LocalFile.ReadableFileSize} of {downloader.RemoteFile.ReadableFileSize}";
            var percentage = Convert.ToInt16(100 / downloader.RemoteFile.FileSize * downloader.LocalFile.FileSize);
            LblPercentage.Text = percentage.ToString() + "%";
            ProgressBar.Value = percentage;
        }

        private void DownloadState_change(object sender, DownloadState e)
        {
            State = e;

            if (e == DownloadState.Completed)
            {
                BtnCancel.Visible = false;
                BtnChangeState.Visible = false;
                BtnOpenFolder.Visible = true;
            }
            DownloadState_Change_UpperLayer.Raise(this, e);
        }

        private void OnProcessing(object sender, ProcessingModel e)
        {
            LblPercentage.Text = e.Percentage.ToString() + "%";
            ProgressBar.Value = e.Percentage;
            LblSizeMoniter.Text = $"{e.ReadableFilesize} of {Downloader.RemoteFile.ReadableFileSize}";
        }

        private void BtnDispose_Click(object sender, EventArgs e)
        {
            if (Downloader.DownloadState != DownloadState.Stopped)
                Downloader.Stop();
            else
                Interaction_Happend.Raise(this, UserInteraction.Dispose);
        }

        private void BtnOpenFolder_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(Path.GetDirectoryName(Downloader.FinalFile)))
                ShowSelectedInExplorer.FilesOrFolders(LblInternalPath.Text);
            else
                return;
        }

        public void BtnChangeState_Click(object sender, EventArgs e)
        {
            if (Downloader.DownloadState == DownloadState.Paused || Downloader.DownloadState == DownloadState.GettingHeaders)
            {
                BtnChangeState.Text = "Pause";
                Downloader.Resume();
                Interaction_Happend.Raise(this, UserInteraction.Resume);
            }
            else if (Downloader.DownloadState == DownloadState.Initialized)
            {
                BtnChangeState.Text = "Pause";
                Downloader.Start();
                Interaction_Happend.Raise(this, UserInteraction.Resume);
            }
            else
            {
                BtnChangeState.Text = "Resume";
                Downloader.Pause();
                Interaction_Happend.Raise(this, UserInteraction.Paused);
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Downloader.Stop();
            BtnCancel.Visible = false;
            BtnStart.Visible = true;
            Interaction_Happend.Raise(this, UserInteraction.Stopped);
        }

        private void BtnRetry_Click(object sender, EventArgs e)
        {
            Downloader.Restart();
            BtnCancel.Visible = true;
            BtnStart.Visible = false;
        }
    }
}
