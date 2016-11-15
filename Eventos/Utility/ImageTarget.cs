using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Square.Picasso;

namespace Eventos.Utility
{
    public class ImageTarget : Java.Lang.Object, ITarget
    {
        public View view;

        public ImageTarget(View view)
        {
            this.view = view;
        }

        public void OnBitmapFailed(Drawable p0)
        {
            return;
        }

        public void OnBitmapLoaded(Bitmap p0, Picasso.LoadedFrom p1)
        {
            view.SetBackgroundDrawable(new BitmapDrawable(view.Context.Resources, p0));
            view.Background.SetColorFilter(new Color(96, 27, 149), PorterDuff.Mode.Add);
            view.Background.Alpha = 40;
        }

        public void OnPrepareLoad(Drawable p0)
        {
            return;
        }
    }
}