using CurrencyExchange.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange
{
    public static class DataSource
    {
        static DataSource()
        {
            DbContext.Currencies.AddRange(new List<Currency>() { new Currency() { Id = 0, Name = "USD" },
                                                                 new Currency() { Id = 1, Name = "EUR" },
                                                                 new Currency() { Id = 2, Name = "RUR" } });

            DbContext.Banks.AddRange(new List<Bank>() {  new Bank() { Id = 0,
                                                                      Name = "Идея Банк",
                                                                      Address = "г.Минск, ул. З.Бядули, д. 11",
                                                                      OpenTime = new TimeSpan(10, 00, 00),
                                                                      CloseTime = new TimeSpan(19, 00, 00) }});
        }

        public static CurrencyDbContext DbContext { get; } = new CurrencyDbContext();


    }
}
