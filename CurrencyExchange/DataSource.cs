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
            setObmennikByBankId();
        }

        public static CurrencyDbContext DbContext { get; } = new CurrencyDbContext();

        private static string CurrencySourceXMLPath = @"http://www.obmennik.by/xml/kurs.xml";
        private static string GoogleAPIKey = @"AIzaSyDo_63nP_vhZS53MftWlqoIhJX7bTToPA0";

        //айдишники банков для сайта obmennik.by
        public static Dictionary<int, string> obmennikByBankId = new Dictionary<int, string>();

        public static void loadCurrencyData()
        {
            //данные о курсах достаю в ручную потому что мне не понравилась структура с сайта
            XDocument doc = XDocument.Load(CurrencySourceXMLPath);

            IEnumerable<XElement> banks = doc.Element("banks").Elements();

            foreach(XElement bank in banks)
            {
                string bankName = obmennikByBankId[int.Parse(bank.Element("idbank").Value)];

                Bank dbBank = DatabaseManager.findBank(bankName);

                if (dbBank == null) continue;

                Currency usd = new Currency()
                {
                    Buy = double.Parse(bank.Element("usd").Element("buy").Value),
                    Sell = double.Parse(bank.Element("usd").Element("sell").Value)
                };

                Currency eur = new Currency()
                {
                    Buy = double.Parse(bank.Element("eur").Element("buy").Value),
                    Sell = double.Parse(bank.Element("eur").Element("sell").Value)
                };

                Currency rur = new Currency()
                {
                    Buy = 5,//double.Parse(bank.Element("rur").Element("buy").Value, NumberStyles.AllowDecimalPoint),
                    Sell = 5//double.Parse(bank.Element("rur").Element("sell").Value, NumberStyles.AllowDecimalPoint)
                };

                ExchangeRecord newRecord = DatabaseManager.findExchangeRecord(dbBank, DateTime.Now.Date);

                if (newRecord != null) continue;

                newRecord = new ExchangeRecord()
                {
                    Bank = dbBank,
                    Date = DateTime.Now.Date,
                    EUR = eur,
                    USD = usd,
                    RUR = rur
                };

                DatabaseManager.db.ExchangeRecords.Add(newRecord);  
            }

            DatabaseManager.db.SaveChanges();
            
        }

        public static void setObmennikByBankId()
        {
            //перенести в базу
               obmennikByBankId.Add(1, "Абсолютбанк");
               obmennikByBankId.Add(2, "Альфа-Банк");
               obmennikByBankId.Add(3, "Банк ВТБ");
               obmennikByBankId.Add(4, "Белагропромбанк");
               obmennikByBankId.Add(5, "Белгазпромбанк");
               obmennikByBankId.Add(6, "Белинвестбанк");
               obmennikByBankId.Add(7, "Белорусский Банк Малого Бизнеса");
               obmennikByBankId.Add(8, "Белорусский Народный Банк");
               obmennikByBankId.Add(9, "БПС-Сбербанк");
               obmennikByBankId.Add(10, "Белросбанк");
               obmennikByBankId.Add(11, "БелСвиссБанк");
               obmennikByBankId.Add(12, "БТА Банк");
               obmennikByBankId.Add(13, "Евробанк");
               obmennikByBankId.Add(14, "Международный резервный банк");
               obmennikByBankId.Add(15, "МТБанк");
               obmennikByBankId.Add(16, "Паритетбанк");
               obmennikByBankId.Add(17, "Приорбанк");
               obmennikByBankId.Add(18, "Беларусбанк");
               obmennikByBankId.Add(19, "Идея Банк");
               obmennikByBankId.Add(20, "Технобанк");
               obmennikByBankId.Add(21, "Хоум Кредит Банк");
               obmennikByBankId.Add(22, "Цептер Банк");
               obmennikByBankId.Add(23, "Банк Москва-Минск");
               obmennikByBankId.Add(24, "Трастбанк");
               obmennikByBankId.Add(25, "БелВЭБ");
               obmennikByBankId.Add(26, "Франсабанк");
               obmennikByBankId.Add(27, "Дельта Банк");
               obmennikByBankId.Add(28, "РРБ-Банк");
               obmennikByBankId.Add(29, "Кредэксбанк");
               obmennikByBankId.Add(30, "ТК Банк");
               obmennikByBankId.Add(31, "Онербанк");
               obmennikByBankId.Add(32, "Бит-Банк");
               obmennikByBankId.Add(34, "Н.Е.Б. Банк");
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
            loadCurrencyData();
            DatabaseManager.dataDump();
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
