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
        public List<FileInformation> VideoLists { get; set; } = new List<FileInformation>();
        public List<FileInformation> AudioLists { get; set; } = new List<FileInformation>();
        public FileInformation SelectedVideo { get; set; } = new FileInformation();
        public FileInformation SelectedAudio { get; set; } = new FileInformation();

        public SearchResultControl(VideoModel videoModel)
        {
            InitializeComponent();

            LblTitle.Text = videoModel.Detais["title"].ToString();
            LblAuthor.Text = videoModel.Detais["author"].ToString();
            if (videoModel.Detais["status"].ToString().ToLower() != "ok")
                VideoStatus.Visible = true;

            SetImage(videoModel.Thumbnails.FirstOrDefault());

            foreach (var item in videoModel.Lists)
            {
                if (item.FileType == FileTypeEnum.video)
                {
                    comboBox1.Items.Add($"{item.Format} {item.FileExtenction}");
                    VideoLists.Add(item);
                }
                else
                {
                    comboBox2.Items.Add($"{item.Format} {item.FileExtenction}");
                    AudioLists.Add(item);
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var val = comboBox1.SelectedIndex > 0 ? 0
                : comboBox1.SelectedIndex <= VideoLists.Count ? VideoLists.Count - 1
                : comboBox1.SelectedIndex - 1;
            SelectedVideo = VideoLists[val];
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            var val = comboBox2.SelectedIndex > 0 ? 0
                : comboBox2.SelectedIndex <= AudioLists.Count ? AudioLists.Count - 1
                : comboBox2.SelectedIndex - 1;
            SelectedAudio = AudioLists[val];
        }
    }
}
