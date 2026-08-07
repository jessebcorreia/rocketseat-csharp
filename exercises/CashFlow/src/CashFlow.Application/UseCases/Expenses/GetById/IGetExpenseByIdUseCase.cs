using CashFlow.Communication.Responses.Expenses;

namespace CashFlow.Application.UseCases.Expenses.GetById;

public interface IGetExpenseByIdUseCase
{
    public Task<ResponseExpenseJson> Execute(long id);
}
