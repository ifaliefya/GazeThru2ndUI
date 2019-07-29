namespace GazethruApps
{
    partial class Admin
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnInfo = new System.Windows.Forms.Button();
            this.btnPeta = new System.Windows.Forms.Button();
            this.btnSlide = new System.Windows.Forms.Button();
            this.btnSettings = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.adminInformasi1 = new GazethruApps.AdminInformasi();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.btnSettings);
            this.panel1.Controls.Add(this.btnSlide);
            this.panel1.Controls.Add(this.btnPeta);
            this.panel1.Controls.Add(this.btnInfo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(187, 839);
            this.panel1.TabIndex = 0;
            // 
            // btnInfo
            // 
            this.btnInfo.Location = new System.Drawing.Point(12, 157);
            this.btnInfo.Name = "btnInfo";
            this.btnInfo.Size = new System.Drawing.Size(175, 71);
            this.btnInfo.TabIndex = 0;
            this.btnInfo.Text = "Informasi";
            this.btnInfo.UseVisualStyleBackColor = true;
            // 
            // btnPeta
            // 
            this.btnPeta.Location = new System.Drawing.Point(12, 225);
            this.btnPeta.Name = "btnPeta";
            this.btnPeta.Size = new System.Drawing.Size(175, 71);
            this.btnPeta.TabIndex = 1;
            this.btnPeta.Text = "Peta";
            this.btnPeta.UseVisualStyleBackColor = true;
            // 
            // btnSlide
            // 
            this.btnSlide.Location = new System.Drawing.Point(12, 293);
            this.btnSlide.Name = "btnSlide";
            this.btnSlide.Size = new System.Drawing.Size(175, 71);
            this.btnSlide.TabIndex = 2;
            this.btnSlide.Text = "Slideshow";
            this.btnSlide.UseVisualStyleBackColor = true;
            // 
            // btnSettings
            // 
            this.btnSettings.Location = new System.Drawing.Point(12, 362);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(175, 71);
            this.btnSettings.TabIndex = 3;
            this.btnSettings.Text = "Settings";
            this.btnSettings.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.panel3.Location = new System.Drawing.Point(0, 157);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(13, 71);
            this.panel3.TabIndex = 2;
            // 
            // adminInformasi1
            // 
            this.adminInformasi1.Location = new System.Drawing.Point(214, 88);
            this.adminInformasi1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.adminInformasi1.Name = "adminInformasi1";
            this.adminInformasi1.Size = new System.Drawing.Size(954, 579);
            this.adminInformasi1.TabIndex = 1;
            // 
            // AdminInfo
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1689, 839);
            this.Controls.Add(this.adminInformasi1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Coves", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AdminInfo";
            this.Text = "AdminInfo";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Button btnSlide;
        private System.Windows.Forms.Button btnPeta;
        private System.Windows.Forms.Button btnInfo;
        private AdminInformasi adminInformasi1;
    }
}