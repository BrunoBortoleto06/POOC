using Microsoft.VisualBasic.FileIO;
using POOC.Domain.OrderManagement;
using POOC.Domain.ProductManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POOC;

internal class Utilities
{
    private static ProductRepository _productRepository = new ProductRepository();
    private static List<Product> inventory = _productRepository.LoadProductsFromFile();
    private static List<Order> orders = new();


    public static void PrintWelcome()
    {
        Console.WriteLine("                            .-'''-.        .-'''-.           _..._     \r\n                           '   _    \\     '   _    \\      .-'_..._''.  \r\n_________   _...._       /   /` '.   \\  /   /` '.   \\   .' .'      '.\\ \r\n\\        |.'      '-.   .   |     \\  ' .   |     \\  '  / .'            \r\n \\        .'```'.    '. |   '      |  '|   '      |  '. '              \r\n  \\      |       \\     \\\\    \\     / / \\    \\     / / | |              \r\n   |     |        |    | `.   ` ..' /   `.   ` ..' /  | |              \r\n   |      \\      /    .     '-...-'`       '-...-'`   . '              \r\n   |     |\\`'-.-'   .'                                 \\ '.          . \r\n   |     | '-....-'`                                    '. `._____.-'/ \r\n  .'     '.                                               `-.______ /  \r\n'-----------'                                                      `   \r\n                                                                       ");

        ReadString("Press enter key to continue logging in!");
        Console.Clear();

    }

    public static void ShowMainMenu()
    {
        Console.WriteLine("********************");
        Console.WriteLine("* Select an Action *");
        Console.WriteLine("********************");

        Console.WriteLine("1 - Inventory Management");
        Console.WriteLine("2 - Order management");
        Console.WriteLine("0 - Close application");

    }

    public static void ShowInventoryManagement()
    {
        bool running = true;

        while (running) 
        {
            Console.WriteLine("\n");
            Console.WriteLine("********************");
            Console.WriteLine("* Inventory Management *");
            Console.WriteLine("********************");

            foreach (Product itens in inventory)
            {
                Console.WriteLine("\n");
                itens.DisplayDetailsShort();
                Console.WriteLine("\n");
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("What do you mean?");

            Console.ResetColor();
            Console.WriteLine("1 - View details of product");
            Console.WriteLine("2 - Add new product");
            Console.WriteLine("3 - Clone product");
            Console.WriteLine("4 - View products with low stock");
            Console.WriteLine("0 - back to main menu");
            int choice = ReadIntLine("Your selection: ");

            switch (choice)
            {

                case 1:

                    int idOption = ReadInt("What's the id of product that you want see");

                    try
                    {
                        Product itens = inventory.Single(x => x.Id == idOption);
                        Console.WriteLine("\n");
                        itens.DisplayDetailsFull();
                        Console.WriteLine("\n");


                        Console.WriteLine("What you want to do?");
                        Console.WriteLine("1 - Use product");
                        Console.WriteLine("0 - Back to inventory overview");
                        int ChoiceCase1 = ReadIntLine("Your selection: ");

                        switch (ChoiceCase1)
                        {
                            case 1:

                                int QntUso = ReadInt($"Want to use how much items of {itens.Name}");

                                itens.UseProduct(QntUso);
                                _productRepository.SaveProductsToFile(inventory);


                                Console.ReadLine();
                                Console.Clear();
                                break;

                            case 0:
                                Console.Clear();
                                break;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Not exist one product with this ID");
                    }
                    break;

                case 2:

                    inventory.Add(ProductFactory.CreateProduct());
                    _productRepository.SaveProductsToFile(inventory);
                    Console.Clear();
                    break;

                case 3:

                    int idClone = ReadInt("What's the id of product that you want see");

                    Product item = inventory.Single(x => x.Id == idClone);

                    inventory.Add(ProductFactory.CloneProduct(item));
                    _productRepository.SaveProductsToFile(inventory);

                    break;

                case 4:

                    IEnumerable<Product> ListBelowStock = inventory.Where(x => x.IsBelowStockThreshSold == true);

                    Console.WriteLine("The following items are low on stock, order more soon!");

                    foreach (Product itensLow in ListBelowStock)
                    {
                        Console.WriteLine("\n");
                        itensLow.DisplayDetailsShort();
                    }

                    Console.ReadLine();
                    Console.Clear();
                    break;

                case 0:
                    Console.Clear();
                    running = false;
                    break;
            }

        }
    }

    public static void ShowOrderManagement()
    {
        bool running = true;

        while (running)
        {
            Console.WriteLine("1 - Open order overview");
            Console.WriteLine("2 - Add new orders");
            Console.WriteLine("0 - back to main menu");
            int choice = ReadIntLine("Your selection: ");

            switch (choice)
            {

                case 1:
                    if (orders.Count > 0)
                    {
                        Console.WriteLine("Open orders:");

                        foreach (Order order in orders)
                        {
                            order.ShowOrderDetails();
                            Console.WriteLine();
                        }
                    }

                    else
                    {
                        Console.WriteLine("There are no open orders");
                    }

                    Console.ReadLine();
                    Console.Clear();
                    break;

                case 2:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Creating new order");

                    Console.ResetColor();
                    foreach (Product itens in inventory)
                    {
                        Console.WriteLine("\n");
                        itens.DisplayDetailsShort();
                        Console.WriteLine("\n");
                    }

                    int idProductOption;

                    do
                    {
                        idProductOption = Utilities.ReadInt("Which product do you want to order? (enter 0 to stop adding new products to the order)");
                        if (idProductOption != 0)
                        {


                            try
                            {

                                Product item = inventory.Single(x => x.Id == idProductOption);

                                Order order = OrderFactory.CreateOrder(item);
                                orders.Add(order);
                                _productRepository.SaveProductsToFile(inventory);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Nao existe item come esse ID");
                            }
                        }

                    } while (idProductOption != 0);

                    break;

                case 0:
                    Console.Clear();
                    running = false;
                    break;
            }
        }
    }

    public static int ReadInt(string message)
    {
        Console.WriteLine(message);
        return int.Parse(Console.ReadLine());
    }

    public static int ReadIntLine(string message)
    {
        Console.Write(message);
        return int.Parse(Console.ReadLine());
    }

    public static string ReadString(string message)
    {
        Console.WriteLine(message);
        return Console.ReadLine();
    }
}
