using Newtonsoft.Json;
using RataDigiTraffic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace RataDigiTraffic
{
    public class APIUtil

    {
public List<Liikennepaikka> Liikennepaikat()
        {
            string json = "";
            using (var client = new HttpClient())
            {           
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync($"https://rata.digitraffic.fi/api/v1/metadata/stations").Result;
                var responseString = response.Content.ReadAsStringAsync().Result;
                json = responseString;
            }
            List<Liikennepaikka> res;
            res = JsonConvert.DeserializeObject<List<Liikennepaikka>>(json);
            return res;
        }

        public List<Juna> JunatVälillä(string mistä, string minne)
        {
            DateTime aloitus = new DateTime();
            aloitus = DateTime.Now.AddHours(-1);
            string json = "";
            string url = $"https://rata.digitraffic.fi/api/v1/schedules?departure_station={mistä}&arrival_station={minne}"; //Ei tulosta aikaa. API https://rata.digitraffic.fi/#reittiperusteinen-haku

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync(url).Result;
                var responseString = response.Content.ReadAsStringAsync().Result;
                json = responseString;
            }
            List<Juna> res;
            res = JsonConvert.DeserializeObject<List<Juna>>(json);
            return res;
        }

        public List<Kulkutietoviesti> LiikennepaikanJunat(string paikka )
        {
            string json = "";
            string url = $"https://rata.digitraffic.fi/api/v1/train-tracking?station={paikka}&departure_date={DateTime.Today.ToString("yyyy-MM-dd-hh-mm-ss")}";

            using (var client = new HttpClient())
            {

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync(url).Result;
                var responseString = response.Content.ReadAsStringAsync().Result;
                json = responseString;
            }
            List<Kulkutietoviesti> res;
            res = JsonConvert.DeserializeObject<List<Kulkutietoviesti>>(json);
            return res;
        }
    }





}
