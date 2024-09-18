using System.Text.Json.Serialization;

namespace Maui5eClient.Models;

public struct Subclasses
{
    public string Name { get; set; }
    [JsonPropertyName("desc")]
    public List<string> Description { get; set; }
}