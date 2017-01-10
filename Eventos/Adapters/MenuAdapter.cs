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
using Eventos.MenuData;
using Android.Graphics;
using static Android.Graphics.PorterDuff;
using Eventos.core.DataService;
using Square.Picasso;
using Android.Support.V4.Graphics.Drawable;
using Android.Graphics.Drawables;

namespace Eventos.Adapters
{
    //This class implements the interface BaseAdapter<MenuList>, BaseAdapter<MenuList> where xx can be any other type of data

    public class MenuAdapter : BaseAdapter<MenuList>
    {
        private List<MenuList> items;
        private Activity context;
        private DataService dataServiceInstance;

        //<summary>
        //Builds the Adapter
        //</summary>
        //<param name = "items">
        //List of elements for the Adapter in this case a list of type MenuList
        //</param>
        //<param name = "context">
        //Activity containing the fragment
        //</param>
        public MenuAdapter(Activity context, List<MenuList> items, DataService dataServiceInstance)
        {
            this.context = context;
            this.items = items;
            this.dataServiceInstance = dataServiceInstance;
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
        public override MenuList this[int position]
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

            if (position==0)
            {
                convertView = context.LayoutInflater.Inflate(Resource.Layout.MenuImageLayoutView, parent, false);
                string url = "http://testappeventos.webcindario.com/Imagenes/" + dataServiceInstance.GetEvent().EventInformation.MainImage.ImagePath + ".png";
                Picasso.With(context).Load(Resource.Drawable.logoEvento).Into(convertView.FindViewById<ImageView>(Resource.Id.drawerImageView));
                return convertView;
            }
            else
            {
                convertView = context.LayoutInflater.Inflate(Resource.Layout.MenuRowView, parent, false);

                var drawableImg = context.Resources.GetDrawable(context.Resources.GetIdentifier(item.iconPath, "drawable", context.PackageName));
                var color = Color.ParseColor("#FFFFFF");

                Drawable drawableCompat = DrawableCompat.Wrap(drawableImg);
                DrawableCompat.SetTint(drawableCompat, Color.White);

                convertView.FindViewById<ImageView>(Resource.Id.menuIcon).SetImageDrawable(drawableCompat);
                convertView.FindViewById<TextView>(Resource.Id.textMenu).Text = item.menuText;

                return convertView;
            }
        }
    }
}