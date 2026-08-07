using CashFlow.Communication.Responses.Expenses;

namespace CashFlow.Application.UseCases.Expenses.GetAll;

public interface IGetAllExpensesUseCase
{
    public Task<ResponseExpensesJson> Execute();
}
