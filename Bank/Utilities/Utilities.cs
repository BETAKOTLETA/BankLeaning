using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Bank.Utilities
{
    public static class WalletUtils
    {
        public static bool IsAPositive(double value) => value>0;
    }
}