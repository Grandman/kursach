using System;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace KursachV3
{
    static class Tour
    {
        /// <summary>
        /// Хранит города в виде : (город;id)
        /// </summary>
        static readonly Dictionary<string, int> Towns = new Dictionary<string, int>();
        /// <summary>
        /// Страны
        /// </summary>
        static readonly Dictionary<string, int> Parametrs = new Dictionary<string, int>();
        /// <summary>
        /// Парсинг туров по страницам
        /// </summary>
        /// <param name="country">Страна куда лететь</param>
        /// <param name="page">Страница на сайте</param>
        /// <param name="nightFrom">От скольки ночей</param>
        /// <param name="nightTo">До скольки ночей</param>
        /// <param name="dateFrom">Начиная с даты</param>
        /// <param name="dateTo">Заканчивая датой</param>
        /// <param name="townFrom">Из какого города (название)</param>
        /// <returns></returns>
        static DataTable ParseTours(string country, int page, int nightFrom, int nightTo, DateTime dateFrom, DateTime dateTo, string townFrom)
        {
            DataTable tableTours = new DataTable();
            tableTours.Columns.Add("Name");
            tableTours.Columns.Add("Stars");
            tableTours.Columns.Add("Nights");
            tableTours.Columns.Add("Cost");
            const string url = "http://www.1001tur.ru/cgi-bin/Client.cgi?tourSearchPage=1";
            var resultpage = HttpRequest.GetResponse(url, "act=search&Page=" + page + "&Country=" + Parametrs[country] + "&Curort=&Hotel=&Kat=&Food=&check1=0&TipRazm=2&Chld1=&Chld2=&NightOt=" + nightFrom + "&NightDo=" + nightTo + "&PriceOt=&PriceDo=&SDay=" + dateFrom.Day + "&SMonth=" + dateFrom.Month + "&SYear=" + dateFrom.Year + "&EDay=" + dateTo.Day + "&EMonth=" + dateTo.Month + "&EYear=" + dateTo.Year + "&SortBy=Price&ShowBy=3&MorePage=1&MorePageStop=1&ctours=0&from_city=" + Towns[townFrom] + "&is_ski=&sortfilter=price&simpleSearch=0", "POST");
            resultpage = resultpage.Replace("   ", " ");
            const string patternNameUrl = @"(<div class=""sr_val1_sub1""><!--googleoff: all--><a href="")(http\://[a-zA-Z0-9\-\.]+\.[a-zA-Z]{2,3}(/\S*)?)("" target=""_blank"" rel=""nofollow"">)([^<]*)(</a><!--googleon: all--></div>)";
            const string patternStars = @"(<span class=""sr_hotelscat"">)(\d*)([*]+)(\*</span><span class=""sr_stars""></span>)";
            const string patternNights = @"(<span class=""sr_night"">)(\d*)(</span> ночей)";
            const string patternCost = @"(<span class=""actualization_price"">)(\d*)(&nbsp;)(\d*)(</span> руб</a>)";
            const string patternDate = @"(<td class=""sr_val3""><div class=""sr_val3_sub1"">)(\d*).(\d*)(</div></td>)";
            MatchCollection nameAndUrlMatches = Regex.Matches(resultpage, patternNameUrl);
            MatchCollection starsMatches = Regex.Matches(resultpage, patternStars);
            MatchCollection nightsMatches = Regex.Matches(resultpage, patternNights);
            MatchCollection costsMatches = Regex.Matches(resultpage, patternCost);
            MatchCollection dateMatches = Regex.Matches(resultpage, patternDate);
            for (int mtch = 0; mtch < nameAndUrlMatches.Count; mtch++)
            {
                tableTours.Rows.Add(nameAndUrlMatches[mtch].Groups[5].Value, starsMatches[mtch].Groups[2].Value, nightsMatches[mtch].Groups[2].Value, costsMatches[mtch].Groups[2].Value + costsMatches[mtch].Groups[4].Value, nameAndUrlMatches[mtch].Groups[2].Value, dateMatches[mtch].Groups[2], country);
            }
            return tableTours;
        }
        public static string GetCity(string city)
        {
            return "" + Towns[city];
        }
        public static DataTable GetAllToursFromBd(int money = 0)
        {
            var table = money == 0 ? Db.Select("*", "tours", "id", "desc") : Db.Select("*", "tours", "", "", "price<='" + money + "'");
            return table;
        }

        public static string[] GetCities()
        {
            Towns.Clear();
            const string url = "http://www.1001tur.ru/searest.htm";
            var page = HttpRequest.GetResponse(url, "", "GET");
            var pattern = @"(<select name=""from_city"" class=""sfs_fake_chouse_select jq_fake_chouse_select"">)([\s\S]*)(\t{4}</select>)";
            var regex = new Regex(pattern);
            var match = regex.Match(page);
            var cities = match.Groups[2].Value;
            pattern = @"(<OPTION value="")([0-9]{1,6})("" class=""""(?: >| SELECTED>))(\D*)(</OPTION>)";
            regex = new Regex(pattern);
            match = regex.Match(cities);
            while (match.Success)
            {
                Towns.Add(match.Groups[4].Value, Convert.ToInt16(match.Groups[2]));
                match = match.NextMatch();
            }
            var result = new string[Towns.Keys.Count];
            Towns.Keys.CopyTo(result, 0);
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
        /// <summary>
        /// Происходит при выборе города
        /// </summary>
        /// <param name="town">Название города, который выбрали</param>
        /// <returns></returns>
        public static Dictionary<string, int> JsonParsingCountries(string town)
        {
            var id = Towns[town];
            var json = HttpRequest.GetResponse("http://www.1001tur.ru/cgi-bin/get_countries.pl?from_city=" + id + "&json=1", "", "GET");
            if (json == null)
            {
                return null;
            }
            var country = JsonConvert.DeserializeObject<Country[]>(json);
            Parametrs.Clear();
            foreach (var countries in country)
            {
                Parametrs.Add(countries.Name, countries.Value);
            }

            return Parametrs;
        }
        public static void UpdateTour(int id, int price, DateTime date, string description, string hotel, int stars, string url, string country)
        {
            var vars = ToursValues(price, date, description, hotel, stars, url, country);
            Db.Update("tours", vars, id);
        }
        public static void AddTour(int price, DateTime date, string description, string hotel, int stars, string url, string country)
        {
            var vars = ToursValues(price, date, description, hotel, stars, url, country);
            Db.Insert("tours", vars);
        }
        private static Dictionary<string, object> ToursValues(int price, DateTime date, string description, string hotel, int stars, string url, string country)
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
        public static void DelTour(int id)
        {
            Db.Delete("tours", id);
        }
    }
}
