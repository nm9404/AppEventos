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

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            View view = inflater.Inflate(Resource.Layout.CalendarFragmentView, container, false);
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
            calendarListView = this.View.FindViewById<ListView>(Resource.Id.calendarListView);
            calendarShareButton = this.View.FindViewById<Button>(Resource.Id.shareButtonCalendar);
        }

        public void PopulateData()
        {
            List<int> dates = new List<int>();
            dates = YearListOrder.ConferenceToDates(dataServiceInstance.GetAllConferences());
            CalendarAdapterA calendarAdapterA = new CalendarAdapterA(dates, this.Activity, dataServiceInstance);
            calendarListView.Adapter = calendarAdapterA;
        }

        public void HandleEvents()
        {
            calendarShareButton.Click += ShareContent;
        }

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

        public void InstantiateDataService(DataService dataServiceInstance)
        {
            this.dataServiceInstance = dataServiceInstance;
        }
    }
}