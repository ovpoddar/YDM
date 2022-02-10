
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
            this.PanelSelect = new System.Windows.Forms.Panel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.PanelImage = new System.Windows.Forms.Panel();
            this.PicThumbnail = new System.Windows.Forms.PictureBox();
            this.PanelDetails = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.AudioComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.VideoComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.VideoStatus = new System.Windows.Forms.Panel();
            this.LblAuthor = new System.Windows.Forms.Label();
            this.LblTitle = new System.Windows.Forms.Label();
            this.PanelSelect.SuspendLayout();
            this.PanelImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicThumbnail)).BeginInit();
            this.PanelDetails.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelSelect
            // 
            this.PanelSelect.Controls.Add(this.checkBox1);
            this.PanelSelect.Dock = System.Windows.Forms.DockStyle.Left;
            this.PanelSelect.Location = new System.Drawing.Point(0, 0);
            this.PanelSelect.Name = "PanelSelect";
            this.PanelSelect.Size = new System.Drawing.Size(31, 150);
            this.PanelSelect.TabIndex = 0;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(10, 63);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(15, 14);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // PanelImage
            // 
            this.PanelImage.Controls.Add(this.PicThumbnail);
            this.PanelImage.Dock = System.Windows.Forms.DockStyle.Left;
            this.PanelImage.Location = new System.Drawing.Point(31, 0);
            this.PanelImage.Name = "PanelImage";
            this.PanelImage.Padding = new System.Windows.Forms.Padding(5);
            this.PanelImage.Size = new System.Drawing.Size(138, 150);
            this.PanelImage.TabIndex = 1;
            // 
            // PicThumbnail
            // 
            this.PicThumbnail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PicThumbnail.Location = new System.Drawing.Point(5, 5);
            this.PicThumbnail.Name = "PicThumbnail";
            this.PicThumbnail.Size = new System.Drawing.Size(128, 140);
            this.PicThumbnail.TabIndex = 0;
            this.PicThumbnail.TabStop = false;
            // 
            // PanelDetails
            // 
            this.PanelDetails.Controls.Add(this.panel3);
            this.PanelDetails.Controls.Add(this.panel2);
            this.PanelDetails.Controls.Add(this.panel1);
            this.PanelDetails.Controls.Add(this.LblTitle);
            this.PanelDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelDetails.Location = new System.Drawing.Point(169, 0);
            this.PanelDetails.Margin = new System.Windows.Forms.Padding(0);
            this.PanelDetails.Name = "PanelDetails";
            this.PanelDetails.Padding = new System.Windows.Forms.Padding(5);
            this.PanelDetails.Size = new System.Drawing.Size(581, 150);
            this.PanelDetails.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.AudioComboBox);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Location = new System.Drawing.Point(10, 108);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(554, 24);
            this.panel3.TabIndex = 3;
            // 
            // AudioComboBox
            // 
            this.AudioComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AudioComboBox.FormattingEnabled = true;
            this.AudioComboBox.Location = new System.Drawing.Point(212, 0);
            this.AudioComboBox.Name = "AudioComboBox";
            this.AudioComboBox.Size = new System.Drawing.Size(342, 23);
            this.AudioComboBox.TabIndex = 1;
            this.AudioComboBox.SelectedIndexChanged += new System.EventHandler(this.ComboBox2_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(212, 24);
            this.label2.TabIndex = 0;
            this.label2.Text = "Select the Audio Quality";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.VideoComboBox);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(10, 78);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(554, 24);
            this.panel2.TabIndex = 2;
            // 
            // VideoComboBox
            // 
            this.VideoComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VideoComboBox.FormattingEnabled = true;
            this.VideoComboBox.Location = new System.Drawing.Point(212, 0);
            this.VideoComboBox.Name = "VideoComboBox";
            this.VideoComboBox.Size = new System.Drawing.Size(342, 23);
            this.VideoComboBox.TabIndex = 1;
            this.VideoComboBox.SelectedIndexChanged += new System.EventHandler(this.ComboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(212, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select the video Quality";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.VideoStatus);
            this.panel1.Controls.Add(this.LblAuthor);
            this.panel1.Location = new System.Drawing.Point(11, 46);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(557, 24);
            this.panel1.TabIndex = 1;
            // 
            // VideoStatus
            // 
            this.VideoStatus.BackColor = System.Drawing.Color.Red;
            this.VideoStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VideoStatus.Location = new System.Drawing.Point(533, 0);
            this.VideoStatus.Name = "VideoStatus";
            this.VideoStatus.Size = new System.Drawing.Size(24, 24);
            this.VideoStatus.TabIndex = 1;
            this.VideoStatus.Visible = false;
            // 
            // LblAuthor
            // 
            this.LblAuthor.Dock = System.Windows.Forms.DockStyle.Left;
            this.LblAuthor.Location = new System.Drawing.Point(0, 0);
            this.LblAuthor.Name = "LblAuthor";
            this.LblAuthor.Size = new System.Drawing.Size(533, 24);
            this.LblAuthor.TabIndex = 0;
            this.LblAuthor.Text = "Author";
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
            // SearchResultControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.Controls.Add(this.PanelDetails);
            this.Controls.Add(this.PanelImage);
            this.Controls.Add(this.PanelSelect);
            this.Name = "SearchResultControl";
            this.Size = new System.Drawing.Size(750, 150);
            this.PanelSelect.ResumeLayout(false);
            this.PanelSelect.PerformLayout();
            this.PanelImage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PicThumbnail)).EndInit();
            this.PanelDetails.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanelSelect;
        private System.Windows.Forms.Panel PanelImage;
        private System.Windows.Forms.Panel PanelDetails;
        private System.Windows.Forms.PictureBox PicThumbnail;
        private System.Windows.Forms.Label LblTitle;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label LblAuthor;
        private System.Windows.Forms.Panel VideoStatus;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox VideoComboBox;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox AudioComboBox;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}
