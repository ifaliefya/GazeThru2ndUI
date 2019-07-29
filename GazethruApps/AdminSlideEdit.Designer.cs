namespace GazethruApps
{
    partial class AdminSlideEdit
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
            this.ShowHide = new System.Windows.Forms.CheckBox();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.TanggalNOW = new System.Windows.Forms.Label();
            this.labelTgl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxJudul = new System.Windows.Forms.TextBox();
            this.buttonBrowsePict = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // ShowHide
            // 
            this.ShowHide.AutoSize = true;
            this.ShowHide.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ShowHide.ForeColor = System.Drawing.Color.White;
            this.ShowHide.Location = new System.Drawing.Point(313, 24);
            this.ShowHide.Margin = new System.Windows.Forms.Padding(2);
            this.ShowHide.Name = "ShowHide";
            this.ShowHide.Size = new System.Drawing.Size(78, 17);
            this.ShowHide.TabIndex = 15;
            this.ShowHide.Text = "Show/Hide";
            this.ShowHide.UseVisualStyleBackColor = true;
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(23)))), ((int)(((byte)(46)))));
            this.buttonUpdate.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonUpdate.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonUpdate.ForeColor = System.Drawing.Color.White;
            this.buttonUpdate.Location = new System.Drawing.Point(156, 604);
            this.buttonUpdate.Margin = new System.Windows.Forms.Padding(2);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(156, 32);
            this.buttonUpdate.TabIndex = 14;
            this.buttonUpdate.Text = "PERBARUI";
            this.buttonUpdate.UseVisualStyleBackColor = false;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // TanggalNOW
            // 
            this.TanggalNOW.AutoSize = true;
            this.TanggalNOW.ForeColor = System.Drawing.Color.White;
            this.TanggalNOW.Location = new System.Drawing.Point(122, 24);
            this.TanggalNOW.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.TanggalNOW.Name = "TanggalNOW";
            this.TanggalNOW.Size = new System.Drawing.Size(75, 13);
            this.TanggalNOW.TabIndex = 13;
            this.TanggalNOW.Text = "DD-MM-YYYY";
            // 
            // labelTgl
            // 
            this.labelTgl.AutoSize = true;
            this.labelTgl.ForeColor = System.Drawing.Color.White;
            this.labelTgl.Location = new System.Drawing.Point(67, 24);
            this.labelTgl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTgl.Name = "labelTgl";
            this.labelTgl.Size = new System.Drawing.Size(52, 13);
            this.labelTgl.TabIndex = 12;
            this.labelTgl.Text = "Tanggal :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(67, 62);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Judul :";
            // 
            // textBoxJudul
            // 
            this.textBoxJudul.ForeColor = System.Drawing.Color.White;
            this.textBoxJudul.Location = new System.Drawing.Point(120, 60);
            this.textBoxJudul.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxJudul.Name = "textBoxJudul";
            this.textBoxJudul.Size = new System.Drawing.Size(270, 20);
            this.textBoxJudul.TabIndex = 10;
            // 
            // buttonBrowsePict
            // 
            this.buttonBrowsePict.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBrowsePict.Location = new System.Drawing.Point(70, 541);
            this.buttonBrowsePict.Margin = new System.Windows.Forms.Padding(2);
            this.buttonBrowsePict.Name = "buttonBrowsePict";
            this.buttonBrowsePict.Size = new System.Drawing.Size(148, 32);
            this.buttonBrowsePict.TabIndex = 9;
            this.buttonBrowsePict.Text = "UNGGAH GAMBAR";
            this.buttonBrowsePict.UseVisualStyleBackColor = true;
            this.buttonBrowsePict.Click += new System.EventHandler(this.buttonBrowsePict_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pictureBox1.Location = new System.Drawing.Point(70, 93);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(320, 480);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Tag = "";
            // 
            // AdminSlideEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(23)))), ((int)(((byte)(46)))));
            this.ClientSize = new System.Drawing.Size(472, 681);
            this.Controls.Add(this.ShowHide);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.TanggalNOW);
            this.Controls.Add(this.labelTgl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxJudul);
            this.Controls.Add(this.buttonBrowsePict);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "AdminSlideEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Slider";
            this.Load += new System.EventHandler(this.AdminSlideEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox ShowHide;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Label TanggalNOW;
        private System.Windows.Forms.Label labelTgl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxJudul;
        private System.Windows.Forms.Button buttonBrowsePict;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}