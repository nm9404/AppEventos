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
using Eventos.core.DataService;

namespace Eventos.Adapters
{
    class ConferenceDescriptionAdapter : BaseAdapter<Conference>
    {
        List<Conference> items;
        Activity context;
        DataService dataServiceInstance;

        //This class implements the interface BaseAdapter<Conference>, BaseAdapter<Conference> where xx can be any other type of data

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
        public override Conference this[int position]
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
        //List of elements for the Adapter in this case a list of type Conference
        //</param>
        //<param name = "context">
        //Activity containing the fragment
        //</param>
        //<param name = "dataServiceInstance">
        //instance of DataService with all the required data
        //</param>
        public ConferenceDescriptionAdapter (List<Conference> items, Activity context, DataService dataServiceInstance)
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
            convertView = context.LayoutInflater.Inflate(Resource.Layout.ConferenceDescriptionRow, parent, false);
            convertView.FindViewById<TextView>(Resource.Id.conferenceTitleDescription).Text = items[position].Title;
            convertView.FindViewById<TextView>(Resource.Id.conferenceAbstractDescription).Text = items[position].Abstract;
            if (items[position].Abstract == null || items[position].Abstract == String.Empty)
            {
                convertView.FindViewById<TextView>(Resource.Id.conferenceAbstractDescription).Text = items[position].ShortDescription;
                if (items[position].ShortDescription == null || items[position].ShortDescription == String.Empty)
                {
                    string data = "Conferencia dicatada por: ";
                    List<Presenter> presenters = dataServiceInstance.GetPresentersByConferenceId(items[position].ConferenceId);

                    foreach (Presenter presenter in presenters)
                    {
                        data += presenter.Name;
                    }
                    convertView.FindViewById<TextView>(Resource.Id.conferenceAbstractDescription).Text = "Conferencia dictada por: " + data;
                }
            }
            return convertView;
        }
    }
}