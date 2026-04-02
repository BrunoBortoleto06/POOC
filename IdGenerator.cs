namespace POOC;

public static class IdGenerator
{
    private static int _nextIdProduct = 1;
    private static int _nextIdOrderItem = 1;
    private static int _nextIdOrder = 1;

    public static int NextIdProduct()
    {
        return _nextIdProduct++;
    }

    public static int NextIdOrderItem()
    {
        return _nextIdOrderItem++;
    }

    public static int NextIdOrder()
    {
        return _nextIdOrder++;
    }

}
