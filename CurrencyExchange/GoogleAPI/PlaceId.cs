using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange
{

    public class PlaceIdRoot
    {
        public object[] html_attributions { get; set; }
        public PlaceIdResult[] results { get; set; }
        public string status { get; set; }
    }

    public class PlaceIdResult
    {
        public Geometry geometry { get; set; }
        public string id { get; set; }
        public string place_id { get; set; }
        public string reference { get; set; }
    }


}
