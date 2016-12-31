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

        //<summary>
        //This function overrides OnCreateView in order to inflate the view PresenterDetailView.axml on the fragment
        //</summary>
        //<return>
        //returns the inflated view of this fragment
        //</return>
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            View view = inflater.Inflate(Resource.Layout.PresenterDetailView, container, false);
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
        //<param name ="presentersList">
        //List of presenters of the event
        //</param>
        //<param name ="dataServiceInstance">
        //Instance of the dataService created from the SplashActivity with all the app's Data
        //</param>
        public void instanceDataService(List<Presenter> presentersList, DataService dataServiceInstance)
        {
            this.presentersList = presentersList;
            this.dataServiceInstance = dataServiceInstance;
        }

        //<summary>
        //This function finds all the views from the file PresenterDetailView.axml
        //</summary>
        public void FindViews()
        {
            presenterNameText = this.View.FindViewById<TextView>(Resource.Id.presenterDetailNameText);
            presenterDescriptionText = this.View.FindViewById<TextView>(Resource.Id.presenterDetailProfileText);
            workListView = this.View.FindViewById<ListView>(Resource.Id.PresenterDetailListView);
            mainLayout = this.View.FindViewById<LinearLayout>(Resource.Id.layoutPresenterDetail);
            sharePresenterDetailButton = this.View.FindViewById<Button>(Resource.Id.shareButtonPresenterDetail);
            imageView = this.View.FindViewById<ImageView>(Resource.Id.presenterImageDetailView1);
        }


        //<summary>
        //This function puts the respective Data into the image and the textViews
        //</summary>
        //<param name ="position">
        //Index or position in the presentersList to gather data from
        //</param>
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

        //<summary>
        //Gets the position of the presenter on the list from its Id
        //</summary>
        //<param name="presenterId">
        //Id of the presenter to look for on the list
        //</param>
        //<return>
        //returns the Presenter index on the List
        //</return>
        public int GetPresenterPositionFromId(int presenterId)
        {
            return presentersList.IndexOf(dataServiceInstance.GetPresenterById(presenterId));
        }

        //<summary>
        //Sets the background picture for each presenter using the index or position of the list
        //</summary>
        //<param name="position">
        //Position or index of the presentersList
        //</param>
        public void SetBackgrounds(int position)
        {
            ImageTarget target = new ImageTarget(mainLayout);
            string url = "http://testappeventos.webcindario.com/Imagenes/" + dataServiceInstance.GetConferenceByPresenterId(presentersList[position].PresenterId).FirstOrDefault<Conference>().Picture.ImagePath + ".png";
            Picasso.With(this.Activity).Load(url).CenterCrop().Resize(800, 480).Into(target);
        }

        //<summary>
        //Sets the delegates of each event
        //</summary>
        public void HandleEvents()
        {
            sharePresenterDetailButton.Click += shareImage;
        }

        //<summary>
        //Creates the imageBitmap from the picture and launches the shareIntent
        //</summary>
        public void shareImage(object sender, EventArgs e)
        {
            //Conference conference = presentersList[index].Conferences[0];
            int presenterId = presentersList[index].PresenterId;
            List<Conference> conferenceList = dataServiceInstance.GetConferenceByPresenterId(presenterId);
            string info = "";
            string[] hourData = new string[2];
            foreach (Conference conference in conferenceList)
            {
                hourData[0] = conference.Hour.Hours.ToString();
                hourData[1] = conference.Hour.Minutes.ToString();
                if (conference.Hour.Hours < 10)
                {
                    hourData[0] = "0" + hourData[0];
                }
                if (conference.Hour.Minutes < 10)
                {
                    hourData[1] = "0" + hourData[1];
                }

                info += presentersList[index].Name.ToString() + " Presentará su conferencia: " + conference.Title.ToString() + "\n" + "Acompáñanos a las " + hourData[0].ToString() + " : " + hourData[1].ToString();
            }
            
            Share("Información", info);
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