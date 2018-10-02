using RataDigiTraffic.Model;
using RataDigiTraffic;
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
        List<Liikennepaikka> lPaikat;
        List<Juna> junat;
        APIUtil rata;
        public Form1()
        {
            InitializeComponent();
            lPaikat = new List<Liikennepaikka>();
            junat = new List<Juna>();
            rata = new APIUtil();
            lPaikat = rata.Liikennepaikat();
            comboBox1.DataSource = lPaikat.Select(lpaikka => lpaikka.stationName).ToArray();
            comboBox2.DataSource = lPaikat.Select(lpaikka => lpaikka.stationName).ToArray();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string s = haeAsemaShortCode(comboBox1.SelectedItem.ToString());
            string s2 = haeAsemaShortCode(comboBox2.SelectedItem.ToString());

            junat = rata.JunatVälillä(s, s2);  //Toimii tähän kohtaan
        }

        private string haeAsemaShortCode(string asema)
        {
            var indexi = lPaikat.Where(lpaikka => lpaikka.stationName.Contains(asema)).Select(lpaikka => lpaikka.stationShortCode);
            string str = string.Join("",indexi.ToArray());
            return str;
        }

        
    }
}
