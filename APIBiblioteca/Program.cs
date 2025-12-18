using APIBiblioteca.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//Area de servicios

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<BibliotecaContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("conexion")));

//Fin area de servicios

var app = builder.Build();

//Area de middlewares
app.UseSwagger();
app.UseSwaggerUI();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//Fin area de middlewares


app.Run();
