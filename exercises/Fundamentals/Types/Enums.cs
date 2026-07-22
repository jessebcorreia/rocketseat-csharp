namespace Fundamentals.Types;

public class Enums
{
    public static void Execute()
    {
        OrderStatus status = OrderStatus.Pending;

        Console.WriteLine($"Current status: {status}");
        Console.WriteLine($"Status value: {(int)status}");

        status = OrderStatus.Approved;

        Console.WriteLine($"Updated status: {status}");
        Console.WriteLine($"Status value: {(int)status}");
    }
}

public enum OrderStatus
{
    Pending,
    Approved,
    Completed,
    Cancelled
}
