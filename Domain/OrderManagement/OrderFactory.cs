using POOC.Domain.ProductManagement;

namespace POOC.Domain.OrderManagement;

public class OrderFactory
{

    public static Order CreateOrder(Product product)
    {
        Order order = new();

        int id = IdGenerator.NextIdOrder();

        order.OrdemItems.Add(CreateOrderItem(product));


        return new Order() { Id = id, OrdemItems = order.OrdemItems, OrderFulfilmentDate = order.OrderFulfilmentDate};
    }

    public static OrderItem CreateOrderItem(Product product)
    {
        int amountOrdered = Utilities.ReadInt("How much items you want stock");

        product.IncreaseInStock(amountOrdered);

        int id = IdGenerator.NextIdOrderItem();

        int productId = product.Id;

        string productName = product.Name;



        return new OrderItem() { Id = id, AmountOrdered = amountOrdered, ProductID = productId, ProductName = productName };

    }
}
