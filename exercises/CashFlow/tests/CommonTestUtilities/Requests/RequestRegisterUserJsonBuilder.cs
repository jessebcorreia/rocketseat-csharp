using Bogus;
using CashFlow.Communication.Requests.Users;

namespace CommonTestUtilities.Requests;

public class RequestRegisterUserJsonBuilder
{
    public static RequestRegisterUserJson Build()
    {
        // Precisei tipar o Faker explicitamente porque o IntelliSense não estava inferindo corretamente o tipo da lambda (aparentemente é um bug no visual studio)
        return new Faker<RequestRegisterUserJson>()
            .RuleFor(request => request.Name, (Faker faker) => faker.Person.FirstName)
            .RuleFor(request => request.Email, (Faker faker, RequestRegisterUserJson user) => faker.Internet.Email(user.Name))
            .RuleFor(request => request.Password, (Faker faker) => faker.Internet.Password(prefix: "@Aa1"));
    }
}
