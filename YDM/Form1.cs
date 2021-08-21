using System;
using System.Threading;
using System.Windows.Forms;
using YDM.Concept;
using YDM.Concept.Models;
using YDM.CustomeUserControl;
using YDM.Pages;

namespace YDM
{
    public partial class Form1 : Form
    {
        private CancellationTokenSource _cancellationTokenSource;
        private Button _cancellationBtn;
        private FileInformation[] _files = new FileInformation[2];
        //private Form2 _downloader;

        public Form1()
        {
            InitializeComponent();

        }

        private void FoundVideo(object sender, VideoModel e)
        {
            _files[0] = (e.Lists[2]);
            _files[1] = (e.Lists[4]);
        }

        private void ErrorFound(object sender, Exception e)
        {
            _cancellationBtn.Dispose();
            _cancellationTokenSource.Dispose();
            // Log into some were;
        }

        public async void Search_Click(object sender, EventArgs e)
        {
            var text = URL.Text;

            var _ydm = new YDMVideoProcesser(text, FoundVideo, ErrorFound);

            _ydm.StartProcess += starthandler;
            _cancellationTokenSource = new CancellationTokenSource();
            var ids = await _ydm.GetTaskAsync(_cancellationTokenSource.Token);

            _ydm.EndProcess += endhandler;
        }

        private void endhandler(object sender, EventArgs e)
        {
            _cancellationBtn.Dispose();
            _cancellationTokenSource.Dispose();
        }

        private void starthandler(object sender, EventArgs e)
        {
            _cancellationBtn = new Button()
            {
                Text = "Cancel",
                TextAlign = System.Drawing.ContentAlignment.MiddleCenter

            };
            _cancellationBtn.Click += CancelBtn_Click;
            flowLayoutPanel1.Controls.Add(_cancellationBtn);
        }

        private void CancelBtn_Click(object sender, EventArgs e) =>
            _cancellationTokenSource.Cancel();

        private void BtnDownload_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var downloader = new Download();
            downloader.Add(new FileDownloadControl(new YDMDownloader(_files[0], _files[1], @"C:\Users\Ayan\Desktop", "test1")));
            downloader.Add(new FileDownloadControl(new YDMDownloader(_files[0], _files[1], @"C:\Users\Ayan\Desktop", "test2")));
            downloader.Add(new FileDownloadControl(new YDMDownloader(_files[0], _files[1], @"C:\Users\Ayan\Desktop", "test3")));
            downloader.BtnResumeAll_Click(this, EventArgs.Empty);

            downloader.Show();
        }
    }
}
