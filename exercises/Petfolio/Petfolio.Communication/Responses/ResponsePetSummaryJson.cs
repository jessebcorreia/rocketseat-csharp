using Petfolio.Communication.Enums;

namespace Petfolio.Communication.Responses;

public class ResponsePetSummaryJson
{
    public int id { get; set; }
    public string Name { get; set; } = string.Empty;
    public PetType Type { get; set; }
}
