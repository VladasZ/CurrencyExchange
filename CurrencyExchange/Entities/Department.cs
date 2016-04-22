using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.Entities
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Address { get; set; }
        public TimeSpan OpenTime { get; set; }
        public TimeSpan CloseTime { get; set; }
        public Bank Bank { get; set; }
    }
}
