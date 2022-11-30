using System.Net.Http.Headers;
using TerraformPluginDotNet.ResourceProvider;

namespace CodacyProvider;

public class CodacyResourceProvider :  IResourceProvider<CodacyRepository>
{
    private readonly CodacyConfigurator _configurator;
    private readonly HttpClient _httpClient;

    public CodacyResourceProvider(CodacyConfigurator configurator, HttpClient httpClient)
    {
        _configurator = configurator;
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri(_configurator.Config?.BaseAddress ?? throw new InvalidOperationException());
        _httpClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("api-token", _configurator.Config.ApiToken);
    }

    public Task<CodacyRepository> PlanAsync(CodacyRepository? prior, CodacyRepository proposed)
    {
        var t = _httpClient;
        return Task.FromResult(proposed);
    }

    public async Task<CodacyRepository> CreateAsync(CodacyRepository planned)
    {
        planned.Id = Guid.NewGuid().ToString();
        // call Codacy API
        // await File.WriteAllTextAsync(planned.Path, BuildContent(planned.Content));
        return planned;
    }

    public Task<CodacyRepository> ReadAsync(CodacyRepository resource)
    {
        return Task.FromResult(resource);
    }

    public Task<CodacyRepository> UpdateAsync(CodacyRepository? prior, CodacyRepository planned)
    {
        return Task.FromResult(planned);
    }

    public Task DeleteAsync(CodacyRepository resource)
    {
        return Task.CompletedTask;
    }

    public Task<IList<CodacyRepository>> ImportAsync(string id)
    {
        IList<CodacyRepository> resource = new[]
        {
            new CodacyRepository()
        };
        return Task.FromResult(resource);
    }
}