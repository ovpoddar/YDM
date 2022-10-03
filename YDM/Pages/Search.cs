using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using YDM.Concept;
using YDM.Concept.Models;
using YDM.CustomeUserControl;
using System.ComponentModel;
using System.Threading.Tasks;

namespace YDM.Pages
{
    public partial class Search : Form
    {
        private CancellationTokenSource _cancellationTokenSource;
        private Button _cancellationBtn;
        private int _processVideo;
        private int _totalVideo;

        public EventHandler<FileDownloadControl> FoundFileToDownload;

        public Search()
        {
            InitializeComponent();

            panelSearchResult.AutoScroll = false;
            panelSearchResult.HorizontalScroll.Enabled = false;
            panelSearchResult.HorizontalScroll.Visible = false;
            panelSearchResult.AutoScroll = true;
        }

        private void TextBox1_MouseEnter(object sender, EventArgs e) =>
            panelTextBox.BackColor = Color.FromArgb(215, 36, 36);

        private void TextBox1_MouseLeave(object sender, EventArgs e) =>
            panelTextBox.BackColor = Color.FromArgb(49, 57, 66);

        private async void TextBox1_KeyDownAsync(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                _processVideo = 0;
                panelSearch.Dock = DockStyle.Top;
                panel2.Dock = DockStyle.Top;
                panelSearchResult.Dock = DockStyle.Fill;
                panel3.Dock = DockStyle.Bottom;

                var text = txtSearchBox.Text;

                var _ydm = new YDMVideoProcesser(text);
                _ydm.VideoFound += FoundVideo;
                _ydm.ErrorOccered += ErrorFound;

                _ydm.StartProcess += Starthandler;
                _cancellationTokenSource = new CancellationTokenSource();
                var ids = await _ydm.GetIDsAsync(_cancellationTokenSource.Token);
                _totalVideo = ids.Count();
                _ydm.GetVideos(ids, _cancellationTokenSource.Token);
                _ydm.EndProcess += Endhandler;
                return;
            }
        }

        private void FoundVideo(object sender, VideoModel e)
        {
            _processVideo++;
            LblStatusCount.Text = $"{_processVideo} of {_totalVideo}";
            var result = new SearchResultControl(e);

            panelSearchResult.Controls.Add(result);

            PopulateGlobalList(e.Lists);

            panel2.Visible = true;
            BtnStartDownload.Visible = true;
        }

        private void PopulateGlobalList(List<FileInformation> lists)
        {
            foreach (var item in lists)
            {
                var name = $"{item.Format} {item.FileType} {item.FileExtenction}";
                if (GlobalSelectionVideoFile.Items.Contains(name) || GlobalSelectionAudioFiles.Items.Contains(name))
                    continue;
                if (item.FileType == FileTypeEnum.video)
                    GlobalSelectionVideoFile.Items.Add(name);
                else
                    GlobalSelectionAudioFiles.Items.Add(name);
            }
        }

        private void ErrorFound(object sender, Exception e)
        {
            _cancellationBtn.Dispose();
            _cancellationTokenSource.Dispose();
            // Log into some were;
        }

        private void Endhandler(object sender, EventArgs e)
        {
            LblStatusCount.Text = string.Empty;
            _cancellationBtn.Dispose();
            _cancellationTokenSource.Dispose();
        }

        private void Starthandler(object sender, EventArgs e)
        {
            _cancellationBtn = new Button()
            {
                Text = "Cancel",
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Right,
                FlatStyle = FlatStyle.Flat
            };
            _cancellationBtn.Click += CancelBtn_Click;
            panel1.Controls.Add(_cancellationBtn);
        }

        private void CancelBtn_Click(object sender, EventArgs e) =>
            _cancellationTokenSource.Cancel();

        private void Search_Load(object sender, EventArgs e) => ActiveControl = null;

        private void TxtSearchBox_MouseClick(object sender, MouseEventArgs e)
        {
            txtSearchBox.MouseLeave -= TextBox1_MouseLeave;
            txtSearchBox.LostFocus += TxtSearchBox_LostFocus;
        }

        private void TxtSearchBox_LostFocus(object sender, EventArgs e) =>
            txtSearchBox.MouseLeave += TextBox1_MouseLeave;

        private async void BtnStartDownload_Click(object sender, EventArgs e)
        {
            var controls = panelSearchResult
                .Controls
                .OfType<SearchResultControl>()
                .Where(a => a.IsChecked == true);

            if (!controls.Any())
                return;

            if (controls.Any(a => a.AudioComboBox.SelectedIndex == -1))
            {
                MessageBox.Show("Select the audio to download");
                return;
            }

            foreach (var item in controls.Reverse())
            {
                FoundFileToDownload.Raise(this, item.DownloadControl);
                panelSearchResult.Controls.Remove(item);
                item.Visible = false;
                item.Dispose();
                await Task.Delay(500);
            }

        }

        private void GlobalSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (var downloader in panelSearchResult.Controls.OfType<SearchResultControl>())
            {
                downloader.SelectVideo(GlobalSelectionVideoFile);
            }
        }

        private void GlobalSelectionAudioFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (var downloader in panelSearchResult.Controls.OfType<SearchResultControl>())
            {
                downloader.SelectAudio(GlobalSelectionAudioFiles);
            }
        }

    }

    static class Entand
    {

        internal static object Raise(this MulticastDelegate multicastDelegate, object sender, object eventArgs)
        {
            if (multicastDelegate == null)
                return null;
            object retval = null;
            foreach (var d in multicastDelegate.GetInvocationList())
            {
                var ISynchronizeInvoke = d.Target as ISynchronizeInvoke;
                if (ISynchronizeInvoke != null && ISynchronizeInvoke.InvokeRequired)
                    retval = ISynchronizeInvoke.EndInvoke(ISynchronizeInvoke.BeginInvoke(d, new[] { sender, eventArgs }));
                else
                    retval = d.DynamicInvoke(new[] { sender, eventArgs });
            }
            return retval;
        }
    }
}
