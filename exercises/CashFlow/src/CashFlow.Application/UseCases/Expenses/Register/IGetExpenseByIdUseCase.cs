using CashFlow.Communication.Responses;

namespace CashFlow.Application.UseCases.Expenses.Register;

public interface IGetExpenseByIdUseCase
{
    public Task<ResponseExpenseJson> Execute(long id);
}
