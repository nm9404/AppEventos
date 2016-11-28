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

namespace Eventos.Adapters
{
    public class MenuAdapter : BaseAdapter<MenuList>
    {
        private List<MenuList> items;
        private Activity context;
        private DataService dataServiceInstance;

        public MenuAdapter(Activity context, List<MenuList> items, DataService dataServiceInstance)
        {
            this.context = context;
            this.items = items;
            this.dataServiceInstance = dataServiceInstance;
        }

        public override MenuList this[int position]
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

            if (position==0)
            {
                convertView = context.LayoutInflater.Inflate(Resource.Layout.MenuImageLayoutView, parent, false);
                string url = "http://testappeventos.webcindario.com/Imagenes/" + dataServiceInstance.GetEvent().EventInformation.MainImage.ImagePath + ".png";
                Picasso.With(context).Load(url).Into(convertView.FindViewById<ImageView>(Resource.Id.drawerImageView));
                return convertView;
            }
            else
            {
                convertView = context.LayoutInflater.Inflate(Resource.Layout.MenuRowView, parent, false);

                var drawableImg = context.Resources.GetDrawable(context.Resources.GetIdentifier(item.iconPath, "drawable", context.PackageName));
                var color = Color.ParseColor("#FFFFFF");
                

                drawableImg.SetColorFilter(color, Mode.SrcAtop);

                convertView.FindViewById<ImageView>(Resource.Id.menuIcon).SetImageDrawable(drawableImg);
                convertView.FindViewById<TextView>(Resource.Id.textMenu).Text = item.menuText;

                return convertView;
            }
        }
    }
}