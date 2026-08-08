using CashFlow.Application.UseCases.Users;
using CashFlow.Communication.Requests.Users;
using FluentValidation;
using Shouldly;

namespace Validators.Tests.Users;

public class PasswordValidatorTest
{
    [Theory]
    [InlineData("")]
    [InlineData("      ")]
    [InlineData(null)]
    [InlineData("aaaaaaa")]
    [InlineData("aaaaaaaa")]
    [InlineData("AAAAAAAA")]
    [InlineData("Aaaaaaa1")]
    public void ErrorInvalidPassword(string? password)
    {
        // Arrange
        var validator = new PasswordValidator<RequestRegisterUserJson>();

        // Act
        var result = validator.IsValid(new ValidationContext<RequestRegisterUserJson>(new RequestRegisterUserJson()), password!);

        // Assert
        result.ShouldBeFalse();
    }
}
