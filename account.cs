public class Account

public static string GenerateCardNumber()
{
    Random random = new Random();
    return ($"{random.next(1000, 9999)}-{random.Next(1000, 9999)}-{random.Next(1000, 9999)}-{random.Next(1000, 9999)}")
}

