using GMap.NET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange
{

    public class PlaceInfo
    {
        public object[] html_attributions { get; set; }
        public Result result { get; set; }
        public string status { get; set; }
    }

    public class Result
    {
        public Address_Components[] address_components { get; set; }
        public string adr_address { get; set; }
        public string formatted_address { get; set; }
        public string formatted_phone_number { get; set; }
        public Geometry geometry { get; set; }
        public string icon { get; set; }
        public string id { get; set; }
        public string international_phone_number { get; set; }
        public string name { get; set; }
        public Opening_Hours opening_hours { get; set; }
        public PlacePhoto[] photos { get; set; }
        public string place_id { get; set; }
        public string reference { get; set; }
        public Review[] reviews { get; set; }
        public string scope { get; set; }
        public string[] types { get; set; }
        public string url { get; set; }
        public int user_ratings_total { get; set; }
        public int utc_offset { get; set; }
        public string vicinity { get; set; }
        public string website { get; set; }
    }

    public class Geometry
    {
        public Location location { get; set; }
    }

    public class Location
    {
        public float lat { get; set; }
        public float lng { get; set; }

        public PointLatLng toPointLatLng()
        {
            return new PointLatLng(lat, lng);
        }
    }

    public class Opening_Hours
    {
        public bool open_now { get; set; }
        public Period[] periods { get; set; }
        public string[] weekday_text { get; set; }
    }

    public class Period
    {
        public Close close { get; set; }
        public Open open { get; set; }
    }

    public class Close
    {
        public int day { get; set; }
        public string time { get; set; }
    }

    public class Open
    {
        public int day { get; set; }
        public string time { get; set; }
    }

    public class Address_Components
    {
        public string long_name { get; set; }
        public string short_name { get; set; }
        public string[] types { get; set; }
    }

    public class PlacePhoto
    {
        public int height { get; set; }
        public string[] html_attributions { get; set; }
        public string photo_reference { get; set; }
        public int width { get; set; }
    }

    public class Review
    {
        public Aspect[] aspects { get; set; }
        public string author_name { get; set; }
        public string author_url { get; set; }
        public string language { get; set; }
        public string profile_photo_url { get; set; }
        public int rating { get; set; }
        public string text { get; set; }
        public int time { get; set; }
    }

    public class Aspect
    {
        public int rating { get; set; }
        public string type { get; set; }
    }

}
