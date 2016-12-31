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

        //<summary>
        //This function overrides OnCreateView in order to inflate the view GalleryFragment.axml on the fragment
        //</summary>
        //<return>
        //returns the inflated view of this fragment
        //</return>
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            View view = inflater.Inflate(Resource.Layout.GalleryFragment, container, false);
            return view;
        }

        //<summary>
        //This function overrides OnActivityCreated finding each view for this fragment, and setting the event delegates in this case GridView.itemClick
        //</summary>
        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            base.OnActivityCreated(savedInstanceState);

            MainActivity activity = (MainActivity)this.Activity;

            FindViews();

            imageGridView.ItemClick += GalleryItemClick;

        }

        //<summary>
        //This function sets the list of images from the DataService
        //</summary>
        //<param name = "imagesList">
        //this parameter is the ImagesList containing all the Image Data for the gallery
        //</param>
        public void SetImageList(List<MImage> imagesList)
        {
            this.imagesList = imagesList;
            MainActivity activity = (MainActivity)this.Activity;
            activity.galleryDetailFragment.instanceDataService(imagesList);
        }

        //<summary>
        //This function sets the adapter for the Gallery GridView
        //</summary>
        public void PopulateMenu()
        {
            GalleryMenuAdapter galleryMenuAdapter = new GalleryMenuAdapter(imagesList, this.Activity);
            imageGridView.Adapter = galleryMenuAdapter;
        }

        //<summary>
        //This function finds all the views from the file GalleryFragment.axml
        //</summary>
        private void FindViews()
        {
            imageGridView = this.View.FindViewById<GridView>(Resource.Id.GalleryGridView);
        }

        //<summary>
        //This function sets the EventListener in order to enable interaction with each picture, this may be used within a delegate
        //</summary>
        //<param name = "sender">
        //Is the object that listens to this event, in this case the GridView
        //</param>
        //<param name = "e">
        //Is the type of argument that recieves the event Listener
        //</param>
        public void GalleryItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            MainActivity activity = (MainActivity)this.Activity;
            activity.galleryDetailFragment.PopulateData(e.Position);
            activity.ShowFragment(activity.galleryDetailFragment);
        }


    }
}