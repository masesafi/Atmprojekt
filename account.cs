using System;
using System.Collections.Generic;

namespace atmprojekt
{
public class Account
{
public string FirstName {get; set;}
public string LastName {get; set;}
public string CardNumber  {get; set;}
public string Pin {get; set;}
public decimal Balance { get; set;}
    public static List<Account> Accounts = new List<Account>();

    public static string GenerateCardNumber()
{
    Random random = new Random();
    return $"{random.Next(1000, 9999)}-{random.Next(1000, 9999)}-{random.Next(1000, 9999)}-{random.Next(1000, 9999)}";
}

    public Account(string firstName, string lastName, string pin)
    {

    FirstName = firstName;
    LastName = lastName;
    CardNumber = GenerateCardNumber();
    Pin = pin;
    Balance =0; //Detta så att alla konton börjar på 0 kronor
     Accounts.Add(this);
    }
}
}