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
using Android.Animation;
using Eventos.Fragments;

namespace Eventos.Utility
{
    class TouchListener : Java.Lang.Object, View.IOnTouchListener
    {
        public View view;
        public float viewX;
        public int mLeft;
        public int mRight;
        //public float initViewX;
        //public ObjectAnimator transAnimation;
        public GalleryDetailFragment galleryDetailFragment;

        public TouchListener(View view, GalleryDetailFragment galleryDetailFragment)
        {
            this.view = view;
            this.galleryDetailFragment = galleryDetailFragment;
          
        }

        public bool OnTouch(View v, MotionEvent e)
        {
            switch(e.Action)
            {
                case MotionEventActions.Down:
                    viewX = e.GetX();
                    //viewX = initViewX;
                    //view.Layout((int)initViewX, view.Top, (int)initViewX + view.Width, view.Bottom);
                    break;

                case MotionEventActions.Move:
                    mLeft = (int)(e.RawX - viewX);
                    mRight = (int)(mLeft + view.Width);
                    v.Layout(mLeft, v.Top, mRight, v.Bottom);
                    break;

                case MotionEventActions.Up:
                    v.Layout((int)(0), v.Top, (int)(v.Width), v.Bottom);

                    if (mLeft>v.Width/8)
                    {
                        if(galleryDetailFragment.position>0)
                        {
                            galleryDetailFragment.PopulateData(galleryDetailFragment.position - 1);
                        }
                    }
                    else
                    {
                        if (mLeft<-v.Width/8)
                        {
                            if (galleryDetailFragment.position<galleryDetailFragment.imageList.Count-1)
                            {
                                galleryDetailFragment.PopulateData(galleryDetailFragment.position + 1);
                            }
                        }
                    }
                    break;
            }


            return true;
        }
    }
}