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
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using SupportFragment = Android.Support.V4.App.Fragment;
using Eventos.core.DataService;

namespace Eventos.Fragments
{
    public class MapFragment : SupportFragment
    {
        private GoogleMap map;
        private Marker marker;
        private MapView mapView;
        private DataService dataServiceInstance;
        private Button shareButton;
        private double lat;
        private double lng;
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            var view = inflater.Inflate(Resource.Layout.PlaceFragment, null);
            mapView = view.FindViewById<MapView>(Resource.Id.mapView);
            mapView.OnCreate(savedInstanceState);
            return view;
        }

        public override void OnActivityCreated(Bundle p0)
        {
            base.OnActivityCreated(p0);
            FindViews();
            HandleEvents();
            MapsInitializer.Initialize(Activity);
        }

        public override void OnStart()
        {
            base.OnStart();
        }

        public void FindViews()
        {
            shareButton = this.View.FindViewById<Button>(Resource.Id.shareButtonPlace);
        }

        public void InstantiateDataAndInitializeMap(DataService dataServiceInstance)
        {
            this.dataServiceInstance = dataServiceInstance;
            InitializeMapAndHandlers();
        }

        private void InitializeMapAndHandlers()
        {
            SetUpMapIfNeeded();

            if (map != null)
            {
                map.MyLocationEnabled = true;
                //map.MyLocationChange += MapOnMyLocationChange;
                //map.MarkerDragStart += MapOnMarkerDragStart;
                //map.MarkerDragEnd += MapOnMarkerDragEnd;

                lat = dataServiceInstance.GetEvent().Place.Location.Latitude;
                lng = dataServiceInstance.GetEvent().Place.Location.Longitude;

                string labelInfo = dataServiceInstance.GetEvent().Place.Name;

                var latLng = new LatLng(lat, lng);

                var markerOptions = new MarkerOptions()
                        .SetPosition(latLng)
                        .Draggable(true)
                        .SetTitle(labelInfo);
                marker = map.AddMarker(markerOptions);
                map.AnimateCamera(CameraUpdateFactory.NewLatLngZoom(latLng, 13));
            }
        }

        public void HandleEvents()
        {
            shareButton.Click += ShareMouseClickAction;
        }

        public void ShareMouseClickAction(object o, EventArgs e)
        {
            String uri = "http://maps.google.com/maps?saddr=" + lat + "," + lng;

            Intent shareIntent = new Intent(Android.Content.Intent.ActionSend);
            shareIntent.SetType("text/plain");
            String shareSub = "Ubicación";
            shareIntent.PutExtra(Android.Content.Intent.ExtraSubject, shareSub);
            shareIntent.PutExtra(Android.Content.Intent.ExtraTitle, "Me encuentro en: ");
            shareIntent.PutExtra(Android.Content.Intent.ExtraText, uri);

            StartActivity(Intent.CreateChooser(shareIntent, "Compartir vía"));

        }

        public override void OnDestroyView()
        {
            base.OnDestroyView();
            mapView.OnDestroy();
        }

        public override void OnResume()
        {
            base.OnResume();
            SetUpMapIfNeeded();
            mapView.OnResume();
        }

        public override void OnPause()
        {
            base.OnPause();
            mapView.OnPause();
        }

        public override void OnLowMemory()
        {
            base.OnLowMemory();
            mapView.OnLowMemory();
        }

        private void SetUpMapIfNeeded()
        {
            if (null == map)
            {
                map = View.FindViewById<MapView>(Resource.Id.mapView).Map;
            }
        }
    }
}