namespace YTwitchPlayer.Models.YModels
{
    public class VideoDetailsResult
    {
        [JsonPropertyName("items")]
        public List<YVideoResult> VideoResults { get; set; }
    }
}
