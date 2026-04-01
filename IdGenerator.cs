namespace POOC;

public static class IdGenerator
{
    private static int _nextId = 1;

    public static int NextID()
    {
        return _nextId++;
    }
}
