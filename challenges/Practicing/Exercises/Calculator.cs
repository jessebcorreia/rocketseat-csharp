using Practicing.Utils;

namespace Practicing.Exercises;

public static class Calculator
{
    public static void Execute()
    {
        Printer.PrintMenuSubtitle("Calculator");

        Printer.PrintInLine(" -> Digite o primeiro número: ", ConsoleTheme.HighlightColor);
        double? number1 = double.TryParse(Console.ReadLine(), out double n1) ? n1 : null;

        Printer.PrintInLine(" -> Digite o segundo número: ", ConsoleTheme.HighlightColor);
        double? number2 = double.TryParse(Console.ReadLine(), out double n2) ? n2 : null;

        if (number1 is null || number2 is null)
        {
            Printer.Print("Por favor, informe um número válido", ConsoleTheme.ErrorColor);
            return;
        }

        double sumResult = Sum(number1.Value, number2.Value);
        double subtractResult = Subtract(number1.Value, number2.Value);
        double multiplyResult = Multiply(number1.Value, number2.Value);
        double divideResult = Divide(number1.Value, number2.Value);
        double averageResult = Average(number1.Value, number2.Value);

        Console.WriteLine();
        Printer.Print($"Soma          ({number1} + {number2}) = {sumResult}");
        Printer.Print($"Subtração     ({number1} - {number2}) = {subtractResult}");
        Printer.Print($"Multiplicação ({number1} * {number2}) = {multiplyResult}");
        Printer.Print($"Divisão       ({number1} / {number2}) = {divideResult}");
        Printer.Print($"Média entre   ({number1} e {number2}) = {averageResult}");
    }

    private static double Sum(double number1, double number2)
    {
        return number1 + number2;
    }

    private static double Subtract(double number1, double number2)
    {
        return number1 - number2;
    }

    private static double Multiply(double number1, double number2)
    {
        return number1 * number2;
    }

    private static double Divide(double number1, double number2)
    {
        return number1 / number2;
    }

    private static double Average(double number1, double number2)
    {
        return (number1 + number2) / 2;
    }
}
