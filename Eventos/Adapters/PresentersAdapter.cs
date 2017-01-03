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
        //This class implements the interface BaseAdapter<Presenter>, BaseAdapter<Presenter> where xx can be any other type of data

        private List<Presenter> items;
        private Activity context;

        //<summary>
        //Builds the Adapter
        //</summary>
        //<param name = "items">
        //List of elements for the Adapter in this case a list of type PresentersAdapter
        //</param>
        //<param name = "context">
        //Activity containing the fragment
        //</param>
        public PresentersAdapter(List<Presenter> items, Activity context)
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
        public override Presenter this[int position]
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
            convertView = context.LayoutInflater.Inflate(Resource.Layout.PresenterElementSingle, parent, false);
            convertView.FindViewById<TextView>(Resource.Id.presenterTextA1).Text = item.Name;
            convertView.FindViewById<TextView>(Resource.Id.presenterTextB1).Text = item.Profile;
            string imageUrl = "http://testappeventos.webcindario.com/Imagenes/PresentersImages/Thumbs/" + (position + 1).ToString().TrimStart('0') + ".jpg";

            ImageView imageView = convertView.FindViewById<ImageView>(Resource.Id.presenterImageView1);

            Picasso.With(context).Load(imageUrl).CenterCrop().Fit().Placeholder(AnimationHelper.instanceAnimationDrawable(context, Resource.Drawable.loaderAnimationPurpleSq)).Transform(new RoundedCornerTransform()).Into(imageView);

            return convertView;
        }
    }
}