using RataDigiTraffic.Model;
using RataDigiTraffic;
using JunatBL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Viikko4MiniProjekti
{
    public partial class Form1 : Form
    {
        Toiminnallisuus BL;
        public Form1()
        {
            InitializeComponent();
            BL = new Toiminnallisuus();
            BL.lPaikat = BL.rata.Liikennepaikat();
            comboBox1.DataSource = BL.lPaikat.Select(lpaikka => lpaikka.stationName).ToArray();
            comboBox2.DataSource = BL.lPaikat.Select(lpaikka => lpaikka.stationName).ToArray();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string s = BL.haeAsemaShortCode(comboBox1.SelectedItem.ToString());
            string s2 = BL.haeAsemaShortCode(comboBox2.SelectedItem.ToString());

            BL.junat = BL.rata.JunatVälillä(s, s2);  //Toimii tähän kohtaan
            List<string> naytto = new List<string>();
            IEnumerable<DateTime> haku = BL.junat.Select(p => p.timeTableRows)
                .Select(tr => tr[0].scheduledTime);
            DateTime[] ajat = haku.ToArray<DateTime>();
            for (int i = 0; i < ajat.Length ; i++)
            {
                naytto.Add(ajat[i].ToShortTimeString()+" "+BL.junat[i].trainNumber);
            }
            listBox1.DataSource = naytto;
        }

        void HaeJunat()
        {
            string[] rivit;
            foreach (Juna juna in BL.junat)
            {
                foreach (Aikataulurivi item in juna.timeTableRows)
                {
                    string rivi = item.scheduledTime.ToShortTimeString();
                }
            }
        }

    }
}
