﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GazethruApps
{
    public partial class formPeta : Form
    {
        List<double> wx;
        List<double> wy;
        int lap = 0;

        KendaliTombol kendali;
        public formPeta()
        {
            InitializeComponent();
            wx = new List<double>();
            wy = new List<double>();
            wx.Add(0); //btn Lantai 1
            wy.Add(0);
            wx.Add(0); //btn Lantai 2
            wy.Add(0);
            wx.Add(0); //btn Lantai 3
            wy.Add(0);
            wx.Add(0); //Home
            wy.Add(0);

            wx[0] = 250; //lantai 1
            wy[0] = 350;
            wx[1] = 700; //lantai 2
            wy[1] = 170;
            wx[2] = 1520; //lantai 3
            wy[2] = 650;
            wx[3] = 1086; //posisi awal btnhome
            wy[3] = 773; 

            kendali = new KendaliTombol();
            kendali.TambahTombol(btnHome, new FungsiTombol(TombolHomeTekan));
            kendali.TambahTombol(btnSatu, new FungsiTombol(TombolSatuTekan));
            kendali.TambahTombol(btnDua, new FungsiTombol(TombolDuaTekan));
            kendali.TambahTombol(btnTiga, new FungsiTombol(TombolTigaTekan));

            kendali.Start();
        }

        private static formPeta Instance;
        public static formPeta getInstance()
        {
            if (Instance == null || Instance.IsDisposed)
            {
                Instance = new formPeta();
            }
            else
            {
                Instance.BringToFront();
            }
            return Instance;
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            formUser Home = new formUser();
            Home.Show();
            this.Close();
        }

        //private void btnBack_Click(object sender, EventArgs e)
        //{
        //    formUser FormUser = new formUser();
        //    FormUser.Show();
        //    this.Close();
        //}

        private void formPeta_Load(object sender, EventArgs e)
        {
            timer1.Interval = 1;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            btnSatu.Location = new Point((int)wx[0], (int)wy[0]);
            btnDua.Location = new Point((int)wx[1], (int)wy[1]);
            btnTiga.Location = new Point((int)wx[2], (int)wy[2]);
            btnHome.Location = new Point((int)wx[3], (int)wy[3]);

            progressBarSatu.Location = new Point((int)wx[0], (int)wy[0]);
            progressBarDua.Location = new Point((int)wx[1], (int)wy[1]);
            progressBarTiga.Location = new Point((int)wx[2], (int)wy[2]);
            progressBarHome.Location = new Point((int)wx[3], (int)wy[3]);

            if (lap == 0)
            {
                wy[0]++;
                wx[1]++;
                wy[2]--;
                wx[3]--;
            }
            if (lap == 1)
            {
                wy[0]--;
                wx[1]--;
                wy[2]++;
                wx[3]++;
            }

            if (wx[3] == 786)
            {
                lap = 1;
            }
            if (wx[3] == 1086)
            {
                lap = 0;
            }

            kendali.CekTombol();
        }

        private void btnSatu_Click(object sender, EventArgs e)
        {
            formLantai1 FormLantai1 = new formLantai1();
            this.Close();
            FormLantai1.Show();
            FormLantai1.GetLantaiPic(1);
            FormLantai1.LoadPointer(1);
        }

        private void btnDua_Click(object sender, EventArgs e)
        {
            formLantai1 FormLantai1 = new formLantai1();
            this.Close();
            FormLantai1.Show();
            FormLantai1.GetLantaiPic(2);
            FormLantai1.LoadPointer(2);
        }

        private void btnTiga_Click(object sender, EventArgs e)
        {
            formLantai1 FormLantai1 = formLantai1.getInstance();
            this.Close();
            FormLantai1.Show();
            FormLantai1.GetLantaiPic(3);
            FormLantai1.LoadPointer(3);
        }

        private void TombolHomeTekan(ArgumenKendaliTombol e)
        {
            PresenceCheck.Visible = false;
            if (e.CekMata)
            {
                PresenceCheck.Visible = true;
            }

            if (e.mataX == null || e.mataY == null)
            {
                kendali.NoLook();
            }

            if (e.status)
            {
                formUser Home = formUser.getInstance();
                Home.Show();
                timer1.Stop();
                kendali.Close();
                this.Close();
            }

            progressBarHome.Value = e.DataKor;
        }

        private void TombolSatuTekan(ArgumenKendaliTombol e)
        {
            if (e.mataX == null || e.mataY == null)
            {
                kendali.NoLook();
            }

            if (e.status)
            {
                formLantai1 FormLantai1 = formLantai1.getInstance();
                FormLantai1.Show();
                FormLantai1.GetLantaiPic(1);
                FormLantai1.LoadPointer(1);
                timer1.Stop();
                kendali.Close();
                this.Close();
            }

            progressBarSatu.Value = e.DataKor;
        }

        private void TombolDuaTekan(ArgumenKendaliTombol e)
        {
            if (e.mataX == null || e.mataY == null)
            {
                kendali.NoLook();
            }

            if (e.status)
            {
                formLantai1 FormLantai1 = formLantai1.getInstance();
                FormLantai1.Show();
                FormLantai1.GetLantaiPic(2);
                FormLantai1.LoadPointer(2);
                timer1.Stop();
                kendali.Close();
                this.Close();
            }

            progressBarDua.Value = e.DataKor;
                
        }

        private void TombolTigaTekan(ArgumenKendaliTombol e)
        {
            if (e.mataX == null || e.mataY == null)
            {
                kendali.NoLook();
            }

            if (e.status)
            {
                formLantai1 FormLantai1 = formLantai1.getInstance();
                FormLantai1.Show();
                FormLantai1.GetLantaiPic(3);
                FormLantai1.LoadPointer(3);
                timer1.Stop();
                kendali.Close();
                this.Close();
            }

            progressBarTiga.Value = e.DataKor;
        }
    }
}
