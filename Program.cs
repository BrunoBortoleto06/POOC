using POOC.Domain.General;
using POOC.Domain.OrderManagement;
using POOC.Domain.ProductManagement;

namespace POOC;

public class Program
{
    public static void Main()
    {

        Utilities.PrintWelcome();

        int choice = 1;

        while (choice != 0)
        {
            Utilities.ShowMainMenu();

             choice = Utilities.ReadInt("Your selection:");

            switch (choice)
            {
                case 1:
                    Console.Clear();
                    Utilities.ShowInventoryManagement();
                    break;

                case 2:
                    Console.Clear();
                    Utilities.ShowOrderManagement();
                    break;

                case 0:
                    Console.Clear();
                    break;
            }
        }
    }
}