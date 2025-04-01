public interface ITransaction
{
    double Amount { get; }
    DateTime Date { get; }
    string Type { get; }
}

public class Transaction : ITransaction
{
    public double Amount { get; }
    public DateTime Date { get; }
    public string Type { get; }

    public Transaction(double amount, string type)
    {
        Amount = amount;
        Type = type;
        Date = DateTime.Now;
    }
}