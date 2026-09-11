using System.Reflection;

namespace CleanArchitecture.WebAPI.Configurations;

public static class DependencyInjection
{
    public static IServiceCollection InstallServices(this IServiceCollection services, IConfiguration configuration, IHostBuilder host, params Assembly[] assemblies)
    {
        IEnumerable<IServiceInstaller> serviceInstallers = assemblies
            .SelectMany(s => s.DefinedTypes)
            .Where(IsAssignableToType<IServiceInstaller>)
            .Select(Activator.CreateInstance)
            .Cast<IServiceInstaller>();

        foreach (IServiceInstaller serviceInstaller in serviceInstallers)
        {
            serviceInstaller.Install(services, configuration, host);
        }

        return services;

        static bool IsAssignableToType<T>(TypeInfo typeInfo)
            =>
            typeof(T).IsAssignableFrom(typeInfo) &&
            !typeInfo.IsInterface &&
            !typeInfo.IsAbstract;
    }
}
