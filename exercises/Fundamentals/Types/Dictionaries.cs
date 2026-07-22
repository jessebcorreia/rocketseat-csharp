namespace Fundamentals.Types;

public class Dictionaries
{
    public static void Execute()
    {
        Console.WriteLine("\nDictionary declaration");

        Dictionary<int, string> users = new Dictionary<int, string>();

        Console.WriteLine($"Count: {users.Count}");

        Console.WriteLine("\nAdding items");

        users.Add(1, "John Doe");
        users.Add(2, "Jane Smith");
        users.Add(3, "Bob Johnson");

        foreach (KeyValuePair<int, string> user in users)
        {
            Console.WriteLine($"Id: {user.Key}, Name: {user.Value}");
        }

        Console.WriteLine("\nAccessing item");

        string userName = users[1];

        Console.WriteLine($"User: {userName}");

        Console.WriteLine("\nSearching item");

        bool containsKey = users.ContainsKey(2);

        Console.WriteLine($"Contains key 2: {containsKey}");

        Console.WriteLine("\nRemoving item");

        users.Remove(3);

        foreach (KeyValuePair<int, string> user in users)
        {
            Console.WriteLine($"Id: {user.Key}, Name: {user.Value}");
        }
    }
}