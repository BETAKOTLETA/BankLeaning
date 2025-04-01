using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Bank.Utilities
{
    public static class WalletUtils
    {
        public static bool IsAPositive(double value) { 
            return value > 0; }

        public static bool VerifyPassword(string inputPassword, string _password)
        {
            if (_password == null)
            {
                //_errors.Add("Please create a password.");
                return false;
            }

            if (inputPassword == _password)
            {
                return true;
            }
            else
            {
                //_errors.Add("Incorrect password.");
                return false;
            }
        }

        public static bool VerifyAmount(double amount, bool isWithdrawal, BankAccount _account)
        {
            if (!WalletUtils.IsAPositive(amount))
            {
                //_errors.Add("Amount must be positive.");
                return false;
            }

            if (isWithdrawal && _account.GetBalance() < amount)
            {
                //_errors.Add("Not enough money.");
                return false;
            }

            return true;
        }

        public static bool VerifyAccount(BankAccount _account)
        {


            if (_account.IsLocked())
            {
                //_errors.Add("Account is locked.");
                return false;
            }

            return true;
        }
    }
}