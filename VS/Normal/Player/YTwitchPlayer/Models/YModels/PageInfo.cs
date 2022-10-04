namespace YTwitchPlayer.Models.YModels
{
    public class PageInfo
    {
        [JsonPropertyName("totalResults")]
        public int TotalResults { get; set; }

        [JsonPropertyName("resultsPerPage")]
        public int ResultsPerPage { get; set; }
    }
}
