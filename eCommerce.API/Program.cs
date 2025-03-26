using eCommerce.Infrastructure;
using eCommerce.Core;
using eCommerce.API.Middlewares;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add Infrastructure and Core services
builder.Services.AddInfrastruction();
builder.Services.AddCore();

// Add Controller to service collection
builder.Services.AddControllers().AddJsonOptions(
    options => {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});


var app = builder.Build();

// Exception
app.UseExceptionHandlingMiddleware();

// Routing
app.UseRouting();

// Auth
app.UseAuthentication();
app.UseAuthorization();

// Controller routes
app.MapControllers();   
app.Run();
