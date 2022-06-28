using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using YDM.Concept.Helper;
using YDM.Models;

namespace YDM.CustomeUserControl
{
    public partial class YDMYoutubeVideos : UserControl
    {
        #region Search Section
        const int _width = 1267;

        private Stage _stage;

        public event EventHandler OnStageChange;

        public Stage Stage
        {
            get { return _stage; }
            private set
            {
                if (OnStageChange != null)
                    OnStageChange.Invoke(this, EventArgs.Empty);
                _stage = value;
            }
        }

        private YDMYoutubeVideos()
        {
            InitializeComponent();
        }

        public YDMYoutubeVideos(UriAnalyzer link)
        {
            InitializeComponent();
            this.OnStageChange += YDMYoutubeVideos_OnStageChange;
            
            // Stage = Stage.Downloading;
        }

        private void YDMYoutubeVideos_OnStageChange(object sender, EventArgs e)
        {
            panel1.Width = Stage == Stage.Preview ? 0 : _width;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Stage == Stage.Preview)
                Stage = Stage.Downloading;
            else
                Stage = Stage.Preview;
        }

        #endregion

        #region Downloading Work
        private void Remove_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        #endregion
    }
}
