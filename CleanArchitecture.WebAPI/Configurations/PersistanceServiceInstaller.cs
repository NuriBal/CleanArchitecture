using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace CleanArchitecture.WebAPI.Configurations;

public sealed class PersistanceServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration, IHostBuilder host)
    {

        services.AddAutoMapper(cfg =>
        {
            cfg.AddMaps(typeof(CleanArchitecture.Persistance.AssemblyReference).Assembly);
        });

        string connectionString = configuration.GetConnectionString("SqlServer");

        services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

        services.AddIdentity<User, Role>(options =>
        {
            options.Password.RequiredLength = 6;
        }).AddEntityFrameworkStores<AppDbContext>();

        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Information()
            .Enrich.FromLogContext()
            .WriteTo.Console()
            .WriteTo.File("Logs/log-.txt", rollingInterval: RollingInterval.Day)
            .WriteTo.MSSqlServer(
            connectionString: connectionString,
            tableName: "Logs",
            autoCreateSqlTable: true)
            .CreateLogger();

        host.UseSerilog();
    }
}
