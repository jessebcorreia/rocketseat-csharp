using CashFlow.Exception;
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
        var isValid = ValidatePassword(password);

        if (isValid == false)
        {
            context.MessageFormatter.AppendArgument(ERROR_MESSAGE_KEY, ResourceErrorMessages.INVALID_PASSWORD);
            return false;
        }

        return true;
    }

    private static bool ValidatePassword(string password)
    {
        return
            string.IsNullOrWhiteSpace(password) is not true &&
            password.Length >= 8 &&
            UppercaseLetter().IsMatch(password) &&
            LowercaseLetter().IsMatch(password) &&
            Number().IsMatch(password) &&
            SpecialCharacter().IsMatch(password);
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