
using eCommerce.API.Middlewares;
using eCommerce.Core;
using eCommerce.Core.Mappers;
using eCommerce.Infrastructure;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastruction();
builder.Services.AddCore();
//Add the controllers to the services collection
builder.Services.AddControllers().AddJsonOptions(
    options =>
    {
        options.JsonSerializerOptions.Converters.Add(
            new JsonStringEnumConverter()
        );
    }
    );
builder.Services.AddAutoMapper(typeof(ApplicationUserMappingProfile));
//Fluent Validation can be added here if needed
builder.Services.AddFluentValidationAutoValidation();

//Build the app 
var app = builder.Build();

app.UseExceptionHandlingMiddleware();
//Configure the HTTP request pipeline

//Routing
app.UseRouting();
//Authentication and Authorization
app.UseAuthentication();
app.UseAuthorization();
//Controller routes
app.MapControllers();
app.Run();
