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
            context.data = JsonConvert.SerializeObject(context.dataServiceInstance.GetEvent());
            if (context.data == "{}")
            {
                context.BuildAlertDialog();
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