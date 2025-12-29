using APIBiblioteca.Entidades;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//Area de servicios

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<BibliotecaContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("conexion")));

//Autenticacion y autorizacion
builder.Services.AddIdentityCore<IdentityUser>()//
    .AddEntityFrameworkStores<BibliotecaContext>() 
    .AddDefaultTokenProviders();


builder.Services.AddScoped<UserManager<IdentityUser>>(); // para gestionar usuarios (crear, eliminar, actualizar)
builder.Services.AddScoped<SignInManager<IdentityUser>>(); // para gestionar inicios de sesion (autenticar usuarios)
builder.Services.AddHttpContextAccessor();
builder.Services.AddAuthentication().AddJwtBearer(opciones =>
{
    opciones.MapInboundClaims = false;
    opciones.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer=false,
            ValidateAudience=false,
            ValidateLifetime=true,
            ValidateIssuerSigningKey=true,
            IssuerSigningKey= new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["llavejwt"])),
            ClockSkew=TimeSpan.Zero
        };

    }
    
    );
//Fin area autenticacion y autorizacion

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
