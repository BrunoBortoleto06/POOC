using POOC.Domain.General;
using POOC.Domain.ProductManagement;

namespace POOC;

public class ProductRepository
{

    public string path = @"C:\Users\E5659\Documents\C#\POOC\product.txt";


    public bool FileExist()
    {
        return File.Exists(path);
    }

    public void SaveProductsToFile(List<Product> inventory)
    {
        string conteudo = "";

        foreach (Product product in inventory)
        {
            conteudo += $"{product.Id},{product.Name},{product.Description},{product.MaxItemInStock},{product.Price},{product.UnitType},{product.AmountInStock}\n";
        }

            File.WriteAllText(path, conteudo);

    }


public List<Product> LoadProductsFromFile()
{
    List<Product> inventory = new();

    if (!FileExist())
    {
        Console.WriteLine("Arquivo nao existe");
        return inventory;
    }

    string[] linhas = File.ReadAllLines(path);

    foreach (var linha in linhas)
    {
        if (string.IsNullOrWhiteSpace(linha)) continue;

        string[] dados = linha.Split(',');

        int id = int.Parse(dados[0].Trim());
        string name = dados[1].Trim();
        string description = dados[2].Trim();
        int maxStock = int.Parse(dados[3].Trim());

        string[] partesPreco = dados[4].Trim().Split(' ');
        int priceValue = int.Parse(partesPreco[0]);

        Currency currency = EnumHelper.ParseEnum<Currency>(partesPreco[1]);
        Price price = new Price(priceValue, currency);

        UnitType unitType = EnumHelper.ParseEnum<UnitType>(dados[5].Trim());

        int amountInStock = int.Parse(dados[6].Trim());

        Product product = new Product(id, name, description, maxStock, price, unitType, amountInStock);

        inventory.Add(product);
    }

    return inventory;
}

}
