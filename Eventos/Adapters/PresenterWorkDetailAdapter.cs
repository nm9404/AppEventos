
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
using Eventos.core.DataService;

namespace Eventos.Adapters
{
    class PresenterWorkDetailAdapter : BaseAdapter<Work>
    {
        public List<Work> items = new List<Work>();
        public Activity context;
        public DataService dataServiceInstance = new DataService();

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

        public PresenterWorkDetailAdapter(Activity context, List<Work> items, DataService dataServiceInstance)
        {
            this.context = context;
            this.items = items;
            this.dataServiceInstance = dataServiceInstance;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {

            if (dataServiceInstance.GetConferenceByWorkId(items[position].WorkId)!=null)
            {
                Conference conference = dataServiceInstance.GetConferenceByWorkId(items[position].WorkId);
                convertView = context.LayoutInflater.Inflate(Resource.Layout.PresenterConferenceRow, parent, false);

                string url = "http://testappeventos.webcindario.com/Imagenes/" + conference.Picture.ImagePath + ".png";
                ImageView imageView = convertView.FindViewById<ImageView>(Resource.Id.presenterImageWorkDetail);
                Picasso.With(context).Load(url).Fit().CenterCrop().Into(imageView);

                List<String> hourData = new List<String>();
                hourData.Add(conference.Hour.Hours.ToString());
                hourData.Add(conference.Hour.Minutes.ToString());
                if (conference.Hour.Hours<10)
                {
                    hourData[0] = "0" + hourData[0];
                }
                if(conference.Hour.Minutes<10)
                {
                    hourData[1] = "0"+ hourData[1];
                }

                string message = hourData[0] + " : " + hourData[1] + "\n"+ conference.Date.Day.ToString() + "/" + conference.Date.Month.ToString() + "/" + conference.Date.Year.ToString();

                convertView.FindViewById<TextView>(Resource.Id.presenterDetailWorkTitle).Text = "Conferencia: " + items[position].Title;
                convertView.FindViewById<TextView>(Resource.Id.presenterDetailWorkYear).Text = message;
                convertView.FindViewById<TextView>(Resource.Id.presenterDetailWorkDescription).Text = conference.ShortDescription;
            }
            else
            {
                convertView = context.LayoutInflater.Inflate(Resource.Layout.PresenterWorkRow, parent, false);

                string url = "http://testappeventos.webcindario.com/Imagenes/" + items[position].Picture.ImagePath + ".jpg";
                ImageView imageView = convertView.FindViewById<ImageView>(Resource.Id.presenterImageWorkDetail);
                Picasso.With(context).Load(url).Fit().CenterCrop().Into(imageView);

                convertView.FindViewById<TextView>(Resource.Id.presenterDetailWorkName).Text = items[position].Title;
                convertView.FindViewById<TextView>(Resource.Id.presenterDetailWorkYear).Text = items[position].Year.ToString();
                convertView.FindViewById<TextView>(Resource.Id.presenterDetailWorkDescription).Text = items[position].Abstract;
            }

            convertView.FindViewById<TextView>(Resource.Id.presenterWorkDetailImageDescription).Text = items[position].Picture.Description;

            return convertView;
        }
    }
}