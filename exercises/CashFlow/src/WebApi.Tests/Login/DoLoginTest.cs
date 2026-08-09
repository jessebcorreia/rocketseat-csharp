using CashFlow.Communication.Requests.Users;
using Shouldly;
using System.Net;
using System.Net.Http.Json;
using System.Text.Json;

namespace WebApi.Tests.Login;

public class DoLoginTest : IClassFixture<CustomWebApplicationFactory>
{
    private const string METHOD = "api/login";
    private readonly HttpClient _httpClient;
    private readonly string _name;
    private readonly string _email;
    private readonly string _rawPassword;

    public DoLoginTest(CustomWebApplicationFactory webApplicationFactory)
    {
        _httpClient = webApplicationFactory.CreateClient();
        _name = webApplicationFactory.GetName();
        _email = webApplicationFactory.GetEmail();
        _rawPassword = webApplicationFactory.GetRawPassword();
    }

    [Fact]
    public async Task Success()
    {
        var request = new RequestLoginJson
        {
            Email = _email,
            Password = _rawPassword,
        };

        var httpResponse = await _httpClient.PostAsJsonAsync(METHOD, request);
        var responseStream = await httpResponse.Content.ReadAsStreamAsync();
        var responseJson = await JsonDocument.ParseAsync(responseStream);

        httpResponse.StatusCode.ShouldBe(HttpStatusCode.OK);
        responseJson.RootElement.GetProperty("name").GetString().ShouldBe(_name);
        responseJson.RootElement.GetProperty("token").GetString().ShouldNotBeNullOrEmpty();
    }
}
