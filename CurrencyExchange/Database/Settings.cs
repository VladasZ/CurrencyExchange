using CurrencyExchange.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.Database
{
    public class Settings
    {
        public bool AllBanks { get; set; }
        public bool Profitable { get; set; }
        public bool Sell { get; set; }
        public Currency Currency { get; set; }
    }
}
