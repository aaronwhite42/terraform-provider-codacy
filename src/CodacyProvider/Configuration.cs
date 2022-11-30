using System.ComponentModel;
using MessagePack;

namespace CodacyProvider;

[MessagePackObject]
public class Configuration
{
    [Key("api_token")]
    [Description("Codacy API token")]
    public string? ApiToken { get; set; }

    [Key("base_address")]
    [Description("Base address of the Codacy endpoint")]
    public string BaseAddress { get; set; }
}