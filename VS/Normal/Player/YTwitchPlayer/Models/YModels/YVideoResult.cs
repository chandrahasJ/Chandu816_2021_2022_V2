namespace YTwitchPlayer.Models.YModels
{
    public class YVideoResult
    {  
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("snippet")]
        public Snippet Snippet { get; set; }

        [JsonPropertyName("contentDetails")]
        public ContentDetails ContentDetails { get; set; }

        [JsonPropertyName("statistics")]
        public Statistics Statistics { get; set; }
    }
}
