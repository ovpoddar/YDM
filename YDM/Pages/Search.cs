using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using YDM.Concept.Helper;
using YDM.Concept.Processer;
using YDM.CustomeUserControl;

namespace YDM.Pages
{
    public partial class Search : Form
    {
        public Search()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var uri = new UriAnalyzer(textBox1.Text);
            if (uri.IsProcessable || uri.Exception == null)
            {
                if (!uri.IsList)
                    flowLayoutPanel1.Controls.Add(new YDMYoutubeVideos(uri));
                else
                {
                    try
                    {
                        var responseFromServer = await new RequestProcesser(uri.Url).DownloadString(false, new System.Threading.CancellationToken());
                        var process = new SorceProcesser();
                        var tokens =  process.ParseListCode(responseFromServer);

                        foreach (var item in tokens)
                        {
                            flowLayoutPanel1.Controls.Add(new YDMYoutubeVideos(item));
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception();
                    }
                }
            }
            else
            {
                MessageBox.Show(uri.Exception.Message);
            }
        }
    }
}
