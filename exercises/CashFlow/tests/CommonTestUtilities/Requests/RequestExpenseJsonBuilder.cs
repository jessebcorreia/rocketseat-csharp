using Bogus;
using CashFlow.Communication.Enums;
using CashFlow.Communication.Requests.Expenses;

namespace CommonTestUtilities.Requests;

public class RequestExpenseJsonBuilder
{
    public static RequestExpenseJson Build()
    {
        // Precisei tipar o Faker explicitamente porque o IntelliSense não estava inferindo corretamente o tipo da lambda (aparentemente é um bug no visual studio)
        return new Faker<RequestExpenseJson>()
            .RuleFor(request => request.Title, (Faker faker) => faker.Commerce.ProductName())
            .RuleFor(request => request.Description, (Faker faker) => faker.Commerce.ProductDescription())
            .RuleFor(request => request.Date, (Faker faker) => faker.Date.Past())
            .RuleFor(request => request.PaymentType, (Faker faker) => faker.PickRandom<PaymentType>())
            .RuleFor(request => request.Amount, (Faker faker) => faker.Random.Decimal(min: 1, max: 1000));
    }
}
