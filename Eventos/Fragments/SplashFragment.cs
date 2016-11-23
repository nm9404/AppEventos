using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using SupportFragment = Android.Support.V4.App.Fragment;
using Eventos.Utility;
using Square.Picasso;
using static Android.Resource;
using Android.Views.Animations;
using System.Threading.Tasks;

namespace Eventos.Fragments
{
    public class SplashFragment : SupportFragment
    {
        public ImageView splashImage;
        public ImageView logoImage;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            View view = inflater.Inflate(Resource.Layout.SplashView, container, false);
            return view;
        }


        public void SetBackgrounds()
        {
            Picasso.With(this.Activity).Load("http://testappeventos.webcindario.com/Imagenes/EventImage/1b.png").Into(splashImage);
            Picasso.With(this.Activity).Load("http://testappeventos.webcindario.com/Imagenes/EventImage/LogoDynamik_Horizontal.png").Into(logoImage);

            Android.Views.Animations.Animation fade = AnimationUtils.LoadAnimation(this.Activity, Resource.Animation.animationSplah);
            splashImage.StartAnimation(fade);
            logoImage.StartAnimation(fade);
            Task.Run(() => this.sleep(5000)); 
        }

        public void FindViews()
        {
            splashImage = this.View.FindViewById<ImageView>(Resource.Id.eventLogoImageSplash);
            logoImage = this.View.FindViewById<ImageView>(Resource.Id.dynamikLogoImage);
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            base.OnActivityCreated(savedInstanceState);
            FindViews();
            SetBackgrounds();
        }

        public async Task sleep(int miliSeconds)
        {
            await Task.Delay(miliSeconds);
            MainActivity activity = (MainActivity)this.Activity;
            activity.ShowFragment(activity.mainMenuFragment);
            activity.CreateActionDrawer();
        }
    }
}