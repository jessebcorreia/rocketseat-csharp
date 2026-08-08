using CashFlow.Domain.Entities;

namespace CashFlow.Domain.Repositories.Users;

public interface IUsersReadOnlyRepository
{
    Task<bool> UserExistsWithEmail(string email);
    Task<User?> GetUserByEmail(string email);
}
