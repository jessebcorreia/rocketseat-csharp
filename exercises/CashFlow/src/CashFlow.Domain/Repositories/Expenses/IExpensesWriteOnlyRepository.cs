using CashFlow.Domain.Entities;

namespace CashFlow.Domain.Repositories.Expenses;

public interface IExpensesWriteOnlyRepository
{
    Task Add(Expense expense);
    /// <summary>
    /// Returns true if the deletion was successful; otherwise, returns false.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<Boolean> Delete(long id);
}
