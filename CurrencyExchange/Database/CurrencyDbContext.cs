using CurrencyExchange.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange
{
    public class CurrencyDbContext : DbContext
    {
        public CurrencyDbContext() : base(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CurrencyExchange2;Integrated Security=True;MultipleActiveResultSets=true")
        {
           
        }

        public DbSet<Bank> Banks { get; set; }
        public DbSet<BankDepartment> Departments { get; set; }
        public DbSet<ExchangeRecord> ExchangeRecords { get; set; }
        public DbSet<Currency> Currencies { get; set; }

    }

    //// Migrations are considered configured for MyDbContext because this class implementation exists.
    //internal sealed class Configuration : DbMigrationsConfiguration<CurrencyDbContext>
    //{
    //    public Configuration()
    //    {
    //        AutomaticMigrationsEnabled = false;
    //    }
    //}

    //// Declaring (and elsewhere registering) this DB initializer of type MyDbContext - but a DbMigrationsConfiguration already exists for that type.
    //public class TestDatabaseInitializer : DropCreateDatabaseAlways<CurrencyDbContext>
    //{
    //    protected override void Seed(CurrencyDbContext context) { }
    //}
}
