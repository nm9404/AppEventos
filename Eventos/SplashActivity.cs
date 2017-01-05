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
using Android.Graphics;
using System.IO;
using Eventos.core;

namespace Eventos
{
    [Activity(Label = "ColombiaModa", MainLauncher = true, Theme = "@style/MyTheme")]
    public class SplashActivity : ActionBarActivity
    {
        private ImageView splashImage;
        private ImageView logoImage;
        public MainEvent mainEvent;
        public DataService dataServiceInstance;
        public string data = "";
        public NetworkInfo networkInfo;
        public View relativeLayout;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            RequestedOrientation = Android.Content.PM.ScreenOrientation.Portrait;
            SetContentView(Resource.Layout.SplashView);
            mainEvent = new MainEvent();

            initData();
            FindViews();
            SetBackgrounds();
            //CheckInternetConnection();
            // Create your application here
        }

        private void initData()
        {
            if (IsInternetConnectionAvailable())
            {
                initDataOnline();
            }
            else
            {
                LoadCacheFileOrDefault();
            }
        }

        private async void initDataOnline()
        {
            dataServiceInstance = new DataService();
            var r = await dataServiceInstance.SetEventOnline();
            if (r)
            {
                RunOnUiThread(() =>
                {
                    data = JsonConvert.SerializeObject(dataServiceInstance.GetEvent());
                    SaveDataToJsonFile();
                    StartMainActivity();
                });
            }
            else
            {
                RunOnUiThread(() =>
                {
                    LoadCacheFileOrDefault();
                });
            }
        }



        //<summary>
        //    This function checks for the internet connection before attempting to start the MainActivity, if there's no connection it chhecks for the data file in chache, if it doesn't exist, the app will exit.
        //</summary>
        public void LoadCacheFileOrDefault()
        {
            try
            {
                var document = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
                var filename = System.IO.Path.Combine(document, "data.json");
                String text = File.ReadAllText(filename);
                if (text != null)
                {
                    StartMainActivity();
                }
            }
            catch (Exception e)
            {
                try
                {
                    JSonStrings jsonStrings = new JSonStrings();
                    data = jsonStrings.JSonString;
                    SaveDataToJsonFile();
                    StartMainActivity();
                }
                catch (Exception ex)
                {
                    IAlert.Builder alert = new IAlert.Builder(this);
                    alert.SetTitle("No hay conexión a internet");
                    alert.SetMessage("Los datos no pudieron ser descargados, comprueba tu conexión a internet");
                    alert.SetPositiveButton("Ok", (senderAlert, args) =>
                    {
                        Toast.MakeText(this, "Reintentando Cargar Datos...", ToastLength.Short).Show();
                        initData();
                        //Android.OS.Process.KillProcess(Android.OS.Process.MyPid());
                        //System.Environment.Exit(0);
                    });
                    Dialog dialog = alert.Create();
                    dialog.Show();
                }
            }
        }

        //<summary>
        //    This function sets all the images for the splash screen, they are located in @Resources/Drawable folder
        //</summary>
        public void SetBackgrounds()
        {
            ImageTarget imageTarget = new ImageTarget(relativeLayout);
            Display display = WindowManager.DefaultDisplay;
            Point size = new Point();
            display.GetSize(size);

            Picasso.With(this).Load(Resource.Drawable.logo_splash).Fit().CenterCrop().Into(splashImage);
            Picasso.With(this).Load(Resource.Drawable.logo_dynamik_splash).Fit().CenterCrop().Into(logoImage);
            Picasso.With(this).Load(Resource.Drawable.splash_bg).Resize(size.X, size.Y).CenterCrop().Into(imageTarget);

            //AnimationListener animationListener = new AnimationListener(this);

            Android.Views.Animations.Animation fade = AnimationUtils.LoadAnimation(this, Resource.Animation.animationSplah);
            //fade.SetAnimationListener(animationListener);
            logoImage.StartAnimation(fade);



            //splashImage.StartAnimation(fade);
            //Task.Run(() => this.sleep(30000));
        }

        //<summary>
        //    This function checks if there's an internet connection Available
        //</summary>
        //<return>
        //  Returns true if an internet connection is available, otherwise it returns false
        //</return>
        public bool IsInternetConnectionAvailable()
        {
            ConnectivityManager conMngr = (ConnectivityManager)this.GetSystemService(Context.ConnectivityService);
            networkInfo = conMngr.ActiveNetworkInfo;
            return networkInfo != null && networkInfo.IsConnected && networkInfo.IsAvailable;
        }

        //<summary>
        //    This function this function instantiates all the views for the file SplashView.axml
        //</summary>
        public void FindViews()
        {
            splashImage = FindViewById<ImageView>(Resource.Id.eventLogoImageSplash);
            logoImage = FindViewById<ImageView>(Resource.Id.dynamikLogoImage);
            relativeLayout = FindViewById<RelativeLayout>(Resource.Id.splashLayout);
        }

        //<summary>
        //    This function waits a given time in mili-seconds and creates the JSon cache file in order to Start the MainActivity with the Data. 
        //</summary>
        //<param name ="miliseconds">
        //  is the time in miliSeconds that the task may wait for data to load.
        //</param>
        public async Task sleep(int miliSeconds)
        {
            await Task.Delay(miliSeconds);

            if (dataServiceInstance.GetEvent().Conferences != null)
            {
                data = JsonConvert.SerializeObject(dataServiceInstance.GetEvent());
                SaveDataToJsonFile();
                StartMainActivity();
            }
            else
            {
                try
                {
                    var document = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
                    var filename = System.IO.Path.Combine(document, "data.json");
                    String text = File.ReadAllText(filename);
                    if (text != null)
                    {
                        StartMainActivity();
                        //Android.OS.Process.KillProcess(Android.OS.Process.MyPid());
                        //System.Environment.Exit(0);
                    }
                }
                catch (Exception e)
                {
                    Android.OS.Process.KillProcess(Android.OS.Process.MyPid());
                    System.Environment.Exit(0);
                }
            }
        }

        public void SaveDataToJsonFile()
        {
            var document = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var filename = System.IO.Path.Combine(document, "data.json");
            File.WriteAllText(filename, data);
            //File.AppendAllText(filename, data);
        }

        public void BuildAlertDialog()
        {
            IAlert.Builder alert = new IAlert.Builder(this);
            alert.SetTitle("Datos No cargados Aun");
            alert.SetMessage("Los datos no han sido cargados aun, ¿desea volver a intentarlo?");
            alert.SetPositiveButton("Si", (senderAlert, args) =>
            {
                Toast.MakeText(this, "Espere 10 segundos", ToastLength.Short).Show();
                Task.Run(() => this.sleep(10000));
            });

            alert.SetNegativeButton("No", (senderAlert, args) =>
            {
                Toast.MakeText(this, "Cerrando App...", ToastLength.Short).Show();
                Android.OS.Process.KillProcess(Android.OS.Process.MyPid());
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