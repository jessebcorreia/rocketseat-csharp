using Practicing.Utils;

namespace Practicing;

public class Menu
{
    private readonly string menuTitle;
    private readonly List<MenuItem> menuItems;

    public Menu(string menuTitle, List<MenuItem> menuItems)
    {
        this.menuTitle = menuTitle;
        this.menuItems = menuItems;
    }

    public void Execute()
    {
        ShowMenu();
    }

    private void ShowMenu()
    {
        Printer.PrintMenuTitle(menuTitle);

        foreach (var item in menuItems)
        {
            Printer.PrintMenuItem(item.Number, item.Description);
        }

        Printer.PrintInLine("\n -> Digite um número corresponde ao menu acima: ", ConsoleTheme.HighlightColor);

        bool isUserInputValid = false;
        bool isUserInputInNumberRange = false;

        do
        {
            string? userInput = Console.ReadLine();
            isUserInputValid = int.TryParse(userInput, out int optionNumber);

            if (!isUserInputValid)
            {
                Printer.PrintInLine($" -> O valor digitado não é um número válido. Por favor, digite novamente: ", ConsoleTheme.ErrorColor);
                continue;
            }

            isUserInputInNumberRange = menuItems.Any(item => item.Number == optionNumber);

            if (!isUserInputInNumberRange)
            {
                Printer.PrintInLine($" -> O número digitado '{optionNumber}' não está listado no menu. Por favor, digite novamente: ", ConsoleTheme.ErrorColor);
                continue;
            }

            ExecuteCodeByOption(optionNumber);
        } while (!isUserInputValid || !isUserInputInNumberRange);
    }

    private void ExecuteCodeByOption(int optionNumber)
    {
        MenuItem menuItem = menuItems.First(item => item.Number == optionNumber);

        if (menuItem is null)
            return;

        menuItem.Execute();
    }

}
