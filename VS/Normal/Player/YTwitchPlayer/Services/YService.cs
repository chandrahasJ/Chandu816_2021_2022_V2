

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
            var resourceURI = $"channels?part=snippet,statistics&id={WebUtility.UrlEncode(channelIDs)}&key={Constants.ApiKey}";

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
    }
}
