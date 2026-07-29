using CashFlow.Api.Filters;
using CashFlow.Api.Middleware;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddRouting(option => option.LowercaseUrls = true);
builder.Services.AddMvc(options => options.Filters.Add<ExceptionFilter>());

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();

}

app.UseMiddleware<CultureMiddleware>();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
