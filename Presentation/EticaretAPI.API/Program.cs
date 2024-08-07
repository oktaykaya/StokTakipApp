using EticaretAPI.Persistance;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore.Design;
using EticaretAPI.Application.Repositories;
using EticaretAPI.Persistance.Repositories;
using EticaretAPI.API;
using FluentValidation.AspNetCore;
using EticaretAPI.Application.Validators.Products;
using EticaretAPI.Infrastructure.Filters;
using EticaretAPI.Infrastructure;
using EticaretAPI.Infrastructure.services.Storage.Local;
using EticaretAPI.Infrastructure.Enums;



var builder = WebApplication.CreateBuilder(args);

// Servisleri ekle
builder.Services.AddPersistenceServices();
builder.Services.AddInfrastructureServices();
//builder.Services.AddStorage(StorageType.Azure);
builder.Services.AddStorage(StorageType.Local);

builder.Services.AddCors(options => options.AddDefaultPolicy(policy => policy.WithOrigins("http://localhost:4200", "https://localhost:4200").AllowAnyHeader().AllowAnyMethod()));


builder.Services.AddControllers(options => options.Filters.Add<ValidationFilter>())
    .AddFluentValidation(configuration => configuration.RegisterValidatorsFromAssemblyContaining<CreateProductValidator>())
    .ConfigureApiBehaviorOptions(options => options.SuppressModelStateInvalidFilter = true);

// Swagger/OpenAPI yapılandırması
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

// HTTP istek ardışık düzenini yapılandırın
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();

app.UseCors();

app.UseMiddleware<AbstractExceptionHandlerMiddleware>();


app.UseAuthorization();

app.MapControllers();


app.Run();
