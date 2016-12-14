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

        public MainMenuFragment (DataService dataServiceInstance)
        {
            this.dataServiceInstance = dataServiceInstance;
        }

        public MainMenuFragment()
        {

        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            //return base.OnCreateView(inflater, container, savedInstanceState);
            View view = inflater.Inflate(Resource.Layout.MainMenuFragmentView, container, false);
            return view;
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            base.OnActivityCreated(savedInstanceState);
            FindViews();
            HandleEvents();
            SetBackgrounds();
            SetTextsAndPicture();
        }

        public void SetBackgrounds()
        {
            ImageTarget target = new ImageTarget(mainLayout);
            string url = "http://testappeventos.webcindario.com/Imagenes/ImageGallery/bg.jpg";
            Picasso.With(this.Activity).Load(url).Placeholder(Resource.Drawable.bg).CenterCrop().Resize(720, 1025).Into(target);
        }

        public void InstantiateDataService(DataService dataServiceInstance)
        {
            this.dataServiceInstance = dataServiceInstance;
        }

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

        private void SetTextsAndPicture()
        {
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

            descriptionText.Text = mainEvent.EventInformation.EventDescription.ToString();
            hourText.Text = hourData[0].ToString() + " : " + hourData[1].ToString();
            dateText.Text = firstConference.Date.Day.ToString() + " de " + Conversions.ConvertNumberToMonth(firstConference.Date.Month) + " de " + firstConference.Date.Year.ToString();
            addressText.Text = mainEvent.Place.Address.ToString();
            string url = "http://testappeventos.webcindario.com/Imagenes/" + mainEvent.EventInformation.MainImage.ImagePath + ".png";
            Picasso.With(this.Activity).Load(Resource.Drawable.logoEvento).Into(eventImage);
        }

        public void HandleEvents()
        {
            placeButton.Click += PlaceButtonEventClick;
            faqButton.Click += FaqButtonEventClick;
            presentersButton.Click += PresentersButtonEventClick;
            callendarButton.Click += AgendaButtonEventClick;
            contactButton.Click += ContactButtonEventClick;
            galleryButton.Click += GalleryButtonEventClick;
        }

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