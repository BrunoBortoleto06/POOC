namespace POOC.Domain.OrderManagement;

public class Order
{
    public int Id { get; private set; }
    public DateTime OrderFulfilmentDate { get; private set; }
    public List<OrderItem> OrdemItems { get; }
    public bool FulFilled { get; private set;  } = false;

    public Order()
    {
        this.Id = new Random().Next(99999);

        int numberOfSeconds = new Random().Next(100);
        this.OrderFulfilmentDate = DateTime.Now.AddSeconds(numberOfSeconds);

        this.OrdemItems = new List<OrderItem>();
    }
}
