using CashFlow.Application.UseCases.Users.Register;
using CommonTestUtilities.Cryptography;
using CommonTestUtilities.Mapper;
using CommonTestUtilities.Repositories;
using CommonTestUtilities.Requests;
using CommonTestUtilities.Token;
using Shouldly;

namespace UseCases.Tests.Users.Register;

public class RegisterUserUseCaseTest
{
    [Fact]
    public async Task Success()
    {
        // Arrange
        var request = RequestRegisterUserJsonBuilder.Build();
        var useCase = CreateRegisterUserUseCase();

        var result = await useCase.Execute(request);

        result.ShouldNotBeNull();
        result.Name.ShouldBe(request.Name);
        result.Token.ShouldNotBeNullOrWhiteSpace();
    }

    private RegisterUserUseCase CreateRegisterUserUseCase()
    {
        var mapper = MapperBuilder.Build();
        var unitOfWork = UnitOfWorkBuilder.Build();
        var usersWriteOnlyRepository = UsersWriteOnlyRepositoryBuilder.Build();
        var passwordHasher = PasswordHasherBuilder.Build();
        var jwtTokenGenerator = JwtTokenGeneratorBuilder.Build();
        var usersReadOnlyRepository = new UsersReadOnlyRepositoryBuilder().Build();

        return new RegisterUserUseCase(unitOfWork, usersReadOnlyRepository, usersWriteOnlyRepository, mapper, passwordHasher, jwtTokenGenerator);
    }
}
