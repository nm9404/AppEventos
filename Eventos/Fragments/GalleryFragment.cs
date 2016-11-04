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
using Eventos.Adapters;
using Eventos.Utility;

namespace Eventos.Fragments
{
    public class GalleryFragment : SupportFragment
    {
        public List<MImage> imagesList = new List<MImage>();
        public GridView imageGridView;
        public ImageLoader imageLoader;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            View view = inflater.Inflate(Resource.Layout.GalleryFragment, container, false);
            return view;
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            base.OnActivityCreated(savedInstanceState);

            MainActivity activity = (MainActivity)this.Activity;

            FindViews();
        }

        public void SetImageList(List<MImage> imagesList)
        {
            this.imagesList = imagesList;
        }

        public void PopulateMenu()
        {

            GalleryMenuAdapter galleryMenuAdapter = new GalleryMenuAdapter(imagesList, this.Activity);
            imageGridView.Adapter = galleryMenuAdapter;
        }

        private void FindViews()
        {
            imageGridView = this.View.FindViewById<GridView>(Resource.Id.GalleryGridView);
        }
    }
}