using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Security.Policy;
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
            var process = new SorceProcesser();
            if (uri.IsProcessable || uri.Exception == null)
            {
                if (!uri.IsList)
                    flowLayoutPanel1.Controls.Add(new YDMYoutubeVideo(process, uri, uri.IsList));
                else
                {
                    try
                    {
                        var responseFromServer = await new RequestProcesser(ref uri).DownloadString(false, new System.Threading.CancellationToken());

                        var tokens = process.ParseListCode(responseFromServer);
                        var controls = from item in tokens
                                       select new YDMYoutubeVideo(process, item);

                        foreach (var item in controls)
                        {
                            flowLayoutPanel1.Controls.Add(item);
                            await Task.Delay(500);
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show(uri.Exception.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var controls = flowLayoutPanel1.Controls.OfType<YDMYoutubeVideo>().Where(a => a.IsSelected);
            if(controls.Any())
            {
                var from  = (YDMForm)this.Parent;
                var download = (Download)from._currentChildForm[1];
                download.flowLayoutPanel1.Controls.AddRange(controls.ToArray());
            }

        }
    }
}
