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
        public Form1()
        {
            InitializeComponent();
            lPaikat = new List<Liikennepaikka>();
            junat = new List<Juna>();
            APIUtil rata = new APIUtil();
            lPaikat = rata.Liikennepaikat();
            comboBox1.DataSource = lPaikat.Select(lpaikka => lpaikka.stationName).ToArray();
            comboBox2.DataSource = lPaikat.Select(lpaikka => lpaikka.stationName).ToArray();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
