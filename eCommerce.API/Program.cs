// Infrastructure
using eCommerce.Infrastructure;

// Core
using eCommerce.Core;
using eCommerce.Core.Map;
using eCommerce.Core.Entity;


// Exten library
using eCommerce.API.Middlewares;
using System.Text.Json.Serialization;
using FluentValidation;
using FluentValidation.AspNetCore;


var builder = WebApplication.CreateBuilder(args);

// Add Infrastructure and Core services
builder.Services.AddInfrastruction();
builder.Services.AddCore();

// Add Controller to service collection
builder.Services.AddControllers().AddJsonOptions(
    options => {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

// Mapper 
builder.Services.AddAutoMapper(typeof(ApplicationUserMappingProfile).Assembly);


// Add FluentValidations
builder.Services.AddFluentValidationAutoValidation();

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
