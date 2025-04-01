using Bank;
using Bank.Utilities;
using System.Transactions;
using static System.Runtime.InteropServices.JavaScript.JSType;
using BankTransactionManager = Bank.TransactionManager;
using BankTransaction = Bank;


public class BankAccount 
{

    private double balance;
    private string? password; // I could hash it but i'm too lazy i will do it Later
    private BankTransactionManager transactionManager;
    private bool isLocked;
    private readonly List<ITransaction> _transactions = new();
    public bool IsActive { get; private set; }

    public event Action<int> OnDeactivation;    
        
    public BankAccount()
    { 
        transactionManager = new BankTransactionManager(this);
    }

    protected internal void AddToBalance(double amount)
    {
        balance += amount;
    }
    protected internal void DeductFromBalance(double amount)
    {
        balance -= amount;
    }
    public void AddTransaction(ITransaction transaction)
    {
        _transactions.Add(transaction);
    }
    public IEnumerable<ITransaction> GetTransactionHistory()
    {
        return _transactions;
    }

    public void Deposit(double amount, string? inputpassword)
    {
        transactionManager.DepositFundsToAccount(amount, inputpassword);
    }

    public void Withdraw(double amount, string? inputpassword)
    {
        transactionManager.WithdrawFundsToAccount(amount, inputpassword);
    }

    public double GetBalance() => balance;


    public void SetPassword(string inputPassword)
    {
        if (password == null)
        {
            password = inputPassword;
        }
    }
    public string? GetPassword() => password;


    public void LockTheAccount(string? inputPassword)
    {
        if (inputPassword != null)
        {
            if (WalletUtils.VerifyPassword(inputPassword, password)) isLocked = true;
        }
    }


    public bool IsLocked()
    {
        return isLocked;
    }

    private void Reactivate()
    {
        IsActive = true;
    }

}