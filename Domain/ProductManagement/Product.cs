using POOC.Domain.General;
using System.Security.AccessControl;
using System.Text;

namespace POOC.Domain.ProductManagement;

public partial class Product
{
    
    public int Id { get; private set; }
    private string _name = string.Empty;
    private string? _description;
    public string Name
    {
        get { return _name; }

        private set
        {
            _name = value.Length > 50 ? value[..50] : value;
        }
    }
    public string Description
    {
        get { return _description; }

        private set
        {
            if (value == null) _description = string.Empty;

            else _description = value.Length > 250 ? value[..250] : value;
        }
    }
    public int MaxItemInStock { get; private set; }
    public Price Price { get; private set; }
    public UnitType UnitType { get; private set; }
    public int AmountInStock { get; private set; }

    public static int ThreshSold = 10;
    public bool IsBelowStockThreshSold => AmountInStock < ThreshSold;

    public Product(int id, string name, string? description, int maxItemInStock, Price price, UnitType unitType, int amountInStock = 0)
    {

        if (amountInStock > maxItemInStock) throw new ArgumentOutOfRangeException($"Stock Overflow");


        this.Id = id;
        this.Name = name;
        this.Description = description;
        this.MaxItemInStock = maxItemInStock;
        this.Price = price;
        this.UnitType = unitType;
        this.AmountInStock = amountInStock;
    }

    public void UseProduct(int items, string reason = "")
    {
        if (items <= this.AmountInStock)
        {
            this.AmountInStock -= items;

            string logMessage = $"Amount in stock updated, Now {this.AmountInStock} {GetUnitTypeFriendlyName()} in stock.";

            if (!string.IsNullOrEmpty(reason))
            {
                logMessage += $"\nREASON: {reason}";
            }

            Log(logMessage);

        }

        else
        {
            Log($"Not enough items on stock for {CreateSimpleProductRepresentation()}. {this.AmountInStock} avaible but {items} {GetUnitTypeFriendlyName()} requested");
        }
    }

    public void IncreaseInStock()
    {
        IncreaseInStock(1);
    }

    public void IncreaseInStock(int amount)
    {
        int newStock = this.AmountInStock + amount;

        if (newStock <= MaxItemInStock) this.AmountInStock += amount;

        else
        {
            this.AmountInStock = this.MaxItemInStock;

            Log($"{CreateSimpleProductRepresentation()} stock overflow. {newStock - this.AmountInStock} {GetUnitTypeFriendlyName()} ordered that couldn't be stored");
        }
    }

    public void DisplayDetailsShort()
    {
        Console.WriteLine( $"{this.Id}. {this.Name} \n{this.AmountInStock} {GetUnitTypeFriendlyName()} in stock");
    }

    public void DisplayDetailsFull()
    {
        DisplayDetailsFull("");
    }

    public void DisplayDetailsFull(string extraDetails)
    {
        StringBuilder sb = new();

        sb.Append($"{this.Id} {this.Name} \n{this.Description}\n{this.Price}\n{this.AmountInStock} {GetUnitTypeFriendlyName()} in stock");
        
        if (extraDetails != "") sb.Append($"\t EXTRA: {extraDetails}");

        if (IsBelowStockThreshSold)
        {
            sb.Append("\n!!STOCK LOW!!");
        }

        Console.WriteLine(sb.ToString());
    }

}

    
