using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW10.Task4.Booking.Models
{
    public class AccountService
    {
        public static Account Add (ref Account account)
        {
            AccountRepository.Repos.Add(account);
            return account;
        }

        public static void Remove (Guid id)
        {
            var collectAccount = AccountRepository.Repos;
            for (int i = 0; i < collectAccount.Count; i++)
            {
                if (id == collectAccount[i].Id)
                 {
                    collectAccount[i] = null;
                 }
            }
        }

        public static Account AccountSearch (string login, string password, out bool isCorrectPwd, out bool isLoginExisted)
        {
            bool IsCorrectPwd = false;
            bool IsLoginExisted=false;
            int index=0;
            var collectAccount = AccountRepository.Repos;
            for (int i = 0; i < collectAccount.Count; i++)
            {
                if (login == collectAccount[i].Login )
                {
                    IsLoginExisted = true;
                }
                else if (password == collectAccount[i].Password)
                {
                    IsCorrectPwd = true; 
                    index = i;
                }
            }
            isCorrectPwd = IsCorrectPwd;
            isLoginExisted=IsLoginExisted;
            if (IsLoginExisted && IsCorrectPwd)
            {
                return collectAccount[index];
            }
            return null;
        }
    }
}
