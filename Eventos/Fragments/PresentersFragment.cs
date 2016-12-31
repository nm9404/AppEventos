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
        //<summary>
        //This class controls the presenters fragment

        public GridView presentersView;
        public List<Presenter> presentersList = new List<Presenter>();

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        //<summary>
        //This function overrides OnCreateView in order to inflate the view PresentersFragmentView.axml on the fragment
        //</summary>
        //<return>
        //returns the inflated view of this fragment
        //</return>
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            View view = inflater.Inflate(Resource.Layout.PresentersFragmentView ,container, false);
            return view;
        }

        //<summary>
        //This function overrides OnActivityCreated finding each view for this fragmeny
        //</summary>
        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            base.OnActivityCreated(savedInstanceState);

            MainActivity activity = (MainActivity)this.Activity;

            FindViews();

            presentersView.ItemClick += PresenterItemClick;
        }

        //<summary>
        //This function sets the list of presenters from the DataService
        //</summary>
        //<param name = "dataServiceInstance">
        //this parameter is the DataServiceInstance created from the splashActivity with all the Data of the event and this is parsed from the MainActivity to instantiate the data for this fragment
        //</param>
        public void SetPresentersList(DataService dataServiceInstance)
        {
            presentersList = dataServiceInstance.GetAllPresenters();
            MainActivity activity = (MainActivity)this.Activity;
            activity.presenterDetailFragment.instanceDataService(presentersList, dataServiceInstance);
        }

        //<summary>
        //This function sets the adapter for the Presenter's GridView
        //</summary>
        public void PopulateMenu()
        {
            PresentersAdapter presentersAdapter = new PresentersAdapter(presentersList, this.Activity);
            presentersView.Adapter = presentersAdapter;
        }

        //<summary>
        //This function sets the EventListener in order to enable interaction with each presenter picture, this may be used within a delegate
        //</summary>
        //<param name = "sender">
        //Is the object that listens to this event, in this case the GridView
        //</param>
        //<param name = "e">
        //Is the type of argument that recieves the event Listener
        //</param>
        public void PresenterItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            MainActivity activity = (MainActivity)this.Activity;
            activity.presenterDetailFragment.PopulateData(e.Position);
            activity.ShowFragment(activity.presenterDetailFragment);
        }

        //<summary>
        //This function finds all the views from the file PresentersFragmentView.axml
        //</summary>
        private void FindViews()
        {
            presentersView = this.View.FindViewById<GridView>(Resource.Id.PresentersGridView);
        }
    }
}