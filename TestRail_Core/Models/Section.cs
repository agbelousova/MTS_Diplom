using System.Net;
using System.Text.Json.Serialization;

namespace MTS_Diplom.Models;

public record Section
{
    [JsonPropertyName("name")] public string Name { get; set; }
    [JsonPropertyName("id")] public int Id { get; set; }
    [JsonPropertyName("description")] public string? Description { get; set; }
    [JsonPropertyName("suite_id")] public int SuiteId { get; set; }
    [JsonPropertyName("display_order")] public int? DisplayOrder { get; set; }
    [JsonPropertyName("depth")] public int? Depth { get; set; }
}