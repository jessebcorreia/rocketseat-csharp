namespace Fundamentals.Loops;

public static class LoopsExample
{
    public static void For()
    {
        for (int i = 1; i <= 5; i++)
        {
            Console.WriteLine($"Iteration: {i}");
        }
    }

    public static void While()
    {
        int counter = 1;

        while (counter <= 5)
        {
            Console.WriteLine($"Counter: {counter}");

            counter++;
        }
    }

    public static void DoWhile()
    {
        int number = 1;

        do
        {
            Console.WriteLine($"Number: {number}");

            number++;
        }
        while (number <= 5);
    }

    public static void Foreach()
    {
        string[] fruits =
        {
            "Apple",
            "Banana",
            "Orange"
        };

        foreach (string fruit in fruits)
        {
            Console.WriteLine(fruit);
        }
    }

    public static void Nested()
    {
        for (int row = 1; row <= 3; row++)
        {
            for (int column = 1; column <= 3; column++)
            {
                Console.WriteLine($"Row: {row}, Column: {column}");
            }
        }
    }

    public static void Break()
    {
        for (int i = 1; i <= 10; i++)
        {
            if (i == 5)
            {
                break; // Encerra o loop completamente -> Se der return, encerra o método inteiro
            }

            Console.WriteLine(i);
        }
    }

    public static void Continue()
    {
        for (int i = 1; i <= 5; i++)
        {
            if (i == 3)
            {
                continue; // Pula apenas a iteração atual e continua o loop
            }

            Console.WriteLine(i);
        }
    }
}
