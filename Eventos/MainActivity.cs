using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Eventos.core.Model;
using Eventos.core.Repository;
using Eventos.core.DataService;
using Android.Support.V7.App;
using SupportToolbar = Android.Support.V7.Widget.Toolbar;
using Android.Support.V4.Widget;
using MActionBarToggle = Eventos.MyActionBarToggle.MyActionBarToggle;
using Eventos.Adapters;
using Eventos.MenuData;
using SupportFragment = Android.Support.V4.App.Fragment;
using System.Collections.Generic;
using Eventos.Fragments;
using static Android.Widget.AdapterView;
using System.Threading.Tasks;
using Eventos.Utility;
using Newtonsoft.Json;
using Square.Picasso;
using Android.Graphics.Drawables;
using System.IO;
using Android.Net;

namespace Eventos
{
    [Activity(Label = "ColombiaModa", MainLauncher = false, Icon = "@drawable/icon", Theme = "@style/MyTheme")]
    public class MainActivity : ActionBarActivity
    {
        int count = 1;
        bool fragmentInstantiated = false;
        MainEvent mainEvent = new MainEvent();
        DataService dataServiceInstance = new DataService();

        //Views
        private SupportToolbar mToolbar;
        private MActionBarToggle mActionBarToggle;
        private DrawerLayout mDrawerLayout;
        private ListView mLeftDrawer;
        public AnimationDrawable loadingAnimation;
        private ImageView drawerImageView;

        //MenuElments
        private MenuElements menuElementsInstance = new MenuElements();

        //FragmentStack
        private Stack<SupportFragment> fragmentStack = new Stack<SupportFragment>();


        //Fragments
        public MainMenuFragment mainMenuFragment;
        public FrequentQuestionsFragment frequentQuestionsFragment;
        public SupportFragment currentFragment;
        public PresentersFragment presentersFragment;
        public GalleryFragment galleryFragment;
        public MapFragment mapFragment;
        public PresenterDetailFragment presenterDetailFragment;
        public GalleryDetailFragment galleryDetailFragment;
        public CalendarFragment calendarFragment;
        public ContactFragment contactFragment;
        public SplashFragment splashFragment;

        

        //private MenuAdapter menuAdapter = new MenuAdapter(,menuElementsInstance.menuElements);

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            RequestedOrientation = Android.Content.PM.ScreenOrientation.Portrait;

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            //string data = Intent.GetStringExtra("Data");
            MainEvent eventData = new MainEvent();
            var document = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var filename = Path.Combine(document, "data.json");
            String text = File.ReadAllText(filename);
            eventData = JsonConvert.DeserializeObject<MainEvent>(text);
            dataServiceInstance.SetEvent(eventData);

            FindViews();
            CreateActionDrawer();
            SetListBackground();

            mainMenuFragment = new MainMenuFragment(dataServiceInstance);
            frequentQuestionsFragment = new FrequentQuestionsFragment();
            presentersFragment = new PresentersFragment();
            galleryFragment = new GalleryFragment();
            mapFragment = new MapFragment();
            presenterDetailFragment = new PresenterDetailFragment();
            galleryDetailFragment = new GalleryDetailFragment();
            calendarFragment = new CalendarFragment();
            contactFragment = new ContactFragment();
            splashFragment = new SplashFragment();


            //frequentQuestionsFragment.PopulateMenu();

            mLeftDrawer.ItemClick += OnSelectedItemDrawer;

            CreateAndHideFragments();

            //Task.Run(() => ExecuteCheckAsync());
            //t.Wait();

            //Action<object> actionOfTask1 = (object obj) => { CheckData(); };

            //Task backgroundTask = new Task(actionOfTask1, "ready");
            //backgroundTask.Start();
            //backgroundTask.Wait();

            currentFragment = mainMenuFragment;
        }


