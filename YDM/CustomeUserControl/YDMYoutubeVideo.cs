using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using YDM.Concept.Helper;
using YDM.Concept.Models;
using YDM.Concept.Processer;
using YDM.Models;

namespace YDM.CustomeUserControl
{
    public partial class YDMYoutubeVideo : UserControl
    {
        const int _width = 1267;

        private Stage _stage;
        private CancellationTokenSource _processToken = new CancellationTokenSource();

        public event EventHandler OnStageChange;

        public Stage Stage
        {
            get => _stage;
            private set
            {
                OnStageChange?.Invoke(this, EventArgs.Empty);
                _stage = value;
            }
        }

        private YDMYoutubeVideo()
        {
            InitializeComponent();
        }

        public YDMYoutubeVideo(SorceProcesser processer, UriAnalyzer link, bool isList = true)
        {
            InitializeComponent();
            this.OnStageChange += YDMYoutubeVideos_OnStageChange;
            PrepareYDMYoutubeVideo(processer, link, isList);
        }

        async void PrepareYDMYoutubeVideo(SorceProcesser processer, UriAnalyzer link, bool isList)
        {
            var responseFromServer = await new RequestProcesser(link.Url)
                .DownloadString(false, _processToken.Token);
            if (isList)
            {
                processer.ProcessedVideo += Processer_ProcessedVideo;
                await processer.ParseVideoCode(responseFromServer, _processToken.Token);
            }
            else
            {
                var responce = await processer.ParseVideoCode(responseFromServer, _processToken.Token, true);
                Processer_ProcessedVideo(this, responce);
            }
        }

        private async void Processer_ProcessedVideo(object sender, VideoProcessModel e)
        {
            if (e.Success)
            {
                await this.SetImage(e.Thumbnails.First());
                LBLName.Text = e.Details["title"].ToString();
                LblAuthor.Text = e.Details["author"].ToString();
                foreach (var item in e.Streans)
                {
                    if (item.FileType == FileTypeEnum.video)
                    {
                        VideoComboBox.Items.Add($"{item.Format} {item.FileExtenction}");
                    }
                    else
                    {
                        AudioComboBox.Items.Add($"{item.Format} {item.FileExtenction}");
                    }
                }
            }
        }

        async Task SetImage(Thumbnail thumbnail)
        {
            var request = WebRequest.Create(thumbnail.Uri.Split("?")[0]);

            using (var response = await request.GetResponseAsync())
            using (var stream = response.GetResponseStream())
            {
                pictureBox1.Image = Image.FromStream(stream);
            }
        }

        void YDMYoutubeVideos_OnStageChange(object sender, EventArgs e)
        {
            panel1.Width = Stage == Stage.Preview ? 0 : _width;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        #region Downloading Work
        private void Remove_Click(object sender, EventArgs e)
        {
            GC.Collect();
            _processToken.Cancel();
            _processToken.Dispose();
            this.Dispose();
        }

        #endregion
    }
}
