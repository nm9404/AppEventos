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
        ListView calendarListView;
        public DataService dataServiceInstance;

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
        }

        public void FindViews()
        {
            calendarListView = this.View.FindViewById<ListView>(Resource.Id.calendarListView);
        }

        public void PopulateData()
        {
            List<int> dates = new List<int>();
            dates = YearListOrder.ConferenceToDates(dataServiceInstance.GetAllConferences());
            CalendarAdapterA calendarAdapterA = new CalendarAdapterA(dates, this.Activity, dataServiceInstance);
            calendarListView.Adapter = calendarAdapterA;
        }

        public void InstantiateDataService(DataService dataServiceInstance)
        {
            this.dataServiceInstance = dataServiceInstance;
        }
    }
}