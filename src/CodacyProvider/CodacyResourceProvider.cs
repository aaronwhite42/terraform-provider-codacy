using CodacyProvider.Api.Client;
using TerraformPluginDotNet.ResourceProvider;

namespace CodacyProvider;

public class CodacyResourceProvider :  IResourceProvider<CodacyRepository>
{
    private readonly CodacyClient _codacyClient;
    private readonly Configuration? _config;

    public CodacyResourceProvider(CodacyConfigurator configurator, CodacyClient codacyClient)
    {
        _codacyClient = codacyClient;
        _config = configurator.Configuration;
    }

    public async Task<CodacyRepository> PlanAsync(CodacyRepository? prior, CodacyRepository proposed)
    {
        try
        {
            Enum.TryParse(_config?.Provider ?? "Gh", out Provider47 provider);//TODO: handle enum parsing safely
            var response = await _codacyClient.GetRepositoryAsync(provider, proposed.Owner, proposed.Name);
            return proposed with { Id = response.Data.RepositoryId.ToString() ?? string.Empty };
        }
        catch (Exception)
        {
            // smother
        }

        return new CodacyRepository
        {
            Name = proposed.Name,
            Owner = proposed.Owner
        };
    }

    public async Task<CodacyRepository> CreateAsync(CodacyRepository planned)
    {
        Enum.TryParse(_config?.Provider ?? "Gh", out Provider provider);//TODO: handle enum parsing safely

        try
        {
            var response = await _codacyClient.AddRepositoryAsync(null,
                new AddRepositoryBody
                {
                    Provider = provider,
                    RepositoryFullPath = $"{planned.Owner}/{planned.Name}"
                });

            return planned with { Id = response.RepositoryId.ToString() ?? string.Empty };
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<CodacyRepository> ReadAsync(CodacyRepository respository)
    {
        Enum.TryParse(_config?.Provider ?? "Gh", out Provider47 provider);//TODO: handle enum parsing safely
        var response = await _codacyClient.GetRepositoryAsync(provider, respository.Owner, respository.Name);
        return respository with { Id = response.Data.RepositoryId.ToString() ?? string.Empty };
    }

    public Task<CodacyRepository> UpdateAsync(CodacyRepository? prior, CodacyRepository planned)
    {
        return Task.FromResult(planned);
    }

    public async Task DeleteAsync(CodacyRepository repository)
    {
        Enum.TryParse(_config?.Provider ?? "Gh", out Provider48 provider);//TODO: handle enum parsing safely
        await _codacyClient.DeleteRepositoryAsync(provider, repository.Owner, repository.Name);
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