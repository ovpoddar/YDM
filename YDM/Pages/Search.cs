using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using YDM.Concept;
using YDM.Concept.Models;
using YDM.CustomeUserControl;

namespace YDM.Pages
{
    public partial class Search : Form
    {
        // TODO: fix the issue of resizing if you drag the from a littile bit down then the content are not resizing

        private CancellationTokenSource _cancellationTokenSource;
        private Button _cancellationBtn;
        public Search()
        {
            InitializeComponent();



            panelSearchResult.AutoScroll = false;

            panelSearchResult.HorizontalScroll.Enabled = false;
            panelSearchResult.HorizontalScroll.Visible = false;
            panelSearchResult.AutoScroll = true;
        }

        private void TextBox1_MouseEnter(object sender, EventArgs e)
        {
            panelTextBox.BackColor = Color.FromArgb(215, 36, 36);
        }

        private void TextBox1_MouseLeave(object sender, EventArgs e)
        {
            panelTextBox.BackColor = Color.FromArgb(49, 57, 66);
        }

        private async void TextBox1_KeyDownAsync(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                panelSearch.Dock = DockStyle.Top;
                panel2.Dock = DockStyle.Top;
                panel3.Dock = DockStyle.Bottom;
                panelSearchResult.Dock = DockStyle.Fill;


                var text = txtSearchBox.Text;

                var _ydm = new YDMVideoProcesser(text, FoundVideo, ErrorFound);

                _ydm.StartProcess += Starthandler;
                _cancellationTokenSource = new CancellationTokenSource();
                var ids = await _ydm.GetTaskAsync(_cancellationTokenSource.Token);

                _ydm.EndProcess += Endhandler;
            }
        }

        private void FoundVideo(object sender, VideoModel e)
        {
            var result = new SearchResultControl(e, 1200);
            panelSearchResult.Controls.Add(result);
            BtnStartDownload.Visible = true;
        }

        private void ErrorFound(object sender, Exception e)
        {
            _cancellationBtn.Dispose();
            _cancellationTokenSource.Dispose();
            // Log into some were;
        }


        private void Endhandler(object sender, EventArgs e)
        {
            _cancellationBtn.Dispose();
            _cancellationTokenSource.Dispose();
        }

        private void Starthandler(object sender, EventArgs e)
        {
            _cancellationBtn = new Button()
            {
                Text = "Cancel",
                TextAlign = System.Drawing.ContentAlignment.MiddleCenter

            };
            _cancellationBtn.Click += CancelBtn_Click;
            panel1.Controls.Add(_cancellationBtn);
        }

        private void CancelBtn_Click(object sender, EventArgs e) =>
            _cancellationTokenSource.Cancel();

        private void Search_Load(object sender, EventArgs e)
        {
            ActiveControl = null;
        }

        private void TxtSearchBox_MouseClick(object sender, MouseEventArgs e)
        {
            txtSearchBox.MouseLeave -= TextBox1_MouseLeave;
            txtSearchBox.LostFocus += TxtSearchBox_LostFocus;
        }

        private void TxtSearchBox_LostFocus(object sender, EventArgs e)
        {
            txtSearchBox.MouseLeave += TextBox1_MouseLeave;
        }

        private void BtnStartDownload_Click(object sender, EventArgs e)
        {

        }
    }
}
