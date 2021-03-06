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
using Android.Graphics.Drawables;

namespace Eventos.Utility
{
    //<summary>
    //    This class performs the instantiation of an animation drawable
    //</summary>

    class AnimationHelper
    {

        public static AnimationDrawable instanceAnimationDrawable(Activity context, int resourceId)
        {
            //ImageView falseImageView = new ImageView(context);
            //falseImageView.SetBackgroundResource(resourceId);
            //AnimationDrawable animation = (AnimationDrawable)falseImageView.Background;
            AnimationDrawable animation = (AnimationDrawable)context.Resources.GetDrawable(resourceId);
            animation.Start();
            return animation;
        }
    }
}