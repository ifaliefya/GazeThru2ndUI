using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Diagnostics;
using EyeXFramework;
using Tobii.EyeX;
using Tobii.EyeX.Framework;
using System.Windows.Forms;

namespace GazethruApps
{
    public delegate void FungsiTombol(ArgumenKendaliTombol e);

    public class ArgumenKendaliTombol
    {
        public double korelasiX;
        public double korelasiY;
        public double jarak;
        public bool status;
        public int? mataX;
        public int? mataY;
        public int DataKor;
        public bool CekMata;

        public ArgumenKendaliTombol(double corx, double cory, double dist, bool state, int? gazeX, int? gazeY, int datakorelasi, bool Presence)
        {
            korelasiX = corx;
            korelasiY = cory;
            jarak = dist;
            status = state;
            mataX = gazeX;
            mataY = gazeY;
            DataKor = datakorelasi;
            CekMata = Presence;
        }
    }

    public class KendaliTombol
    {
        int ukuranKorelasi = 5;
        int ukuranFilterMata = 30;

        double ThresholdJarak = 250;
        double ThresholdKorelasi = 0.8;

        int DurasiJarakEuclidean = 100;
        int DurasiKorelasiPearson = 100;

        EyeXHost Host;
        GazePointDataStream DataStream;

        int[][] PosisiMata;
        int[][] PosisiMataAsli;

        double[] KorX;
        double[] KorY;

        List<Control> DaftarTombol;
        List<FungsiTombol> DaftarFungsi;
        List<int[][]> DaftarPosisiTombol;

        List<int> HasilKorelasiPearson;
        List<int> HasilJarakEuclidean;
        List<int> HasilKorelasiX;
        List<int> HasilKorelasiY;

        List<double[]> DaftarJarakEuclidean;
        List<double[]> DaftarKorX;
        List<double[]> DaftarKorY;

        int? posisimataX;
        int? posisimataY;

        int DataKorelasi;

        int jumlahSama = 0;
        int posisiTerakhirMataX;
        int posisiTerakhirMataY;

        public KendaliTombol()
        {
            DaftarTombol = new List<Control>();
            DaftarFungsi = new List<FungsiTombol>();
            DaftarPosisiTombol = new List<int[][]>();

            PosisiMata = new int[2][];
            PosisiMata[0] = new int[ukuranKorelasi];
            PosisiMata[1] = new int[ukuranKorelasi];

            PosisiMataAsli = new int[2][];
            PosisiMataAsli[0] = new int[ukuranFilterMata];
            PosisiMataAsli[1] = new int[ukuranFilterMata];

            KorX = new double[ukuranKorelasi];
            KorY = new double[ukuranKorelasi];

            HasilJarakEuclidean = new List<int>();
            HasilKorelasiPearson = new List<int>();
            HasilKorelasiX = new List<int>();
            HasilKorelasiY = new List<int>();

            DaftarJarakEuclidean = new List<double[]>();
            DaftarKorX = new List<double[]>();
            DaftarKorY = new List<double[]>();
        }

        public void Start()
        {
            Host = new EyeXHost();
            DataStream = Host.CreateGazePointDataStream(GazePointDataMode.LightlyFiltered);

            Host.Start();
            DataStream.Next += SimpanPosisiMata;
        }       

        public void TambahTombol(Control tombol, FungsiTombol fungsi)
        {
            DaftarTombol.Add(tombol);
            DaftarFungsi.Add(fungsi);

            DaftarPosisiTombol.Add(new int[2][]);
            DaftarPosisiTombol[DaftarPosisiTombol.Count - 1][0] = new int[ukuranKorelasi];
            DaftarPosisiTombol[DaftarPosisiTombol.Count - 1][1] = new int[ukuranKorelasi];

            HasilJarakEuclidean.Add(0);
            HasilKorelasiPearson.Add(0);
            HasilKorelasiX.Add(0);
            HasilKorelasiY.Add(0);

            DaftarJarakEuclidean.Add(new double[DurasiJarakEuclidean + 1]);
            DaftarKorX.Add(new double[DurasiKorelasiPearson + 1]);
            DaftarKorY.Add(new double[DurasiKorelasiPearson + 1]);
            
        }

        void SimpanPosisiMata(object sender, GazePointEventArgs e)
        {
            int[] PosisiMataSekarang = { (int)e.X, (int)e.Y };

            for (int i = ukuranFilterMata - 1; i > 0; i--)
            {
                PosisiMataAsli[0][i] = PosisiMataAsli[0][i - 1];
                PosisiMataAsli[1][i] = PosisiMataAsli[1][i - 1];

            }
            PosisiMataAsli[0][0] = PosisiMataSekarang[0];
            PosisiMataAsli[1][0] = PosisiMataSekarang[1];

            for (int i = ukuranKorelasi - 1; i > 0; i--)
            {
                PosisiMata[0][i] = PosisiMata[0][i - 1];
                PosisiMata[1][i] = PosisiMata[1][i - 1];

            }
            PosisiMata[0][0] = AverageFilter(PosisiMataAsli[0]);
            PosisiMata[1][0] = AverageFilter(PosisiMataAsli[1]);

            GeserPosisiTombol();
        }

