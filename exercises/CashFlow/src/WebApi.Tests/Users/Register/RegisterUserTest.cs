using CashFlow.Exception;
using CommonTestUtilities.Requests;
using Shouldly;
using System.Globalization;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using WebApi.Tests.InlineData;

namespace WebApi.Tests.Users.Register;

public class RegisterUserTest : IClassFixture<CustomWebApplicationFactory>
{
    private const string METHOD = "api/users";
    private readonly HttpClient _httpClient;

    public RegisterUserTest(CustomWebApplicationFactory webApplicationFactory)
    {
        _httpClient = webApplicationFactory.CreateClient();
    }

    [Fact]
    public async Task Success()
    {
        var request = RequestRegisterUserJsonBuilder.Build();
        var httpResponse = await _httpClient.PostAsJsonAsync(METHOD, request);
        var responseStream = await httpResponse.Content.ReadAsStreamAsync();
        var responseJson = await JsonDocument.ParseAsync(responseStream);

        httpResponse.StatusCode.ShouldBe(HttpStatusCode.Created);
        responseJson.RootElement.GetProperty("name").GetString().ShouldBe(request.Name);
        responseJson.RootElement.GetProperty("token").GetString().ShouldNotBeNullOrEmpty();
    }

    [Theory]
    [ClassData(typeof(CultureInlineDataTest))]
    public async Task ErrorEmptyName(string culture)
    {
        var request = RequestRegisterUserJsonBuilder.Build();
        request.Name = string.Empty;

        var cultureInfo = new CultureInfo(culture);
        var acceptedLanguage = new StringWithQualityHeaderValue(cultureInfo.ToString());

        _httpClient.DefaultRequestHeaders.AcceptLanguage.Clear();
        _httpClient.DefaultRequestHeaders.AcceptLanguage.Add(acceptedLanguage);

        var expectedErrorMessage = ResourceErrorMessages.ResourceManager.GetString("EMPTY_NAME", cultureInfo);

        var httpResponse = await _httpClient.PostAsJsonAsync(METHOD, request);
        var responseStream = await httpResponse.Content.ReadAsStreamAsync();
        var responseJson = await JsonDocument.ParseAsync(responseStream);
        var errors = responseJson.RootElement
            .GetProperty("errorMessages")
            .EnumerateArray()
            .Select(error => error.GetString());

        httpResponse.StatusCode.ShouldBe(HttpStatusCode.BadRequest);
        errors.ShouldHaveSingleItem();
        errors.Contains(expectedErrorMessage).ShouldBeTrue();
    }
}
