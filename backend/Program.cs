using backend.Register.Domain.Repositories;
using backend.Register.Domain.Services;
using backend.Register.Persistence.Context;
using backend.Register.Persistence.Repositories;
using backend.Register.Services;
using backend.Register.Mapping;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Database Connection
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(
    options => options.UseMySQL(connectionString)
        .LogTo(Console.WriteLine, LogLevel.Information)
        .EnableSensitiveDataLogging()
        .EnableDetailedErrors());



// Add lower case routes
builder.Services.AddRouting(
    options => options.LowercaseUrls = true);

// Dependency Injection Configuration
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IClientService, ClientServiceImpl>();
builder.Services.AddScoped<IBusinessService, BusinessServiceImpl>();
builder.Services.AddScoped<IBusinessRepository, BusinessRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWorkRepository>();

// AutoMapper Configuration
builder.Services.AddAutoMapper(
    typeof(ModelToResourceProfile), 
    typeof(ResourceToModelProfile));



var app = builder.Build();

// Validation for Ensuring Database Objects are created

using (var scope = app.Services.CreateScope())
using (var context = scope.ServiceProvider.GetService<AppDbContext>())
{
    context.Database.EnsureCreated();
}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();