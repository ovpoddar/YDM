
namespace YDM.CustomeUserControl
{
    partial class FileDownloadControl
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.BtnChangeState = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnOpenFolder = new System.Windows.Forms.Button();
            this.BtnStart = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.LblPercentage = new System.Windows.Forms.Label();
            this.LblSizeMoniter = new System.Windows.Forms.Label();
            this.ProgressBar = new System.Windows.Forms.ProgressBar();
            this.LblInternalPath = new System.Windows.Forms.Label();
            this.LblName = new System.Windows.Forms.Label();
            this.BtnDispose = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(82, 175);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.LblInternalPath);
            this.panel2.Controls.Add(this.LblName);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(82, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(584, 175);
            this.panel2.TabIndex = 1;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.BtnChangeState);
            this.panel5.Controls.Add(this.BtnCancel);
            this.panel5.Controls.Add(this.BtnOpenFolder);
            this.panel5.Controls.Add(this.BtnStart);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 105);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(584, 70);
            this.panel5.TabIndex = 5;
            // 
            // BtnChangeState
            // 
            this.BtnChangeState.Location = new System.Drawing.Point(0, 17);
            this.BtnChangeState.Name = "BtnChangeState";
            this.BtnChangeState.Size = new System.Drawing.Size(88, 34);
            this.BtnChangeState.TabIndex = 1;
            this.BtnChangeState.Text = "Pause";
            this.BtnChangeState.UseVisualStyleBackColor = true;
            this.BtnChangeState.Visible = false;
            this.BtnChangeState.Click += new System.EventHandler(this.BtnChangeState_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Location = new System.Drawing.Point(94, 17);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 34);
            this.BtnCancel.TabIndex = 2;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Visible = false;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // BtnOpenFolder
            // 
            this.BtnOpenFolder.FlatAppearance.BorderSize = 0;
            this.BtnOpenFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnOpenFolder.Location = new System.Drawing.Point(0, 6);
            this.BtnOpenFolder.Name = "BtnOpenFolder";
            this.BtnOpenFolder.Size = new System.Drawing.Size(155, 45);
            this.BtnOpenFolder.TabIndex = 0;
            this.BtnOpenFolder.Text = "SHOW IN FOLDER";
            this.BtnOpenFolder.UseVisualStyleBackColor = true;
            this.BtnOpenFolder.Visible = false;
            this.BtnOpenFolder.Click += new System.EventHandler(this.BtnOpenFolder_Click);
            // 
            // BtnStart
            // 
            this.BtnStart.Location = new System.Drawing.Point(94, 17);
            this.BtnStart.Name = "BtnStart";
            this.BtnStart.Size = new System.Drawing.Size(75, 34);
            this.BtnStart.TabIndex = 3;
            this.BtnStart.Text = "Retry";
            this.BtnStart.UseVisualStyleBackColor = true;
            this.BtnStart.Visible = false;
            this.BtnStart.Click += new System.EventHandler(this.BtnRetry_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.ProgressBar);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 70);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(584, 35);
            this.panel3.TabIndex = 4;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.LblPercentage);
            this.panel4.Controls.Add(this.LblSizeMoniter);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(584, 27);
            this.panel4.TabIndex = 5;
            // 
            // LblPercentage
            // 
            this.LblPercentage.Dock = System.Windows.Forms.DockStyle.Left;
            this.LblPercentage.Location = new System.Drawing.Point(135, 0);
            this.LblPercentage.Name = "LblPercentage";
            this.LblPercentage.Padding = new System.Windows.Forms.Padding(5);
            this.LblPercentage.Size = new System.Drawing.Size(65, 27);
            this.LblPercentage.TabIndex = 2;
            this.LblPercentage.Text = "100%";
            // 
            // LblSizeMoniter
            // 
            this.LblSizeMoniter.Dock = System.Windows.Forms.DockStyle.Left;
            this.LblSizeMoniter.Location = new System.Drawing.Point(0, 0);
            this.LblSizeMoniter.Name = "LblSizeMoniter";
            this.LblSizeMoniter.Padding = new System.Windows.Forms.Padding(5);
            this.LblSizeMoniter.Size = new System.Drawing.Size(135, 27);
            this.LblSizeMoniter.TabIndex = 3;
            this.LblSizeMoniter.Text = "39.7 Mb of 39.7MB";
            // 
            // ProgressBar
            // 
            this.ProgressBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProgressBar.Location = new System.Drawing.Point(0, 0);
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(584, 35);
            this.ProgressBar.TabIndex = 4;
            // 
            // LblInternalPath
            // 
            this.LblInternalPath.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblInternalPath.Location = new System.Drawing.Point(0, 35);
            this.LblInternalPath.Name = "LblInternalPath";
            this.LblInternalPath.Padding = new System.Windows.Forms.Padding(10);
            this.LblInternalPath.Size = new System.Drawing.Size(584, 35);
            this.LblInternalPath.TabIndex = 1;
            this.LblInternalPath.Text = "file:///C:/Users/Ayan/Downloads/ffmpeg-2021-07-18-git-694545b6d5-full_build.7z";
            // 
            // LblName
            // 
            this.LblName.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblName.Location = new System.Drawing.Point(0, 0);
            this.LblName.Name = "LblName";
            this.LblName.Padding = new System.Windows.Forms.Padding(10);
            this.LblName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LblName.Size = new System.Drawing.Size(584, 35);
            this.LblName.TabIndex = 0;
            this.LblName.Text = "File Name";
            // 
            // BtnDispose
            // 
            this.BtnDispose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnDispose.FlatAppearance.BorderSize = 0;
            this.BtnDispose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnDispose.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BtnDispose.Location = new System.Drawing.Point(665, 1);
            this.BtnDispose.Margin = new System.Windows.Forms.Padding(0);
            this.BtnDispose.Name = "BtnDispose";
            this.BtnDispose.Size = new System.Drawing.Size(35, 35);
            this.BtnDispose.TabIndex = 2;
            this.BtnDispose.Text = "X";
            this.BtnDispose.UseVisualStyleBackColor = true;
            this.BtnDispose.Click += new System.EventHandler(this.BtnDispose_Click);
            // 
            // FileDownloadControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Controls.Add(this.BtnDispose);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FileDownloadControl";
            this.Size = new System.Drawing.Size(700, 175);
            this.panel2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button BtnDispose;
        private System.Windows.Forms.Label LblName;
        private System.Windows.Forms.Label LblInternalPath;
        private System.Windows.Forms.Label LblPercentage;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button BtnOpenFolder;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label LblSizeMoniter;
        private System.Windows.Forms.ProgressBar ProgressBar;
        private System.Windows.Forms.Panel panel4;
        public System.Windows.Forms.Button BtnChangeState;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button BtnStart;
    }
}
