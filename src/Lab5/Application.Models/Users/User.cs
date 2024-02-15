namespace Models.Users;

public class User
{
    public User(long id, long pin, long balance)
    {
        Id = id;
        Pin = pin;
        Balance = balance;
    }

    public long Id { get; init; }
    public long Pin { get; init; }
    public long Balance { get; private set; }

    public void ChangeBalance(long amount)
    {
        if (amount >= 0)
        {
            Balance = amount;
        }
    }
}