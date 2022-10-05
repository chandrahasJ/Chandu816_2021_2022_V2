

namespace YTwitchPlayer.Services
{
    public class YService : RestServiceBase, IApiService
    {
        public YService(IConnectivity connectivity, IBarrel barrel) : base(connectivity, barrel)
        {
            SetBaseURL(Constants.ApiServiceURL);
        }

        public async Task<VideoSearchResult> SearchVideos(string searchQuery, string nextPageToken = "")
        {
            var resourceURI = $"part=snippet&maxResults=10&type=video&q={WebUtility.UrlEncode(searchQuery)}&key={Constants.ApiKey}" +
                $"{(!String.IsNullOrEmpty(nextPageToken)? $"&pageToken={nextPageToken}" : "")}";

            var result = await GetAsync<VideoSearchResult>(resourceURI, 4);

            return result;
        }
    }
}
