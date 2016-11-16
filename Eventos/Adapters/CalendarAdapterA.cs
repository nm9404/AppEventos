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
        private List<int> items;
        private Activity context;
        private DataService dataServiceInstance;

        public override int Count
        {
            get
            {
                return items.Count();
            }
        }

        public override int this[int position]
        {
            get
            {
                return items[position];
            }
        }

        public CalendarAdapterA(List<int> items, Activity context, DataService dataServiceInstance)
        {
            this.items = items;
            this.context = context;
            this.dataServiceInstance = dataServiceInstance;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            convertView = context.LayoutInflater.Inflate(Resource.Layout.CalendarDayRowView, parent, false);

            DateF date = YearListOrder.ConvetNumberToDateObject((int)items[position]);

            convertView.FindViewById<TextView>(Resource.Id.dayCalendar).Text = date.Day.ToString();
            convertView.FindViewById<TextView>(Resource.Id.monthCalendar).Text = Conversions.ConvertNumberToMonth(date.Month);

            List<Conference> allConferencesInDate = dataServiceInstance.GetConferencesByDay(date);
            ConferenceDescriptionAdapter conferenceDescriptionAdapter = new ConferenceDescriptionAdapter(allConferencesInDate, context);

            LinearLayout layout = convertView.FindViewById<LinearLayout>(Resource.Id.calendarCardView);

            for (int i = 0; i < allConferencesInDate.Count(); i++)
            {
               layout.AddView(conferenceDescriptionAdapter.GetView(i, null, null));
            }
            

            return convertView;
        }
    }
}