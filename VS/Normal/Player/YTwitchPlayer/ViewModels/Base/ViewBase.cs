
namespace YTwitchPlayer.ViewModels.Base;

public class ViewBase<TViewModel> : PageBase where TViewModel : AppViewModelBase
{
    #region Variables
    protected bool _isLoaded = false;
    protected event EventHandler ViewModelInitialized;
    #endregion Variables

    #region Properties
    protected TViewModel ViewModel { get; set; }
    public object ViewModelParameters { get; set; }
    #endregion Properties

    #region Constructors
    public ViewBase() : base()
    {
    }

    public ViewBase(object initialParameter) : base() =>
        ViewModelParameters = initialParameter;
    #endregion Constructors

    #region Methods
    protected override async void OnAppearing()
    {
        if (!_isLoaded)
        {
            base.OnAppearing();

            BindingContext = ViewModel = ServiceHelper.GetService<TViewModel>();

            ViewModel.NavigationService = this.Navigation;
            ViewModel.PageService = this;

            //Raise the Event to Notify that ViewModel has been Initialized.
            ViewModelInitialized?.Invoke(this, new EventArgs());

            // If OnNavigatedTo is Implemented in Child Class it will be called.
            await ViewModel.OnNavigatedTo(ViewModelParameters);

            _isLoaded = true;
        }
    }
    #endregion Methods 
}
