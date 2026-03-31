namespace POOC.Domain.OrderManagement;

public class OrderItem
{
    public int Id { get; private set; }
    public int ProductID { get; private set; }
    public string ProductName { get; private set; } = string.Empty;
    public int AmountOrdered { get; private set; }

    public override string ToString()
    {
        return $"Product ID: {ProductID} - Name: {ProductName} - Amount Ordered: {AmountOrdered}";
    }
}
