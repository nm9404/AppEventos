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

namespace Eventos.Adapters
{
    public class MenuAdapter : BaseAdapter<MenuList>
    {
        private List<MenuList> items;
        private Activity context;

        public MenuAdapter(Activity context, List<MenuList> items)
        {
            this.context = context;
            this.items = items;
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

            convertView = context.LayoutInflater.Inflate(Resource.Layout.MenuRowView, parent, false);

            var drawableImg = context.Resources.GetDrawable(context.Resources.GetIdentifier(item.iconPath, "drawable", context.PackageName));
            var color = Color.ParseColor("#601b95");

            drawableImg.SetColorFilter(color, Mode.SrcAtop);

            convertView.FindViewById<ImageView>(Resource.Id.menuIcon).SetImageDrawable(drawableImg);
            convertView.FindViewById<TextView>(Resource.Id.textMenu).Text = item.menuText;

            return convertView;
        }
    }
}