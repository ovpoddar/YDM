
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.LblTitle = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.VideoStatus = new System.Windows.Forms.Panel();
            this.LblAuthor = new System.Windows.Forms.Label();
            this.PanelImage = new System.Windows.Forms.Panel();
            this.PicThumbnail = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.PanelDetails.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
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
            this.panel1.Size = new System.Drawing.Size(750, 200);
            this.panel1.TabIndex = 0;
            // 
            // PanelDetails
            // 
            this.PanelDetails.Controls.Add(this.comboBox1);
            this.PanelDetails.Controls.Add(this.panel2);
            this.PanelDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelDetails.Location = new System.Drawing.Point(176, 0);
            this.PanelDetails.Name = "PanelDetails";
            this.PanelDetails.Size = new System.Drawing.Size(574, 200);
            this.PanelDetails.TabIndex = 3;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(22, 109);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(542, 23);
            this.comboBox1.TabIndex = 4;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(10);
            this.panel2.Size = new System.Drawing.Size(574, 78);
            this.panel2.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.LblTitle);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(10, 10);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(554, 29);
            this.panel4.TabIndex = 2;
            // 
            // LblTitle
            // 
            this.LblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblTitle.Location = new System.Drawing.Point(0, 0);
            this.LblTitle.Name = "LblTitle";
            this.LblTitle.Size = new System.Drawing.Size(554, 29);
            this.LblTitle.TabIndex = 0;
            this.LblTitle.Text = "Title";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.VideoStatus);
            this.panel3.Controls.Add(this.LblAuthor);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(10, 39);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(554, 29);
            this.panel3.TabIndex = 1;
            // 
            // VideoStatus
            // 
            this.VideoStatus.BackColor = System.Drawing.Color.Red;
            this.VideoStatus.Dock = System.Windows.Forms.DockStyle.Right;
            this.VideoStatus.Location = new System.Drawing.Point(524, 0);
            this.VideoStatus.Name = "VideoStatus";
            this.VideoStatus.Size = new System.Drawing.Size(30, 29);
            this.VideoStatus.TabIndex = 2;
            this.VideoStatus.Visible = false;
            // 
            // LblAuthor
            // 
            this.LblAuthor.Dock = System.Windows.Forms.DockStyle.Left;
            this.LblAuthor.Location = new System.Drawing.Point(0, 0);
            this.LblAuthor.Name = "LblAuthor";
            this.LblAuthor.Size = new System.Drawing.Size(255, 29);
            this.LblAuthor.TabIndex = 1;
            this.LblAuthor.Text = "Author";
            // 
            // PanelImage
            // 
            this.PanelImage.Controls.Add(this.PicThumbnail);
            this.PanelImage.Dock = System.Windows.Forms.DockStyle.Left;
            this.PanelImage.Location = new System.Drawing.Point(0, 0);
            this.PanelImage.Name = "PanelImage";
            this.PanelImage.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.PanelImage.Size = new System.Drawing.Size(176, 200);
            this.PanelImage.TabIndex = 2;
            // 
            // PicThumbnail
            // 
            this.PicThumbnail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PicThumbnail.Location = new System.Drawing.Point(10, 5);
            this.PicThumbnail.Name = "PicThumbnail";
            this.PicThumbnail.Size = new System.Drawing.Size(156, 190);
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
            this.Size = new System.Drawing.Size(750, 200);
            this.panel1.ResumeLayout(false);
            this.PanelDetails.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.PanelImage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PicThumbnail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel PanelDetails;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label LblTitle;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel VideoStatus;
        private System.Windows.Forms.Label LblAuthor;
        private System.Windows.Forms.Panel PanelImage;
        private System.Windows.Forms.PictureBox PicThumbnail;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}
