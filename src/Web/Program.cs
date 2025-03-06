using FluentValidation;
using Web.Models;
using Web.Validators;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddScoped<IValidator<BillingTermsDto>, BillingTermsDtoValidator>();

// Automatic registration:
// builder.Services.AddValidatorsFromAssembly(Assembly.GetCallingAssembly());

var app = builder.Build();

app.MapControllers();
app.Run();
