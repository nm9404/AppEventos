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
using MImage = Eventos.core.Model.Image;
using Eventos.Utility;
using Android.Graphics;
using System.Threading.Tasks;
using Square.Picasso;

namespace Eventos.Adapters
{
    class GalleryMenuAdapter : BaseAdapter<MImage>
    {
        public List<MImage> items;
        public Activity context;

        public GalleryMenuAdapter(List<MImage> items, Activity context)
        {
            this.items = items;
            this.context = context;
        }

        public override MImage this[int position]
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

        public override 
            
        View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = items[position];
            convertView = context.LayoutInflater.Inflate(Resource.Layout.GalleryElement, parent, false);

            string imageUrl = "http://testappeventos.webcindario.com/Imagenes/ImageGallery/Thumbs/" + (position + 1).ToString().TrimStart('0') + ".jpg";

            ImageView imageView = convertView.FindViewById<ImageView>(Resource.Id.galleryThumb);

            Picasso.With(context).Load(imageUrl).Into(imageView);

            return convertView;
        }
    }
}