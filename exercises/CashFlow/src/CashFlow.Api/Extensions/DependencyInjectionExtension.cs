using CashFlow.Api.Filters;
using CashFlow.Api.Token;
using CashFlow.Domain.Security.Tokens;

namespace CashFlow.Api.Extensions;

public static class DependencyInjectionExtension
{
    public static IServiceCollection AddApi(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddControllers();
        services.AddRouting(option => option.LowercaseUrls = true);
        services.AddMvc(options => options.Filters.Add<ExceptionFilter>());
        services.AddHttpContextAccessor();
        services.AddScoped<ITokenProvider, HttpContextTokenValue>();
        services.AddAuthenticationConfiguration(configuration);
        services.AddOpenApiConfiguration();

        return services;
    }
}
