using Practicing.Utils;

namespace Practicing.Exercises;

public static class DateFormatter
{
    public static void Execute()
    {
        Printer.PrintMenuSubtitle("Date Formatter");

        DateTime now = DateTime.Now;

        Printer.Print("1 - Data completa");
        Printer.Print("2 - Apenas data");
        Printer.Print("3 - Apenas hora");
        Printer.Print("4 - Data com mês por extenso");

        Printer.PrintInLine("\n -> Escolha uma opção: ", ConsoleTheme.HighlightColor);
        string? option = Console.ReadLine();

        switch (option)
        {
            case "1":
                FullDate(now);
                break;

            case "2":
                OnlyDate(now);
                break;

            case "3":
                OnlyTime(now);
                break;

            case "4":
                DateWithMonthName(now);
                break;

            default:
                Printer.Print("Opção inválida", ConsoleTheme.ErrorColor);
                break;
        }
    }

    private static void FullDate(DateTime date)
    {
        Printer.Print(date.ToString("dddd, dd 'de' MMMM 'de' yyyy HH:mm:ss"));
    }

    private static void OnlyDate(DateTime date)
    {
        Printer.Print(date.ToString("dd/MM/yyyy"));
    }

    private static void OnlyTime(DateTime date)
    {
        Printer.Print(date.ToString("HH:mm:ss"));
    }

    private static void DateWithMonthName(DateTime date)
    {
        Printer.Print(date.ToString("dd 'de' MMMM 'de' yyyy"));
    }
}