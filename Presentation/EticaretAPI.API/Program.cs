using EticaretAPI.Persistance;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore.Design;
using EticaretAPI.Application.Repositories;
using EticaretAPI.Persistance.Repositories;
using EticaretAPI.API;
using FluentValidation.AspNetCore;
using EticaretAPI.Application.Validators.Products;
using EticaretAPI.Infrastructure.Filters;



var builder = WebApplication.CreateBuilder(args);

// Servisleri ekle
builder.Services.AddPersistenceServices();

builder.Services.AddCors(options => options.AddDefaultPolicy(policy => policy.WithOrigins("http://localhost:4200", "https://localhost:4200").AllowAnyHeader().AllowAnyMethod()));


builder.Services.AddControllers(options => options.Filters.Add<ValidationFilter>())
    .AddFluentValidation(configuration => configuration.RegisterValidatorsFromAssemblyContaining<CreateProductValidator>())
    .ConfigureApiBehaviorOptions(options => options.SuppressModelStateInvalidFilter = true);

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

app.UseStaticFiles();

app.UseCors();

app.UseMiddleware<AbstractExceptionHandlerMiddleware>();


app.UseAuthorization();

app.MapControllers();


app.Run();
