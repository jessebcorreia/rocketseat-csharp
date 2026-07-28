using Petfolio.Communication.Enums;
using Petfolio.Communication.Responses;

namespace Petfolio.Application.UseCases.Pets.GetById;

public class GetPetByIdUseCase
{
    public ResponsePetJson Execute(int id)
    {
        var pet = new ResponsePetJson()
        {
            Id = 1,
            Name = "John Dog",
            Type = PetType.Dog,
            Birthday = new DateTime(year: 2026, month: 04, day: 25),
        };

        return pet;
    }
}
