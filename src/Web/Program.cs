using System.Reflection;
using FluentValidation;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// https://docs.fluentvalidation.net/en/latest/configuring.html#placeholders
builder.Services
    .AddFluentValidationAutoValidation()
    .AddFluentValidationClientsideAdapters()
    .AddValidatorsFromAssembly(Assembly.GetCallingAssembly());

var app = builder.Build();

app.MapControllers();
app.Run();
