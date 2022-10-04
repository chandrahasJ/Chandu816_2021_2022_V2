﻿#if WINDOWS
using Microsoft.UI;
using Microsoft.UI.Windowing;
using Windows.Graphics;
#endif
using Microsoft.Maui.Controls;

namespace YTwitchPlayer;

public partial class App : Application
{
	const int WindowWidth = 540;
	const int WindowHeight = 800;
	public App()
	{
		InitializeComponent();

		//Enable Version Tracking
		VersionTracking.Track();

		//Set Up App Size on MS Windows
		Microsoft.Maui.Handlers.WindowHandler.Mapper.AppendToMapping(nameof(IWindow), (handler, view) =>
		{
#if WINDOWS
			var mauiWindow = handler.VirtualView;
			var nativeWindow = handler.PlatformView;
			nativeWindow.Activate();
			IntPtr windowHandle = WinRT.Interop.WindowNative.GetWindowHandle(nativeWindow);
			WindowId windowId= Microsoft.UI.Win32Interop.GetWindowIdFromWindow(windowHandle);
			AppWindow appWindow = Microsoft.UI.Windowing.AppWindow.GetFromWindowId(windowId);
			appWindow.Resize(new SizeInt32(WindowWidth, WindowHeight));
#endif
        });

		MainPage = new NavigationPage(new StartPage());
	}
}
