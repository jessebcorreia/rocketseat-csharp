using AutoMapper;
using CashFlow.Communication.Requests.Users;
using CashFlow.Communication.Responses.Users;
using CashFlow.Domain.Repositories.Users;
using CashFlow.Domain.Security.Cryptography;
using CashFlow.Domain.Security.Tokens;
using CashFlow.Exception.ExceptionsBase;

namespace CashFlow.Application.UseCases.Users.Login;

public class DoLoginUseCase : IDoLoginUseCase
{
    private readonly IUsersReadOnlyRepository _repository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IAccessTokenGenerator _accesTokenGenerator;


    public DoLoginUseCase(IUsersReadOnlyRepository repository, IMapper mapper, IPasswordHasher passwordHasher, IAccessTokenGenerator accesTokenGenerator)
    {
        _repository = repository;
        _passwordHasher = passwordHasher;
        _accesTokenGenerator = accesTokenGenerator;
    }

    public async Task<ResponseRegisteredUserJson> Execute(RequestLoginJson request)
    {
        var user = await _repository.GetUserByEmail(request.Email);
        var errors = new List<string>();

        if (user is null)
            throw new InvalidLoginException();

        var isPasswordValid = _passwordHasher.Verify(request.Password, user.Password);
        if (isPasswordValid == false)
            throw new InvalidLoginException();

        return new ResponseRegisteredUserJson
        {
            Name = user.Name,
            Token = _accesTokenGenerator.Generate(user),
        };
    }
}
