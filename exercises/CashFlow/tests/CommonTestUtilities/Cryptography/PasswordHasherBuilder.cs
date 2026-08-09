using CashFlow.Domain.Security.Cryptography;
using Moq;

namespace CommonTestUtilities.Cryptography;

public class PasswordHasherBuilder
{
    private readonly Mock<IPasswordHasher> _mock;

    public PasswordHasherBuilder()
    {
        _mock = new Mock<IPasswordHasher>();

        var hashedPassword = "$2a$11$inqi3SR0RqIWJlHvBFcyPePPGhfnBVkwyi/SrfgcYjBa1KeUzDQRy";
        _mock.Setup(passwordHasher => passwordHasher.Hash(It.IsAny<string>()))
            .Returns(hashedPassword);
    }

    public PasswordHasherBuilder Verify(string? password)
    {
        if (string.IsNullOrWhiteSpace(password) == false)
        {
            _mock
                .Setup(passwordHasher =>
                    passwordHasher.Verify(password, It.IsAny<string>()))
                .Returns(true);
        }

        return this;
    }

    public IPasswordHasher Build() => _mock.Object;
}
