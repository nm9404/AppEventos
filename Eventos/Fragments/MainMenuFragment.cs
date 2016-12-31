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
using Square.Picasso;
using FFImageLoading.Work;
using Eventos.Utility;
using Eventos.core.DataService;
using Eventos.core.Model;

namespace Eventos
{
    public class MainMenuFragment : SupportFragment
    {
        public Button placeButton;
        public Button faqButton;
        public Button galleryButton;
        public Button presentersButton;
        public Button callendarButton;
        public Button contactButton;
        public View mainLayout;
        public TextView descriptionText;
        public TextView dateText;
        public TextView hourText;
        public TextView addressText;
        public DataService dataServiceInstance;
        public ImageView eventImage;

        //<summary>
        //Builds the fragment instantiating the dataServiceInstance
        //</summary>
        //<param name = "dataServiceInstance">
        //Instance of Data Service coming from MainActivity
        //</param>
        public MainMenuFragment (DataService dataServiceInstance)
        {
            this.dataServiceInstance = dataServiceInstance;
        }

        //<summary>
        //Default fragment construction...
        //</summary>
        public MainMenuFragment()
        {

        }

        
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        //<summary>
        //This function overrides OnCreateView in order to inflate the view MainMenuFragmentView.axml on the fragment
        //</summary>
        //<return>
        //returns the inflated view of this fragment
        //</return>
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            //return base.OnCreateView(inflater, container, savedInstanceState);
            View view = inflater.Inflate(Resource.Layout.MainMenuFragmentView, container, false);
            return view;
        }

