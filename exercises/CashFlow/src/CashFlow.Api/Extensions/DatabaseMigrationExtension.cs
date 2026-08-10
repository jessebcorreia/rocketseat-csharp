using CashFlow.Infrastructure.Extensions;
using CashFlow.Infrastructure.Migrations;

namespace CashFlow.Api.Extensions;

public static class DatabaseMigrationExtension
{
    public static async Task<WebApplication> MigrateDatabase(this WebApplication app)
    {
        if (app.Configuration.IsTestEnvironment())
            return app;

        await using var scope = app.Services.CreateAsyncScope();

        await DatabaseMigration.MigrateDatabase(scope.ServiceProvider);

        return app;
    }
}
