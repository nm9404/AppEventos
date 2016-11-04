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

namespace Eventos.Fragments
{
    public class PresenterDetailFragment : SupportFragment
    {
        private List<Presenter> presentersList = new List<Presenter>();

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
        }

        public void instanceDataService(List<Presenter> presentersList)
        {
            this.presentersList = presentersList;
        }

        public void PopulateData(int position)
        {
            var imageView = this.View.FindViewById<ImageView>(Resource.Id.presenterImageDetailView1);
            string imageUrl = "http://testappeventos.webcindario.com/Imagenes/" + presentersList[position].Photo.ImagePath + ".jpg";

            Picasso.With(Context).Load(imageUrl).CenterCrop().Resize(600, 600).Into(imageView);
        }

    }
}