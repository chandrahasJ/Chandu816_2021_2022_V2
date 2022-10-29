using System.Text.Json.Serialization;

namespace NSE.Model
{
    public class Index
    {
        [JsonPropertyName("key")]
        public string Key { get; set; } = String.Empty;

        [JsonPropertyName("index")]
        public string IndexType { get; set; } = String.Empty;

        [JsonPropertyName("indexSymbol")]
        public string IndexSymbol { get; set; } = String.Empty;

        [JsonPropertyName("last")]
        public double Last { get; set; }

        [JsonPropertyName("variation")]
        public double Variation { get; set; }

        [JsonPropertyName("percentChange")]
        public double PercentChange { get; set; }

        [JsonPropertyName("open")]
        public double Open { get; set; }

        [JsonPropertyName("high")]
        public double High { get; set; }

        [JsonPropertyName("low")]
        public double Low { get; set; }

        [JsonPropertyName("previousClose")]
        public double PreviousClose { get; set; }

        [JsonPropertyName("yearHigh")]
        public double YearHigh { get; set; }

        [JsonPropertyName("yearLow")]
        public double YearLow { get; set; }

        [JsonPropertyName("pe")]
        public string Pe { get; set; } = String.Empty;

        [JsonPropertyName("pb")]
        public string Pb { get; set; } = String.Empty;

        [JsonPropertyName("dy")]
        public string Dy { get; set; } = String.Empty;

        [JsonPropertyName("declines")]
        public string Declines { get; set; } = String.Empty;

        [JsonPropertyName("advances")]
        public string Advances { get; set; } = String.Empty;

        [JsonPropertyName("unchanged")]
        public string Unchanged { get; set; } = String.Empty;
    }


}