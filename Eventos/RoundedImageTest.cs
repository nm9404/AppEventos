using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Support.V7.App;

namespace Eventos
{
    [Activity(Label = "RoundedImageTest", MainLauncher = false, Theme = "@style/MyTheme")]
    public class RoundedImageTest : ActionBarActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ContactFragmentView);
            // Create your application here
        }
    }
}