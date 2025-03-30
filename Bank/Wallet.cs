using Bank;
using Bank.Utilities;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class BankAccount
{

    private double balance;

    private string? password;

    public BankAccount()
    {
        balance = 0.0;
        password = null;
    }

    public void DepositFunds(double amount, string? inputpassword)
    {
        var errors = new List<string>();
        if (!Verification(inputpassword))
        {
            errors.Add("Deposit failed due to incorrect password.");
        } 
        if (!WalletUtils.IsAPositive(amount))
        {
            errors.Add("Amount must be positive.");
        }
        if (errors.Count > 0)
        {
            throw new InvalidOperationException(string.Join(" ", errors));
        }
         balance += amount;
         //Console.WriteLine("Successfully deposit.");
         return;
    }

    public void WithdrawFunds(double amount, string? inputpassword)
    {
        var errors = new List<string>();
        if (!Verification(inputpassword))
        {
            errors.Add("Password verification failed.");
        }
        if (!WalletUtils.IsAPositive(amount))
        {
            errors.Add("Amount must be positive.");
        }
        if (balance < amount)
        {
            errors.Add("Not enough money.");
        }
        if (errors.Count > 0)
        {
            throw new InvalidOperationException(string.Join(" ", errors));
        }

        balance -= amount;
        //Console.WriteLine($"Successfully withdrew {amount}. Remaining balance: {balance}");
    }

    public double GetBalance() => balance;


    public void SetPassword(string inputPassword)
    {
        if (password == null)
        {
            password = inputPassword;
            //Console.WriteLine("The password created");
        }
    }

    public bool Verification(string? inputPassword)
    {
        return PasswordVerifier.Verify(password, inputPassword); 
    }
}