
namespace YDM.Pages
{
    partial class Search
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtSearchBox = new System.Windows.Forms.TextBox();
            this.panelTextBox = new System.Windows.Forms.Panel();
            this.panelSearchResult = new System.Windows.Forms.FlowLayoutPanel();
            this.panelSearch = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.GlobalSelectionAudioFiles = new System.Windows.Forms.ComboBox();
            this.GlobalSelectionVideoFile = new System.Windows.Forms.ComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.BtnStartDownload = new System.Windows.Forms.Button();
            this.LblStatusCount = new System.Windows.Forms.Label();
            this.panelTextBox.SuspendLayout();
            this.panelSearch.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtSearchBox
            // 
            this.txtSearchBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(57)))), ((int)(((byte)(66)))));
            this.txtSearchBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSearchBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSearchBox.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtSearchBox.Location = new System.Drawing.Point(0, 0);
            this.txtSearchBox.Margin = new System.Windows.Forms.Padding(0);
            this.txtSearchBox.Name = "txtSearchBox";
            this.txtSearchBox.PlaceholderText = "Enter the Link";
            this.txtSearchBox.Size = new System.Drawing.Size(908, 32);
            this.txtSearchBox.TabIndex = 2;
            this.txtSearchBox.TabStop = false;
            this.txtSearchBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TxtSearchBox_MouseClick);
            this.txtSearchBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox1_KeyDownAsync);
            this.txtSearchBox.MouseEnter += new System.EventHandler(this.TextBox1_MouseEnter);
            this.txtSearchBox.MouseLeave += new System.EventHandler(this.TextBox1_MouseLeave);
            // 
            // panelTextBox
            // 
            this.panelTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.panelTextBox.Controls.Add(this.txtSearchBox);
            this.panelTextBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelTextBox.Location = new System.Drawing.Point(0, 0);
            this.panelTextBox.Name = "panelTextBox";
            this.panelTextBox.Size = new System.Drawing.Size(908, 37);
            this.panelTextBox.TabIndex = 2;
            // 
            // panelSearchResult
            // 
            this.panelSearchResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelSearchResult.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(57)))), ((int)(((byte)(66)))));
            this.panelSearchResult.Location = new System.Drawing.Point(0, 210);
            this.panelSearchResult.Name = "panelSearchResult";
            this.panelSearchResult.Size = new System.Drawing.Size(1208, 231);
            this.panelSearchResult.TabIndex = 3;
            // 
            // panelSearch
            // 
            this.panelSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelSearch.Controls.Add(this.panel1);
            this.panelSearch.Location = new System.Drawing.Point(0, 122);
            this.panelSearch.Name = "panelSearch";
            this.panelSearch.Size = new System.Drawing.Size(1208, 37);
            this.panelSearch.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(57)))), ((int)(((byte)(66)))));
            this.panel1.Controls.Add(this.panelTextBox);
            this.panel1.Location = new System.Drawing.Point(116, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(989, 37);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(57)))), ((int)(((byte)(66)))));
            this.panel2.Controls.Add(this.LblStatusCount);
            this.panel2.Controls.Add(this.GlobalSelectionAudioFiles);
            this.panel2.Controls.Add(this.GlobalSelectionVideoFile);
            this.panel2.Location = new System.Drawing.Point(3, 165);
            this.panel2.Margin = new System.Windows.Forms.Padding(0, 0, 0, 23);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1205, 43);
            this.panel2.TabIndex = 5;
            this.panel2.Visible = false;
            // 
            // GlobalSelectionAudioFiles
            // 
            this.GlobalSelectionAudioFiles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(57)))), ((int)(((byte)(66)))));
            this.GlobalSelectionAudioFiles.Dock = System.Windows.Forms.DockStyle.Left;
            this.GlobalSelectionAudioFiles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GlobalSelectionAudioFiles.FormattingEnabled = true;
            this.GlobalSelectionAudioFiles.Location = new System.Drawing.Point(0, 0);
            this.GlobalSelectionAudioFiles.Name = "GlobalSelectionAudioFiles";
            this.GlobalSelectionAudioFiles.Size = new System.Drawing.Size(582, 23);
            this.GlobalSelectionAudioFiles.TabIndex = 1;
            this.GlobalSelectionAudioFiles.SelectedIndexChanged += new System.EventHandler(this.GlobalSelectionAudioFiles_SelectedIndexChanged);
            // 
            // GlobalSelectionVideoFile
            // 
            this.GlobalSelectionVideoFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(57)))), ((int)(((byte)(66)))));
            this.GlobalSelectionVideoFile.Dock = System.Windows.Forms.DockStyle.Right;
            this.GlobalSelectionVideoFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GlobalSelectionVideoFile.FormattingEnabled = true;
            this.GlobalSelectionVideoFile.Location = new System.Drawing.Point(623, 0);
            this.GlobalSelectionVideoFile.Name = "GlobalSelectionVideoFile";
            this.GlobalSelectionVideoFile.Size = new System.Drawing.Size(582, 23);
            this.GlobalSelectionVideoFile.TabIndex = 0;
            this.GlobalSelectionVideoFile.SelectedIndexChanged += new System.EventHandler(this.GlobalSelection_SelectedIndexChanged);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(57)))), ((int)(((byte)(66)))));
            this.panel3.Controls.Add(this.BtnStartDownload);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 447);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1208, 33);
            this.panel3.TabIndex = 6;
            // 
            // BtnStartDownload
            // 
            this.BtnStartDownload.Location = new System.Drawing.Point(506, 7);
            this.BtnStartDownload.Name = "BtnStartDownload";
            this.BtnStartDownload.Size = new System.Drawing.Size(196, 23);
            this.BtnStartDownload.TabIndex = 0;
            this.BtnStartDownload.Text = "Download";
            this.BtnStartDownload.UseVisualStyleBackColor = true;
            this.BtnStartDownload.Visible = false;
            this.BtnStartDownload.Click += new System.EventHandler(this.BtnStartDownload_Click);
            // 
            // LblStatusCount
            // 
            this.LblStatusCount.AutoSize = true;
            this.LblStatusCount.Location = new System.Drawing.Point(586, 26);
            this.LblStatusCount.Name = "LblStatusCount";
            this.LblStatusCount.Size = new System.Drawing.Size(0, 15);
            this.LblStatusCount.TabIndex = 2;
            // 
            // Search
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(57)))), ((int)(((byte)(66)))));
            this.ClientSize = new System.Drawing.Size(1208, 480);
            this.Controls.Add(this.panelSearchResult);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panelSearch);
            this.Name = "Search";
            this.Text = "Search";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panelTextBox.ResumeLayout(false);
            this.panelTextBox.PerformLayout();
            this.panelSearch.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelTextBox;
        private System.Windows.Forms.Panel panelSearch;
        private System.Windows.Forms.TextBox txtSearchBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.FlowLayoutPanel panelSearchResult;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button BtnStartDownload;
        private System.Windows.Forms.ComboBox GlobalSelectionVideoFile;
        private System.Windows.Forms.ComboBox GlobalSelectionAudioFiles;
        private System.Windows.Forms.Label LblStatusCount;
    }
}

