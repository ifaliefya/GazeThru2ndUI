namespace GazethruApps
{
    partial class AdminInfoNew
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
            this.labelNo = new System.Windows.Forms.Label();
            this.NoInfo = new System.Windows.Forms.Label();
            this.labelJudul = new System.Windows.Forms.Label();
            this.textBoxJudul = new System.Windows.Forms.TextBox();
            this.labelGambar = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelIsi = new System.Windows.Forms.Label();
            this.textBoxIsi = new System.Windows.Forms.RichTextBox();
            this.buttonInsert = new System.Windows.Forms.Button();
            this.buttonBrowsePict = new System.Windows.Forms.Button();
            this.ShowHide = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelNo
            // 
            this.labelNo.AutoSize = true;
            this.labelNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNo.ForeColor = System.Drawing.Color.White;
            this.labelNo.Location = new System.Drawing.Point(50, 43);
            this.labelNo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelNo.Name = "labelNo";
            this.labelNo.Size = new System.Drawing.Size(38, 17);
            this.labelNo.TabIndex = 0;
            this.labelNo.Text = "No : ";
            // 
            // NoInfo
            // 
            this.NoInfo.AutoSize = true;
            this.NoInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NoInfo.ForeColor = System.Drawing.Color.White;
            this.NoInfo.Location = new System.Drawing.Point(82, 43);
            this.NoInfo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.NoInfo.Name = "NoInfo";
            this.NoInfo.Size = new System.Drawing.Size(0, 17);
            this.NoInfo.TabIndex = 1;
            // 
            // labelJudul
            // 
            this.labelJudul.AutoSize = true;
            this.labelJudul.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelJudul.ForeColor = System.Drawing.Color.White;
            this.labelJudul.Location = new System.Drawing.Point(254, 43);
            this.labelJudul.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelJudul.Name = "labelJudul";
            this.labelJudul.Size = new System.Drawing.Size(50, 17);
            this.labelJudul.TabIndex = 2;
            this.labelJudul.Text = "Judul :";
            // 
            // textBoxJudul
            // 
            this.textBoxJudul.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxJudul.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxJudul.Location = new System.Drawing.Point(303, 37);
            this.textBoxJudul.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxJudul.Name = "textBoxJudul";
            this.textBoxJudul.Size = new System.Drawing.Size(514, 23);
            this.textBoxJudul.TabIndex = 3;
            // 
            // labelGambar
            // 
            this.labelGambar.AutoSize = true;
            this.labelGambar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGambar.ForeColor = System.Drawing.Color.White;
            this.labelGambar.Location = new System.Drawing.Point(49, 90);
            this.labelGambar.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelGambar.Name = "labelGambar";
            this.labelGambar.Size = new System.Drawing.Size(142, 17);
            this.labelGambar.TabIndex = 4;
            this.labelGambar.Text = "Gambar (rasio 2x3) : ";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(52, 119);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(220, 330);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // labelIsi
            // 
            this.labelIsi.AutoSize = true;
            this.labelIsi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelIsi.ForeColor = System.Drawing.Color.White;
            this.labelIsi.Location = new System.Drawing.Point(300, 90);
            this.labelIsi.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelIsi.Name = "labelIsi";
            this.labelIsi.Size = new System.Drawing.Size(78, 17);
            this.labelIsi.TabIndex = 6;
            this.labelIsi.Text = "Deskripsi : ";
            // 
            // textBoxIsi
            // 
            this.textBoxIsi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxIsi.Location = new System.Drawing.Point(303, 119);
            this.textBoxIsi.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxIsi.Name = "textBoxIsi";
            this.textBoxIsi.Size = new System.Drawing.Size(514, 330);
            this.textBoxIsi.TabIndex = 7;
            this.textBoxIsi.Text = "";
            // 
            // buttonInsert
            // 
            this.buttonInsert.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(185)))));
            this.buttonInsert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonInsert.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonInsert.ForeColor = System.Drawing.Color.White;
            this.buttonInsert.Location = new System.Drawing.Point(654, 480);
            this.buttonInsert.Margin = new System.Windows.Forms.Padding(2);
            this.buttonInsert.Name = "buttonInsert";
            this.buttonInsert.Size = new System.Drawing.Size(156, 32);
            this.buttonInsert.TabIndex = 8;
            this.buttonInsert.Text = "SIMPAN";
            this.buttonInsert.UseVisualStyleBackColor = false;
            this.buttonInsert.Click += new System.EventHandler(this.buttonInsert_Click);
            // 
            // buttonBrowsePict
            // 
            this.buttonBrowsePict.BackColor = System.Drawing.SystemColors.ControlLight;
            this.buttonBrowsePict.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBrowsePict.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBrowsePict.Location = new System.Drawing.Point(53, 417);
            this.buttonBrowsePict.Margin = new System.Windows.Forms.Padding(2);
            this.buttonBrowsePict.Name = "buttonBrowsePict";
            this.buttonBrowsePict.Size = new System.Drawing.Size(148, 32);
            this.buttonBrowsePict.TabIndex = 11;
            this.buttonBrowsePict.Text = "UNGGAH GAMBAR";
            this.buttonBrowsePict.UseVisualStyleBackColor = false;
            this.buttonBrowsePict.Click += new System.EventHandler(this.buttonBrowsePict_Click);
            // 
            // ShowHide
            // 
            this.ShowHide.AutoSize = true;
            this.ShowHide.Checked = true;
            this.ShowHide.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ShowHide.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShowHide.ForeColor = System.Drawing.Color.White;
            this.ShowHide.Location = new System.Drawing.Point(153, 42);
            this.ShowHide.Margin = new System.Windows.Forms.Padding(2);
            this.ShowHide.Name = "ShowHide";
            this.ShowHide.Size = new System.Drawing.Size(94, 21);
            this.ShowHide.TabIndex = 12;
            this.ShowHide.Text = "Show/Hide";
            this.ShowHide.UseVisualStyleBackColor = true;
            // 
            // AdminInfoNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(185)))));
            this.ClientSize = new System.Drawing.Size(866, 546);
            this.Controls.Add(this.ShowHide);
            this.Controls.Add(this.buttonBrowsePict);
            this.Controls.Add(this.buttonInsert);
            this.Controls.Add(this.textBoxIsi);
            this.Controls.Add(this.labelIsi);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.labelGambar);
            this.Controls.Add(this.textBoxJudul);
            this.Controls.Add(this.labelJudul);
            this.Controls.Add(this.NoInfo);
            this.Controls.Add(this.labelNo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "AdminInfoNew";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tambahkan Konten Baru";
            this.Load += new System.EventHandler(this.AdminInfoNew_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelNo;
        private System.Windows.Forms.Label NoInfo;
        private System.Windows.Forms.Label labelJudul;
        private System.Windows.Forms.TextBox textBoxJudul;
        private System.Windows.Forms.Label labelGambar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelIsi;
        private System.Windows.Forms.RichTextBox textBoxIsi;
        private System.Windows.Forms.Button buttonInsert;
        private System.Windows.Forms.Button buttonBrowsePict;
        private System.Windows.Forms.CheckBox ShowHide;
    }
}