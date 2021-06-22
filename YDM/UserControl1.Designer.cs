
namespace YDM
{
    partial class UserControl1
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
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnStop = new System.Windows.Forms.Button();
            this.BtnPause = new System.Windows.Forms.Button();
            this.BtnPlay = new System.Windows.Forms.Button();
            this.BtnRestart = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(11, 45);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(508, 23);
            this.progressBar1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(11, 10);
            this.label1.MaximumSize = new System.Drawing.Size(508, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(508, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // BtnStop
            // 
            this.BtnStop.Location = new System.Drawing.Point(535, 10);
            this.BtnStop.Name = "BtnStop";
            this.BtnStop.Size = new System.Drawing.Size(33, 23);
            this.BtnStop.TabIndex = 2;
            this.BtnStop.Text = "X";
            this.BtnStop.UseVisualStyleBackColor = true;
            this.BtnStop.Click += new System.EventHandler(this.BtnStop_Click);
            // 
            // BtnPause
            // 
            this.BtnPause.Location = new System.Drawing.Point(535, 45);
            this.BtnPause.Name = "BtnPause";
            this.BtnPause.Size = new System.Drawing.Size(33, 23);
            this.BtnPause.TabIndex = 3;
            this.BtnPause.Text = "| |";
            this.BtnPause.UseVisualStyleBackColor = true;
            this.BtnPause.Click += new System.EventHandler(this.BtnPause_Click);
            // 
            // BtnPlay
            // 
            this.BtnPlay.Location = new System.Drawing.Point(575, 45);
            this.BtnPlay.Name = "BtnPlay";
            this.BtnPlay.Size = new System.Drawing.Size(31, 23);
            this.BtnPlay.TabIndex = 4;
            this.BtnPlay.Text = "▲";
            this.BtnPlay.UseVisualStyleBackColor = true;
            this.BtnPlay.Click += new System.EventHandler(this.BtnPlay_Click);
            // 
            // BtnRestart
            // 
            this.BtnRestart.Location = new System.Drawing.Point(575, 10);
            this.BtnRestart.Name = "BtnRestart";
            this.BtnRestart.Size = new System.Drawing.Size(31, 23);
            this.BtnRestart.TabIndex = 5;
            this.BtnRestart.Text = "⊂";
            this.BtnRestart.UseVisualStyleBackColor = true;
            this.BtnRestart.Click += new System.EventHandler(this.BtnRestart_Click);
            // 
            // UserControl1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BtnRestart);
            this.Controls.Add(this.BtnPlay);
            this.Controls.Add(this.BtnPause);
            this.Controls.Add(this.BtnStop);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressBar1);
            this.Name = "UserControl1";
            this.Size = new System.Drawing.Size(621, 77);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnStop;
        private System.Windows.Forms.Button BtnPause;
        private System.Windows.Forms.Button BtnPlay;
        private System.Windows.Forms.Button BtnRestart;
    }
}
