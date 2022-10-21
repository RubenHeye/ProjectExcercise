using Microsoft.EntityFrameworkCore;
using ProjectExcercise.Infrastructure;
using ProjectExcercise.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//builder.Services.AddInfrastructure();
builder.Services.AddDbContext<MovieDbContext>(options =>
                options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ProjectExcercise;Trusted_Connection=True;MultipleActiveResultSets=true"));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
