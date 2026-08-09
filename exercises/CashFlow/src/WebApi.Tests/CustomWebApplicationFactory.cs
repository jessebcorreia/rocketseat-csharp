using CashFlow.Domain.Entities;
using CashFlow.Domain.Security.Cryptography;
using CashFlow.Infrastructure.DataAccess;
using CommonTestUtilities.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace WebApi.Tests;

public class CustomWebApplicationFactory : WebApplicationFactory<Program>
{
    private User _user = null!;
    private string _rawPassword = string.Empty;

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.UseEnvironment("Test")
            .ConfigureServices(services =>
            {
                var provider = services.AddEntityFrameworkInMemoryDatabase().BuildServiceProvider();
                services.AddDbContext<CashFlowDbContext>(config =>
                {
                    config.UseInMemoryDatabase("InMemoryDbForTesting");
                    config.UseInternalServiceProvider(provider);
                });

                var scope = services.BuildServiceProvider().CreateScope();
                var dbContext = scope.ServiceProvider.GetRequiredService<CashFlowDbContext>();
                var passwordHasher = scope.ServiceProvider.GetRequiredService<IPasswordHasher>();

                StartDatabase(dbContext, passwordHasher);
            });
    }

    public string GetEmail() => _user.Email;

    public string GetName() => _user.Name;

    public string GetRawPassword() => _rawPassword;

    private void StartDatabase(CashFlowDbContext dbContext, IPasswordHasher passwordHasher)
    {
        _user = UserBuilder.Build();
        _rawPassword = _user.Password;
        _user.Password = passwordHasher.Hash(_rawPassword);

        dbContext.Users.Add(_user);
        dbContext.SaveChanges();
    }
}
