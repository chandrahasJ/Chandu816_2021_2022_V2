namespace YTwitchPlayer.Models.YModels
{
    public class ContentDetails
    {
        [JsonPropertyName("duration")]
        public string Duration { get; set; }

        [JsonPropertyName("dimension")]
        public string Dimension { get; set; }

        [JsonPropertyName("definition")]
        public string Definition { get; set; }

        [JsonPropertyName("caption")]
        public string Caption { get; set; }

        [JsonPropertyName("licensedContent")]
        public bool LicensedContent { get; set; }

        [JsonPropertyName("contentRating")]
        public ContentRating ContentRating { get; set; }

        [JsonPropertyName("projection")]
        public string Projection { get; set; }
    }
}
