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
using Eventos.core.DataService;
using Square.Picasso;
using Eventos.core.Model;
using Eventos.Adapters;
using Eventos.Utility;
using Android.Graphics.Drawables;
using Android.Graphics;
using System.IO;

namespace Eventos.Fragments
{
    public class PresenterDetailFragment : SupportFragment
    {
        private List<Presenter> presentersList = new List<Presenter>();
        private TextView presenterNameText;
        private TextView presenterDescriptionText;
        private ListView workListView;
        private DataService dataServiceInstance;
        private LinearLayout mainLayout;
        private Button sharePresenterDetailButton;
        private ImageView imageView;
        private int index=0;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            View view = inflater.Inflate(Resource.Layout.PresenterDetailView, container, false);
            return view;
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            base.OnActivityCreated(savedInstanceState);

            FindViews();
            HandleEvents();
        }

        public void instanceDataService(List<Presenter> presentersList, DataService dataServiceInstance)
        {
            this.presentersList = presentersList;
            this.dataServiceInstance = dataServiceInstance;
        }

        public void FindViews()
        {
            presenterNameText = this.View.FindViewById<TextView>(Resource.Id.presenterDetailNameText);
            presenterDescriptionText = this.View.FindViewById<TextView>(Resource.Id.presenterDetailProfileText);
            workListView = this.View.FindViewById<ListView>(Resource.Id.PresenterDetailListView);
            mainLayout = this.View.FindViewById<LinearLayout>(Resource.Id.layoutPresenterDetail);
            sharePresenterDetailButton = this.View.FindViewById<Button>(Resource.Id.shareButtonPresenterDetail);
            imageView = this.View.FindViewById<ImageView>(Resource.Id.presenterImageDetailView1);
        }

        public void PopulateData(int position)
        {
            SetBackgrounds(position);
            string imageUrl = "http://testappeventos.webcindario.com/Imagenes/" + presentersList[position].Photo.ImagePath + ".jpg";

            Picasso.With(Context).Load(imageUrl).Fit().CenterCrop().Transform(new RoundedCornerTransform()).Placeholder(AnimationHelper.instanceAnimationDrawable(this.Activity, Resource.Drawable.loaderAnimationWhiteSq)).Into(imageView);

            presenterNameText.Text = presentersList[position].Name;
            presenterDescriptionText.Text = presentersList[position].Profile;

            List<Work> allPresenterWorks = dataServiceInstance.GetAllWorksByPresenterId(presentersList[position].PresenterId);

            PresenterWorkDetailAdapter presenterWorkDetailAdapter = new PresenterWorkDetailAdapter(this.Activity, allPresenterWorks, dataServiceInstance);
            workListView.Adapter = presenterWorkDetailAdapter;
            index = position;
        }

        public int GetPresenterPositionFromId(int presenterId)
        {
            return presentersList.IndexOf(dataServiceInstance.GetPresenterById(presenterId));
        }

        public void SetBackgrounds(int position)
        {
            ImageTarget target = new ImageTarget(mainLayout);
            string url = "http://testappeventos.webcindario.com/Imagenes/" + dataServiceInstance.GetConferenceByPresenterId(presentersList[position].PresenterId).FirstOrDefault<Conference>().Picture.ImagePath + ".png";
            Picasso.With(this.Activity).Load(url).CenterCrop().Resize(800, 480).Into(target);
        }

        public void HandleEvents()
        {
            sharePresenterDetailButton.Click += shareImage;
        }

        public void shareImage(object sender, EventArgs e)
        {
            Conference conference = presentersList[index].Conferences[0];
            List<String> hourData = new List<String>();
            hourData.Add(conference.Hour.Hours.ToString());
            hourData.Add(conference.Hour.Minutes.ToString());
            if (conference.Hour.Hours < 10)
            {
                hourData[0] = "0" + hourData[0];
            }
            if (conference.Hour.Minutes < 10)
            {
                hourData[1] = "0" + hourData[1];
            }

            string info = presentersList[index].Name.ToString() + " Presentará su conferencia: " + presentersList[index].Conferences[0].Title.ToString() + "\n" + "Acompáñanos a las " + hourData[0].ToString() + " : " + hourData[1].ToString();
            Share("Información", info);
        }

        public void Share(string title, string content)
        {
            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(content))
                return;

            //Drawable mDrawable = imageView.Drawable;
            imageView.BuildDrawingCache();
            Bitmap b = Bitmap.CreateBitmap(imageView.GetDrawingCache(false));

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
            imageView.DestroyDrawingCache();
        }
    }
}