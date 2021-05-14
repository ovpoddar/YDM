using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using YDM.Concept.Models;

namespace YDM
{
    public partial class Form1 : Form
    {
        private Concept.YDM _ydm;
        public Form1()
        {
            InitializeComponent();
            _ydm = new Concept.YDM();
            _ydm.VideoFound += FoundVideo;
            _ydm.ErrorFound += ErrorFound;
        }

        private void FoundVideo(object sender, IQueryable<VideoModel> e)
        {
            var str = Output.Text + (string)e.FirstOrDefault().Detais["title"];
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
            await _ydm.ParseVideoAsync(text);
        }

    }
}
