namespace POOC.Domain.ProductManagement;

public partial class Product
{

    private void Log(string message)
    {
        Console.WriteLine(message);
    }

    private string CreateSimpleProductRepresentation()
    {
        return $"Product {this.Id} ({this.Name})";
    }
    private string GetUnitTypeFriendlyName()
    {
        return this.UnitType switch
        {
            UnitType.PerItem => "Item(s)",
            UnitType.PerBox => "box(es)",
            UnitType.PerKg => "kg",

            _ => this.UnitType.ToString() // todo outro valor de enum que nao registrado em cima, vai ser mostrado como ele esta no enum (serve para evitar erros)
        };
    }

}

