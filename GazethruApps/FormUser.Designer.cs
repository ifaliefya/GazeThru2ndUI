﻿namespace GazethruApps
{
    partial class formUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formUser));
            this.btnInfo = new System.Windows.Forms.Button();
            this.btnPeta = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.PresenceCheck = new System.Windows.Forms.Panel();
            this.progressBarInform = new System.Windows.Forms.ProgressBar();
            this.progressBarPeta = new System.Windows.Forms.ProgressBar();
            this.progressBarBack = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnInfo
            // 
            this.btnInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(185)))));
            this.btnInfo.FlatAppearance.BorderSize = 0;
            this.btnInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInfo.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInfo.ForeColor = System.Drawing.Color.White;
            this.btnInfo.Location = new System.Drawing.Point(375, 400);
            this.btnInfo.Name = "btnInfo";
            this.btnInfo.Size = new System.Drawing.Size(155, 56);
            this.btnInfo.TabIndex = 5;
            this.btnInfo.Text = "Informasi";
            this.btnInfo.UseVisualStyleBackColor = false;
            this.btnInfo.Click += new System.EventHandler(this.btnInfo_Click);
            // 
            // btnPeta
            // 
            this.btnPeta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(185)))));
            this.btnPeta.FlatAppearance.BorderSize = 0;
            this.btnPeta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPeta.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPeta.ForeColor = System.Drawing.Color.White;
            this.btnPeta.Location = new System.Drawing.Point(1420, 400);
            this.btnPeta.Name = "btnPeta";
            this.btnPeta.Size = new System.Drawing.Size(155, 56);
            this.btnPeta.TabIndex = 6;
            this.btnPeta.Text = "Peta";
            this.btnPeta.UseVisualStyleBackColor = false;
            this.btnPeta.Click += new System.EventHandler(this.btnPeta_Click);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(197)))), ((int)(((byte)(1)))));
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(23)))), ((int)(((byte)(46)))));
            this.btnBack.Location = new System.Drawing.Point(884, 940);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(155, 56);
            this.btnBack.TabIndex = 7;
            this.btnBack.Text = "Kembali";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(723, 67);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(504, 125);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(574, 311);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(796, 297);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 10;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // PresenceCheck
            // 
            this.PresenceCheck.BackColor = System.Drawing.Color.LightCoral;
            this.PresenceCheck.Location = new System.Drawing.Point(955, 1070);
            this.PresenceCheck.Name = "PresenceCheck";
            this.PresenceCheck.Size = new System.Drawing.Size(10, 10);
            this.PresenceCheck.TabIndex = 37;
            // 
            // progressBarInform
            // 
            this.progressBarInform.Location = new System.Drawing.Point(375, 400);
            this.progressBarInform.Maximum = 80;
            this.progressBarInform.Name = "progressBarInform";
            this.progressBarInform.Size = new System.Drawing.Size(155, 5);
            this.progressBarInform.TabIndex = 38;
            // 
            // progressBarPeta
            // 
            this.progressBarPeta.Location = new System.Drawing.Point(1420, 400);
            this.progressBarPeta.Maximum = 80;
            this.progressBarPeta.Name = "progressBarPeta";
            this.progressBarPeta.Size = new System.Drawing.Size(155, 5);
            this.progressBarPeta.TabIndex = 39;
            // 
            // progressBarBack
            // 
            this.progressBarBack.Location = new System.Drawing.Point(884, 940);
            this.progressBarBack.Maximum = 80;
            this.progressBarBack.Name = "progressBarBack";
            this.progressBarBack.Size = new System.Drawing.Size(155, 5);
            this.progressBarBack.TabIndex = 40;
            // 
            // formUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(23)))), ((int)(((byte)(46)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.progressBarBack);
            this.Controls.Add(this.progressBarPeta);
            this.Controls.Add(this.progressBarInform);
            this.Controls.Add(this.PresenceCheck);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnPeta);
            this.Controls.Add(this.btnInfo);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "formUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "formUser";
            this.Load += new System.EventHandler(this.FormUser_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnInfo;
        private System.Windows.Forms.Button btnPeta;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel PresenceCheck;
        private System.Windows.Forms.ProgressBar progressBarInform;
        private System.Windows.Forms.ProgressBar progressBarPeta;
        private System.Windows.Forms.ProgressBar progressBarBack;
    }
}