        //<summary>
        //    This Function creates all the fragments for the app
        //</summary>
        public void CreateAndHideFragments()
        {
            var transaction = SupportFragmentManager.BeginTransaction();

            transaction.Add(Resource.Id.fragmentContainer, galleryDetailFragment, "Gallery Detail");
            transaction.Hide(galleryDetailFragment);

            transaction.Add(Resource.Id.fragmentContainer, contactFragment, "Contact");
            transaction.Hide(contactFragment);

            transaction.Add(Resource.Id.fragmentContainer, calendarFragment, "Calendar");
            transaction.Hide(calendarFragment);

            transaction.Add(Resource.Id.fragmentContainer, presenterDetailFragment, "Presenter Detail");
            transaction.Hide(presenterDetailFragment);

            transaction.Add(Resource.Id.fragmentContainer, mapFragment, "Map");
            transaction.Hide(mapFragment);

            transaction.Add(Resource.Id.fragmentContainer, galleryFragment, "Gallery List");
            transaction.Hide(galleryFragment);

            transaction.Add(Resource.Id.fragmentContainer, presentersFragment, "Presenters List");
            transaction.Hide(presentersFragment);

            transaction.Add(Resource.Id.fragmentContainer, frequentQuestionsFragment, "Frequent Questions");
            transaction.Hide(frequentQuestionsFragment);

            transaction.Add(Resource.Id.fragmentContainer, mainMenuFragment, "Main Menu");

            transaction.Commit();

        }

        //<summary>
        //    This Function hides the current fragment, pushes the stack and sets the new current fragment by showing it and adding it to the FragmentStack
        //</summary>
        //<param name = "fragment">
        //This parameter is the new fragment to be added as the currentFragment
        //</param>
        public void ShowFragment(SupportFragment fragment)
        {
            if (!fragment.IsVisible)
            {
                var transaction = SupportFragmentManager.BeginTransaction();

                transaction.Hide(currentFragment);
                transaction.Show(fragment);
                transaction.AddToBackStack(null);
                transaction.Commit();

                fragmentStack.Push(currentFragment);
                currentFragment = fragment;
            }
        }

        //<summary>
        //    This Function hides the current fragment, pushes the stack and sets the new current fragment by showing it and adding it to the FragmentStack
        //</summary>
        //<param name = "fragment">
        //This parameter is the new fragment to be added as the currentFragment
        //</param>
        public void CreateActionDrawer()
        {
            SetSupportActionBar(mToolbar);

            mActionBarToggle = new MActionBarToggle(this,
                mDrawerLayout,
                0,
                0);

            //Hacer el adapter
            MenuAdapter menuAdapter = new Adapters.MenuAdapter(this, menuElementsInstance.menuElements, dataServiceInstance);
            mLeftDrawer.Adapter = menuAdapter;

            mDrawerLayout.SetDrawerListener(mActionBarToggle);
            SupportActionBar.SetHomeButtonEnabled(true);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            mActionBarToggle.SyncState();
        }

        //<summary>
        //    This function instantiates the views on the file MainLayout.axml
        //</summary>
        private void FindViews()
        {
            mToolbar = FindViewById<SupportToolbar>(Resource.Id.appToolbar);
            mDrawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            mLeftDrawer = FindViewById<ListView>(Resource.Id.left_drawer);
            drawerImageView = FindViewById<ImageView>(Resource.Id.drawerImageView);
        }

        //<summary>
        //    This function uses picasso and the image target with its color transform in order to set the purple background for the side Menu
        //</summary>
        private void SetListBackground()
        {
            ImageTarget imageTarget = new ImageTarget(mLeftDrawer);
            imageTarget.filter = false;
            imageTarget.alpha = 255;
            //string url = "http://testappeventos.webcindario.com/Imagenes/ImageGallery/bg.jpg";
            Picasso.With(this).Load(Resource.Drawable.menu).Resize(600, 1000).CenterCrop().Into(imageTarget);
        }

        protected override void OnSaveInstanceState(Bundle outState)
        {
            if (mDrawerLayout.IsDrawerOpen((int)GravityFlags.Left))
            {
                outState.PutString("DrawerState", "Opened");
                //currentFragment = fragmentStack.Pop(); :|
            }
            else
            {
                outState.PutString("DrawerState", "Closed");
            }
            base.OnSaveInstanceState(outState);
        }

        private void CheckData()
        {
            InstanceDataOnFragments();
        }

        //<summary>
        //    This function loads and instantiates each DataService instance on all of the fragments.
        //</summary>
        public void InstanceDataOnFragments()
        {
            frequentQuestionsFragment.SetFrequentQuestionList(dataServiceInstance.GetEvent().FrequentQuestions);
            presentersFragment.SetPresentersList(dataServiceInstance);
            galleryFragment.SetImageList(dataServiceInstance.GetEvent().ImageGallery);
            mapFragment.InstantiateDataAndInitializeMap(dataServiceInstance);
            calendarFragment.InstantiateDataService(dataServiceInstance);
            contactFragment.InstantiateDataService(dataServiceInstance);
        }

