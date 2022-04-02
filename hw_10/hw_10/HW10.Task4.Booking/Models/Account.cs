using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace HW10.Task4.Booking.Models
{
    class Account
    {
        private protected string Login { get; set; }

        private protected string Password { get; set; }

        private protected string UserName { get; set; } = "Underfined";

        private protected string Age { get; set; }

        private protected string AdditionalInfo { get; set; }

        private protected string PaymentMethod { get; set; }

        private protected MailAddress UserEmail { get; set; } =  new MailAddress("", "");

        public Account()
        { }

        public Account(string login, string password, string username, MailAddress useremail)
        { }

        public void PerformPay()
        { }
    }
}
