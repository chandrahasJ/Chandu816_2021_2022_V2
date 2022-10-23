namespace YTwitchPlayer.Models.YModels
{
    public class Comment
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("snippet")]
        public Snippet Snippet { get; set; }
    }
}
