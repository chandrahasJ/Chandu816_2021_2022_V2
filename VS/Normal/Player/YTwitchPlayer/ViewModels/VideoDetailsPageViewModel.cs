 namespace YTwitchPlayer.ViewModels
{
    public class VideoDetailsPageViewModel : AppViewModelBase
    {
        private readonly IApiService apiService;

        public VideoDetailsPageViewModel(IApiService apiService) : base(apiService)
        {
            this.apiService = apiService;
            this.Title = Constants.ApplicationName;
        }
    }
}
