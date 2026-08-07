using AutoMapper;
using CashFlow.Communication.Requests.Users;
using CashFlow.Communication.Responses.Users;
using CashFlow.Domain.Entities;
using CashFlow.Exception.ExceptionsBase;

namespace CashFlow.Application.UseCases.Users.Register;

public class RegisterUserUseCase : IRegisterUserUseCase
{
    private readonly IMapper _mapper;

    public RegisterUserUseCase(IMapper mapper)
    {
        _mapper = mapper;
    }

    public async Task<ResponseRegisterUserJson> Execute(RequestRegisterUserJson request)
    {
        Validate(request);

        var user = _mapper.Map<User>(request);

        return new ResponseRegisterUserJson
        {
            Name = user.Name
        };
    }

    private void Validate(RequestRegisterUserJson request)
    {
        var result = new RegisterUserValidator().Validate(request);

        if (result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
