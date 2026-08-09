using CashFlow.Domain.Security.Cryptography;
using Moq;

namespace CommonTestUtilities.Cryptography;

public class PasswordHasherBuilder
{
    public static IPasswordHasher Build()
    {
        var mock = new Mock<IPasswordHasher>();
        var hashedPassword = "$2a$11$inqi3SR0RqIWJlHvBFcyPePPGhfnBVkwyi/SrfgcYjBa1KeUzDQRy";

        mock.Setup(passwordHasher => passwordHasher.Hash(It.IsAny<string>()))
            .Returns(hashedPassword);

        return mock.Object;
    }
}
