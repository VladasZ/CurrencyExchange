using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.Entities
{
    class ExchangeRecord
    {
        public int Id { get; set; }
        public Currency Currency { get; set; }
        public DateTime Date { get; set; }
        public Bank Bank { get; set; }
        public double Sell { get; set; }
        public double Buy { get; set; }
    }
}
