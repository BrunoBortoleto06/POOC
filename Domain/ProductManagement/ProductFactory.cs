using POOC.Domain.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POOC.Domain.ProductManagement;

public class ProductFactory
{
    public static Product CreateProduct()
    {

        int id = IdGenerator.NextID();

        string productName = Utilities.ReadString("\nQual o nome do produto?");

        string description = Utilities.ReadString("\nQual a descrição?");

        int maxItemInStock = Utilities.ReadInt("\nQual o maximo de itens no estoque?");

        int priceValue = Utilities.ReadInt("\nQual o preço?");

        Currency currency = EnumHelper.ReadEnum<Currency>("\nQual a moeda?\n0 - USD\n1 - EUR\n2 - GBP\n3 - BRL");

        Price price = new Price(priceValue, currency);

        UnitType unitType = EnumHelper.ReadEnum<UnitType>("\nQual o tipo?\n0 - PerItem\n1 - PerBox\n2 - PerKg");

        return new Product(id, productName, description, maxItemInStock, price, unitType);

    }

    public static Product CloneProduct(Product produto)
    {

        int id = IdGenerator.NextID(); 

        string productName = produto.Name;

        string description = produto.Description;

        int maxItemInStock = produto.MaxItemInStock;

        Price price = produto.Price;

        UnitType unitType = produto.UnitType;

        return new Product(id, productName, description, maxItemInStock, price, unitType);

    }

}
