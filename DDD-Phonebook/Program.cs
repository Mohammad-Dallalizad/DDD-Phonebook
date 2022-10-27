using ApplicationCore.Interfaces;
using ApplicationCore.Services;
using DDD_Phonebook;
using DDD_Phonebook.Dtos.Validators;
using DDD_Phonebook.Middlewares;
using FluentValidation;
using FluentValidation.AspNetCore;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

var configuration = builder.Configuration;

var logger = new LoggerConfiguration()
  .ReadFrom.Configuration(builder.Configuration)
  .Enrich.FromLogContext()
  .CreateLogger();

builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

// Add services to the container.
//services.AddDbContext<PhoneBookDbContext>(c => c.UseSqlServer(configuration.GetConnectionString("SqlServer")));
services.AddDbContext<PhoneBookDbContext>(c =>c.UseInMemoryDatabase("PhoneBook"));

services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
services.AddScoped<IContactService, ContactService>();

const string CORS_POLICY = "CorsPolicy";
services.AddCors(options =>
{
    options.AddPolicy(name: CORS_POLICY,
        builder => builder
                  .AllowAnyMethod()
                  .AllowAnyHeader()
                  .SetIsOriginAllowed(origin => true)  // Allow any origin
                  .AllowCredentials());                // Allow credentials
});

services.AddControllers();

services.AddFluentValidationAutoValidation();
services.AddValidatorsFromAssemblyContaining<ContactValidator>();

services.AddAutoMapper(typeof(MappingProfile).Assembly);


services.AddEndpointsApiExplorer();
services.AddSwaggerGen(p => { 
    p.SwaggerDoc("v1", new OpenApiInfo { Title = "DDD-PhoneBook", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseMiddleware(typeof(ExceptionHandlingMiddleware));

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "DDD-PhoneBook");
});

app.Run();
