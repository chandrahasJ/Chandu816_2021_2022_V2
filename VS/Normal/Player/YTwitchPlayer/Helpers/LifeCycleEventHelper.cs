using Microsoft.Maui.LifecycleEvents;

namespace YTwitchPlayer.Helpers
{
    public class LifeCycleEventHelper
    {
        public static void LifeCycleBuilder(ILifecycleBuilder lifecycleBuilder)
        {
#if ANDROID
            lifecycleBuilder.AddAndroid(android => android.OnCreate((activity, bundle) => MakeStatusBarTranslucent(activity)));
#endif
        }

#if ANDROID
        private static void MakeStatusBarTranslucent(Android.App.Activity activity)
        {
            activity.Window.SetFlags(Android.Views.WindowManagerFlags.LayoutNoLimits,
                                    Android.Views.WindowManagerFlags.LayoutNoLimits
                                    );

            activity.Window.ClearFlags(Android.Views.WindowManagerFlags.TranslucentStatus);

            activity.Window.SetStatusBarColor(Android.Graphics.Color.Transparent);
        }
#endif
    }
}
