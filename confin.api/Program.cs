using System.Text.Json.Serialization;
using confin.api.filters;
using confin.api.validators;
using confin.data;
using confin.data.Repositories;
using FluentValidation;
using FluentValidation.AspNetCore;
using Serilog;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // builder.Logging.ClearProviders();
        // builder.Logging.AddConsole();
        // builder.Host.ConfigureLogging(logging => 
        // {
        //     logging.ClearProviders();
        //     logging.AddConsole();
        // });

        builder.Services.AddControllers(opt =>
        {
            opt.Filters.Add(typeof(CompraExceptionFilter));
        }).AddJsonOptions(opt =>
        {
            opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        });
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddCors();

        builder.Services.AddScoped<DbSession>();
        builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
        builder.Services.AddTransient<CompraRepository>();

        builder.Services.AddFluentValidationAutoValidation();
        builder.Services.AddValidatorsFromAssemblyContaining<NovaCompraValidator>();
        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        using var logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();
        builder.Logging.AddSerilog(logger);

        var app = builder.Build();

        app.Logger.LogInformation("*****Starting Confin Api*****");

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}