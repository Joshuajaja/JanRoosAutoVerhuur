using JanRoosAutoVerhuurAPI.Services;
using JanRoosAutoVerhuurAPI.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using JanRoosAutoVerhuurAPI.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<JanRoosAutoVerhuurAPIContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("JanRoosAutoVerhuurAPIContext") ?? throw new InvalidOperationException("Connection string 'JanRoosAutoVerhuurAPIContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<MongoSettings>(
    builder.Configuration.GetSection("MongoSettings"));

builder.Services.AddSingleton<CarRepository>();


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
