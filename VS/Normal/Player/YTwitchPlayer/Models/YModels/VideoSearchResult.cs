
namespace YTwitchPlayer.Models.YModels;

public class VideoSearchResult
{
    [JsonPropertyName("nextPageToken")]
    public string NextPageToken { get; set; }

    [JsonPropertyName("prevPageToken")]
    public string PrevPageToken { get; set; }

    [JsonPropertyName("pageInfo")]
    public PageInfo PageInfo { get; set; }

    [JsonPropertyName("items")]
    public List<YVideo> YVideos { get; set; }
}
