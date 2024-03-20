using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace ISB.Renting.Cross.Extensions;

public static class AutoMapperExtension
{
    public static IServiceCollection RegisterAutoMapperServices(this IServiceCollection services, IEnumerable<Type> types, bool allowNullCollection = false)
    {
        services.AddAutoMapper(types.ToArray());
        services.Configure<MapperConfigurationExpression>(cfg => { cfg.AllowNullCollections = allowNullCollection; });

        return services;
    }

    public static IEnumerable<Type> GetSolutionDerivedClasses(Type baseClass)
    {
        var types = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(assembly => assembly.GetTypes())
            .Where(x => x.IsClass && !x.IsAbstract && x.IsSubclassOf(baseClass));
        return types;
    }
}
