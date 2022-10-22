namespace YTwitchPlayer.Views;

public partial class StartPage : ViewBase<StartPageViewModel>
{

    #region Bindable Property
    //ItemsHeightProperty
    public static BindableProperty ItemsHeightProperty = BindableProperty.Create(
      nameof(ItemsHeight),
      typeof(double),
      typeof(StartPage),
      null,
      BindingMode.OneWay
    );

    public double ItemsHeight
    {
        get => (double)GetValue(ItemsHeightProperty);
        set => SetValue(ItemsHeightProperty, value);
    }
   
    #endregion Bindable Property

    public StartPage()
	{
		InitializeComponent();
	}

    protected override void OnSizeAllocated(double width, double height)
    {
        base.OnSizeAllocated(width, height);

        ItemsHeight = 60d + (width - lstOfVideo.Margin.Right - lstOfVideo.Margin.Left) / 1.8d;
    }
}