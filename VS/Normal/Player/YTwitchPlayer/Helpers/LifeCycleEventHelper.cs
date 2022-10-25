using Android.Views;
using Microsoft.Maui.LifecycleEvents;

namespace YTwitchPlayer.Helpers
{
    public class LifeCycleEventHelper
    {
        public static void LifeCycleBuilder(ILifecycleBuilder lifecycleBuilder)
        {
#if ANDROID
            lifecycleBuilder.AddAndroid(android => android.OnCreate((activity, bundle) => { 
                MakeStatusBarTranslucent(activity);
                MakeThreeButtonHide(activity);
            }));
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

        private static void MakeThreeButtonHide(Android.App.Activity activity)
        {
            activity.Window.DecorView.SystemUiVisibility = (StatusBarVisibility)
                    (SystemUiFlags.ImmersiveSticky | SystemUiFlags.HideNavigation |
                     SystemUiFlags.Fullscreen | SystemUiFlags.Immersive);
        }
#endif
    }
}
