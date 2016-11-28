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
using Eventos.core.DataService;
using Eventos.Utility;
using Square.Picasso;

namespace Eventos.Fragments
{
    public class ContactFragment : SupportFragment
    {
        DataService dataServiceInstance;
        TextView eventNameText;
        TextView eventDateText;
        TextView eventAddressText;
        TextView eventDescriptionText;
        TextView eventHashTagText;
        TextView eventEmailText;
        TextView eventNumberText;
        LinearLayout mainLayout;
        Button facebookButton;
        Button twitterButton;
        Button instagramButton;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            View view = inflater.Inflate(Resource.Layout.ContactFragmentView, container, false);
            return view;
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            base.OnActivityCreated(savedInstanceState);
            FindViews();
            HandleEvents();
        }

        private void FindViews()
        {
            eventNameText = this.View.FindViewById<TextView>(Resource.Id.eventTitleTextContact);
            eventDateText = this.View.FindViewById<TextView>(Resource.Id.eventDateTextContact);
            eventDescriptionText = this.View.FindViewById<TextView>(Resource.Id.eventDescriptionTextContact);
            eventHashTagText = this.View.FindViewById<TextView>(Resource.Id.eventHashtagContact);
            eventEmailText = this.View.FindViewById<TextView>(Resource.Id.eventMailTextContact);
            eventNumberText = this.View.FindViewById<TextView>(Resource.Id.eventPhoneNumbersContact);
            eventAddressText = this.View.FindViewById<TextView>(Resource.Id.eventPlaceTextContact);
            mainLayout = this.View.FindViewById<LinearLayout>(Resource.Id.contactLayout);
            facebookButton = this.View.FindViewById<Button>(Resource.Id.contactFacebookButton);
            twitterButton = this.View.FindViewById<Button>(Resource.Id.contactTwitterButton);
            instagramButton = this.View.FindViewById<Button>(Resource.Id.contactInstagramButton);
        }

        private void HandleEvents()
        {
            facebookButton.Click += FacebookIntent;
            twitterButton.Click += TwitterIntent;
            instagramButton.Click += InstagramIntent;
        }

        private void FacebookIntent(object sender, EventArgs e)
        {
            Android.Net.Uri uri = Android.Net.Uri.Parse("fb://page/153563447786");
            Intent intent = new Intent(Intent.ActionView, uri);
            StartActivity(intent);
        }

        private void TwitterIntent(object sender, EventArgs e)
        {
            Android.Net.Uri uri = Android.Net.Uri.Parse("twitter://user?screen_name=inexmoda");
            Intent intent = new Intent(Intent.ActionView, uri);
            StartActivity(intent);
        }

        private void InstagramIntent(object sender, EventArgs e)
        {
            Android.Net.Uri uri = Android.Net.Uri.Parse("http://instagram.com/_u/inexmoda");
            Intent intent = new Intent(Intent.ActionView, uri);
            StartActivity(intent);
        }

        public void InstantiateDataService(DataService dataServiceInstance)
        {
            this.dataServiceInstance = dataServiceInstance;
        }

        public void SetBackgrounds()
        {
            ImageTarget target = new ImageTarget(mainLayout);
            string url = "http://testappeventos.webcindario.com/Imagenes/" + dataServiceInstance.GetEvent().Place.Picture.ImagePath + ".jpg";
            Picasso.With(this.Activity).Load(url).CenterCrop().Resize(720, 1025).Into(target);
        }

        public void PopulateData()
        {
            SetBackgrounds();
            eventNameText.Text = dataServiceInstance.GetEvent().EventInformation.EventName.ToString();
            eventAddressText.Text = dataServiceInstance.GetEvent().Place.Address.ToString();
            eventDescriptionText.Text = dataServiceInstance.GetEvent().EventInformation.EventDescription.ToString();
            eventHashTagText.Text = "#" + dataServiceInstance.GetEvent().EventInformation.EventName.ToString();
            eventEmailText.Text = dataServiceInstance.GetEvent().EventInformation.EventName.ToString() + "@gmail.com";
            eventNumberText.Text = "+57 355 6879";
        }
    }
}