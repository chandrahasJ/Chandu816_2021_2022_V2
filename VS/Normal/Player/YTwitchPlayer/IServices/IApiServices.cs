
namespace YTwitchPlayer.IServices
{
    public interface IApiServices
    {
        Task<VideoSearchResult> SearchVideos(string searchQuery, string nextPageToken = "");
    }
}
