using System.Text.Json.Serialization;

namespace MTS_Diplom.Models;

public record Links
{
    [JsonPropertyName("next")] public string Next { get; set; }
    [JsonPropertyName("prev")] public string Prev { get; set; }
}