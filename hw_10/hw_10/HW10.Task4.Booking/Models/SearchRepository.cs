using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW10.Task4.Booking.Models
{
    class SearchRepository
    {
        internal static  Dictionary<Account, Search> Repos { get; set; } = new Dictionary<Account, Search>();
    }
}
