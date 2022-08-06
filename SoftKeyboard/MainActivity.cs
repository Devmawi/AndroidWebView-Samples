using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Webkit;
using AndroidX.AppCompat.App;

namespace SoftKeyboard
{
    [Activity(Label = "@string/app_name", Theme = "@style/Theme.MaterialComponents.Light.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            WebView.SetWebContentsDebuggingEnabled(true);
            var webview = FindViewById<WebView>(Resource.Id.webView);
            webview.LoadUrl("file:///android_asset/index.html");
            webview.Settings.JavaScriptEnabled = true;
            webview.RequestFocus();
            Window.SetSoftInputMode(SoftInput.StateAlwaysHidden);
            HideNavAndStatusBar();
            webview.AddJavascriptInterface(new InputMethodManagerJsInterface(this), "InputMethodManager");
        }

        protected override void OnResume()
        {
            base.OnResume();
            HideNavAndStatusBar();

        }

        private void HideNavAndStatusBar()
        {
            int uiOptions = (int)Window.DecorView.SystemUiVisibility;
            uiOptions |= (int)SystemUiFlags.LowProfile;
            uiOptions |= (int)SystemUiFlags.Fullscreen;
            uiOptions |= (int)SystemUiFlags.HideNavigation;
            uiOptions |= (int)SystemUiFlags.ImmersiveSticky;
            Window.DecorView.SystemUiVisibility = (StatusBarVisibility)uiOptions;

        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}