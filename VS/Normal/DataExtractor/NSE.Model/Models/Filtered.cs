using System.Text.Json.Serialization;

namespace NSE.Model
{
    public class Filtered
    {
        [JsonPropertyName("data")]
        public List<Datum> Data { get; set; } = new List<Datum>();

        [JsonPropertyName("CE")]
        public CE CE { get; set; } = new CE();

        [JsonPropertyName("PE")]
        public PE PE { get; set; } = new PE();
    }
}