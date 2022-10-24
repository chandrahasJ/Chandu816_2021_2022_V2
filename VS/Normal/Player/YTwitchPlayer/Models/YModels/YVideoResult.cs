using MAUIApp.Framework.Extensions;

namespace YTwitchPlayer.Models.YModels
{
    public class YVideoResult
    {  
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("snippet")]
        public Snippet Snippet { get; set; }

        [JsonPropertyName("contentDetails")]
        public ContentDetails ContentDetails { get; set; }

        [JsonPropertyName("statistics")]
        public Statistics Statistics { get; set; }

        public string VideoSubtitle
        {
            get => $"{Statistics.ViewCount.FormattedNumber()} views | {Snippet.PublishedAt.ToTimeAgo()}";
        }

        public string LikesCount
        {
            get => Statistics.LikeCount.FormattedNumber();
        }

        public string VideoDuration
        {
            get => ContentDetails.Duration.ToTimeSpan().ToReadableString();
        }

        public string CommentsCount
        {
            get => Statistics.CommentCount.FormattedNumber();
        }
    }
}
