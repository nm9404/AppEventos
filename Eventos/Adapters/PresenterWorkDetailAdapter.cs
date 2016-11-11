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
using Square.Picasso;

namespace Eventos.Adapters
{
    class PresenterWorkDetailAdapter : BaseAdapter<Work>
    {
        public List<Work> items = new List<Work>();
        public Activity context;

        public override int Count
        {
            get
            {
                return items.Count();
            }
        }

        public override Work this[int position]
        {
            get
            {
                return items[position];
            }
        }

        public PresenterWorkDetailAdapter(Activity context, List<Work> items)
        {
            this.context = context;
            this.items = items;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            convertView = context.LayoutInflater.Inflate(Resource.Layout.PresenterWorkRow, parent, false);

            string url = "http://testappeventos.webcindario.com/Imagenes/" + items[position].Picture.ImagePath + ".jpg";
            ImageView imageView = convertView.FindViewById<ImageView>(Resource.Id.presenterImageWorkDetail);
            Picasso.With(context).Load(url).Resize(300,300).CenterCrop().Into(imageView);

            convertView.FindViewById<TextView>(Resource.Id.presenterDetailWorkName).Text = items[position].Title;
            convertView.FindViewById<TextView>(Resource.Id.presenterDetailWorkDescription).Text = items[position].Abstract;
            convertView.FindViewById<TextView>(Resource.Id.presenterDetailWorkYear).Text = items[position].Year.ToString();
            convertView.FindViewById<TextView>(Resource.Id.presenterWorkDetailImageDescription).Text = items[position].Picture.Description;

            return convertView;
        }
    }
}