using CashFlow.Communication.Requests.Users;
using CashFlow.Communication.Responses.Users;

namespace CashFlow.Application.UseCases.Users.Register;

public interface IRegisterUserUseCase
{
    Task<ResponseRegisterUserJson> Execute(RequestRegisterUserJson request);
}
