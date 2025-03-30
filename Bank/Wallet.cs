using Bank.Utilities;

public class Account
{

    private double balance;

    private string? password;

    public Account()
    {
        balance = 0.0;
    }

    public void DepositFunds(double amount)
    {
        if (!Verification())
        {
            Console.WriteLine("Deposit failed due to incorrect password.");
            return;
        } 
        if (!WalletUtils.IsAPositive(amount))
        {
            Console.WriteLine("Amount must be positive.");
            return;
        }
        else
        {
            balance += amount;
            Console.WriteLine("Successfully deposit.");
            return;
        }
    }

    public void WithdrawFunds(double amount)
    {
        if (!Verification())
        {
            Console.WriteLine("Password verification failed.");
            return;
        }
        if (!WalletUtils.IsAPositive(amount))
        {
            Console.WriteLine("Amount must be positive.");
            return;
        }
        if (balance < amount)
        {
            Console.WriteLine("Not enough money.");
            return;
        }

        balance -= amount;
        Console.WriteLine($"Successfully withdrew {amount}. Remaining balance: {balance}");
    }

    public void GetBalance()
    {
        Console.WriteLine(balance);
    }

    public void SetPassword(string inputPassword)
    {
        if (password == null)
        {
            password = inputPassword;
            Console.WriteLine("The password created");
        }
    }

    public bool Verification()
    {
        if(password == null)
        {
            Console.WriteLine("Please Create A password");
            return false;
        } 
        Console.WriteLine("Please enter the password");
        string? inputPassword = Console.ReadLine();

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