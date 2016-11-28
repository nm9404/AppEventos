using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Support.V7.App;
using Square.Picasso;
using Android.Views.Animations;
using System.Threading.Tasks;
using Eventos.core.DataService;
using Newtonsoft.Json;
using IAlertDialog = Android.App.AlertDialog;
using Eventos.core.Model;
using IAlert = Android.App.AlertDialog;
using Eventos.Utility;
using Android.Net;

namespace Eventos
{
    [Activity(Label = "SplashActivity", MainLauncher = true, Theme = "@style/MyTheme")]
    public class SplashActivity : ActionBarActivity
    {
        private ImageView splashImage;
        private ImageView logoImage;
        public MainEvent mainEvent;
        public DataService dataServiceInstance;
        public string data = "";
        public NetworkInfo networkInfo;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.SplashView);
            mainEvent = new MainEvent();
            dataServiceInstance = new DataService();
            dataServiceInstance.SetEventOnline();
            FindViews();
            SetBackgrounds();
            // Create your application here
        }

        public void SetBackgrounds()
        {
            Picasso.With(this).Load("http://testappeventos.webcindario.com/Imagenes/EventImage/1b.png").Into(splashImage);
            Picasso.With(this).Load("http://testappeventos.webcindario.com/Imagenes/EventImage/LogoDynamik_Horizontal.png").Into(logoImage);

            AnimationListener animationListener = new AnimationListener(this);

            Android.Views.Animations.Animation fade = AnimationUtils.LoadAnimation(this, Resource.Animation.animationSplah);
            fade.SetAnimationListener(animationListener);
            logoImage.StartAnimation(fade);

            if (!IsInternetConnectionAvailable())
            {
                IAlert.Builder alert = new IAlert.Builder(this);
                alert.SetTitle("No hay conexión a internet");
                alert.SetMessage("Los datos no pudieron ser descargados, comprueba tu conexión a internet");
                alert.SetPositiveButton("Ok", (senderAlert, args) => {
                    System.Environment.Exit(0);
                });
                Dialog dialog = alert.Create();
                dialog.Show();
            }
            
            //splashImage.StartAnimation(fade);
            //Task.Run(() => this.sleep(30000));
        }

        public bool IsInternetConnectionAvailable()
        {
            ConnectivityManager conMngr = (ConnectivityManager)this.GetSystemService(Context.ConnectivityService);
            networkInfo = conMngr.ActiveNetworkInfo;
            return networkInfo != null && networkInfo.IsConnected && networkInfo.IsAvailable;
        }

        public void FindViews()
        {
            splashImage = FindViewById<ImageView>(Resource.Id.eventLogoImageSplash);
            logoImage = FindViewById<ImageView>(Resource.Id.dynamikLogoImage);
        }

        public async Task sleep(int miliSeconds)
        {
            await Task.Delay(miliSeconds);

            if (dataServiceInstance.GetEvent().Presenters!=null)
            {
                data = JsonConvert.SerializeObject(dataServiceInstance.GetEvent());
            }
            else
            {
                IAlert.Builder alert = new IAlert.Builder(this);
                alert.SetTitle("No hay conexión a internet");
                alert.SetMessage("Los datos no pudieron ser descargados, comprueba tu conexión a internet");
                alert.SetPositiveButton("Ok", (senderAlert, args) => {
                    System.Environment.Exit(0);
                });
                Dialog dialog = alert.Create();
                dialog.Show();
            }

            StartMainActivity();
        }

        public void BuildAlertDialog()
        {
            IAlert.Builder alert = new IAlert.Builder(this);
            alert.SetTitle("Datos No cargados Aun");
            alert.SetMessage("Los datos no han sido cargados aun, ¿desea volver a intentarlo?");
            alert.SetPositiveButton("Si", (senderAlert, args) => {
                Toast.MakeText(this, "Espere 10 segundos", ToastLength.Short).Show();
                Task.Run(() => this.sleep(10000));
            });

            alert.SetNegativeButton("No", (senderAlert, args) => {
                Toast.MakeText(this, "Cerrando App...", ToastLength.Short).Show();
                System.Environment.Exit(0);
            });

            Dialog dialog = alert.Create();
            dialog.Show();
        }

        public void StartMainActivity()
        {
            Intent intent = new Intent(this, typeof(MainActivity));
            intent.PutExtra("Data", data);
            StartActivity(intent);
            Finish();
        }
    }
}