using Livraria.Config;
using Livraria.DataContext;
using Livraria.Exceptions;
using Livraria.repository;
using Livraria.service;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.t

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});


builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ILivroRepository, LivroService>();
builder.Services.AddScoped<IAutorRepository, AutorService>();
builder.Services.AddDbContext<ApplicationDbContext>(options =>

{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
var app = builder.Build();

app.UseExceptionHandler(errorApp =>
{
    errorApp.Run(async context =>
    {
        var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();
        var exception = exceptionHandlerPathFeature?.Error;
        if (exception is HttpStatusCodeException httpStatusCodeException)
        {
            context.Response.StatusCode = (int)httpStatusCodeException.StatusCode;
            context.Response.ContentType = "apllication/json";

            var response = new
            {
                error = httpStatusCodeException.Message
            };

            await context.Response.WriteAsJsonAsync(response);
        }
        else
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";
            var response = new
            {
                error = "Um erro inesperado aconteceu, tente novamente e caso o erro  persista, acione o suporte!"
            };
            await context.Response.WriteAsJsonAsync(response);
        }
    });
});
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
