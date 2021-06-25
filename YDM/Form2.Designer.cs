
namespace YDM
{
    partial class Form2
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnPauseAll = new System.Windows.Forms.Button();
            this.BtnResumeAll = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 41);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(800, 409);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BtnResumeAll);
            this.panel1.Controls.Add(this.BtnPauseAll);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 42);
            this.panel1.TabIndex = 1;
            // 
            // BtnPauseAll
            // 
            this.BtnPauseAll.Location = new System.Drawing.Point(713, 12);
            this.BtnPauseAll.Name = "BtnPauseAll";
            this.BtnPauseAll.Size = new System.Drawing.Size(75, 23);
            this.BtnPauseAll.TabIndex = 0;
            this.BtnPauseAll.Text = "Pause All";
            this.BtnPauseAll.UseVisualStyleBackColor = true;
            this.BtnPauseAll.Click += new System.EventHandler(this.BtnPauseAll_Click);
            // 
            // BtnResumeAll
            // 
            this.BtnResumeAll.Location = new System.Drawing.Point(626, 13);
            this.BtnResumeAll.Name = "BtnResumeAll";
            this.BtnResumeAll.Size = new System.Drawing.Size(75, 23);
            this.BtnResumeAll.TabIndex = 1;
            this.BtnResumeAll.Text = "Resume All";
            this.BtnResumeAll.UseVisualStyleBackColor = true;
            this.BtnResumeAll.Click += new System.EventHandler(this.BtnResumeAll_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnPauseAll;
        private System.Windows.Forms.Button BtnResumeAll;
    }
}