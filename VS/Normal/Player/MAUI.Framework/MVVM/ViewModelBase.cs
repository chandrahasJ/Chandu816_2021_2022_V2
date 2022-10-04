namespace MAUIApp.Framework.MVVM
{
    public partial class ViewModelBase : ObservableObject
    {
        [ObservableProperty]
        private string title = string.Empty;

        [ObservableProperty]
        private string loadingText = string.Empty;

        [ObservableProperty]
        private string errorMessage = string.Empty;

        [ObservableProperty]
        private string errorImage = string.Empty;

        [ObservableProperty]
        private bool isBusy = false;

        [ObservableProperty]
        private bool dataLoaded = false;

        [ObservableProperty]
        private bool isErrorState = false;

        public ViewModelBase() => IsErrorState = false;

        //Called on Page Appearing
        public virtual async void OnNavigatedTo(object parameters) =>
            await Task.CompletedTask;

        //Set Loading Indicator for Page
        protected void SetLoadingIndicator(bool isStarting = true)
        {
            if (isStarting)
            {
                IsBusy = true;
                DataLoaded = false; 
                IsErrorState = false;
                ErrorMessage = string.Empty;
                ErrorImage = String.Empty;
            }
            else
            {
                LoadingText = "";
                IsBusy = false; 
            }
        }
    }
}
