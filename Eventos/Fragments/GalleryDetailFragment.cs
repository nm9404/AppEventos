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
using Android.Graphics.Drawables;
using Android.Graphics;
using Android.Provider;
using System.IO;
using Eventos.Utility;

namespace Eventos.Fragments
{
    public class GalleryDetailFragment : SupportFragment
    {
        public List<MImage> imageList = new List<MImage>();
        private TextView imageDetailText;
        private Button shareImageButton;
        public ImageView photoImageView;
        public int position;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        //<summary>
        //This function overrides OnCreateView in order to inflate the view ImageDetailView.axml on the fragment
        //</summary>
        //<return>
        //returns the inflated view of this fragment
        //</return>
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            View view = inflater.Inflate(Resource.Layout.ImageDetailView, container, false);
            return view;
        }

        //<summary>
        //This function overrides OnActivityCreated finding each view for this fragment and calling the event handlers
        //</summary>
        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            base.OnActivityCreated(savedInstanceState);

            FindViews();

            HandleEvents();
        }

        //<summary>
        //This function instantiates all the required data for the fragment recieving the presenter's List and the DataServiceInstance
        //</summary>
        //<param name ="imageList">
        //List of the images of the gallery
        //</param>
        public void instanceDataService(List<MImage> imageList)
        {
            this.imageList = imageList;
        }

        //<summary>
        //This function finds all the views from the file ImageDetailView.axml
        //</summary>
        public void FindViews()
        {
            imageDetailText = this.View.FindViewById<TextView>(Resource.Id.imageDetailText);
            shareImageButton = this.View.FindViewById<Button>(Resource.Id.shareButtonImageDetail);
            photoImageView = this.View.FindViewById<ImageView>(Resource.Id.imageDetailedView);
        }

        //<summary>
        //Sets the delegates of each event
        //</summary>
        public void HandleEvents()
        {
            shareImageButton.Click += ShareImageMouseClickButton;
        }

        //<summary>
        //Launches the share intent for this fragment
        //</summary>
        //<param name="title">
        //is the title of the message to share
        //</param>
        //<param name="contet">
        //is the content of the message to share
        //</param>
        public void Share(string title, string content)
        {
            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(content))
                return;

            Drawable mDrawable = photoImageView.Drawable;
            Bitmap b = ((BitmapDrawable)mDrawable).Bitmap;

            var tempFilename = "test.png";
            var sdCardPath = Android.OS.Environment.ExternalStorageDirectory.AbsolutePath;
            var filePath = System.IO.Path.Combine(sdCardPath, tempFilename);
            using (var os = new FileStream(filePath, FileMode.Create))
            {
                b.Compress(Bitmap.CompressFormat.Png, 100, os);
            }
            b.Dispose();

            var imageUri = Android.Net.Uri.Parse($"file://{sdCardPath}/{tempFilename}");
            var sharingIntent = new Intent();
            sharingIntent.SetAction(Intent.ActionSend);
            sharingIntent.SetType("image/*");
            sharingIntent.PutExtra(Intent.ExtraText, content);
            sharingIntent.PutExtra(Intent.ExtraStream, imageUri);
            sharingIntent.AddFlags(ActivityFlags.GrantReadUriPermission);
            StartActivity(Intent.CreateChooser(sharingIntent, title));
        }

        //<summary>
        //Creates the imageBitmap from the picture and launches the shareIntent
        //</summary>
        public void ShareImageMouseClickButton(object o, EventArgs e)
        {
            Share("Fotografía", imageList[position].Description.ToString());
        }

        //<summary>
        //This function puts the respective Data into the image and the textViews
        //</summary>
        //<param name ="position">
        //Index or position in the imagesList to gather data from
        //</param>
        public void PopulateData(int position)
        {
            TouchListener touchListener = new TouchListener(photoImageView, this);
            photoImageView.SetOnTouchListener(touchListener);

            this.position = position;

            string imageUrl = "http://testappeventos.webcindario.com/Imagenes/" + imageList[position].ImagePath + ".jpg";

            Picasso.With(Context).Load(imageUrl).Fit().CenterCrop().Placeholder(AnimationHelper.instanceAnimationDrawable(this.Activity, Resource.Drawable.loaderAnimationPurpleRect)).Into(photoImageView);

            imageDetailText.Text = imageList[position].Description;
        }
    }
}