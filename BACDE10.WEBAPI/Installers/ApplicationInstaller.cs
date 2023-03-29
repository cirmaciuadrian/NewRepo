using BACDE10.WEBAPI.Installers.Interfaces;

namespace BACDE10.WEBAPI.Installers;
//front-end installers

public class ApplicationInstaller : IInstaller
{
    public void InstallServices(IServiceCollection services, IConfiguration configuration)
    {
        //var envSettings = new EnviromentSettings();
        //configuration.Bind(nameof(EnviromentSettings), envSettings);
        //services.AddSingleton(envSettings);

        services.AddCors(p => p.AddPolicy("corsapp",
            builder =>
            {
                builder.WithOrigins("http://localhost:3000")
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();
            })
        );
        services.AddControllers();

        //Log.Logger = new LoggerConfiguration()
        //                .ReadFrom.Configuration(configuration)
        //                .Enrich.FromLogContext()
        //                .CreateLogger();
        //services.AddLogging(loggingBuilder => loggingBuilder.AddSerilog(dispose: true));
    }
}
