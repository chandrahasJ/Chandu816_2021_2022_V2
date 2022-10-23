using CommunityToolkit.Maui;

namespace YTwitchPlayer;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("FiraSans-Light.ttf", "RegularFont");
				fonts.AddFont("FiraSans-Medium.ttf", "MediumFont");
			})
			.ConfigureLifecycleEvents(events => LifeCycleEventHelper.LifeCycleBuilder(events))
			.UseMauiCommunityToolkit();

		RegisterServices(builder.Services);


        return builder.Build();
	}

	public static void RegisterServices(IServiceCollection services)
	{
        // Add Platform spefic Dependencies
        services.AddSingleton<IConnectivity>(Connectivity.Current);

		// Register Barrel Cache
		Barrel.ApplicationId = Constants.ApplicationId;
		services.AddSingleton<IBarrel>(Barrel.Current);

		//Register API services
		services.AddSingleton<IApiService, YService>();

		//Register ViewModel
		services.AddSingleton<StartPageViewModel>();
		services.AddTransient<VideoDetailsPageViewModel>();

	}
}
