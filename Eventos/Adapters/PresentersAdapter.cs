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
using Square.Picasso;

namespace Eventos.Adapters
{
    class PresentersAdapter : BaseAdapter<Presenter>
    {
        private List<Presenter> items;
        private Activity context;

        public PresentersAdapter(List<Presenter> items, Activity context)
        {
            this.items = items;
            this.context = context;
        }

        public override Presenter this[int position]
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
            var item = items[position];
            convertView = context.LayoutInflater.Inflate(Resource.Layout.PresenterElementSingle, parent, false);
            convertView.FindViewById<TextView>(Resource.Id.presenterTextA1).Text = item.Name;
            convertView.FindViewById<TextView>(Resource.Id.presenterTextB1).Text = item.Profile;
            string imageUrl = "http://testappeventos.webcindario.com/Imagenes/PresentersImages/Thumbs/" + (position + 1).ToString().TrimStart('0') + ".jpg";

            ImageView imageView = convertView.FindViewById<ImageView>(Resource.Id.presenterImageView1);

            Picasso.With(context).Load(imageUrl).CenterCrop().Resize(400,400).Into(imageView);

            return convertView;
        }
    }
}