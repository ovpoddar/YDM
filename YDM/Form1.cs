using Jurassic;
using System;
using System.Linq;
using System.Text.Json;
using System.Windows.Forms;
using YDM.ConfigurationsString;
using YDM.ExtendClasses;
using YDM.Processer;

namespace YDM
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Search_Click(object sender, EventArgs e)
        {
            var text = URL.Text;

            var url = UrlAnalyzer.Check(text);

            if (url.Success && url.Exception == null)
            {
                var responseFromServer = RequestManager.DownloadWebSite(url);

                var index = (responseFromServer.IndexOf(Configuration.ScriptBegin) + Configuration.ScriptBegin.Length);
                var responce = responseFromServer[index..];

                var para = responce.IndexOf(Configuration.ScriptEnd);

                var scr = responce.Remove(para);

                var document = JsonDocument.Parse(scr, new JsonDocumentOptions
                {
                    MaxDepth = 64,
                    AllowTrailingCommas = false
                });
                var root = document.RootElement;

                var format = root.FindProperty("formats");
                var adaptiveFormats = root.FindProperty("adaptiveFormats");

                var result = LinkProcesser.GetFormatsStream(format.FirstOrDefault().EnumerateArray());
                var result1 = LinkProcesser.GetFormatsStream(adaptiveFormats.FirstOrDefault().EnumerateArray());


                Output.Text = $"";

            }
            else
                MessageBox.Show(url.Exception);
        }
    }
}
