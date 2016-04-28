using CurrencyExchange.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Data.Entity;
using System.Configuration;
using GMap.NET;
using System.Net;
using Newtonsoft.Json;
using System.Globalization;
using CurrencyExchange.Database;

namespace CurrencyExchange
{
    public static class DataSource
    {
        static DataSource()
        {
            //DbContext.Currencies.AddRange(new List<Currency>() { new Currency() { Id = 0, Name = "USD" },
            //                                                     new Currency() { Id = 1, Name = "EUR" },
            //                                                     new Currency() { Id = 2, Name = "RUR" } });

            //DbContext.Banks.AddRange(new List<Bank>() {  new Bank() { Id = 0,
            //                                                          Name = "Идея Банк",
            //                                                          Address = "г.Минск, ул. З.Бядули, д. 11",
            //                                                          OpenTime = new TimeSpan(10, 00, 00),
            //                                                          CloseTime = new TimeSpan(19, 00, 00) }});
            
        }

        public static CurrencyDbContext DbContext { get; } = new CurrencyDbContext();

        private static string CurrencySourceXMLPath = @"http://www.obmennik.by/xml/kurs.xml";
        private static string GoogleAPIKey = @"AIzaSyDo_63nP_vhZS53MftWlqoIhJX7bTToPA0";

        private static void loadCurrencyData()
        {
            XDocument doc = XDocument.Load(CurrencySourceXMLPath);

            IEnumerable<XElement> banks = doc.Element("banks").Elements();

            foreach(XElement bank in banks)
            {
                DbContext.ExchangeRecords.Add(
                    new ExchangeRecord()
                    {
                        //Bank = (Bank)DbContext.Banks.Select(b => b.Id == int.Parse(bank.Element("idbank").Value)).FirstOrDefault()
                    });

                
               
                Console.WriteLine(" " + getBankName(bank.Element("idbank").Value) + " " +
                     bank.Element("usd").Element("sell").Value + " " + bank.Element("usd").Element("buy").Value) ;
            }



        }

        public static string getBankName(string bankId)
        {
            int _bankId = int.Parse(bankId);

            switch (_bankId)
            {
                case 1:  return "Абсолютбанк";
                case 2:  return "Альфа-Банк";
                case 3:  return "Банк ВТБ";
                case 4:  return "Белагропромбанк";
                case 5:  return "Белгазпромбанк";
                case 6:  return "Белинвестбанк";
                case 7:  return "Белорусский Банк Малого Бизнеса";
                case 8:  return "Белорусский Народный Банк";
                case 9:  return "БПС-Сбербанк";
                case 10: return "Белросбанк";
                case 11: return "БелСвиссБанк";
                case 12: return "БТА Банк";
                case 13: return "Евробанк";
                case 14: return "Международный резервный банк";
                case 15: return "МТБанк";
                case 16: return "Паритетбанк";
                case 17: return "Приорбанк";
                case 18: return "Беларусбанк";
                case 19: return "Идея Банк";
                case 20: return "Технобанк";
                case 21: return "Хоум Кредит Банк";
                case 22: return "Цептер Банк";
                case 23: return "Банк Москва-Минск";
                case 24: return "Трастбанк";
                case 25: return "БелВЭБ";
                case 26: return "Франсабанк";
                case 27: return "Дельта Банк";
                case 28: return "РРБ-Банк";
                case 29: return "Кредэксбанк";
                case 30: return "ТК Банк";
                case 31: return "Онербанк";
                case 32: return "Бит-Банк";
                case 34: return "Н.Е.Б. Банк";
                default: throw new FormatException("Invalid bank Id");
            }
        }

        public static string createGoogleApiRequest(PointLatLng userPosition, int radius, string bankName)
        {
            return @"https://maps.googleapis.com/maps/api/place/radarsearch/json?location=" + userPosition.Lat + "," + userPosition.Lng +
                    "&radius=" + radius +
                    "&types=bank&name=" + bankName + 
                    "&key=" + GoogleAPIKey;
        }

        public static string createGoogleApiRequest(PointLatLng userPosition, int radius)
        {
            return @"https://maps.googleapis.com/maps/api/place/radarsearch/json?location="
                    + userPosition.Lat.ToGBString() + "," + userPosition.Lng.ToGBString() +
                    "&radius=" + radius +
                    "&types=bank&key=" + GoogleAPIKey;
        }

        public static List<string> getPlacesID(PointLatLng userPosition, int radius)
        {
            string jsonData;

            using (WebClient client = new WebClient())
            {
                client.Encoding = Encoding.UTF8;
                jsonData = client.DownloadString(createGoogleApiRequest(userPosition, radius));
            }

            PlaceIdRoot placeIdRoot = JsonConvert.DeserializeObject<PlaceIdRoot>(jsonData);

            List<string> placesId = new List<string>();

            foreach(PlaceIdResult id in placeIdRoot.results)
            {
                placesId.Add(id.place_id);
            }

            return placesId;
        }

        public static PlaceInfo getPlaceInfo(string placeID)
        {
            string jsonData;
            string requestString = @"https://maps.googleapis.com/maps/api/place/details/json?placeid=" 
                                    + placeID + "&key=" + GoogleAPIKey;


            using (WebClient client = new WebClient())
            {
                client.Encoding = Encoding.UTF8;
                jsonData = client.DownloadString(requestString);
            }

            PlaceInfo placeInfo = JsonConvert.DeserializeObject<PlaceInfo>(jsonData);

            return placeInfo;
        }

        public static List<PlaceInfo> getPlacesInfo(List<string> placesId)
        {
            List<PlaceInfo> placesInfo = new List<PlaceInfo>();

            foreach(string placeId in placesId)
            {
                placesInfo.Add(getPlaceInfo(placeId));
            }

            return placesInfo;
        }

        public static List<string> getDefaultPlacesId()
        {
            return getPlacesID(new PointLatLng(53.9017, 27.56227), 50000);
        }

        static void Main(string[] args)
        {
            // DatabaseManager.getData();

            List<string> banks = (from bank in DatabaseManager.db.Departments
                                  select bank.Name).Distinct().ToList();

            List<string> banksNames = new List<string>();

            foreach(string bank in banks)
            {
                banksNames.Add(DatabaseManager.getBankName(bank));
            }

            banksNames = (from name in banksNames
                          select name).Distinct().ToList();

            foreach(string name in banksNames)
            {
                Console.WriteLine(name);
            }
        }

    }

    //нужен для строкового представления double с точкой как разделитель
    public static class DoubleExtensions
    {
        public static string ToGBString(this double value)
        {
            return value.ToString(CultureInfo.GetCultureInfo("en-GB"));
        }
    }
}
