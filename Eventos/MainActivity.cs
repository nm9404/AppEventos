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

namespace Eventos
{
    [Activity(Label = "Eventos", MainLauncher = false, Icon = "@drawable/icon", Theme = "@style/MyTheme")]
    public class MainActivity : ActionBarActivity
    {
        int count = 1;
        bool fragmentInstantiated = false;
        MainEvent mainEvent = new MainEvent();
        DataService dataServiceInstance = new DataService();

        private SupportToolbar mToolbar;
        private MActionBarToggle mActionBarToggle;
        private DrawerLayout mDrawerLayout;
        private ListView mLeftDrawer;

        private MenuElements menuElementsInstance = new MenuElements();
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


            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            string data = Intent.GetStringExtra("Data");
            MainEvent eventData = new MainEvent();
            eventData = JsonConvert.DeserializeObject<MainEvent>(data);
            dataServiceInstance.SetEvent(eventData);

            FindViews();
            CreateActionDrawer();

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

            var transaction = SupportFragmentManager.BeginTransaction();

            transaction.Add(Resource.Id.fragmentContainer, contactFragment, "GalleryContact");
            transaction.Hide(contactFragment);

            transaction.Add(Resource.Id.fragmentContainer, calendarFragment, "Calendar");
            transaction.Hide(calendarFragment);

            transaction.Add(Resource.Id.fragmentContainer, galleryDetailFragment, "Gallery Detail");
            transaction.Hide(galleryDetailFragment);

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

            
            //Task.Run(() => ExecuteCheckAsync());
            //t.Wait();

            //Action<object> actionOfTask1 = (object obj) => { CheckData(); };

            //Task backgroundTask = new Task(actionOfTask1, "ready");
            //backgroundTask.Start();
            //backgroundTask.Wait();

            currentFragment = mainMenuFragment;
        }

        public void ShowFragment(SupportFragment fragment)
        {
            if (fragment.IsVisible)
            {
                return;
            }

            var transaction = SupportFragmentManager.BeginTransaction();

            transaction.Hide(currentFragment);
            transaction.Show(fragment);
            transaction.AddToBackStack(null);
            transaction.Commit();

            fragmentStack.Push(currentFragment);
            currentFragment = fragment;
        }

        public void CreateActionDrawer()
        {
            SetSupportActionBar(mToolbar);

            mActionBarToggle = new MActionBarToggle(this,
                mDrawerLayout,
                0,
                0);

            //Hacer el adapter
            MenuAdapter menuAdapter = new Adapters.MenuAdapter(this, menuElementsInstance.menuElements);
            mLeftDrawer.Adapter = menuAdapter;

            mDrawerLayout.SetDrawerListener(mActionBarToggle);
            SupportActionBar.SetHomeButtonEnabled(true);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            mActionBarToggle.SyncState();
        }


        private void FindViews()
        {
            mToolbar = FindViewById<SupportToolbar>(Resource.Id.appToolbar);
            mDrawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            mLeftDrawer = FindViewById<ListView>(Resource.Id.left_drawer);
        }

 

        protected override void OnSaveInstanceState(Bundle outState)
        {
            if (mDrawerLayout.IsDrawerOpen((int)GravityFlags.Left))
            {
                outState.PutString("DrawerState", "Opened");
                currentFragment = fragmentStack.Pop();
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

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch(item.ItemId)
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
                    ShowFragment(mapFragment);
                    break;
                case 1:
                    ShowFragment(calendarFragment);
                    calendarFragment.PopulateData();
                    break;
                case 2:
                    ShowFragment(presentersFragment);
                    presentersFragment.PopulateMenu();
                    break;
                case 3:
                    ShowFragment(galleryFragment);
                    galleryFragment.PopulateMenu();
                    break;
                case 4:
                    ShowFragment(frequentQuestionsFragment);
                    frequentQuestionsFragment.PopulateMenu();
                    break;
                case 5:
                    ShowFragment(contactFragment);
                    contactFragment.PopulateData();
                    break;
                default:
                    break;
            }
            Toast.MakeText(this, e.Id.ToString(), ToastLength.Long).Show();
        }

        public DataService GetDataServiceInstance()
        {
            return dataServiceInstance;
        }
    }
}

