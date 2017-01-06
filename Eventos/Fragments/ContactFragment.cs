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

        //<summary>
        //This function overrides OnCreateView in order to inflate the view ContactFragmentView.axml on the fragment
        //</summary>
        //<return>
        //returns the inflated view of this fragment
        //</return>
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            View view = inflater.Inflate(Resource.Layout.ContactFragmentView, container, false);
            return view;
        }

        //<summary>
        //This function overrides OnActivityCreated finding each view for this fragmeny
        //</summary>
        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            base.OnActivityCreated(savedInstanceState);
            FindViews();
            HandleEvents();
        }

        //<summary>
        //This function finds all the views from the file ContactFragmentView.axml
        //</summary>
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

        //<summary>
        //Sets the delegates of each event
        //</summary>
        private void HandleEvents()
        {
            facebookButton.Click += FacebookIntent;
            twitterButton.Click += TwitterIntent;
            instagramButton.Click += InstagramIntent;
        }

        //SocialNetworks intents, the only different thing from one another is the URI.

        //<summary>
        //Launches the social network intent, this function may be used within a delegate
        //</summary>
        //<param name = "sender">
        //Is the object that Listens to the event, in this case a button
        //</param>
        //<param name = "e">
        //EventArgs for the ClickEvent
        //</param>
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

        //<summary>
        //This function instantiates all the required data for the fragment recieving the dataService instance
        //</summary>
        //<param name ="dataServiceInstance">
        //Instance of the dataService created from the SplashActivity with all the app's Data
        //</param>
        public void InstantiateDataService(DataService dataServiceInstance)
        {
            this.dataServiceInstance = dataServiceInstance;
        }

        //<summary>
        //Sets the background picture for the mainFragment
        //</summary>
        public void SetBackgrounds()
        {
            ImageTarget target = new ImageTarget(mainLayout);
            //string url = "http://testappeventos.webcindario.com/Imagenes/" + dataServiceInstance.GetEvent().Place.Picture.ImagePath + ".jpg";
            Picasso.With(this.Activity).Load(Resource.Drawable.placeImage).CenterCrop().Resize(720, 1025).Into(target);
        }

        //<summary>
        //This function sets all the texts in the TextViews of the fragment's view
        //</summary>
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