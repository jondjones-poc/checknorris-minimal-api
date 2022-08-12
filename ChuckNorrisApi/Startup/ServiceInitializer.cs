using Services;

namespace ChuckNorrisApi.Refactored.Startup;

public static partial class ServiceInitializer
{
    public static IServiceCollection RegisterApplicationServices(
                                        this IServiceCollection services)
    {
        RegisterCustomDependencies(services);

        RegisterSwagger(services);
        RegisterHttpClientDependencies(services);

        return services;
    }

    private static void RegisterCustomDependencies(IServiceCollection services)
    {
        services.AddTransient<IChuckNorrisRespositoryAPI, ChuckNorrisRespositoryAPI>();
    }

    private static void RegisterHttpClientDependencies(IServiceCollection services)
    {
        services.AddHttpClient<IChuckNorrisRespositoryAPI, ChuckNorrisRespositoryAPI>();
    }
    private static void RegisterSwagger(IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
    }
}

