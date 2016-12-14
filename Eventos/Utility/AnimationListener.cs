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

namespace Eventos.Utility
{
    class AnimationListener : Java.Lang.Object, Android.Views.Animations.Animation.IAnimationListener
    {
        public SplashActivity context;

        public AnimationListener(SplashActivity context)
        {
            this.context = context;
        }

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