using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW10.Task4.Booking.Models
{
    public class AccountRepository
    {
        internal static List<Account> Repos { get; set; } = new List<Account>(25);
    }
}
