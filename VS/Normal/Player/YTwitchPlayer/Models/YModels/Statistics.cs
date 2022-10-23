namespace YTwitchPlayer.Models.YModels
{
    public class Statistics
    {
        [JsonPropertyName("viewCount")]
        public string ViewCount { get; set; }

        [JsonPropertyName("likeCount")]
        public string LikeCount { get; set; }

        [JsonPropertyName("favoriteCount")]
        public string FavoriteCount { get; set; }

        [JsonPropertyName("commentCount")]
        public string CommentCount { get; set; }
    }
}
