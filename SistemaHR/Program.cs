using Microsoft.EntityFrameworkCore;
using SistemaHR.Data;
using SistemaHR.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Pegamos a Connection String do appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Registramos o DbContext para Injeção de Dependência
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddScoped<IFuncionarioRepository, FuncionarioRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
