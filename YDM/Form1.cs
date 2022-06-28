using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YDM.CustomeUserControl;
using YDM.Pages;

namespace YDM
{
    public partial class YDMForm : Form
    {
        private Form[] _currentChildForm = new Form[2];
        public YDMForm()
        {
            InitializeComponent();
            OpenChildForm(new Search(), true);
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

        private void exitToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            Application.Exit();
        }


        private void OpenChildForm(object form, bool dispose)
        {
            var childForm = form as Form;
            if (dispose)
                _currentChildForm.SetValue(childForm, 0);
            else
            {
                _currentChildForm.SetValue(null, 0);
                _currentChildForm.SetValue(childForm, 1);
            }
            //End
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelDesktop.Controls.Add(childForm);
            panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
    }
}
