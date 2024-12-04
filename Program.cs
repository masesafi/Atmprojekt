using System;
namespace atmprojekt
{
    public class Program
    {
        static bool IsPinValid(string Pin)
        {
            foreach (char digit in Pin)
            {
                if (!char.IsDigit(digit)) return false;

            }
            return true;
        }

        static void HandleDeposit(Account account)
        {
            Console.WriteLine("Sätt in önskad belopp(endast heltal):");
            if (int.TryParse(Console.ReadLine(), out int amount) && amount > 0)
            {
                if (amount < 100)
                {
                    Console.WriteLine("Tyvärr för låg insättning, minsta insättning är 100kr");
                }
                else
                {
                    account.Balance = account.Balance + amount; //Öka saldot
                    Console.WriteLine($"Insättningen lyckades ditt nya saldo är: {account.Balance} kr");
                }
            } // Allt innanför denna tryparse kommer att göra en insätting
                else
                {
                    Console.WriteLine("Ogiltigt saldo försök gärna igen."); // Görs ej en insättning
                }
            
            
         }



        public static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Välkommen till modern Atm");
                Console.WriteLine("1. Logga in. ");
                Console.WriteLine("2. Skapa konto.");
                Console.WriteLine("3. Avsluta");
                Console.WriteLine("4. Välj ett av alternativen ovan:");

                try
                {

                    int choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            HandleLogin();
                            break;

                        case 2:
                            HandleCreateAccount();
                            break;

                        case 3:
                            Console.WriteLine("Du valde att avsluta, på återseende!");
                            Environment.Exit(0);
                            break;

                        default:
                            Console.WriteLine("Ogiltigt val, vänligen försök igen");
                            break;
                    }
                }

                catch (FormatException)
                {
                    Console.WriteLine("Vänligen ange ett nummer (1-3)");
                }
            }



            static void HandleLogin()
            {

                Console.WriteLine("Ange ditt kortnummer: ");
                string cardNumber = Console.ReadLine();

                Console.WriteLine("Ange din PIN-kod: ");
                string Pin = Console.ReadLine();


                foreach (var account in Account.Accounts)
                {
                    if (account.CardNumber == cardNumber && account.Pin == Pin)
                        Console.WriteLine("Välkommen {account.FirstName} {account.LastName}!");
                    return;
                }
            }


            static void HandleCreateAccount()
            {
                Console.WriteLine("Ange ditt förnamn");
                string FirstName = Console.ReadLine();

                Console.WriteLine("Ange ditt efternamn");
                string LastName = Console.ReadLine();

                Console.WriteLine("Skapa din pin kod (4 siffror)");
                string Pin = Console.ReadLine();

                while (Pin.Length != 4 || Pin.Contains(" ") || !IsPinValid(Pin))
                {

                    Console.WriteLine("Ogiltig kod, din pin kod måste vara exakt 4 siffror. Försök igen.");
                    Pin = Console.ReadLine();
                }



                string cardNumber = Account.GenerateCardNumber();

                Console.WriteLine("Kortnumret har skapats: {cardNumber}");
                Console.WriteLine("konto skapat för {firstName} {lastName} med PIN kod: {Pin}");

                Account NewAccount = new Account(FirstName, LastName, Pin);

                static bool IsPinValid(string pin)
                {
                    foreach (char digit in pin)
                    {
                        if (!char.IsDigit(digit))
                        {
                            return false; // Om något tecken inte är en siffra, returnera false
                        }
                    }
                    return true; // Alla tecken är siffror
                }
            }
        }
    }
}












































