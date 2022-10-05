namespace YTwitchPlayer.Views.Base;

public partial class PageBase : ContentPage
{
    #region Expose PageContent, PageIcon Elements
    public IList<IView> PageContent => PageContentGrid.Children;
    public IList<IView> PageIcons => PageIconsGrid.Children;
    #endregion Expose PageContent, PageIcon Elements

    #region Properties
    protected bool IsBackButtonEnabled { set => NavigateBackButton.IsEnabled = value; }
    #endregion Properties

    #region Bindable Properties     
    //PageTitle
    public static readonly BindableProperty PageTitleProperty = BindableProperty.Create(
      "PageTitle",
      typeof(string),
      typeof(PageBase),
      string.Empty,
      BindingMode.OneWay,
      null,
      propertyChanged: OnPageTitleChanged
    );

    public string PageTitle
    {
        get => (string)GetValue(PageTitleProperty);
        set => SetValue(PageTitleProperty, value);
    }

    private static void OnPageTitleChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable != null && bindable is PageBase basePage)
        {
            basePage.TitleLabel.Text = (string)newValue;
            basePage.TitleLabel.IsVisible = true;
        }
    }

    //PageMode
    public static readonly BindableProperty PageModeProperty = BindableProperty.Create(
      nameof(PageMode),
      typeof(PageMode),
      typeof(PageBase),
      PageMode.None,
      BindingMode.OneWay,
      propertyChanged: OnPageModeChanged
    );

    public PageMode PageMode
    {
        get => (PageMode)GetValue(PageModeProperty);
        set => SetValue(PageModeProperty, value);
    }

    private static void OnPageModeChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable != null && bindable is PageBase basePage)
            basePage.SetPageMode((PageMode)newValue);
    }

    //ContentDisplayMode
    public static readonly BindableProperty ContentDisplayModeProperty = BindableProperty.Create(
      nameof(ContentDisplayMode),
      typeof(ContentDisplayMode),
      typeof(PageBase),
      ContentDisplayMode.NavigationBar,
      BindingMode.OneWay,
      propertyChanged: OnContentDisplayModeChanged
    );

    public ContentDisplayMode ContentDisplayMode
    {
        get => (ContentDisplayMode)GetValue(ContentDisplayModeProperty);
        set => SetValue(ContentDisplayModeProperty, value);
    }

    private static void OnContentDisplayModeChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable != null && bindable is PageBase basePage)
            basePage.SetContentDisplayMode((ContentDisplayMode)newValue);
    }

    #endregion Bindable Properties

    public PageBase()
	{
		InitializeComponent();

        // Hide the Form build in navigation header
        NavigationPage.SetHasNavigationBar(this, false);

        //Set Page Mode
        SetPageMode(PageMode.None);

        //Set Content Display Mode
        SetContentDisplayMode(ContentDisplayMode.NoNavigationBar);
	}

    #region Private Method
    private void SetPageMode(PageMode pageMode)
    {
        switch (pageMode)
        {            
            case PageMode.Menu:
                HamburgerButton.IsVisible = true;
                NavigateBackButton.IsVisible = false;
                CloseButton.IsVisible = false;
                break;
            case PageMode.Navigate:
                HamburgerButton.IsVisible = false;
                NavigateBackButton.IsVisible = true;
                CloseButton.IsVisible = false;
                break;
            case PageMode.Modal:
                HamburgerButton.IsVisible = false;
                NavigateBackButton.IsVisible = false;
                CloseButton.IsVisible = true;
                break;
            default:
                HamburgerButton.IsVisible = false;
                NavigateBackButton.IsVisible = false;
                CloseButton.IsVisible = false;
                break;
        }
    }

    private void SetContentDisplayMode(ContentDisplayMode contentDisplayMode)
    {
        switch (contentDisplayMode)
        {
            case ContentDisplayMode.NoNavigationBar:
                Grid.SetRow(PageContentGrid, 0);
                Grid.SetRowSpan(PageContentGrid, 3);
                break;
            case ContentDisplayMode.NavigationBar:
                Grid.SetRow(PageContentGrid, 2);
                Grid.SetRowSpan(PageContentGrid, 1);
                break;       
            default:
                // Nothing needs to be done...
                break;
        }
    }
    #endregion Private Method

}