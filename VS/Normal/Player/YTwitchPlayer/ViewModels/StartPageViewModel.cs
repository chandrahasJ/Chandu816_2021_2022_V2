global using YTwitchPlayer.ViewModels.Base;

namespace YTwitchPlayer.ViewModels;

public class StartPageViewModel : AppViewModelBase
{
    public StartPageViewModel(IApiService apiService) : base(apiService)
    {
        this.Title = Constants.ApplicationName;
    }

    public override async void OnNavigatedTo(object parameters)
    {
        SetLoadingIndicator(true);

        LoadingText = "Please wait";

        try
        {
            await Task.Delay(5000);

            this.DataLoaded = true;
        }
        catch(InternetConnectionException iex)
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
}
