using CashFlow.Application.UseCases.Users.Login;
using CashFlow.Domain.Entities;
using CashFlow.Exception;
using CashFlow.Exception.ExceptionsBase;
using CommonTestUtilities.Cryptography;
using CommonTestUtilities.Entities;
using CommonTestUtilities.Repositories;
using CommonTestUtilities.Requests;
using CommonTestUtilities.Token;
using Shouldly;

namespace UseCases.Tests.Login;

public class DoLoginUseCaseTest
{
    [Fact]
    public async Task Success()
    {
        var user = UserBuilder.Build();
        var request = RequestLoginJsonBuilder.Build();
        request.Email = user.Email;

        var useCase = CreateDoLoginUseCase(user, request.Password);

        var result = await useCase.Execute(request);

        result.ShouldNotBeNull();
        result.Name.ShouldBe(user.Name);
        result.Token.ShouldNotBeNullOrWhiteSpace();
    }

    [Fact]
    public async Task ErrorUserNotFound()
    {
        var user = UserBuilder.Build();
        var request = RequestLoginJsonBuilder.Build();

        var useCase = CreateDoLoginUseCase(user, request.Password);

        var act = async () => await useCase.Execute(request);

        var thrownException = await act.ShouldThrowAsync<InvalidLoginException>();

        thrownException.GetErrors().Count.ShouldBe(1);
        thrownException.GetErrors().ShouldContain(ResourceErrorMessages.INVALID_LOGIN_CREDENTIALS);
    }

    [Fact]
    public async Task ErrorPasswordDoesNotMatch()
    {
        var user = UserBuilder.Build();
        var request = RequestLoginJsonBuilder.Build();
        request.Email = user.Email;

        var useCase = CreateDoLoginUseCase(user);

        var act = async () => await useCase.Execute(request);

        var thrownException = await act.ShouldThrowAsync<InvalidLoginException>();

        thrownException.GetErrors().Count.ShouldBe(1);
        thrownException.GetErrors().ShouldContain(ResourceErrorMessages.INVALID_LOGIN_CREDENTIALS);
    }

    private static DoLoginUseCase CreateDoLoginUseCase(User user, string? password = null)
    {
        var passwordHasher = new PasswordHasherBuilder().Verify(password).Build();
        var jwtTokenGenerator = JwtTokenGeneratorBuilder.Build();
        var usersReadOnlyRepository = new UsersReadOnlyRepositoryBuilder().GetUserByEmail(user).Build();

        return new DoLoginUseCase(usersReadOnlyRepository, passwordHasher, jwtTokenGenerator);
    }
}
