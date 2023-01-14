using Desafio.Bravi.Api.Controllers.CriarCliente;
using Desafio.Bravi.Api.Controllers.EditarCliente;
using Desafio.Bravi.Api.Helpers;
using Desafio.Bravi.Repository.DependencyInjection;
using FluentValidation;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
var assembly = AppDomain.CurrentDomain.Load("Desafio.Bravi.Application");
builder.Services.AddMediatR(assembly);
builder.Services.AddRepository();
builder.Services.AddScoped<IValidator<CriarClienteRequest>, CriarClienteValidator>();
builder.Services.AddScoped<IValidator<EditarClienteRequest>, EditarClienteValidator>();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
