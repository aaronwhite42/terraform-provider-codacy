using System.ComponentModel;
using MessagePack;
using TerraformPluginDotNet.Resources;
// ReSharper disable once ClassNeverInstantiated.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable ClassNeverInstantiated.Global

namespace CodacyProvider;

[MessagePackObject]
public record Configuration
{
    [Key("api_token")]
    [Description("Codacy API token")]
    [Required]
    public string? ApiToken { get; set; }

    [Key("base_address")]
    [Description("Base address of the Codacy endpoint")]
    public string? BaseAddress { get; set; }

    [Key("repository_provider")]
    [Description("Repository provider (Gh, Bb, Gl). Defaults to GitHub (Gh)")]
    public string Provider { get; set; } = "Gh";
}