using System.Text.Json.Serialization;

namespace MTS_Diplom.Models;

public record Section
{
    [JsonPropertyName("name")] public string Name { get; set; }
    [JsonPropertyName("id")] public int Id { get; set; }
    [JsonPropertyName("description")] public string? Description { get; set; }
    [JsonPropertyName("suite_id")] public int SuiteId { get; set; }
}