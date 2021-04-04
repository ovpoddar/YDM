using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            try
            {
                var text = URL.Text;

                var url = new Uri(text);

                var httpClient = new HttpClient();

                var httpResponce = httpClient.GetAsync(url);

                var responce = httpResponce.Result.Content.ReadAsStringAsync();

                Output.Text = responce.Result;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
