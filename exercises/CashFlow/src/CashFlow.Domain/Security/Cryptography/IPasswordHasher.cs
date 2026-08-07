namespace CashFlow.Domain.Security.Cryptography;

public interface IPasswordHasher
{
    string Hash(string password);
}
