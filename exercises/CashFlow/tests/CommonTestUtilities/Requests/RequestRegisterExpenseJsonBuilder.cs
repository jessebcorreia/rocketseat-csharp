using Bogus;
using CashFlow.Communication.Enums;
using CashFlow.Communication.Requests;

namespace CommonTestUtilities.Requests;

public class RequestRegisterExpenseJsonBuilder
{
    public static RequestRegisterExpenseJson Build()
    {
        // Precisei tipar o Faker explicitamente porque o IntelliSense não estava inferindo corretamente o tipo da lambda (aparentemente é um bug no visual studio)
        return new Faker<RequestRegisterExpenseJson>()
            .RuleFor(r => r.Title, (Bogus.Faker f) => f.Commerce.ProductName())
            .RuleFor(r => r.Description, (Bogus.Faker f) => f.Commerce.ProductDescription())
            .RuleFor(r => r.Date, (Bogus.Faker f) => f.Date.Past())
            .RuleFor(r => r.PaymentType, (Bogus.Faker f) => f.PickRandom<PaymentType>())
            .RuleFor(r => r.Amount, (Bogus.Faker f) => f.Random.Decimal(min: 1, max: 1000));
    }
}
