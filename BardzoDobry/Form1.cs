using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace BardzoDobry
{
    public partial class Form1 : Form
    {
        int[,] PlikTrasy;
        int[] trasa;
        int DlugoTrasy;

        public Form1()
        {
            InitializeComponent();
            PlikTrasy = new int[49, 49];
            trasa = new int[49];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            z_pliku();
            //for(int i=0; i<49;i++)
            //{
            //    for(int j=0; j<49; j++)
            //    {
            //        richTextBox1.Text += PlikTrasy[i, j]+ "  ";

            //    }
            //    richTextBox1.Text += Environment.NewLine;
            //}
            for(int i=0; i<49; i++)
            {
                trasa[i] = i;


            }

            DlugoTrasy =licz(trasa);
            richTextBox1.Text = "Pierwszy wynik: "+Convert.ToString(DlugoTrasy)+Environment.NewLine;

            int iteracje = Convert.ToInt32(textBox1.Text);

            for(int i=0; i<iteracje; i++)
            {
                mutuj();


            }
            DlugoTrasy = licz(trasa);
            richTextBox1.Text +="Ostateczny wynik: " +Convert.ToString(DlugoTrasy);

        }

        private int licz(int[] trasa2)
        {
            int trasa_pomocnicza=0;
            for(int i=0; i<48; i++)
            {
                trasa_pomocnicza += PlikTrasy[trasa2[i], trasa2[i + 1]];


            }
            trasa_pomocnicza += PlikTrasy[trasa2[48], trasa2[0]];

            //richTextBox1.Text = Convert.ToString(trasa_pomocnicza);
            return trasa_pomocnicza;
        }

        private void mutuj()
        {
            Random r = new Random();
            int[] pomocnicza_trasa = new int[49];

            for (int i = 0; i < 49; i++)
                pomocnicza_trasa[i] = trasa[i];

            
            int I_miasto = r.Next(1, 48);
            int II_miasto = r.Next(1, 48);
            int pomocnicza = trasa[I_miasto];
            pomocnicza_trasa[I_miasto] = pomocnicza_trasa[II_miasto];
            pomocnicza_trasa[II_miasto] = pomocnicza;

            if(licz(trasa) >licz(pomocnicza_trasa))
            {
                for (int i = 0; i < 49; i++)
                    trasa[i] = pomocnicza_trasa[i];


            }


        }

        private void z_pliku()
        {



            int id = 0;
            using (StreamReader SR = new StreamReader("..\\..\\miasta.txt"))
            {
                string wiersz;
                while ((wiersz = SR.ReadLine()) != null)
                {
                    string[] spliter = wiersz.Split(',');
                    for (int i = 0; i < spliter.Length; i++)
                    {
                        int dlugosc = Convert.ToInt32(spliter[i]);
                       PlikTrasy[id, i] = dlugosc;
                    }
                    id++;
                }
            }


        }


    }
}