        int AverageFilter(int[] data)
        {
            int posisi = 0;
            for (int i = 0; i < data.Length; i++)
            {
                posisi += data[i];
            }
            return posisi / data.Length;
        }

        void GeserPosisiTombol()
        {
            for(int i = 0; i < DaftarTombol.Count; i++)
            {
                for(int j = ukuranKorelasi - 1; j > 0; j--)
                {
                    DaftarPosisiTombol[i][0][j] = DaftarPosisiTombol[i][0][j - 1];
                    DaftarPosisiTombol[i][1][j] = DaftarPosisiTombol[i][1][j - 1];
                }
            }
        }

        void SimpanPosisiTombol()
        {
            GeserPosisiTombol();
            for (int i = 0; i < DaftarTombol.Count; i++)
            {
                int[] PosisiTombolSekarang = PosisiTombol(i);
                DaftarPosisiTombol[i][0][0] = PosisiTombolSekarang[0];
                DaftarPosisiTombol[i][1][0] = PosisiTombolSekarang[1];
            }
        }

        int[] PosisiTombol(int index)
        {
            Point posisi = DaftarTombol[index].Parent.PointToScreen(DaftarTombol[index].Location);
            return new int[] { posisi.X, posisi.Y };
        }

        double JarakEuclidean(int titik1x, int titik1y, int titik2x, int titik2y)
        {
            int Ax = titik1x - titik2x;
            int Ay = titik1y - titik2y;
            return Math.Sqrt(Ax * Ax + Ay * Ay);
        }

        double KorelasiPearson(int[] x, int[] y)
        {
            double ux = 0;
            double uy = 0;
            double uxx = 0;
            double uyy = 0;
            double uxy = 0;

            for(int i = 0; i < x.Length; i++)
            {
                ux += x[i];
                uy += y[i];
                uxx += x[i] * x[i];
                uyy += y[i] * y[i];
                uxy += x[i] * y[i];
            }
            return (ukuranKorelasi * uxy - ux * uy) / (Math.Sqrt((ukuranKorelasi * uxx - ux * ux) * (ukuranKorelasi * uyy - uy * uy)) +1e-10);
        }

        public void CekTombol()
        {
            SimpanPosisiTombol();

            if(posisiTerakhirMataX == PosisiMata[0][0] && posisiTerakhirMataY == PosisiMata[1][0]) // Cek posisi mata sama dengan sebelumnya (User Presence)
            {
                jumlahSama++;
            }
            else
            {
                jumlahSama = 0;
            }

            posisiTerakhirMataX = PosisiMata[0][0];
            posisiTerakhirMataY = PosisiMata[1][0];

            if (jumlahSama > 5) //// NO PRESENCE
            {
                return;
            }

            // jika User Presence lolos
            for (int i = 0; i < DaftarTombol.Count; i++)
            {
                posisimataX = PosisiMata[0][0];
                posisimataY = PosisiMata[1][0];

                double jarak = JarakEuclidean(DaftarPosisiTombol[i][0][0], DaftarPosisiTombol[i][1][0], PosisiMata[0][0], PosisiMata[1][0]);
                DaftarJarakEuclidean[i][HasilJarakEuclidean[i]] = jarak;
                HasilJarakEuclidean[i] = jarak < ThresholdJarak ? HasilJarakEuclidean[i] + 1 : 0;

                double korelasix = KorelasiPearson(DaftarPosisiTombol[i][0], PosisiMata[0]);
                double korelasiy = KorelasiPearson(DaftarPosisiTombol[i][1], PosisiMata[1]);                  
                
                HasilKorelasiX[i] = (korelasix > ThresholdKorelasi) ? HasilKorelasiX[i] + 1 : 0;
                HasilKorelasiY[i] = (korelasiy > ThresholdKorelasi) ? HasilKorelasiY[i] + 1 : 0;                              

                HasilKorelasiPearson[i] = (korelasix > ThresholdKorelasi || korelasiy > ThresholdKorelasi) ? HasilKorelasiPearson[i] + 1 : 0;
                
                DataKorelasi = HasilKorelasiPearson[i];

                bool statusjarak = HasilJarakEuclidean[i] >= DurasiJarakEuclidean;
                bool statuskorelasi = HasilKorelasiPearson[i] >= DurasiKorelasiPearson;

                if (statusjarak)
                {
                    HasilJarakEuclidean[i] = 0;
                }
                
                if(statuskorelasi)
                {
                    HasilKorelasiPearson[i] = 0;
                }

                bool UserPresence = jumlahSama == 0;

                ArgumenKendaliTombol e = new ArgumenKendaliTombol(korelasix, korelasiy, jarak, statuskorelasi, posisimataX, posisimataY, DataKorelasi, UserPresence);  //hanya untuk ppmc
                
                DaftarFungsi[i](e);                
            }
        }

        public void Close()
        {
            Host.Dispose();
        }

        public void NoLook()
        {
            for (int i = 0; i < DaftarTombol.Count; i++)
            {
                HasilKorelasiPearson[i] = 0;
            }


        }               
    }
}
