namespace YTwitchPlayer.Models.YModels
{
    public class YVideo
    {
        [JsonPropertyName("id")]
        public Id Id { get; set; }

        [JsonPropertyName("snippet")]
        public Snippet Snippet { get; set; }
    }
}
