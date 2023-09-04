using Application;
using Infrastructure;
using Serilog;
using WebApi.Dependencies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
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

builder.Services.AddControllers();

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


app.UseCors(builder => builder
                        .WithOrigins("http://localhost:5173") 
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials());

app.Use((httpContext, next) => // For the oauth2-less!
{
    if (httpContext.Request.Headers["X-Authorization"].Any())
        httpContext.Request.Headers.Add("Authorization", httpContext.Request.Headers["X-Authorization"]);

    return next();
});

app.Run();
