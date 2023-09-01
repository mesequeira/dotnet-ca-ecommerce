using Application;
using Application.Options;
using Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.Text;
using WebApi.Dependencies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services
        .AddApplication()
        .AddInfrastructure(builder.Configuration)
        .AddJwtAuthorization(builder.Configuration);

builder.Host
    .UseSerilog((ctx, cfg) => 
        cfg.ReadFrom.Configuration(ctx.Configuration));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.MapControllers();

app.UseAuthentication();

app.UseAuthorization();


app.UseCors(builder =>
{
    builder.WithOrigins("http://localhost:5173") // Cambia esto al dominio correcto
           .AllowAnyHeader()
           .AllowAnyMethod()
           .AllowCredentials(); // Si es necesario incluir cookies en las solicitudes
});

app.Run();
