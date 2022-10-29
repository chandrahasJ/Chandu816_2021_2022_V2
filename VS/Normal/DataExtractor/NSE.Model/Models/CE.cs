using System.Text.Json.Serialization;

namespace NSE.Model
{
    // Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
    public class CE
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
        public double OpenInterest { get; set; }

        [JsonPropertyName("changeinOpenInterest")]
        public int ChangeinOpenInterest { get; set; }

        [JsonPropertyName("pchangeinOpenInterest")]
        public double PchangeinOpenInterest { get; set; }

        [JsonPropertyName("totalTradedVolume")]
        public double TotalTradedVolume { get; set; }        

        [JsonPropertyName("impliedVolatility")]
        public double ImpliedVolatility { get; set; }

        [JsonPropertyName("lastPrice")] 
        public double LastPrice { get; set; }

        [JsonPropertyName("change")]
        public double Change { get; set; }   

        [JsonPropertyName("pChange")]
        public double PChange { get; set; }   

        [JsonPropertyName("totalBuyQuantity")]
        public double TotalBuyQuantity { get; set; }
    
        [JsonPropertyName("totalSellQuantity")]
        public double TotalSellQuantity { get; set; }
    
        [JsonPropertyName("bidQty")]
        public double BidQty { get; set; }   

        [JsonPropertyName("bidprice")]
        public double Bidprice { get; set; }    

        [JsonPropertyName("askQty")]
        public double AskQty { get; set; }    

        [JsonPropertyName("askPrice")]
        public double AskPrice { get; set; }   

        [JsonPropertyName("underlyingValue")]
        public double UnderlyingValue { get; set; }
    
       [JsonPropertyName("totOI")]
        public double TotOI { get; set; }    

        [JsonPropertyName("totVol")]
        public double TotVol { get; set; }

        public override string ToString()
        {
            return $"{StrikePrice},{ExpiryDate},{Underlying},{Identifier},{OpenInterest},{ChangeinOpenInterest}," +
                   $"{PchangeinOpenInterest},{TotalTradedVolume},{ImpliedVolatility},{LastPrice},{Change},{PChange},{TotalBuyQuantity}," +
                   $"{TotalSellQuantity},{BidQty},{Bidprice},{AskQty},{AskPrice},{UnderlyingValue},{TotOI},{TotVol}";
        }
    }
}