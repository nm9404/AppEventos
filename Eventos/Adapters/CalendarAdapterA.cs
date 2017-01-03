using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Eventos.core.Model;
using Eventos.Utility;
using Eventos.core.DataService;

namespace Eventos.Adapters
{
    class CalendarAdapterA : BaseAdapter<int>
    {
        private List<int> items; //List of the same type of the baseAdapter
        private Activity context;
        private DataService dataServiceInstance;

        //This class implements the interface BaseAdapter<int>, BaseAdapter<xx> where xx can be any other type of data

        //<summary>
        //Returns the number of items of the list
        //</summary>
        public override int Count
        {
            get
            {
                return items.Count();
            }
        }

        //<summary>
        //Returns the item at a given position
        //</summary>
        //<param name = "position">
        //the position on the list for the item
        //</param>
        //<return>
        //An item of the list at its given position
        //</return>
        public override int this[int position]
        {
            get
            {
                return items[position];
            }
        }

        //<summary>
        //Builds the Adapter
        //</summary>
        //<param name = "items">
        //List of elements for the Adapter in this case a list of type int
        //</param>
        //<param name = "context">
        //Activity containing the fragment
        //</param>
        //<param name = "dataServiceInstance">
        //instance of DataService with all the required data
        //</param>
        public CalendarAdapterA(List<int> items, Activity context, DataService dataServiceInstance)
        {
            this.items = items;
            this.context = context;
            this.dataServiceInstance = dataServiceInstance;
        }

        //<summary>
        //Returns the position of each element of the Adapter
        //</summary>
        //<param name = "position">
        //position on the list for each item
        //</param>
        //<return>
        //returns the given position
        //</return>
        public override long GetItemId(int position)
        {
            return position;
        }

        //<summary>
        //Sets and inflates the row view for each list or grid, then it returns the row view with all the data instantiated
        //</summary>
        //<param name = "position">
        //position on the list for each item
        //</param>
        //<param name = "convertView">
        //View that will inflate the row view
        //</param>
        //<param name = "parent">
        //parent of the convertView
        //</param>
        //<return>
        //returns the inflated and instantiated Row-View
        //</return>
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            convertView = context.LayoutInflater.Inflate(Resource.Layout.CalendarDayRowView, parent, false);

            DateF date = YearListOrder.ConvetNumberToDateObject((int)items[position]);

            convertView.FindViewById<TextView>(Resource.Id.dayCalendar).Text = date.Day.ToString();
            convertView.FindViewById<TextView>(Resource.Id.monthCalendar).Text = Conversions.ConvertNumberToMonth(date.Month);

            List<Conference> allConferencesInDate = dataServiceInstance.GetConferencesByDay(date);
            ConferenceDescriptionAdapter conferenceDescriptionAdapter = new ConferenceDescriptionAdapter(allConferencesInDate, context, dataServiceInstance);

            LinearLayout layout = convertView.FindViewById<LinearLayout>(Resource.Id.calendarCardView);

            for (int i = 0; i < allConferencesInDate.Count(); i++)
            {
                View view = conferenceDescriptionAdapter.GetView(i, null, null);
                view.Tag = allConferencesInDate[i].ConferenceId.ToString();
                view.Click += DateItemClick; //EventClick Delegate
                layout.AddView(view);
            }
            
            return convertView;
        }

        //<summary>
        //This event sets the ClickEvent for each row on the Agenda
        //</summary>
        //<param name = "sender">
        //Object that sends the EventClick in this case each conference by date on a row
        //</param>
        //<param name = "e">
        //EventArgs for the click event
        //</param>
        public void DateItemClick(object sender, EventArgs e)
        {
            View castedSender = (View)sender;
            MainActivity mainActivity = (MainActivity)context;
            mainActivity.presenterDetailFragment.PopulateData(mainActivity.presenterDetailFragment.GetPresenterPositionFromId(dataServiceInstance.GetPresentersByConferenceId(Int32.Parse(castedSender.Tag.ToString()))[0].PresenterId));
            mainActivity.ShowFragment(mainActivity.presenterDetailFragment);
        }
    }
}