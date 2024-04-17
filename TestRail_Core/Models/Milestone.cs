using System.Text.Json.Serialization;

namespace TestRailComplexApi.Models;

public class Milestone
{
    [JsonPropertyName("id")] public int Id { get; set; }
    [JsonPropertyName("name")] public string? Name { get; init; } 
    [JsonPropertyName("description")] public string? Description { get; set; }
    [JsonPropertyName("is_completed")] public bool IsCompleted { get; set; }
    [JsonPropertyName("project_id")] public int IdProject { get; set; }
}