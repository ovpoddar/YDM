using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using YDM.Concept.Models;

namespace YDM.CustomeUserControl
{
    public partial class SearchResultControl : UserControl
    {
        public bool IsChecked;
        private FileInformation[] _selectedItem { get; set; } = new FileInformation[2];
        private List<FileInformation> _videoLists { get; set; } = new List<FileInformation>();
        private List<FileInformation> _audioLists { get; set; } = new List<FileInformation>();

        public FileDownloadControl DownloadControl
        {
            get
            {
                if (_selectedItem[0] == null)
                    return new FileDownloadControl(new Concept.YDMDownloader(_selectedItem[1], Properties.Settings.Default.DownloadPath, LblTitle.Text));
                else
                    return new FileDownloadControl(new Concept.YDMDownloader(_selectedItem[0],_selectedItem[1], Properties.Settings.Default.DownloadPath, LblTitle.Text));
            }

        }

        public SearchResultControl(VideoModel videoModel)
        {
            InitializeComponent();
            IsChecked = checkBox1.Checked;
            LblTitle.Text = videoModel.Detais["title"].ToString();
            LblAuthor.Text = videoModel.Detais["author"].ToString();
            if (videoModel.Detais["status"].ToString().ToLower() != "ok")
                VideoStatus.Visible = true;

            SetImage(videoModel.Thumbnails.FirstOrDefault());

            foreach (var item in videoModel.Lists)
            {
                if (item.FileType == FileTypeEnum.video)
                {
                    VideoComboBox.Items.Add($"{item.Format} {item.FileExtenction}");
                    _videoLists.Add(item);
                }
                else
                {
                    AudioComboBox.Items.Add($"{item.Format} {item.FileExtenction}");
                    _audioLists.Add(item);
                }
            }
        }

        private void SetImage(Thumbnail thumbnail)
        {

            var request = WebRequest.Create(thumbnail.Uri.Split("?")[0]);

            using (var response = request.GetResponse())
            using (var stream = response.GetResponseStream())
            {
                PicThumbnail.Image = Image.FromStream(stream);
            }
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var val = VideoComboBox.SelectedIndex < 0 ? 0
                : VideoComboBox.SelectedIndex >= _videoLists.Count ? _videoLists.Count - 1
                : VideoComboBox.SelectedIndex;
            _selectedItem[0] = _videoLists[val];

            if (AudioComboBox.SelectedIndex == -1)
            {
                var index = Map(VideoComboBox.SelectedIndex, 0, _videoLists.Count - 1, 0, _audioLists.Count - 1, false);
                AudioComboBox.SelectedIndex = (int)Math.Round(index, MidpointRounding.AwayFromZero);
            }
        }


        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            var val = AudioComboBox.SelectedIndex < 0 ? 0
                : AudioComboBox.SelectedIndex >= _audioLists.Count ? _audioLists.Count - 1
                : AudioComboBox.SelectedIndex;
            _selectedItem[1] = _audioLists[val];
        }

        public void SelectAudio(ComboBox element)
        {
            var mappedIndex = Map(element.SelectedIndex, 0, element.Items.Count - 1, 0, _audioLists.Count - 1, false);
            var roundedIndex = (int)Math.Round(mappedIndex, MidpointRounding.AwayFromZero);
            AudioComboBox.SelectedIndex = roundedIndex;
        }

        public void SelectVideo(ComboBox element)
        {
            var mappedIndex = Map(element.SelectedIndex, 0, element.Items.Count - 1, 0, _videoLists.Count - 1, false);
            var roundedIndex = (int)Math.Round(mappedIndex, MidpointRounding.AwayFromZero);
            VideoComboBox.SelectedIndex = roundedIndex;
        }

        public decimal Map(decimal n, decimal start1, decimal stop1, decimal start2, decimal stop2, bool withinBounds)
        {
            var newval = (n - start1) / (stop1 - start1) * (stop2 - start2) + start2;

            if (!withinBounds)
            {
                return newval;
            }
            if (start2 < stop2)
            {
                return Constrain(newval, start2, stop2);
            }
            else
            {
                return Constrain(newval, stop2, start2);
            }
        }

        private decimal Constrain(decimal n, decimal low, decimal high) => 
            Math.Max(Math.Min(n, high), low);
    }
}
