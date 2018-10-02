using RataDigiTraffic.Model;
using RataDigiTraffic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JunatBL
{
    public class Toiminnallisuus
    {
        public List<Liikennepaikka> lPaikat;
        public List<Juna> junat;
        public APIUtil rata;

        public Toiminnallisuus()
        {
            lPaikat = new List<Liikennepaikka>();
            junat = new List<Juna>();
            rata = new APIUtil();
        }

        public string haeAsemaShortCode(string asema)
        {
            var indexi = lPaikat.Where(lpaikka => lpaikka.stationName.Contains(asema)).Select(lpaikka => lpaikka.stationShortCode);
            string str = string.Join("", indexi.ToArray());
            return str;
        }

        public List<DateTime> HaeJunanAikataulu()  // käsittellään tässä aseman lähtö ja saapumisaikataulu.
        {
            var tempList = new List<DateTime>();
            foreach (var item in junat)
            {
                List<RataDigiTraffic.Model.Aikataulurivi> art = item.timeTableRows;
                foreach (var i in art)
                {
                    if(i.stationShortCode=="TPE")
                    tempList.Add(i.scheduledTime);
                }
            }
            return tempList;
        }

        //public void HaeJunanTiedot()
        //{
        //    List<Juna> lista = new List<Juna>();
        //    var aikataulu = HaeJunanAikataulu();
        //    lista.Add(aikataulu);
        //}
    }
}
