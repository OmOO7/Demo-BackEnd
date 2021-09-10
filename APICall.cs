using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIDemo
{
    public class APICall
    {
        //readonly static string url = "http://hapidemo.etglobe.com/";
        readonly static string url = "your website";
        public static string SearchHotels(string data)
        {
            return APIRequest.addData(url + "v1/SearchHotels", data);
        }

        public static string GetHotelsRooms(string data)
        {
            return APIRequest.addData(url + "v1/GetHotelsRooms", data);
        }
    }
}