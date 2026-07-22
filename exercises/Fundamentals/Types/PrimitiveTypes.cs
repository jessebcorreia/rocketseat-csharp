using Fundamentals.Utils;

namespace Fundamentals.Types;

public class PrimitiveTypes
{
    public static void Execute()
    {
        // Inteiros
        sbyte sbyteNumber = -100;
        byte byteNumber = 255;
        short shortNumber = -32000;
        ushort ushortNumber = 65000;
        int intNumber = 100000;
        uint uintNumber = 4000000000;
        long longNumber = 9000000000000;
        ulong ulongNumber = 18000000000000000000;

        // Ponto flutuante
        float floatNumber = 3.14f;
        double doubleNumber = 3.14159265359;
        decimal decimalNumber = 19.99m;

        // Texto
        char character = 'A';

        // Booleano
        bool isActive = true;

        // Nullable (permite valor nulo)
        int? age = null;

        Console.WriteLine($"sbyte   : {sbyteNumber}");
        Console.WriteLine($"byte    : {byteNumber}");
        Console.WriteLine($"short   : {shortNumber}");
        Console.WriteLine($"ushort  : {ushortNumber}");
        Console.WriteLine($"int     : {intNumber}");
        Console.WriteLine($"uint    : {uintNumber}");
        Console.WriteLine($"long    : {longNumber}");
        Console.WriteLine($"ulong   : {ulongNumber}");
        Console.WriteLine($"float   : {floatNumber}");
        Console.WriteLine($"double  : {doubleNumber}");
        Console.WriteLine($"decimal : {decimalNumber}");
        Console.WriteLine($"char    : {character}");
        Console.WriteLine($"bool    : {isActive}");
        Console.WriteLine($"int?    : {age}");
    }
}
