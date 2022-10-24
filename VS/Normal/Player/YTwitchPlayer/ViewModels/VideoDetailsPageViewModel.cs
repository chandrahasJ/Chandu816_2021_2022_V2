 namespace YTwitchPlayer.ViewModels
{
    public partial class VideoDetailsPageViewModel : AppViewModelBase
    {
        [ObservableProperty]
        private YVideoResult theVideo;

        [ObservableProperty]
        private List<YVideo> similarVideos;

        [ObservableProperty]
        private Channel theChannel;

        [ObservableProperty]
        private bool similarVideosAvailable;

        [ObservableProperty]
        private List<Comment> comments;

        public event EventHandler DownloadCompleted;

        private readonly IApiService apiService;

        public VideoDetailsPageViewModel(IApiService apiService) : base(apiService)
        {
            this.apiService = apiService;
            this.Title = Constants.ApplicationName;
        }

        public override async Task OnNavigatedTo(object parameters)
        {
            string videoId = (string)parameters;
            SetLoadingIndicator(true);
            this.LoadingText = "We are fetching the video details. Hold on!";

            await LoadVideoDetailsPage(videoId);
        }

        private async Task LoadVideoDetailsPage(string videoId)
        {
            try
            {
                SimilarVideos = new();
                Comments = new();

                //Get Video Details
                TheVideo = await apiService.GetVideoResult(videoId);

                //Get Channel URL &  Set in the Video Detail
                var channelSearchResult = await apiService.GetChannels(TheVideo.Snippet.ChannelId);
                TheChannel = channelSearchResult.Channels.First();

                //Find Similar Videos
                if (TheVideo.Snippet.Tags is not null)
                {
                    var similarVideoSearchResult = await apiService.SearchVideos(TheVideo.Snippet.Tags.First(), "");

                    SimilarVideos = similarVideoSearchResult.YVideos;
                    SimilarVideosAvailable = (SimilarVideos?.Count > 0);
                }

                var commentSearchResult = await apiService.GetComments(videoId);
                Comments = commentSearchResult.Comments;

                this.DataLoaded = true;

                //All required apis calls has been completed.
                DownloadCompleted?.Invoke(this, new EventArgs());
            }
            catch (InternetConnectionException iex)
            {
                this.IsErrorState = true;
                this.ErrorImage = "nointernet.png";
                this.ErrorMessage = $"It seems your internet is not connected. Error : {iex.Message}";
            }
            catch (Exception ex)
            {
                this.IsErrorState = true;
                this.ErrorImage = "error.png";
                this.ErrorMessage = $"It seems something went wrong. Error : {ex.Message}";
            }
            finally
            {
                SetLoadingIndicator(false);
            }
        }


        [RelayCommand]
        private async Task DislikeVideo()
        {
            await PageService.DisplayAlert("Dislike", "Not Implemented!", "OK");
        }

        [RelayCommand]
        private async Task ShareVideo()
        { 
            string textToShare = $"Hey, I  am sure you will love watching this amazing video. check it out: " +
                                 $"https://www.youtube.com/watch?v={WebUtility.UrlEncode(TheVideo.Id)}";

            //Sharing Logic
            await Share.RequestAsync(new ShareTextRequest()
            {
                Text = textToShare,
                Title = Constants.ApplicationName
            });
        }

        [RelayCommand]
        private async Task DownloadVideo()
        {
            await PageService.DisplayAlert("Download Video", "Not Implemented!", "OK");
        }

        [RelayCommand]
        private async Task SubscriberChannelVideo()
        {
            await PageService.DisplayAlert("Subscriber Channel", "Not Implemented!", "OK");
        }

        [RelayCommand]
        private async Task NavigateToVideoDetailsPage(string videoId)
        {
            await NavigationService.PushAsync(new VideoDetailsPage(videoId));
        }

        [RelayCommand]
        private async Task VideoComment()
        {
            await PageService.DisplayAlert("Comments", "Not Implemented!", "OK");
        }
    }
}
