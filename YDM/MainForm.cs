using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using YDM.Pages;

namespace YDM
{
    public partial class MainForm : Form
    {
        private Form _currentChildForm = new Form();
        public MainForm()
        {
            InitializeComponent();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void DownloadsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Download());
        }

        private void SettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void HomeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Search());
        }

        private void OpenChildForm(Form childForm)
        {
            //open only form
            if (_currentChildForm != null)
            {
                _currentChildForm.Close();
            }
            _currentChildForm = childForm;
            //End
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelDesktop.Controls.Add(childForm);
            panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void MenuStrip1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            OpenChildForm(new Search());
        }
    }
}
