using System.ComponentModel;
using System.Text.Json.Serialization;
using MessagePack;
using TerraformPluginDotNet.Resources;
using TerraformPluginDotNet.Serialization;

namespace CodacyProvider;

[SchemaVersion(1)]
[MessagePackObject]
public record CodacyRepository
{
    [Key("id")]
    [Computed]
    [Description("Unique ID for this resource.")]
    [MessagePackFormatter(typeof(ComputedStringValueFormatter))]
    public string? Id { get; set; }

    [Key("owner")]
    [JsonPropertyName("owner")]
    [Description("Repository owner")]
    [Required]
    public string Owner { get; set; }

    [Key("name")]
    [JsonPropertyName("name")]
    [Description("Repository name")]
    [Required]
    public string Name { get; set; }

}