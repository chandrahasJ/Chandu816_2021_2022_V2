namespace YTwitchPlayer.Models.YModels
{

    public class Snippet
    {
        [JsonPropertyName("publishedAt")]
        public DateTime PublishedAt { get; set; }

        [JsonPropertyName("channelId")]
        public string ChannelId { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("thumbnails")]
        public Thumbnails Thumbnails { get; set; }

        [JsonPropertyName("channelTitle")]
        public string ChannelTitle { get; set; }

        public string ChannelImageURL { get; set; }

        //For Details
        [JsonPropertyName("tags")]
        public List<string> Tags { get; set; }

        //For Comments
        [JsonPropertyName("topLevelComment")]
        public TopLevelComment TopLevelComment { get; set; }

        [JsonPropertyName("textDisplay")]
        public string TextDisplay { get; set; }

        [JsonPropertyName("authorDisplayName")]
        public string AuthorDisplayName { get; set; }

        [JsonPropertyName("authorProfileImageUrl")]
        public string AuthorProfileImageUrl { get; set; }

        [JsonPropertyName("likeCount")]
        public int LikeCount { get; set; }
    }
}
