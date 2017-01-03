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
using MImage = Eventos.core.Model.Image; //This Alias is the class Image from Eventos.core.Model
using Eventos.Utility;
using Android.Graphics;
using System.Threading.Tasks;
using Square.Picasso;

namespace Eventos.Adapters
{
    class GalleryMenuAdapter : BaseAdapter<MImage>
    {

        //This class implements the interface BaseAdapter<MIMage>, BaseAdapter<MImage> where xx can be any other type of data

        public List<MImage> items;
        public Activity context;

        //<summary>
        //Builds the Adapter
        //</summary>
        //<param name = "items">
        //List of elements for the Adapter in this case a list of type MImage
        //</param>
        //<param name = "context">
        //Activity containing the fragment
        //</param>
        public GalleryMenuAdapter(List<MImage> items, Activity context)
        {
            this.items = items;
            this.context = context;
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
        public override MImage this[int position]
        {
            get
            {
                return items[position];
            }
        }


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
            var item = items[position];

            convertView = context.LayoutInflater.Inflate(Resource.Layout.GalleryElement, parent, false);

            string imageUrl = "http://testappeventos.webcindario.com/Imagenes/ImageGallery/Thumbs/" + (position + 1).ToString().TrimStart('0') + ".jpg";

            ImageView imageView = convertView.FindViewById<ImageView>(Resource.Id.galleryThumb);

            Picasso.With(context).Load(imageUrl).Fit().CenterCrop().Placeholder(AnimationHelper.instanceAnimationDrawable(context, Resource.Drawable.loaderAnimationPurpleRect)).Into(imageView); ;

            return convertView;
        }
    }
}