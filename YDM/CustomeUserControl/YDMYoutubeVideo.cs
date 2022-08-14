using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

        public YDMYoutubeVideo(UriAnalyzer link)
        {
            InitializeComponent();
            this.OnStageChange += YDMYoutubeVideos_OnStageChange;
            _ = PrepareYDMYoutubeVideo(link);
        }

        async Task PrepareYDMYoutubeVideo(UriAnalyzer link)
        {
            var processer = new SorceProcesser();
            var responseFromServer = await new RequestProcesser(link.Url).DownloadString(false, _processToken.Token);

            var success = await processer.ParseVideoCode(responseFromServer, _processToken.Token);
            
            if(success)
            {
                LBLName.Text = processer.Details["title"].ToString();
                LblAuthor.Text = processer.Details["author"].ToString();
                foreach (var item in processer.Streans)
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

        private void YDMYoutubeVideos_OnStageChange(object sender, EventArgs e)
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
            this.Dispose();
        }

        #endregion
    }
}
