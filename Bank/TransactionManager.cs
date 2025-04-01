using Bank.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;


namespace Bank
{
    public class TransactionManager
    {
        private readonly BankAccount _account;

        public TransactionManager(BankAccount account) {
            _account = account ?? throw new ArgumentNullException(nameof(account));
        }

        public void DepositFundsToAccount(double amount, string? inputpassword)
        {
            if (inputpassword == null || !ValidateTransaction(amount, inputpassword, false))
            {
                return;
            }
            _account.AddToBalance(amount);
            _account.AddTransaction(new Transaction(amount, "Deposit"));
        }

        public void WithdrawFundsToAccount(double amount, string? inputpassword)
        {
            if (inputpassword == null || !ValidateTransaction(amount, inputpassword, true))
            {
                return;
            }

            _account.DeductFromBalance(amount);
            _account.AddTransaction(new Transaction(amount, "Withdrawal"));
        }

        public bool ValidateTransaction(double amount, string? inputpassword, bool isWithdrawal)
        {
            if (inputpassword == null) return false;
            var accountPassword = _account.GetPassword();
            if (accountPassword == null) return false;
            if (!WalletUtils.VerifyPassword(inputpassword, accountPassword)) return false;
            if (!WalletUtils.VerifyAmount(amount, isWithdrawal, _account)) return false;
            if (!WalletUtils.VerifyAccount(_account)) return false;
            else return true;
        }
    }
}
