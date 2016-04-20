using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.Entities
{
    public class ExchangeRecord
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public Bank Bank { get; set; }
        public Currency USD { get; set; }
        public Currency EUR { get; set; }
        public Currency RUR { get; set; }
    }
}
