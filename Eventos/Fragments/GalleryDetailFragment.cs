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

namespace Eventos.Fragments
{
    public class GalleryDetailFragment : SupportFragment
    {
        private List<MImage> imageList = new List<MImage>();
        private TextView imageDetailText;
        private Button shareImageButton;
        private ImageView photoImageView;

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

            FindViews();

            HandleEvents();
        }

        public void instanceDataService(List<MImage> imageList)
        {
            this.imageList = imageList;
        }

        public void FindViews()
        {
            imageDetailText = this.View.FindViewById<TextView>(Resource.Id.imageDetailText);
            shareImageButton = this.View.FindViewById<Button>(Resource.Id.shareButtonImageDetail);
            photoImageView = this.View.FindViewById<ImageView>(Resource.Id.imageDetailedView);
        }

        public void HandleEvents()
        {
            shareImageButton.Click += ShareImageMouseClickButton;
        }

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


        public void ShareImageMouseClickButton(object o, EventArgs e)
        {
            Share("Fotografía", "Galeria Imagenes");
        }

        public void PopulateData(int position)
        {
            string imageUrl = "http://testappeventos.webcindario.com/Imagenes/" + imageList[position].ImagePath + ".jpg";

            Picasso.With(Context).Load(imageUrl).CenterCrop().Resize(720, 1025).Into(photoImageView);

            imageDetailText.Text = imageList[position].Description;
        }
    }
}