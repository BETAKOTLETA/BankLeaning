using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Utilities
{
    public static class WalletUtils
    {
        public static bool IsAPositive(double value)
        {
            if (value <= 0)
            {
                Console.WriteLine("Value should be positive.");
                return false;
            }
            return true;
        }

    }
}