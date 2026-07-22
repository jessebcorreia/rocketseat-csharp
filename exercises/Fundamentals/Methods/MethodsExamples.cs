namespace Fundamentals.Functions;

public static class MethodsExamples
{
    public static void Execute()
    {
        int subtractResult = MethodsExamples.Subtract(5, 2);
        int sumResult = MethodsExamples.Sum(4, 6);
        (int result, string author) = MethodsExamples.SumWithAuthor(3, 5, "John");
        int optionalParamsResult = MethodsExamples.OptionalParams(3);
    }

    public static int Subtract(int number1, int number2)
    {
        return number1 - number2;
    }

    public static int Sum(int number1, int number2) => number1 + number2;


    public static (int Result, string Author) SumWithAuthor(int number1, int number2, string author) // Retorna uma tupla nomeada
    {
        int result = number1 + number2;

        return (result, author);
    }

    public static int OptionalParams(int value1, int value2 = 0) // Define um valor padrão para um parâmetro, tornando-o opcional
    {
        int result = value1 + value2;

        return result;
    }
}
