public class Account

public static string GenerateCardNumber()
{
    Random random = new Random();
    return ($"{random.next(1000, 9999)}-{random.Next(1000, 9999)}-{random.Next(1000, 9999)}-{random.Next(1000, 9999)}")
}

public string FirstName = {get; set;}
public string LastName = {get; set;}
public int CardNumber = {get; set;}
public string Pin = {get; set;}
public decimal Balance = { get; set;}



    public static List<Account> Accounts = new List<Account>();
{

    public Account(string FirstName, string LastName, int CardNumber, string Pin)

    FirstName = firstName
    LastName = lastName
    Pin = pin;
    Balance = 0; //Detta så att alla konton börjar på 0 kronor

    Account.Add(this);

}

