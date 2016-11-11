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

namespace Eventos.Fragments
{
    public class PresenterDetailFragment : SupportFragment
    {
        private List<Presenter> presentersList = new List<Presenter>();
        private TextView presenterNameText;
        private TextView presenterDescriptionText;
        private ListView workListView;
        private DataService dataServiceInstance = new DataService();

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
        }

        public void PopulateData(int position)
        {
            var imageView = this.View.FindViewById<ImageView>(Resource.Id.presenterImageDetailView1);
            string imageUrl = "http://testappeventos.webcindario.com/Imagenes/" + presentersList[position].Photo.ImagePath + ".jpg";

            Picasso.With(Context).Load(imageUrl).CenterCrop().Resize(450, 450).Into(imageView);

            presenterNameText.Text = presentersList[position].Name;
            presenterDescriptionText.Text = presentersList[position].Profile;

            List<Work> allPresenterWorks = dataServiceInstance.GetAllWorksByPresenterId(presentersList[position].PresenterId);

            PresenterWorkDetailAdapter presenterWorkDetailAdapter = new PresenterWorkDetailAdapter(this.Activity, allPresenterWorks);
            workListView.Adapter = presenterWorkDetailAdapter;

        }

    }
}