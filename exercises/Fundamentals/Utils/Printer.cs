namespace Fundamentals.Utils;

public static class Printer
{

    public static void PrintMenuTitle(string title, ConsoleColor titleColor = ConsoleColor.Green)
    {
        int menuWidth = 30;
        string separator = new string('=', menuWidth);

        int leftPaddingWidth = (menuWidth - title.Length) / 2;
        string leftPadding = new string(' ', leftPaddingWidth);

        ConsoleColor previousForeground = Console.ForegroundColor;

        Console.ForegroundColor = titleColor;

        Console.WriteLine();
        Console.WriteLine(separator);
        Console.WriteLine(leftPadding + title.ToUpper());
        Console.WriteLine(separator);
        Console.WriteLine();

        Console.ForegroundColor = previousForeground;
    }

    public static void PrintMenuItem(int number, string description, ConsoleColor numberColor = ConsoleColor.Green)
    {
        ConsoleColor previousForeground = Console.ForegroundColor;

        Console.ForegroundColor = numberColor;
        Console.Write($" {number}. ");

        Console.ForegroundColor = previousForeground;
        Console.Write($"{description}\n");
    }

    public static void Print(string text, ConsoleColor? textColor = null, PrintMode printMode = PrintMode.NextLine)
    {
        ConsoleColor previousForeground = Console.ForegroundColor;

        if (textColor is ConsoleColor color)
        {
            Console.ForegroundColor = color;
        }

        if (printMode == PrintMode.InLine)
        {
            Console.Write(text);
        } else
        {
            Console.WriteLine(text);
        }

        Console.ForegroundColor = previousForeground;
    }
}

