using TerraformPluginDotNet.ResourceProvider;

namespace CodacyProvider;

public class CodacyResourceProvider :  IResourceProvider<CodacyResource>
{
    private readonly CodacyConfigurator _configurator;

    public CodacyResourceProvider(CodacyConfigurator configurator)
    {
        _configurator = configurator;
    }

    public Task<CodacyResource> PlanAsync(CodacyResource? prior, CodacyResource proposed)
    {
        return Task.FromResult(proposed);
    }

    public async Task<CodacyResource> CreateAsync(CodacyResource planned)
    {
        planned.Id = Guid.NewGuid().ToString();
        // call Codacy API
        // await File.WriteAllTextAsync(planned.Path, BuildContent(planned.Content));
        return planned;
    }

    public Task<CodacyResource> ReadAsync(CodacyResource resource)
    {
        return Task.FromResult(resource);
    }

    public Task<CodacyResource> UpdateAsync(CodacyResource? prior, CodacyResource planned)
    {
        return Task.FromResult(planned);
    }

    public Task DeleteAsync(CodacyResource resource)
    {
        return Task.CompletedTask;
    }

    public Task<IList<CodacyResource>> ImportAsync(string id)
    {
        IList<CodacyResource> resource = new[]
        {
            new CodacyResource()
        };
        return Task.FromResult(resource);
    }
}