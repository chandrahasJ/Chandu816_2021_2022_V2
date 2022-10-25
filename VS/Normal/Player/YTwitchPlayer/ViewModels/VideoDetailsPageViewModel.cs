using YoutubeExplode.Videos.Streams;
using YTwitchPlayer.Services;

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

        [ObservableProperty]
        private bool commentsAvailable;

        [ObservableProperty]
        private string videoSource;

        [ObservableProperty]
        private double progressValue;

        [ObservableProperty]
        private bool isDownloading = false;


        public event EventHandler DownloadCompleted;

        private IEnumerable<MuxedStreamInfo> streamInfo;

        private readonly IApiService apiService;
        private readonly IDownloadFileService fileDownloadService;

        public VideoDetailsPageViewModel(IApiService apiService, IDownloadFileService fileDownloadService) : base(apiService)
        {
            this.apiService = apiService;
            this.fileDownloadService = fileDownloadService;
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
                commentsAvailable = (Comments?.Count > 0);

                await GetVideoUrl();

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

        private async Task GetVideoUrl()
        {
            var youtube = new YoutubeClient();

            var streamManifest = await youtube.Videos.Streams.GetManifestAsync(
                $"https://youtube.com/watch?v={TheVideo.Id}"
            );

            // Get highest quality muxed stream
            streamInfo = streamManifest.GetMuxedStreams();

            var videoPlayerStream = streamInfo.First(video => video.VideoQuality.Label is "240p" or "360p");

            VideoSource = videoPlayerStream.Url;
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
            if (IsDownloading)
                return;

            var progressIndicator = new Progress<double>((value) => ProgressValue = value);
            var cts = new CancellationTokenSource();

            try
            {
                IsDownloading = true;

                var urlToDownload = streamInfo.OrderByDescending(video => video.VideoResolution.Area).First().Url;

                //Download the file
                var downloadedFilePath = await fileDownloadService.DownloadFileAsync(
                    urlToDownload,
                    TheVideo.Snippet.Title.CleanCacheKey() + ".mp4",
                    progressIndicator,
                    cts.Token);

                //Save the File
                await Share.RequestAsync(new ShareFileRequest
                {
                    File = new ShareFile(downloadedFilePath),
                    Title = TheVideo.Snippet.Title
                });
            }
            catch (OperationCanceledException ex)
            {
                //Handle Exception and Cancellation Token here
            }
            finally
            {
                IsDownloading = false;
            }
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