        //<summary>
        //This function overrides OnActivityCreated finding each view for this fragment, calling the event handlers and setting texts and Picture
        //</summary>
        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            base.OnActivityCreated(savedInstanceState);
            FindViews();
            //SetBackgrounds();
            HandleEvents();
            SetTextsAndPicture();
        }

        //<summary>
        //Sets the background picture for the mainFragment
        //</summary>
        public void SetBackgrounds()
        {
            ImageTarget target = new ImageTarget(this.View.FindViewById<LinearLayout>(Resource.Id.mainMenuLayout));
            //string url = "http://testappeventos.webcindario.com/Imagenes/ImageGallery/bg.jpg";
            Picasso.With(this.Activity).Load(Resource.Drawable.bg).Placeholder(Resource.Drawable.bg).Error(Resource.Drawable.bg).CenterCrop().Resize(720, 1025).Into(target);
        }

        //<summary>
        //This function instantiates all the required data for the fragment recieving the dataService instance
        //</summary>
        //<param name ="dataServiceInstance">
        //Instance of the dataService created from the SplashActivity with all the app's Data
        //</param>
        public void InstantiateDataService(DataService dataServiceInstance)
        {
            this.dataServiceInstance = dataServiceInstance;
        }

        //<summary>
        //This function finds all the views from the file MainMenuFragment.axml
        //</summary>
        public void FindViews()
        {
            placeButton = this.View.FindViewById<Button>(Resource.Id.placeButton);
            faqButton = this.View.FindViewById<Button>(Resource.Id.faqButton);
            presentersButton = this.View.FindViewById<Button>(Resource.Id.personsButton);
            callendarButton = this.View.FindViewById<Button>(Resource.Id.calendarButton);
            contactButton = this.View.FindViewById<Button>(Resource.Id.contactButton);
            galleryButton = this.View.FindViewById<Button>(Resource.Id.galeryButton);
            mainLayout = this.View.FindViewById<View>(Resource.Id.mainMenuLayout);

            descriptionText = this.View.FindViewById<TextView>(Resource.Id.eventDescriptionText);
            hourText = this.View.FindViewById<TextView>(Resource.Id.eventHour);
            dateText = this.View.FindViewById<TextView>(Resource.Id.eventDateText);
            addressText = this.View.FindViewById<TextView>(Resource.Id.eventAddress);

            eventImage = this.View.FindViewById<ImageView>(Resource.Id.eventImage);
        }

        //<summary>
        //This function puts the respective Data into all the views for this fragment
        //</summary>
        private void SetTextsAndPicture()
        {
            SetBackgrounds();

            //Variables and text formatting
            List<String> hourData = new List<String>();
            MainEvent mainEvent = new MainEvent();
            mainEvent = dataServiceInstance.GetEvent();
            Presenter firstPresenter = dataServiceInstance.GetAllPresenters()[0];
            Conference firstConference = dataServiceInstance.GetConferenceByPresenterId(firstPresenter.PresenterId)[0];

            hourData.Add(firstConference.Hour.Hours.ToString());

            hourData.Add(firstConference.Hour.Minutes.ToString());
            if (firstConference.Hour.Hours < 10)
            {
                hourData[0] = "0" + hourData[0];
            }
            if (firstConference.Hour.Minutes < 10)
            {
                hourData[1] = "0" + hourData[1];
            }

            //From here all data is set...
            descriptionText.Text = mainEvent.EventInformation.EventDescription.ToString();
            hourText.Text = hourData[0].ToString() + " : " + hourData[1].ToString();
            dateText.Text = firstConference.Date.Day.ToString() + " de " + Conversions.ConvertNumberToMonth(firstConference.Date.Month) + " de " + firstConference.Date.Year.ToString();
            addressText.Text = mainEvent.Place.Address.ToString();
            string url = "http://testappeventos.webcindario.com/Imagenes/" + mainEvent.EventInformation.MainImage.ImagePath + ".png";
            Picasso.With(this.Activity).Load(Resource.Drawable.logoEvento).Into(eventImage);
        }

        //<summary>
        //Sets the delegates of each event
        //</summary>
        public void HandleEvents()
        {
            placeButton.Click += PlaceButtonEventClick;
            faqButton.Click += FaqButtonEventClick;
            presentersButton.Click += PresentersButtonEventClick;
            callendarButton.Click += AgendaButtonEventClick;
            contactButton.Click += ContactButtonEventClick;
            galleryButton.Click += GalleryButtonEventClick;
        }

        //All event delegates for the 6 buttons in the view...

        //<summary>
        //This functions are the dellegates for the Click event on the 6 buttons, they call the context Activity and use its ShowFragment Function in order to switch from one to another fragment
        //</summary>
        //<param name = "sender">
        //Is the object that listens to this event, in this case each button
        //</param>
        //<param name = "e">
        //Is the type of argument that recieves the event Listener
        //</param>
        public void PlaceButtonEventClick(object sender, EventArgs e)
        {
            MainActivity activity = (MainActivity)this.Activity;
            activity.InstanceDataOnFragments();
            activity.ShowFragment(activity.mapFragment);
            activity.SupportActionBar.SetTitle(Resource.String.titlePlace);
        }

        public void FaqButtonEventClick(object sender, EventArgs e)
        {
            MainActivity activity = (MainActivity)this.Activity;
            activity.InstanceDataOnFragments();
            activity.frequentQuestionsFragment.PopulateMenu();
            activity.ShowFragment(activity.frequentQuestionsFragment);
            activity.SupportActionBar.SetTitle(Resource.String.titleFrequentQuestions);
        }

        public void PresentersButtonEventClick(object sender, EventArgs e)
        {
            MainActivity activity = (MainActivity)this.Activity;
            activity.InstanceDataOnFragments();
            activity.presentersFragment.PopulateMenu();
            activity.ShowFragment(activity.presentersFragment);
            activity.SupportActionBar.SetTitle(Resource.String.titlePresenters);
        }

        public void AgendaButtonEventClick(object sender, EventArgs e)
        {
            MainActivity activity = (MainActivity)this.Activity;
            activity.InstanceDataOnFragments();
            activity.calendarFragment.PopulateData();
            activity.ShowFragment(activity.calendarFragment);
            activity.SupportActionBar.SetTitle(Resource.String.titleCalendar);
        }

        public void ContactButtonEventClick(object sender, EventArgs e)
        {
            MainActivity activity = (MainActivity)this.Activity;
            activity.InstanceDataOnFragments();
            activity.contactFragment.PopulateData();
            activity.ShowFragment(activity.contactFragment);
            activity.SupportActionBar.SetTitle(Resource.String.titleContact);
        }

        public void GalleryButtonEventClick(object sender, EventArgs e)
        {
            MainActivity activity = (MainActivity)this.Activity;
            activity.InstanceDataOnFragments();
            activity.galleryFragment.PopulateMenu();
            activity.ShowFragment(activity.galleryFragment);
            activity.SupportActionBar.SetTitle(Resource.String.titleGaleria);
        }
    }
}