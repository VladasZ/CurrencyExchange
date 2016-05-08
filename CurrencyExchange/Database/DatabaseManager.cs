
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

            Console.WriteLine(placesId.Count + " placesId count");

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

        public static Bank addNewBank(string bankName)
        {
            Bank newBank = findBank(bankName);

            if (newBank == null)
            {
                newBank = new Bank()
                {
                    Name = bankName,
                    ObmennikById = DataSource.obmennikByBankId.FirstOrDefault(bank => bank.Value == bankName).Key
                };

                db.Banks.Add(newBank);
            }

            db.SaveChanges();

            return newBank;
        }

        public static void addNewDepartment(string placeId)
        {
            BankDepartment newDepartment = findDepartment(placeId);

            //не добавляем отделения повторно
            if (newDepartment != null) return;

            PlaceInfo departmentInfo = DataSource.getPlaceInfo(placeId);

            if (departmentInfo.result == null) return;

            string bankName = getBankName(departmentInfo.result.name);

            //не добавляем в базу неизвестные нам банки
            if (bankName.Contains("unknown")) return;

            Bank bank = findBank(bankName);

            if (bank == null)
            {
                bank = addNewBank(bankName);
            }

            newDepartment = new BankDepartment()
            {
                GoogleId = placeId,
                Name = departmentInfo.result.name,
                LocationLat = departmentInfo.result.geometry.location.lat,
                LocationLng = departmentInfo.result.geometry.location.lng,
                Bank = bank
            };


            db.Departments.Add(newDepartment);
            bank.Departments.Add(newDepartment);

            db.SaveChanges();
        }

        public static BankDepartment findDepartment(string placeGoogleId)
        {
            if (db.Departments.Count() == 0) return null;

            return (from dep in db.Departments
                    where dep.GoogleId == placeGoogleId
                    select dep).FirstOrDefault();
                   
        }

        public static Bank findBank(string bankName)
        {
            if (db.Banks.Count() == 0) return null;

            return (from bank in db.Banks
                    where bank.Name == bankName
                    select bank).FirstOrDefault();
        }

        public static ExchangeRecord findExchangeRecord(Bank bank, DateTime dateTime)
        {
            if (db.ExchangeRecords.Count() == 0) return null;

            ////обновляем базу валют если сегодня этого еще не было сделано
            //DateTime today = DateTime.Now.Date;

            //if(db.ExchangeRecords.FirstOrDefault(rec => rec.Date == today) == null)
            //{
            //    DataSource.loadCurrencyData();
            //}

            return (from record in db.ExchangeRecords.Include("Bank")
                    where record.Bank.Id == bank.Id && record.Date == dateTime
                    select record).FirstOrDefault();
        }
        
        public static List<BankMark> getBankDepartmentsMarks(PointLatLng userLocation, int radius)
        {
            List<BankMark> marks = new List<BankMark>();


            foreach(BankDepartment department in db.Departments.Include("Bank"))
            {
                if (distance(department.getPointLatLng(), userLocation) > radius) continue;

                ExchangeRecord record = findExchangeRecord(department.Bank, DateTime.Now.Date);

                if (record == null) continue;

                marks.Add(new BankMark()
                {
                    Title = department.Bank.Name + "\n            Покупка Продажа\n" + 
                    "USD      " + record.USD.Buy + "     " + record.USD.Sell + "\n" +
                    "EUR      " + record.EUR.Buy + "     " + record.EUR.Sell + "\n"
                    ,
                    Location = new PointLatLng(department.LocationLat, department.LocationLng)
                });
            }

            return marks;
        }

        public static void eraseDatabase()
        {
            foreach (BankDepartment bank in db.Departments)
                db.Departments.Remove(bank);

            foreach (Bank bank in db.Banks)
                db.Banks.Remove(bank);

            foreach (ExchangeRecord record in db.ExchangeRecords)
                db.ExchangeRecords.Remove(record);

            db.SaveChanges();
        }

        public static void dataDump()
        {
            foreach (Bank bank in db.Banks)
                Console.WriteLine(bank.Name + " " + bank.ObmennikById);

            foreach(BankDepartment department in db.Departments)
                Console.WriteLine(department.Name + " " + department.Bank.Name + " " + department.LocationLat);

            foreach(ExchangeRecord record in db.ExchangeRecords)
                Console.WriteLine(record.Bank.Name + " " + record.USD.Buy + " " + record.Date);
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

            if (departmentName.Contains("Belarus") ||
               departmentName.Contains("Беларус"))
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
               departmentName.Contains("осква") ||
               departmentName.Contains("асква"))
                return "Банк Москва-Минск";

            if (departmentName.Contains("Prior") ||
               departmentName.Contains("Приор"))
                return "Приорбанк";

            if (departmentName.Contains("BPS") ||
               departmentName.Contains("БПС") ||
               departmentName.Contains("Бпс"))
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
                departmentName.Contains("БелСвисс") ||
                departmentName.Contains("Белсвисс"))
                return "БелСвиссБанк";

            if (departmentName.Contains("BTA"))
                return "БТА Банк";

            if (departmentName.Contains("Паритет") ||
                departmentName.Contains("Paritet"))
                return "Паритетбанк";

            if (departmentName.Contains("Белросбанк") ||
                departmentName.Contains("Белрусбанк"))
                return "Белросбанк";

            if (departmentName.Contains("VTB") ||
                departmentName.Contains("ВТБ"))
                return "Банк ВТБ";

            if (departmentName.Contains("Хоум"))
                return "Хоум Кредит Банк";

            if (departmentName.Contains("Абсолют"))
                return "Абсолютбанк";

            if (departmentName.Contains("Техно"))
                return "Технобанк";

            if (departmentName.Contains("Франса") ||
                departmentName.Contains("Fransa"))
                return "Франсабанк";

            return departmentName + " #unknown";
        }

        //google
        public static int distance(PointLatLng point1, PointLatLng point2)
        {
            double R = 6371; // km
            double dLat = toRad(point2.Lat - point1.Lat);
            double dLon = toRad(point2.Lng - point1.Lng);
            point1.Lat = toRad(point1.Lat);
            point2.Lat = toRad(point2.Lat);

            double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                    Math.Sin(dLon / 2) * Math.Sin(dLon / 2) * Math.Cos(point1.Lat) * Math.Cos(point2.Lat);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            double result = R * c * 1000;
            return (int)result;
        }

        public static double toRad(double a)
        {
            return a * Math.PI / 180;
        }
    }
}
