using POOC.Domain.General;
using POOC.Domain.OrderManagement;
using POOC.Domain.ProductManagement;

namespace POOC;

public class Program
{
    public static void Main()
    {


        Console.WriteLine("Qual o preço?");
        int priceValue = int.Parse(Console.ReadLine());

        Console.WriteLine("Qual a moeda?");
        foreach (var item in Enum.GetValues<Currency>())
        {
            Console.WriteLine($"{(int)item} - {item}");
        }

        int currencyInput = int.Parse(Console.ReadLine());
        Currency currency = (Currency)currencyInput;

        Price price = new Price(priceValue, currency);

        Console.WriteLine(price);





    }
}