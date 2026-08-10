using Microsoft.OpenApi.Models;

namespace CashFlow.Api.Extensions;

public static class OpenApiExtension
{
    public static IServiceCollection AddOpenApiConfiguration(
        this IServiceCollection services)
    {
        services.AddOpenApi(options =>
        {
            options.AddDocumentTransformer((document, context, cancellationToken) =>
            {
                document.Components ??= new();
                document.Components.SecuritySchemes ??= new Dictionary<string, OpenApiSecurityScheme>();
                document.Components.SecuritySchemes["Bearer"] =
                    new OpenApiSecurityScheme
                    {
                        Type = SecuritySchemeType.Http,
                        Scheme = "bearer",
                        BearerFormat = "JWT"
                    };

                return Task.CompletedTask;
            });
        });

        return services;
    }
}
