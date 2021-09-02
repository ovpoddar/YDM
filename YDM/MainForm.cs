﻿using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using YDM.CustomeUserControl;
using YDM.Pages;

namespace YDM
{
    public partial class MainForm : Form
    {
        private Form _currentChildForm = new Form();
        private Download _download = new Download();
        public MainForm()
        {
            InitializeComponent();
            var DownloadFolderGuid = new Guid("374DE290-123F-4565-9164-39C4925E467B");
            string downloads;
            SHGetKnownFolderPath(DownloadFolderGuid, 0, IntPtr.Zero, out downloads);

            Properties.Settings.Default.DownloadPath = downloads;
            Properties.Settings.Default.Save();
        }

        [DllImport("shell32.dll", CharSet = CharSet.Unicode)]
        static extern int SHGetKnownFolderPath([MarshalAs(UnmanagedType.LPStruct)] Guid rfid, uint dwFlags, IntPtr hToken, out string pszPath);

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void DownloadsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(_download, false);
        }

        private void SettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void HomeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new Search();
            form.FoundFileToDownload += AddToDownload;
            OpenChildForm(form, true);
        }

        private void AddToDownload(object sender, List<FileDownloadControl> e)
        {
            _download.Add(e);
        }

        private void OpenChildForm(object form, bool dispose)
        {
            var childForm = form as Form;
            //open only form
            if (_currentChildForm != null)
            {
                if (dispose)
                    _currentChildForm.Close();
                else
                    _currentChildForm.Hide();
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
            var form = new Search();
            form.FoundFileToDownload += AddToDownload;
            OpenChildForm(form, true);
        }
    }
}
