// See https://aka.ms/new-console-template for more information

using CodacyProvider;
using Microsoft.Extensions.DependencyInjection;
using TerraformPluginDotNet;
using TerraformPluginDotNet.ResourceProvider;

await TerraformPluginHost.RunAsync(args, "advocacy.dev/aaron/codacy", (services, registry) =>
{
    services.AddSingleton<CodacyConfigurator>();
    services.AddTerraformProviderConfigurator<Configuration, CodacyConfigurator>();
    services.AddSingleton<IResourceProvider<CodacyResource>, CodacyResourceProvider>();
    registry.RegisterResource<CodacyResource>("codacy_resource");
});