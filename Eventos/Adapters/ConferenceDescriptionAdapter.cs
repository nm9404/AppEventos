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

namespace Eventos.Adapters
{
    class ConferenceDescriptionAdapter : BaseAdapter<Conference>
    {
        List<Conference> items;
        Activity context;

        public override int Count
        {
            get
            {
                return items.Count();
            }
        }

        public override Conference this[int position]
        {
            get
            {
                return items[position];
            }
        }

        public ConferenceDescriptionAdapter (List<Conference> items, Activity context)
        {
            this.items = items;
            this.context = context;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            convertView = context.LayoutInflater.Inflate(Resource.Layout.ConferenceDescriptionRow, parent, false);
            convertView.FindViewById<TextView>(Resource.Id.conferenceTitleDescription).Text = items[position].Title;
            convertView.FindViewById<TextView>(Resource.Id.conferenceAbstractDescription).Text = items[position].Abstract;
            return convertView;
        }
    }
}