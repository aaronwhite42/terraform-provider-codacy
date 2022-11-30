using TerraformPluginDotNet.ProviderConfig;

namespace CodacyProvider;

public class CodacyConfigurator : IProviderConfigurator<Configuration>
{
    public Configuration? Config { get; private set; }

    public Task ConfigureAsync(Configuration config)
    {
        Config = config;
        return Task.CompletedTask;
    }
}