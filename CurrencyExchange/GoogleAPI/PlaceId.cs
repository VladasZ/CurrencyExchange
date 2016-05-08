using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange
{
    //апишка сразу может выдавать полные данные о местах но только по 20 штук за раз
    //этот класс это id мест которых можно получать по 200 штук за раз и потом из них получать данные
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
