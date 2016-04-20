using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.Entities
{
    public class CurrencyDbContext// : DbContext
    {
        public CurrencyDbContext()
        {

        }

        public DbSet<Bank> Banks { get; set; }
        public DbSet<ExchangeRecord> ExchangeRecords { get; set; }

    }
}
