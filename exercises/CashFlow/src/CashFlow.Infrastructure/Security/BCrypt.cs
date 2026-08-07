using CashFlow.Domain.Security.Cryptography;
using BC = BCrypt.Net.BCrypt;

namespace CashFlow.Infrastructure.Security;

public class BCrypt : IPasswordHasher
{
    public string Hash(string password)
    {
        return BC.HashPassword(password);
    }
}
