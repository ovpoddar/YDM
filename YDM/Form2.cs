using System.Linq;
using System.Windows.Forms;
using YDM.Concept;

namespace YDM
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public void Add(YDMDownloader downloader)
        {
            var control = new UserControl1(downloader);
            flowLayoutPanel1.Controls.Add(control);
        }

        public void Start()
        {
            var _maxDownload = 2;
            var queue = flowLayoutPanel1.Controls.OfType<UserControl1>().ToArray();
            for (int i = 0; i < queue.Count(); i++)
            {
                if (i < _maxDownload)
                    queue[i]._downloader.Start();
                else
                    queue[i]._downloader.Pause();
            }
        }
    }
}
