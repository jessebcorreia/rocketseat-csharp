using Fundamentals.Classes;
using Fundamentals.Utils;

namespace Fundamentals;

public static class MainMenu
{
    public static void Execute()
    {
        ShowMenu();
    }

    private static void ShowMenu()
    {
        List <(int number, string description)> menu = new();

        menu.Add((0, "Execute All"));
        menu.Add((1, "Types"));
        menu.Add((2, "Methods"));
        menu.Add((3, "Classes"));
        menu.Add((4, "Conditionals"));
        menu.Add((5, "Loops"));

        Printer.PrintMenuTitle("Menu Principal", ConsoleTheme.TitleColor);

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
                TypesMenu.Execute();
                MethodsMenu.Execute();
                ClassesMenu.Execute();
                ConditionalsMenu.Execute();
                LoopsMenu.Execute();
                break;
            case 1:
                TypesMenu.Execute();
                break;
            case 2:
                MethodsMenu.Execute();
                break;
            case 3:
                ClassesMenu.Execute();
                break;
            case 4:
                ConditionalsMenu.Execute();
                break;
            case 5:
                LoopsMenu.Execute();
                break;
            default:
                Printer.Print("O número digitado é inválido");
                break;
        }
    }

}
