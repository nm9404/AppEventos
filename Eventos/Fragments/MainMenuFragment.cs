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
            SetTexts();
        }

        public void SetBackgrounds()
        {
            ImageTarget target = new ImageTarget(mainLayout);
            string url = "http://testappeventos.webcindario.com/Imagenes/ImageGallery/bg.jpg";
            Picasso.With(this.Activity).Load(url).CenterCrop().Resize(720, 1025).Into(target);
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
        }

        private void SetTexts()
        {
            List<String> hourData = new List<String>();
            MainEvent mainEvent = new MainEvent();
            mainEvent = dataServiceInstance.GetEvent();

            hourData.Add(mainEvent.Presenters[0].Conferences[0].Hour.Hours.ToString());

            hourData.Add(mainEvent.Presenters[0].Conferences[0].Hour.Minutes.ToString());
            if (mainEvent.Presenters[0].Conferences[0].Hour.Hours < 10)
            {
                hourData[0] = "0" + hourData[0];
            }
            if (mainEvent.Presenters[0].Conferences[0].Hour.Minutes < 10)
            {
                hourData[1] = "0" + hourData[1];
            }

            descriptionText.Text = mainEvent.EventInformation.EventDescription.ToString();
            hourText.Text = hourData[0].ToString() + " : " + hourData[1].ToString();
            dateText.Text = mainEvent.Presenters[0].Conferences[0].Date.Day.ToString() + " de " + Conversions.ConvertNumberToMonth(mainEvent.Presenters[0].Conferences[0].Date.Month) + " de " + mainEvent.Presenters[0].Conferences[0].Date.Year.ToString();
            addressText.Text = mainEvent.Place.Address.ToString();
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
        }

        public void FaqButtonEventClick(object sender, EventArgs e)
        {
            MainActivity activity = (MainActivity)this.Activity;
            activity.InstanceDataOnFragments();
            activity.frequentQuestionsFragment.PopulateMenu();
            activity.ShowFragment(activity.frequentQuestionsFragment);
        }

        public void PresentersButtonEventClick(object sender, EventArgs e)
        {
            MainActivity activity = (MainActivity)this.Activity;
            activity.InstanceDataOnFragments();
            activity.presentersFragment.PopulateMenu();
            activity.ShowFragment(activity.presentersFragment);
        }

        public void AgendaButtonEventClick(object sender, EventArgs e)
        {
            MainActivity activity = (MainActivity)this.Activity;
            activity.InstanceDataOnFragments();
            activity.calendarFragment.PopulateData();
            activity.ShowFragment(activity.calendarFragment);
        }

        public void ContactButtonEventClick(object sender, EventArgs e)
        {
            MainActivity activity = (MainActivity)this.Activity;
            activity.InstanceDataOnFragments();
            activity.contactFragment.PopulateData();
            activity.ShowFragment(activity.contactFragment);
        }

        public void GalleryButtonEventClick(object sender, EventArgs e)
        {
            MainActivity activity = (MainActivity)this.Activity;
            activity.InstanceDataOnFragments();
            activity.galleryFragment.PopulateMenu();
            activity.ShowFragment(activity.galleryFragment);
        }
    }
}