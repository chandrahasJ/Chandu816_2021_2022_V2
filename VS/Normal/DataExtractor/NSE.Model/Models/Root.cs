using System.Text.Json.Serialization;

namespace NSE.Model;

public class Root
{
    [JsonPropertyName("records")]
    public Records Records { get; set; } = new Records();

    [JsonPropertyName("filtered")]
    public Filtered Filtered { get; set; } = new Filtered();
}