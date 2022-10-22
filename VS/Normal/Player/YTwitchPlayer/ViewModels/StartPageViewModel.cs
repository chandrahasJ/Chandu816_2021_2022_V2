﻿global using YTwitchPlayer.ViewModels.Base;
using MAUIApp.Framework.Extensions;
using System.Collections.ObjectModel;
using YTwitchPlayer.Models.YModels;

namespace YTwitchPlayer.ViewModels;

public partial class StartPageViewModel : AppViewModelBase
{
    private string nextToken = string.Empty;
    private string searchTerm = "Azure";

    [ObservableProperty]
    private ObservableCollection<YVideo> yVideos;

    public StartPageViewModel(IApiService apiService) : base(apiService)
    {
        this.Title = Constants.ApplicationName;
    }

    public override async void OnNavigatedTo(object parameters)
    {
         Search();
        await Task.CompletedTask;
    }

    private async void Search()
    {
        SetLoadingIndicator(true);

        LoadingText = "Please wait";

        YVideos = new();

        try
        {
            //Search for Video
            await GetTVideo();

            this.DataLoaded = true;
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

    private async Task GetTVideo()
    {
        //Search the video
        var videoSearchResult = await _appApiService.SearchVideos(searchTerm, nextToken);

        nextToken = videoSearchResult.NextPageToken;

        // Create comma separated channel id list.
        var channelIDs = string.Join(",", videoSearchResult.YVideos.Select(videos => videos.Snippet.ChannelId).Distinct());

        var channelSearchResult = await _appApiService.GetChannels(channelIDs);

        //Set Channel Url in the video.
        videoSearchResult.YVideos.ForEach(video =>
                video.Snippet.ChannelImageUrl =
                        channelSearchResult.Channels.Where(channnel =>
                             channnel.Id == video.Snippet.ChannelId).First().Snippet.Thumbnails.High.Url
        );



        //Add the video for display.
        YVideos.AddRange(videoSearchResult.YVideos);
    }

    [RelayCommand]
    private async void OpenSetting()
    {
        await PageService.DisplayAlert("Setting", "Not Implemented!", "Got it.");
    }
}
