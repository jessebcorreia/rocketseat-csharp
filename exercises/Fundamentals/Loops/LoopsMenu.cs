using Fundamentals.Loops;
using Fundamentals.Utils;

public static class LoopsMenu
{
    public static void Execute()
    {
        ShowMenu();
    }

    private static void ShowMenu()
    {
        List<(int number, string description)> menu = new();

        menu.Add((0, "Execute All"));
        menu.Add((1, "For"));
        menu.Add((2, "While"));
        menu.Add((3, "Do While"));
        menu.Add((4, "For Each"));
        menu.Add((5, "Nested"));
        menu.Add((6, "Break"));
        menu.Add((7, "Continue"));

        Printer.PrintMenuTitle("Loops", ConsoleTheme.TitleColor);

        foreach (var item in menu)
        {
            Printer.PrintMenuItem(item.number, item.description, ConsoleTheme.HighlightColor);
        }

        Printer.Print("\n -> Digite um número corresponde ao menu acima: ", ConsoleTheme.HighlightColor, PrintMode.InLine);

        bool isUserInputValid = false;
        bool isUserInputInNumberRange = false;

        do
        {
            string? userInput = Console.ReadLine();
            isUserInputValid = int.TryParse(userInput, out int userInputNumber);

            if (!isUserInputValid)
            {
                Printer.Print($" -> O valor digitado não é um número válido. Por favor, digite novamente: ", ConsoleTheme.ErrorColor, PrintMode.InLine);
                continue;
            }

            isUserInputInNumberRange = menu.Any(item => item.number == userInputNumber);

            if (!isUserInputInNumberRange)
            {
                Printer.Print($" -> O número digitado '{userInputNumber}' não está listado no menu. Por favor, digite novamente: ", ConsoleTheme.ErrorColor, PrintMode.InLine);
                continue;
            }

            ExecuteCodeByOption(userInputNumber);

        } while (!isUserInputValid || !isUserInputInNumberRange);
    }

    private static void ExecuteCodeByOption(int optionNumber)
    {
        switch (optionNumber)
        {
            case 0:
                Printer.PrintMenuTitle("For", ConsoleTheme.SubtitleColor);
                LoopsExample.For();

                Printer.PrintMenuTitle("While", ConsoleTheme.SubtitleColor);
                LoopsExample.While();

                Printer.PrintMenuTitle("Do While", ConsoleTheme.SubtitleColor);
                LoopsExample.DoWhile();

                Printer.PrintMenuTitle("For Each", ConsoleTheme.SubtitleColor);
                LoopsExample.Foreach();

                Printer.PrintMenuTitle("Nested", ConsoleTheme.SubtitleColor);
                LoopsExample.Nested();

                Printer.PrintMenuTitle("Break", ConsoleTheme.SubtitleColor);
                LoopsExample.Break();

                Printer.PrintMenuTitle("Continue", ConsoleTheme.SubtitleColor);
                LoopsExample.Continue();
                break;
            case 1:
                Printer.PrintMenuTitle("For", ConsoleTheme.SubtitleColor);
                LoopsExample.For();
                break;
            case 2:
                Printer.PrintMenuTitle("While", ConsoleTheme.SubtitleColor);
                LoopsExample.While();
                break;
            case 3:
                Printer.PrintMenuTitle("Do While", ConsoleTheme.SubtitleColor);
                LoopsExample.DoWhile();
                break;
            case 4:
                Printer.PrintMenuTitle("For Each", ConsoleTheme.SubtitleColor);
                LoopsExample.Foreach();
                break;
            case 5:
                Printer.PrintMenuTitle("Nested", ConsoleTheme.SubtitleColor);
                LoopsExample.Foreach();
                break;
            case 6:
                Printer.PrintMenuTitle("Break", ConsoleTheme.SubtitleColor);
                LoopsExample.Break();
                break;
            case 7:
                Printer.PrintMenuTitle("Continue", ConsoleTheme.SubtitleColor);
                LoopsExample.Break();
                break;
            default:
                Printer.Print("O número digitado é inválido");
                break;
        }
    }

}
