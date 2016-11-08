using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using SupportFragment = Android.Support.V4.App.Fragment;
using MImage = Eventos.core.Model.Image;
using Square.Picasso;

namespace Eventos.Fragments
{
    public class GalleryDetailFragment : SupportFragment
    {
        private List<MImage> imageList = new List<MImage>();

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }


        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            View view = inflater.Inflate(Resource.Layout.ImageDetailView, container, false);
            return view;
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            base.OnActivityCreated(savedInstanceState);
        }

        public void instanceDataService(List<MImage> imageList)
        {
            this.imageList = imageList;
        }

        public void PopulateData(int position)
        {
            var imageView = this.View.FindViewById<ImageView>(Resource.Id.imageDetailedView);
            string imageUrl = "http://testappeventos.webcindario.com/Imagenes/" + imageList[position].ImagePath + ".jpg";

            Picasso.With(Context).Load(imageUrl).Into(imageView);
        }
    }
}