namespace YTwitchPlayer.Models.YModels
{
    public class Thumbnails
    {
        [JsonPropertyName("medium")]
        public Thumbnail Medium { get; set; }

        [JsonPropertyName("high")]
        public Thumbnail High { get; set; }
    }
}
