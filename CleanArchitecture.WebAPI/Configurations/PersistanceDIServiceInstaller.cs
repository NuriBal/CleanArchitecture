using CleanArchitecture.Application.Repositories;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Infrastructure.Services;
using CleanArchitecture.Persistance.Repository;
using CleanArchitecture.Persistance.Services;
using CleanArchitecture.WebAPI.Middleware;

namespace CleanArchitecture.WebAPI.Configurations;

public sealed class PersistanceDIServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration, IHostBuilder host)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<ICarRepository, CarRepository>();
        services.AddScoped<IUserRoleRepository, UserRoleRepository>();

        services.AddTransient<ExceptionMiddleware>();
        services.AddScoped<ICarService, CarService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IMailService, MailService>();
        services.AddScoped<IRoleService, RoleService>();
        services.AddScoped<IUserRoleService, UserRoleService>();
    }
}
