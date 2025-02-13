using System;
using System.Text.Json.Serialization;
using confin.api.extensions;
using confin.api.interfaces.repositories;
using confin.api.middlewares;
using confin.api.validators;
using confin.data;
using confin.data.Repositories;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

public class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        
        SerilogExtension.AddSerilogApi(builder.Configuration);
        
        builder.Host.UseSerilog(Log.Logger);

        builder.Services.AddControllers().AddJsonOptions(opt =>
        {
            opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        });

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddCors();

        builder.Services.AddScoped<DbSession>();
        builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
        builder.Services.AddTransient<ICompraRepository, CompraRepository>();
        builder.Services.AddTransient<IContaRepository, ContaRepository>();

        builder.Services.AddFluentValidationAutoValidation();
        builder.Services.AddValidatorsFromAssemblyContaining<NovaCompraValidator>();
        
        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        var app = builder.Build();

        app.UseMiddleware<ErrorHandlingMiddleware>();
        app.UseMiddleware<RequestSerilogMiddleware>();

        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
        app.UseAuthorization();
        app.MapControllers();

        app.Run();
    }
}