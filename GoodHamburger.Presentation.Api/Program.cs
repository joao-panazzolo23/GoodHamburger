using GoodHamburger.Application.Shared.Extensions;
using GoodHamburger.Presentation.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddDatabase(builder.Configuration)
    .AddDocumentation(builder.Environment)
    .AddValidators()
    .AddExceptions()
    .AddAllApplicationParts()
    ;

var app = builder.Build();

app.UseScalarInterface()
    .UseHttpsRedirection()
    .UseExceptionHandler()
    .UseDatabase()
    .UseControllers();

app.Run();