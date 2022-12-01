using CodacyProvider.Api.Client;
using Microsoft.Extensions.DependencyInjection;

namespace CodacyProvider;

public static class ServiceExtensions
{
    public static IServiceCollection AddCodacyClient(this IServiceCollection services)
    {
        services.AddHttpClient<CodacyClient>((provider, httpClient) =>
        {
            var configurator = provider.GetService<CodacyConfigurator>();
            var config = configurator?.Configuration;
            if (config?.BaseAddress != null) httpClient.BaseAddress = new Uri(config.BaseAddress);
            httpClient.DefaultRequestHeaders.TryAddWithoutValidation("api-token", config?.ApiToken);
        });
        return services;
    }
}