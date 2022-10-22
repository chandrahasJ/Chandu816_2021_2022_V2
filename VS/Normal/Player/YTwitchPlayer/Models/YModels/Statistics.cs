namespace YTwitchPlayer.Models.YModels
{
    public class Statistics
    {
        [JsonPropertyName("viewCount")]
        public string ViewCount { get; set; }

        [JsonPropertyName("subscriberCount")]
        public string SubscriberCount { get; set; }

        [JsonPropertyName("hiddenSubscriberCount")]
        public bool HiddenSubscriberCount { get; set; }

        [JsonPropertyName("videoCount")]
        public string VideoCount { get; set; }
    }
}
