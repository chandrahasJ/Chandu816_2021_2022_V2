using Microsoft.Maui.LifecycleEvents;
using YTwitchPlayer.Helpers;

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
			.ConfigureLifecycleEvents(events => LifeCycleEventHelper.LifeCycleBuilder(events));

		return builder.Build();
	}
}
