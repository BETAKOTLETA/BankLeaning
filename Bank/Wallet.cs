using Bank;
using Bank.Utilities;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class BankAccount 
{

    private double balance;
    protected string? password; // I could hash it but i'm too lazy i will do it Later
    private TransactionManager transactionManager;
    private PasswordVerifier passwordVerifier;
    private bool isLocked;

    public BankAccount()
    {
        balance = 0.0;
        password = null;
        isLocked = false;
        transactionManager = new TransactionManager(this);
        passwordVerifier = new PasswordVerifier(password ?? string.Empty, this);
    }

    protected internal void AddToBalance(double amount)
    {
        balance += amount;
    }
    protected internal void DeductFromBalance(double amount)
    {
        balance -= amount;
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
            passwordVerifier = new PasswordVerifier(password, this);
            //Password is created
        }
    }

    public bool Verification(string? inputPassword)
    {
        return passwordVerifier.Verify(inputPassword); 
    }

    public void LockTheAccount(string? inputPassword)
    {
        if (passwordVerifier.Verify(inputPassword)) isLocked = true;
    }

    public bool IsLocked()
    {
        return isLocked;
    }
}