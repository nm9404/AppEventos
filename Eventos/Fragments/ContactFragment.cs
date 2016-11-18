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
        }

        public void FindViews()
        {
            eventNameText = this.View.FindViewById<TextView>(Resource.Id.eventTitleTextContact);
            eventDateText = this.View.FindViewById<TextView>(Resource.Id.eventDateTextContact);
            eventDescriptionText = this.View.FindViewById<TextView>(Resource.Id.eventDescriptionTextContact);
            eventHashTagText = this.View.FindViewById<TextView>(Resource.Id.eventHashtagContact);
            eventEmailText = this.View.FindViewById<TextView>(Resource.Id.eventMailTextContact);
            eventNumberText = this.View.FindViewById<TextView>(Resource.Id.eventPhoneNumbersContact);
            eventAddressText = this.View.FindViewById<TextView>(Resource.Id.eventPlaceTextContact);
        }

        public void InstantiateDataService(DataService dataServiceInstance)
        {
            this.dataServiceInstance = dataServiceInstance;
        }

        public void PopulateData()
        {
            eventNameText.Text = dataServiceInstance.GetEvent().EventInformation.EventName;
            eventAddressText.Text = dataServiceInstance.GetEvent().Place.Address;
            eventDescriptionText.Text = dataServiceInstance.GetEvent().EventInformation.EventDescription;
            eventHashTagText.Text = "#" + dataServiceInstance.GetEvent().EventInformation.EventName;
            eventEmailText.Text = dataServiceInstance.GetEvent().EventInformation.EventName + "@gmail.com";
            eventNumberText.Text = "+57 355 6879";
        }
    }
}