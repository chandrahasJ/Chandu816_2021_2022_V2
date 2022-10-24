namespace YTwitchPlayer.Models.YModels
{
    public class Channel
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("snippet")]
        public Snippet Snippet { get; set; }
        [JsonPropertyName("statistics")]
        public Statistics Statistics { get; set; }

        public string SubsribersCount
        {
            get => $"{Statistics.SubscriberCount.FormattedNumber()}  subscribers";
        }
    }
}
