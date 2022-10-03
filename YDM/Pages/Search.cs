using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            flowLayoutPanel1.Controls.Clear();
            var uri = new UriAnalyzer(textBox1.Text);
            if (uri.IsProcessable || uri.Exception == null)
            {

                if (!uri.IsList)
                    flowLayoutPanel1.Controls.Add(new YDMYoutubeVideo(uri, uri.IsList));
                else
                {
                    try
                    {
                        var responseFromServer = await new RequestProcesser(uri.Url).DownloadString(false, new System.Threading.CancellationToken());
                        var process = new SorceProcesser();
                        var tokens = process.ParseListCode(responseFromServer);
                        var controls = from item in tokens
                                       select new YDMYoutubeVideo(item);

                        var index = 0;
                        while (true)
                        {
                            var tempItems = controls.Skip(index * 10).Take(10).ToArray();
                            if (tempItems.Length < 10)
                            {
                                flowLayoutPanel1.Controls.AddRange(tempItems);
                                break;
                            }
                            flowLayoutPanel1.Controls.AddRange(tempItems);
                            index++;
                            await Task.Delay(500);
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
