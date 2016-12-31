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

        //<summary>
        //This class controls the SplashFragment
        //</summary>
        
       
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            

            // Create your fragment here
        }

        //<summary>
        //This function overrides OnCreateView in order to inflate the view SplashView.axml on the fragment
        //</summary>
        //<return>
        //returns the inflated view of this fragment
        //</return>
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            View view = inflater.Inflate(Resource.Layout.SplashView, container, false);
            return view;
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            base.OnActivityCreated(savedInstanceState);

        }

       
    }
}