
using Com.AppDellaFresca.API.Controllers.Helpers;
using Com.AppDellaFresca.API.Repositories;
using Com.AppDellaFresca.API.Repositories.Interfaces;
using Com.AppDellaFresca.API.Services;
using Com.AppDellaFresca.API.Services.Interfaces;
using MassTransit;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.SystemConsole.Themes;


namespace Com.AppDellaFresca.API;

public class Program
{
    public const string ServiceName = "Com.AppDellaFresca.API";

    public static void Main(string[] args)
    {
        Log.Logger.Information($"Local Timezone: {TimeZoneInfo.Local.Id} ({TimeZoneInfo.Local.BaseUtcOffset})");

        var appBuilder = WebApplication.CreateBuilder(args);

        var configuration = new ConfigurationBuilder()
                .AddEnvironmentVariables()
        .AddCommandLine(args)
        .Build();

        var settings = configuration.Get<AppSettings>();
        var config = new Config(settings);

        var loggerConfig = new LoggerConfiguration()
                   .MinimumLevel.ControlledBy(settings.LogLevelSwitch)
                   .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                   .Enrich.WithProperty("ServiceName", ServiceName)
                   .Enrich.WithProperty("MachineName", Environment.MachineName)
                   .WriteTo.Console(theme: AnsiConsoleTheme.Code);
        Log.Logger = loggerConfig.CreateLogger();

        appBuilder.Host.UseConsoleLifetime().UseSerilog(Log.Logger);

        Log.Information("*************************");
        Log.Information($"Starting microservice {ServiceName}");
        Log.Information($"Local Timezone: {TimeZoneInfo.Local.Id} ({TimeZoneInfo.Local.BaseUtcOffset})");

        appBuilder.Host.ConfigureServices(services =>
        {
            ConfigureInternalServices(services);
            ConfigureRepositories(services);
            ConfigureRabbitMq(services);
        });

        appBuilder.Services.AddControllers();
        appBuilder.Services.AddEndpointsApiExplorer();
        appBuilder.Services.AddSwaggerGen();

        var app = appBuilder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }

    private static void ConfigureInternalServices(IServiceCollection services)
    {
        services.AddScoped<GameHelper>();
        services.AddScoped<IGameService, GameService>();
    }

    private static void ConfigureRepositories(IServiceCollection services)
    {
        services.AddScoped<IGameRepository, GameRepository>();
        services.AddScoped<IBusCachedInterface, BusCachedInterface>();
    }

    private static void ConfigureRabbitMq(IServiceCollection services)
    {
        services.AddMassTransit(x =>
        {
            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host("rabbitmq://localhost", h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                });
            });
        });
    }
}
