using Fundamentals.Types;
using Fundamentals.Utils;

public static class TypesMenu
{
    public static void Execute()
    {
        ShowMenu();
    }

    private static void ShowMenu()
    {
        List<(int number, string description)> menu = new();

        menu.Add((0, "Execute All"));
        menu.Add((1, "Primitive Types"));
        menu.Add((2, "Enums"));
        menu.Add((3, "Arrays"));
        menu.Add((4, "Lists"));
        menu.Add((5, "Dictionaries"));

        Printer.PrintMenuTitle("Types", ConsoleTheme.TitleColor);

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
                Printer.PrintMenuTitle("Primitive Types", ConsoleTheme.SubtitleColor);
                PrimitiveTypes.Execute();

                Printer.PrintMenuTitle("Enums", ConsoleTheme.SubtitleColor);
                Enums.Execute();

                Printer.PrintMenuTitle("Arrays", ConsoleTheme.SubtitleColor);
                Arrays.Execute();

                Printer.PrintMenuTitle("Lists", ConsoleTheme.SubtitleColor);
                Lists.Execute();

                Printer.PrintMenuTitle("Dictionaries", ConsoleTheme.SubtitleColor);
                Dictionaries.Execute();
                break;
            case 1:
                Printer.PrintMenuTitle("Primitive Types", ConsoleTheme.SubtitleColor);
                PrimitiveTypes.Execute();
                break;
            case 2:
                Printer.PrintMenuTitle("Enums", ConsoleTheme.SubtitleColor);
                Enums.Execute();
                break;
            case 3:
                Printer.PrintMenuTitle("Arrays", ConsoleTheme.SubtitleColor);
                Arrays.Execute();
                break;
            case 4:
                Printer.PrintMenuTitle("Lists", ConsoleTheme.SubtitleColor);
                Lists.Execute();
                break;
            case 5:
                Printer.PrintMenuTitle("Dictionaries", ConsoleTheme.SubtitleColor);
                Dictionaries.Execute();
                break;
            default:
                Printer.Print("O número digitado é inválido");
                break;
        }
    }

}
