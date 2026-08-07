using AutoMapper;
using CashFlow.Communication.Requests.Users;
using CashFlow.Communication.Responses.Users;
using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories.Users;
using CashFlow.Domain.Security.Cryptography;
using CashFlow.Exception;
using CashFlow.Exception.ExceptionsBase;
using FluentValidation.Results;

namespace CashFlow.Application.UseCases.Users.Register;

public class RegisterUserUseCase : IRegisterUserUseCase
{
    private readonly IMapper _mapper;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IUsersReadOnlyRepository _userReadOnlyRepository;

    public RegisterUserUseCase(IMapper mapper, IPasswordHasher passwordHasher, IUsersReadOnlyRepository userReadOnlyRepository)
    {
        _mapper = mapper;
        _passwordHasher = passwordHasher;
        _userReadOnlyRepository = userReadOnlyRepository;
    }

    public async Task<ResponseRegisterUserJson> Execute(RequestRegisterUserJson request)
    {
        await Validate(request);

        var user = _mapper.Map<User>(request); // password ficou fora do automapper

        user.Password = _passwordHasher.Hash(request.Password);

        return new ResponseRegisterUserJson
        {
            Name = user.Name
        };
    }

    private async Task Validate(RequestRegisterUserJson request)
    {
        var result = new RegisterUserValidator().Validate(request);

        var userExists = await _userReadOnlyRepository.UserExistsWithEmail(request.Email);
        if (userExists)
        {
            result.Errors.Add(new ValidationFailure(string.Empty, ResourceErrorMessages.EMAIL_ALREADY_REGISTERED));
        }

        if (result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
