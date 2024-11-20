using system;
public class Program
{
    public static void Main (string[] args)
    {
        Console.WriteLine("Välkommen till modern Atm");
        Console.WriteLine("1. Logga in. ");
        Console.WriteLine("2. Skapa konto.");
        Console.WriteLine("3. Avsluta");
        Console.WriteLine("4. Välj ett av alternativen ovan:");
        {
            int choice = int.parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
               Console.WriteLine("Du är nu inloggad"); 
               break;
               case 2:
               Console.WriteLine("Du valde att skapa ett nytt konto");
               break;
               case 3:
               Console.WriteLine("Du valde att avsluta, på återseende!");
               environment.Exit(0);
               break;
               default;
               Console.WriteLine("Ogiltigt val, vänligen försök igen");
               break;

                

            }

            


        }




    }

}



































}
    