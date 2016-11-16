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

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            View view = inflater.Inflate(Resource.Layout.FrequentQuestionsFragmentView,container,false);
            return view;
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            base.OnActivityCreated(savedInstanceState);

            MainActivity activity = (MainActivity)this.Activity;

            FindViews();
        }

        public void SetFrequentQuestionList(List<FrequentQuestion> questionList)
        {
            frequentQuestionList = questionList;
        }

        public void PopulateMenu()
        {
            FrequentQuestionAdapter frequentQuestionAdapter = new FrequentQuestionAdapter(this.Activity, frequentQuestionList);
            questionList.Adapter = frequentQuestionAdapter;
        }

        private void FindViews()
        {
            questionList = this.View.FindViewById<ListView>(Resource.Id.frequentQuestionListView);
            //searchQuery = this.View.FindViewById<SearchView>(Resource.Id.frequentQuestionSearch);
        }
    }
}