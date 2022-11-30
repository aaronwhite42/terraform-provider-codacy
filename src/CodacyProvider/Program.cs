// See https://aka.ms/new-console-template for more information

using CodacyProvider;
using Microsoft.Extensions.DependencyInjection;
using TerraformPluginDotNet;
using TerraformPluginDotNet.ResourceProvider;

await TerraformPluginHost.RunAsync(args, "advocacy.dev/aaron/codacy", (services, registry) =>
{
    services.AddSingleton<CodacyConfigurator>();
    // services.AddHttpClient("Codacy", httpClient =>
    // {
    //     httpClient.BaseAddress = new Uri("https://app.codacy.com/api/v3");
    //     services.Get
    // });
    services.AddTerraformProviderConfigurator<Configuration, CodacyConfigurator>();

    services.AddHttpClient<CodacyResourceProvider>();

    services.AddSingleton<IResourceProvider<CodacyRepository>, CodacyResourceProvider>();
    registry.RegisterResource<CodacyRepository>("codacy_repository");
});