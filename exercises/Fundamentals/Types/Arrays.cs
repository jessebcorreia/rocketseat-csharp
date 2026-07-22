namespace Fundamentals.Types;

public class Arrays
{
    public static void Execute()
    {
        DemonstrateArrayDeclaration();
        DemonstrateArrayWithSize();
        DemonstrateMultidimensionalArray();
    }

    public static void DemonstrateArrayDeclaration()
    {
        Console.WriteLine("\nArray declaration");

        string[] names =
        {
            "John Doe",
            "Jane Smith",
            "Bob Johnson"
        };

        foreach (string name in names)
        {
            Console.WriteLine(name);
        }
    }

    public static void DemonstrateArrayWithSize()
    {
        Console.WriteLine("\nArray with defined size");

        string[] names = new string[3];

        names[0] = "John Doe";
        names[1] = "Jane Smith";
        names[2] = "Bob Johnson";

        foreach (string name in names)
        {
            Console.WriteLine(name);
        }
    }

    public static void DemonstrateMultidimensionalArray()
    {
        Console.WriteLine("\nMultidimensional array");

        int[,] matrix = new int[2, 3];

        matrix[0, 0] = 1;
        matrix[0, 1] = 2;
        matrix[0, 2] = 3;

        matrix[1, 0] = 4;
        matrix[1, 1] = 5;
        matrix[1, 2] = 6;

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int column = 0; column < matrix.GetLength(1); column++)
            {
                Console.Write($"{matrix[row, column]} ");
            }

            Console.WriteLine();
        }
    }
}