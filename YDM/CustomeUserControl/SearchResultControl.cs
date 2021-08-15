using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using YDM.Concept.Models;

namespace YDM.CustomeUserControl
{
    public partial class SearchResultControl : UserControl
    {
        public List<FileInformation> Lists { get; set; }
        public FileInformation SelectedItem { get; set; } = new FileInformation();

        public SearchResultControl(VideoModel videoModel, int width, Panel parent)
        {
            InitializeComponent();

            parent.AutoScroll = false;

            parent.HorizontalScroll.Enabled = false;
            parent.HorizontalScroll.Visible = false;
            parent.AutoScroll = true;

            Width = width;
            LblTitle.Text = (string)videoModel.Detais["title"];
            LblAuthor.Text = (string)videoModel.Detais["author"];
            if ((string)videoModel.Detais["status"] != "ok")
                VideoStatus.Visible = true;

            PicThumbnail.ImageLocation = videoModel.Thumbnails[0].Uri;
            PicThumbnail.Height = videoModel.Thumbnails[0].Height;
            PicThumbnail.Width = videoModel.Thumbnails[0].Width;

            Lists = videoModel.Lists;
            foreach (var item in videoModel.Lists)
            {
                comboBox1.Items.Add($"{item.Format} {item.FileType} {item.FileExtenction}");
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
