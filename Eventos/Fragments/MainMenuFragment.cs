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

namespace Eventos
{
    public class MainMenuFragment : SupportFragment
    {
        public Button placeButton;
        public Button faqButton;
        public Button galleryButton;
        public Button presentersButton;
        public Button callendarButton;
        public Button contactButton;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            //return base.OnCreateView(inflater, container, savedInstanceState);
            View view = inflater.Inflate(Resource.Layout.MainMenuFragmentView, container, false);
            return view;
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            base.OnActivityCreated(savedInstanceState);
            FindViews();
            HandleEvents();
        }

        public void FindViews()
        {
            placeButton = this.View.FindViewById<Button>(Resource.Id.placeButton);
            faqButton = this.View.FindViewById<Button>(Resource.Id.faqButton);
            presentersButton = this.View.FindViewById<Button>(Resource.Id.personsButton);
            callendarButton = this.View.FindViewById<Button>(Resource.Id.calendarButton);
            contactButton = this.View.FindViewById<Button>(Resource.Id.contactButton);
            galleryButton = this.View.FindViewById<Button>(Resource.Id.galeryButton);
        }

        public void HandleEvents()
        {
            placeButton.Click += PlaceButtonEventClick;
        }

        public void PlaceButtonEventClick(object sender, EventArgs e)
        {
            MainActivity activity = (MainActivity)this.Activity;
            activity.InstanceDataOnFragments();
            activity.ShowFragment(activity.mapFragment);
        }
    }
}