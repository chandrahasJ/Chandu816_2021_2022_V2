using System.Text.Json.Serialization;

namespace NSE.Model
{
    public class PE
    {
        [JsonPropertyName("strikePrice")]
        public int StrikePrice { get; set; }

        [JsonPropertyName("expiryDate")]
        public string ExpiryDate { get; set; } = String.Empty;

        [JsonPropertyName("underlying")]
        public string Underlying { get; set; } = String.Empty;

        [JsonPropertyName("identifier")]
        public string Identifier { get; set; } = String.Empty;

        [JsonPropertyName("openInterest")]
        public int OpenInterest { get; set; }

        [JsonPropertyName("changeinOpenInterest")]
        public int ChangeinOpenInterest { get; set; }

        [JsonPropertyName("pchangeinOpenInterest")]
        public double PchangeinOpenInterest { get; set; }

        [JsonPropertyName("totalTradedVolume")]
        public int TotalTradedVolume { get; set; }

        [JsonPropertyName("impliedVolatility")]
        public double ImpliedVolatility { get; set; }

        [JsonPropertyName("lastPrice")]
        public double LastPrice { get; set; }

        [JsonPropertyName("change")]
        public double Change { get; set; }

        [JsonPropertyName("pChange")]
        public double PChange { get; set; }

        [JsonPropertyName("totalBuyQuantity")]
        public int TotalBuyQuantity { get; set; }

        [JsonPropertyName("totalSellQuantity")]
        public int TotalSellQuantity { get; set; }

        [JsonPropertyName("bidQty")]
        public int BidQty { get; set; }

        [JsonPropertyName("bidprice")]
        public double Bidprice { get; set; }

        [JsonPropertyName("askQty")]
        public int AskQty { get; set; }

        [JsonPropertyName("askPrice")]
        public double AskPrice { get; set; }

        [JsonPropertyName("underlyingValue")]
        public double UnderlyingValue { get; set; }

        [JsonPropertyName("totOI")]
        public int TotOI { get; set; }

        [JsonPropertyName("totVol")]
        public int TotVol { get; set; }
    }


}