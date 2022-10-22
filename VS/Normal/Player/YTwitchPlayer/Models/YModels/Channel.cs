namespace YTwitchPlayer.Models.YModels
{
    public class Channel
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("snippet")]
        public Snippet Snippet { get; set; }
        //public Statistics Statistics { get; set; }
    }


}
