var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// https://docs.fluentvalidation.net/en/latest/testing.html#test-extensions
// builder.Services.AddScoped<IValidator<BillingTermsDto>, BillingTermsDtoValidator>();
// Automatic registration:
// builder.Services.AddValidatorsFromAssembly(Assembly.GetCallingAssembly());

var app = builder.Build();

app.MapControllers();
app.Run();
