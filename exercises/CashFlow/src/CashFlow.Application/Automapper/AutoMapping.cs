using AutoMapper;
using CashFlow.Communication.Requests.Expenses;
using CashFlow.Communication.Requests.Users;
using CashFlow.Communication.Responses.Expenses;
using CashFlow.Domain.Entities;

namespace CashFlow.Application.Automapper;

public class AutoMapping : Profile
{
    public AutoMapping()
    {
        RequestToEntity();
        EntityToResponse();
    }

    private void RequestToEntity()
    {
        CreateMap<RequestExpenseJson, Expense>();
        CreateMap<RequestRegisterUserJson, User>()
            .ForMember(userEntity => userEntity.Password, config => config.Ignore());
    }

    private void EntityToResponse()
    {
        CreateMap<Expense, ResponseRegisterExpenseJson>();
        CreateMap<Expense, ResponseExpenseSummaryJson>();
        CreateMap<Expense, ResponseExpenseJson>();
        CreateMap<User, RequestRegisterUserJson>();
    }
}
