using Bogus;
using CashFlow.Communication.Requests.Users;

namespace CommonTestUtilities.Requests;

public class RequestLoginJsonBuilder
{
    public static RequestLoginJson Build()
    {
        // Precisei tipar o Faker explicitamente porque o IntelliSense não estava inferindo corretamente o tipo da lambda (aparentemente é um bug no visual studio)
        return new Faker<RequestLoginJson>()
            .RuleFor(request => request.Email, (Faker faker) => faker.Internet.Email())
            .RuleFor(request => request.Password, (Faker faker) => faker.Internet.Password(prefix: "!Aa1"));
    }
}
