using CashFlow.Domain.Entities;

namespace CashFlow.Domain.Repositories.Expenses;

public interface IExpensesReadOnlyRepository
{
    Task<List<Expense>> GetAll(long userId);
    Task<Expense?> GetById(long expenseId, long userId);
    Task<List<Expense>> FilterByMonth(DateOnly date);
}
