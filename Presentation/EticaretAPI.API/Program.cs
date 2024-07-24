using EticaretAPI.Persistance;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore.Design;
using EticaretAPI.Application.Repositories;
using EticaretAPI.Persistance.Repositories;
using EticaretAPI.API;

var builder = WebApplication.CreateBuilder(args);

// Servisleri ekle
builder.Services.AddPersistenceServices();

builder.Services.AddCors(options => options.AddDefaultPolicy(policy => policy.WithOrigins("http://localhost:4200", "https://localhost:4200").AllowAnyHeader().AllowAnyMethod()));


builder.Services.AddControllers();

// Swagger/OpenAPI yapýlandýrmasý
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// HTTP istek ardýþýk düzenini yapýlandýrýn
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseMiddleware<AbstractExceptionHandlerMiddleware>();


app.UseAuthorization();

app.MapControllers();


app.Run();
