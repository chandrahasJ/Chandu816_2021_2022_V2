namespace YTwitchPlayer.Models.YModels
{
    public class TopLevelComment
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("snippet")]
        public Snippet Snippet { get; set; }
    }
}
