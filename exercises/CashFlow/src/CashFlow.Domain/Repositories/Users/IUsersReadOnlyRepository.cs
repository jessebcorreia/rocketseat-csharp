namespace CashFlow.Domain.Repositories.Users;

public interface IUsersReadOnlyRepository
{
    Task<bool> UserExistsWithEmail(string email);
}
