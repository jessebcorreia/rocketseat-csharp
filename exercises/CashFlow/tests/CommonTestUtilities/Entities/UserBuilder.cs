using Bogus;
using CashFlow.Domain.Entities;
using CommonTestUtilities.Cryptography;

namespace CommonTestUtilities.Entities;

public class UserBuilder
{
    public static User Build()
    {
        var passwordHasher = new PasswordHasherBuilder().Build();

        return new Faker<User>()
            .RuleFor(user => user.Id, _ => 1)
            .RuleFor(user => user.Name, (Faker faker) => faker.Person.FirstName)
            .RuleFor(user => user.Email, (Faker faker, User user) => faker.Internet.Email(user.Name))
            .RuleFor(user => user.Password, (Faker _, User user) => passwordHasher.Hash(user.Password))
            .RuleFor(user => user.UserIdentifier, _ => Guid.NewGuid());
    }
}
