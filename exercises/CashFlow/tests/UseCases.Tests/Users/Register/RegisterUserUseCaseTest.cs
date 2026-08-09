using CashFlow.Application.UseCases.Users.Register;
using CashFlow.Exception;
using CashFlow.Exception.ExceptionsBase;
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
        var request = RequestRegisterUserJsonBuilder.Build();
        var useCase = CreateRegisterUserUseCase();

        var result = await useCase.Execute(request);

        result.ShouldNotBeNull();
        result.Name.ShouldBe(request.Name);
        result.Token.ShouldNotBeNullOrWhiteSpace();
    }
    [Fact]
    public async Task ErrorEmptyName()
    {
        var request = RequestRegisterUserJsonBuilder.Build();
        request.Name = string.Empty;

        var useCase = CreateRegisterUserUseCase();

        var act = async () => await useCase.Execute(request);

        var thrownException = await act.ShouldThrowAsync<ErrorOnValidationException>();

        thrownException.GetErrors().Count.ShouldBe(1);
        thrownException.GetErrors().ShouldContain(ResourceErrorMessages.EMPTY_NAME);
    }

    [Fact]
    public async Task ErrorEmailAlreadyRegistered()
    {
        var request = RequestRegisterUserJsonBuilder.Build();

        var useCase = CreateRegisterUserUseCase(request.Email);

        var act = async () => await useCase.Execute(request);

        var thrownException = await act.ShouldThrowAsync<ErrorOnValidationException>();

        thrownException.GetErrors().Count.ShouldBe(1);
        thrownException.GetErrors().ShouldContain(ResourceErrorMessages.EMAIL_ALREADY_REGISTERED);
    }

    private static RegisterUserUseCase CreateRegisterUserUseCase(string? email = null)
    {
        var mapper = MapperBuilder.Build();
        var unitOfWork = UnitOfWorkBuilder.Build();
        var passwordHasher = PasswordHasherBuilder.Build();
        var jwtTokenGenerator = JwtTokenGeneratorBuilder.Build();
        var usersWriteOnlyRepository = UsersWriteOnlyRepositoryBuilder.Build();
        var usersReadOnlyRepository = new UsersReadOnlyRepositoryBuilder();

        if (string.IsNullOrWhiteSpace(email) == false)
        {
            usersReadOnlyRepository.UserExistsWithEmail(email);
        }

        return new RegisterUserUseCase(unitOfWork, usersReadOnlyRepository.Build(), usersWriteOnlyRepository, mapper, passwordHasher, jwtTokenGenerator);
    }
}
