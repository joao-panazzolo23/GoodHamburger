using GoodHamburger.Application.Extensions;
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
    ;

var app = builder.Build();

app.UseScalarInterface()
    .UseHttpsRedirection()
    .UseExceptionHandler()
    .UseDatabase()
    .UseControllers();

app.Run();