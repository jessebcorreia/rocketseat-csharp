using Practicing.Utils;

namespace Practicing.Exercises;

public static class Welcome
{
    public static void Execute()
    {
        WelcomeMessage();
        CharacterCount();
    }

    public static void WelcomeMessage()
    {
        Printer.PrintMenuSubtitle("Welcome");

        Printer.PrintInLine(" -> Digite seu primeiro nome: ", ConsoleTheme.HighlightColor);
        string? firstName = Console.ReadLine();

        Printer.PrintInLine(" -> Digite seu sobrenome: ", ConsoleTheme.HighlightColor);
        string? lastName = Console.ReadLine();

        Console.WriteLine();
        Printer.Print($"Seja bem vindo, {firstName} {lastName}");
    }

    public static void CharacterCount()
    {
        Printer.PrintInLine("\n -> Digite uma ou mais palavras: ", ConsoleTheme.HighlightColor);
        string? input = Console.ReadLine();

        int count = 0;

        if (input is not null)
        {
            foreach (char character in input)
            {
                if (character != ' ')
                {
                    count++;
                }
            }
        }

        Printer.Print($"Quantidade de caracteres: {count}");
    }
}
