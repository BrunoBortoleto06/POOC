using POOC.Domain.OrderManagement;
using POOC.Domain.ProductManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POOC
{
    internal class Utilities
    {

        private static List<Product> inventory = new();
        private static List<Order> orders = new();


        internal static void initializeStock()
        {

        }

        public static void PrintWelcome()
        {
            Console.WriteLine("                            .-'''-.        .-'''-.           _..._     \r\n                           '   _    \\     '   _    \\      .-'_..._''.  \r\n_________   _...._       /   /` '.   \\  /   /` '.   \\   .' .'      '.\\ \r\n\\        |.'      '-.   .   |     \\  ' .   |     \\  '  / .'            \r\n \\        .'```'.    '. |   '      |  '|   '      |  '. '              \r\n  \\      |       \\     \\\\    \\     / / \\    \\     / / | |              \r\n   |     |        |    | `.   ` ..' /   `.   ` ..' /  | |              \r\n   |      \\      /    .     '-...-'`       '-...-'`   . '              \r\n   |     |\\`'-.-'   .'                                 \\ '.          . \r\n   |     | '-....-'`                                    '. `._____.-'/ \r\n  .'     '.                                               `-.______ /  \r\n'-----------'                                                      `   \r\n                                                                       ");

            Console.WriteLine("Press enter key to continue logging in!");
            Console.ReadLine();

        }

        public static void ShowMainMenu()
        {
            Console.WriteLine("TESTE");
        }

    }
}
