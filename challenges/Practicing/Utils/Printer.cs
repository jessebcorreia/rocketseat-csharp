namespace Practicing.Utils;

public static class Printer
{

    public static void PrintMenuTitle(string title, ConsoleColor titleColor = ConsoleTheme.TitleColor)
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

    public static void PrintMenuSubtitle(string title, ConsoleColor titleColor = ConsoleTheme.SubtitleColor)
    {
        int menuWidth = 30;
        string separator = new string('-', menuWidth);

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

    public static void PrintMenuItem(int number, string description, ConsoleColor numberColor = ConsoleTheme.TitleColor)
    {
        ConsoleColor previousForeground = Console.ForegroundColor;

        Console.ForegroundColor = numberColor;
        Console.Write($" {number}. ");

        Console.ForegroundColor = previousForeground;
        Console.Write($"{description}\n");
    }

    public static void Print(string text, ConsoleColor? textColor = null)
    {
        ConsoleColor previousForeground = Console.ForegroundColor;

        if (textColor is ConsoleColor color)
        {
            Console.ForegroundColor = color;
        }

        Console.WriteLine(text);

        Console.ForegroundColor = previousForeground;
    }

    public static void PrintInLine(string text, ConsoleColor? textColor = null)
    {
        ConsoleColor previousForeground = Console.ForegroundColor;

        if (textColor is ConsoleColor color)
        {
            Console.ForegroundColor = color;
        }

        Console.Write(text);

        Console.ForegroundColor = previousForeground;
    }
}

