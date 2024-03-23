using HouseFunSKA.Data;
using HouseFunSKA.Repositories;
using HouseFunSKA.Repositories.Interface;
using HouseFunSKA.Services;
using HouseFunSKA.Services.Interface;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
var connectionString = configuration.GetConnectionString("DefaultConnectString");
builder.Services.AddDbContext<NorthwindContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();

var app = builder.Build();

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