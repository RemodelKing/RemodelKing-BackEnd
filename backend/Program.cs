using backend.Register.Domain.Repositories;
using backend.Register.Domain.Services;
using backend.Register.Persistence.Context;
using backend.Register.Persistence.Repositories;
using backend.Register.Services;
using backend.Register.Mapping;
using backend.RemodelKing.Domain.Repositories;
using backend.RemodelKing.Domain.Services;
using backend.RemodelKing.Persistence.Repositories;
using backend.RemodelKing.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var  MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
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

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy  =>
        {
            policy.WithOrigins("http://localhost:3000").AllowAnyHeader()
                .AllowAnyMethod();
        });
});

// Add lower case routes
builder.Services.AddRouting(
    options => options.LowercaseUrls = true);

// Dependency Injection Configuration
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IClientService, ClientServiceImpl>();
builder.Services.AddScoped<IBusinessService, BusinessServiceImpl>();
builder.Services.AddScoped<IBusinessRepository, BusinessRepository>();;
builder.Services.AddScoped<IBusinessProjectService, BusinessProjectServiceImpl>();
builder.Services.AddScoped<IBusinessProjectRepository, BusinessProjectRepository>();
builder.Services.AddScoped<IActivityRepository, ActivityRepository>();
builder.Services.AddScoped<IActivityService, ActivityServiceImpl>();
builder.Services.AddScoped<IPortfolioRepository, PortfolioRepository>();
builder.Services.AddScoped<IPortfolioService, PortfolioServiceImpl>();
builder.Services.AddScoped<IRequestService, RequestServiceImpl>();
builder.Services.AddScoped<IRequestRepository, RequestRepository>();
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
builder.Services.AddScoped<IPaymentService, PaymentServiceImpl>();
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
app.UseStaticFiles();
app.UseRouting();
app.UseCors(MyAllowSpecificOrigins);
app.UseAuthorization();

app.MapControllers();

app.Run();