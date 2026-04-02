namespace POOC.Domain.OrderManagement;

public class Order
{
    public int Id { get; set; }
    public DateTime OrderFulfilmentDate { get; set; }
    public List<OrderItem> OrderItems { get; set; }
    public bool FulFilled { get; set;  } = false;

    public Order()
    {
        this.Id = new Random().Next(99999);

        int numberOfSeconds = new Random().Next(100);
        this.OrderFulfilmentDate = DateTime.Now.AddSeconds(numberOfSeconds);

        this.OrderItems = new List<OrderItem>();
    }

    public void ShowOrderDetails()
    {
        if (OrderItems != null)
        {
            foreach (var item in OrderItems)
            {
                Console.WriteLine($"{item.ProductID}, {item.ProductName}, {item.AmountOrdered}");
            }
        }
    }
}
