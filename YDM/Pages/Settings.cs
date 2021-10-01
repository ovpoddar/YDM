using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using YDM.CustomeUserControl;

namespace YDM.Pages
{
    // TODO: work on setting tab
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
            var control = new SettingItemControl("Download Path", "DownloadPath", a => Directory.Exists((string)a), typeof(string));
            var control1 = new SettingItemControl("Maximum Download", "MaxDownload", SettingMax, typeof(int));
            flowLayoutPanel1.Controls.Add(control);
            flowLayoutPanel1.Controls.Add(control1);
        }

        private bool SettingMax(object obj)
        {
            var number = int.Parse(obj.ToString());
            return number >= 1 && number <= 15;
        }
    }
}
