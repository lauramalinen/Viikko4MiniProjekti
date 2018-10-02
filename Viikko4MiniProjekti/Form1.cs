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

            List<Juna> junat = BL.rata.JunatVälillä(s, s2);
            string d = string.Join(", ", junat.Select(j => j.trainNumber + " " + j.trainType));
            listBox1.DataSource = ($"Junat {s} ==> {s2}: " + d).ToList();
        }

    }
}
