using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW10.Task4.Booking.Models
{
    class Search
    {
        public DateTime Checkin { get; set; } = new DateTime();
        public DateTime Checkout { get; set; } = new DateTime();
        public string Destination { get; set;}

        public int AdultsNumber { get; set; } = 1;

        public int ChildNumber { get; set; } = 0;

        public int RoomNumber { get; set; } = 1;

        public bool WorkTravel { get; set; } = false;

        public int RecommendedSort { get; set; } = 0;
        public int HouseApartmentFirst { get; set; } = 0;
        public int PriceSort { get; set; } = 0;

        public int StartsSortOrder { get; set; } = 0;

        public int YourBudget { get; set; } = 0;

        public int StarsRating { get; set; } = 0;

        public void StartSearch()
        { }
      
        public void SortSearch()
        { }

        public void AdditionalCriteriaSearch()
        { }

        public static void SearchAddDB(Account account, Search search)
        {
            SearchRepository.Repos.Add(account, search);
        }

    }
   

    class Order : Search
    {
        public void Booking(Search search, Account account)
        {

        }

        public void Purchasing(Search search, Account account)
        {
            account.PerformPay();
        }
    }
}
