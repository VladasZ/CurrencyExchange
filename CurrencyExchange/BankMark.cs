using GMap.NET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange
{
    public class BankMark
    {
        public string Title { get; set; }
        public PointLatLng location { get; set; }
        public int Sell { get; set; }
        public int Buy { get; set; }
    }
}
