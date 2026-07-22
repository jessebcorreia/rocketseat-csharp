namespace Fundamentals.Types;

public class Lists
{
    public static void Execute()
    {
        Console.WriteLine("\nList declaration");

        List<string> names = new List<string>();

        names.Add("John Doe");
        names.Add("Jane Smith");
        names.Add("Bob Johnson");

        foreach (string name in names)
        {
            Console.WriteLine(name);
        }

        Console.WriteLine("\nRemoving items");

        names.Remove("Jane Smith");

        foreach (string name in names)
        {
            Console.WriteLine(name);
        }

        Console.WriteLine("\nSearching items");

        bool containsName = names.Contains("John Doe");

        Console.WriteLine($"Contains John Doe: {containsName}");
    }
}