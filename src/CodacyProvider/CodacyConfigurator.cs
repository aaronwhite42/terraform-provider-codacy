using TerraformPluginDotNet.ProviderConfig;

namespace CodacyProvider;

public class CodacyConfigurator : IProviderConfigurator<Configuration>
{
    public Configuration? Configuration { get; private set; }

    public Task ConfigureAsync(Configuration config)
    {
        Configuration = config;
        return Task.CompletedTask;
    }
}