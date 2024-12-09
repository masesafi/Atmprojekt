using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Transactions;

namespace atmprojekt
{
    public class Account
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CardNumber { get; set; }
        public string Pin { get; set; }
        public decimal Balance { get; set; }
        public static List<Account> Accounts = new List<Account>();


    
       private static Random random = new Random();
        public static string GenerateCardNumber()
        {
            
            return $"{random.Next(1000, 9999)}-{random.Next(1000, 9999)}-{random.Next(1000, 9999)}-{random.Next(1000, 9999)}";
        }

        public Account(string firstName, string lastName, string cardNumber, string pin)
        {

            FirstName = firstName;
            LastName = lastName;
            CardNumber = cardNumber;
            Pin = pin;
            Balance = 0; //Detta så att alla konton börjar på 0 kronor
            Accounts.Add(this);
            Console.WriteLine($"Konto har tillagts i listan: {FirstName} {LastName}, Kortnummer: {CardNumber}");

        }

        public static void ListAllAccounts()
        {
            Console.WriteLine("Konton i systemet:");
            foreach (var account in Accounts)
            {
                Console.WriteLine($"Namn: {account.FirstName} {account.LastName}, Kortnummmer: {account.CardNumber}, Pin; {account.Pin}");
            }
        }

        public List<Transaction> Transactions { get; set; } = new List<Transaction>();

    }
}