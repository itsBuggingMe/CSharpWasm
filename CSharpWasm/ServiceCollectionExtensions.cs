using CSharpWasm.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CSharpWasm;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCSharpCompiler(this IServiceCollection services)
    {
        services.AddScoped<ICSharpProvider, CSharpProvider>();
        return services;
    }

    public static IServiceCollection AddCSharpCompiler(this IServiceCollection services, Action<CSharpProviderOptions> configure)
    {
        services.AddScoped<ICSharpProvider, CSharpProvider>();
        services.Configure(configure);
        return services;
    }
}
