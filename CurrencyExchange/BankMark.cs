using GMap.NET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange
{
    //класс передающий информацию для карты
    public class BankMark
    {
        public string Title { get; set; }
        public PointLatLng Location { get; set; }
        public int Sell { get; set; }
        public int Buy { get; set; }
    }
}
