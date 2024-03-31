using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Services.Abstracts;
using Services.Concretes;

namespace Services;

public static class BusinessDependenciesService
{
    public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
    {
        
        services.AddSubClassesOfType(Assembly.GetExecutingAssembly(), typeof(BaseBusinessRules));
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IAuthService, AuthManager>();
        services.AddScoped<IIdentityService, IdentityManager>();
        
        return services;
    }
    public static IServiceCollection AddSubClassesOfType(this IServiceCollection services,
        Assembly assembly,
        Type type,
        Func<IServiceCollection, Type, IServiceCollection>? addWithLifeCycle = null)
    {
        var types = assembly.GetTypes().Where(t => t.IsSubclassOf(type) && type != t).ToList();
        foreach (var item in types)
            if (addWithLifeCycle == null)
                services.AddScoped(item);
            else
                addWithLifeCycle(services, type);
        return services;
    }
    
}