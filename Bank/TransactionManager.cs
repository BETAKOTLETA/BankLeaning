using Bank.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            ValidateTransaction(amount, inputpassword, false);

            _account.AddToBalance(amount);
        }
        public void WithdrawFundsToAccount(double amount, string? inputpassword)
        {
            ValidateTransaction(amount, inputpassword, true);

            _account.DeductFromBalance(amount);
        }

        public void ValidateTransaction(double amount, string? inputpassword, bool isWithdrawal)
        {
            var errors = new List<string>();

            if (!WalletUtils.IsAPositive(amount))
            {
                errors.Add("Amount must be positive.");
            }

            if (isWithdrawal && _account.GetBalance() < amount)
            {
                errors.Add("Not enough money.");
            }

            if (!_account.Verification(inputpassword))
            {
                errors.Add("Password verification failed.");
            }
            if (_account.IsLocked())
            {
                errors.Add("Account is locked.");
            }
            if (errors.Count > 0)
            {
                throw new InvalidOperationException(string.Join(" ", errors));
            }
        }
    }
}
