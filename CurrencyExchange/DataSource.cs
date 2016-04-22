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
                case 18: return "Сберегательный Банк Беларусбанк";
                case 19: return "СОМБелБанк";
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
            return @"https://maps.googleapis.com/maps/api/place/nearbysearch/json?location=" + userPosition.Lat + "," + userPosition.Lng +
                    "&radius=" + radius +
                    "&types=bank&name=" + bankName + 
                    "&key=" + GoogleAPIKey;
        }

        public static string createGoogleApiRequest(PointLatLng userPosition, int radius)
        {
            return @"https://maps.googleapis.com/maps/api/place/nearbysearch/json?location=" 
                    + userPosition.Lat.ToGBString() + "," + userPosition.Lng.ToGBString() +
                    "&radius=" + radius +
                    "&types=bank&key=" + GoogleAPIKey;
        }

        public static GoogleAPIRootObject getData(PointLatLng userPosition, int radius)
        {
            string jsonData;

            using (WebClient client = new WebClient())
            {
                client.Encoding = Encoding.UTF8;
                jsonData = client.DownloadString(createGoogleApiRequest(userPosition, radius));
            }

            return JsonConvert.DeserializeObject<GoogleAPIRootObject>(jsonData);
        }

        static void Main(string[] args)
        {
           GoogleAPIRootObject rootObject = getData(new PointLatLng(53, 27), 50000);


           foreach(Result result in rootObject.results)
            {
                Console.WriteLine(result.name);
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
