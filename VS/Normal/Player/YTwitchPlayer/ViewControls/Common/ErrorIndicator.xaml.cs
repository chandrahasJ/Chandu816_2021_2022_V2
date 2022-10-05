namespace YTwitchPlayer.ViewControls.Common;

public partial class ErrorIndicator : VerticalStackLayout
{
    #region Bindable Properties
    //IsError
    public static readonly BindableProperty IsErrorProperty = BindableProperty.Create(
        "IsError",
        typeof(bool),
        typeof(ErrorIndicator),
        false,
        BindingMode.OneWay,
        null,
        SetIsError
    );

    public bool IsError 
    { 
        get => (bool)GetValue(IsErrorProperty);
        set => SetValue(IsErrorProperty, value);
    }

    private static void SetIsError(BindableObject bindable, object oldValue, object newValue) =>
        (bindable as ErrorIndicator).IsVisible = (bool)newValue;

    //ErrorText
    public static readonly BindableProperty ErrorTextProperty = BindableProperty.Create(
      "ErrorText",
      typeof(string),
      typeof(ErrorIndicator),
      string.Empty,
      BindingMode.OneWay,
      null,
      SetErrorText
    );

    public string ErrorText
    {
        get => (string)GetValue(ErrorTextProperty);
        set => SetValue(ErrorTextProperty, value);
    }

    private static void SetErrorText(BindableObject bindable, object oldValue, object newValue) =>
        (bindable as ErrorIndicator).lblErrorText.Text = (string)newValue;

    //ErrorImage
    public static readonly BindableProperty ErrorImageProperty = BindableProperty.Create(
      "ErrorImage",
      typeof(ImageSource),
      typeof(ErrorIndicator),
      null,
      BindingMode.OneWay,
      null,
      SetErrorImage
    );

    public string ErrorImage
    {
        get => (string)GetValue(ErrorImageProperty);
        set => SetValue(ErrorImageProperty, value);
    }

    private static void SetErrorImage(BindableObject bindable, object oldValue, object newValue) =>
        (bindable as ErrorIndicator).imgError.Source = (ImageSource)newValue;


    #endregion Bindable Properties

    public ErrorIndicator()
	{
		InitializeComponent();
	}
}