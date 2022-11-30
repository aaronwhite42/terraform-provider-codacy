using System.ComponentModel;
using MessagePack;

[MessagePackObject]
public class Configuration
{
    // [Key("file_header")]
    // [Description("Header text to prepend to every file.")]
    // public string? FileHeader { get; set; }
    [Key("value")]
    [Description("A test value for some reason")]
    public string Value { get; set; }
}