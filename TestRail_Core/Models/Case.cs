using System.Text.Json.Serialization;

namespace MTS_Diplom.Models;

public class Case
{
    [JsonPropertyName("id")] public int Id { get; set; }
    [JsonPropertyName("title")] public string? Title { get; set; }
    [JsonPropertyName("priority_id")] public int? PriorityId { get; set; }
    [JsonPropertyName("estimate")] public string? Estimate { get; set; }
}