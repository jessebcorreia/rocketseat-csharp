using CashFlow.Application.UseCases.Users.Login;
using CashFlow.Domain.Entities;
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

        var useCase = CreateDoLoginUseCase(user);

        var result = await useCase.Execute(request);

        result.ShouldNotBeNull();
        result.Name.ShouldBe(user.Name);
        result.Token.ShouldNotBeNullOrWhiteSpace();
    }

    [Fact]
    public async Task ErrorUserNotFound()
    {

    }

    [Fact]
    public async Task ErrorPasswordDoesNotMatch()
    {

    }

    private static DoLoginUseCase CreateDoLoginUseCase(User user)
    {
        var passwordHasher = PasswordHasherBuilder.Build();
        var jwtTokenGenerator = JwtTokenGeneratorBuilder.Build();
        var usersReadOnlyRepository = new UsersReadOnlyRepositoryBuilder().GetUserByEmail(user).Build();

        return new DoLoginUseCase(usersReadOnlyRepository, passwordHasher, jwtTokenGenerator);
    }
}
