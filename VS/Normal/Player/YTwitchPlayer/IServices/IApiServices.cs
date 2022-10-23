
namespace YTwitchPlayer.IServices
{
    public interface IApiService
    {
        Task<VideoSearchResult> SearchVideos(string searchQuery, string nextPageToken = "");
        Task<ChannelSearchResult> GetChannels(string channelIDs);
        Task<YVideoResult> GetVideoResult(string videoId);
        Task<CommentsSearchResult> GetComments(string videoId);
    }
}
