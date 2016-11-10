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
using Eventos.core.Model;
using Eventos.Adapters;
using SupportFragment = Android.Support.V4.App.Fragment;
using Eventos.core.DataService;

namespace Eventos.Fragments
{
    public class PresentersFragment : SupportFragment
    {

        public GridView presentersView;
        public List<Presenter> presentersList = new List<Presenter>();

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            View view = inflater.Inflate(Resource.Layout.PresentersFragmentView ,container, false);
            return view;
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            base.OnActivityCreated(savedInstanceState);

            MainActivity activity = (MainActivity)this.Activity;

            FindViews();
        }

        public void SetPresentersList(DataService dataServiceInstance)
        {
            presentersList = dataServiceInstance.GetEvent().Presenters;
            MainActivity activity = (MainActivity)this.Activity;
            activity.presenterDetailFragment.instanceDataService(presentersList, dataServiceInstance);
        }

        public void PopulateMenu()
        {
            PresentersAdapter presentersAdapter = new PresentersAdapter(presentersList, this.Activity);
            presentersView.Adapter = presentersAdapter;
            presentersView.ItemClick += PresenterItemClick;
        }

        public void PresenterItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            MainActivity activity = (MainActivity)this.Activity;
            activity.presenterDetailFragment.PopulateData(e.Position);
            activity.ShowFragment(activity.presenterDetailFragment);
        }

        private void FindViews()
        {
            presentersView = this.View.FindViewById<GridView>(Resource.Id.PresentersGridView);
        }
    }
}