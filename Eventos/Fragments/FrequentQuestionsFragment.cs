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
using Eventos.core.Model;
using Eventos.Adapters;

namespace Eventos.Fragments
{
    public class FrequentQuestionsFragment : SupportFragment
    {
        public ListView questionList;
        //private SearchView searchQuery;
        public List<FrequentQuestion> frequentQuestionList = new List<FrequentQuestion>();


        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        //<summary>
        //This function overrides OnCreateView in order to inflate the view FrequenQuestionsFragmentView.axml on the fragment
        //</summary>
        //<return>
        //returns the inflated view of this fragment
        //</return>
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            View view = inflater.Inflate(Resource.Layout.FrequentQuestionsFragmentView,container,false);
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
        }

        //<summary>
        //This function sets the list of frequent questions from the DataService
        //</summary>
        //<param name = "questionList">
        //questionList containing every single question and answer for the event
        //</param>
        public void SetFrequentQuestionList(List<FrequentQuestion> questionList)
        {
            frequentQuestionList = questionList;
        }

        //<summary>
        //This function sets the adapter for the Presenter's GridView
        //</summary>
        public void PopulateMenu()
        {
            FrequentQuestionAdapter frequentQuestionAdapter = new FrequentQuestionAdapter(this.Activity, frequentQuestionList);
            questionList.Adapter = frequentQuestionAdapter;
        }

        //<summary>
        //This function finds all the views from the file FrequentQuestionsFragment.axml
        //</summary>
        private void FindViews()
        {
            questionList = this.View.FindViewById<ListView>(Resource.Id.frequentQuestionListView);
            //searchQuery = this.View.FindViewById<SearchView>(Resource.Id.frequentQuestionSearch);
        }
    }
}