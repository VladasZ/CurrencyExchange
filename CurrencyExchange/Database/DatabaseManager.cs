
using CurrencyExchange.Entities;
using GMap.NET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.Database
{
    public static class DatabaseManager
    {
        public static CurrencyDbContext db = new CurrencyDbContext();

        public static void getData()
        {
            List<string> placesId = DataSource.getDefaultPlacesId();

            //провереям есть ли такое отделение в нашей базе
            foreach(string placeId in placesId)
            {
                BankDepartment newDepartment = findDepartment(placeId);

                if (newDepartment == null)
                {
                    addNewDepartment(placeId);
                }
            }

            db.SaveChanges();
        }

        public static void addNewDepartment(string placeId)
        {
            PlaceInfo departmentInfo = DataSource.getPlaceInfo(placeId);

            BankDepartment newDepartment = new BankDepartment()
            {
                GoogleId = placeId,
                Name = departmentInfo.result.name
            };

            db.Departments.Add(newDepartment);
        }

        public static BankDepartment findDepartment(string placeId)
        {
            return (from dep in db.Departments
                    where dep.GoogleId == placeId
                    select dep).FirstOrDefault();
                   
        }

        public static string getBankName(string departmentName)
        {
            if (departmentName.Contains("Idea") || 
                departmentName.Contains("Идея"))
                return "Идея Банк";

            if (departmentName.Contains("Alfa") ||
                departmentName.Contains("Альфа"))
                return "Альфа-Банк";

            if (departmentName.Contains("Belagro") ||
                departmentName.Contains("Белагро"))
                return "Белагропромбанк";

            if (departmentName.Contains("Belarusbank") ||
               departmentName.Contains("Беларусбанк"))
                return "Беларусбанк";

            if (departmentName.Contains("Belgaz") ||
               departmentName.Contains("Белгаз"))
                return "Белгазпромбанк";

            if (departmentName.Contains("Belinvest") ||
               departmentName.Contains("Белинвест"))
                return "Белинвестбанк";

            if (departmentName.Contains("BNB") ||
                departmentName.Contains("БНБ") ||
               departmentName.Contains("ародный"))
                return "Белорусский Народный Банк";

            if (departmentName.Contains("oscow") ||
               departmentName.Contains("осква"))
                return "Банк Москва-Минск";

            if (departmentName.Contains("Prior") ||
               departmentName.Contains("Приор"))
                return "Приорбанк";

            if (departmentName.Contains("BPS") ||
               departmentName.Contains("БПС"))
                return "БПС-Сбербанк";

            if (departmentName.Contains("МТБ") ||
               departmentName.Contains("Мтб"))
                return "МТБанк";

            if (departmentName.Contains("Belvnesh") ||
               departmentName.Contains("БелВЭБ"))
                return "БелВЭБ";

            if (departmentName.Contains("BSB") ||
                departmentName.Contains("БСБ") ||
                departmentName.Contains("BelSwiss") ||
               departmentName.Contains("БелСвисс"))
                return "БелСвиссБанк";

            if (departmentName.Contains("BTA"))
                return "БТА Банк";

            if (departmentName.Contains("Паритет"))
                return "Паритетбанк";

            if (departmentName.Contains("Белросбанк"))
                return "Белросбанк";

            if (departmentName.Contains("VTB"))
                return "Банк ВТБ";

            if (departmentName.Contains("Хоум"))
                return "Хоум Кредит Банк";

            if (departmentName.Contains("Абсолют"))
                return "Абсолютбанк";

            if (departmentName.Contains("Техно"))
                return "Технобанк";

            if (departmentName.Contains("Франса"))
                return "Франсабанк";



            return "unknown";
        }
    }
}
