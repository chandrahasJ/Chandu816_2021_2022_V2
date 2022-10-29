using System.Text.Json.Serialization;

namespace NSE.Model
{
    public class Records
    {
        [JsonPropertyName("expiryDates")]
        public List<string> ExpiryDates { get; set; } = new List<string>();

        [JsonPropertyName("data")]
        public List<Datum> Data { get; set; } = new List<Datum>();

        [JsonPropertyName("timestamp")]
        public string Timestamp { get; set; } = String.Empty;

        [JsonPropertyName("underlyingValue")]
        public double UnderlyingValue { get; set; }

        [JsonPropertyName("strikePrices")]
        public List<int> StrikePrices { get; set; } = new List<int>();

        [JsonPropertyName("index")]
        public Index Index { get; set; } = new Index();
    }


}