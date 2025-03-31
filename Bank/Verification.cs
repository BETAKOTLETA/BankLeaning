using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class PasswordVerifier
    {
        private readonly string _password;
        private readonly BankAccount _account;

        public PasswordVerifier(string password, BankAccount account)
        {
            _password = password;
            _account = account;
        }

        internal bool Verify(string? inputPassword)
        {
            var errors = new List<string>();

            if (_password == null)
            {
                errors.Add("Please create a password.");
                return false;
            }

            if (inputPassword == _password)
            {
                return true;
            }
            else
            {
                errors.Add("Incorrect password.");
                return false;
            }
        }
    }
}
