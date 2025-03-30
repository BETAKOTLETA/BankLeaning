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

        public PasswordVerifier(string password)
        {
            _password = password;
        }
        public static bool Verify(string? password, string? inputPassword)
        {
            if (password == null)
            {
                Console.WriteLine("Please Create A password");
                return false;
            }
            if (inputPassword == password)
            {
                Console.WriteLine("Password is correct!");
                return true;
            }
            else
            {
                Console.WriteLine("Incorrect password.");
                return false;
            }
        }
    }
}
