using CurrencyExchange.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange
{
    public class CurrencyDbContext : DbContext
    {
        public CurrencyDbContext() : base(ConfigurationManager.AppSettings["ConnectionString"])
        {
           
        }

        public DbSet<Bank> Banks { get; set; }
        public DbSet<BankDepartment> Departments { get; set; }
        public DbSet<ExchangeRecord> ExchangeRecords { get; set; }
        public DbSet<Currency> Currencies { get; set; }

    }

}
