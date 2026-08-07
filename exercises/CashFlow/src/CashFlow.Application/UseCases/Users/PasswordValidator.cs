using FluentValidation;
using FluentValidation.Validators;
using System.Text.RegularExpressions;

namespace CashFlow.Application.UseCases.Users;

public partial class PasswordValidator<T> : PropertyValidator<T, string>
{
    private const string ERROR_MESSAGE_KEY = "ErrorMessage";

    public override string Name => "PasswordValidator";

    protected override string GetDefaultMessageTemplate(string errorCode)
    {
        return $"{{{ERROR_MESSAGE_KEY}}}";
    }

    public override bool IsValid(ValidationContext<T> context, string password)
    {
        var errorMessage = ValidatePassword(password);

        if (errorMessage is not null)
        {
            context.MessageFormatter.AppendArgument(ERROR_MESSAGE_KEY, errorMessage);
            return false;
        }

        return true;
    }

    private static string? ValidatePassword(string password)
    {
        if (string.IsNullOrWhiteSpace(password))
            return "Password is required.";

        if (password.Length < 8)
            return "Password must be at least 8 characters long.";

        if (!UppercaseLetter().IsMatch(password))
            return "Password must contain at least one uppercase letter.";

        if (!LowercaseLetter().IsMatch(password))
            return "Password must contain at least one lowercase letter.";

        if (!Number().IsMatch(password))
            return "Password must contain at least one number.";

        if (!SpecialCharacter().IsMatch(password))
            return "Password must contain at least one special character.";

        return null;
    }

    [GeneratedRegex(@"[A-Z]")]
    private static partial Regex UppercaseLetter();

    [GeneratedRegex(@"[a-z]")]
    private static partial Regex LowercaseLetter();

    [GeneratedRegex(@"[!?.@]")]
    private static partial Regex SpecialCharacter();

    [GeneratedRegex(@"[0-9]")]
    private static partial Regex Number();
}