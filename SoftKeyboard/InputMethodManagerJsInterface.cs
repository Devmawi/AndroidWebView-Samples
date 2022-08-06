using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Views.InputMethods;
using Android.Webkit;
using Android.Widget;
using Java.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftKeyboard
{
    class InputMethodManagerJsInterface : Java.Lang.Object
    {
        Context context;

        public InputMethodManagerJsInterface(Context context)
        {
            this.context = context;
        }

        [JavascriptInterface]
        [Export]
        public void HideSoftInput()
        {
            InputMethodManager inputMethodManager = (InputMethodManager)context.GetSystemService(Activity.InputMethodService);

            Activity activity = (Activity)context;
           inputMethodManager.HideSoftInputFromWindow(activity.CurrentFocus.WindowToken, 0);
        }
    }
}