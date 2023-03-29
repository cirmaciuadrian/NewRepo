using BACDE10.BusinessLogic.Interfaces.Repositories;
using BACDE10.BusinessLogic.Interfaces.Services;
using BACDE10.BusinessLogic.Services;
using BACDE10.BusinessLogic.Services.Providers;
using BACDE10.DataAccess.Contexts;
using BACDE10.DataAccess.Repositories;
using BACDE10.WEBAPI.Installers.Interfaces;
using BACDE10.WEBAPI.Mappers;
using BACDE10.WEBAPI.Middlewares;
using Microsoft.EntityFrameworkCore;

namespace BACDE10.WEBAPI.Installers;
//database and services installers
public class ServiceInstaller : IInstaller
{
    public void InstallServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(configuration["ConnectionString"], x =>
                {
                    x.MigrationsAssembly("BACDE10.DataAccess");
                    x.CommandTimeout(1000);
                }));
        /*
         * Transient -> serviciu este re-creat la fiecare folosire
         * Singletone -> este creat odata pe toata viata aplicatiei
         * Scoped -> este creat odata si are durata de viata doar pe durata requestului curent
         */
        services.AddAutoMapper(typeof(AutoMapperProfile));
        services.AddScoped<HeadersValidationMiddleware>();
        services.AddScoped<IUserDetailsProvider, UserDetailsProvider>();
        services.AddScoped<IClientService, ClientService>();
        services.AddScoped<IClient, ClientRepository>();
    }
}
