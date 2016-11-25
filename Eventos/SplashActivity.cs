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
            splashImage.StartAnimation(fade);
            logoImage.StartAnimation(fade);

            //Task.Run(() => this.sleep(30000));
        }

        public void FindViews()
        {
            splashImage = FindViewById<ImageView>(Resource.Id.eventLogoImageSplash);
            logoImage = FindViewById<ImageView>(Resource.Id.dynamikLogoImage);
        }

        public async Task sleep(int miliSeconds)
        {
            await Task.Delay(miliSeconds);

            data = JsonConvert.SerializeObject(dataServiceInstance.GetEvent());

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
                Toast.MakeText(this, "No", ToastLength.Short).Show();
            });

            Dialog dialog = alert.Create();
            dialog.Show();
        }

        public void StartMainActivity()
        {
            Intent intent = new Intent(this, typeof(MainActivity));
            intent.PutExtra("Data", data);
            StartActivity(intent);
        }
    }
}