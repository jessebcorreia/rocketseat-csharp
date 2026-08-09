using CashFlow.Domain.Entities;
using CashFlow.Domain.Security.Tokens;
using Moq;

namespace CommonTestUtilities.Token;

public class JwtTokenGeneratorBuilder
{
    public static IAccessTokenGenerator Build()
    {
        var mock = new Mock<IAccessTokenGenerator>();
        var mockToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IkpvaG4iLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9zaWQiOiJhMTc4YTY2NS00Y2QzLTQyZTgtOTQyMC04YjA4Mjg5YzVjZjIiLCJuYmYiOjE3ODYyMzE4MjQsImV4cCI6MTc4NjI5MTgyNCwiaWF0IjoxNzg2MjMxODI0fQ.TpaZ4wmn77e6fG-hZ-iiEBz5sTzAKMdsvWafHXZoUeQ";

        mock.Setup(accessTokenGenerator => accessTokenGenerator.Generate(It.IsAny<User>()))
            .Returns(mockToken);

        return mock.Object;
    }
}
