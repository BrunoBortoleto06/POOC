namespace POOC.Domain.General;
public class Price
{
    public int ItemPrice { get; private set; }
    public Currency Currency { get; private set; }

    public Price (int itemPrice, Currency currency){
        this.ItemPrice = itemPrice;
        this.Currency = currency;
    }

    public override string ToString()
    {
        return $"{ItemPrice} {Currency}";
    }
}
