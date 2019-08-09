namespace GazethruApps
{
    partial class formInformasi
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formInformasi));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnHome = new System.Windows.Forms.Button();
            this.btnTentang = new System.Windows.Forms.Button();
            this.btnPrestasi = new System.Windows.Forms.Button();
            this.btnKegiatan = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.PresenceCheck = new System.Windows.Forms.Panel();
            this.progressBarPrestasi = new System.Windows.Forms.ProgressBar();
            this.progressBarKegiatan = new System.Windows.Forms.ProgressBar();
            this.progressBarTentang = new System.Windows.Forms.ProgressBar();
            this.progressBarHome = new System.Windows.Forms.ProgressBar();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(197)))), ((int)(((byte)(1)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1920, 39);
            this.panel1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Black", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(23)))), ((int)(((byte)(46)))));
            this.label1.Location = new System.Drawing.Point(887, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 32);
            this.label1.TabIndex = 2;
            this.label1.Text = "INFORMASI";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnHome
            // 
            this.btnHome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(197)))), ((int)(((byte)(1)))));
            this.btnHome.FlatAppearance.BorderSize = 0;
            this.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHome.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHome.Location = new System.Drawing.Point(1086, 773);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(155, 56);
            this.btnHome.TabIndex = 9;
            this.btnHome.Text = "Home";
            this.btnHome.UseVisualStyleBackColor = false;
            this.btnHome.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnTentang
            // 
            this.btnTentang.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(185)))));
            this.btnTentang.FlatAppearance.BorderSize = 0;
            this.btnTentang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTentang.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTentang.ForeColor = System.Drawing.Color.White;
            this.btnTentang.Location = new System.Drawing.Point(1520, 650);
            this.btnTentang.Name = "btnTentang";
            this.btnTentang.Size = new System.Drawing.Size(220, 56);
            this.btnTentang.TabIndex = 24;
            this.btnTentang.Text = "Tentang DTETI";
            this.btnTentang.UseVisualStyleBackColor = false;
            this.btnTentang.Click += new System.EventHandler(this.btnTentang_Click);
            // 
            // btnPrestasi
            // 
            this.btnPrestasi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(185)))));
            this.btnPrestasi.FlatAppearance.BorderSize = 0;
            this.btnPrestasi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrestasi.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrestasi.ForeColor = System.Drawing.Color.White;
            this.btnPrestasi.Location = new System.Drawing.Point(700, 170);
            this.btnPrestasi.Name = "btnPrestasi";
            this.btnPrestasi.Size = new System.Drawing.Size(155, 56);
            this.btnPrestasi.TabIndex = 25;
            this.btnPrestasi.Text = "Prestasi";
            this.btnPrestasi.UseVisualStyleBackColor = false;
            this.btnPrestasi.Click += new System.EventHandler(this.btnPrestasi_Click);
            // 
            // btnKegiatan
            // 
            this.btnKegiatan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(185)))));
            this.btnKegiatan.FlatAppearance.BorderSize = 0;
            this.btnKegiatan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKegiatan.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKegiatan.ForeColor = System.Drawing.Color.White;
            this.btnKegiatan.Location = new System.Drawing.Point(300, 350);
            this.btnKegiatan.Name = "btnKegiatan";
            this.btnKegiatan.Size = new System.Drawing.Size(155, 56);
            this.btnKegiatan.TabIndex = 26;
            this.btnKegiatan.Text = "Kegiatan";
            this.btnKegiatan.UseVisualStyleBackColor = false;
            this.btnKegiatan.Click += new System.EventHandler(this.btnKegiatan_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(622, 307);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(710, 430);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 27;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(186)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 1070);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1920, 10);
            this.panel2.TabIndex = 28;
            // 
            // PresenceCheck
            // 
            this.PresenceCheck.BackColor = System.Drawing.Color.Maroon;
            this.PresenceCheck.Location = new System.Drawing.Point(955, 1070);
            this.PresenceCheck.Name = "PresenceCheck";
            this.PresenceCheck.Size = new System.Drawing.Size(10, 10);
            this.PresenceCheck.TabIndex = 36;
            // 
            // progressBarPrestasi
            // 
            this.progressBarPrestasi.Location = new System.Drawing.Point(700, 170);
            this.progressBarPrestasi.Maximum = 80;
            this.progressBarPrestasi.Name = "progressBarPrestasi";
            this.progressBarPrestasi.Size = new System.Drawing.Size(155, 5);
            this.progressBarPrestasi.TabIndex = 37;
            // 
            // progressBarKegiatan
            // 
            this.progressBarKegiatan.Location = new System.Drawing.Point(300, 350);
            this.progressBarKegiatan.Maximum = 80;
            this.progressBarKegiatan.Name = "progressBarKegiatan";
            this.progressBarKegiatan.Size = new System.Drawing.Size(155, 5);
            this.progressBarKegiatan.TabIndex = 38;
            // 
            // progressBarTentang
            // 
            this.progressBarTentang.Location = new System.Drawing.Point(1520, 650);
            this.progressBarTentang.Maximum = 80;
            this.progressBarTentang.Name = "progressBarTentang";
            this.progressBarTentang.Size = new System.Drawing.Size(220, 5);
            this.progressBarTentang.TabIndex = 39;
            // 
            // progressBarHome
            // 
            this.progressBarHome.Location = new System.Drawing.Point(1086, 773);
            this.progressBarHome.Maximum = 80;
            this.progressBarHome.Name = "progressBarHome";
            this.progressBarHome.Size = new System.Drawing.Size(155, 5);
            this.progressBarHome.TabIndex = 40;
            // 
            // formInformasi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(23)))), ((int)(((byte)(46)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.progressBarHome);
            this.Controls.Add(this.progressBarTentang);
            this.Controls.Add(this.progressBarKegiatan);
            this.Controls.Add(this.progressBarPrestasi);
            this.Controls.Add(this.PresenceCheck);
            this.Controls.Add(this.btnKegiatan);
            this.Controls.Add(this.btnPrestasi);
            this.Controls.Add(this.btnTentang);
            this.Controls.Add(this.btnHome);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pictureBox1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "formInformasi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormInformasi";
            this.Load += new System.EventHandler(this.FormInformasi_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Button btnTentang;
        private System.Windows.Forms.Button btnPrestasi;
        private System.Windows.Forms.Button btnKegiatan;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel PresenceCheck;
        private System.Windows.Forms.ProgressBar progressBarPrestasi;
        private System.Windows.Forms.ProgressBar progressBarKegiatan;
        private System.Windows.Forms.ProgressBar progressBarTentang;
        private System.Windows.Forms.ProgressBar progressBarHome;
    }
}