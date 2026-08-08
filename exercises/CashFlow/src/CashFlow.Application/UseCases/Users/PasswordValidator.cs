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
        var errors = ValidatePassword(password);

        if (errors.Count > 0)
        {
            context.MessageFormatter.AppendArgument(
                ERROR_MESSAGE_KEY,
                string.Join(Environment.NewLine, errors));
            return false;
        }

        return true;
    }

    private static List<string> ValidatePassword(string password)
    {
        var errors = new List<string>();

        if (string.IsNullOrWhiteSpace(password))
            errors.Add("Password is required.");

        if (password.Length < 8)
            errors.Add("Password must be at least 8 characters long.");

        if (!UppercaseLetter().IsMatch(password))
            errors.Add("Password must contain at least one uppercase letter.");

        if (!LowercaseLetter().IsMatch(password))
            errors.Add("Password must contain at least one lowercase letter.");

        if (!Number().IsMatch(password))
            errors.Add("Password must contain at least one number.");

        if (!SpecialCharacter().IsMatch(password))
            errors.Add("Password must contain at least one special character.");

        return errors;
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