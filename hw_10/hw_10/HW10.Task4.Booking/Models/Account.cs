using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace HW10.Task4.Booking.Models
{
    public class Account
    {
        internal protected string Login { get; set; }

        internal protected string Password { get; set; }

        internal protected Guid Id { get; set; }

        internal protected string UserName { get; set; } = "Underfined";

        internal protected string Age { get; set; }

        internal protected string AdditionalInfo { get; set; }

        internal protected string PaymentMethod { get; set; }

        internal protected MailAddress UserEmail { get; set; } =  new MailAddress("", "");

        public Account()
        { }

        public Account(string login, string password, string username, MailAddress useremail)
        { }

        public void PerformPay()
        { }
    }
}
