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
            Account NewAccount = new Account(FirstName, LastName, cardNumber, Pin);

            Console.WriteLine ($"Kortnumret har skapats: {cardNumber}");
            Console.WriteLine ($"konto skapat för: {FirstName} {LastName} med PIN kod: {Pin}");

        }

        static Account HandleLogin()
        {

            Console.WriteLine("Ange ditt kortnummer: ");
            string cardNumber = Console.ReadLine();

            Console.WriteLine("Ange din PIN-kod: ");
            string Pin = Console.ReadLine();


            foreach (var account in Account.Accounts)
            {
                if (account.CardNumber == cardNumber && account.Pin == Pin)
                {
                    Console.WriteLine("Välkommen {account.FirstName} {account.LastName}!");
                    return account;
                }
            }

            Console.WriteLine("Ogiltig inloggningsuppgift försök gärna igen.");
            return null;
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
                    account.Transactions.Add(new Transaction(amount, "insättning"));
                    Console.WriteLine($"Insättningen lyckades ditt nya saldo är: {account.Balance} kr");


                }
            } // If kommer då att inte låta göra insättning om det är under 100kr, else är det som gör att det sker en insättning
            else
            {
                Console.WriteLine("Ogiltigt saldo försök gärna igen."); // Görs ej en insättning pga andra skäl kanske bokstav som skrivs
            }
        }

        static void HandleWithdraw(Account account)
        {
            Console.WriteLine("Ange hur mycket du vill ta ut(minsta uttaget är 100kr)");

            if (int.TryParse(Console.ReadLine(), out int amount) && amount >= 100)
            {
                if (amount > account.Balance)
                {
                    Console.WriteLine("Otillrickligt saldo!");
                }
                else
                {
                    account.Balance = account.Balance - amount; //Minskar saldot
                    account.Transactions.Add(new Transaction(amount, "Uttag"));
                    Console.WriteLine($"Uttaget godkändes, ditt nya saldo är: {account.Balance} kr");
                }
            }
            else
            {
                Console.WriteLine("Ogiltigt belopp angivet, eller för lågt saldo, försök  gärna igen");

            }
        }

        public static void Main(string[] args)
        {
            Account loggedInAccount = null; //Menas då alltså när kontott är inloggad

            while (true)
            {
                if (loggedInAccount == null)
                {
                    Console.WriteLine("Välkommen till modern Atm");
                    Console.WriteLine("1. skapa konto. ");
                    Console.WriteLine("2. Logga in.");
                    Console.WriteLine("3. Avsluta");
                    Console.WriteLine("4. Välj ett av alternativen ovan:");

                    if (!int.TryParse(Console.ReadLine(), out int choice))
                    {
                        Console.WriteLine("Ogiltigt val, försök gärna igen");
                        continue;
                    }

                    switch (choice)
                    {

                        case 1:
                            HandleCreateAccount();
                            break;

                        case 2:
                            loggedInAccount = HandleLogin();
                            break;

                        case 3:
                            Console.WriteLine("Du valde att avsluta, på återseende!");
                            return;
                        default:
                            Console.WriteLine("Ogiltigt val, vänligen försök igen");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Inloggad meny:");
                    Console.WriteLine("1.Insättning");
                    Console.WriteLine("2.Uttag");
                    Console.WriteLine("3. Visa saldo");
                    Console.WriteLine("4. Logga ut");
                    Console.WriteLine("Välj ett alternativ");

                    if (!int.TryParse(Console.ReadLine(), out int choice))
                    {
                        Console.WriteLine("Ogiltigt val, försök igen");
                        continue;
                    }

                    switch (choice)
                    {
                        case 1:
                            HandleDeposit(loggedInAccount);
                            break;
                        case 2:
                            HandleWithdraw(loggedInAccount);
                            break;
                        case 3:
                            Console.WriteLine($"Ditt saldo är: {loggedInAccount.Balance} kr ");
                            break;
                        case 4:
                            loggedInAccount = null;
                            Console.WriteLine("Du har loggats ut nu");
                            break;
                        default:
                            Console.WriteLine("Ogilitgt val försök igen");
                            break;
                    }
                }
            }
        }



    }
}















































