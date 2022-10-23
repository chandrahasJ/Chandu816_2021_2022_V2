namespace YTwitchPlayer.Models.YModels
{
    //Comments related models
    public class CommentsSearchResult
    {
        [JsonPropertyName("nextPageToken")]
        public string NextPageToken { get; set; }

        [JsonPropertyName("items")]
        public List<Comment> Comments { get; set; }
    }
}
