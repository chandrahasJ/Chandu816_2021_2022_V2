using System.Linq;

namespace YTwitchPlayer.Services
{
    public class YService : RestServiceBase, IApiService
    {
        public YService(IConnectivity connectivity, IBarrel barrel) : base(connectivity, barrel)
        {
            SetBaseURL(Constants.ApiServiceURL);
        }

        public async Task<ChannelSearchResult> GetChannels(string channelIDs)
        {
            var resourceURI = $"channels?part=snippet,statistics&maxResults=10&id={WebUtility.UrlEncode(channelIDs)}&key={Constants.ApiKey}";

            var result = await GetAsync<ChannelSearchResult>(resourceURI, 4);

            return result;
        }

        public async Task<VideoSearchResult> SearchVideos(string searchQuery, string nextPageToken = "")
        {
            var resourceURI = $"search?part=snippet&maxResults=10&type=video&q={WebUtility.UrlEncode(searchQuery)}&key={Constants.ApiKey}" +
                $"{(!String.IsNullOrEmpty(nextPageToken)? $"&pageToken={nextPageToken}" : "")}";

            var result = await GetAsync<VideoSearchResult>(resourceURI, 4);

            return result;
        }

        public async Task<CommentsSearchResult> GetComments(string videoId)
        {
            var resourceURI = $"commentThreads?part=snippet&maxResults=100&videoId={WebUtility.UrlEncode(videoId)}&key={Constants.ApiKey}";

            var result = await GetAsync<CommentsSearchResult>(resourceURI, 4);

            return result;
        }

        public async Task<YVideoResult> GetVideoResult(string videoId)
        {
            var resourceURI = $"videos?part=snippet,statistics,contentDetails,id&id={WebUtility.UrlEncode(videoId)}&key={Constants.ApiKey}";

            var result = await GetAsync<VideoDetailsResult>(resourceURI, 24);

            return result.VideoResults.First();
        }
    }
}
