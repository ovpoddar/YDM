
namespace YDM.CustomeUserControl
{
    partial class SettingItemControl
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
            this.LblSettingFor = new System.Windows.Forms.Label();
            this.TxtBoxSettingID = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // LblSettingFor
            // 
            this.LblSettingFor.Dock = System.Windows.Forms.DockStyle.Left;
            this.LblSettingFor.Location = new System.Drawing.Point(0, 0);
            this.LblSettingFor.Name = "LblSettingFor";
            this.LblSettingFor.Size = new System.Drawing.Size(109, 33);
            this.LblSettingFor.TabIndex = 0;
            this.LblSettingFor.Text = "label1";
            // 
            // TxtBoxSettingID
            // 
            this.TxtBoxSettingID.Dock = System.Windows.Forms.DockStyle.Right;
            this.TxtBoxSettingID.Location = new System.Drawing.Point(307, 0);
            this.TxtBoxSettingID.Name = "TxtBoxSettingID";
            this.TxtBoxSettingID.Size = new System.Drawing.Size(100, 23);
            this.TxtBoxSettingID.TabIndex = 1;
            // 
            // SettingItemControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TxtBoxSettingID);
            this.Controls.Add(this.LblSettingFor);
            this.Name = "SettingItemControl";
            this.Size = new System.Drawing.Size(407, 33);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblSettingFor;
        private System.Windows.Forms.TextBox TxtBoxSettingID;
    }
}
