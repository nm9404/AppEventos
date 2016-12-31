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
using Eventos.core.DataService;
using Eventos.Adapters;

namespace Eventos.Fragments
{
    public class CalendarFragment : SupportFragment
    {
        public ListView calendarListView;
        public DataService dataServiceInstance;
        public Button calendarShareButton;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        //<summary>
        //This function overrides OnCreateView in order to inflate the view CalendarFragmentView.axml on the fragment
        //</summary>
        //<return>
        //returns the inflated view of this fragment
        //</return>
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            View view = inflater.Inflate(Resource.Layout.CalendarFragmentView, container, false);
            return view;
        }

        //<summary>
        //This function overrides OnActivityCreated finding each view for this fragment and calling the event Handlers
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
        public void FindViews()
        {
            calendarListView = this.View.FindViewById<ListView>(Resource.Id.calendarListView);
            calendarShareButton = this.View.FindViewById<Button>(Resource.Id.shareButtonCalendar);
        }

        //<summary>
        //This function sets the adapter for the calendar and the Agenda of the event
        //</summary>
        public void PopulateData()
        {
            List<int> dates = new List<int>();
            dates = YearListOrder.ConferenceToDates(dataServiceInstance.GetAllConferences());
            CalendarAdapterA calendarAdapterA = new CalendarAdapterA(dates, this.Activity, dataServiceInstance);
            calendarListView.Adapter = calendarAdapterA;
        }

        //<summary>
        //Sets the delegates of each event
        //</summary>
        public void HandleEvents()
        {
            calendarShareButton.Click += ShareContent;
        }

        //<summary>
        //Creates the sharing intent of the URL and puts the text
        //</summary>
        //<param name ="sender">
        //Is the object that calls the event, in this case a button
        //</param>
        //<param name ="e">
        //EventArgs for the Click Event
        //</param>
        public void ShareContent(object sender, EventArgs e)
        {
            string uri = "http://colombiamoda.inexmoda.org.co/";
            Intent shareIntent = new Intent(Android.Content.Intent.ActionSend);
            shareIntent.SetType("text/plain");
            String shareSub = "Programación de ColombiaModa";
            shareIntent.PutExtra(Android.Content.Intent.ExtraSubject, shareSub);
            shareIntent.PutExtra(Android.Content.Intent.ExtraText, "¡ColombiaModa 2016!, no te pierdas la programación del evento, consúltala en: \n" + uri);

            StartActivity(Intent.CreateChooser(shareIntent, "Compartir vía"));
        }

        //<summary>
        //This function sets the list of presenters from the DataService
        //</summary>
        //<param name = "dataServiceInstance">
        //this parameter is the DataServiceInstance created from the splashActivity with all the Data of the event and this is parsed from the MainActivity to instantiate the data for this fragment
        //</param>
        public void InstantiateDataService(DataService dataServiceInstance)
        {
            this.dataServiceInstance = dataServiceInstance;
        }
    }
}