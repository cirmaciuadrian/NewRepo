namespace BACDE10.WEBAPI.Installers.Interfaces;

public interface IInstaller
{
    void InstallServices(IServiceCollection services, IConfiguration configuration);
}
