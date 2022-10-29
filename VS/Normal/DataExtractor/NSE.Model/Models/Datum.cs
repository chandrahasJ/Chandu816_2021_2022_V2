using System.Text.Json.Serialization;

namespace NSE.Model
{
    public class Datum
    {
        [JsonPropertyName("strikePrice")]
        public int StrikePrice { get; set; }

        [JsonPropertyName("expiryDate")]
        public string ExpiryDate { get; set; } = String.Empty;

        [JsonPropertyName("CE")]
        public CE CE { get; set; } = new CE();

        [JsonPropertyName("PE")]
        public PE PE { get; set; } = new PE();
    }


}