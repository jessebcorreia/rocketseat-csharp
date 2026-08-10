using CashFlow.Domain.Security.Tokens;

namespace CashFlow.Api.Token;

public class HttpContextTokenValue : ITokenProvider
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public HttpContextTokenValue(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public string TokenOnRequest()
    {
        var authorization = _httpContextAccessor.HttpContext!.Request.Headers.Authorization.ToString();
        // "Bearer string..." precisa remover o Bearer da string

        return authorization["Bearer ".Length..].Trim();
    }
}
