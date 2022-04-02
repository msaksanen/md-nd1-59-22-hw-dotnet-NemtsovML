using HW10.Task4.Booking.Models;
using System;
using System.Globalization;

namespace HW10.Task4.Booking
{
    class Program
    {
        static void Main()
        {
            Session session = new Session();
            session.GetIpValue(out string ipaddr);
            session.IPAddr = ipaddr;

            session.CityStateCountByIp(session.IPAddr, out string countrycode, out string country, out string city);
                      
            RegionInfo myReg = new RegionInfo(countrycode);
            string currency=myReg.ISOCurrencySymbol;
            session.Currency = currency;

            string login = "rerereft";
            string password = "yb243yg36g5";
            Account myAccount = default;
            myAccount=session.Logon(ref myAccount, login, password);

            Search mySearch = new Search();
            //mySearch = session.MakeNewSearch(ref mySearch);

            mySearch.Checkin = new DateTime(2022, 7, 20);
            mySearch.Checkout = new DateTime(2022, 8, 10);
            mySearch.Destination = "London";

            mySearch.AdultsNumber = 2;
            mySearch.ChildNumber = 1;
            mySearch.WorkTravel = false;

            mySearch.StartSearch();

            mySearch.HouseApartmentFirst = 1;
            mySearch.SortSearch();

            mySearch.StarsRating = 4;
            mySearch.AdditionalCriteriaSearch();

            Order myOrder = new Order();
            //myOrder = session.MakeNewOrder(ref myOrder);
            myOrder.Booking(mySearch, myAccount);
            myOrder.Purchasing(mySearch, myAccount);

            Console.ReadKey();
        }
    }
}
