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
        public List<FileInformation> Lists { get; set; }
        public FileInformation SelectedItem { get; set; } = new FileInformation();

        public SearchResultControl(VideoModel videoModel, int width)
        {
            InitializeComponent();

            // Width = width;
            LblTitle.Text = (string)videoModel.Detais["title"];
            LblAuthor.Text = (string)videoModel.Detais["author"];
            if (videoModel.Detais["status"].ToString().ToLower() != "ok")
                VideoStatus.Visible = true;

            SetImage(videoModel.Thumbnails.FirstOrDefault());

            Lists = videoModel.Lists;
            foreach (var item in videoModel.Lists)
            {
                comboBox1.Items.Add($"{item.Format} {item.FileType} {item.FileExtenction}");
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
                : comboBox1.SelectedIndex <= Lists.Count ? Lists.Count - 1
                : comboBox1.SelectedIndex - 1;
            SelectedItem = Lists[val];
        }
    }
}
