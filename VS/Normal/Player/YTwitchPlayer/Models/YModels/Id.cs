namespace YTwitchPlayer.Models.YModels
{
    public class Id
    {
        [JsonPropertyName("channelId")]
        public string ChannelId { get; set; }

        [JsonPropertyName("videoId")]
        public string VideoId { get; set; }
    }
}
