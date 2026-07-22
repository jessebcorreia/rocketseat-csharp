using Fundamentals.Functions;
using Fundamentals.Types;
using Fundamentals.Utils;

public static class MethodsMenu
{
    public static void Execute()
    {
        ShowMenu();
    }

    private static void ShowMenu()
    {
        List<(int number, string description)> menu = new();

        menu.Add((0, "Execute All"));
        menu.Add((1, "Method Examples"));

        Printer.PrintMenuTitle("Methods", ConsoleTheme.TitleColor);

        foreach (var item in menu)
        {
            Printer.PrintMenuItem(item.number, item.description, ConsoleTheme.TitleColor);
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
                Printer.PrintMenuTitle("Methods Examples", ConsoleTheme.SubtitleColor);
                MethodsExamples.Execute();
                break;
            case 1:
                Printer.PrintMenuTitle("Methods Examples", ConsoleTheme.SubtitleColor);
                MethodsExamples.Execute();
                break;
            default:
                Printer.Print("O número digitado é inválido");
                break;
        }
    }
}
