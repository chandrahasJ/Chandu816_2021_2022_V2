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
#pragma warning disable CS0618 // Type or member is obsolete
            activity.Window.DecorView.SystemUiVisibility = (Android.Views.StatusBarVisibility)
                    (Android.Views.SystemUiFlags.ImmersiveSticky | Android.Views.SystemUiFlags.HideNavigation |
                     Android.Views.SystemUiFlags.Fullscreen | Android.Views.SystemUiFlags.Immersive);
#pragma warning restore CS0618 // Type or member is obsolete
        }
#endif
    }
}
