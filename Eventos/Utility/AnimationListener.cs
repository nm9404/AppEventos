using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Views.Animations;
using Android.Widget;
using Newtonsoft.Json;
using System.IO;

//<summary>
//This class is able to call all the methods of the animation listener used in the launch activity, implementing the interface Android.Views.Animations.Animation.IAnimationListener
//</summary>
//<see>
//SplashActivity
//</see>


namespace Eventos.Utility
{
    class AnimationListener : Java.Lang.Object, Android.Views.Animations.Animation.IAnimationListener
    {
        public SplashActivity context;

        public AnimationListener(SplashActivity context)
        {
            this.context = context;
        }

        //<summary>
        //    After the animation finishes, this method is called automatically and checks if an internet connection is available in context, also creates a JSon file in order to save it into the internal memory of the device, if no internet connection appears, this function is able to call the alert Dialog or exit the application in case of an error
        //</summary>
        //<param name = "animation">
        //    Recieves the animation that's calling the Listener
        //</param>

        public void OnAnimationEnd(Animation animation)
        {
            context.CheckInternetConnection();
            if (context.dataServiceInstance.GetEvent().Conferences != null)
            {
                context.data = JsonConvert.SerializeObject(context.dataServiceInstance.GetEvent());
                context.SaveDataToJsonFile();
            }
            else
            {
                context.data = "";
            }

            if (context.data == "{}" || context.data==null || context.data=="")
            {
                if (context.IsInternetConnectionAvailable())
                {
                    context.BuildAlertDialog();
                }
            }
            else
            {
                context.StartMainActivity();
            }
        }

        public void OnAnimationRepeat(Animation animation)
        {
            return;
        }

        public void OnAnimationStart(Animation animation)
        {
            return;
        }
    }
}