using System.ComponentModel;
using System.Text.Json.Serialization;
using MessagePack;
using TerraformPluginDotNet.Resources;
using TerraformPluginDotNet.Serialization;

[SchemaVersion(1)]
[MessagePackObject]
public class CodacyRepository
{
    [Key("id")]
    [Computed]
    [Description("Unique ID for this resource.")]
    [MessagePackFormatter(typeof(ComputedStringValueFormatter))]
    public string Id { get; set; }

    // [Key("some_value")]
    // [JsonPropertyName("some_value")]
    // [Description("Some value in the resource.")]
    // [Required]

    [Key("repository_provider")]
    [JsonPropertyName("repository_provider")]
    [Description("Repository provider")]
    [Required]
    public string Provider { get; set; }

    [Key("full_path")]
    [JsonPropertyName("full_path")]
    [Description("Repository full path")]
    [Required]
    public string FullPath { get; set; }

    // [Key("owner")]
    // [JsonPropertyName("owner")]
    // [Description("Repository owner")]
    // public string Owner { get; set; }

    // [Key("name")]
    // [JsonPropertyName("name")]
    // [Description("Repository name")]
    // public string Name { get; set; }

    // [Key("visibility")]
    // [JsonPropertyName("visibility")]
    // [Description("Repository visibility")]
    // public string Visibility { get; set; }

    // [Key("problems")]
    // [JsonPropertyName("problems")]
    // [Description("Collection of any problems encountered")]
    // public object[] Problems { get; set; }
    //
    // [Key("languages")]
    // [JsonPropertyName("languages")]
    // [Description("Collection of repository languages")]
    // public object[] Languages { get; set; }

    // [Key("repository_id")]
    // [JsonPropertyName("repository_id")]
    // [Description("Repository Identifier")]
    // public int RepositoryId { get; set; }


    // [Key("remote_identifier")]
    // [JsonPropertyName("remote_identifier")]
    // [Description("Repository remote identifier")]
    // public string RemoteIdentifier { get; set; }
}



