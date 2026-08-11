using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories.Expenses;
using Microsoft.EntityFrameworkCore;

namespace CashFlow.Infrastructure.DataAccess.Repositories;

internal class ExpensesRepository : IExpensesWriteOnlyRepository, IExpensesReadOnlyRepository, IExpensesUpdateOnlyRepository
{
    private readonly CashFlowDbContext _dbContext;

    public ExpensesRepository(CashFlowDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Add(Expense expense)
    {
        await _dbContext.Expenses.AddAsync(expense);
    }

    public async Task Delete(long id)
    {
        var expense = await _dbContext.Expenses.FindAsync(id);
        _dbContext.Expenses.Remove(expense!);
    }

    public async Task<List<Expense>> GetAll(long userId)
    {
        return await _dbContext.Expenses.AsNoTracking().Where(expense => expense.UserId == userId).ToListAsync();
    }

    async Task<Expense?> IExpensesReadOnlyRepository.GetById(long expenseId, long userId)
    {
        return await _dbContext.Expenses.AsNoTracking().FirstOrDefaultAsync(expense => expense.Id == expenseId && expense.UserId == userId);
    }

    async Task<Expense?> IExpensesUpdateOnlyRepository.GetById(long expenseId, long userId)
    {
        return await _dbContext.Expenses.FirstOrDefaultAsync(expense => expense.Id == expenseId && expense.UserId == userId);
    }

    public void Update(Expense expense)
    {
        _dbContext.Expenses.Update(expense);
    }

    public async Task<List<Expense>> FilterByMonth(DateOnly date, long userId)
    {
        var startDate = new DateTime(year: date.Year, month: date.Month, day: 1).Date;
        var daysInMonth = DateTime.DaysInMonth(year: date.Year, month: date.Month);
        var endDate = new DateTime(year: date.Year, month: date.Month, day: daysInMonth, hour: 23, minute: 59, second: 59);

        return await _dbContext
            .Expenses
            .AsNoTracking()
            .Where(expense => expense.Date >= startDate && expense.Date <= endDate && expense.UserId == userId)
            .OrderBy(expense => expense.Date)
            .ThenBy(expense => expense.Title)
            .ToListAsync();
    }
}
