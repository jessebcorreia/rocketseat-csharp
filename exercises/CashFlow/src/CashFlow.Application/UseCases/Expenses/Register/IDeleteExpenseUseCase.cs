namespace CashFlow.Application.UseCases.Expenses.Register;

public interface IDeleteExpenseUseCase
{
    public Task Execute(long id);
}
