
namespace YDM.CustomeUserControl
{
    partial class SearchResultControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.PanelDetails = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.LblAuthor = new System.Windows.Forms.Label();
            this.VideoStatus = new System.Windows.Forms.Panel();
            this.LblTitle = new System.Windows.Forms.Label();
            this.PanelImage = new System.Windows.Forms.Panel();
            this.PicThumbnail = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.PanelDetails.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.PanelImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicThumbnail)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.PanelDetails);
            this.panel1.Controls.Add(this.PanelImage);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(750, 150);
            this.panel1.TabIndex = 0;
            // 
            // PanelDetails
            // 
            this.PanelDetails.Controls.Add(this.panel4);
            this.PanelDetails.Controls.Add(this.panel2);
            this.PanelDetails.Controls.Add(this.panel3);
            this.PanelDetails.Controls.Add(this.LblTitle);
            this.PanelDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelDetails.Location = new System.Drawing.Point(176, 0);
            this.PanelDetails.Name = "PanelDetails";
            this.PanelDetails.Size = new System.Drawing.Size(574, 150);
            this.PanelDetails.TabIndex = 3;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.comboBox2);
            this.panel4.Location = new System.Drawing.Point(10, 108);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(554, 24);
            this.panel4.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(212, 24);
            this.label2.TabIndex = 5;
            this.label2.Text = "Select the Audio Quality";
            // 
            // comboBox2
            // 
            this.comboBox2.Dock = System.Windows.Forms.DockStyle.Right;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(218, 0);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(336, 23);
            this.comboBox2.TabIndex = 4;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.comboBox1);
            this.panel2.Location = new System.Drawing.Point(10, 78);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(554, 24);
            this.panel2.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(212, 24);
            this.label1.TabIndex = 5;
            this.label1.Text = "Select the video Quality";
            // 
            // comboBox1
            // 
            this.comboBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(218, 0);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(336, 23);
            this.comboBox1.TabIndex = 4;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.LblAuthor);
            this.panel3.Controls.Add(this.VideoStatus);
            this.panel3.Location = new System.Drawing.Point(10, 47);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(554, 27);
            this.panel3.TabIndex = 1;
            // 
            // LblAuthor
            // 
            this.LblAuthor.Dock = System.Windows.Forms.DockStyle.Left;
            this.LblAuthor.Location = new System.Drawing.Point(0, 0);
            this.LblAuthor.Name = "LblAuthor";
            this.LblAuthor.Size = new System.Drawing.Size(518, 27);
            this.LblAuthor.TabIndex = 1;
            this.LblAuthor.Text = "Author";
            // 
            // VideoStatus
            // 
            this.VideoStatus.BackColor = System.Drawing.Color.Red;
            this.VideoStatus.Dock = System.Windows.Forms.DockStyle.Right;
            this.VideoStatus.Location = new System.Drawing.Point(524, 0);
            this.VideoStatus.Name = "VideoStatus";
            this.VideoStatus.Size = new System.Drawing.Size(30, 27);
            this.VideoStatus.TabIndex = 2;
            this.VideoStatus.Visible = false;
            // 
            // LblTitle
            // 
            this.LblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LblTitle.Location = new System.Drawing.Point(10, 15);
            this.LblTitle.Name = "LblTitle";
            this.LblTitle.Size = new System.Drawing.Size(554, 27);
            this.LblTitle.TabIndex = 0;
            this.LblTitle.Text = "Title";
            // 
            // PanelImage
            // 
            this.PanelImage.Controls.Add(this.PicThumbnail);
            this.PanelImage.Dock = System.Windows.Forms.DockStyle.Left;
            this.PanelImage.Location = new System.Drawing.Point(0, 0);
            this.PanelImage.Name = "PanelImage";
            this.PanelImage.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.PanelImage.Size = new System.Drawing.Size(176, 150);
            this.PanelImage.TabIndex = 2;
            // 
            // PicThumbnail
            // 
            this.PicThumbnail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PicThumbnail.Location = new System.Drawing.Point(10, 5);
            this.PicThumbnail.Name = "PicThumbnail";
            this.PicThumbnail.Size = new System.Drawing.Size(156, 140);
            this.PicThumbnail.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PicThumbnail.TabIndex = 0;
            this.PicThumbnail.TabStop = false;
            // 
            // SearchResultControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Controls.Add(this.panel1);
            this.Name = "SearchResultControl";
            this.Size = new System.Drawing.Size(750, 150);
            this.panel1.ResumeLayout(false);
            this.PanelDetails.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.PanelImage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PicThumbnail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel PanelDetails;
        private System.Windows.Forms.Label LblTitle;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel VideoStatus;
        private System.Windows.Forms.Label LblAuthor;
        private System.Windows.Forms.Panel PanelImage;
        private System.Windows.Forms.PictureBox PicThumbnail;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox2;
    }
}
