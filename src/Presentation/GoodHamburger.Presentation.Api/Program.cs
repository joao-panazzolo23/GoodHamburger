using GoodHamburger.Application.Extensions;
using GoodHamburger.Infrastructure.PostgreSqlDapper;
using GoodHamburger.Presentation.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddDatabase()
    .AddDocumentation(builder.Environment)
    .AddValidators()
    .AddExceptions()
    .AddMediatorService()
    .AddControllerWithOptions()
    .AddApplicationServices()
    .AddQueryRepositories()
    ;

var app = builder.Build();

app.UseScalarInterface()
    .UseHttpsRedirection()
    .UseExceptionHandler()
    .UseDatabase()
    .UseControllers();

app.Run();