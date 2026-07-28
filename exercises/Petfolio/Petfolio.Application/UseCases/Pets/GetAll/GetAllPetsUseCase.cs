using Petfolio.Communication.Enums;
using Petfolio.Communication.Responses;

namespace Petfolio.Application.UseCases.Pets.GetAll;

public class GetAllPetsUseCase
{
    public ResponseAllPetsJson Execute()
    {
        var pet1 = new ResponsePetSummaryJson()
        {
            id = 1,
            Name = "John Dog",
            Type = PetType.Dog
        };

        var pet2 = new ResponsePetSummaryJson()
        {
            id = 2,
            Name = "Nick",
            Type = PetType.Cat,
        };

        var pets = new List<ResponsePetSummaryJson>
        {
            pet1,
            pet2,
        };

        var response = new ResponseAllPetsJson()
        {
            Pets = pets
        };

        return response;
    }
}
