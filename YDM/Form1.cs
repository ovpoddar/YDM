using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using YDM.Concept;
using YDM.Concept.Models;

namespace YDM
{
    public partial class Form1 : Form
    {
        private YDMVideoProcesser _ydm;

        public Form1()
        {
            InitializeComponent();
        }

        private void FoundVideo(object sender, VideoModel e)
        {
            var str = Output.Text + (string)e.Detais["title"];
            Output.Text = str;
        }

        private void ErrorFound(object sender, Exception e)
        {
            // Log into some were;
        }

        public async void Search_Click(object sender, EventArgs e)
        {
            var text = URL.Text;
            Output.Text = "";

            _ydm = new YDMVideoProcesser(text, FoundVideo, ErrorFound);

            var ids = await _ydm.GetTaskAsync();

            Output.Text = Output.Text + ids.ToList().Count;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            _ydm.CancelProcesse();
        }
    }
}
