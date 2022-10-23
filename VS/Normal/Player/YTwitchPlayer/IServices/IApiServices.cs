
namespace YTwitchPlayer.IServices
{
    public interface IApiService
    {
        Task<VideoSearchResult> SearchVideos(string searchQuery, string nextPageToken = "");
        Task<ChannelSearchResult> GetChannels(string channelIDs);
        Task<VideoDetailsResult> GetVideoResult(string videoId);
        Task<CommentsSearchResult> GetComments(string videoId);
    }
}
