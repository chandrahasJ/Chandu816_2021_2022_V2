namespace YTwitchPlayer.ViewModels.Base
{
    public partial class AppViewModelBase : ViewModelBase
    {
        #region Properties
        public INavigation NavigationService { get; set; }
        public Page PageService { get; set; }
        protected IApiService _appApiService { get; set; }
        #endregion Properties

        #region Commands
        [RelayCommand]
        private async Task NavigateBack() =>
            await NavigationService.PopAsync();

        [RelayCommand]
        private async Task CloseModal() =>
            await NavigationService.PopModalAsync();
        #endregion Commands

        public AppViewModelBase(IApiService apiService):base()
        {
            _appApiService = apiService;
        }
    }
}
