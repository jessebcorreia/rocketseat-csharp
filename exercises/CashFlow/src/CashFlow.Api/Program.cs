using CashFlow.Api.Extensions;
using CashFlow.Application;
using CashFlow.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApi(builder.Configuration);
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

app.ConfigureMiddleware();
app.ConfigureEndpoints();

await app.MigrateDatabase();

app.Run();

public partial class Program { }