        protected override void OnPostCreate(Bundle savedInstanceState)
        {
            base.OnPostCreate(savedInstanceState);
            mActionBarToggle.SyncState();
        }

        //<summary>
        //    This function closes the drawer when the home button is pressed or it opens the drawer if it's closed
        //</summary>
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case (Android.Resource.Id.Home):
                    mDrawerLayout.CloseDrawer(mLeftDrawer);
                    if (!mDrawerLayout.IsDrawerOpen(mLeftDrawer))
                    {
                        mDrawerLayout.OpenDrawer(mLeftDrawer);
                    }
                    return true;
                default:

                    return true;
            }
        }

        //<summary>
        //    This function was overriden in order to allow it to take control of the FragmentStack and the App BackStack in order to return to the last fragment by pressing the Back Button on the device
        //</summary>
        public override void OnBackPressed()
        {
            if (SupportFragmentManager.BackStackEntryCount > 0)
            {
                SupportFragmentManager.PopBackStack();
                currentFragment = fragmentStack.Pop();
            }
            else
            {
                base.OnBackPressed();
            }
        }

        //<summary>
        //    This function takes control of the side Menu by showing the respective fragment on each case, the function may be used within a delegate
        //</summary>
        //<param name="sender">
        //sender is the view or object that's listening this event
        //</param>
        //<param name="e">
        //"e" is the eventArgs called with the view
        //</param>
        private void OnSelectedItemDrawer(object sender, ItemClickEventArgs e)
        {
            if (!fragmentInstantiated)
            {
                InstanceDataOnFragments();
                fragmentInstantiated = true;
            }

            mDrawerLayout.CloseDrawer(mLeftDrawer);
            switch (e.Id)
            {
                case 0:
                    ShowFragment(mainMenuFragment);
                    SupportActionBar.SetTitle(Resource.String.titleMain);
                    CheckOnlineMessage();
                    break;
                case 1:
                    ShowFragment(mapFragment);
                    SupportActionBar.SetTitle(Resource.String.titlePlace);
                    CheckOnlineMessage();
                    break;
                case 2:
                    ShowFragment(calendarFragment);
                    calendarFragment.PopulateData();
                    SupportActionBar.SetTitle(Resource.String.titleCalendar);
                    //CheckOnlineMessage();
                    break;
                case 3:
                    ShowFragment(presentersFragment);
                    presentersFragment.PopulateMenu();
                    SupportActionBar.SetTitle(Resource.String.titlePresenters);
                    CheckOnlineMessage();
                    break;
                case 4:
                    ShowFragment(galleryFragment);
                    galleryFragment.PopulateMenu();
                    SupportActionBar.SetTitle(Resource.String.titleGaleria);
                    CheckOnlineMessage();
                    break;
                case 5:
                    ShowFragment(frequentQuestionsFragment);
                    frequentQuestionsFragment.PopulateMenu();
                    SupportActionBar.SetTitle(Resource.String.titleFrequentQuestions);
                    //CheckOnlineMessage();
                    break;
                case 6:
                    ShowFragment(contactFragment);
                    contactFragment.PopulateData();
                    SupportActionBar.SetTitle(Resource.String.titleContact);
                    CheckOnlineMessage();
                    break;
                case 7:
                    facebookIntent();
                    CheckOnlineMessage();
                    break;
                default:
                    break;
            }
            //Toast.MakeText(this, e.Id.ToString(), ToastLength.Long).Show();
        }

        //<summary>
        //    This function launches the facebook app intent
        //</summary>
        public void facebookIntent()
        {
            Android.Net.Uri uri = Android.Net.Uri.Parse("fb://page/153563447786");
            Intent intent = new Intent(Intent.ActionView, uri);
            StartActivity(intent);
        }

        public DataService GetDataServiceInstance()
        {
            return dataServiceInstance;
        }

        public bool IsInternetConnectionAvailable()
        {
            ConnectivityManager conMngr = (ConnectivityManager)this.GetSystemService(Context.ConnectivityService);
            var networkInfo = conMngr.ActiveNetworkInfo;
            return networkInfo != null && networkInfo.IsConnected && networkInfo.IsAvailable;

        }

        public void CheckOnlineMessage()
        {
            if (!IsInternetConnectionAvailable())
            {
                Toast.MakeText(this, "No estás conectado, Verifica tu conexión a internet", ToastLength.Short).Show();
            }
        }
    }
}

