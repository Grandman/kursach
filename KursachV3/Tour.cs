using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace KursachV3
{
    class Tour
    {
        readonly Db _db = new Db(Properties.Settings.Default.Database1ConnectionString);
        readonly Hashtable _htb = new Hashtable();
        readonly HttpRequest _request = new HttpRequest();
        readonly Dictionary<string, int> _parametrs = new Dictionary<string, int>();//страны
        private readonly BackgroundWorker _parseTours = new BackgroundWorker();
        public Tour(Db database)
        {
            _db = database;
            _parseTours.WorkerReportsProgress = true;
            _parseTours.WorkerSupportsCancellation = true;
            //ParseTours.DoWork += new System.ComponentModel.DoWorkEventHandler(this.ParseToursDoWork);
            //ParseTours.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.ParseToursCompleted);
            //ParseTours.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.ParseToursProgressChanged);
        }
        public string GetCity(string city)
        {
            return "" + _htb[city];
        }
        public DataTable GetAllToursFromBd(int money = 0)
        {
            var table = money == 0 ? _db.Select("*", "tours", "id", "desc") : _db.Select("*", "tours", "", "", "price<='" + money + "'");
            return table;
        }

        public string[] GetCities()
        {
            _htb.Clear();
            var page = HttpRequest.GetResponse("http://www.1001tur.ru/searest.htm","","GET");
            var pattern = @"(<select name=""from_city"" class=""sfs_fake_chouse_select jq_fake_chouse_select"">)([\s\S]*)(\t{4}</select>)";
            var regex = new Regex(pattern);
            var match = regex.Match(page);
            var cities = match.Groups[2].Value;
            pattern = @"(<OPTION value="")([0-9]{1,6})("" class=""""(?: >| SELECTED>))(\D*)(</OPTION>)";
            regex = new Regex(pattern);
            match = regex.Match(cities);
            while (match.Success)
            {
                _htb.Add(match.Groups[4].Value, match.Groups[2].Value);//HASHTABLE (ГОРОД;ID)
                match = match.NextMatch();
            }
            var result = new string[_htb.Keys.Count]; 
            this._htb.Keys.CopyTo(result,0);
            return result;
        }
        [JsonObject(MemberSerialization.OptIn)]
        struct Country
        {
            [JsonProperty("value")]
            public int Value { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }
        }
        public Dictionary<string, int> JsonParsingCountries(int cityId) // происходит при выборе города
        {
            var id = _htb[cityId].ToString();
            var json = HttpRequest.GetResponse("http://www.1001tur.ru/cgi-bin/get_countries.pl?from_city=" + id + "&json=1","","GET");
            if (json == null)
            {
                return null;
            }
            var country = JsonConvert.DeserializeObject<Country[]>(json);
            _parametrs.Clear();
            foreach (var countries in country)
            {
                _parametrs.Add(countries.Name, countries.Value);
            }

            return _parametrs;
        }
        public void UpdateTour(int id, int price,DateTime date, string description,string hotel,int stars,string url,string country)
        {
            var vars = ToursValues(price, date, description, hotel, stars, url, country);
            _db.Update("tours",vars,id);
        }
        public void AddTour(int price, DateTime date, string description, string hotel, int stars, string url, string country)
        {
            var vars = ToursValues(price, date, description, hotel, stars, url, country);
            _db.Insert("tours",vars);
        }
        private static Dictionary<string,object> ToursValues(int price, DateTime date, string description, string hotel, int stars, string url, string country)
        {
            var vars = new Dictionary<string, object>
                           {
                               {"price", price},
                               {"date", date},
                               {"description", description},
                               {"hotel", hotel},
                               {"stars", stars},
                               {"url", url},
                               {"country", country}
                           };

            return vars;
        }
        public void DelTour(int id)
        {
            _db.Delete("tours", id);
        }
    }
}
