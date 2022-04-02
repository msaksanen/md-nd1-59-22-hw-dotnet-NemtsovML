using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
//using Json.Net;
using System.Text;
using System.Threading.Tasks;

namespace HW10.Task4.Booking.Models
{
    class Session
    {
        public string IPAddr { get; set; }
        public string Lang { get; set; }

        public string Currency { get; set; }

        public Account MakeNewAccount(ref Account accountname)
        {
            accountname = new Account();
            return accountname;
        }

        //public Search MakeNewSearch(ref Search newsearch)
        //{
        //    newsearch = new Search();
        //    return newsearch;
        //}

        //public Order MakeNewOrder(ref Order neworder)
        //{
        //    neworder = new Order();
        //    return neworder;
        //}

       internal protected Account Logon(ref Account Myaccount, string login, string password)
        {
             Myaccount = new Account();
            //Perform seacrh in database
            //If algo finds login and password in db then
            //Myaccount=db_account;
            Console.WriteLine("Logging on..");
            return Myaccount;

        }

       internal protected void GetIpValue(out string ipAddr) 
        {
            ////https://www.c-sharpcorner.com/article/get-ip-address-in-Asp-Net/
            //    ipAddr = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            //    if (string.IsNullOrEmpty(ipAddr))
            //    {
            //        ipAddr = Request.ServerVariables["REMOTE_ADDR"];
            //    }
            //    else
            //    {
            //        lblIPAddress.Text = ipAddr;
            //    }
            ipAddr= "218.51.71.190";
        }

        public void CityStateCountByIp(string IP, out string countrycode, out string country, out string city)
        {  
            ///https://stackoverflow.com/questions/4327629/get-user-location-by-ip-address
            ////var url = "http://freegeoip.net/json/" + IP;
            ////var url = "http://freegeoip.net/json/" + IP;
            //string url = "http://api.ipstack.com/" + IP + "?access_key=[KEY]";
            //var request = System.Net.WebRequest.Create(url);

            //using (WebResponse wrs = request.GetResponse())
            //{
            //    using (Stream stream = wrs.GetResponseStream())
            //    {
            //        using (System.IO.StreamReader reader = new StreamReader(stream))
            //        {
            //            string json = reader.ReadToEnd();
            //            var obj = JObject.Parse(json);
            //            string City = (string)obj["city"];
            //            string Country = (string)obj["region_name"];
            //            string CountryCode = (string)obj["country_code"];
            //            country = Country;
            //            countrycode = CountryCode;
            //            city = City;       
            //        }
            //    }
            //}
            country = "Belarus" ;
            countrycode = "BY";
            city = "Vitebsk";
        }
    }
}
