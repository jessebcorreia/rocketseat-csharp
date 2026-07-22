namespace Fundamentals.Conditionals;

public static class ConditionalsExamples
{
    public static void IfElseExample()
    {
        int age = 20;

        if (age < 18)
        {
            Console.WriteLine("Underage");
        }
        else if (age == 18)
        {
            Console.WriteLine("Exactly 18 years old");
        }
        else
        {
            Console.WriteLine("Adult");
        }
    }


    public static void LogicalOperatorsExample()
    {
        bool hasPermission = true;
        bool isAdmin = false;

        if (hasPermission && !isAdmin)
        {
            Console.WriteLine("User authorized");
        }

        if (hasPermission || isAdmin)
        {
            Console.WriteLine("User has access");
        }
    }


    public static void TernaryOperatorExample()
    {
        double grade = 8.5;

        string result = grade >= 7
            ? "Approved"
            : "Failed";

        Console.WriteLine(result);
    }


    public static void SwitchExample()
    {
        string day = "Monday";

        switch (day)
        {
            case "Monday":
                Console.WriteLine("Start of the week");
                break;

            case "Friday":
                Console.WriteLine("End of the work week");
                break;

            default:
                Console.WriteLine("Another day");
                break;
        }
    }


    public static void SwitchExpressionExample()
    {
        string day = "Sunday";

        string type = day switch
        {
            "Saturday" or "Sunday" => "Weekend",
            "Monday" => "Beginning of the week",
            _ => "Regular day"
        };

        Console.WriteLine(type);
    }


    public static void PatternMatchingExample()
    {
        object value = 123;

        if (value is int number)
        {
            Console.WriteLine($"Value is an integer: {number}");
        }
    }


    public static void NullCheckExample()
    {
        string? name = null;

        if (name is null)
        {
            Console.WriteLine("Name not provided");
        }
        else
        {
            Console.WriteLine($"Name: {name}");
        }
    }
}