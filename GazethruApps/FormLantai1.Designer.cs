namespace GazethruApps
{
    partial class formLantai1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formLantai1));
            this.btnBack = new System.Windows.Forms.Button();
            this.btnPrev = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelNamaLantai = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textBoxIsi = new System.Windows.Forms.TextBox();
            this.labelJudul = new System.Windows.Forms.Label();
            this.pictureBoxRuang = new System.Windows.Forms.PictureBox();
            this.panelPeta = new System.Windows.Forms.Panel();
            this.pbPetaLantai = new System.Windows.Forms.PictureBox();
            this.PresenceCheck = new System.Windows.Forms.Panel();
            this.btnNext2 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRuang)).BeginInit();
            this.panelPeta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPetaLantai)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(197)))), ((int)(((byte)(1)))));
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(1100, 900);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(155, 56);
            this.btnBack.TabIndex = 21;
            this.btnBack.Text = "Kembali";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnPrev
            // 
            this.btnPrev.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(185)))));
            this.btnPrev.FlatAppearance.BorderSize = 0;
            this.btnPrev.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrev.ForeColor = System.Drawing.Color.White;
            this.btnPrev.Image = ((System.Drawing.Image)(resources.GetObject("btnPrev.Image")));
            this.btnPrev.Location = new System.Drawing.Point(300, 145);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(40, 40);
            this.btnPrev.TabIndex = 24;
            this.btnPrev.UseVisualStyleBackColor = false;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(23)))), ((int)(((byte)(46)))));
            this.panel1.Controls.Add(this.labelNamaLantai);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1920, 39);
            this.panel1.TabIndex = 27;
            // 
            // labelNamaLantai
            // 
            this.labelNamaLantai.AutoSize = true;
            this.labelNamaLantai.Font = new System.Drawing.Font("Segoe UI Black", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNamaLantai.ForeColor = System.Drawing.Color.White;
            this.labelNamaLantai.Location = new System.Drawing.Point(860, 2);
            this.labelNamaLantai.Name = "labelNamaLantai";
            this.labelNamaLantai.Size = new System.Drawing.Size(201, 32);
            this.labelNamaLantai.TabIndex = 2;
            this.labelNamaLantai.Text = "LANTAI 1 DTETI";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(185)))));
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 1070);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1920, 10);
            this.panel3.TabIndex = 39;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(23)))), ((int)(((byte)(46)))));
            this.panel2.Controls.Add(this.textBoxIsi);
            this.panel2.Controls.Add(this.labelJudul);
            this.panel2.Controls.Add(this.pictureBoxRuang);
            this.panel2.Location = new System.Drawing.Point(0, 624);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1920, 270);
            this.panel2.TabIndex = 49;
            // 
            // textBoxIsi
            // 
            this.textBoxIsi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(23)))), ((int)(((byte)(46)))));
            this.textBoxIsi.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxIsi.ForeColor = System.Drawing.Color.White;
            this.textBoxIsi.Location = new System.Drawing.Point(539, 74);
            this.textBoxIsi.Multiline = true;
            this.textBoxIsi.Name = "textBoxIsi";
            this.textBoxIsi.ReadOnly = true;
            this.textBoxIsi.Size = new System.Drawing.Size(399, 102);
            this.textBoxIsi.TabIndex = 40;
            this.textBoxIsi.Text = resources.GetString("textBoxIsi.Text");
            // 
            // labelJudul
            // 
            this.labelJudul.AutoSize = true;
            this.labelJudul.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(23)))), ((int)(((byte)(46)))));
            this.labelJudul.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelJudul.ForeColor = System.Drawing.Color.White;
            this.labelJudul.Location = new System.Drawing.Point(534, 32);
            this.labelJudul.Name = "labelJudul";
            this.labelJudul.Size = new System.Drawing.Size(192, 25);
            this.labelJudul.TabIndex = 41;
            this.labelJudul.Text = "Ruang Tata Usaha";
            // 
            // pictureBoxRuang
            // 
            this.pictureBoxRuang.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxRuang.Image")));
            this.pictureBoxRuang.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxRuang.Name = "pictureBoxRuang";
            this.pictureBoxRuang.Size = new System.Drawing.Size(480, 270);
            this.pictureBoxRuang.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxRuang.TabIndex = 39;
            this.pictureBoxRuang.TabStop = false;
            // 
            // panelPeta
            // 
            this.panelPeta.Controls.Add(this.pbPetaLantai);
            this.panelPeta.Location = new System.Drawing.Point(439, 55);
            this.panelPeta.Name = "panelPeta";
            this.panelPeta.Size = new System.Drawing.Size(1048, 544);
            this.panelPeta.TabIndex = 55;
            // 
            // pbPetaLantai
            // 
            this.pbPetaLantai.BackColor = System.Drawing.Color.White;
            this.pbPetaLantai.Image = ((System.Drawing.Image)(resources.GetObject("pbPetaLantai.Image")));
            this.pbPetaLantai.Location = new System.Drawing.Point(3, 0);
            this.pbPetaLantai.Name = "pbPetaLantai";
            this.pbPetaLantai.Size = new System.Drawing.Size(1048, 541);
            this.pbPetaLantai.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPetaLantai.TabIndex = 50;
            this.pbPetaLantai.TabStop = false;
            // 
            // PresenceCheck
            // 
            this.PresenceCheck.BackColor = System.Drawing.Color.Maroon;
            this.PresenceCheck.Location = new System.Drawing.Point(955, 535);
            this.PresenceCheck.Name = "PresenceCheck";
            this.PresenceCheck.Size = new System.Drawing.Size(10, 10);
            this.PresenceCheck.TabIndex = 56;
            // 
            // btnNext2
            // 
            this.btnNext2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(185)))));
            this.btnNext2.FlatAppearance.BorderSize = 0;
            this.btnNext2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext2.ForeColor = System.Drawing.Color.White;
            this.btnNext2.Image = ((System.Drawing.Image)(resources.GetObject("btnNext2.Image")));
            this.btnNext2.Location = new System.Drawing.Point(1620, 456);
            this.btnNext2.Name = "btnNext2";
            this.btnNext2.Size = new System.Drawing.Size(40, 40);
            this.btnNext2.TabIndex = 57;
            this.btnNext2.UseVisualStyleBackColor = false;
            this.btnNext2.Click += new System.EventHandler(this.btnNext2_Click);
            // 
            // formLantai1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.btnNext2);
            this.Controls.Add(this.PresenceCheck);
            this.Controls.Add(this.panelPeta);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.btnPrev);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "formLantai1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormLantai1";
            this.Load += new System.EventHandler(this.FormLantai1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRuang)).EndInit();
            this.panelPeta.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbPetaLantai)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label labelNamaLantai;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBoxRuang;
        private System.Windows.Forms.TextBox textBoxIsi;
        private System.Windows.Forms.Label labelJudul;
        private System.Windows.Forms.Panel panelPeta;
        private System.Windows.Forms.PictureBox pbPetaLantai;
        private System.Windows.Forms.Panel PresenceCheck;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnNext2;
    }
}