using Practicing.Utils;

namespace Practicing.Exercises;

public static class VehiclePlateValidator
{
    public static void Execute()
    {
        Printer.PrintMenuSubtitle("Vehicle Plate Validator");

        Printer.PrintInLine(" -> Digite a placa do veículo: ", ConsoleTheme.HighlightColor);
        string? plate = Console.ReadLine();

        bool isValid = ValidatePlate(plate);

        Printer.Print(isValid ? "A placa segue o padrão" : "A placa não segue o padrão");
    }

    private static bool ValidatePlate(string? plate)
    {
        if (string.IsNullOrWhiteSpace(plate))
            return false;

        if (plate.Length != 7)
            return false;

        string letters = plate[..3];
        string numbers = plate[3..];

        foreach (char letter in letters)
        {
            if (!char.IsLetter(letter))
                return false;
        }

        foreach (char number in numbers)
        {
            if (!char.IsDigit(number))
                return false;
        }

        return true;
    }
}
