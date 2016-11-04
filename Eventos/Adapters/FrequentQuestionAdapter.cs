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
    class FrequentQuestionAdapter : BaseAdapter<FrequentQuestion>
    {
        private List<FrequentQuestion> items;
        private Activity context;

        public FrequentQuestionAdapter(Activity context, List<FrequentQuestion> items)
        {
            this.items = items;
            this.context = context;
        }

        public override FrequentQuestion this[int position]
        {
            get
            {
                return items[position];
            }
        }

        public override int Count
        {
            get
            {
                return items.Count();
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            convertView = context.LayoutInflater.Inflate(Resource.Layout.FrequentQuestionRow, parent, false);

            convertView.FindViewById<TextView>(Resource.Id.faqQuestionText).Text = items[position].Question;
            convertView.FindViewById<TextView>(Resource.Id.faqAnswerText).Text = items[position].Answer;

            return convertView;
        }
    }
}