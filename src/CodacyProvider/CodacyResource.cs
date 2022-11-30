using System.ComponentModel;
using System.Text.Json.Serialization;
using MessagePack;
using TerraformPluginDotNet.Resources;
using TerraformPluginDotNet.Serialization;

[SchemaVersion(1)]
[MessagePackObject]
public class CodacyResource
{
    [Key("id")]
    [Computed]
    [Description("Unique ID for this resource.")]
    [MessagePackFormatter(typeof(ComputedStringValueFormatter))]
    public string Id { get; set; }

    [Key("some_value")]
    [JsonPropertyName("some_value")]
    [Description("Some value in the resource.")]
    [Required]
    public string SomeValue { get; set; }
}



