using Fundamentals.Conditionals;
using Fundamentals.Utils;

public static class ConditionalsMenu
{
    public static void Execute()
    {
        ShowMenu();
    }

    private static void ShowMenu()
    {
        List<(int number, string description)> menu = new();

        menu.Add((0, "Execute All"));
        menu.Add((1, "If Else"));
        menu.Add((2, "Logical Operators"));
        menu.Add((3, "Ternary Operator"));
        menu.Add((4, "Switch"));
        menu.Add((5, "Switch Expression"));
        menu.Add((6, "Pattern Matching"));
        menu.Add((7, "Null Check"));

        Printer.PrintMenuTitle("Conditionals", ConsoleTheme.TitleColor);

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
                Printer.PrintMenuTitle("If Else", ConsoleTheme.SubtitleColor);
                ConditionalsExamples.IfElseExample();

                Printer.PrintMenuTitle("Logical Operators", ConsoleTheme.SubtitleColor);
                ConditionalsExamples.LogicalOperatorsExample();

                Printer.PrintMenuTitle("Ternary Operator", ConsoleTheme.SubtitleColor);
                ConditionalsExamples.TernaryOperatorExample();

                Printer.PrintMenuTitle("Switch", ConsoleTheme.SubtitleColor);
                ConditionalsExamples.SwitchExample();

                Printer.PrintMenuTitle("Switch Expression", ConsoleTheme.SubtitleColor);
                ConditionalsExamples.SwitchExpressionExample();

                Printer.PrintMenuTitle("Pattern Matching", ConsoleTheme.SubtitleColor);
                ConditionalsExamples.PatternMatchingExample();

                Printer.PrintMenuTitle("Null Check", ConsoleTheme.SubtitleColor);
                ConditionalsExamples.NullCheckExample();
                break;
            case 1:
                Printer.PrintMenuTitle("If Else", ConsoleTheme.SubtitleColor);
                ConditionalsExamples.IfElseExample();
                break;
            case 2:
                Printer.PrintMenuTitle("Logical Operators", ConsoleTheme.SubtitleColor);
                ConditionalsExamples.LogicalOperatorsExample();
                break;
            case 3:
                Printer.PrintMenuTitle("Ternary Operator", ConsoleTheme.SubtitleColor);
                ConditionalsExamples.TernaryOperatorExample();
                break;
            case 4:
                Printer.PrintMenuTitle("Switch", ConsoleTheme.SubtitleColor);
                ConditionalsExamples.SwitchExample();
                break;
            case 5:
                Printer.PrintMenuTitle("Switch Expression", ConsoleTheme.SubtitleColor);
                ConditionalsExamples.SwitchExpressionExample();
                break;
            case 6:
                Printer.PrintMenuTitle("Pattern Matching", ConsoleTheme.SubtitleColor);
                ConditionalsExamples.PatternMatchingExample();
                break;
            case 7:
                Printer.PrintMenuTitle("Null Check", ConsoleTheme.SubtitleColor);
                ConditionalsExamples.NullCheckExample();
                break;
            default:
                Printer.Print("O número digitado é inválido");
                break;
        }
    }

}
