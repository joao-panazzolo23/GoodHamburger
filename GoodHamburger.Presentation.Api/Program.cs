using GoodHamburger.Presentation.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddDatabase(builder.Configuration)
    .AddDocumentation(builder.Environment);

var app = builder.Build();

app.UseScalarInterface()
    .UseHttpsRedirection();

app.Run();